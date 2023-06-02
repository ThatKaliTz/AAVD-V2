using PIA___MAD.Pantallas_Admin;
using PIA___MAD.Pantallas_Operativo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA___MAD
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
        public int checkOut { get; set; }
        public int cantidadPersonas { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public Guid codigoReservacion { get; set; }
        public float anticipo { get; set; }
        public string servUtilizados { get; set; }
        public float costoServicio { get; set; }
        public string metodoPago { get; set; }

    }


    public static class FormManager
    {
        public static reservacionesHabitaciones reservHab { get; set; }
    }


}
