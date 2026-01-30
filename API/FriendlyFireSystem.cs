using System;
using System.Linq;
using Exiled.API.Features;

namespace AutoEvent.API;
public class FriendlyFireSystem
{
    private static Type? _cedmodFFAutobanType;
    private static bool _cedmodTypeChecked;
    public static bool CedModIsPresent { get; private set; }
    public static bool IsFriendlyFireEnabledByDefault { get; set; }
    public static bool FriendlyFireAutoBanDefaultEnabled { get; set; }
    static FriendlyFireSystem()
    {
        CedModIsPresent = false;
        initializeFFSettings();
        FriendlyFireAutoBanDefaultEnabled = IsFriendlyFireEnabledByDefault;
    }
    private static void initializeFFSettings()
    {
        if (AppDomain.CurrentDomain.GetAssemblies().Any(x => x.FullName.ToLower().Contains("cedmod")))
        {
            DebugLogger.LogDebug("CedMod has been detected.");
            CedModIsPresent = true;
        }
        else
            DebugLogger.LogDebug("CedMod has not been detected.");
    }

    public static bool FriendlyFireDetectorIsDisabled
    {
        get
        {
            try
            {
                // if cedmod detector is not paused - false
                if (CedModIsPresent)
                {
                    if (!_cedmodFFAutobanIsDisabled())
                    {
                        return false;
                    }
                }

                // if basegame detector is not paused - false
                return FriendlyFireConfig.PauseDetector;
                // Both MUST be off to be considered "paused".
            }
            catch
            {
                return false;
            }
        }
    }

    private static Type? GetCedModAutobanType()
    {
        if (_cedmodTypeChecked)
            return _cedmodFFAutobanType;

        _cedmodTypeChecked = true;
        _cedmodFFAutobanType = AppDomain.CurrentDomain
            .GetAssemblies()
            .Select(a => a.GetType("CedMod.FriendlyFireAutoban", false))
            .FirstOrDefault(t => t != null);

        return _cedmodFFAutobanType;
    }

    private static bool _cedmodFFAutobanIsDisabled()
    {
        var type = GetCedModAutobanType();
        if (type == null)
            return false;

        var prop = type.GetProperty("AdminDisabled");
        return prop != null && (bool)prop.GetValue(null);
    }

    private static void _cedmodFFDisable()
    {
        var type = GetCedModAutobanType();
        var prop = type?.GetProperty("AdminDisabled");
        prop?.SetValue(null, true);
    }

    private static void _cedmodFFEnable()
    {
        var type = GetCedModAutobanType();
        var prop = type?.GetProperty("AdminDisabled");
        prop?.SetValue(null, false);
    }

    public static void EnableFriendlyFireDetector()
    {
        DebugLogger.LogDebug("Enabling Friendly Fire Detector.");
        try
        {
            FriendlyFireConfig.PauseDetector = false;

            if (CedModIsPresent)
            {
                _cedmodFFEnable();
            }
        }
        catch { }
    }

    public static void DisableFriendlyFireDetector()
    {
        try
        {
            DebugLogger.LogDebug("Disabling Friendly Fire Detector.");
            FriendlyFireConfig.PauseDetector = true;

            if (CedModIsPresent)
            {
                _cedmodFFDisable();
            }
        }
        catch { }
    }

    public static void EnableFriendlyFire()
    {
        DebugLogger.LogDebug("Enabling Friendly Fire.");
        
        Server.FriendlyFire = true;
    }

    public static void DisableFriendlyFire()
    {
        DebugLogger.LogDebug("Disabling Friendly Fire.");

        Server.FriendlyFire = false;
    }

    public static void RestoreFriendlyFire()
    {
        DebugLogger.LogDebug("Restoring Friendly Fire and Detector.");
        Server.FriendlyFire = IsFriendlyFireEnabledByDefault;

        return; //03.05.2025 fix console errors
        
        if (FriendlyFireAutoBanDefaultEnabled && FriendlyFireDetectorIsDisabled)
        {
            EnableFriendlyFireDetector();
        }

        if (!FriendlyFireAutoBanDefaultEnabled && !FriendlyFireDetectorIsDisabled)
        {
            DisableFriendlyFireDetector();
        }
    }
}
