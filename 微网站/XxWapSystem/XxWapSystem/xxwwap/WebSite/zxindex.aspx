<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zxindex.aspx.cs" Inherits="XxWapSystem.zxindex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta content="telephone=no" name="format-detection" />
<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0, user-scalable=no" name="viewport" />
<meta name="apple-mobile-web-app-capable" content="no" />
<title>�������ز�װ����</title>
<meta name="apple-mobile-web-app-capable" content="yes" />
<meta name="keywords" content="�������ز�װ����,����װ��,����װ�޹�˾,��������,�����Ҿ�,���ʦ,װ����Ʒ,װ���ռ�,�����Ź�"/>
<meta name="description" content="�������ز�װ��������������Ψһһ��ר�Ŵ���װ����Ϣ���������ý�塣Ϊ���ṩ���µ���ҵ��̬�ʹ�����Ϣ����ȫ��װ�޽��ġ���Ȩ������ҵ���º����õ������������ز�װ����������Ϊ����װ����ҵ��Ȩ���Ĺ���ý�塣"/>
<meta name="apple-mobile-web-app-title" content="�������ز�װ����">
<meta name="viewport" content="width=device-width"/>  
<!��[if IE 6 ]><html class="ie ielt9 ielt8 ielt7 ie6" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]��>
<!��[if IE 7 ]><html class="ie ielt9 ielt8 ie7" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]��>
 <!��[if IE 8 ]><html class="ie ielt9 ie8" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]��>
 <!��[if IE 9 ]><html class="ie ie9" lang="en-US"><script src="Content/Script/Html5.js"></script><![endif]��>
 <!��[if (gt IE 9)|!(IE)]><!��><html lang="en-US"><!��<![endif]��>

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
		<h1 class="logo"><a href="home/index.html"><img src="content/personal/Images/logo/m_logo72.png" width="150px" alt="�������ز�װ����" style=" padding-top:4px"></a></h1>
	</div>
  </header>
  <div class="banner">
    <img src='Content/Home/images/sy_001.jpg' />
  </div>
<nav class="nav_btn_group" style="max-height: 120px;">
<UL>
  <LI id="nav_btn_news"><A href="/jc_go/jcgoList.aspx" 
  target="_self"><I class="nav_icon_news"></I>����</A></LI>
  <LI id="nav_btn_newhouse"><A href="/zx_xyda/xydaList.aspx" target="_self"><I 
  class="nav_icon_newhouse"></I>����</A></LI>
  <LI id="nav_btn_sellhouse"><A href="/zx_ts/tsList.aspx" 
  target="_self"><I class="nav_icon_sellhouse"></I>Ͷ��</A></LI> 
  <LI id="nav_btn_decoration"><A href="/news/ZxNews.aspx" 
  target="_self"><I class="nav_icon_decoration"></I>��Ѷ</A></LI></UL></nav>
    <!--װ����Ѷ-->
    <div id="bbs_wrap">
        <h2 class="h2_v2">
            <span class="title_news"><a href="/zx/">װ����Ѷ</a></span></h2>
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
          <span>������</span>
          <span>-</span>
          <a href="http://m.yyfdcw.com">���԰�</a>
          </div>
		</div>
		<p class="copyRight">
          <span>�������ز�װ������Ȩ����&copy;2014</span>
		</p>
	</footer>
</div>
<script>
    $(function () {
        //�����������¹���ʱ��ʾTOP
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