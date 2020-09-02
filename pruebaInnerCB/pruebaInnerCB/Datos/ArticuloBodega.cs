using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace pruebaInnerCB.Datos
{
    class ArticuloBodega
    {
        private ConexionBD objcon = new ConexionBD();
        private SqlCommand objcom = new SqlCommand();
        private SqlDataReader Leer;


        public DataTable ListarProductos()
        {
            DataTable Tabla = new DataTable();
            objcom.Connection = objcon.AbrirConn();
            objcom.CommandText = "select * from Articulos";
            Leer = objcom.ExecuteReader();
            Tabla.Load(Leer);
            Leer.Close();
            objcon.CerrarConn();
            return Tabla;
        }

        
        public DataTable ListarBodegas()
        {
            DataTable Tabla = new DataTable();
            objcom.Connection = objcon.AbrirConn();
            objcom.CommandText = "select * from Bodegas";
            Leer = objcom.ExecuteReader();
            Tabla.Load(Leer);
            Leer.Close();
            objcon.CerrarConn();
            return Tabla;

        }

        public void insertarDatos(int idBodega, string Descripcion, int Precio, int Stock)
        {

            objcom.Connection = objcon.AbrirConn();
            objcom.CommandText = "insert into Articulos (idBodega,Descripcion, Precio, Stock) values ("+idBodega+", '"+Descripcion+"', "+Precio+", "+Stock+")";
      
            objcom.ExecuteNonQuery();
            objcon.CerrarConn();

        }




    }
}
