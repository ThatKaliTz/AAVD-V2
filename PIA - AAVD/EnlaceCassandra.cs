using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;
using Cassandra.Mapping;
using System.Configuration;
using System.Windows.Forms;
using System.Web;
using PIA___MAD;
using static PIA___MAD.Clases;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using System.Globalization;

namespace PIA___AAVD
{
    public class EnlaceCassandra
    {
        static private string _dbServer { set; get; }
        static private string _dbKeySpace { set; get; }
        static private Cluster _cluster;
        static private ISession _session;

        private static void conectar()
        {
            _dbServer = ConfigurationManager.AppSettings["Cluster"].ToString();
            _dbKeySpace = ConfigurationManager.AppSettings["KeySpace"].ToString();

            _cluster = Cluster.Builder()
                .AddContactPoint(_dbServer)
                .Build();

            _session = _cluster.Connect(_dbKeySpace);
        }


        private static void desconectar()
        {
            _cluster.Dispose();
        }

        static private EnlaceCassandra instance;

        static public EnlaceCassandra getInstance()
        {
            if (instance == null)
                instance = new EnlaceCassandra();
            return instance;
        }

        //******************************************    *******************************************//

        #region GET


        public int ObtenerNumeroRegistros(string nombreTabla)
        {
            try
            {
                conectar();
                string query = $"SELECT COUNT(*) FROM {nombreTabla}";
                RowSet result = _session.Execute(query);
                Row row = result.FirstOrDefault();

                if (row != null && row.Count() > 0)
                {
                    var firstColumnValue = row.GetValue<object>(0);
                    int intValue = Convert.ToInt32(firstColumnValue);
                    intValue++;
                    return intValue;

                }
                return 0; // Si no se encontraron registros, devolver 0.
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar();
            }

        }
            public List<Clases.Usuario> GetUsuario()
        {
            string query = "SELECT correoelec, contrasenia, isadmin, ishabilitado ";
            query += "FROM usuario;"; // WHERE isHabilitado = TRUE dudoso de cambiarlo 
            conectar();

            IMapper mapper = new Mapper(_session);
            IEnumerable<Clases.Usuario> usuarios = mapper.Fetch<Clases.Usuario>(query);

            desconectar();
            return usuarios.ToList();
        }

        public List<Clases.Hotel> GetHoteles()
        {
            string query = "SELECT * ";
            query += "FROM hotel;";
            conectar();

            IMapper mapper = new Mapper(_session);
            IEnumerable<Clases.Hotel> hoteles = mapper.Fetch<Clases.Hotel>(query);

            desconectar();
            return hoteles.ToList();
        }


        #endregion


        #region USUARIOS
        public void insertOperativos(string correoElec, string Nombre, string apPaterno, string apMaterno, string Contrasenia, string Domicilio, string Telefono,
            string FechaNacim, int numNomina, string fechaRegistro, string horaRegistro, bool isAdmin, bool isHabilitado)
        {
            var Err = false;
            try
            {
                conectar();     
                string query = String.Format("INSERT INTO usuario(correoelec, nombre, appaterno, apmaterno, contrasenia, domicilio, telefono, fechanacim, numnomina, fecharegistro, horaregistro, isadmin, ishabilitado)\r\n ");
                query += String.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, '{9}', '{10}', {11}, {12}) IF NOT EXISTS",
                    correoElec, Nombre, apPaterno, apMaterno, Contrasenia, Domicilio, Telefono, FechaNacim, numNomina, fechaRegistro, horaRegistro, isAdmin, isHabilitado);

                _session.Execute(query);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Err = true;
                throw e;
            }
            finally
            {
                desconectar();
            }
        }
        #endregion


        #region HOTEL
        public void insertHoteles(int idHotel, string nombreHotel, int numeroPisos, int cantidadHabitaciones, string ciudadHotel,
            string estadoHotel, string calleHotel, string paisHotel, string coloniaHotel, bool zonaTur, string serviciosAd,
            bool frentePlaya, int cantidadPiscinas, bool salonEvento, string fechaOperacion, string fechaRegistro, string horaRegistro,
            string idusuario)
        {
            var Err = false;
            try
            {
                conectar();
                string query = String.Format("INSERT INTO hotel(idhotel, nombrehotel, numeropisos, cantidadhabitaciones, ciudadhotel, estadohotel, callehotel, " +
                    "paishotel, coloniahotel, zonatur, serviciosad, frenteplaya, " +
                    "cantidadpiscinas, salonevento, fechaoperacion, fecharegistro, horaregistro, idusuario)\r\n ");
                query += String.Format("VALUES ({0}, '{1}', {2}, {3}, '{4}', '{5}', '{6}', '{7}', '{8}', {9}, '{10}', {11}, {12}, {13}," +
                    " '{14}', '{15}', '{16}', '{17}') IF NOT EXISTS",
                    idHotel, nombreHotel, numeroPisos, cantidadHabitaciones, ciudadHotel, estadoHotel, calleHotel,
                    paisHotel, coloniaHotel, zonaTur, serviciosAd, frentePlaya,
                    cantidadPiscinas, salonEvento, fechaOperacion, fechaRegistro, horaRegistro, idusuario);

                _session.Execute(query);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Err = true;
                throw e;
            }
            finally
            {
                desconectar();
            }
        }
        #endregion


        #region TIPO-HABITACION

        public void insertarTipoHabitacion(int idTipo, string nombreTipo, float precioNoche, int limitePersonas,
    int numeroCamas, string tiposCamas, string nivelHabitacion, bool amenidadPiscina, bool amenidadPlaya,
    bool amenidadJardin, string idUsuario, int idHotelTipoHab)
        {
            var Err = false;
            try
            {
                conectar();
                string query = String.Format("INSERT INTO tipohabitacion (idtipo, nombretipo, precionoche, limitepersonas, numerocamas, tiposcamas, nivelhabitacion, amenidadpiscina, amenidadplaya, amenidadjardin, idusuario, idhoteltipohab)\r\n");
                query += String.Format("VALUES ({0}, '{1}', {2}, {3}, {4}, '{5}', '{6}', {7}, {8}, {9}, '{10}', {11})",
                    idTipo, nombreTipo, precioNoche, limitePersonas, numeroCamas, tiposCamas, nivelHabitacion,
                    amenidadPiscina, amenidadPlaya, amenidadJardin, idUsuario, idHotelTipoHab);

                _session.Execute(query);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Err = true;
                throw e;
            }
            finally
            {
                desconectar();
            }
        }


        public List<TipoHabitacion> ObtenerTiposHabitacion()
        {
            List<TipoHabitacion> tiposHabitacion = new List<TipoHabitacion>();

            try
            {
                conectar();
                string query = "SELECT * FROM tipohabitacion WHERE idhoteltipohab = " + Validaciones.ultimohotel.ToString() + " ALLOW FILTERING";
                RowSet result = _session.Execute(query);

                foreach (Row row in result)
                {
                    TipoHabitacion tipoHab = new TipoHabitacion
                    {
                        idTipo = row.GetValue<int>("idtipo"),
                        nombreTipo = row.GetValue<string>("nombretipo"),
                        precioNoche = row.GetValue<float>("precionoche"),
                        limitePersonas = row.GetValue<int>("limitepersonas"),
                        numeroCamas = row.GetValue<int>("numerocamas"),
                        tiposCamas = row.GetValue<string>("tiposcamas"),
                        nivelHabitacion = row.GetValue<string>("nivelhabitacion"),
                        amenidadPiscina = row.GetValue<bool>("amenidadpiscina"),
                        amenidadPlaya = row.GetValue<bool>("amenidadplaya"),
                        amenidadJardin = row.GetValue<bool>("amenidadjardin"),
                        idUsuario = row.GetValue<string>("idusuario"),
                        idHotelTipoHab = row.GetValue<int>("idhoteltipohab")
                    };

                    tiposHabitacion.Add(tipoHab);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar();
            }

            return tiposHabitacion;
        }

        #endregion


        #region HABITACION
        public void InsertarHabitacion(int idHabitacion, int idTipo_hab, int idHotel_hab)
        {
            DateTimeOffset fechaRegistro = DateTimeOffset.Now;

            try
            {
                conectar();
                string query = string.Format("INSERT INTO habitacion (idhabitacion, fecharegistro, horaregistro, idhotel_hab, idtipo_hab)\r\n");
                query += string.Format("VALUES ({0}, '{1}', '{2}', {3}, {4})",
                    idHabitacion, fechaRegistro.Date.ToString("yyyy-MM-dd"), fechaRegistro.TimeOfDay.ToString("hh\\:mm\\:ss"),
                    idHotel_hab, idTipo_hab);

                _session.Execute(query);

                string query2 = $"SELECT MAX(idhotel) FROM hotel;";
                Row filaResultado = _session.Execute(query2).FirstOrDefault();

                int ultimoId = filaResultado.GetValue<int>(0);

                    string query3 = $"UPDATE hotel SET cantidadhabitaciones = {Validaciones.cantidadDelHotel} WHERE idhotel = {ultimoId}";

                _session.Execute(query3);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar();
            }
        }
        #endregion


        #region reservaciones
        public DataTable filtrarReserva(string dato, string FiltroCliente)
        {

            DataTable dataTable = new DataTable();

            try
            {
                conectar();
                string query = "";

                if (FiltroCliente == "Apellidos")
                {
                     query = $"SELECT rfc, nombre, apellidopaterno, apellidomaterno, domicilio, correocliente FROM cliente WHERE apellidopaterno = '{dato}' ALLOW FILTERING";

                }
                else if (FiltroCliente == "RFC")
                {

                     query = $"SELECT rfc, nombre, apellidopaterno, apellidomaterno, domicilio, correocliente FROM cliente WHERE rfc = '{dato}' ALLOW FILTERING";

                }else if (FiltroCliente == "Correo")
                {

                     query = $"SELECT rfc, nombre, apellidopaterno, apellidomaterno, domicilio, correocliente FROM cliente WHERE correocliente = '{dato}' ALLOW FILTERING";
                }
                else
                {
                    return null;
                }

                RowSet result = _session.Execute(query);


                dataTable.Columns.Add("rfc");
                dataTable.Columns.Add("nombre");
                dataTable.Columns.Add("apellidopaterno");
                dataTable.Columns.Add("apellidomaterno");
                dataTable.Columns.Add("domicilio");
                dataTable.Columns.Add("correocliente");

                foreach (Row row in result)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["rfc"] = row.GetValue<string>("rfc");
                    dataRow["nombre"] = row.GetValue<string>("nombre");
                    dataRow["apellidopaterno"] = row.GetValue<string>("apellidopaterno");
                    dataRow["apellidomaterno"] = row.GetValue<string>("apellidomaterno");
                    dataRow["domicilio"] = row.GetValue<string>("domicilio");
                    dataRow["correocliente"] = row.GetValue<string>("correocliente");
                    dataTable.Rows.Add(dataRow);
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar();
            }

            return dataTable;
        }

        public DataTable filtrarHotel(string dato)
        {
            DataTable dataTable = new DataTable();
            try
            {
                conectar();

                string query = $"SELECT idhotel, nombrehotel, ciudadhotel FROM hotel WHERE ciudadhotel = '{dato}' ALLOW FILTERING ";
                RowSet result = _session.Execute(query);

                dataTable.Columns.Add("idhotel");
                dataTable.Columns.Add("nombrehotel");
                dataTable.Columns.Add("ciudadhotel");

                foreach (Row row in result)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["idhotel"] = row.GetValue<int>("idhotel");
                    dataRow["nombrehotel"] = row.GetValue<string>("nombrehotel");
                    dataRow["ciudadhotel"] = row.GetValue<string>("ciudadhotel");
                    dataTable.Rows.Add(dataRow);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;

            }
            finally
            {
                desconectar();
            }

            return dataTable;
        }
        #endregion


        #region reservacionesHabitacion

        public DataTable rObtenerHabitaciones(int idHotel, DateTime dateInicio,
            DateTime dateFin, int personasAHospedar)
        {
            DataTable dataTable = new DataTable();
            try
            {
                conectar();

                string query = $"SELECT idhabitacion FROM habitacion WHERE idhotel_hab = '{idHotel}' ALLOW FILTERING ";
                RowSet result = _session.Execute(query);

                dataTable.Columns.Add("idhotel");
                dataTable.Columns.Add("nombrehotel");
                dataTable.Columns.Add("ciudadhotel");

                foreach (Row row in result)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["idhotel"] = row.GetValue<int>("idhotel");
                    dataRow["nombrehotel"] = row.GetValue<string>("nombrehotel");
                    dataRow["ciudadhotel"] = row.GetValue<string>("ciudadhotel");
                    dataTable.Rows.Add(dataRow);

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;

            }
            finally
            {
                desconectar();
            }

            return dataTable;
        }
        #endregion







        private List<Clases.Reserva> MapReservas(RowSet result, int idHotel, int idHabitacion)
        {
            List<Clases.Reserva> reservas = new List<Clases.Reserva>();

            foreach (Row row in result)
            {
                int codigoReservacion = row.GetValue<int>("codigoreservacion");
                string fechaInicio = row.GetValue<string>("fechainicio");
                string fechaFin = row.GetValue<string>("fechafin");
                string servUtilizados = row.GetValue<string>("servutilizados");
                float costoServicio = row.GetValue<float>("costoservicio");
                string metodoPago = row.GetValue<string>("metodopago");
                float descuento = row.GetValue<float>("descuento");
                float anticipo = row.GetValue<float>("anticipo");
                string numeroFactura = row.GetValue<string>("numerofactura");
                int cantidadPersonas = row.GetValue<int>("cantidadpersonas");
                bool checkIn = row.GetValue<bool>("checkin");
                bool checkOut = row.GetValue<bool>("checkout");
                string usuarioReserva = row.GetValue<string>("usuarioreserva");
                string fechaReservacion = row.GetValue<string>("fechareservacion");
                string horaReservacion = row.GetValue<string>("horareservacion");
                string idCliente = row.GetValue<string>("idcliente");

                Clases.Reserva reserva = new Clases.Reserva()
                {
                    codigoReservacion = codigoReservacion,
                    fechaInicio = fechaInicio,
                    fechaFin = fechaFin,
                    servUtilizados = servUtilizados,
                    costoServicio = costoServicio,
                    metodoPago = metodoPago,
                    descuento = descuento,
                    anticipo = anticipo,
                    numeroFactura = numeroFactura,
                    cantidadPersonas = cantidadPersonas,
                    checkIn = checkIn,
                    checkOut = checkOut,
                    usuarioReserva = usuarioReserva,
                    fechaReservacion = fechaReservacion,
                    horaReservacion = horaReservacion,
                    idCliente = idCliente,
                    idHabitacion = idHabitacion
                };

                reservas.Add(reserva);
            }

            return reservas;
        }


        public List<Clases.HabitacionCheckOut> ObtenerHabitacionesCheckOut(int idHotel, DateTime fechaInicio, DateTime fechaFin, int cantidadPersonas)
        {
            List<Clases.HabitacionCheckOut> habitaciones = new List<Clases.HabitacionCheckOut>();

            try
            {
                conectar();

                // Consulta para obtener las habitaciones disponibles según el idHotel
                string query = $@"SELECT Habitacion.idHabitacion, tipoHabitacion.nombreTipo, tipoHabitacion.limitePersonas
                                  FROM Habitacion
                                  WHERE Habitacion.idHotel = {idHotel}
                                  ALLOW FILTERING;";

                RowSet result = _session.Execute(query);


                foreach (Row row in result)
                {
                    int idHabitacion = row.GetValue<int>("idhabitacion");
                    string nombreTipo = row.GetValue<string>("nombretipo");
                    int limitePersonas = row.GetValue<int>("limitepersonas");

                    // Validar si la habitación está reservada en el intervalo de fechas proporcionado
                    bool habitacionReservada = false;
                    // Aqui va el queryReserva
                    string queryReserva = $@"SELECT *
                             FROM Reserva
                             WHERE idHotel = {idHotel} AND idHabitacion = {idHabitacion}";

                    RowSet resultReserva = _session.Execute(queryReserva);
                    List<Clases.Reserva> reservas = MapReservas(resultReserva, idHotel, idHabitacion);


                    foreach (Reserva reserva in reservas)
                    {
                        DateTime fechaInicioReserva = DateTime.ParseExact(reserva.fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        DateTime fechaFinReserva = DateTime.ParseExact(reserva.fechaFin, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        if (reserva.idHabitacion == idHabitacion &&
                            fechaInicio <= fechaFinReserva &&
                            fechaFin >= fechaInicioReserva)
                        {
                            habitacionReservada = true;
                            break;
                        }
                    }

                    if (habitacionReservada)
                        continue; // La habitación está reservada en el intervalo de fechas, se omite

                    // Verificar si la cantidad de personas es menor o igual al límite de la habitación
                    if (cantidadPersonas <= limitePersonas)
                    {
                        Clases.HabitacionCheckOut habitacion = new Clases.HabitacionCheckOut()
                        {
                            IdHabitacion = idHabitacion,
                            NombreTipo = nombreTipo,
                            LimitePersonas = limitePersonas
                        };
                        habitaciones.Add(habitacion);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar();
            }

            return habitaciones;

        }





        #region CLIENTES
        public void insertClientes(string RFC, string Nombre, string apellidoPaterno, string apellidoMaterno, string Domicilio,
           string correoCliente, string Referencia, string Telefono, string fechaNacim, string estadoCivil, string fechaGestion, string horaGestion)
        {
            var Err = false;
            try
            {

                conectar();
                string query = String.Format("INSERT INTO cliente(rfc, nombre, apellidopaterno, apellidomaterno, domicilio, correocliente, referencia ,telefono, " +
                    "fechanacim, estadocivil, fechagestion, horagestion)\r\n ");
                query += String.Format("VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}') IF NOT EXISTS",
                    RFC, Nombre, apellidoPaterno, apellidoMaterno, Domicilio, correoCliente, Referencia,
                    Telefono, fechaNacim, estadoCivil, fechaGestion, horaGestion);

                _session.Execute(query);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Err = true;
                throw e;
            }
            finally
            {
                desconectar();
            }
        }

        #endregion

        //********************************************************************************************//



    }
}

    
