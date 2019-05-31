<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkoutInput.aspx.cs" Inherits="WorkoutTrackerWeb.WorkoutInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4">
        <table class="table table-dark">
            <tr>
                <td>
                    <label>Workout Date: </label>
                    <div class="input-group date" data-provide="datepicker">
                        <input type="text" class="form-control" id="txtDate" runat="server">
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>
                </td><td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <label>Body Area: </label>
                    <asp:DropDownList class="form-control" ID="selBodyArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selBodyArea_SelectedIndexChanged" ></asp:DropDownList>
                </td>
                <td>
                    <label>Exercise: </label>
                    <asp:DropDownList class="form-control" ID="selExercise" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Machine: </label>
                    <asp:DropDownList class="form-control" ID="selMachine" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <label>Number of Sets: </label>
                    <asp:DropDownList class="form-control" ID="selNumOfSets" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selNumOfSets_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <div id="DIVSetLog" class="col-lg-8" runat="server">

        </div >
       
        <!---->
        <asp:Button class="btn btn-success" id="btnAddToWorkout" runat="server" onclick="btnAddToWorkout_OnClick" text="Add to Workout"/>
      
    </div>
    <div class="col-lg-8" id="tblLog" runat="server">
        
    </div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="lblErr" runat="server" Text="Label"></asp:Label>
    <div class="clearfix"></div>
</asp:Content>

