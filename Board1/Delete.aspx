<%@ Page Title="홈 페이지" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Delete.aspx.cs" Inherits="Delete" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2>글 삭제</h2><br />
        <asp:Label ID="lblNum" runat="server" ForeColor="Red"></asp:Label>
        번 글을 삭제하시겠습니까?<br />
        암호 : 
        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" MaxLength="10"></asp:TextBox>
        <asp:Button ID="btnDelete" runat="server" Text="삭제" 
            OnClientClick="return confirm('정말 삭제하시겠습니까?');" onclick="btnDelete_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="취소" onclick="btnCancel_Click" 
            style="height: 21px" /><br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
