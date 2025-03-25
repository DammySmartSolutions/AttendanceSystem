<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Capture Attendance" AutoEventWireup="true" CodeBehind="CaptureAttendance.aspx.cs" Inherits="AttendanceSystem.CaptureAttendance" %>






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
       

                                       </div>

                                        </div>

                                          </div>

                                                                                                




                                    </ContentTemplate>

                                          </asp:UpdatePanel>

                                        <div class="row">
                                        <div class="col-sm-6">

                                        <div class="form-group">
                                                     <asp:Button  CssClass="btn btn-success form-control form-control-sm" runat="server" ID="btnview" OnClick="btnview_Click" Text="Load Attendance" />
                                                   </div>

                                                    </div>

    

                                            </div>
                                        
                                      
                                                                           
                                        


                                         </div>
                                            


                               
                                
                                <div class="card-body border-top">

                                        <h4>Attendance Table</h4>
                                      
                                      
                                          <div class="table-responsive">

                                    <div class="row">
                                    <div class="col-sm-6">

                                    <div class="form-group">
                                                 <asp:Button  CssClass="btn btn-success form-control form-control-sm" runat="server" ID="btnProcess" OnClick="btnProcess_Click" Text="Process Attendance" Visible="false" />
                                               </div>

                                                </div>

    

                                        </div>
                                              
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                BorderColor="CornflowerBlue" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                Font-Names="Arial" Font-Size="10pt" ForeColor="#333333" GridLines="None"
                Style="z-index: 100; left: 0%; position: relative; top: 0px; width: 100%;" Width="100%"
                Font-Overline="False" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" EmptyDataText="No student registration found in the Table"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDataBound="GridView1_RowDataBound"
                OnRowDeleting="GridView1_RowDeleting"           AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowEditing="GridView1_RowEditing"
                OnRowCommand="GridView1_RowCommand">


                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />

                        </ItemTemplate>

                        <ItemStyle Width="20px"></ItemStyle>
                    </asp:TemplateField>


                    <asp:BoundField DataField="StudentID" HeaderText="StudentID" Visible="true">

                        <ItemStyle Width="200px" HorizontalAlign="left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="StudentName" HeaderText="Name">

                        <ItemStyle Width="450px" HorizontalAlign="left" />
                    </asp:BoundField>

                    <asp:BoundField DataField="code" HeaderText="CourseCode">

                        <ItemStyle Width="200px" HorizontalAlign="left" />
                    </asp:BoundField>


                    

                    
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="Present" runat="server" CommandName="Present" CommandArgument="<%# Container.DataItemIndex %>" ForeColor="White" BackColor ="Green" />
                        </ItemTemplate>



                    </asp:TemplateField>




                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button Text="Absent" runat="server" CommandName="Absent" CommandArgument="<%# Container.DataItemIndex %>" ForeColor="White" BackColor ="Red" />
                        </ItemTemplate>



                    </asp:TemplateField>

                   
                </Columns>


                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle HorizontalAlign="Left" BackColor="CornflowerBlue" Font-Bold="False" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="maroon" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="LemonChiffon" Font-Size="8pt" ForeColor="#333333" Font-Names="Arial" HorizontalAlign="Left"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>


                        
                    </div>
                                           
                                          

                                            
                                          




                                        
                                    </div>


                                          <asp:HiddenField ID="courseid" runat="server" />
                                  
                               
                                </div>
                            </div>
                      
                   
                            </div>






       
         

         
           
       
     


      

        





    </asp:Content>

