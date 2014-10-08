<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jcgoList.aspx.cs" Inherits="XxWapSystem.jc_go.jcgoList" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no"/> 
<meta name="format-detection" content="telephone=no" />
<title>岳阳房地产装修网 建材GO便宜</title>
<meta name="keywords" content="岳阳房地产装修网,岳阳装修,岳阳装修公司,岳阳建材,岳阳家居,设计师,装修作品,装修日记,本地团购"/>
<meta name="description" content="岳阳房地产装修网是岳阳地区唯一一家专门从事装修信息服务的网络媒体。为您提供最新的行业动态和促销信息、最全的装修建材、最权威的行业规章和信用档案。岳阳房地产装修网致力成为岳阳装修行业最权威的公信媒体。"/>
<meta name="apple-mobile-web-app-title" content="岳阳房地产装修网">
<meta name="apple-mobile-web-app-capable" content="yes" />
<script src="../js/jquery.js?version=1.0"></script> 
<script src="../js/common.js?version=1.0"></script>
<link rel="stylesheet" type="text/css" href="../css/v2.css" />
<link rel="stylesheet" type="text/css" href="../css/main.css" />
<link rel="stylesheet" type="text/css" href="../css/base.css" />
<link rel="stylesheet" type="text/css" href="../css/city/nj.css" />

</head>
<body>
    <!--头部LOGO-->
    <header class="m_wrap">
<section id="topbar" class="topnav_tool">
<button class="top_btn" id="btn_back">返回</button>
<h1>建材GO便宜</h1>
</section>
</header>

    <script>
        var choose_opts = new Map();
        var choose_opt_labels = new Array();

        function submitsearch() {
            var jumpurl = "?jcname=" + encodeURIComponent(jQuery("#searchInput").val()) + "";
            document.location.href = jumpurl;
        }
    </script>

    <!--搜索区域-->
    <div class="search_wrap">
        <div id="sugglist">
        </div>
        <form method="get" id="search_form" name="search_form" action="?">
        <div class="search-input">
            <label for="searchInput" class="forSearchInput2">
            </label>
            <input type="text" class="textInput" name="keyword" value="" id="searchInput" placeholder="请输入建材关键字"
                autocomplete="off" />
            <input type="bottom" class="search-submit right" onClick="submitsearch()" vlaue="搜索" />
        </div>
        </form>
    </div>

    <!--数据-->
    <h2 class="h2_tabtitle">
        <span class="cur_title_count"><i class="bhline"></i>精品家装材料</span>
    </h2>
    <div id="datalist">
        <div class="tplist">
            <ul>
                <asp:Repeater ID="rptMessage" runat="server">
                    <ItemTemplate>
                        <li class="p-item" onClick="gourl('ProductShow.aspx?id=<%# Eval("iID").ToString() %>')">
                            <div class="p-img">
                                <a href="ProductShow.aspx?id=<%# Eval("iID").ToString() %>">
                                    <img width="50" height="50" alt="<%# Eval("cProductName").ToString() %>" src="<%# Thumbnail(Eval("iID").ToString()) %>" />
                                </a>
                            </div>
                            <div class="p-txt">
                                <div class="s-name">
                                    <a href="ProductShow.aspx?id=<%# Eval("iID").ToString() %>"><%# Eval("cProductName").ToString()%></a></div>
                                <div class="s-addr">
                                    品牌：<%# Brand(Eval("iBrandID").ToString())%> - 产品型号：<%# Eval("cProductXh").ToString()%></div>
                                <div class="s-addr">
                                    促销价</div>
                                <div class="s-price">
                                   ￥<%# Eval("cPrice").ToString()%></div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>

    <script type="text/javascript">
        var page = 2;
        var url = "ProductAjax.aspx?Action=list";

        $(document).ready(function() {


            //新加的
            var is_topnav_show = false;
            $(".top_btn_fav").click(function() {
                if (is_topnav_show) {
                    $("#topnav_menu").slideUp();
                    is_topnav_show = false;
                } else {
                    $("#topnav_menu").slideDown();
                    is_topnav_show = true;
                }
            });
            $(".topnav_contract").click(function() {
                $("#topnav_menu").slideUp();
                is_topnav_show = false;
            });
            $(".choose_opt dl").addClass('choose_line');
            $(".choose_switch").click(function() {
                //alert($(this).parent().html());
                $(this).parent().toggleClass('choose_line');
                //alert($(this).find("i").hasClass("icon-on"));
                if ($(this).find("i").hasClass("icon-on")) {
                    $(this).find("i").removeClass('icon-on');
                    $(this).find("i").toggleClass('icon-off');
                } else {
                    $(this).find("i").removeClass('icon-off');
                    $(this).find("i").toggleClass('icon-on')
                }
            });

            //更多筛选
            var choose_more = false;
            var more_choose_up_html = '更多筛选条件<i class="icon-down"></i>';
            var more_choose_down_html = '精简筛选条件<i class="icon-up"></i>';
            $(".choose_opt dl:gt(1)").hide();
            $(".choose_more").click(function() {
                if (choose_more) {
                    $(".choose_opt dl:gt(1)").hide();
                    $(this).html(more_choose_up_html);
                    choose_more = false;
                } else {
                    $(".choose_opt dl:gt(1)").show();
                    $(this).html(more_choose_down_html);
                    choose_more = true;
                }
            });
            //已选条件  
            var choose_selected_list_html = "";
            if (choose_opts.size() > 0) {
                for (var i = 0; i < choose_opts.size(); i++) {
                    choose_selected_list_html += "<li><label>" + choose_opt_labels[choose_opts.element(i).key] + ":</label>" + choose_opts.element(i).value + "</li>";
                }
                $("#choose_selected_list").html(choose_selected_list_html);
            } else {
                $(".choose_selected").hide();
            }

            //初始化排序选择
            //initOrderParam();
            //新加end

            var moreitem = '<div class="more_tag">点击加载更多</div>';
            var nodataitem = '<div class="nodata_tag">很抱歉,没有找到相关建材信息！</div>';

            $("#datalist").append(moreitem);

            $(".more_tag").click(function() {
                $(".more_tag").hide();
                $("#datalist").append('<div class="page_loading"></div>');
                $.ajax({
                    type: "GET",
                    url: url,
                    data: "page=" + page,
                    success: function(msg) {

                        $(".page_loading").remove();
                        if (msg != '') {
                            page = page + 1;
                            $("#datalist ul").append(msg);
                            //$("#datalist").append(moreitem);
                            $(".more_tag").show();
                        } else {
                            $(".more_tag").hide();
                            $("#datalist").append('<div class="nodata_tag">没有更多数据了</div>');
                        }
                    }
                });
            });

            $("#datalist li:even").addClass("bg2");


            //搜索联想
            $("#searchInput").keyup(function() {
                var thinkurl = "#";
                var searchInput = $("#searchInput").val();
                if (searchInput.length >= 2) {
                    $("#sugglist").html('<img src="../images/loading.gif"/>');
                    $("#sugglist").show();
                    $.ajax({
                        type: "GET",
                        url: thinkurl,
                        dataType: 'json',
                        data: "keyword=" + $.trim(searchInput),
                        success: function(data) {
                            //$(".search_wrap").append('');
                            var sugglisthtml = '<ul>';
                            $.each(data, function(i, n) {
                                sugglisthtml += "<li bid=\"" + n.id + "\">" + n.name + "</li>";
                            });
                            sugglisthtml += '</ul>';
                            if (data.length == 0) {
                                $("#sugglist").hide();
                            }
                            $("#sugglist").html(sugglisthtml);
                            //$("#sugglist").show();
                        }
                    });
                } else {
                    $("#sugglist").hide();
                }

            });

            $('#sugglist li').live('click', function() {
                go_sellhouse_block_url($(this).attr("bid"));
                $("#sugglist").hide();
            });

        });
    </script>

    <!--底部导航-->
<div class="footer">
	<footer>
		<div class="footer_top">
		  <div class="islogin">
			<a href="/news/BuildingNews.aspx">资讯</a><
			<a href="/newhouse/List.aspx" target="_self">新房</a>
			<a href="/sellhouse/List.aspx" target="_self">二手房</a>
			<a href="/index.html" target="_self">装修</a>
          </div>
		</div>
		<div class="footer_bottom">
		  <div class="gotop" id="gotop" style="display:none;"><a href="javascript:scroll(0,0)"><img src="content/home/images/top.png" style="width:100%" /></a></div>
          <div class="links">
          <span>触屏版</span>
          <span>-</span>
          <a href="http://zx.yyfdcw.com">电脑版</a>
          </div>
		</div>
		<p class="copyRight">
          <span>岳阳房地产装修网版权所有&copy;2014</span>
		</p>
	</footer>
</div>
    <div class="btn_gotop" id="btn_gotop" style="display: none">
    </div>
</body>
</html>