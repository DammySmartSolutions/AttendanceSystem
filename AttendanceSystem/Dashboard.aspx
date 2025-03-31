<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Dashboard" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AttendanceSystem.Dashboard" %>








<asp:Content ContentPlaceHolderID="MainContent" runat="server">






     <div class="dashboard-influence">
	            <div class="container-fluid dashboard-content">
	                <!-- ============================================================== -->
	                <!-- pageheader  -->
	                <!-- ============================================================== -->
	                <div class="row">
	                    <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
	                        <div class="page-header">
							 <h3 class="mb-2"><%=Page.Title %>  </h3>


								</div>
	                    </div>
	                </div>
	                <!-- ============================================================== -->
	                <!-- end pageheader  -->
	                <!-- ============================================================== -->
	                <!-- ============================================================== -->
	                <!-- content  -->
	                <!-- ============================================================== -->
	                <!-- ============================================================== -->
	                <!-- influencer profile  -->
	                <!-- ============================================================== -->
	                
	                    <!-- ============================================================== -->
	                    <!-- end influencer profile  -->
	                    <!-- ============================================================== -->
	                    <!-- ============================================================== -->
	                    <!-- widgets   -->
	                    <!-- ============================================================== -->
	                    <div class="row">
	                        <!-- ============================================================== -->
	                        <!-- four widgets   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- total views   -->
	                        <!-- ============================================================== -->
	                        <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Number of System Users</h5>
	                                        <h2 class="mb-0"><label id="totalusers" style ="position:relative;"> </label></h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-info-light mt-1">
	                                        <i class="fa fa-user fa-fw fa-sm text-primary"></i>
											
	                                    </div>
	                                </div>
	                            </div>
	                        </div>
	                        <!-- ============================================================== -->
	                        <!-- end total views   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- total followers   -->
	                        <!-- ============================================================== -->
	                        <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Number of Students</h5>
	                                        <h2 class="mb-0"><label id="totalstudent" style ="position:relative;"> </label></h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-primary-light mt-1">
	                                       <i class="fa fa-users fa-fw fa-sm text-info"></i> 

	                                    </div>
	                                </div>
	                            </div>
	                        </div>
	                        <!-- ============================================================== -->
	                        <!-- end total followers   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- partnerships   -->
	                        <!-- ============================================================== -->
	                        

							 <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Number of Courses </h5>
	                                        <h2 class="mb-0"><label id="totalNotCertCollect" style ="position:relative;"> </label></h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-primary-light mt-1">
	                                        <i class="fas fa-book fa-fw fa-sm text-primary"></i>
	                                    </div>
	                                </div>
	                            </div>
	                        </div>


	                        <!-- ============================================================== -->
	                        <!-- end partnerships   -->
	                        <!-- ============================================================== -->
	                        <!-- ============================================================== -->
	                        <!-- total earned   -->
	                        <!-- ============================================================== -->
	                        
							 <div class="col-xl-3 col-lg-6 col-md-6 col-sm-12 col-12">
	                            <div class="card">
	                                <div class="card-body">
	                                    <div class="d-inline-block">
	                                        <h5 class="text-muted">Total Number of Dept</h5>
	                                        <h2 class="mb-0"><label id="totaldept" style ="position:relative;"> </label></h2>
	                                    </div>
	                                    <div class="float-right icon-circle-medium  icon-box-lg  bg-primary-light mt-1">
	                                      <%--  <i class="fas fa-archive fa-fw fa-sm text-info"></i>--%>
                                            <i class="fa fa-building fa-fw  fa-sm text-info"></i> 
	                                    </div>
	                                </div>
	                            </div>
	                        </div>




	                        <!-- ============================================================== -->
	                        <!-- end total earned   -->
	                        <!-- ============================================================== -->
	                    </div>
	                    <!-- ============================================================== -->
	                    <!-- end widgets   -->
	             
	                    <!-- recommended campaigns   -->
	                    <!-- ============================================================== -->
	                    



					 <div class="card-body border-top">
                                      
                                      
                      
                                <section class="col-lg-12 connectedSortable">
    <!-- Custom tabs (Charts with tabs)-->
    <div class="card">
        <div class="card-header">
            <h3 class="card-title">
                <i class="fas fa-chart-pie mr-1"></i>
               Total Number of Students by Courses
            </h3>
            <div class="card-tools">
                <ul class="nav nav-pills ml-auto">
                    <li class="nav-item">
                        <a class="nav-link active" href="#revenue-chart" data-toggle="tab">Barchart</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#sales-chart" data-toggle="tab">Donut</a>
                    </li>
                </ul>
            </div>
        </div>
        <!-- /.card-header -->
        <div class="card-body">
            <div class="tab-content p-0">
                <!-- Morris chart - Sales -->
                <div class="chart tab-pane active" id="revenue-chart"
                    style="position: relative; height: 400px;">
                    <canvas id="barchart" height="100" style="height:auto;"></canvas>
                </div>
                <div class="chart tab-pane" id="sales-chart" style="position: relative; height: 400px;">
                    <canvas id="donut" height="100" style="height: auto;"></canvas>
                </div>
            </div>
        </div>
        <!-- /.card-body -->
    </div>
                  
</section>           
                                          

                                            
                                          




                                        
                                    </div>













	                                </div>
	                            </div>
	               





	<script type ="text/javascript">

     
  
    window.onload = function onloadTable() {


        LoadTotalNumberofStudent();
        LoadTotalSysUsers();
        LoadTotalCourses();
        LoadTotalDept();
        LoadStudentByCourses();
        LoadStaffDetails();
        LoadTaxDetails();
       
       

    }

   


    function LoadTotalNumberofStudent()
    {

          
      


           $.ajax({
               type: "GET",
               contentType: "application/json; charset=utf-8",
               dataType: "json",
               cache: false,
               data: "{}",
               url: "../api/attendance/LoadTotalStudent",
               success: function (data) {
        
                   document.getElementById("totalstudent").innerHTML = data;
    
                     }
        })

       }



    function LoadTotalSysUsers() {





        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            data: "{}",
            url: "../api/attendance/LoadTotalSysUser",
           success: function (data) {

               document.getElementById("totalusers").innerHTML = data;

            }
        })

    }




        function LoadTotalCourses() {





        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            data: "{}",
            url: "../api/attendance/LoadTotalCourses",
            success: function (data) {

                document.getElementById("totalNotCertCollect").innerHTML = data;

            }
        })

    }


    


    function LoadTotalDept() {





        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            data: "{}",
            url: "../api/attendance/LoadTotalDept",
            success: function (data) {

                document.getElementById("totaldept").innerHTML = data;

            }
        })

    }


      
    

        function LoadStudentByCourses() {

        var CheckCookieValue = document.cookie.split("=");
        var getcomid = CheckCookieValue[2];


        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            data: "{}",
            url: "../api/attendance/LoadStudentByCourses",
            success: function (data) {


                var elements = Array();
                elements = data;

                var codelbl = Array();
                var totlbl= Array();

                var i;

                for (i = 0; i < elements.length; i++) {
                    codelbl.push(elements[i].CourseCode);
                   // var getdata = elements[i].totalGrossPay;
                    // var datas = getdata.replace(/,/g, '');


                    //totlbl.push(parseFloat(datas));

                    totlbl.push(elements[i].StudentID);
                   
                }

             
                var ctx = document.getElementById('barchart').getContext('2d');
                              var myChart = new Chart(ctx, {
                                type: 'bar',
                                data: {
                                    labels: codelbl,
                                    datasets: [{
                                        label: 'Number of Students by Courses',
                                        data: totlbl,
                                        backgroundColor: [
                                            'blue',
                                            'rgba(54, 162, 235, 0.2)',
                                            'rgba(255, 206, 86, 0.2)',
                                            'rgba(75, 192, 192, 0.2)',
                                            'rgba(153, 102, 255, 0.2)',
                                            'violet',
                                              'blue',
                                              'green',
                                              'almond',
                                               'maroon',
                                               'gold',
                                               'pink',
                                               'purple',
                                               '#ead'
                                        ],

                                      
                                        borderColor: [
                                            'black',
                                               'black',
                                               'black',
                                               'black',
                                               'black',
                                               'black',
                                            'black',
                                              'black',
                                               'black',
                                               'black',
                                                'black',
                                               'black',
                                                'black',
                                                 'black'

                                        ],
                                        borderWidth: 1
                                    },
                                        ]
                                },
                                options: {
                                    scales: {
                                        yAxes: [{
                                            display: true,
                                            ticks: {
                                                beginAtZero: true,
                                             //   min: 0,
                                              //  max: 100000000,

                                            }
                                        }]
                                    }
                                }
                
                });
                
            }

        });


        LoadStudentByCourseDonut();

         }



    


        function LoadStudentByCourseDonut() {

        


             $.ajax({
                     type: "GET",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     cache: false,
                     data: "{}",
                 url: "../api/attendance/LoadStudentByCourses",
                     success: function (data) {


                 
                    

                         var elements = Array();
                         elements = data;

                        


                         var codelbl = Array();
                         var totlbl = Array();


                         var i;

                         for (i = 0; i < elements.length; i++)
                         {
                             codelbl.push(elements[i].CourseCode);
                             // var getdata = elements[i].totalGrossPay;
                             // var datas = getdata.replace(/,/g, '');


                             //totlbl.push(parseFloat(datas));

                             totlbl.push(elements[i].StudentID);
                   






                         }



                      



                     var ctx = document.getElementById('donut').getContext('2d');
                     var myChart = new Chart(ctx, {
                         type: 'doughnut',
                         data: {
                             labels: codelbl,
                             datasets: [{
                                 label: 'Number of Students by Courses',
                                 data: totlbl,
                                 backgroundColor: [
                                     'blue',
                                     'rgba(54, 162, 235, 0.2)',
                                     'rgba(255, 206, 86, 0.2)',
                                     'rgba(75, 192, 192, 0.2)',
                                     'rgba(153, 102, 255, 0.2)',
                                     'violet',
                                       'blue',
                                       'green',
                                       'almond',
                                        'maroon',
                                        'gold',
                                        'pink',
                                        'purple',
                                        '#ead'
                                 ],


                                 //borderColor: [
                                 //    'black',
                                 //       'black',
                                 //       'black',
                                 //       'black',
                                 //       'black',
                                 //       'black',
                                 //    'black',
                                 //      'black',
                                 //       'black',
                                 //       'black',
                                 //        'black',
                                 //       'black',
                                 //        'black',
                                 //         'black'

                                 //],
                                 //borderWidth: 5
                                 hoverOffset: 4
                             },
                             ]
                         },
                         //options: {
                         //    scales: {
                         //        yAxes: [{
                         //            display: true,
                         //            ticks: {
                         //                beginAtZero: true,
                         //                //   min: 0,
                         //                //  max: 100000000,

                         //            }
                         //        }]
                         //    }
                         //}

                     });

                 }

             });

         }

  

  

    

    </script>













    </asp:Content>