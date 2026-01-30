# AutoEvent（兼容更新版）

AutoEvent 是一个用于 **SCP: Secret Laboratory** 的 Exiled 插件，可在服务器中 **自动运行各类小游戏（Mini-Games）**，为服务器提供更加丰富、有趣的自动化活动体验，适用于娱乐服、活动服及社区服务器。

本项目基于原作者 **RisottoMan** 开发的 AutoEvent 插件进行修改与维护，**对插件进行了新版本兼容性适配**，使其能够在当前最新游戏版本与 Exiled 环境中正常运行。

---

## 项目来源

- 原项目地址：  
  https://github.com/RisottoMan/AutoEvent

- 本版本说明：  
  在原项目基础上进行兼容性与稳定性修改，确保插件能够在新版本环境下 **正常编译、加载并运行**。

---

## 兼容性支持

已在以下环境中测试并可正常使用：

- **SCP: Secret Laboratory** `14.2.5`
- **Exiled** `9.12.6`

本版本主要解决了原插件在新版本游戏与 Exiled 框架下出现的：
- API 变更导致的兼容问题  
- 插件无法正常加载或运行的问题  

### 已知问题

- 部分小游戏无法正常运行  
  - 主要与 **地图编辑器插件（MapEditorReborn）** 的地图生成与加载机制有关  
  - 该问题仍在排查与修复中

---

## 参与贡献

欢迎提交 **Issues** 与 **Pull Requests**，共同改进与维护本项目。

---

## 功能展示（原项目）

以下截图来自原项目，用于展示插件的运行效果与游戏内提示示例：

![Logo](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/MGMER.png)

![Guide1](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/Message.png)
![Guide2](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/Message1.png)
![Guide3](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/Message2.png)
![Guide4](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/Message3.png)
![Guide5](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/Message4.png)
![Guide6](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/Message5.png)
![Guide7](https://github.com/RisottoMan/AutoEvent/blob/beta14.1-mer/Photos/Message6.png)

---

## 致谢（Credits）

感谢原作者及社区成员对 AutoEvent 项目的贡献（保留原项目致谢内容）：

- Thanks to **xleb.ik** for creating new maps, Halloween and Winter season maps.
- Thanks to **Redforce04** for the help in changing the structures of the mini-games.
- Thanks to **ART0022VI** for a little help in fixing plugins.
- Thanks to **Alexander666** for the help at the initial stage of creating the plugin.
- Thanks to **art15** for writing the command code to run the mini-game.
- Thanks to **Sakred_** for supporting.
- Special thanks to **Michal78900** for the plugin *MapEditorReborn* for spawning maps.
- Special thanks to **Killers0992** for the plugin *AudioPlayerApi* for playing music.

本插件基于 **ExMod / Exiled 框架** 运行。

---

## 说明

- 本仓库为 **非官方维护版本**
- 修改内容主要集中在 **新版本兼容性与稳定性修复**
- 若原作者发布官方更新版本，建议优先使用官方版本
