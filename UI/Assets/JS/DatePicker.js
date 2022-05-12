$(document).ready(function() {

    $("input[id*=txtDateIssueInsert]").datepicker({

        dateFormat: "dd/mm/yy",
        minDate: new Date(2022, 1, 1),
        maxDate: new Date(2022, 12, 31)

    });

});

//$(document).ready(function() {

//    $('id=txtDateIssueInsert').datepicker({
//        dateFormat: 'dd/mm/yyyy'
//    });
//});