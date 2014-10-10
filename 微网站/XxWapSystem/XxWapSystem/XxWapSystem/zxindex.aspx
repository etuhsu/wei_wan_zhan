<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zxindex.aspx.cs" Inherits="XxWapSystem.zxindex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta content="telephone=no" name="format-detection" />
<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no" name="viewport" />
<meta name="apple-mobile-web-app-capable" content="no" />
<title>岳阳房地产装修网</title>
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="keywords" content="岳阳房地产装修网,岳阳装修,岳阳装修公司,岳阳建材,岳阳家居,设计师,装修作品,装修日记,本地团购"/>
<meta name="description" content="岳阳房地产装修网是岳阳地区唯一一家专门从事装修信息服务的网络媒体。为您提供最新的行业动态和促销信息、最全的装修建材、最权威的行业规章和信用档案。岳阳房地产装修网致力成为岳阳装修行业最权威的公信媒体。"/>
<meta name="apple-mobile-web-app-title" content="岳阳房地产装修网">
<meta name="viewport" content="width=device-width"/>  
<!—[if IE 6 ]><html class="ie ielt9 ielt8 ielt7 ie6" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]—>
<!—[if IE 7 ]><html class="ie ielt9 ielt8 ie7" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]—>
 <!—[if IE 8 ]><html class="ie ielt9 ie8" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]—>
 <!—[if IE 9 ]><html class="ie ie9" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]—>
 <!—[if (gt IE 9)|!(IE)]><!—><html lang="en-US"><!—<![endif]—>

 <link href="Content/Home/Style/style3860.css?v=1" rel="stylesheet">
  <link href="Content/Home/Style/menu3860.css?v=1" rel="stylesheet">
  <script src="Content/personal/Script/jquery-1.5.2.min.js"></script> 
 <script src="Content/Home/Script/index3860.js?v=1"></script>
 <script src="Content/Personal/Script/base.min3860.js?v=1"></script>

    <link href="css/v2.css" rel="stylesheet" type="text/css">
</head>
<body>

<div class="content">
  
 <header>
	<div class="header_bar">
		<h1 class="logo"><a href="home/index.html"><img src="content/personal/Images/logo/m_logo72.png" width="150px" alt="岳阳房地产装修网" style=" padding-top:4px"></a></h1>
	</div>
  </header>
  <div class="banner">
    <img src='Content/Home/images/sy_001.jpg' />
  </div>
<nav class="nav_btn_group" style="max-height: 120px;">
<UL>
  <LI id="nav_btn_news"><A href="/jc_go/jcgoList.aspx" 
  target="_self"><I class="nav_icon_news"></I>建材</A></LI>
  <LI id="nav_btn_newhouse"><A href="/zx_xyda/xydaList.aspx" target="_self"><I 
  class="nav_icon_newhouse"></I>信用</A></LI>
  <LI id="nav_btn_sellhouse"><A href="/zx_ts/tsList.aspx" 
  target="_self"><I class="nav_icon_sellhouse"></I>投诉</A></LI> 
  <LI id="nav_btn_decoration"><A href="/news/ZxNews.aspx" 
  target="_self"><I class="nav_icon_decoration"></I>资讯</A></LI></UL></nav>
    <!--装修资讯-->
    <div id="bbs_wrap">
        <h2 class="h2_v2">
            <span class="title_news"><a href="/zx/">装修资讯</a></span></h2>
        <div class="cnews_list">
            <ul>
             <%=DecorateHtml %>
            </ul>
        </div>
    </div>
<div class="footer">
	<footer>

		<div class="footer_bottom">
		  <div class="gotop" id="gotop" style="display:none;"><a href="javascript:scroll(0,0)"><img src="content/home/images/top.png" style="width:100%" /></a></div>
          <div class="links">
          <span>触屏版</span>
          <span>-</span>
          <a href="http://m.yyfdcw.com">电脑版</a>
          </div>
		</div>
		<p class="copyRight">
          <span>岳阳房地产装修网版权所有&copy;2014</span>
		</p>
	</footer>
</div>
<script>
    $(function () {
        //当滚动条向下滚动时显示TOP
        if ($("#gotop")) {
            $(window).scroll(function () {
                if ($(window).scrollTop() > 0) {
                    $("#gotop").fadeIn(100);
                }
                else {
                    $("#gotop").fadeOut(100);
                }
            });
        }
    });
</script>

  
</div>



</body>
</html>