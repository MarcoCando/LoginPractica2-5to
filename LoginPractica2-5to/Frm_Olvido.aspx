<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Frm_Olvido.aspx.cs" Inherits="LoginPractica2_5to.Frm_Olvido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <contenttemplate>

        <div class="container">

            <div class="row justify-content-center">

                <div class="col-xl-10 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-2">Olvidaste tu Contraseña</h1>
                                            <p class="mb-4">Ingresa porfavor tu Correo Electrónico!</p>
                                        </div>
                                        <form class="user">
                                            <div class="form-group">
                                                <asp:TextBox ID="txt_email" type="email" runat="server" CssClass="form-control form-control-user" placeholder="Ingrese su Email"></asp:TextBox>
                                                
                                            </div>
                                             <div class="form-group">
                                                <asp:TextBox ID="txt_usu" type="text" runat="server" CssClass="form-control form-control-user" placeholder="Ingrese su Usuario"></asp:TextBox>
                                                
                                            </div>

                                            <asp:Button ID="Button1" CssClass="btn btn-facebook" runat="server" Text="Enviar Correo" OnClick="Button1_Click" />
                                        </form>
                                        <hr>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

            </div>


        </div>


    </contenttemplate>

</asp:Content>
