using PIA___AAVD.Pantallas_Admin;
using PIA___AAVD.Pantallas_Operativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA___AAVD
{
    public static class habID
    {
        public static string HotelID;
    }

    public static class reservID
    {
        public static string ClienteRFC;
        public static string HotelID;

    }


    public class datosCheckOut
    {
        public int hotelID { get; set; }
        public bool checkOut { get; set; }
        public int cantidadPersonas { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int codigoReservacion { get; set; }
        public float anticipo { get; set; }
        public string servUtilizados { get; set; }
        public float costoServicio { get; set; }
        public string metodoPago { get; set; }
        public int idhabitacion { get; set; }

    }


    public static class FormManager
    {
        public static reservacionesHabitaciones reservHab { get; set; }
    }


}
