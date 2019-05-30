$(document).ready(function () {
    

    //function btnAddToWorkout() {
        //var selBodyArea = $("#selBodyArea").val();
    $("#btnAddToWorkout").click(function () {
        var selBodyArea = $("#MainContent_selBodyArea option:selected").text();
        var sets = $("#MainContent_selNumOfSets option:selected").text();
        var arrWt = $("[name='txtWt']");
        var arrReps = $("[name='txtReps']");
        var td = "";
       
        for (var i = 0; i < arrWt.length; i++) {
            td += "<tr><td>Set " + i + 1 + "</td><td>ex</td><td>" + arrWt[i].value; +"</td><td>" + arrReps[i].value; + "</td></tr>";
        }
        $("#tblLog").append(td);
        
    });
        
    //}
});