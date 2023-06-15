using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sbor_dannyh_s_PK
{
    public partial class fMenu : Form
    {
        //Constructor
        public fMenu()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }

        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
       
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelBarTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        int lx, ly;
        int sw, sh;
        private void btnMHide_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMHide.Visible = false;
            btnNormal.Visible = true;

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMHide.Visible = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 230)
            {
                this.tmShowMenu.Start();
            }
            else if (panelMenu.Width == 55)
            {
                this.tmHideMenu.Start();
            }

            //if (panelMenu.Width == 55)
            //{
            //    panelMenu.Width = 230;
            //}
            //else

            //    panelMenu.Width = 55;
        }

        private void tmHideMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 230)
                this.tmHideMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width + 5;
            
        }

        private void tmShowMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 55)
                this.tmShowMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width - 5;
        }

        private void OpenFormInPanel(object formHijo)
        {
            if (this.panelContenedorForm.Controls.Count > 0)
                this.panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;            
            this.panelContenedorForm.Controls.Add(fh);
            this.panelContenedorForm.Tag = fh;
            fh.Show();
        }
        private void ShowFormLogo()
        {
            OpenFormInPanel(new fLogo());
        }

        private void fMenu_Load(object sender, EventArgs e)
        {
            ShowFormLogo();
        }
        private void ShowFormLogoAtCloseForms(object sender, FormClosedEventArgs e)
        {
            ShowFormLogo();
        }
        
        private void btnHard_Click(object sender, EventArgs e)
        {
            fHard fm = new fHard();
            fm.FormClosed += new FormClosedEventHandler(ShowFormLogoAtCloseForms);
            OpenFormInPanel(fm);
        }

        private void btnProgramm_Click(object sender, EventArgs e)
        {
            fProgramm fm = new fProgramm();
            fm.FormClosed += new FormClosedEventHandler(ShowFormLogoAtCloseForms);
            OpenFormInPanel(fm);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            fProcess fm = new fProcess();
            fm.FormClosed += new FormClosedEventHandler(ShowFormLogoAtCloseForms);
            OpenFormInPanel(fm);
        }

        private void btnMExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnOS_Click(object sender, EventArgs e)
        {
            fOS fm = new fOS();
            fm.FormClosed += new FormClosedEventHandler(ShowFormLogoAtCloseForms);
            OpenFormInPanel(fm);
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            fService fm = new fService();
            fm.FormClosed += new FormClosedEventHandler(ShowFormLogoAtCloseForms);
            OpenFormInPanel(fm);
        }



        
        private void tmDateTime_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToString("HH:mm:ssss");
        }
        

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            fNetwork fm = new fNetwork();
            fm.FormClosed += new FormClosedEventHandler(ShowFormLogoAtCloseForms);
            OpenFormInPanel(fm);
        }

        

    }
}
