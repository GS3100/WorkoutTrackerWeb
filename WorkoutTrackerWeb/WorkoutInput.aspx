<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkoutInput.aspx.cs" Inherits="WorkoutTrackerWeb.WorkoutInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4">
    <table class="table table-dark">
        <tr>
            <td>
                <label>Workout Date: </label>
                <div class="input-group date" data-provide="datepicker">
                    <input type="text" class="form-control">
                    <div class="input-group-addon">
                        <span class="glyphicon glyphicon-th"></span>
                    </div>
                </div>
            </td><td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <label>Body Area: </label>
                <asp:DropDownList class="form-control" ID="selBodyArea" runat="server"></asp:DropDownList>
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
                <asp:DropDownList class="form-control" ID="selNumOfSets" runat="server" AutoPostBack="True" OnSelectedIndexChanged="selNumOfSets_SelectedIndexChanged" ></asp:DropDownList>
            </td>
        </tr>
    </table>
    <div id="DIVSetLog" runat="server">

    </div>
        <button class="btn btn-success" id="btnAddToWorkout">Add to Workout</button>
    </div>
    <div class="clearfix"></div>
</asp:Content>

