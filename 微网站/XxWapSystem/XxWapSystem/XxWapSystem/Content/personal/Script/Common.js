function _(id){return document.getElementById(id);}
function trim(str){return str.replace(/(^\s*)|(\s*$)/g,"");}
function AddClass(obj,cName){
  RemoveClass(obj,cName);
  return obj && (obj.className += (obj.className.length>0?' ':'')+cName);
}

function RemoveClass(obj,cName){
  return obj && (obj.className=obj.className.replace(new RegExp("^"+cName+"\\b\\s*|\\s*\\b"+cName+"\\b",'g'),''));
}
function HasClass(obj,cName){
  return (!obj || !obj.className)?false:(new RegExp("\\b"+cName+"\\b")).test(obj.className);
}
function _Tag(tag){return document.getElementsByTagName(tag)}  //通过Tag获取对象
function _ChildTag(id,tag){return id.getElementsByTagName(tag)}  //通过Tag获取ID的子对象
function _Class(className){return getElementsByClassName(className)}  //通过className获取对象

//中英文混合长度对应VARCHAR
function englength(str){return str.match(/[^ -~]/g) == null ? str.length : str.length + str.match(/[^ -~]/g).length;}

function CtoH(obj)
{ 
  var str=obj.value;
　var result="";
　for (var i = 0; i < str.length; i++)
  {
　　if (str.charCodeAt(i)==12288)
	{
　　　result+= String.fromCharCode(str.charCodeAt(i)-12256);
　　　continue;
　　}
　　if (str.charCodeAt(i)>65280 && str.charCodeAt(i)<65375)
	  result+= String.fromCharCode(str.charCodeAt(i)-65248);
　　else
	  result+= String.fromCharCode(str.charCodeAt(i));
　}
  result = result.replace(/——/g,"_");
  if(obj.value != result)
    obj.value = result;
} 
function Ajax(method,url,parm,callback,bool){
  var xmlHttp = false;
  if(window.ActiveXObject)
  {
	xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
  }
  else if(window.XMLHttpRequest)
  {
	xmlHttp = new XMLHttpRequest();
  }  
  xmlHttp.onreadystatechange = function () 
  {
	if (xmlHttp.readyState == 4) 
	{
	  if(xmlHttp.status == 200){
		  callback(xmlHttp); 
	  }
	  else{
		popbox.error(xmlHttp.status+"："+xmlHttp.responseText);
	  }
	}
  } 
  xmlHttp.open(method,url,bool);
  xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;charset=gb2312");
  xmlHttp.send(parm);
  if(navigator.userAgent.indexOf("Firefox")>0)
    callback(xmlHttp);

} 
function UpdatePWDCallBack(obj){
  if(obj.responseText==1){
    popbox.error("密码修改成功");
	_("txtPrePassword").value = "";
	_("txtPassword").value = "";
	_("Confirm").value = "";
  }
  else if(obj.responseText==0)
    popbox.error("密码错误");
  else
    popbox.error(obj.responseText);
}

function setCookie(key,strName,value) // 变更名，子键名 ,子键值
{
	var cookies = ""
	var dc = "; "+document.cookie+"; ";
	var cooNum = dc.indexOf("; "+key+"="); 
	var cookInfo = dc.substring(cooNum+key.length+3,dc.length);
	cookInfos = (cookInfo.split(";"))[0].split("&") ; 
	for (var i=0; i < cookInfos.length; i++)
	{
		var endPlace = cookInfos[i].indexOf("=") ;
		var strCoo = cookInfos[i].substring(0,endPlace) ;
		if(strName == strCoo)
		{
			cookies = cookies + strName + "=" + value ;
			if(i != cookInfos.length-1 )
				cookies = cookies + "&" ;
		}
		else 
		{
			cookies = cookies + cookInfos[i]  ;
			if(i != cookInfos.length-1 )
				cookies = cookies + "&" ;
		}
	}	 
	document.cookie = key + "=" + cookies ;
}
//读取cookies值
function GetCookie(key,strName) // 变更名，子键名  
{
	var cookies = "" ;
	var dc = "; "+document.cookie+"; "; 
	var cooNum = dc.indexOf("; "+key+"="); 
	var cookInfo = dc.substring(cooNum+key.length+3,dc.length);
	cookInfos = (cookInfo.split(";"))[0].split("&") ;
	for (var i=0; i < cookInfos.length; i++)
	{
		var endPlace = cookInfos[i].indexOf("=") ;
		var strCoo = cookInfos[i].substring(0,endPlace) ;
		if(strName == strCoo)
			cookies = cookInfos[i].substring(cookInfos[i].indexOf("=")+1) ;
	}
	return cookies ;
}

function delCookie(key)//删除cookie
{
	var ckContent = "" ;
	var cookies = document.cookie.match(new RegExp("(^| )"+key+"=([^;]*)(;|$)"));
	if(cookies != null) 
		ckContent=unescape(cookies[2]);
	var exp = new Date();
	exp.setTime(exp.getTime() - 1);	
	if(ckContent!=null || ckContent!="") 
		document.cookie= key + "="+ckContent+";expires="+exp.toGMTString();
}

function URL_Request(strHref,strName){
  var intPos = strHref.indexOf("?");
  var strRight = strHref.substr(intPos + 1);
  var arrTmp = strRight.split("&");
  for (var i = 0; i < arrTmp.length; i++){
    var dIntPos = arrTmp[i].indexOf("=");
    var paraName = arrTmp[i].substr(0, dIntPos);
    var paraData = arrTmp[i].substr(dIntPos + 1);
    if(paraName.toUpperCase() == strName.toUpperCase())
      return paraData;
  }
  return "";
}
