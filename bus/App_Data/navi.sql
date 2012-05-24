/*
id
网站名
网址
分类
标签
简介
截图
推荐人
推荐人邮箱
推荐时间
审核状态
修改时间

分类表

标签表
*/

create table category(id integer primary key  autoincrement, catename varchar(50) default '未命名', count integer default 0);
create table tag(id integer primary key autoincrement, tag varchar(50), count integer default 0);
create table sites(
	id integer primary key autoincrement,
	sitename varchar(100) not null,
	siteurl varchar(255) not null,
	siteimg varchar(255),
	category integer not null,
	tags varchar(255),
	summary varchar(1000),
	submit varchar(50),
	sub_mail varchar(255),
	sub_time datetime default (datetime('now','localtime')),
	status integer default 0,
	modify_time datetime default (datetime('now','localtime'))
)