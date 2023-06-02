using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA___MAD
{
    public class Clases
    {
        public class Usuario
        {        
            public string correoElec { get; set; }
            public string Nombre { get; set; }
            public string apPaterno { get; set; }
            public string apMaterno { get; set; }
            public string Contrasenia { get; set; }
            public string Domicilio { get; set; }
            public string Telefono { get; set; }
            public string FechaNacim { get; set; }
            public string numNomina { get; set; }
            public string fechaRegistro { get; set; }
            public string horaRegistro { get; set; }
            public bool isAdmin { get; set; }
            public bool isHabilitado { get; set; }
        }

        public class Cliente
        {
            public string RFC { get; set; }
            public string Nombre { get; set; }
            public string apellidoPaterno { get; set; }
            public string apellidoMaterno { get; set; }
            public string Domicilio { get; set; }
            public string correoCliente { get; set; }
            public string Referencia { get; set; }
            public string Telefono { get; set; }
            public string fechaNacim { get; set; }
            public string estadoCivil { get; set; }
            public string fechaGestion { get; set; }
            public string horaGestion { get; set; }
        }

        public class Hotel
        {
            public int idhotel { get; set; }
            public string nombre_hotel { get; set; }
            public string ubicacion { get; set; }
            public string domicilio { get; set; }
            public int numero_pisos { get; set; }
            public int cantodad_habitaciones { get; set; }
            public string paisHotel { get; set; }
            public string ciudadHotel { get; set; }
            public string estadoHotel { get; set; }
            public string calleHotel { get; set; }
            public string coloniaHotel { get; set; }
            public bool zonaTur { get; set; }
            public string serviciosAd { get; set; }
            public bool frentePlaya { get; set; }
            public int cantidadPiscinas { get; set; }
            public bool salonEvento { get; set; }
            public string fechaOperacion { get; set; }
            public string fechaRegistro { get; set; }
            public string horaRegistro { get; set; }
            public string idusuario { get; set; }
        }



        public class Habitacion
        {
            public int idHabitacion { get; set; }
            public string fechaRegistro { get; set; }
            public string horaRegistro { get; set; }
            public int idHotel_hab { get; set; }

            public int idTipo_hab { get; set; }


        }




        public class TipoHabitacion
        {
            public int idTipo { get; set; }
            public string nombreTipo { get; set; }
            public float precioNoche { get; set; }
            public int limitePersonas { get; set; }
            public int numeroCamas { get; set; }
            public string tiposCamas { get; set; }
            public string nivelHabitacion { get; set; }
            public bool amenidadPiscina { get; set; }
            public bool amenidadPlaya { get; set; }
            public bool amenidadJardin { get; set; }
            public string idUsuario { get; set; }
            public int idHotelTipoHab { get; set; }
        }


        public class Reserva
        {
            public int codigoReservacion { get; set; }
            public string fechaInicio { get; set; }
            public string fechaFin { get; set; }
            public string servUtilizados { get; set; }
            public float costoServicio { get; set; }
            public string metodoPago { get; set; }
            public float descuento { get; set; }
            public float anticipo { get; set; }
            public string numeroFactura { get; set; }
            public int cantidadPersonas { get; set; }
            public bool checkIn { get; set; }
            public bool checkOut { get; set; }
            public string usuarioReserva { get; set; }
            public string fechaReservacion { get; set; }
            public string horaReservacion { get; set; }
            public string idCliente { get; set; }
            public int idHabitacion { get; set; }


        }

        public class HabitacionCheckOut
        {
            public int IdHabitacion { get; set; }
            public string NombreTipo { get; set; }
            public int LimitePersonas { get; set; }
        }

        public class ResumenTipoHabitacion
        {
            public string TipoHabitacion { get; set; }
            public int Cantidad { get; set; }
            public int Disponibles { get; set; }
            public int Ocupadas { get; set; }
        }
    }
}
