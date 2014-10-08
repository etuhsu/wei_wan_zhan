// JavaScript Document
function Ajax(method, url, parm, callback, bool) {
    var xmlHttp = false;
    if (window.ActiveXObject) {
        xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    else if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
    }
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4) {
            if (xmlHttp.status == 200) {
                callback(xmlHttp);
                xmlHttp = null;
            }
            else if (xmlHttp.status == 0) {
                if (window.ActiveXObject) {
                    xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                else if (window.XMLHttpRequest) {
                    xmlHttp = new XMLHttpRequest();
                }
                xmlHttp.onreadystatechange = function () { if (xmlHttp.readyState == 4) { if (xmlHttp.status == 200) { callback(xmlHttp); xmlHttp = null; } } }
                xmlHttp.open(method, url, bool);
                xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;charset=gb2312");
                xmlHttp.send(parm);

            }
            else {
                document.write(xmlHttp.status + "£º" + xmlHttp.responseText);
            }
        }
    }
    xmlHttp.open(method, url, bool);
    xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;charset=gb2312");
    xmlHttp.send(parm);
    if (navigator.userAgent.indexOf("Firefox") > 0)
        callback(xmlHttp);
} 