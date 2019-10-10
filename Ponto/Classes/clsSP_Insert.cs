using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ponto.Classes;

namespace Ponto.Classes
{
    class clsSP_Insert
    {

        public static string ComandoInsertUsuario(clsUsuario _Usu)
        {
            string Comando = "exec SP_USU_INSERT ";
            Comando += "'" + _Usu.Usu_Empr + "', ";
            Comando += "'" + _Usu.Usu_Usu + "', ";
            Comando += "'" + _Usu.Usu_CPF + "', ";
            Comando += "'" + _Usu.Usu_Sts + "'";

            return Comando;
        }

    }
}
