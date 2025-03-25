<%@ Page Language="C#"  MasterPageFile="~/Site.Master" Title="Add New User" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="AttendanceSystem.AddUser" %>







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
                                                <label for="txtid" class="col-form-label">Staff/Student ID</label>
                                                <input id="txtid" type="text" class="form-control form-control-sm" runat="server"  placeholder="202381568">
                                            </div>

                                             </div>

                                             <div class="col-sm-6">

                                                 <div class="form-group">
                                                
                                                      <label for="txtname" class="col-form-label">Name</label>
                                                     <input id="txtname" type="text" class="form-control form-control-sm" runat="server" placeholder="Surname Firstname" >
                                                     

                                            </div>

                                             </div>

                                             </div>

                                      


                                         
                                    <asp:UpdatePanel ID="upSetSession" runat="server">
                                            <ContentTemplate>

                                             <div class="row">
                                        <div class="col-sm-6">

                                            <div class="form-group">
                                          

                                                       <label for="txtemail" class="col-form-label">Email Address</label>
                                                      <input id="txtemail" type="email" class="form-control form-control-sm" runat="server" placeholder="oseedru@mun.ca" >
                                                
                                                
                                               


                                       </div>

                                        </div>

                                        <div class="col-sm-6">

                                            <div class="form-group">
       
                                                 <label for="txtpass" class="col-form-label">Password</label>

                                                 <input id="txtpass" type="password" class="form-control form-control-sm" runat="server" placeholder="New password" >

                                       </div>

                                        </div>

                                          </div>




                                                 <div class="row">
                                             <div class="col-sm-6">

                                                 <div class="form-group">
   

                                                            <label for="txtconfirmpass" class="col-form-label">Confirm Password</label>
                                                           <input id="txtconfirmpass" type="password" class="form-control form-control-sm" runat="server" placeholder="Same as New password" >
                                                                 




                                            </div>

                                             </div>

                                             <div class="col-sm-6">

                                                 <div class="form-group">
       
                                                      <label for="ddlDept" class="col-form-label">Department</label>
                                                  <asp:DropDownList ID="ddlDept" AppendDataBoundItems="true" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="deptid" CssClass="form-control form-control-sm" >    
                                                  <asp:ListItem Text="--Select Department--" Value="0" />   
                                                 </asp:DropDownList>
                                                         <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                                ConnectionString="<%$ ConnectionStrings:SqlConnection %>"
                                                SelectCommand="select * from tblSetupDept">
                                                 </asp:SqlDataSource>


                                            </div>

                                             </div>

                                               </div>







                                                     <div class="row">
                                             <div class="col-sm-6">

                                                 <div class="form-group">
   

                                                            <label for="ddlStatus" class="col-form-label">Status</label>

                                                       <asp:DropDownList ID="ddlStatus" AppendDataBoundItems="true" runat="server" DataSourceID="SqlDataSource2" DataTextField="status" DataValueField="id" CssClass="form-control form-control-sm" >    
                                                  <asp:ListItem Text="--Select Status--" Value="0" />   
                                                 </asp:DropDownList>
                                                         <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                                                ConnectionString="<%$ ConnectionStrings:SqlConnection %>"
                                                SelectCommand="select * from tblStatus">
                                                 </asp:SqlDataSource>

                                                           




                                            </div>

                                             </div>

                                             <div class="col-sm-6">

                                                 <div class="form-group">
       
                                                     <%-- <label for="ddlsemester" class="col-form-label">Department</label>
                                                  
                                                     <input id="Password1" type="password" class="form-control form-control-sm" runat="server" >--%>
                     
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
                                            


                               
                                
                                


                                          
                                  
                               
                                </div>
                            </div>
                      
                   
                            </div>






       

         
           
       
     


      

        





    </asp:Content>
