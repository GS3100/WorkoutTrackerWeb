<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkoutInput.aspx.cs" Inherits="WorkoutTrackerWeb.WorkoutInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4">
        <table class="table table-dark">
            <tr>
                <td>
                    <label>Workout Date: </label>
                    <!--
                    <div class="input-group date" data-provide="datepicker">
                        <input type="text" class="form-control"  runat="server">
                        <div class="input-group-addon">
                            <span class="glyphicon glyphicon-th"></span>
                        </div>
                    </div>-->
                    <div class="input-group date">
                        <div class="input-group-addon bg-darkCobalt fg-white"><i class="glyphicon glyphicon-th"></i></div>
                        <input type="text" class="form-control" id="txtDate" runat="server">
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
        <div class="clearfix"></div>
        <div id="DIVSetLog" class="col-lg-8" runat="server">

        </div >
       
        <!---->
        <asp:Button class="btn bg-darkCobalt fg-white" id="btnAddToWorkout" runat="server" onclick="btnAddToWorkout_OnClick" text="Add to Workout"/><br />
      
    </div>
    
    <div class="col-lg-12">
        <div style="padding-top:15px;"></div>
        <asp:GridView class="table table-striped table-bordered" runat="server" id="grdWOLog"></asp:GridView>
        <asp:Button ID="btnWOComplete" class="btn btn-success" runat="server" Text="Workout Complete!" onclick="btnWOComplete_OnClick" Visible="False" />
    </div>
    <asp:Label ID="Label1" runat="server" ></asp:Label><br />
    <asp:Label ID="lblErr" runat="server" ></asp:Label>
    <div class="clearfix"></div>
</asp:Content>

