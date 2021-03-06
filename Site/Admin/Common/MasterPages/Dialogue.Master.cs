using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Kay.Global;
using Kay.BLL;

namespace Kay.Site.Admin.Common.MasterPages
{
    public partial class Dialogue : System.Web.UI.MasterPage
    {
        // Properties
        private BasePage basepage
        {
            get
            {
                return (BasePage)this.Page;
            }
        }
        private KayUser CurrentUser
        {
            get
            {
                return basepage.CurrentUser;
            }
        }
        public HtmlGenericControl Body;

        // Load
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPreRender(EventArgs e)
        {
            // Clear messages
            MessageDisplay.Text = "";

            // Error message
            if (!String.IsNullOrEmpty(basepage.ErrorMessage))
            {
                MessageDisplay.Text += String.Format("<p class=\"error\">{0}</p>", basepage.ErrorMessage);
                basepage.ErrorMessage = String.Empty;
            }

            // Status message
            if (!String.IsNullOrEmpty(basepage.StatusMessage))
            {
                MessageDisplay.Text += String.Format("<p class=\"help\">{0}</p>", basepage.StatusMessage);
                basepage.StatusMessage = String.Empty;
            }

            // Base method
            base.OnPreRender(e);
        }
    }
}
