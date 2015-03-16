# 巴士电台接口API REST版 #
**[账号管理](http://code.google.com/p/bus-fm-api/wiki/REST#账号管理)
  * [登录](http://code.google.com/p/bus-fm-api/wiki/REST#登录)
  * [注册](http://code.google.com/p/bus-fm-api/wiki/REST#注册)
  * [找回密码](http://code.google.com/p/bus-fm-api/wiki/REST#找回密码)
  * [修改密码](http://code.google.com/p/bus-fm-api/wiki/REST#修改密码)
  * [用户名是否可用](http://code.google.com/p/bus-fm-api/wiki/REST#用户名是否可用)
  * [昵称是否可用](http://code.google.com/p/bus-fm-api/wiki/REST#昵称是否可用)** [歌曲管理](http://code.google.com/p/bus-fm-api/wiki/REST#歌曲管理)
  * [频道列表](http://code.google.com/p/bus-fm-api/wiki/REST#得到频道列表)
    * [频道json格式](http://code.google.com/p/bus-fm-api/wiki/REST#频道数据格式)
  * [根据频道返回歌曲数据](http://code.google.com/p/bus-fm-api/wiki/REST#根据频道返回歌曲数据)
    * [歌曲json格式](http://code.google.com/p/bus-fm-api/wiki/REST#歌曲json格式)
  * [根据账号返回收藏列表](http://code.google.com/p/bus-fm-api/wiki/REST#根据账号返回收藏列表)
  * [歌曲是否被收藏](http://code.google.com/p/bus-fm-api/wiki/REST#歌曲是否被收藏)
  * [收藏/取消收藏](http://code.google.com/p/bus-fm-api/wiki/REST#收藏/取消收藏)
  * [收听列表](http://code.google.com/p/bus-fm-api/wiki/REST#收听列表)
  * [推荐列表](http://code.google.com/p/bus-fm-api/wiki/REST#推荐列表)
  * [偏好管理](http://code.google.com/p/bus-fm-api/wiki/REST#偏好管理)

## 账号管理 ##
### 登录 ###
  * 方法类型：GET
  * 调用地址：http://api.bus.fm/account/usermail/userpwd
  * 参数说明：
    * usermail:用户名/邮箱
    * userpwd:用户密码
  * 返回值：json对象，包含了登录状态，以及用户信息，如`{"userinfo":[{"member_id":"88","member_mail":"demo@bus.fm","member_nickname":"demo"}]`}
### 注册 ###
  * 方法类型： POST
  * 调用地址：http://api.bus.fm/account/usermail/userpwd/nickname
  * 参数说明：
    * usermail:用户名/邮箱
    * userpwd:用户密码
    * nickname:用户昵称
  * 返回值：状态码|状态说明，如1|注册成功,0|昵称被占用
### 找回密码 ###
  * 方法类型：GET
  * 调用地址：http://api.bus.fm/password/usermail
  * 参数说明：
    * usermail:用户名/邮箱
  * 返回值：状态码|状态说明，如1|密码已发至邮箱,0|昵称被占用
### 修改密码 ###
  * 方法类型：PUT
  * 调用地址：http://api.bus.fm/password/userid/oldpwd/newpwd
  * 参数说明：
    * userid:用户名 (注：非邮箱)
    * oldpwd:旧密码
    * newpwd:新密码
  * 返回值：状态码|状态说明，如1|修改成功,0|未知错误
### 用户名是否可用 ###
  * 方法类型：GET
  * 调用地址：http://api.bus.fm/validate/usermail/type
  * 参数说明：
    * usermail:用户名/邮箱
    * type: "username  "
  * 返回值：状态码或错误描述，0为可用，1为被占用，其他情况为错误描述
### 昵称是否可用 ###
  * 方法类型：GET
  * 调用地址：get http://api.bus.fm/validate/name/type
  * 参数说明：
    * nickname:用户昵称
    * type: "nickname"
  * 返回值：状态码或错误描述，0为可用，1为被占用，其他情况为错误描述
## 歌曲管理 ##
### 得到频道列表 ###
  * 方法类型：GET
  * 调用地址：http://api.bus.fm/channel/
  * 返回值：json数组
> #### 频道数据格式 ####
```
	{"Channels":
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
  * 方法类型：GET
  * 调用地址：http://api.bus.fm/music/channleid/appkey
  * 参数说明：
    * channelid:频道ID
    * appkey:应用授权ID
  * 返回值：json数组
#### 歌曲json格式 ####
```
{"Tracks":
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
  * 方法类型：GET
  * 调用地址：http://api.bus.fm/userid/appkey
  * 参数说明：
    * userid:用户ID
    * appkey:应用授权ID
  * 返回值：json数组 [格式](http://code.google.com/p/bus-fm-api/wiki/REST#歌曲json格式)
### 歌曲是否被收藏 ###
  * 方法类型：GET
  * 调用地址：http://api.bus.fm/favorite/userid/appkey/songid
  * 参数说明：
    * userid:用户ID
    * songid:歌曲ID
  * 返回值：状态码或错误描述，0为假，1为真，其他情况为错误描述
### 收藏/取消收藏 ###
  * 方法类型：PUT
  * 调用地址：http://api.bus.fm/favorite/userid/songid/appkey/act
  * 参数说明：
    * userid:用户ID
    * songid:歌曲ID
    * appkey:应用授权ID
    * act:"fav"
  * 返回值：状态码|状态描述，如1|收藏成功，1|取消收藏成功，0|未知错误
### 收听列表 ###
### 推荐列表 ###
### 偏好管理 ###