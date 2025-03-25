<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Generate Attendance" AutoEventWireup="true" CodeBehind="rptAttendance.aspx.cs" Inherits="AttendanceSystem.rptAttendance" %>






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
                                       
                                       <asp:UpdatePanel ID="upSetSession" runat="server">
         <ContentTemplate>

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
                                                
                                                                                            <label for="ddlsession" class="col-form-label">Session</label>
                                  <asp:DropDownList ID="ddlsession" AppendDataBoundItems="true" runat="server" DataSourceID="SqlDataSource2" DataTextField="session" DataValueField="sessid" CssClass="form-control form-control-sm"  AutoPostBack="true" OnSelectedIndexChanged="ddlsession_SelectedIndexChanged">    
                                  <asp:ListItem Text="--Select Session--" Value="0" />   
                                 </asp:DropDownList>
                                         <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                                ConnectionString="<%$ ConnectionStrings:SqlConnection %>"
                                SelectCommand="select * from tblSetupSession">
                                 </asp:SqlDataSource>


                                            </div>

                                             </div>

                                             </div>

                                      


                                         
                                   

                                             <div class="row">
                                        <div class="col-sm-6">

                                            <div class="form-group">
                                          

                                                      
                                                 <label for="ddlcode" class="col-form-label">Course Code</label>
                                            <asp:DropDownList ID="ddlcode"  runat="server"   CssClass="form-control form-control-sm"  >    
                                             </asp:DropDownList>



                                       </div>

                                        </div>

                                        <div class="col-sm-6">

                                            <div class="form-group">
       
                                                <label for="txtdate" class="col-form-label">Date</label>
                                     <input id="txtdate" type="date" class="form-control form-control-sm" runat="server" >

                                       </div>

                                        </div>

                                          </div>

                                                                                                




                                    </ContentTemplate>

                                          </asp:UpdatePanel>

                                        <div class="row">
                                        <div class="col-sm-6">

                                        <div class="form-group">
                                                     <asp:Button  CssClass="btn btn-success form-control form-control-sm" runat="server" ID="btnview" OnClick="btnview_Click" Text="Generate Report " />
                                                   </div>

                                                    </div>

    

                                            </div>
                                        
                                      
                                                                           
                                        


                                         </div>
                                            


                               
                                
                                


                                         
                                  
                               
                                </div>
                            </div>
                      
                   
                            </div>






       
         

         
           
       
     


      

        





    </asp:Content>

