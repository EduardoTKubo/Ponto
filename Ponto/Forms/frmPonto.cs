using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ponto.Classes;


namespace Ponto.Forms
{
    public partial class frmPonto : Form
    {
        clsUsuario Usuario = new clsUsuario();


        public frmPonto()
        {
            InitializeComponent();

            this.Text = Application.ProductName.ToString() + " ".PadLeft(120) + Application.ProductVersion;

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
            cboEmpresa.SelectedIndex = -1;
            cboFunc.Items.Clear();
            cboFunc.SelectedIndex = -1;
            dtgRel.DataSource = "";
            this.Refresh();
        }

        private void LimpaTabPage3()
        {
            lblId_C.Text = "";
            cboEmpresa.SelectedIndex = -1;
            txtCPF_C.Text = string.Empty;
            txtNome_C.Text = string.Empty;
            cboStatus_C.SelectedIndex = -1;
            dtgCad.DataSource = "";
            btnGravar_C.Text = "";
            btnExcluir_C.Enabled = false;
        }

        private async void PreencherTabPage3()
        {
            cboEmpresa_C.Items.Clear();
            clsVariaveis.GstrSQL = "select Descricao as Empresa from A_Tab_Geral where Titulo = 'EMPRESA' and Ativo = 1 order by Descricao";
            DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);
            foreach (DataRow item in dt.Rows)
            {
                cboEmpresa_C.Items.Add(item[0].ToString());
            }

            cboStatus_C.Items.Clear();
            cboStatus_C.Items.Add("ADMINISTRADOR");
            cboStatus_C.Items.Add("USUARIO");
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
                if (_empresa != "")
                {
                    clsVariaveis.GstrSQL = "select Usuario from vi_A_Cadastro where empresa = '" + _empresa
                                       + "' and data between '" + _dt1 + "' and '" + _dt2 +
                                       "' group by Usuario order by Usuario";
                    DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);
                    foreach (DataRow item in dt.Rows)
                    {
                        cboFunc.Items.Add(item[0].ToString());
                    }
                    if (dt.Rows.Count > 1)
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

        private async void PreencheTelaUsu( string _tipo ,string _cpf)
        {
            switch (_tipo)
            {
                case "ID":
                    clsVariaveis.GstrSQL = "select top 1 * from A_Usuario where ID = " + _cpf;
                    break;

                case "DOC":
                    clsVariaveis.GstrSQL = "select top 1 * from A_Usuario where CPF = '" + _cpf + "' and Ativo = 1";
                    break;
            }
            

            DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (cboEmpresa_C.Text != item["EMPRESA"].ToString())
                    {
                        cboEmpresa_C.Text = item["EMPRESA"].ToString();

                    }
                    if (txtCPF_C.Text != item["CPF"].ToString())
                    {
                        txtCPF_C.Text = item["CPF"].ToString();
                    }
                    txtNome_C.Text   = item["USUARIO"].ToString();
                    cboStatus_C.Text = item["STATUS"].ToString();
                    lblId_C.Text     = item["ID"].ToString();
                }
                btnGravar_C.Text = "Alterar";
                btnExcluir_C.Enabled = true;
            }
            else
            {
                //cboEmpresa_C.SelectedIndex = -1;
                txtNome_C.Text = "";
                cboStatus_C.SelectedIndex = -1;
                lblId_C.Text = "";
                btnGravar_C.Text = "Incluir";
                btnExcluir_C.Enabled = false;
            }
        }

        private async void PreencheGridCad(string _empresa)
        {
            dtgCad.DataSource = "";
            try
            {
                clsVariaveis.GstrSQL = "select ID ,Usuario from A_Usuario where Empresa = '" + _empresa + "' and Ativo = 1 order by Usuario";
                dtgCad.DataSource = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);

                dtgCad.Columns[1].Width = 220;

                foreach (DataGridViewColumn column in dtgCad.Columns)
                {
                    if (column.DataPropertyName == "ID")
                    {
                        column.Visible = false;
                    }
                    else
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Preenche Cad Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void PreencheGridHorarios(string _dt1, string _dt2, string _empresa, string _func)
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

                        dtTot.Merge(dtFunc);   // "add" dtFunc in dtTot
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

        private string VerificaInfoUsu()
        {
            string Resp = string.Empty;

            if (cboEmpresa_C.Text.Trim() == "") Resp += "Informar a Empresa" + System.Environment.NewLine;
            if (txtCPF_C.Text.Trim() == "") Resp += "Informar o CPF" + System.Environment.NewLine;
            if (txtNome_C.Text.Trim() == "") Resp += "Informar o Nome" + System.Environment.NewLine;
            if (cboStatus_C.Text.Trim() == "") Resp +="Informar o Status" + System.Environment.NewLine;

            return Resp;
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
                            LimpaTabPage3();
                            PreencherTabPage3();
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
            PreencheCboFunc(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"), cboEmpresa.Text);
        }

        private void cboFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencheGridHorarios(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"), cboEmpresa.Text, cboFunc.Text);
        }

        private void btnXls_Click(object sender, EventArgs e)
        {
            if (dtgRel.RowCount != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Tem certeza ?", "Exportar para o Excel", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    btnXls.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    bool booResp = clsPlanilha.ExportarXLS(dtgRel);

                    btnXls.Enabled = true;
                    this.Cursor = Cursors.Default;
                }
            }


            //if (dtgRel.RowCount != 0)
            //{
            //    // definindo nome da planilha
            //    string strCaminho = Application.StartupPath + @"\arquivo\" + DateTime.Now.ToString("yyyyMMdd_HHmm") + "_RelVisitas.xlsx";

            //    DataTable dt = new DataTable();

            //    // create columns
            //    foreach (DataGridViewColumn col in dtgRel.Columns)
            //    {
            //        if (col.ValueType == null)
            //        {
            //            dt.Columns.Add(col.Name, typeof(string));
            //        }
            //        else
            //        {
            //            dt.Columns.Add(col.Name, col.ValueType);
            //            dt.Columns[col.Name].Caption = col.HeaderText;
            //        }
            //    }
            //    // insert row data
            //    foreach (DataGridViewRow row in dtgRel.Rows)
            //    {
            //        DataRow drNewRow = dt.NewRow();
            //        foreach (DataColumn col in dt.Columns)
            //        {
            //            drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
            //        }
            //        dt.Rows.Add(drNewRow);
            //    }

            //    // cria a planilha
            //    if (await clsPlanilha.GeraSpireXLSAsync(dt, strCaminho))
            //    {
            //        // abre a planilha
            //        clsPlanilha.OpenXLS(strCaminho);
            //    }
            //}
        }

        private void txtCPF_C_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNome_C.Focus();
            }
        }

        private async void btnExcluir_C_Click(object sender, EventArgs e)
        {
            if (lblId_C.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o usuário ?", "Excluir / Usuário", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool booDel = await clsUsuario.ExcluirUsuario(lblId_C.Text);
                    if (booDel)
                    {
                        MessageBox.Show("Excluído com sucesso", "Excluir / Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string x = cboEmpresa_C.Text;
                        LimpaTabPage3();
                        cboEmpresa_C.Text = x;
                        PreencheGridCad(x);
                    }
                    else
                    {
                        MessageBox.Show(clsVariaveis.GstrResp, "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtCPF_C_Leave(object sender, EventArgs e)
        {
            if (txtCPF_C.Text != "")
            {
                string resp = clsFuncoes.ValidarDoc(this, txtCPF_C);
                if (resp == "")
                {
                    PreencheTelaUsu("DOC" ,txtCPF_C.Text);
                }
            }
        }

        private void cboEmpresa_C_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencheGridCad(cboEmpresa_C.Text);
        }

        private async void btnGravar_C_Click(object sender, EventArgs e)
        {
            if (btnGravar_C.Text == "") return;

            string x = VerificaInfoUsu();
            if (x != "")
            {
                MessageBox.Show(x, btnGravar_C.Text + "Usuário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            Usuario.Usu_Empr = cboEmpresa_C.Text;
            Usuario.Usu_CPF = txtCPF_C.Text;
            Usuario.Usu_Usu = txtNome_C.Text;
            Usuario.Usu_Sts = cboStatus_C.Text;
            Usuario.Usu_Id = lblId_C.Text;

            switch (btnGravar_C.Text)
            {
                case "Incluir":
                    DataTable dti = await clsBanco.ExecuteQueryRetornoAsync(clsSP_Insert.ComandoInsertUsuario(Usuario));

                    if (dti.Rows[0][0].ToString().Contains("SUCESSO"))
                    {
                        MessageBox.Show(dti.Rows[0][0].ToString());
                    }
                    else
                    {
                        MessageBox.Show(dti.Rows[0][0].ToString());
                        return;
                    }
                    break;

                case "Alterar":
                    DataTable dta = await clsBanco.ExecuteQueryRetornoAsync(clsSP_Update.ComandoUpdateUsuario(Usuario));

                    if (dta.Rows[0][0].ToString().Contains("SUCESSO"))
                    {
                        MessageBox.Show(dta.Rows[0][0].ToString());
                    }
                    else
                    {
                        MessageBox.Show(dta.Rows[0][0].ToString());
                        return;
                    }
                    break;
            }

            string y = cboEmpresa_C.Text;
            LimpaTabPage3();
            cboEmpresa_C.Text = y;
            PreencheGridCad(cboEmpresa_C.Text);
        }

        private void txtNome_C_Leave(object sender, EventArgs e)
        {
            if(txtNome_C.Text != "")
            {
                txtNome_C.Text = (txtNome_C.Text).ToUpper().Trim();
            }
        }

        private void dtgCad_DoubleClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dtgCad[0, dtgCad.CurrentRow.Index].Value);
            PreencheTelaUsu( "ID" ,ID.ToString());
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
    }
}



