﻿
namespace Ponto.Classes
{
    class clsSP_Update
    {

        public static string ComandoUpdateUsuario(clsUsuario _usu)
        {
            string Comando = "EXEC SP_USU_UPDATE ";
            Comando += "'" + _usu.Usu_Id + "', ";
            Comando += "'" + _usu.Usu_Empr + "', ";
            Comando += "'" + _usu.Usu_Usu + "', ";
            Comando += "'" + _usu.Usu_Sts  + "'";

            return Comando;
        }

    }
}
