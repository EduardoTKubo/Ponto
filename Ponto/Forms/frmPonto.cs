using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Ponto.Classes;


namespace Ponto.Forms
{
    public partial class frmPonto : Form
    {
        public frmPonto()
        {
            InitializeComponent();

            this.Text = Application.ProductName.ToString() + " ".PadLeft(110) + Application.ProductVersion;

            timer1.Interval = 1000;
            timer1.Enabled = true;

            lblHora.Parent = pictureBox1;
            lblHora.BackColor = Color.Transparent;

            toolStripStatusLabel1.Text = clsVariaveis.usuNome;
            toolStripStatusLabel2.Text = clsVariaveis.usuEmpresa;
            toolStripStatusLabel3.Text = DateTime.Now.ToShortDateString();

            CarregarLista();

            tabPage1.Select();
                        
        }

        private async void CarregarLista()
        {
            listBox1.Items.Clear();

            clsVariaveis.GstrSQL = "select ID ,HORA1 ,HORA2 ,HORA3 ,HORA4 from A_Cadastro where Data = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and CPF = '" + clsVariaveis.usuDoc + "' order by ID";
            DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    listBox1.Items.Add(item["HORA1"]);
                    listBox1.Items.Add(item["HORA2"]);
                    listBox1.Items.Add(item["HORA3"]);
                    listBox1.Items.Add(item["HORA4"]);
                }                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void frmPonto_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        private async void btnGravar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza ?", "Gravar ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                btnGravar.Enabled = false;

                if(await clsPonto.GravarPontoAsync(DateTime.Now.ToString("yyyy-MM-dd"), clsVariaveis.usuDoc))
                {
                    CarregarLista();
                }

                btnGravar.Enabled = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (clsVariaveis.usuStatus)
            {
                case "USUARIO":
                    tabPage1.Show();
                    break;
            }

        }
    }
}
