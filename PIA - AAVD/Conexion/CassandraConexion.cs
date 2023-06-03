using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using Cassandra.Mapping.Attributes;

namespace PIA___AAVD.Conexion
{


    internal class CassandraConexion
    {

        public class Usuario
        {
            [Column("correoElec")]
            public string correoElec { get; set; }

            [Column("Contrasenia")]
            public string Contrasenia { get; set; }

            [Column("precio")]
            public decimal Precio { get; set; }
        }

            
        static void main()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1") // Reemplaza con tus puntos de contacto
                .Build();
            var session = cluster.Connect("tu_keyspace");

            var mapper = new Mapper(session);
            RowSet result = session.Execute("SELECT columna_int FROM tabla WHERE clave_primaria = 'valor_clave_primaria'");


            var nuevoProducto = new Usuario
            {
                correoElec = result.First().GetValue<string>("columna_int"),
                Contrasenia = "Nuevo Producto",
                Precio = 9.99m
            };
            mapper.Insert(nuevoProducto);

            var productoObtenido = mapper.FirstOrDefault<Usuario>("WHERE id = ?", nuevoProducto.correoElec);


            if (productoObtenido != null)
            {
                productoObtenido.correoElec = "Producto Actualizado";
                mapper.Update(productoObtenido);
            }

            // Eliminar un producto
            if (productoObtenido != null)
            {
                mapper.Delete(productoObtenido);
            }

            // Cerrar la sesión y el cluster
            session.Dispose();
            cluster.Dispose();


        }




    }
}
