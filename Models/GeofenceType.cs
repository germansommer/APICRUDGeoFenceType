using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiCrudGFType.Connections;

namespace ApiCrudGFType.Models
{
    public class GeofenceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Colour { get; set; }
        public int EnterpriseId { get; set; }
        public string Active { get; set; }

        //Funcion GET
        public static List<GeofenceType> GetAll()
        {
            var result = new List<GeofenceType>();
            Connection conn = new Connection();
            var sql = "select id, name, colour, enterpriseid, active from geofencetype";
            var command = new SqlCommand(sql, conn.connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new GeofenceType
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Colour = reader.GetString(2),
                    EnterpriseId = reader.GetInt32(3),
                    Active = reader.GetString(4),
                });
            }
            reader.Close();
            return result;
        }

        //Funcion POST
        public static void PostGFT(int id, string name, string colour, int enterpriseid, string active)
        {
            if (GeofenceType.CheckExists(id) == false)
            {
                //Insert
                Connection conn = new Connection();
                var sql = $"insert into geofencetype values ({id}, '{name}', null, '{colour}', {enterpriseid}, '{active}')";
                var command = new SqlCommand(sql, conn.connection);
                var reader = command.ExecuteReader();
                reader.Close();
            }
        }

        public static void UpdateGFT(int id, string name, string colour, int enterpriseid, string active)
        {
            if (GeofenceType.CheckExists(id) == true)
            {
                Connection conn = new Connection();
                var sql = $"update geofencetype set name = '{name}', colour = '{colour}', enterpriseid = '{enterpriseid}', active = '{active}' where geofencetype.id = {id}";
                var command = new SqlCommand(sql, conn.connection);
                var reader = command.ExecuteReader();
                reader.Close();
            }
        }

        public static void DeleteGFT(int id)
        {
            if (GeofenceType.CheckExists(id) == true)
            {
                Connection conn = new Connection();
                var sql = $"delete from geofencetype where geofencetype.id = {id}";
                var command = new SqlCommand(sql, conn.connection);
                var reader = command.ExecuteReader();
                reader.Close();
            }
        }

        public static bool CheckExists(int id)
        {
            //Comprobar si la GeofenceType ingresada existe en la base de datos
            var Check = GeofenceType.GetAll();
            var geofencetype = new GeofenceType();
            geofencetype = null;
            foreach (GeofenceType g in Check)
            {
                if (id == g.Id)
                {
                    geofencetype = g;
                }
            }
            if (geofencetype != null)
            {
                return true;
            }
            return false;            
        }
    }     
}
