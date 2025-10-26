using Microsoft.Data.Sqlite;
using TP7.Models;

namespace TP7.Repositorios
{
    public class ProductoRepository
    {
        private string connectionString = "Data Source=tienda.db;";

        public List<Producto> GetAll()
        {
            List<Producto> productos = new();

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var query = "SELECT idProducto, Descripcion, Precio FROM Productos";
            using var cmd = new SqliteCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    idProducto = reader.GetInt32(0),
                    descripcion = reader.GetString(1),
                    precio = reader.GetDouble(2)
                });
            }
            return productos;
        }

        public Producto? GetById(int id)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var query = "SELECT idProducto, Descripcion, Precio FROM Productos WHERE idProducto = @id";
            using var cmd = new SqliteCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Producto
                {
                    idProducto = reader.GetInt32(0),
                    descripcion = reader.GetString(1),
                    precio = reader.GetDouble(2)
                };
            }
            return null;
        }

        public void Crear(Producto prod)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var query = "INSERT INTO Productos (Descripcion, Precio) VALUES (@d, @p)";
            using var cmd = new SqliteCommand(query, connection);
            cmd.Parameters.AddWithValue("@d", prod.descripcion);
            cmd.Parameters.AddWithValue("@p", prod.precio);
            cmd.ExecuteNonQuery();
        }

        public bool Eliminar(int id)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var query = "DELETE FROM Productos WHERE idProducto=@id";
            using var cmd = new SqliteCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Modificar(int id, Producto prod)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var query = "UPDATE Productos SET Descripcion=@d, Precio=@p WHERE idProducto=@id";
            using var cmd = new SqliteCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@d", prod.descripcion);
            cmd.Parameters.AddWithValue("@p", prod.precio);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}