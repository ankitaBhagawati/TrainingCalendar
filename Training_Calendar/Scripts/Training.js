//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
 
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Training/ListTechnical",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //console.log(result);
            var html = '';
            $.each(result, function (key, item) {

                //tr = $('<tr/>');
                //tr.append("<td>" + item.DateString + "</td>");
                //tr.append("<td>" + item.Program + "</td>");
                //tr.append("<td>" + item.Facillator + "</td>");
                //tr.append("<td>" + item.Details + "</td>");
                //$('table').append(tr);
                html += '<tr>';
                html += '<td>' + item.DateString + '</td>';
                html += '<td>' + item.Program + '</td>';
                html += '<td>' + item.Facillator + '</td>';
                html += '<td>' + item.Details + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Training_Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Training_Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}





//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var Obj = {
        
        Date: $('#Date').val(),
        Program: $('#Program').val(),
        Facillator: $('#Facillator').val(),
        Details: $('#Details').val()
    };
    $.ajax({
        url: "/Training/Add",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

////Get ID
//function getbyID(ID) {
//    $('#Date').css('border-color', 'lightgrey');
//    $('#Program').css('border-color', 'lightgrey');
//    $('#Facillator').css('border-color', 'lightgrey');
//    $('#Details').css('border-color', 'lightgrey');
//    $.ajax({
//        url: "/Training/getbyID/" + ID,
//        typr: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            $('#Training_Id').val(result.Training_Id);
//            $('#Date').val(result.Date);
//            $('#Program').val(result.Program);
//            $('#Facillator').val(result.Facillator);
//            $('#Details').val(result.Details);

//            $('#myModal').modal('show');
//            $('#btnUpdate').show();
//            $('#btnAdd').hide();
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//    return false;
//}



function getbyID(ID) {
    $('#Date').css('border-color', 'lightgrey');
    $('#Program').css('border-color', 'lightgrey');
    $('#Facillator').css('border-color', 'lightgrey');
    $('#Details').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Training/getbyID/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Training_Id').val(result.Training_Id);
            $('#Date').val(result.Date);
            $('#Program').val(result.Program);
            $('#Facillator').val(result.Facillator);
            $('#Details').val(result.Details);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            //$('#btnUpdate').html('Update');
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}




////Update  
//function Update() {
//    var res = validate();
//    if (res == false) {
//        return false;
//    }
//   // console.log($("Training_Id"))

//    var obj = {
//        Training_Id: $('#Training_Id').val(),
//        Date: $('#Date').val(),
//        Program: $('#Program').val(),
//        Facillator: $('#Facillator').val(),
//        Details: $('#Details').val(),
//    };
//    $.ajax({
//        url: "/Training/Update",
//        data: JSON.stringify(obj),
//        type: "POST",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            loadData();
//            $('#myModal').modal('hide');
//            $('#Training_Id').val("result.Training_Id");
//            $('#Date').val("");
//            $('#Program').val("");
//            $('#Facillator').val("");
//            $('#Details').val("");
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}





function Update() {
   // $('#myModalLabel').html('Update');
    var res = validate();
    if (res == false) {
        return false;
    }
    var Obj = {
        Training_Id: $('#Training_Id').val(),

        //Training_Id: $('#Training_Id').val(),
        Date: $('#Date').val(),
        Program: $('#Program').val(),
        Facillator: $('#Facillator').val(),
        Details: $('#Details').val(),
    };
    $.ajax({
        url: "/Training/Update",
        data: JSON.stringify(Obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
           
           
            $('#myModal').modal('hide');



            $('#Training_Id').val("");
            $('#Date').val("");
            $('#Program').val("");
            $('#Facillator').val("");
            $('#Details').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}










//Delete 
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Training/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Clear 
function clearTextBox() {
    $('#Training_Id').val("");
    $('#Date').val("");
    $('#Program').val("");
    $('#Facillator').val("");
    $('#Details').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Date').css('border-color', 'lightgrey');
    $('#Program').css('border-color', 'lightgrey');
    $('#Facillator').css('border-color', 'lightgrey');
    $('#Details').css('border-color', 'lightgrey');
}
//Valdidation 
function validate() {
    var isValid = true;
    if ($('#Date').val().trim() == "") {
        $('#Date').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Date').css('border-color', 'lightgrey');
    }
    if ($('#Program').val().trim() == "") {
        $('#Program').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Program').css('border-color', 'lightgrey');
    }
    if ($('#Facillator').val().trim() == "") {
        $('#Facillator').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Facillator').css('border-color', 'lightgrey');
    }
    if ($('#Details').val().trim() == "") {
        $('#Details').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Details').css('border-color', 'lightgrey');
    }
    return isValid;
}