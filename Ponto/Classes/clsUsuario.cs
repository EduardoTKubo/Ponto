using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponto.Classes
{
    class clsUsuario
    {
        private string usu_Id = string.Empty;
        public string Usu_Id
        {
            get { return usu_Id.TrimStart().TrimEnd(); }
            set { usu_Id = value.TrimStart().TrimEnd(); }
        }
        private string usu_Empr = string.Empty;
        public string Usu_Empr
        {
            get { return usu_Empr.TrimStart().TrimEnd(); }
            set { usu_Empr = value.TrimStart().TrimEnd(); }
        }
        private string usu_Usu = string.Empty;
        public string Usu_Usu
        {
            get { return usu_Usu.TrimStart().TrimEnd(); }
            set { usu_Usu = value.TrimStart().TrimEnd(); }
        }
        private string usu_CPF = string.Empty;
        public string Usu_CPF
        {
            get { return usu_CPF.TrimStart().TrimEnd(); }
            set { usu_CPF = value.TrimStart().TrimEnd(); }
        }
        private string usu_Sts = string.Empty;
        public string Usu_Sts
        {
            get { return usu_Sts.TrimStart().TrimEnd(); }
            set { usu_Sts = value.TrimStart().TrimEnd(); }
        }
        private string usu_Atv = string.Empty;
        public string Usu_Atv
        {
            get { return usu_Atv.TrimStart().TrimEnd(); }
            set { usu_Atv = value.TrimStart().TrimEnd(); }
        }




        public static async Task<string> AcessoUsuarioAsync(string _cpf)
        {
            clsVariaveis.GstrSQL = ("select Empresa ,Usuario ,Status from A_Usuario where Ativo = 1 and CPF ='@cpf' ").Replace("@cpf", _cpf);

            DataTable dt = await Classes.clsBanco.ConsultaAsync(clsVariaveis.GstrSQL);

            if ( dt.Rows.Count > 0)
            {
                clsVariaveis.usuDoc = _cpf;
                clsVariaveis.usuNome = dt.Rows[0]["Usuario"].ToString();
                clsVariaveis.usuEmpresa = dt.Rows[0]["Empresa"].ToString();

                return dt.Rows[0]["Status"].ToString();
            }
            else
            {
                return "";
            }
        }



    }
}
