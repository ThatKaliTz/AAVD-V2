using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA___MAD
{

    public class HistorialCliente
    {

        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public string nombreHotel { get; set; }
        public string nombreTipo { get; set; }
        public int idHabitacion { get; set; }
        public Guid codigoReservacion { get; set; }
        public int cantidadPersonas { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public float anticipo { get; set; }
        public float descuento { get; set; }
        public float costoServicio { get; set; }
        public int checkOut { get; set; }
        public float montoTotal { get; set; }

    }

    public class HotelInfo
    {
        public int idHotel { get; set; }
        public string ciudadHotel { get; set; }
        public string nombreHotel { get; set; }
        public int anioRegistro { get; set; }
        public int mesRegistro { get; set; }
        public int cantidadPersonasHospedadas { get; set; }
        public int limitePersonas { get; set; }
        public double porcentajeOcupacion { get; set; }

    }
    public class ReporteVentas
    {
        public int Mes { get; set; }
        public float IngresosHospedaje { get; set; }
        public float IngresosServiciosAd { get; set; }
        public float IngresosTotales { get; set; }
    }

}
