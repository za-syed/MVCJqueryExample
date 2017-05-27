$(function () {
    $.ajaxSetup({ cache: false });  
    $("a[data-modal]").on("click", function (e) {
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });    
});

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $('#progress').show();
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#progress').hide();
                    location.reload();
                } else {
                    $('#progress').hide();
                    $('#myModalContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}

//$(document).ready(
//     (function () {
//         var selectedState = $("#ddlState").val();
//         selectedStateChanged($(selectedState));
//     }));

//function selectedStateChanged(obj) {
//    $("#ddlState").change(function () {
//        $.getJSON('Friends/GetCitiesByState/' + $('#ddlState').val(), function (cities) {    //counties is retrieved from UsStates Controller
//            $('#ddlCity').empty();    //initialize county dropdownlist before populating
//            $.each(cities, function (i, city) {
//                $("#ddlCity").append('<option value"' + city.Value + '">' + city.Text + '</option>');
//            });
//        });
//    });
//};

$(document).ready(function () {
    $('#ddlState').change(function () {
        $.ajax({
            type: "post",
            url: "/Friends/GetCitiesByState",
            data: { stateCode: $('#ddlState').selectedItems[0] },
            datatype: "json",
            traditional: true,
            success: function (data) {
                var ddlCity = "<select id='ddlCity'>";
                ddlCity = ddlCity + '<option value="">--Select--</option>';
                for (var i = 0; i < data.length; i++) {
                    ddlCity = ddlCity + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                }
                ddlCity = ddlCity + '</select>';
                $('#city').html(ddlCity);
            }
        });
    });
});