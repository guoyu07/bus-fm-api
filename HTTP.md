# 巴士电台接口API REST版 #
**[账号管理](http://code.google.com/p/bus-fm-api/wiki/HTTP#账号管理)
  * [登录](http://code.google.com/p/bus-fm-api/wiki/HTTP#登录)
  * [注册](http://code.google.com/p/bus-fm-api/wiki/HTTP#注册)
  * [找回密码](http://code.google.com/p/bus-fm-api/wiki/HTTP#找回密码)
  * [修改密码](http://code.google.com/p/bus-fm-api/wiki/HTTP#修改密码)
  * [用户名是否可用](http://code.google.com/p/bus-fm-api/wiki/HTTP#用户名是否可用)
  * [昵称是否可用](http://code.google.com/p/bus-fm-api/wiki/HTTP#昵称是否可用)** [歌曲管理](http://code.google.com/p/bus-fm-api/wiki/HTTP#歌曲管理)
  * [频道列表](http://code.google.com/p/bus-fm-api/wiki/HTTP#得到频道列表)
    * [频道json格式](http://code.google.com/p/bus-fm-api/wiki/HTTP#频道数据格式)
  * [根据频道返回歌曲数据](http://code.google.com/p/bus-fm-api/wiki/HTTP#根据频道返回歌曲数据)
    * [歌曲json格式](http://code.google.com/p/bus-fm-api/wiki/HTTP#歌曲json格式)
  * [根据账号返回收藏列表](http://code.google.com/p/bus-fm-api/wiki/HTTP#根据账号返回收藏列表)
  * [歌曲是否被收藏](http://code.google.com/p/bus-fm-api/wiki/HTTP#歌曲是否被收藏)
  * [收藏/取消收藏](http://code.google.com/p/bus-fm-api/wiki/HTTP#收藏/取消收藏)
  * [收听列表](http://code.google.com/p/bus-fm-api/wiki/HTTP#收听列表)
  * [推荐列表](http://code.google.com/p/bus-fm-api/wiki/HTTP#推荐列表)
  * [偏好管理](http://code.google.com/p/bus-fm-api/wiki/HTTP#偏好管理)

## 账号管理 ##
  * 访问的基准URL均为http://api.bus.fm/pt/，参数可采用GET或POST方式提交
### 登录 ###
  * 调用地址：http://api.bus.fm/pt/login
  * 参数说明：
    * usermail:用户名/邮箱
    * userpwd:用户密码
    * GET方式提交示例：http://api.bus.fm/pt/login?usermail=mail@domain.com&userpwd=000000
  * 返回值：json对象，包含了登录状态，以及用户信息，如`{"userinfo":[{"member_id":"88","member_mail":"demo@bus.fm","member_nickname":"demo"}]`}
### 注册 ###
  * 调用地址：http://api.bus.fm/pt/reg
  * 参数说明：
    * usermail:用户名/邮箱
    * userpwd:用户密码
    * nickname:用户昵称
  * 返回值：状态码|状态说明，如1|注册成功,0|昵称被占用
### 找回密码 ###
  * 调用地址：http://api.bus.fm/pt/resetpwd
  * 参数说明：
    * usermail:用户名/邮箱
  * 返回值：状态码|状态说明，如1|密码已发至邮箱,0|昵称被占用
### 修改密码 ###
  * 调用地址：http://api.bus.fm/pt/changepwd
  * 参数说明：
    * userid:用户名 (注：非邮箱)
    * oldpwd:旧密码
    * newpwd:新密码
  * 返回值：状态码|状态说明，如1|修改成功,0|未知错误
### 用户名是否可用 ###
  * 调用地址：http://api.bus.fm/pt/checkusermail
  * 参数说明：
    * usermail:用户名/邮箱
  * 返回值：状态码或错误描述，0为可用，1为已被占用，其他情况为错误描述
### 昵称是否可用 ###
  * 调用地址：http://api.bus.fm/pt/checknickname
  * 参数说明：
    * nickname:用户昵称
  * 返回值：状态码或错误描述，0为可用，1为已被占用，其他情况为错误描述
## 歌曲管理 ##
  * 访问的基准URL均为http://api.bus.fm/pt/，即与账号管理同入口，参数可采用GET或POST方式提交，
### 得到频道列表 ###
  * 调用地址：http://api.bus.fm/pt/getchannellist
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
  * 调用地址：http://api.bus.fm/pt/getlistbychannel
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
  * 调用地址：http://api.bus.fm/pt/getlistbyuserid
  * 参数说明：
    * userid:用户ID
    * appkey:应用授权ID
  * 返回值：json数组 [格式](http://code.google.com/p/bus-fm-api/wiki/HTTP#歌曲json格式)
### 歌曲是否被收藏 ###
  * 调用地址：http://api.bus.fm/pt/isfaved
  * 参数说明：
    * userid:用户ID
    * songid:歌曲ID
  * 返回值：状态码或错误描述，0为假，1为真，其他情况为错误描述
### 收藏/取消收藏 ###
  * 调用地址：http://api.bus.fm/pt/favethis
  * 参数说明：
    * userid:用户ID
    * songid:歌曲ID
  * 返回值：状态码|状态描述，如1|收藏成功，1|取消收藏成功，0|未知错误
### 收听列表 ###
### 推荐列表 ###
### 偏好管理 ###