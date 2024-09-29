# HiddenChannel
> 通过RSA进行加密的端到端加密通讯工具

![](https://github.com/Mangofang/HiddenChannel/blob/main/Image/Head.gif)

整个应用包含服务端和客户端，客户端使用`C#`服务端使用`Python`

你可以在Releases中试用本应用，每天会删除服务器讯息

如果你有任何问题或反馈程序问题请提交`Issues`

## 声明：
1. 文中所涉及的技术、思路和工具仅供以安全为目的的学习交流使用，任何人不得将其用于非法用途以及盈利等目的，否则后果自行承担！
2. 水平不高，纯萌新面向Google编程借鉴了很多大佬的代码，请自行酌情修改

## 执行流程
你可以在程序中创建聊天室

程序会生成2048位RSA密钥，公钥会上传至服务器保存用于加密信息，私钥留在本地用于解密信息
<img src="https://github.com/Mangofang/HiddenChannel/blob/main/Image/CreateRoom.jpg" width="65%">

加入房间时会从服务端获取公钥，当需要发送信息时使用公钥对信息进行加密

对于接收到的讯息，使用私钥进行解密

<img src="https://github.com/Mangofang/HiddenChannel/blob/main/Image/SendMessage.jpg" width="65%">

## 服务端部署
**注意：代码水平有限，建议自行进行再优化**

服务端使用Python Flask WebApi + Mysql（可自行替换脚本内的数据库语句兼容其他数据库）

``` shell
# 安装模块
pip install -r requirements.txt
# 创建数据库 可自行修改数据库名 需要对应配置WebApi.py
CREATE DATABASE HiddenChannel
# 创建表或导入转储文件
CREATE TABLE `messages` (
  `RoomId` varchar(100) DEFAULT NULL,
  `Username` varchar(100) DEFAULT NULL,
  `Text` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `room` (
  `RoomId` varchar(100) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Own` varchar(100) DEFAULT NULL,
  `PublicKey` varchar(500) DEFAULT NULL,
  `Info` varchar(100) DEFAULT NULL
) ENGINE=MEMORY DEFAULT CHARSET=utf8mb4;

CREATE TABLE `user` (
  `Username` varchar(100) DEFAULT NULL,
  `Passwd` varchar(100) DEFAULT NULL,
  `IsLogin` varchar(100) DEFAULT NULL,
  `Session` varchar(100) DEFAULT NULL,
  `InRoom` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

# 配置WabApi.py

# 启动WebApi.py
python WebApi.py
```

## 更新
2024年09月30日
  1. 公开仓库

## 可能的更新
1. 代码优化
2. 文件传输
