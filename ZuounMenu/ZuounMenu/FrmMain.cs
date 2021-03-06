﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZuounMenu.Menu;

namespace ZuounMenu
{
    public partial class FrmMain : Form
    {
        #region Definições para o resize

        private const int cGrip = 16;
        private const int cCaption = 32;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region Definições para o Click and Drag

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /// <summary>
        /// Método responsável pelo Click and Drag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickToDrag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        public FrmMain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #region Botões Barra de Tarefas
        private void BMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Botões de Contato

        private void BSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://monteiro.dev");
        }

        private void BTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/gmonteeeiro");
        }

        private void BGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gmonteeeiro");
        }

        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            MontaMenu menu = new MontaMenu(pMenu, pSubMenu, 40, pMenu.Size.Width, 10);
            menu.CarregaMenu();
        }
    }
}
