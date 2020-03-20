<%@ Page Title="홈 페이지" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2:hover
        {
            background-color: #bfcbd6;
            color: #465c71;
            text-decoration: none;
        }
         
        .style2
        {
            width: 80px;
            border: 1px solid skyblue; 
            background-color: rgba(0,0,0,0); 
            padding: 5px;
            color: #465c71;
            border-top-right-radius: 5px; 
            border-top-left-radius: 5px;
            border-bottom-right-radius: 5px;
            border-bottom-left-radius: 5px;
            font-weight:bold;
        }
   
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <%-- 게시물 리스트 --%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:boarddbConnectionString4 %>" 
        SelectCommand="SELECT [Num], [Title], [PostDate], [Content], [Password], [ReadCount],[Ref],[Step],id 
        FROM [board] as b inner join member as m on b.id = m.id order by [Num] desc">
    </asp:SqlDataSource>
   
   <%--AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="5"--%>
    <h2>글 목록</h2><br />
     <asp:GridView ID="boardList" runat="server" AutoGenerateColumns="false" width="100%" 
     onrowdatabound="boardList_RowDataBound" >
        <Columns>
           <asp:BoundField DataField="NumR" HeaderText="번호"  InsertVisible="False" ItemStyle-Width="50px"  
                           ReadOnly="True" > 
           <ItemStyle HorizontalAlign="Center" />
           </asp:BoundField>
          <%-- <asp:BoundField DataField="Num" HeaderText="고유번호" InsertVisible="False"
                           ReadOnly="True" SortExpression="Num">
           <ItemStyle HorizontalAlign="Center" Width="50px"  Font-Size="13pt"/> </asp:BoundField>--%>
         <%--  <asp:BoundField HeaderText="작성자" DataField="name" ItemStyle-Width="100px"> 
           <ItemStyle HorizontalAlign="Center" />--%>
           <%--</asp:BoundField>--%>
           <asp:BoundField HeaderText="아이디" DataField="id" ItemStyle-Width="100px">
           <ItemStyle HorizontalAlign="Center" /> 
            </asp:BoundField>    
           <asp:HyperLinkField HeaderText="제목"
               DataNavigateUrlFields="Num,Ref,Step,Reorder,id"
               DataNavigateUrlFormatString="View.aspx?Num={0}&Ref={1}&Step={2}&Reorder={3}&id={4}"
               DataTextField="title" ItemStyle-Width="350px" />
           <asp:BoundField HeaderText="작성일"
               DataField="PostDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" ItemStyle-Width="150px">
           <ItemStyle HorizontalAlign="Center" />
           </asp:BoundField>
           <asp:BoundField HeaderText="조회수" DataField="ReadCount" ItemStyle-Width="40px">
           <ItemStyle HorizontalAlign="Center" />
           </asp:BoundField>
       </Columns>   
    </asp:GridView>

   <br />

   <!--검색리스트-->
       <asp:DropDownList ID="lstSearchField" runat="server">
           <asp:ListItem Value="title" Selected="True">제목</asp:ListItem>
           <asp:ListItem Value="content">내용</asp:ListItem>
       </asp:DropDownList>
       <asp:TextBox ID="txtSearchQuery" runat="server" Width="209px"></asp:TextBox> 
       <asp:Button ID="btnSearch" runat="server" Text="검색" onclick="btnSearch_Click" class="style2"/><br />

</asp:Content>
