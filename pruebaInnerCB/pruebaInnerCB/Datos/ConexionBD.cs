using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace pruebaInnerCB.Datos
{
    class ConexionBD
    {
        static private string Strconn = "Server =(LocalDB)\\MSSQLLocalDB; Database=testing; Integrated Security=true";
        private SqlConnection Conexion = new SqlConnection(Strconn);

        public SqlConnection AbrirConn()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
                return Conexion;
            


        }

        public SqlConnection CerrarConn()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
                return Conexion;
            


        }

    }
}
