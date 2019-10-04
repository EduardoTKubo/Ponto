using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ponto.Classes;
//using Ponto.Classes.Exceptions;


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

        private void LimpaTabPage2()
        {
            cboEmpresa.Items.Clear();
            cboEmpresa.Text = string.Empty;
            cboFunc.Items.Clear();
            cboFunc.Text = string.Empty;
            dtgRel.DataSource = "";
            this.Refresh();
        }

        private async void PreencheCboEmpresa(string _dt1, string _dt2)
        {
            LimpaTabPage2();

            try
            {
                int intA = Convert.ToInt32(clsFuncoes.RetornaNumero(_dt1));
                int intB = Convert.ToInt32(clsFuncoes.RetornaNumero(_dt2));

                if (intB < intA)
                {
                    MessageBox.Show("Período inválido", "Preenche Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    clsVariaveis.GstrSQL = "select Empresa from vi_A_Cadastro where data between '" + _dt1 +
                                   "' and '" + _dt2 + "' group by Empresa order by Empresa";
                    DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);
                    foreach (DataRow item in dt.Rows)
                    {
                        cboEmpresa.Items.Add(item[0].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Preenche Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void PreencheCboFunc(string _dt1, string _dt2, string _empresa)
        {
            cboFunc.Items.Clear();
            cboFunc.Text = string.Empty;
            dtgRel.DataSource = "";
            this.Refresh();

            try
            {
                if(_empresa != "")
                {
                    clsVariaveis.GstrSQL = "select Usuario from vi_A_Cadastro where empresa = '" + _empresa
                                       + "' and data between '" + _dt1 + "' and '" + _dt2 +
                                       "' group by Usuario order by Usuario";
                    DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);
                    foreach (DataRow item in dt.Rows)
                    {
                        cboFunc.Items.Add(item[0].ToString());
                    }
                    if(dt.Rows.Count > 1)
                    {
                        cboFunc.Items.Add("TODOS");
                    }
                    
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Preenche Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void PreencheGridHorarios(string _dt1, string _dt2, string _empresa ,string _func)
        {
            switch (_func)
            {
                case "TODOS":
                    DataTable dtTot = new DataTable();

                    clsVariaveis.GstrSQL = "select Usuario from vi_A_Cadastro where Empresa = '" + _empresa +
                        "' and data between '" + _dt1 + "' and '" + _dt2 + "' group by Usuario order by Usuario";
                    DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);

                    foreach (DataRow item in dt.Rows)
                    {
                        clsVariaveis.GstrSQL = "select Empresa ,Usuario ,Data ,Hora1 ,Hora2 ,Hora3 ,Hora4 ,Nome_pc ,Nome_pc2 ,Nome_pc3 ,Nome_pc4 from vi_A_Cadastro where Empresa = '" + _empresa +
                                "' and Usuario = '" + item["Usuario"] + "' and data between '" + _dt1 +
                                "' and '" + _dt2 + "' order by data";
                        DataTable dtFunc = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);

                        dtTot.Merge(dtFunc);
                    }

                    dtgRel.DataSource = dtTot;
             
                    break;

                default:
                    clsVariaveis.GstrSQL = "select Empresa ,Usuario ,Data ,Hora1 ,Hora2 ,Hora3 ,Hora4 ,Nome_pc ,Nome_pc2 ,Nome_pc3 ,Nome_pc4 from vi_A_Cadastro where Empresa = '" + _empresa +
                        "' and Usuario = '" + _func + "' and data between '" + _dt1 +
                        "' and '" + _dt2 + "' order by data";
                    dtgRel.DataSource = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);
                    break;
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

                if (await clsPonto.GravarPontoAsync(DateTime.Now.ToString("yyyy-MM-dd"), clsVariaveis.usuDoc))
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

                default:
                    switch (tabControl1.SelectedIndex)
                    {
                        case 0:
                            CarregarLista();
                            break;

                        case 1:
                            //dtPicker1.Value = DateTime.Today.Subtract(TimeSpan.FromDays(DateTime.Today.Day - 1));
                            //dtPicker2.Value = DateTime.Now;
                            PreencheCboEmpresa(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"));
                            break;

                        case 2:

                            break;
                    }
                    break;
            }

        }

        private void dtPicker1_ValueChanged(object sender, EventArgs e)
        {
            PreencheCboEmpresa(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"));
        }

        private void dtPicker2_ValueChanged(object sender, EventArgs e)
        {
            PreencheCboEmpresa(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"));
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencheCboFunc(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"),cboEmpresa.Text);
        }

        private void cboFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencheGridHorarios(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"), cboEmpresa.Text ,cboFunc.Text);
        }
    }
}
