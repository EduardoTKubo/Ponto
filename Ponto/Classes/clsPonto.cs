using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponto.Classes
{
    class clsPonto
    {
        private string pto_Id = string.Empty;
        public string Pto_Id
        {
            get { return pto_Id.TrimStart().TrimEnd(); }
            set { pto_Id = value.TrimStart().TrimEnd(); }
        }
        private string pto_Dta = string.Empty;
        public string Pto_Dta
        {
            get { return pto_Dta.TrimStart().TrimEnd(); }
            set { pto_Dta = value.TrimStart().TrimEnd(); }
        }
        private string pto_Usu = string.Empty;
        public string Pto_Usu
        {
            get { return pto_Usu.TrimStart().TrimEnd(); }
            set { pto_Usu = value.TrimStart().TrimEnd(); }
        }
        private string pto_Cpf = string.Empty;
        public string Pto_Cpf
        {
            get { return pto_Cpf.TrimStart().TrimEnd(); }
            set { pto_Cpf = value.TrimStart().TrimEnd(); }
        }
        private string pto_Hra1 = string.Empty;
        public string Pto_Hra1
        {
            get { return pto_Hra1.TrimStart().TrimEnd(); }
            set { pto_Hra1 = value.TrimStart().TrimEnd(); }
        }
        private string pto_Pc1 = string.Empty;
        public string Pto_Pc1
        {
            get { return pto_Pc1.TrimStart().TrimEnd(); }
            set { pto_Pc1 = value.TrimStart().TrimEnd(); }
        }
        private string pto_Hra2 = string.Empty;
        public string Pto_Hra2
        {
            get { return pto_Hra2.TrimStart().TrimEnd(); }
            set { pto_Hra2 = value.TrimStart().TrimEnd(); }
        }
        private string pto_Pc2 = string.Empty;
        public string Pto_Pc2
        {
            get { return pto_Pc2.TrimStart().TrimEnd(); }
            set { pto_Pc2 = value.TrimStart().TrimEnd(); }
        }
        private string pto_Hra3 = string.Empty;
        public string Pto_Hra3
        {
            get { return pto_Hra3.TrimStart().TrimEnd(); }
            set { pto_Hra3 = value.TrimStart().TrimEnd(); }
        }
        private string pto_Pc3 = string.Empty;
        public string Pto_Pc3
        {
            get { return pto_Pc3.TrimStart().TrimEnd(); }
            set { pto_Pc3 = value.TrimStart().TrimEnd(); }
        }
        private string pto_Hra4 = string.Empty;
        public string Pto_Hra4
        {
            get { return pto_Hra4.TrimStart().TrimEnd(); }
            set { pto_Hra4 = value.TrimStart().TrimEnd(); }
        }
        private string pto_Pc4 = string.Empty;
        public string Pto_Pc4
        {
            get { return pto_Pc4.TrimStart().TrimEnd(); }
            set { pto_Pc4 = value.TrimStart().TrimEnd(); }
        }



        public static async Task<bool> GravarPontoAsync(string _data, string _cpf)
        {
            try
            {
                clsVariaveis.GstrSQL = ("select * from A_Cadastro where Data = '@data' and CPF ='@cpf' ").Replace("@data", _data).Replace("@cpf", _cpf);

                DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);

                if (dt.Rows.Count == 0)
                {
                    clsVariaveis.GstrSQL = "insert into A_Cadastro (data ,cpf ,usuario ,hora1 ,nome_pc) values ('" +
                                           _data + "','" + _cpf + "','" + clsVariaveis.usuNome + "','" +
                                           DateTime.Now.ToString("HH:mm:ss") + "','" + clsVariaveis.usuNomePc + "')";

                    bool booResp = await clsBanco.ExecuteQueryAsync(clsVariaveis.GstrSQL);

                    return booResp;
                }
                else
                {
                    if(dt.Rows[0]["HORA2"].ToString() == "")
                    {
                        clsVariaveis.GstrSQL = "update A_Cadastro set hora2 = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,nome_pc2 = '" + clsVariaveis.usuNomePc + "' where ID = " + dt.Rows[0]["ID"].ToString();
                    }
                    else if(dt.Rows[0]["HORA3"].ToString() == "")
                    {
                        clsVariaveis.GstrSQL = "update A_Cadastro set hora3 = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,nome_pc3 = '" + clsVariaveis.usuNomePc + "' where ID = " + dt.Rows[0]["ID"].ToString();
                    }
                    else if(dt.Rows[0]["HORA4"].ToString() == "")
                    {
                        clsVariaveis.GstrSQL = "update A_Cadastro set hora4 = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,nome_pc4 = '" + clsVariaveis.usuNomePc + "' where ID = " + dt.Rows[0]["ID"].ToString();
                    }
                    else
                    {
                        clsVariaveis.GstrSQL = "update A_Cadastro set hora4 = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,nome_pc4 = '" + clsVariaveis.usuNomePc + "' where ID = " + dt.Rows[0]["ID"].ToString();
                    }

                    bool booResp = await clsBanco.ExecuteQueryAsync(clsVariaveis.GstrSQL);
                    return booResp;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gravar Ponto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }



    }
}
