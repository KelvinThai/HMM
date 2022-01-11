using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HMM.Pages
{
    public partial class CenteredForm : Form
    {
        #region Variables & Properties

        #endregion

        #region Form Events
        public CenteredForm()
        {
            InitializeComponent();
        }

        private void CenteredForm_Load(object sender, EventArgs e)
        {
            if (Site != null && Site.DesignMode) return;

            OnScreenActualSize();

            if (this.Parent != null)
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.Transparent;

                Rectangle parentRect = this.Parent.ClientRectangle;
                this.Left = (parentRect.Width - this.Width) / 2;

                this.Top = (parentRect.Height - this.Height) / 2;
                //this.Top = 0;
            }
        }
        #endregion

        #region Business Logic

        /// <summary>
        /// Force client to implement responsive display for 1920x1080
        /// </summary>
        public virtual void OnScreenActualSize()
        {

            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            if (resolution.Width == 1920 && resolution.Height == 1080)
            {
                this.Width = 1500;
                this.Height = 900;
            }
        }

        #endregion

    }
}
