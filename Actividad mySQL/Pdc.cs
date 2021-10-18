using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mysql
{
    class Pdc
    {
        public int _ID { get; set; }
        public string _Pnombre { get; set; }
        public int _Pprecio { get; set; }
        public string _Pmarca { get; set; }

        private Crud crud = new Crud();

        public MySqlDataReader getallcarpat()
        {
            string query = "SELECT ID,nombre,precio,marca FROM PDC";

            return crud.select(query);
        }

        public Boolean newEditcarpart(string action)
        {
            if (action == "new")
            {
                string query = "INSERT INTO PDC(nombre, precio, marca)" +
                    "VALUES ('"+ _Pnombre +"', '"+ _Pprecio +"', '"+ _Pmarca +"')";
                crud.executeQuery(query);
                return true;
            }
            else if (action == "edit")
            {
                string query = "UPDATE PDC SET "
                    + "nombre='"+ _Pnombre +"' ,"
                    + "precio='" + _Pprecio + "',"
                    + "marca='" + _Pmarca + "'"
                    + "WHERE "
                    + "ID= '"+ _ID +"'";
                crud.executeQuery(query);
                return true;
            }
            return false;
        }

        public Boolean deletecarpart()
        {
            string query = "DELETE FROM recetas WHERE ID='" + _ID + "'";
            crud.executeQuery(query);
            return true;
        }
    }
}
