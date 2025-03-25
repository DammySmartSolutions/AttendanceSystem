<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="User List" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AttendanceSystem.UserList" %>






<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    








        <div class="alert alert-primary" runat="server" id="divalert">
            <asp:Label ID="lblmsg" runat="server"></asp:Label>

        </div>


        <div class="row">
            <div class="col-6">
                <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                    <div class="page-header">
                        <h2 class="pageheader-title"><%=Page.Title %> </h2>

                    </div>
                </div>
            </div>
            <div class="col-5">
                <a class="btn btn-dark float-right" style="text-align: end" runat="server" href="AddUser.aspx"><i class="fa fa-fw fas fa-plus-circle"></i>Add New User</a>

            </div>

        </div>


        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
            <div class="card">

                <div class="card-body">
                     <h3> User Table</h3>
                    <div class="table-responsive">
                        <table id="table" class="table table-striped table-bordered second" style="width: 100%">

                            <thead>
                                <tr>

                                    <th>ID</th>
                                    <th>Full Name </th>
                                    <th>Email Address</th>
                                     <th>Dept</th>
                                    <th>Status</th>
                                    <th>Action</th>



                                </tr>
                            </thead>
                            <tbody style="width: 100%">
                            </tbody>





                        </table>
                    </div>
                </div>


                
            </div>
        </div>


        <asp:HiddenField ID="userid" runat="server" />


    <script src="Scripts/Attendance/UserList.js"></script>


      
      




   










</asp:Content>
