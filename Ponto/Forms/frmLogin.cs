using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ponto.Classes;


namespace Ponto
{
    public partial class frmCPF : Form
    {
        public frmCPF()
        {
            InitializeComponent();
            this.Text = Application.ProductName.ToString();
        }


        private async void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);

            if(e.KeyChar == (char)Keys.Enter)
            {               
                string resp = clsFuncoes.ValidarDoc(this, txtCPF);
                if(resp != "")
                {
                    MessageBox.Show(resp, "CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCPF.Focus();
                }
                else
                {
                    string doc = txtCPF.Text;
                    string acesso = await clsUsuario.AcessoUsuarioAsync(doc);

                    switch (acesso)
                    {
                        case "ADMINISTRADOR":
                            Classes.clsFuncoes.OpenForm(new Forms.frmPonto(), this, "1");
                            this.Close();
                            break;

                        case "USUARIO":
                            Classes.clsFuncoes.OpenForm(new Forms.frmPonto(), this, "1");
                            this.Close();
                            break;

                        default:
                            MessageBox.Show("Usuário não cadastrado", "CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                            
                    }
                }
            }
        }

        private void frmCPF_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
