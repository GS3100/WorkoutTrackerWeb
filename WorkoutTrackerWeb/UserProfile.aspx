<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="WorkoutTrackerWeb.UserProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>User Profile</h3>
    <div class="col-md-3">
    <asp:Table class="table table-bordered" ID="Table1" runat="server">
        <asp:TableRow><asp:TableCell>Name</asp:TableCell><asp:TableCell>
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell>DOB</asp:TableCell><asp:TableCell>
            <asp:Label ID="lblDOB" runat="server" Text="Label"></asp:Label></asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell>Height</asp:TableCell><asp:TableCell>
            <asp:Label ID="lblHeight" runat="server" Text="Label"></asp:Label></asp:TableCell></asp:TableRow>
        <asp:TableRow><asp:TableCell>Weight</asp:TableCell><asp:TableCell>
            <asp:Label ID="lblWeight" runat="server" Text="Label"></asp:Label></asp:TableCell></asp:TableRow>
    </asp:Table>
        
    </div>
    <div class="col-md-3">
        
        <asp:Table class="table table-bordered" ID="Table2" runat="server">

            <asp:TableRow>
                <asp:TableCell>New Height</asp:TableCell><asp:TableCell>
                <asp:TextBox CssClass="input-sm" ID="txtHeightFt" runat="server" size="2"></asp:TextBox> <asp:TextBox CssClass="input-sm" ID="txtHeightIn" runat="server" size="2"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>New Weight</asp:TableCell><asp:TableCell>
                <asp:TextBox CssClass="input-sm" ID="txtWt" runat="server" size="2"></asp:TextBox> </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2">
                <asp:Button CssClass="btn btn-info"  ID="btnUpdateUser" runat="server" Text="Update" />

                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

    </div>

    <div class="clearfix"></div>
</asp:Content>