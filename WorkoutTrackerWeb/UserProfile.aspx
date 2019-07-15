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
  <canvas id="myChart" width="400" height="400"></canvas>
<script>
var ctx = document.getElementById('myChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: [//build dyanamically
<%
    var graph = userStats();
    var labels = graph.Item1;
    var data = graph.Item2;
    Response.Write(labels.ToString());
%>
        ],
        datasets: [{
            label: '# of Votes',
            data: [
                //12, 19, 3, 5, 2, 3
<%
    Response.Write(data.ToString());
%>
            ],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});
</script>
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
                <asp:Button CssClass="btn btn-info"  ID="BtnUpdateUser" OnClick="BtnUpdateUser_Click" runat="server" Text="Update" />

                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:TextBox ID="hidID" runat="server" Visible="False"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>

    <div class="clearfix"></div>
</asp:Content>