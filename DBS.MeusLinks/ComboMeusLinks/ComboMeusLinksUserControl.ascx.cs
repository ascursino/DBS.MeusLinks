using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Text;

namespace DBS.MeusLinks.ComboMeusLinks
{
    public partial class ComboMeusLinksUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                lblCombo.Text = montaCombo();
            }
            catch (Exception ex)
            {
                lblCombo.Text = ex.ToString();
            }
        }

        private String montaCombo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<select id=\"comboLinks\" onchange=\"abrirLinkDaCombo()\">");

            using (SPWeb web = SPContext.Current.Site.RootWeb)
            {
                SPList lstLinks = web.Lists["Meus Links"];

                SPQuery query = new SPQuery
                {
                    //Query = "<Where><Eq><FieldRef Name=\"Author\" /><Value Type=\"Integer\"><UserID Type=\"Integer\" /></Value></Eq></Where>"
                    //Query = @"<Where><Eq><FieldRef Name=""Destinatario"" LookupId= ""TRUE""/><Value Type=""User"">" + web.CurrentUser.ID.ToString() + "</Value></Eq></Where>";

                    Query = @"                
                               <Where>
                                  <Eq>
                                     <FieldRef Name='Destinatario' LookupId='True' />
                                     <Value Type='User'>"+ web.CurrentUser.ID.ToString() + @"</Value>
                                  </Eq>
                               </Where>"               
                };

                //cboLinks.Items.Add(new ListItem("Acessar meus links favoritos", ""));
                sb.AppendLine("<option value=\"0\">Acessar meus links favoritos</option>");

                var Links = lstLinks.GetItems(query);

                foreach (SPListItem link in Links)
                {
                    if (link["AbrirNovaJanela"].ToString().ToUpper() == "TRUE")
                    {
                        //Se for para abrir em nova janela, coloco "N" na frente do valor do link para identificar no Javascript
                        sb.AppendLine("<option value=\"N" + link["Link"].ToString() + "\">" + link["Title"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.AppendLine("<option value=\"" + link["Link"].ToString() + "\">" + link["Title"].ToString() + "</option>");
                    }
                }
            }

            sb.AppendLine("</select>");

            return sb.ToString();

        }

        //protected void cboLinks_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect(cboLinks.SelectedItem.Value.ToString());
        //}
    }
}
