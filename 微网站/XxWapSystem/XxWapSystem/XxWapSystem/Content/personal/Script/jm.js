function IntConsumeDailyGift(msg) {
    if (confirm(msg))
        Ajax("POST", "/cv/ajaxCvView", "type=3&cvID=" + _("showCvMainID").value, IntConsumeDailyGiftCallback, false);
}
//消耗储值会员的balanc
function IntConsumeMoney(consumeType) {
    Ajax("POST", "/cv/ajaxCvView", "consumeType=" + consumeType + "&type=2&cvID=" + _("showCvMainID").value, IntConsumeMoneyCallback, false);
}
function IntConsumeActiveQuota() {
    if (confirm("继续操作将消费您一个简历下载数，是否继续")) {
        Ajax("POST", "/cv/ajaxCvView", "type=4&cvID=" + _("showCvMainID").value, IntConsumeActiveQuotaCallback, false);
    }
}
function SaveInterview() {
    if (checkForm()) {
        Ajax("POST", "/cv/InterViewSendBatch", "jobname=" + _("jobname").value + "&JobID=" + _("JobID").value + "&cvMainIDs=" + _("cvMainIDs").value + "&paNames=" + _("paNames").value + "&InterviewDate=" + _("InterviewDate").value + "&InterViewPlace=" + _("InterViewPlace").value + "&LinkMan=" + _("LinkMan").value + "&Telephone=" + _("Telephone").value, SaveInterviewCallBack, false);
    }
}
function SaveInterviewCallBack(obj) {
    _("contentTable").innerHTML = obj.responseText + " <div> <input type='button' value='关闭' class='infoBoxBtn' onClick='popbox.close()'/></div>";
}

function checkInterViewForm(replyid) {
    var content = _("messageContent");
    var message = "";
    if (content != null) {
        if ((content.value.indexOf("娘") >= 0) || (content.value.indexOf("妈") >= 0) || (content.value.indexOf("日您") >= 0) || (content.value.indexOf("龟孙子") >= 0) || (content.value.indexOf("老子") >= 0) || (content.value.indexOf("蛋") >= 0) || (content.value.indexOf("玩意") >= 0) || (content.value.indexOf("操您") >= 0) || (content.value.indexOf("混账") >= 0) || (content.value.indexOf("奶") >= 0) || (content.value.indexOf("妓女") >= 0) || (content.value.indexOf("傻逼") >= 0) || (content.value.indexOf("垃圾") >= 0) || (content.value.indexOf("短信群发") >= 0) || (content.value.indexOf("15069086158") >= 0) || (content.value.indexOf("鄙视") >= 0)) {
            popbox.error("对不起，回复内容不能出现敏感字词!");
            content.focus();
            content.select();
            return false;
        }
        if (replyid == "2" && content.value == "") {
            popbox.error("对不起，回复内容不能为空!");
            content.focus();
            content.select();
            return false;
        }
        message = content.value;
    }
    submitInterViewReply(_("showInterViewID").value, message, replyid)
}

function submitInterViewReply(Id, message, replyid) {
    Ajax("post", "/personal/jm/InterViewReplyInsert", "replyid=" + replyid + "&ID=" + Id + "&Message=" + escape(message), batchMessageCallback, false);
}
function MsgConsumeDailyGift(msg) {
    if (confirm(msg))
        Ajax("POST", "/cv/ajaxCvView", "type=3&cvID=" + _("showCvMainID").value, MsgConsumeDailyGiftCallback, false);
}


//收藏简历 ajax返回处理方法
function batchMessageCallback(obj) {
    var date = obj.responseText
    if (date == "1") {
        popbox.error('回复成功!');
        Ajax("POST", "/personal/jm/InterViewList", batchMessageCallback, false);
    }
    else if (date == -100) {
        popbox.error("请从本网站提交");
        return;
    }
    else if (date == -101) {
        popbox.error("您还没有登录，请您先登录");
    }
    else
        popbox.error(date);
}

function BatchDeletePop(Type) {
    var ids = "";
    $('.ck_yes').each(function () {
        if (typeof ($(this).attr('jobid')) != "undefined") {
            ids += $(this).attr('value') + ",";
        }
    });
    if (ids) {
        if (Type) {
            var func1 = "BatchDelete(" + Type + ")";
            var func2 = "popbox2.close();";
            popbox2.confirm("您确定要删除选中的职位吗？", 1, "确定", "取消", func1, func2);
        }
        else {
            popbox.error("请选择职位！")
        }
    }
    else {
        popbox.error("请选择职位！")
    }
}


function BatchDelete(Type) {
    var typeName = "";
    if (Type == 1) {
        typeName = "JobApply";
    }
    else if (Type == 2) {
        typeName = "Favorate";
    }
    else if (Type == 3) {
        typeName = "CvIntention";
    }
    var ids = "";
    $('.ck_yes').each(function () {
        if (typeof ($(this).attr('jobid')) != "undefined") {
            ids += $(this).attr('value') + ",";
        }
    });
    ids = ids.substr(0, ids.length - 1);
    var url = "/personal/jm/" + typeName + "Delete?ids=" + ids + "&url=" + escape(document.location.toString());
    Ajax("get", url, "", BatchDeleteCallback, true)
}

function BatchDeleteCallback(obj) {
    location.reload();
}

//申请职位
function BatchApplyJob(id) {
    var jobids = "";
    var cvid = "";
    if (!id) {
        $('.ck_yes').each(function () {
            jobids += $(this).attr('jobid') + ",";
            if ($(this).attr('cvmainid'))
                cvid = $(this).attr('cvmainid');
            else
                cvid = document.getElementById("jobSelect").value;
        });
        if (jobids.length > 0) {
            jobids = jobids.substr(0, jobids.length - 1);
        }
    }
    else {
        jobids = id;
        cvid = document.getElementById("jobSelect").value;
    }
    if (cvid) {
        var url = "/Personal/Jm/ApplyJobInsert?jobids=" + jobids + "&cvid=" + cvid;
        Ajax("get", url, "", BatchApplyJobCallBack, true)
    }
    else
        popbox.error("请选择职位！")
    popbox2.close();
}


function BatchApplyJob2(id, cvid) {
    var jobids = "";
    if (id == "") {
        $('.ck_yes').each(function () {
            jobids += $(this).attr('jobid') + ",";
        });
        if (jobids.length > 0) {
            jobids = jobids.substr(0, jobids.length - 1);
        }
    }
    else {
        jobids = id;
    }
    if (jobids) {
        var url = "/Personal/Jm/ApplyJobInsert?jobids=" + jobids + "&cvid=" + cvid;
        Ajax("get", url, "", BatchApplyJobCallBack, true)
    }
    else
        popbox.error("请选择职位！")
}


//申请职位
function BatchApplyJob3(id) {
    var jobids = "";
    var cvid = "";
    if (!id) {
        $('.ck_yes').each(function () {
            jobids += $(this).attr('jobid') + ",";
            if ($(this).attr('cvmainid'))
                cvid = $(this).attr('cvmainid');
            else
                cvid = document.getElementById("jobSelect").value;
        });
        if (jobids.length > 0) {
            jobids = jobids.substr(0, jobids.length - 1);
        }
    }
    else {
        jobids = id;
        cvid = document.getElementById("jobSelect").value;
    }
    if (cvid) {
        var url = "/Personal/Jm/ApplyJobInsert?jobids=" + jobids + "&cvid=" + cvid;
        Ajax("get", url, "", BatchApplyJobCallBack3, true)
    }
    else
        popbox.error("请选择职位！")
    popbox2.close();
}


function BatchApplyJob4(id, cvid) {
    var jobids = "";
    if (id == "") {
        $('.ck_yes').each(function () {
            jobids += $(this).attr('jobid') + ",";
        });
        if (jobids.length > 0) {
            jobids = jobids.substr(0, jobids.length - 1);
        }
    }
    else {
        jobids = id;
    }
    if (jobids) {
        var url = "/Personal/Jm/ApplyJobInsert?jobids=" + jobids + "&cvid=" + cvid;
        Ajax("get", url, "", BatchApplyJobCallBack3, true)
    }
    else
        popbox.error("请选择职位！")
}

function refreshPage()
{
	location.reload();
}

function BatchApplyJobCallBack3(obj) {
    var r = obj.responseText;
    var arrTmp = r.split(':');
    if (arrTmp[0] == "0") {
        var H="";
		var vUrl=window.location.href;
        H += "<div id=\"popinfo\" class=\"popbg\" > ";
        H += "<section class='popWin'> ";
        H += " <div class=\"popClose\"> ";
        H += "  <span class=\"btnClose1\" onClick='popbox2.close()'></span> ";
        H += "</div> ";
        H += " <table cellpadding='0' cellspacing='0' border='0' style=\"margin:0 auto; width:90%;\"> ";
        H += "   <tr style=\"height:60px;\"> ";
        H += "       <td style=\" text-align:center\"><span class=\"alertInfo\"></span> ";
        H += "       <span style=\"font-size:18px; font-weight:bold; display:inline-block; padding-top:10px; ";
        H += "padding-left:4px; vertical-align:top;\">未能申请成功</span></td> ";
        H += "  </tr> ";
        H += "  <tr style=\"height:30px;\">    ";
        H += "      <td>职位过期或您30天内已经申请过该职位。</td> ";
        H += "  </tr> ";
        H += "</table> ";
        H += "</section> ";
        H += "</div> ";
    }
    else {
        var H="";
        H += "<div id=\"popinfo\" class=\"popbg\" > ";
        H += "<section class='popWin'> ";
        H += " <div class=\"popClose\"> ";
        H += "  <span class=\"btnClose1\" onClick='refreshPage()'></span> ";
        H += "</div> ";
        H += " <table cellpadding='0' cellspacing='0' border='0' style=\"margin:0 auto; width:90%;\"> ";
        H += "   <tr style=\"height:60px;\"> ";
        H += "       <td style=\" text-align:center\"><span class=\"duihao\"></span> ";
        H += "       <span style=\"font-size:18px; font-weight:bold; display:inline-block; padding-top:10px; ";
        H += "padding-left:4px; vertical-align:top;\">已成功申请了" + arrTmp[0] + "个职位</span></td> ";
        H += "  </tr> ";
        H += "  <tr style=\"height:30px;\">    ";
        H += "      <td>平均申请15个职位可以换来一次面试机会，您今天已经申请了" + arrTmp[2] + "个职位。</td> ";
        H += "  </tr> ";
        H += "</table> ";
        H += "</section> ";
        H += "</div> ";
    }
    //if (r == "1") {
    //popbox.error("已成功申请职位");
    popbox2.show(H, 1);
    //popbox2.close();
    //}
    //else if (r == "-101")
    //    popbox.error("您还没有登录，或者登录已超时，<a href='/personal/sys/login'>请登录</a>。");
    //else
    //    location.reload();
}



function BatchApplyJobCallBack(obj) {
    var r = obj.responseText;
	if(r=="xxx")
	{
		    popbox.error("一次申请不可以同时申请同一公司的3个以上的职位");
	}
	else
	{
    var arrTmp = r.split(':');
    if (arrTmp[0] == "0") {
        var H="";
        H += "<div id=\"popinfo\" class=\"popbg\" > ";
        H += "<section class='popWin'> ";
        H += " <div class=\"popClose\"> ";
        H += "  <span class=\"btnClose1\" onClick='popbox2.close()'></span> ";
        H += "</div> ";
        H += " <table cellpadding='0' cellspacing='0' border='0' style=\"margin:0 auto; width:90%;\"> ";
        H += "   <tr style=\"height:60px;\"> ";
        H += "       <td style=\" text-align:center\"><span class=\"alertInfo\"></span> ";
        H += "       <span style=\"font-size:18px; font-weight:bold; display:inline-block; padding-top:10px; ";
        H += "padding-left:4px; vertical-align:top;\">未能申请成功</span></td> ";
        H += "  </tr> ";
        H += "  <tr style=\"height:30px;\">    ";
        H += "      <td>职位过期或您30天内已经申请过该职位。</td> ";
        H += "  </tr> ";
        H += "</table> ";
        H += "</section> ";
        H += "</div> ";
    }
    else {
        var H="";
        H += "<div id=\"popinfo\" class=\"popbg\" > ";
        H += "<section class='popWin'> ";
        H += " <div class=\"popClose\"> ";
        H += "  <span class=\"btnClose1\" onClick='popbox2.close()'></span> ";
        H += "</div> ";
        H += " <table cellpadding='0' cellspacing='0' border='0' style=\"margin:0 auto; width:90%;\"> ";
        H += "   <tr style=\"height:60px;\"> ";
        H += "       <td style=\" text-align:center\"><span class=\"duihao\"></span> ";
        H += "       <span style=\"font-size:18px; font-weight:bold; display:inline-block; padding-top:10px; ";
        H += "padding-left:4px; vertical-align:top;\">已成功申请了" + arrTmp[0] + "个职位</span></td> ";
        H += "  </tr> ";
        H += "  <tr style=\"height:30px;\">    ";
        H += "      <td>平均申请15个职位可以换来一次面试机会，您今天已经申请了" + arrTmp[2] + "个职位。</td> ";
        H += "  </tr> ";
        H += "</table> ";
        H += "</section> ";
        H += "</div> ";
    }
    //if (r == "1") {
    //popbox.error("已成功申请职位");
    popbox2.show(H, 1);
    //popbox2.close();
    //}
    //else if (r == "-101")
    //    popbox.error("您还没有登录，或者登录已超时，<a href='/personal/sys/login'>请登录</a>。");
    //else
    //    location.reload();
	}
}


//收藏职位
function BatchFavorate(id) {
    var jobids = "";
    if (!id) {
        $('.ck_yes').each(function () {
            jobids += $(this).attr('jobid') + ",";
        });
        if (jobids.length > 0) {
            jobids = jobids.substr(0, jobids.length - 1);
        }
    }
    else {
        jobids = id;
    }
    if (jobids) {
        var url = "/Personal/Jm/FavorateInsert?jobids=" + jobids;
        Ajax("get", url, "", BatchFavorateCallBack, true)
    }
    else
        popbox.error("请选择职位！")
}

function BatchFavorateCallBack(obj) {
    var r = obj.responseText;
    if (r == "1") {
        popbox.error("已成功放入收藏夹");
    }
    else if (r == "-101")
        popbox2.show('<section class="popWin" id="msgPop" ><div class="btnClose"  onClick="popbox2.close()"></div><p style="color:#000;padding:20px 0;display:inline-block;width:100%;" align="center">您还没有登录，或者登录已超时，<a style="color:blue" href="/personal/sys/login?urlfile='+escape(document.location.href)+'">请登录</a>。</p></section>',1);
    else
        location.reload();
}

//推荐职位
function ChangeCvShow(obj, ObjID, cvMainID, count) {
    if (ObjID != "") {
        var ObjCvTab = _('MyCv_tab');
        for (var i = 0; i < ObjCvTab.children.length; i++) {
            ObjCvTab.children[i].className = "Tab_CvName_UnSelect";
        }
        obj.className = "selected";
        var objCvMain = _('MyCvMain');
        for (var i = 1; i < objCvMain.children.length; i++) {
            objCvMain.children[i].style.display = "none";
        }
        _(ObjID).style.display = "block";
    } else {
        var ObjCvTab = _('MyCv_tab');
        for (var i = 0; i < ObjCvTab.children.length; i++) {
            ObjCvTab.children[i].className = "noselected";
        }
        obj.className = "selected";
    }
    _("bk").innerHTML = "";
    ChangeRecommend(cvMainID, count);
}

function ChangeRecommend(cvmainid, count) {
    addLoading();
    Ajax("post", "/Personal/js/AjaxGetRecommendJobList", "PageNo=1&cvid=" + cvmainid, ShowAjaxList, true);
}

//面试通知
var InterviewID;
var ReplyReason;
var InterViewReply
function ReplyInterview(ID, cpMainID, reply) {
    InterviewID = ID;
    InterViewReply = reply;
    message = "";
    ReplyReason = escape(document.getElementById("txtReason" + ID).value);
    var url = "/personal/jm/InterViewUpdate";
    if (InterViewReply == 2 && ReplyReason.length == 0) {
        popbox.error("请填写不能准时参加面试的理由！");
        return;
    }
    Ajax("POST", url, "id=" + ID + "&reply=" + InterViewReply + "&cpMainID=" + cpMainID + "&message=" + ReplyReason, SetInterview, true);
}

function SetInterview(obj) {
    if (obj.responseText == -2) {
        popbox.error("您还没有登录，请先登录系统！");
        window.location.href = '/personal/sys/login';
    }
    else if (obj.responseText.length > 0) {
        popbox.error("您的面试通知已经成功回复！");
        location.reload();
    }
}
