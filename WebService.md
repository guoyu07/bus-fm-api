# 巴士电台接口API Web Service版 #
  * [服务地址](http://code.google.com/p/bus-fm-api/wiki/WebService#服务地址)
  * [账号管理](http://code.google.com/p/bus-fm-api/wiki/WebService#账号管理)
  * [登录](http://code.google.com/p/bus-fm-api/wiki/WebService#登录)
  * [注册](http://code.google.com/p/bus-fm-api/wiki/WebService#注册)
  * [找回密码](http://code.google.com/p/bus-fm-api/wiki/WebService#找回密码)
  * [修改密码](http://code.google.com/p/bus-fm-api/wiki/WebService#修改密码)
  * [用户名是否可用](http://code.google.com/p/bus-fm-api/wiki/WebService#用户名是否可用)
  * [昵称是否可用](http://code.google.com/p/bus-fm-api/wiki/WebService#昵称是否可用)
**[歌曲管理](http://code.google.com/p/bus-fm-api/wiki/WebService#歌曲管理)
  * [频道列表](http://code.google.com/p/bus-fm-api/wiki/WebService#得到频道列表)
    * [频道json格式](http://code.google.com/p/bus-fm-api/wiki/WebService#频道数据格式)
  * [根据频道返回歌曲数据](http://code.google.com/p/bus-fm-api/wiki/WebService#根据频道返回歌曲数据)
    * [歌曲json格式](http://code.google.com/p/bus-fm-api/wiki/WebService#歌曲json格式)
  * [根据账号返回收藏列表](http://code.google.com/p/bus-fm-api/wiki/WebService#根据账号返回收藏列表)
  * [歌曲是否被收藏](http://code.google.com/p/bus-fm-api/wiki/WebService#歌曲是否被收藏)
  * [收藏/取消收藏](http://code.google.com/p/bus-fm-api/wiki/WebService#收藏/取消收藏)
  * [收听列表](http://code.google.com/p/bus-fm-api/wiki/WebService#收听列表)
  * [推荐列表](http://code.google.com/p/bus-fm-api/wiki/WebService#推荐列表)
  * [偏好管理](http://code.google.com/p/bus-fm-api/wiki/WebService#偏好管理)**

## 服务地址 ##
  * 权限模块：http://api.bus.fm/auth?wsdl
  * 歌曲模块：http://api.bus.fm/music?wsdl
## 账号管理 ##
  * 此处用useraccount代表生成的用户验证代理类，实际应用中以自己生成的本地代理类为准
### 登录 ###
  * 调用方法：useraccount.login(string usermail, string userpwd)
  * 参数说明：
    * Usermail:用户名/邮箱
    * Userpwd:用户密码
  * 返回值：json对象，包含了登录状态，以及用户信息，如`{"userinfo":[{"member_id":"88","member_mail":"demo@bus.fm","member_nickname":"demo"}]`}
### 注册 ###
  * 调用方法：useraccount.reg(string usermail, string userpwd, string nickname)
  * 参数说明：
    * Usermail:用户名/邮箱
    * Userpwd:用户密码
    * Nickname:用户昵称
  * 返回值：状态码|状态说明，如1|注册成功,0|昵称被占用
### 找回密码 ###
  * 调用方法：useraccount.resetPassword(string usermail)
  * 参数说明：
    * Usermail:用户名/邮箱
  * 返回值：状态码|状态说明，如1|密码已发至邮箱,0|昵称被占用
### 修改密码 ###
  * 调用方法：useraccount.changePassword(string userid, string oldpwd, string newpwd)
  * 参数说明：
    * Userid:用户名 (注：非邮箱)
    * Oldpwd:旧密码
    * Newpwd:新密码
  * 返回值：状态码|状态说明，如1|修改成功,0|未知错误
### 用户名是否可用 ###
  * 调用方法：useraccount.checkUsermail(string usermail)
  * 参数说明：
    * Usermail:用户名/邮箱
  * 返回值：状态码或错误描述，0为假，1为真，其他情况为错误描述
### 昵称是否可用 ###
  * 调用方法：useraccount.checkNickname(string nickname,)
  * 参数说明：
    * Nickname:用户昵称
  * 返回值：状态码或错误描述，0为假，1为真，其他情况为错误描述
## 歌曲管理 ##
  * 此处用musicdata代表生成的歌曲数据代理类，实际应用中以自己生成的本地代理类为准
### 得到频道列表 ###
  * 调用方法：musicdata.GetChannelList()
  * 返回值：json数组
> #### 频道数据格式 ####
```
	{"Tracks":
		[
			{"cid":"1","cname":"白"},
			{"cid":"2","cname":"灰"},
			{"cid":"3","cname":"黑"},
			{"cid":"4","cname":"红"},
			{"cid":"99","cname":"私人频道"}
		]
	} 
```
### 根据频道返回歌曲数据 ###
  * 调用方法：musicdata.getListByChannel(string channelId, string apikey)
  * 参数说明：
    * ChannelID:频道ID
    * Apikey:应用授权ID
  * 返回值：json数组
#### 歌曲json格式 ####
```
{"Channels":
	[
		{
		"songid":"1045",
		"title":"If You Want To",
		"url":"http://ftp.luoo.net/radio/radio93/02.mp3",
		"artist":"Alligators",
		"album":"Piggy and Cups",
		"thumb":"http://www.luoo.net/wp-content/uploads/ds.jpg"
		},
		{
		"songid":"1503",
		"title":"Let Go of the Dream",
		"url":"http://ftp.luoo.net/radio/radio133/03.mp3",
		"artist":"Hurricane No.1",
		"albutm":"Hurricane No.1",
		"thumb":"http://t.douban.com/lpic/s3832173.jpg"
		}
	]
}
```
### 根据账号返回收藏列表 ###
  * 调用方法：musicdata.getListByUserID(string userid, string apikey)
  * 参数说明：
    * Userid:用户ID
    * Apikey:应用授权ID
  * 返回值：json数组 [格式](http://code.google.com/p/bus-fm-api/wiki/WebService#歌曲json格式)
### 歌曲是否被收藏 ###
  * 调用方法：musicdata.isFaved(string userid,string songid)
  * 参数说明：
    * Userid:用户ID
    * Songid:歌曲ID
  * 返回值：状态码或错误描述，0为假，1为真，其他情况为错误描述
### 收藏/取消收藏 ###
  * 调用方法：musicdata.FaveThis(string userid,string songid)
  * 参数说明：
    * Userid:用户ID
    * Songid:歌曲ID
  * 返回值：状态码|状态描述，如1|收藏成功，1|取消收藏成功，0|未知错误
### 收听列表 ###
### 推荐列表 ###
### 偏好管理 ###