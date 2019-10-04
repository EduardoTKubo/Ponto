using System;


namespace Ponto.Classes
{
    class clsVariaveis
    {
        // db03
        private static readonly string conexao = @"Data Source=10.0.32.63;Initial Catalog=CAD_TRADE; User ID=sa; Password=SRV@admin2012;";
        public static string Conexao
        {
            get { return conexao; }
        }


        public static readonly string usuNomePc = Environment.MachineName;
        public static string UsuNomePc
        {
            get { return usuNomePc; }
        }

        public static string usuNome = string.Empty;
        public static string UsuNome
        {
            get { return usuNome; }
        }

        public static string usuEmpresa = string.Empty;
        public static string UsuEmpresa
        {
            get { return usuEmpresa; }
        }

        public static string usuDoc = string.Empty;
        public static string UsuDoc
        {
            get { return usuDoc; }
        }

        private static string gstrSQL = string.Empty;
        public static string GstrSQL
        {
            get { return gstrSQL; }
            set { gstrSQL = value; }
        }

        private static string gstrResp = string.Empty;
        public static string GstrResp
        {
            get { return gstrResp; }
            set { gstrResp = value; }
        }


    }
}
