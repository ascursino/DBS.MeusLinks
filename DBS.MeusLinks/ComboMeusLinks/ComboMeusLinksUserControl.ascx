<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComboMeusLinksUserControl.ascx.cs" Inherits="DBS.MeusLinks.ComboMeusLinks.ComboMeusLinksUserControl" %>
<asp:Label ID="lblCombo" runat="server" Text="{comboBox}"></asp:Label>

<script language="javascript" type="text/javascript">

    function abrirLinkDaCombo() {

        var combo = document.getElementById("comboLinks");
        var valor = combo.options[combo.selectedIndex].value;

        if (valor != 0) {

            if (valor.charAt(0) == 'N') {

                //Abro em nova janela
                valor = valor.substr(1)
                window.open(valor);
            }
            else {
                //abro na mesma janela
                window.location = valor;
            }

            
        }
    }
    
</script>
 