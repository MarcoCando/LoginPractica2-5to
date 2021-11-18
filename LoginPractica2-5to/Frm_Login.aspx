<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Frm_Login.aspx.cs" Inherits="LoginPractica2_5to.Frm_Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ContentTemplate>


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
                                                    <h1 class="h4 text-gray-900 mb-4">Bienvenido a ATR LOGIN</h1>
                                                </div>

                                                <table style="width: 100%">

                                                    <div class="form-group">
                                                        <asp:TextBox type="text" ID="txt_usu" OnTextChanged="txt_usu_TextChanged" CssClass="form-control form-control-user" placeholder="Ingrese Usuario" runat="server">

                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:TextBox type="password" ID="txt_pass" CssClass="form-control form-control-user" placeholder="Ingrese Contraseña" runat="server">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="custom-control custom-checkbox small">
                                                        </div>
                                                    </div>
                                                    <asp:Button ID="btnIngresar" CssClass="btn btn-success btn-user btn-block" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                                                    <asp:Button ID="btnOlvido" CssClass="btn btn-facebook btn-user btn-block" runat="server" Text="Restaurar Contraseña" Visible="false" OnClick="btnOlvido_Click" />


                                                </table>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>

                </div>
        </ContentTemplate>
</asp:Content>
