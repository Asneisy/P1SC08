using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace P1SC08
{
    public class cnn
    {
        public static string db = @"Data Source =LAPTOP-S5GNS06I\SQLDEV; Initial Catalog =DBpractica04; Integrated Security =true;";
    }

    public class Item
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Item (string _name, int _value)
        {
            Name = _name; 
            Value = _value;
        }

        public override string ToString()
        {
            return Name;
        }

        public class Busco
        {
            public static string BuscaUltimoNumero(string nmId)
            {
                string sQuery = "SELECT SECUENCIA + 1 AS ULTIMO_NUMERO FROM SECUENCIA WHERE ID ='" + nmId + "'";

                SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
                SqlCommand cmd = new SqlCommand(sQuery, cnx);
                SqlDataReader _read = cmd.ExecuteReader();

                if (_read.Read())
                {
                    return _read["ULTIMO_NUMERO"].ToString();

                    cmd.Dispose();
                    cnx.Close();
                }

                return null;
            }
        }
    }

}
