var tjwqTitleVal = $('.tjwqtitle').text().trim();
if($(".listbtnz").hasClass("tjwqActive")) {
	var secVal = $('.tjwqActive').text();
}
$('#tjwqtitlenav').text('欢迎登陆本系统！您当前的位置为:' + tjwqTitleVal + ' > ' + secVal);
$('#tjwqBtn div').click(function() {

	var self = $(this);
	if(self.attr("url") != undefined && self.attr("url") != "") {
		var url = self.attr("url");
		//alert(url);
		$("#mainFrame").attr("src", url);
	}

})
$('#tjwqBtn .listbtnz').click(function() {
	if($(this).next().is(".list_hidegrp")) {
		if($(this).is(".on_xk")) {
			$(this).removeClass("on_xk");
			$(this).next(".list_hidegrp").stop().animate({
				"height": 0
			}, 300);
		} else {
			$(this).addClass("on_xk").siblings(".listbtnz").removeClass("on_xk");
			var _thisheight_ = $(this).next(".list_hidegrp").stop().height();
			var _thisaim_ = $(this).next(".list_hidegrp").css("height", "auto").height();
			$(this).next(".list_hidegrp").css("height", _thisheight_).animate({
				"height": _thisaim_
			}, 300);
			$(this).next(".list_hidegrp").siblings(".list_hidegrp").stop().animate({
				"height": 0
			}, 300);
		}
	} else {
		$(this).addClass("on_xk").siblings(".listbtnz").removeClass("on_xk");
		$(this).siblings(".list_hidegrp").stop().animate({
			"height": 0
		}, 300);
		$('#tjwqBtn .listbtnz').removeClass('tjwqActive');
		$(this).addClass('tjwqActive');
		var tjwqTitleVal = $('.tjwqtitle').text().trim();
		if($(".listbtnz").hasClass("tjwqActive")) {
			var secVal = $('.tjwqActive').children("div").text();
		}
		if(secVal == undefined) {
			$('#tjwqtitlenav').text('欢迎登陆本系统！您当前的位置为:' + tjwqTitleVal);
		} else {
			$('#tjwqtitlenav').text('欢迎登陆本系统！您当前的位置为:' + tjwqTitleVal + ' > ' + secVal);
		}
	}
});
var linkjump = {
	"检测数据查询": "./jianceshujuchaxun.html",
	"车辆查询": "./cheliangchaxun.html",
	"检测站查询": "./jiancezhanchaxun.html",
	"新车查询": "./xinchefenxi.html",
	"新车审核": "./cheliangshenhe.html",
	"新车录入": "./cheliangshenheluru.html",
	"外转车查询": "./waizhuanchechaxun.html",
	"检测量统计报表_日报": "./jianceliangtongjibaobiao_date.html",
	"检测量统计报表_月报": "./jianceliangtongjibaobiao_month.html",
	"检测量统计报表_年报": "./jianceliangtongjibaobiao_year.html",
	"合格量统计报表_日报": "./hegeliangtongjibaobiao_date.html",
	"合格量统计报表_月报": "./hegeliangtongjibaobiao_month.html",
	"合格量统计报表_年报": "./hegeliangtongjibaobiao_year.html",
	"车辆轻重型统计报表_日报": "./cheliangqingzhongxingtongjibaobiao_date.html",
	"车辆轻重型统计报表_月报": "./cheliangqingzhongxingtongjibaobiao_month.html",
	"车辆轻重型统计报表_年报": "./cheliangqingzhongxingtongjibaobiao_year.html",
	"标志类型统计报表_日报": "./biaozhileixingtongjibaobiao_date.html",
	"标志类型统计报表_月报": "./biaozhileixingtongjibaobiao_month.html",
	"标志类型统计报表_年报": "./biaozhileixingtongjibaobiao_year.html",
	"检测标志量统计报表_日报": "./jiancebiaozhiliangtongjibaobiao_date.html",
	"检测标志量统计报表_月报": "./jiancebiaozhiliangtongjibaobiao_month.html",
	"检测标志量统计报表_年报": "./jiancebiaozhiliangtongjibaobiao_year.html",
	"信息管理": "./xinxiguanli.html",
	"信息发布": "./xinxifabu.html",
	"信息浏览": "./xinxiliulan.html",
	"遥测分析":"./yaocefenxi.html",
	"路检路查":"./lujianlucha.html",
	"门站式执法":"./menzhanshizhifa.html",
	"移动式执法":"./yidongshizhifa.html",
	'组织机构管理':"./zuzhijigouguanli.html",
	'用户管理':'yonghuguanli.html',
	'权限管理':'quanxianguanli.html',
	'检测站人员审核':'jiancezhanrenyuanshenhe.html',
	'业务角色管理':'yewujueseguanli.html',
	'登录日志':'denglurizhi.html',
	'操作日志':'caozuorizhi.html',
	'日志状态设置':'rizhizhuangtaishezhi.html',
	'数据字典':'shujuzidainguanli.html',
	'限值管理':'xianzhiguanli.html',
	'车辆维修信息':'cheliangweixiuxinxi.html',
	'限行信息管理':'xianxingxinxiguanli.html',
	'车型信息管理':'hexingxinxiguanli.html',
	'设备检定管理':'shebeijiandingguanli.html',
	'达标车型管理':'dabiaochexingguanli.html',
	'设备维修管理':'shebeiweixiuguanli.html',
	'系统配置管理':'xitongpeizhiguanli.html',
	'视频通道配置':'shipintongdaopeizhi.html',
	'视频录像机配置':'shipinluxiangjipeizhi.html'
}
$(document).on("click", "[frameHref]", function() {
	var _thishref_ = $(this).attr("frameHref");
	if(_thishref_ == undefined || _thishref_ == null || _thishref_ == "") {
		if($(this).children("div").length) {
			_thishref_ = $(this).children("div").text();
		} else {
			_thishref_ = $(this).text();
		}

	}
	if(linkjump[_thishref_] != undefined && linkjump[_thishref_] != null && linkjump[_thishref_] != "") {
		_thishref_ = linkjump[_thishref_];
	}
	try {
		$("#mainFrame").attr("src", _thishref_);
	} catch(e) {
		//TODO handle the exception
	}
})

window.onload = function() {
	var oDiv = document.getElementById('roll');
	var oUl = oDiv.getElementsByTagName('ul')[0];
	var aLi = oUl.getElementsByTagName('li');
	var speed = -4;
	var oBtn1 = oDiv.getElementsByTagName('a')[0];
	var oBtn2 = oDiv.getElementsByTagName('a')[1];
	var roll_timer = null;

	oUl.innerHTML += oUl.innerHTML;
	oUl.style.width = aLi[0].offsetWidth * aLi.length + 'px';

	/*roll_timer = setInterval(function() {
	oUl.style.left = oUl.offsetLeft + speed + 'px';
	if(oUl.offsetLeft < -oUl.offsetWidth / 2) {
		oUl.style.left = 0 + 'px';
	} else if(oUl.offsetLeft > (0)) {
		oUl.style.left = -oUl.offsetWidth / 2 + 'px';
	}
	}, 30);*/

	//左
	oBtn1.onclick = function() {
		speed = 82;
		oUl.style.left = oUl.offsetLeft + speed + 'px';
		if(oUl.offsetLeft < -oUl.offsetWidth / 2) {
			oUl.style.left = 0 + 'px';
		} else if(oUl.offsetLeft > (0)) {
			oUl.style.left = -oUl.offsetWidth / 2 + 'px';
		}
	}
	//右
	oBtn2.onclick = function() {
		speed = -82;
		oUl.style.left = oUl.offsetLeft + speed + 'px';
		if(oUl.offsetLeft < -oUl.offsetWidth / 2) {
			oUl.style.left = 0 + 'px';
		} else if(oUl.offsetLeft > (0)) {
			oUl.style.left = -oUl.offsetWidth / 2 + 'px';
		}
	}
};

/*--------------------------------*/
$('.chartmapbox_xk ul a').click(function() {
	if(!$(this).is(".on_xk")) {
		$(this).addClass("on_xk").parent("li").siblings("li").children("a").removeClass("on_xk");

	}
})