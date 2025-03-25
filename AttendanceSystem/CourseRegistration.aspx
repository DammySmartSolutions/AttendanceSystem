<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Course Registration" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="AttendanceSystem.CourseRegistration" %>









<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    

    
    
   
    <link rel="stylesheet" href="assets/vendor/bootstrap/css/bootstrap.min.css">
    <link href="assets/vendor/fonts/circular-std/style.css" rel="stylesheet">
    <link rel="stylesheet" href="assets/libs/css/style.css">
    <link rel="stylesheet" href="assets/vendor/fonts/fontawesome/css/fontawesome-all.css">
    <link rel="stylesheet" href="assets/vendor/datepicker/tempusdominus-bootstrap-4.css" />
    <link rel="stylesheet" href="assets/vendor/inputmask/css/inputmask.css" />


    <div class="alert alert-primary" runat="server" id="divalert">
         <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                         
         </div>



    <div class="row">
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="page-header" id="top">
                                    <h2 class="pageheader-title"><%=Page.Title %> </h2>
                                   
                                   
                                </div>
                            </div>
                        </div>


                       <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>





    
                        <div class="row">
						
										
                            <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                
                                <div class="card">
                                  
                                    <div class="card-body">
                                       
                                      

                                         <div class="row">
                                             <div class="col-sm-6">

                                                 <div class="form-group">
                                                      <label for="ddlsemester" class="col-form-label">Semester</label>
                                      <asp:DropDownList ID="ddlsemester" AppendDataBoundItems="true" runat="server" DataSourceID="SqlDataSource1" DataTextField="semester" DataValueField="semid" CssClass="form-control form-control-sm" >    
                                      <asp:ListItem Text="--Select Semester--" Value="0" />   
                                     </asp:DropDownList>
                                             <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:SqlConnection %>"
                                    SelectCommand="select * from tblSetupSemester">
                                     </asp:SqlDataSource>

                                            </div>

                                             </div>

                                             <div class="col-sm-6">

                                                 <div class="form-group">
                                                
                                                   <label for="ddlSession" class="col-form-label">Session</label>
                                      <asp:DropDownList ID="ddlSession" AppendDataBoundItems="true" runat="server" DataSourceID="SqlDataSource2" DataTextField="session" DataValueField="sessid" CssClass="form-control form-control-sm" >    
                                      <asp:ListItem Text="--Select Session--" Value="0" />   
                                     </asp:DropDownList>
                                             <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:SqlConnection %>"
                                    SelectCommand="select * from tblSetupSession">
                                     </asp:SqlDataSource>
                                                     

                                            </div>

                                             </div>

                                             </div>

                                      


                                         
                                    <asp:UpdatePanel ID="upSetSession" runat="server">
                                            <ContentTemplate>

                                             <div class="row">
                                        <div class="col-sm-6">

                                            <div class="form-group">
                                          

                                                       <label for="ddlDept" class="col-form-label">Department Name</label>
                                                      <asp:DropDownList ID="ddlDept" AppendDataBoundItems="true" runat="server" DataSourceID="SqlDataSource3" DataTextField="name" DataValueField="deptid" CssClass="form-control form-control-sm" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged"         AutoPostBack="true" >    
                                                      <asp:ListItem Text="--Select Dept--" Value="0" />   
                                                     </asp:DropDownList>
                                                             <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                                                    ConnectionString="<%$ ConnectionStrings:SqlConnection %>"
                                                    SelectCommand="select * from tblSetupDept">
                                                     </asp:SqlDataSource>




                                       </div>

                                        </div>

                                        <div class="col-sm-6">

                                            <div class="form-group">
       
                                                 <label for="ddlcode" class="col-form-label">Course Code</label>
                                            <asp:DropDownList ID="ddlcode"  runat="server"   CssClass="form-control form-control-sm" >    
                                             </asp:DropDownList>

                                       </div>

                                        </div>

                                          </div>




                                                 <div class="row">
                                             <div class="col-sm-6">

                                                 <div class="form-group">
   

                                                            <label for="ddlvenue" class="col-form-label">Venue</label>
                                                           <asp:DropDownList ID="ddlvenue"  runat="server"  CssClass="form-control form-control-sm"  >    
                                                             
                                                          </asp:DropDownList>
                                                                 




                                            </div>

                                             </div>

                                             <div class="col-sm-6">

                                                 <div class="form-group">
       
                                                                          <label for="ddlstaffid" class="col-form-label">Student</label>
                                                                         <asp:DropDownList ID="ddlstaffid"  runat="server"  CssClass="form-control form-control-sm"  >    
   
                                                                        </asp:DropDownList>
                                                                 

                                            </div>

                                             </div>

                                               </div>




                                    </ContentTemplate>

                                          </asp:UpdatePanel>

                                        <div class="row">
                                        <div class="col-sm-6">

                                        <div class="form-group">
                                                     <asp:Button  CssClass="btn btn-success form-control form-control-sm" runat="server" ID="btnsave" OnClick="btnsave_Click" Text="Save" />
                                                   </div>

                                                    </div>

    

                                            </div>
                                        
                                      
                                                                           
                                        


                                         </div>
                                            


                               
                                
                                <div class="card-body border-top">
                                      
                                      
                                          <div class="table-responsive">
                        <table id="table" class="table table-striped table-bordered second" style="width: 100%">

                            <thead>
                                <tr>

                                   
                                    <th>Course Code</th>
                                    <th>Student</th>
                                    
                                    <th>Semester</th>
                                    <th>Session</th>
                                    <th>Venue</th>


                                                                       
                                     <th>#</th>
                             <th>#</th>


                                </tr>
                            </thead>
                            <tbody style="width: 100%">
                            </tbody>





                        </table>
                    </div>
                                           
                                          

                                            
                                          




                                        
                                    </div>


                                          <asp:HiddenField ID="Allocid" runat="server" />
                                  
                               
                                </div>
                            </div>
                      
                   
                            </div>






       
          <script src="Scripts/Attendance/CourseRegistration.js"></script>

         
           
       
     


      

        





    </asp:Content>
