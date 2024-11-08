using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TestDB
{
    public class MainViewModel
    {
        private const string connectionString = "Host=localhost;Port=5050;Username=POS_USER;Password=POS_PASSWORD;Database=POS_DB";
        private NpgsqlConnection connection;
        private NpgsqlCommand command;

        public MainViewModel()
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            command = connection.CreateCommand();
        }

        public List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            command.CommandText = "SELECT * FROM menu_items";
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Id = reader.GetInt32(0);
                menuItem.Name = reader.GetString(1);
                menuItem.SellPrice = reader.GetFloat(2);
                menuItem.CapitalPrice = reader.GetFloat(3);
                menuItem.CategoryId = reader.GetInt32(4);
                menuItem.CreatedAt = reader.GetDateTime(5);
                menuItem.UpdatedAt = reader.GetDateTime(6);
                menuItems.Add(menuItem);
            }
            reader.Close();
            return menuItems;
        }
    }
}
