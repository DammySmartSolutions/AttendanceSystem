
































//id = 0;
ID = 0;
const Mainform = document.getElementById("mainform")
window.onload = function onloadTable() {

    LoadDataTable();
}





function LoadDataTable() {

    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        data: "{}",
        url: "../api/attendance/LoadCourseAllocation",
        success: function (data) {


            $('#table').DataTable().destroy();

            var datatableVariable = $('#table').DataTable({


                data: data,
                "bFilter": true,
                "bInfo": false,
                "searching": true,
                "ordering": true,


                "bDisplayLength": 1000,
                "bLengthChange": true,
                "lengthMenu": [[5, 10, 15, 20, 25, 50, -1], [5, 10, 25, 50, "All"]],
                "columnDefs": [{ "width": "15%", "targets": 0 }, { "width": "30%", "targets": 1 }, { "width": "15%", "targets": 2 }, { "width": "15%", "targets": 3 }, { "width": "15%", "targets": 4 }, { "width": "10%", "targets": 5 }, { "width": "10%", "targets": 6 }],
                pageLength: 10,
                dom: "Bfrtip",
                buttons: [

                    'copy', 'csv', 'excel', 'pdf', 'print'


                ],
                columns: [

                    { 'data': 'code' },

                    { 'data': 'StaffName' },
                    { 'data': 'semester' },
                    { 'data': 'Session' },
                    { 'data': 'Venue' },
                    {


                        'render': function (data, type, full, row) {

                            return '<a id=btnEdit class="btn  btn-dark"> <i class="fa fa-fw fas fas fa-edit" > Edit</i> </a>'



                        }

                    },

                    {

                        'render': function (data, type, full, row) {

                            return '<a id=btnDelete class="btn  btn-danger mx-2"> <i class="fa fa-fw fas  fas fa-times" > Delete</i>   </a>'



                        }


                    },



                ]



            })
                ;

            datatableVariable.buttons(0, null).container().appendTo(datatableVariable.table().container());
            $('#table tfoot th').each(function () {
                var placeHolderTitle = $('#table thead th').eq($(this).index()).text();
                $(this).html('<input type="text" class="form-control input input-sm" placeholder = "Search ' + placeHolderTitle + '" />');
            });
            datatableVariable.columns().every(function () {
                var column = this;
                $(this.footer()).find('input').on('keyup change', function () {
                    column.search(this.value).draw();
                });
            });
            $('.showHide').on('click', function () {
                var tableColumn = datatableVariable.column($(this).attr('data-columnindex'));
                tableColumn.visible(!tableColumn.visible());
            });








            $('#table tbody').on('click', "#btnEdit", function () {
                // fetch the value on the grid
                var currentrow = $(this).closest("tr")
                var table = $('#table').DataTable()
                var Data = table.row(currentrow).data();
                id = Data["Allocid"]
                //document.getElementById("MainContent_txtcode").value = Data["code"];
                //document.getElementById("MainContent_txttitle").value = Data["title"];

                $("#MainContent_ddlsemester option").each(function () {
                    if ($(this).val() == Data["Semid"]) {
                        $(this).prop("selected", true);
                    }
                });


                $("#MainContent_ddlSession option").each(function () {
                    if ($(this).val() == Data["sessionid"]) {
                        $(this).prop("selected", true);
                    }
                });



                $("#MainContent_ddlDept option").each(function () {
                    if ($(this).val() == Data["Deptid"]) {
                        $(this).prop("selected", true);
                    }
                });





                document.getElementById("MainContent_Allocid").value = id;



                Mainform.Allocid.value = id








            });

            $('#table tbody').on('click', "#btnDelete", function () {

                var currentrow = $(this).closest("tr")
                var table = $('#table').DataTable()
                var Data = table.row(currentrow).data();
                ID = Data["Allocid"]
                var name = Data["code"];



                var Result = confirm("You are about to delete course allocation for  " + name )
                if (Result) {

                    DeleteItem(ID);
                }

            });





        }
        ,
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(xhr.responseText);
            alert(thrownError);
        }

    });

}







function DeleteItem(ID) {


    var CheckCookieValue = document.cookie.split("=");
    var getcomid = CheckCookieValue[2];
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        cache: false,
        data: "{}",
        url: "../api/attendance/DeleteCourseAllocation?id= " + ID + "",
        success: function (data) {
            alert(" Course  Allocation  Deleted! ");
            ID = 0;
            LoadDataTable();



        }
    })

}



