var hasInsertViewLog = 0;
var strJobType = "", strRegion = "", strSalary = "", strEducation = "", strExperience = "", strEmployType = "", strCompanySizeID = "", strWelfare = "", strSFrom = "";
function SetSearch() {
    _("txtKeyWord").value = _("txtdcJobTypeID").value;
    _("hidJobType").value = _("txtdcJobTypeID").value;
    _("txtdcJobTypeID").value = " ";
}
function SetIndustrySearch() {
    if (_("txtdcIndustryID").value.length > 17) {
        _("txtdcIndustryID").value = _("txtdcIndustryID").value.substr(0, 16) + '...'
    }
}
function SetRegionSearch() {
    if (_("txtdcRegionID").value.length > 10) {
        _("txtdcRegionID").value = _("txtdcRegionID").value.substr(0, 10) + '...'
    }
}

//返回上一页
function BackJobList(strType) {
    if (strType.toLowerCase().indexOf("jobtype") > -1) {
        _("iddcJobTypeID").value = _("prevJobTypeID").value;
    }
    if (strType.toLowerCase().indexOf("region") > -1) {
        _("iddcRegionID").value = _("prevRegionID").value;

    }

    document.frmJob.submit();
}

//职位搜索更多条件选择
function FilterSelect(strType, id, val, obj) {
    //职位类别
    if (strType.toLowerCase().indexOf("jobtype") >= 0) {
        _("divJobType").innerHTML = val.substring(0, 4) + "&nbsp;&nbsp;<span id=\"asrJobType\" class=\"zphOption\"></span>";
        _("prevJobTypeID").value = _("iddcJobTypeID").value;
        _("iddcJobTypeID").value = id;
        _("bk").innerHTML = "";
        document.frmJob.submit();
        //AjaxGetJobList(1);
    }
    if (strType.toLowerCase().indexOf("region") >= 0) {
        _("divPlace").innerHTML = val.substring(0, 4) + "&nbsp;&nbsp;<span id=\"asrPlace\" class=\"zphOption\"></span>"; ;
        _("prevRegionID").value = _("iddcRegionID").value;
        _("iddcRegionID").value = id;
        _("bk").innerHTML = "";
        //AjaxGetJobList(1);
        document.frmJob.submit();
    }
    if (strType.toLowerCase().indexOf("salary") >= 0) {
        //_("divSalary").innerHTML = val.substring(0, 4) + "&nbsp;&nbsp;<span id=\"asrSalary\" class=\"zphOption\"></span>"; ;
        _("iddcSalaryID").value = id;
        _("iddcSalaryName").value = val.substring(0, 4);
        _("bk").innerHTML = "";
        AjaxGetJobList(1);
    }
    //最低学历
    if (strType.toLowerCase().indexOf("education") >= 0) {
        _("spanAC2").innerHTML = val;
        _("hiEducation").value = id;
    }

    //最低学历
    if (strType.toLowerCase().indexOf("isonline") >= 0) {
        _("spanZX2").innerHTML = val;
        _("hiIsOnline").value = id;
    }

    //工作经验
    if (strType.toLowerCase().indexOf("experience") >= 0) {
        _("spanNX2").innerHTML = val;
        _("hiExp").value = id;
    }
    //工作性质
    if (strType.toLowerCase().indexOf("employtype") >= 0) {
        _("spanXZ2").innerHTML = val;
        _("hiEmploytype").value = id;
    }
    //公司规模
    if (strType.toLowerCase().indexOf("companysize") > 0) {
        _("spanGM2").innerHTML = val;
        _("hiCompanySize").value = id;
    }
    //福利待遇
    if (strType.toLowerCase().indexOf("welfare") >= 0) {
        var welID = _("hiWelfare").value;
        var welName = _("spanWF2").innerHTML;
        var $o = $(obj);
        var type = 0;
        if ($o.hasClass('ck_yes')) {
            $o.addClass('ck_no').removeClass('ck_yes');
            type = 0;
        } else {
            $o.addClass('ck_yes').removeClass('ck_no');
            type = 1;
        }
        if (type == 0) {
            if (welName.indexOf(val) > -1) {
                welName = welName.replace(val + " ", "");
                welID = welID.replace(id + ",", "");
            }
        }
        else {
            welName = welName.replace("不限", "");
            if (welName.indexOf(val) < 0) {
                welName = welName + val + " ";
                welID = welID + id + ",";
            }
        }
        _("spanWF2").innerHTML = welName;
        _("hiWelfare").value = welID;
    }

    //福利待遇
    if (strType.toLowerCase().indexOf("fuli") >= 0) {
        var welID = _("hiWelfare").value;
        var welName = _("spanWF3").innerHTML;
        var $o = $(obj);
        var type = 0;
        if ($o.hasClass('ck_yes')) {
            $o.addClass('ck_no').removeClass('ck_yes');
            type = 0;
        } else {
            $o.addClass('ck_yes').removeClass('ck_no');
            type = 1;
        }
        if (type == 0) {
            if (welName.indexOf(val) > -1) {
                welName = welName.replace(val + " ", "");
                welID = welID.replace(id + ",", "");
            }
        }
        else {
            welName = welName.replace("不限", "");
            if (welName.indexOf(val) < 0) {
                welName = welName + val + " ";
                welID = welID + id + ",";
            }
        }
        _("spanWF3").innerHTML = welName;
        _("hiWelfare").value = welID;
        _("idEmployType").value = _("hiEmploytype").value;
        _("iddcEducationID").value = _("hiEducation").value;
        _("iddcIsOnline").value = _("hiIsOnline").value;
        _("idMinExperience").value = _("hiExp").value;
        _("iddcCompanySizeID").value = _("hiCompanySize").value;
        _("txtWelfare").value = _("hiWelfare").value;
        _("iddcEducationName").value = _("spanAC2").innerHTML;
        _("idMinExperienceName").value = _("spanNX2").innerHTML;
        _("iddcIsOnlineName").value = _("spanZX2").innerHTML;
        _("txtWelfareName").value = _("spanWF3").innerHTML;
        _("idEmployTypeName").value = _("spanXZ2").innerHTML;
        _("iddcCompanySizeName").value = _("spanGM2").innerHTML;
        _("bk").innerHTML = "";
        AjaxGetJobList(1);
    }

}


//职位查询页面 ajax
function AjaxGetJobList(PageNo) {
    addLoading();
    location.hash = "pageno" + PageNo;
    var postStr = "iddcJobTypeID=" + _("iddcJobTypeID").value + "&";
    postStr += ("iddcRegionID=" + _("iddcRegionID").value + "&");
    postStr += ("iddcIndustryID=" + _("iddcIndustryID").value + "&");
    postStr += ("txtKeyWord=" + escape(_("KeyWord").value) + "&");
    postStr += ("SortType=" + _("SortType").value + "&");
    postStr += ("oldJobTypeID=" + _("oldJobTypeID").value + "&");
    postStr += ("oldRegionID=" + _("oldRegionID").value + "&");
    postStr += ("iddcSalaryID=" + _("iddcSalaryID").value + "&");
    postStr += ("idEmployType=" + _("idEmployType").value + "&");
    postStr += ("iddcEducationID=" + _("iddcEducationID").value + "&");
    postStr += ("idMinExperience=" + _("idMinExperience").value + "&");
    postStr += ("iddcCompanySizeID=" + _("iddcCompanySizeID").value + "&");
    postStr += ("txtWelfare=" + _("txtWelfare").value + "&");
    postStr += ("txtLng=" + _("txtLng").value + "&");
    postStr += ("txtLat=" + _("txtLat").value + "&");
    postStr += ("iddcIsOnline=" + _("iddcIsOnline").value + "&");
    Ajax("post", "/Personal/Js/ajaxGetJobList?PageNo=" + PageNo, postStr, ShowJobAjaxList, true);
}

//职位查询页面 ajax
function AjaxGetParmJobList(PageNo) {
    addLoading();
    location.hash = "pageno" + PageNo;
    var postStr = "iddcJobTypeID=" + _("iddcJobTypeID").value + "&";
    postStr += ("iddcRegionID=" + _("iddcRegionID").value + "&");
    postStr += ("iddcIndustryID=" + _("iddcIndustryID").value + "&");
    postStr += ("txtKeyWord=" + escape(_("KeyWord").value) + "&");
    postStr += ("SortType=" + _("SortType").value + "&");

    postStr += ("oldJobTypeID=" + _("oldJobTypeID").value + "&");
    postStr += ("oldRegionID=" + _("oldRegionID").value + "&");
    postStr += ("iddcSalaryID=" + _("iddcSalaryID").value + "&");
    postStr += ("idEmployType=" + _("idEmployType").value + "&");
    postStr += ("iddcEducationID=" + _("iddcEducationID").value + "&");
    postStr += ("idMinExperience=" + _("idMinExperience").value + "&");
    postStr += ("iddcCompanySizeID=" + _("iddcCompanySizeID").value + "&");
    postStr += ("txtWelfare=" + _("txtWelfare").value + "&");
    postStr += ("iddcIsOnline=" + _("iddcIsOnline").value + "&");
    Ajax("post", "/Personal/parm/AjaxGetParmJobList?PageNo=" + PageNo, postStr, ShowJobAjaxList, true);
}


function ShowJobAjaxList(obj) {
    var data = unescape(obj.responseText);
    if (_("bk")) {
        _("bk").innerHTML = _("bk").innerHTML.replace("拖至底部加载更多...", "");
        _("bk").innerHTML = _("bk").innerHTML.replace("pagemore", "");
        _("bk").innerHTML += data;
        _("divRegion").innerHTML = _("spanWorkPlace").innerHTML;
		if(_("divRegion").innerHTML=="")
		{
			_("divRegion").innerHTML = "<span style='padding:5px 5px;display:block;font-size:12px'>您选择的地区已经到最后一级，不能再进一步筛选了</span>";
		}
        _("divJobTypeFilter").innerHTML = _("spanJobType").innerHTML;
		if(_("divJobTypeFilter").innerHTML=="")
		{
			_("divJobTypeFilter").innerHTML = "<span style='padding:5px 5px;display:block;font-size:12px'>您选择的职位类别已经到最后一级，不能再进一步筛选了</span>";
		}
        //if (_("divSalaryFilter").innerHTML == "") {
        _("divSalaryFilter").innerHTML = _("spanSalary").innerHTML;
        //}
        if (_("showNX").innerHTML == "") {
            _("showNX").innerHTML = _("spanExp").innerHTML;
        }
        if (_("showXZ").innerHTML == "") {
            _("showXZ").innerHTML = _("spanEmploy").innerHTML;
        }
        if (_("showGM").innerHTML == "") {
            _("showGM").innerHTML = _("spanSize").innerHTML;
        }
        if (_("spanJobCnt")) {
            _("spanJobCnt").innerHTML = _("hiJobCnt").value;
        }
        _("divFilter").innerHTML = "";
    }
    else {
        _("ApplyCv").innerHTML = data;
    }
    removeLoading();
}

function otherok() {
    _("idEmployType").value = _("hiEmploytype").value;
    _("iddcEducationID").value = _("hiEducation").value;
    _("idMinExperience").value = _("hiExp").value;
    _("iddcCompanySizeID").value = _("hiCompanySize").value;
    _("iddcIsOnline").value = _("hiIsOnline").value;
    _("iddcIsOnlineName").value = _("spanZX2").innerHTML;
    _("txtWelfare").value = _("hiWelfare").value;
    _("iddcEducationName").value = _("spanAC2").innerHTML;
    _("idMinExperienceName").value = _("spanNX2").innerHTML;
    try {
        _("txtWelfareName").value = _("spanWF2").innerHTML;
    }
    catch (e) {
        _("txtWelfareName").value = _("spanWF3").innerHTML;
    }
    _("idEmployTypeName").value = _("spanXZ2").innerHTML;
    _("iddcCompanySizeName").value = _("spanGM2").innerHTML;
    _("bk").innerHTML = "";
    AjaxGetJobList(1);
}

//本公司其它职位 ajax
function AjaxGetOtherJobs(PageNo) {
    addLoading();
    location.hash = "pageno" + PageNo;
    var postStr = "cpmainid=" + _("hidCpID").value;
    Ajax("post", "/Personal/Jv/AjaxGetOtherJobs?PageNo=" + PageNo, postStr, ShowAjaxList, true);
}