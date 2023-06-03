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
using PIA___AAVD;
using static PIA___AAVD.Clases;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using System.Globalization;
using System.Collections;
using static PIA___AAVD.Conexion.CassandraConexion;

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

                string query = $"SELECT idhabitacion, idtipo_hab FROM habitacion WHERE idhotel_hab = {idHotel} ALLOW FILTERING ";
                RowSet result = _session.Execute(query);


                dataTable.Columns.Add("idhabitacion");


                foreach (Row row in result)
                {
                    DataRow dataRow = dataTable.        NewRow();
                    dataRow["idhabitacion"] = row.GetValue<int>("idhabitacion");
                     
                    //dataRow["nombrehotel"] = row.GetValue<string>("nombrehotel");
                    //dataRow["ciudadhotel"] = row.GetValue<string>("ciudadhotel");
                    dataTable.Rows.Add(dataRow);

                }


                string query2 = $"SELECT nombretipo, limitepersonas FROM tipohabitacion WHERE idhoteltipohab = {idHotel} ALLOW FILTERING ";
                RowSet result2 = _session.Execute(query2);

                dataTable.Columns.Add("nombretipo");
                dataTable.Columns.Add("limitepersonas");


                foreach (Row row in result2)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["nombretipo"] = row.GetValue<string>("nombretipo");
                    dataRow["limitepersonas"] = row.GetValue<int>("limitepersonas");

                    //dataRow["nombrehotel"] = row.GetValue<string>("nombrehotel");
                    //dataRow["ciudadhotel"] = row.GetValue<string>("ciudadhotel");
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
                LocalDate fechaInicioDT = row.GetValue<LocalDate>("fechainicio");
                string fechaInicio = fechaInicioDT.ToString();
                LocalDate fechaFinDT = row.GetValue<LocalDate>("fechafin");
                string fechaFin = fechaFinDT.ToString();

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


                if (idHotel == 0 && idHabitacion == 0)
                {
                     idHabitacion = row.GetValue<int>("idhabitacion");
                    //idHotel = row.GetValue<int>("idhotel");
                }
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


        public Tuple<string, int> ObtenerTipoHabitacion(int idTipoHabitacion)
        {
            try
            {
                //conectar();

                string query = $@"SELECT nombretipo, limitepersonas
                                  FROM tipohabitacion
                                  WHERE idtipo = {idTipoHabitacion} ALLOW FILTERING;";

                RowSet result = _session.Execute(query);

                Row row = result.FirstOrDefault();

                if (row != null)
                {
                    string nombreTipo = row.GetValue<string>("nombretipo");
                    int limitePersonas = row.GetValue<int>("limitepersonas");

                    return new Tuple<string, int>(nombreTipo, limitePersonas);
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                //desconectar();
            }
        }


        public List<Clases.HabitacionCheckOut> ObtenerHabitacionesCheckOut(int idHotel, DateTime fechaInicio, DateTime fechaFin, int cantidadPersonas)
        {
            List<Clases.HabitacionCheckOut> habitaciones = new List<Clases.HabitacionCheckOut>();
            string nombreTipo = "0";
            int limitePersonas = 0;
            try
            {
                conectar();

                // Consulta para obtener las habitaciones disponibles según el idHotel
                string queryHabitacion = $@"SELECT idhabitacion, idtipo_hab
                                  FROM habitacion
                                  WHERE idhotel_hab = {idHotel}
                                  ALLOW FILTERING;
                ";

                RowSet result = _session.Execute(queryHabitacion);


                foreach (Row row in result)
                {
                    int idHabitacion = row.GetValue<int>("idhabitacion");
                    int idTipoHabitacion = row.GetValue<int>("idtipo_hab");
                    // Esto va en tipoHabitacion
                    Tuple<string, int> tipoHabitacion = ObtenerTipoHabitacion(idTipoHabitacion);

                    if (tipoHabitacion != null)
                    {
                         nombreTipo = tipoHabitacion.Item1;
                         limitePersonas = tipoHabitacion.Item2;
                    }

                    // Validar si la habitacion está reservada en el intervalo de fechas proporcionado
                    bool habitacionReservada = false;
                    // Aqui va el queryReserva
                    string queryReserva = $@"SELECT *
                             FROM reserva
                             WHERE idhabitacion = {idHabitacion} ALLOW FILTERING";

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
                        continue; // La habitacion está reservada en el intervalo de fechas, se omite

                    // Verificar si la cantidad de personas es menor o igual al límite de la habitacion
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


        public void insertReserva(int codigoreservacion, string fechainicio, string fechafin,string servutilizados, float costoservicio, string metodopago,
            float descuento,  float anticipo, string numerofactura, int cantidadpersonas, bool checkin, bool checkout, int idhabitacion, string idcliente, string usuarioreserva)
        {
            var Err = false;
            try
            {
                conectar();
                string query = String.Format("INSERT INTO reserva (codigoreservacion, fechainicio, fechafin, servutilizados, costoservicio, metodopago, " +
                    "descuento, anticipo, numerofactura, cantidadpersonas, checkin, checkout, idhabitacion, idcliente, usuarioreserva)\r\n");
                query += String.Format("VALUES ({0}, '{1}', '{2}', '{3}', {4}, '{5}', {6}, {7}, '{8}', {9}, {10}, {11}, {12}, '{13}', '{14}')",
                    codigoreservacion, fechainicio, fechafin, servutilizados, costoservicio, metodopago, descuento,
                    anticipo, numerofactura, cantidadpersonas, checkin, checkout, idhabitacion, idcliente, usuarioreserva);

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


        // public DataTable checkin()
        //{
        //    DataTable dataTable = new DataTable();
        //    try
        //    {
        //        conectar();

        //        string query = $"SELECT fechar, apellidomaterno, nombre FROM cliente WHERE idhotel_hab = {idHotel} ALLOW FILTERING ";
        //        RowSet result = _session.Execute(query);


        //        dataTable.Columns.Add("idhabitacion");


        //        foreach (Row row in result)
        //        {
        //            DataRow dataRow = dataTable.NewRow();
        //            dataRow["idhabitacion"] = row.GetValue<int>("idhabitacion");

        //            //dataRow["nombrehotel"] = row.GetValue<string>("nombrehotel");
        //            //dataRow["ciudadhotel"] = row.GetValue<string>("ciudadhotel");
        //            dataTable.Rows.Add(dataRow);

        //        }


        //        string query2 = $"SELECT nombretipo, limitepersonas FROM tipohabitacion WHERE idhoteltipohab = {idHotel} ALLOW FILTERING ";
        //        RowSet result2 = _session.Execute(query2);

        //        dataTable.Columns.Add("nombretipo");
        //        dataTable.Columns.Add("limitepersonas");


        //        foreach (Row row in result2)
        //        {
        //            DataRow dataRow = dataTable.NewRow();
        //            dataRow["nombretipo"] = row.GetValue<string>("nombretipo");
        //            dataRow["limitepersonas"] = row.GetValue<int>("limitepersonas");

        //            //dataRow["nombrehotel"] = row.GetValue<string>("nombrehotel");
        //            //dataRow["ciudadhotel"] = row.GetValue<string>("ciudadhotel");
        //            dataTable.Rows.Add(dataRow);

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //        throw e;

        //    }
        //    finally
        //    {
        //        desconectar();
        //    }

        //    return dataTable;

        //}


        public void actualizarCheckIn()
        {
            var Err = false;



            try
            {
                DateTime actualDate = DateTime.Now.Date;
                conectar();
                string query = $"UPDATE reserva SET checkin = true WHERE '{actualDate}' >= fechainicio ALLOW FILTERING ";


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

        //        public List<Clases.Reserva> BuscarReservaPorCodigo(int codigoReservacion)
        //{
        //    List<Clases.Reserva> reservas = new List<Clases.Reserva>();

        //    try
        //    {
        //        conectar();

        //        // Consulta para buscar la reserva por su código
        //        string query = $@"SELECT *
        //                        FROM reserva
        //                        WHERE codigoreservacion = {codigoReservacion} AND checkout = false AND checkin = true ALLOW FILTERING";



        //        RowSet result = _session.Execute(query);

        //        // Mapear los resultados a objetos de tipo Reserva
        //        reservas = MapReservas(result, idHotel, idHabitacion);


        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //        throw e;
        //    }
        //    finally
        //    {
        //        desconectar();
        //    }

        //    return reservas;
        //}



        // Aca
        #region checkOut

        public float ObtenerTotalReserva(int codigoReservacion)
        {
            float monto = 0;
            float costoServicio = 0;
            float descuento = 0;
            float anticipo = 0;
            float total = 0;

            try
            {
                conectar(); // Establecer la conexión a tu base de datos Cassandra

                // Obtener la información de la reserva
                string queryReserva = $"SELECT fechainicio, fechafin, costoservicio, anticipo, descuento, idhabitacion FROM reserva WHERE codigoreservacion = {codigoReservacion};";
                RowSet resultReserva = _session.Execute(queryReserva);
                Row reservaRow = resultReserva.FirstOrDefault();
                if (reservaRow != null)
                {
                    LocalDate fechaInicio = reservaRow.GetValue<LocalDate>("fechainicio");
                    LocalDate fechaFin = reservaRow.GetValue<LocalDate>("fechafin");
                    costoServicio = reservaRow.GetValue<float>("costoservicio");
                    anticipo = reservaRow.GetValue<float>("anticipo");
                    descuento = reservaRow.GetValue<float>("descuento");
                    int idHabitacion = reservaRow.GetValue<int>("idhabitacion");

                    // Obtener el tipo de habitación
                    string queryHabitacion = $"SELECT idtipo_hab FROM habitacion WHERE idhabitacion = {idHabitacion};";
                    RowSet resultHabitacion = _session.Execute(queryHabitacion);
                    int idTipoHabitacion = resultHabitacion.FirstOrDefault()?.GetValue<int>("idtipo_hab") ?? 0;

                    // Obtener el precio por noche del tipo de habitación
                    string queryTipoHabitacion = $"SELECT precionoche FROM tipohabitacion WHERE idtipo = {idTipoHabitacion};";
                    RowSet resultTipoHabitacion = _session.Execute(queryTipoHabitacion);
                    float precioNoche = resultTipoHabitacion.FirstOrDefault()?.GetValue<float>("precionoche") ?? 0;


                    DateTime fechaInicioDT = new DateTime(fechaInicio.Year, fechaInicio.Month, fechaInicio.Day);
                    DateTime fechaFinDT = new DateTime(fechaFin.Year, fechaFin.Month, fechaFin.Day);
                    // Calcular el monto de la reserva
                    int numeroNoches = (int)(fechaFinDT - fechaInicioDT).TotalDays;
                    monto = numeroNoches * precioNoche;
                }

                // Calcular el total
                total = monto + costoServicio - (descuento + anticipo);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar(); // Cerrar la conexión a la base de datos
            }

            return total;
        }



        public void PonerCheckOut(int codigoReservacion)
        {
            try
            {
                conectar();
                string query = $"update reserva set checkout = true where codigoreservacion = {codigoReservacion};";
                _session.Execute(query);
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

        public List<Clases.Reserva> BuscarReservaPorCodigo(int codigoReservacion)
        {
            List<Clases.Reserva> reservas = new List<Clases.Reserva>();

            try
            {
                conectar();

                // Consulta para buscar la reserva por su código
                string query = $@"SELECT *
                                FROM reserva
                                WHERE codigoreservacion = {codigoReservacion} AND checkout = false AND checkin = true ALLOW FILTERING";



                RowSet result = _session.Execute(query);

                // Mapear los resultados a objetos de tipo Reserva
                reservas = MapReservas(result, 0, 0);


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

            return reservas;
        }


        

        public void ActualizarReservaExtendida(int codigoReservacion, int nuevoIdHabitacion, DateTime fechaFin)
        {
            try
            {
                conectar();
                string query = $@"UPDATE reserva
                                  SET fechaFin = '{fechaFin.ToString("yyyy-MM-dd")}', idHabitacion = {nuevoIdHabitacion}
                                  WHERE codigoReservacion = {codigoReservacion};";
                _session.Execute(query);
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


        public void ActualizarReserva(int codigoReservacion, float anticipo, string servUtilizados, float costoServicio, string metodoPago)
        {
            try
            {
                conectar();
                string query = $@"UPDATE reserva
                                  SET anticipo = {anticipo}, servUtilizados = '{servUtilizados}', costoServicio = {costoServicio}, metodoPago = '{metodoPago}'
                                  WHERE codigoReservacion = {codigoReservacion};";
                _session.Execute(query);
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


        #region reporteOcupacion

        // Filtro

        public List<Clases.Hotel> GetHotelesCiudad(string ciudadHotel)
        {
            List<Clases.Hotel> hoteles = new List<Clases.Hotel>();

            try
            {
                conectar();
                string query = "SELECT * FROM hotel WHERE ciudadhotel = '" + ciudadHotel + "' ALLOW FILTERING;";
                RowSet result = _session.Execute(query);

                foreach (Row row in result)
                {
                    Clases.Hotel hotel = new Clases.Hotel();
                    hotel.idhotel = row.GetValue<int>("idhotel");
                    hotel.nombre_hotel = row.GetValue<string>("nombrehotel");
                    hotel.numero_pisos = row.GetValue<int>("numeropisos");
                    hotel.cantodad_habitaciones = row.GetValue<int>("cantidadhabitaciones");
                    hotel.paisHotel = row.GetValue<string>("paishotel");
                    hotel.ciudadHotel = row.GetValue<string>("ciudadhotel");
                    hotel.estadoHotel = row.GetValue<string>("estadohotel");
                    hotel.calleHotel = row.GetValue<string>("callehotel");
                    hotel.coloniaHotel = row.GetValue<string>("coloniahotel");
                    hotel.zonaTur = row.GetValue<bool>("zonatur");
                    hotel.serviciosAd = row.GetValue<string>("serviciosad");
                    hotel.frentePlaya = row.GetValue<bool>("frenteplaya");
                    hotel.cantidadPiscinas = row.GetValue<int>("cantidadpiscinas");
                    hotel.salonEvento = row.GetValue<bool>("salonevento");


                    LocalDate fechaOperacionDT = row.GetValue<LocalDate>("fechaoperacion");
                    hotel.fechaOperacion = fechaOperacionDT.ToString();

                    LocalDate fechaRegistroDT = row.GetValue<LocalDate>("fecharegistro");
                    hotel.fechaRegistro = fechaRegistroDT.ToString();     
                    
                    LocalTime horaRegistroDT = row.GetValue<LocalTime>("horaregistro");
                    hotel.horaRegistro = horaRegistroDT.ToString();


                    //hotel.fechaRegistro = row.GetValue<string>("fecharegistro");
                    //hotel.horaRegistro = row.GetValue<string>("horaregistro");
                    hotel.idusuario = row.GetValue<string>("idusuario");

                    hoteles.Add(hotel);
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

            return hoteles;
        }

        public List<Clases.Hotel> GetHotelesAnio(int anio)
        {
            List<Clases.Hotel> hoteles = new List<Clases.Hotel>();

            try
            {
                conectar();
                string query = "SELECT * FROM hotel";
                RowSet result = _session.Execute(query);

                foreach (Row row in result)
                {
                    int registroAnio = row.GetValue<LocalDate>("fecharegistro").Year;

                    if (registroAnio == anio)
                    {
                        Clases.Hotel hotel = new Clases.Hotel();
                        hotel.idhotel = row.GetValue<int>("idhotel");
                        hotel.nombre_hotel = row.GetValue<string>("nombrehotel");
                        hotel.numero_pisos = row.GetValue<int>("numeropisos");
                        hotel.cantodad_habitaciones = row.GetValue<int>("cantidadhabitaciones");
                        hotel.paisHotel = row.GetValue<string>("paishotel");
                        hotel.ciudadHotel = row.GetValue<string>("ciudadhotel");
                        hotel.estadoHotel = row.GetValue<string>("estadohotel");
                        hotel.calleHotel = row.GetValue<string>("callehotel");
                        hotel.coloniaHotel = row.GetValue<string>("coloniahotel");
                        hotel.zonaTur = row.GetValue<bool>("zonatur");
                        hotel.serviciosAd = row.GetValue<string>("serviciosad");
                        hotel.frentePlaya = row.GetValue<bool>("frenteplaya");
                        hotel.cantidadPiscinas = row.GetValue<int>("cantidadpiscinas");
                        hotel.salonEvento = row.GetValue<bool>("salonevento");
                        LocalDate fechaOperacionDT = row.GetValue<LocalDate>("fechaoperacion");
                        hotel.fechaOperacion = fechaOperacionDT.ToString();

                        LocalDate fechaRegistroDT = row.GetValue<LocalDate>("fecharegistro");
                        hotel.fechaRegistro = fechaRegistroDT.ToString();

                        LocalTime horaRegistroDT = row.GetValue<LocalTime>("horaregistro");
                        hotel.horaRegistro = horaRegistroDT.ToString();
                        hotel.idusuario = row.GetValue<string>("idusuario");

                        hoteles.Add(hotel);
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

            return hoteles;
        }

        public List<Clases.Hotel> GetHotelesPais(string pais)
        {
            List<Clases.Hotel> hoteles = new List<Clases.Hotel>();

            try
            {
                conectar();
                string query = "SELECT * FROM hotel WHERE paishotel = '" + pais + "' ALLOW FILTERING;";
                RowSet result = _session.Execute(query);

                foreach (Row row in result)
                {
                    Clases.Hotel hotel = new Clases.Hotel();
                    hotel.idhotel = row.GetValue<int>("idhotel");
                    hotel.nombre_hotel = row.GetValue<string>("nombrehotel");
                    hotel.numero_pisos = row.GetValue<int>("numeropisos");
                    hotel.cantodad_habitaciones = row.GetValue<int>("cantidadhabitaciones");
                    hotel.paisHotel = row.GetValue<string>("paishotel");
                    hotel.ciudadHotel = row.GetValue<string>("ciudadhotel");
                    hotel.estadoHotel = row.GetValue<string>("estadohotel");
                    hotel.calleHotel = row.GetValue<string>("callehotel");
                    hotel.coloniaHotel = row.GetValue<string>("coloniahotel");
                    hotel.zonaTur = row.GetValue<bool>("zonatur");
                    hotel.serviciosAd = row.GetValue<string>("serviciosad");
                    hotel.frentePlaya = row.GetValue<bool>("frenteplaya");
                    hotel.cantidadPiscinas = row.GetValue<int>("cantidadpiscinas");
                    hotel.salonEvento = row.GetValue<bool>("salonevento");
                    LocalDate fechaOperacionDT = row.GetValue<LocalDate>("fechaoperacion");
                    hotel.fechaOperacion = fechaOperacionDT.ToString();

                    LocalDate fechaRegistroDT = row.GetValue<LocalDate>("fecharegistro");
                    hotel.fechaRegistro = fechaRegistroDT.ToString();

                    LocalTime horaRegistroDT = row.GetValue<LocalTime>("horaregistro");
                    hotel.horaRegistro = horaRegistroDT.ToString();
                    hotel.idusuario = row.GetValue<string>("idusuario");
                    hoteles.Add(hotel);
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

            return hoteles;
        }

        public List<Clases.Hotel> GetHotelesNombre(string nombreHotel)
        {
            List<Clases.Hotel> hoteles = new List<Clases.Hotel>();

            try
            {
                conectar();
                string query = "SELECT * FROM hotel WHERE nombrehotel = '" + nombreHotel + "' ALLOW FILTERING;";
                RowSet result = _session.Execute(query);

                foreach (Row row in result)
                {
                    Clases.Hotel hotel = new Clases.Hotel();
                    hotel.idhotel = row.GetValue<int>("idhotel");
                    hotel.nombre_hotel = row.GetValue<string>("nombrehotel");
                    hotel.numero_pisos = row.GetValue<int>("numeropisos");
                    hotel.cantodad_habitaciones = row.GetValue<int>("cantidadhabitaciones");
                    hotel.paisHotel = row.GetValue<string>("paishotel");
                    hotel.ciudadHotel = row.GetValue<string>("ciudadhotel");
                    hotel.estadoHotel = row.GetValue<string>("estadohotel");
                    hotel.calleHotel = row.GetValue<string>("callehotel");
                    hotel.coloniaHotel = row.GetValue<string>("coloniahotel");
                    hotel.zonaTur = row.GetValue<bool>("zonatur");
                    hotel.serviciosAd = row.GetValue<string>("serviciosad");
                    hotel.frentePlaya = row.GetValue<bool>("frenteplaya");
                    hotel.cantidadPiscinas = row.GetValue<int>("cantidadpiscinas");
                    hotel.salonEvento = row.GetValue<bool>("salonevento");
                    LocalDate fechaOperacionDT = row.GetValue<LocalDate>("fechaoperacion");
                    hotel.fechaOperacion = fechaOperacionDT.ToString();

                    LocalDate fechaRegistroDT = row.GetValue<LocalDate>("fecharegistro");
                    hotel.fechaRegistro = fechaRegistroDT.ToString();

                    LocalTime horaRegistroDT = row.GetValue<LocalTime>("horaregistro");
                    hotel.horaRegistro = horaRegistroDT.ToString();
                    hotel.idusuario = row.GetValue<string>("idusuario");

                    hoteles.Add(hotel);
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

            return hoteles;
        }


        public int ObtenerLimitePersonasPorHotel(int idHotel)
        {
            int limitePersonasTotal = 0;

            try
            {
                conectar();

                string queryHabitacion = $@"SELECT idtipo_hab
                                            FROM habitacion
                                            WHERE idhotel_hab = {idHotel} ALLOW FILTERING;";

                RowSet resultHabitacion = _session.Execute(queryHabitacion);

                HashSet<int> idTiposHabitacion = new HashSet<int>();

                foreach (Row row in resultHabitacion)
                {
                    int idTipoHabitacion = row.GetValue<int>("idtipo_hab");
                    idTiposHabitacion.Add(idTipoHabitacion);
                }

                foreach (int idTipoHabitacion in idTiposHabitacion)
                {
                    string queryTipoHabitacion = $@"SELECT limitepersonas
                                                    FROM tipohabitacion
                                                    WHERE idtipo = {idTipoHabitacion} ALLOW FILTERING;";

                    RowSet resultTipoHabitacion = _session.Execute(queryTipoHabitacion);

                    foreach (Row row in resultTipoHabitacion)
                    {
                        int cantidadPersonas = row.GetValue<int>("limitepersonas");
                        limitePersonasTotal += cantidadPersonas;
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

            return limitePersonasTotal;
        }


        public int ObtenerCantidadPersonasReservadas(int idHotel)
        {
            int cantidadPersonasReservadas = 0;

            try
            {
                conectar(); // Establecer la conexión a tu base de datos Cassandra

                // Obtener los identificadores de habitacion relacionados con el idHotel
                string queryHabitacion = $"SELECT idhabitacion FROM habitacion WHERE idhotel_hab = {idHotel} ALLOW FILTERING;";
                IMapper mapper = new Mapper(_session);
                IEnumerable<int> idsHabitacion = mapper.Fetch<int>(queryHabitacion);

                // Obtener la suma de cantidadPersonas en la tabla Reserva utilizando los idsHabitacion
                foreach (int idHabitacion in idsHabitacion)
                {
                    string queryReserva = $"SELECT cantidadpersonas FROM reserva WHERE idhabitacion = {idHabitacion} AND checkout = false ALLOW FILTERING;";
                    int cantidadPersonas = mapper.SingleOrDefault<int>(queryReserva);
                    cantidadPersonasReservadas += cantidadPersonas;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar(); // Cerrar la conexión a la base de datos
            }

            return cantidadPersonasReservadas;
        }



        public List<ResumenTipoHabitacion> ObtenerResumenTipoHabitacion(int idHotel)
        {
            List<ResumenTipoHabitacion> resumenTipoHabitacion = new List<ResumenTipoHabitacion>();

            try
            {
                conectar();

                // Obtener los tipos de habitaciones del hotel
                string queryTiposHabitacion = $@"SELECT idtipo, nombretipo
                                        FROM tipohabitacion
                                        WHERE idhoteltipohab = {idHotel}  ALLOW FILTERING;";
                RowSet resultTiposHabitacion = _session.Execute(queryTiposHabitacion);

                foreach (Row rowTipoHabitacion in resultTiposHabitacion)
                {
                    // Crear un objeto ResumenTipoHabitacion para el tipo actual
                    ResumenTipoHabitacion resumen = new ResumenTipoHabitacion
                    {
                        TipoHabitacion = rowTipoHabitacion.GetValue<string>("nombretipo"),
                        Cantidad = 0,
                        Ocupadas = 0,
                        Disponibles = 0
                    };

                    int idTipo = rowTipoHabitacion.GetValue<int>("idtipo");

                    // Obtener la cantidad de habitaciones de este tipo en el hotel
                    string queryCantidad = $@"SELECT COUNT(*) AS cantidad
                                      FROM habitacion
                                      WHERE idtipo_hab = {idTipo}
                                      AND idhotel_hab = {idHotel} ALLOW FILTERING;";
                    RowSet resultCantidad = _session.Execute(queryCantidad);
                    resumen.Cantidad = (int)(resultCantidad.FirstOrDefault()?.GetValue<long>("cantidad") ?? 0);

                    // Obtener los idHabitacion de este tipo en el hotel
                    string queryIdHabitaciones = $@"SELECT idhabitacion
                                            FROM habitacion
                                            WHERE idtipo_hab = {idTipo}
                                            AND idhotel_hab = {idHotel} ALLOW FILTERING;";
                    RowSet resultIdHabitaciones = _session.Execute(queryIdHabitaciones);
                    List<int> idHabitaciones = resultIdHabitaciones.Select(row => row.GetValue<int>("idhabitacion")).ToList();

                    // Contar las habitaciones ocupadas
                    int ocupadas = 0;
                    foreach (int idHabitacion in idHabitaciones)
                    {
                        string queryReservas = $@"SELECT COUNT(*) AS reservas
                                          FROM reserva
                                          WHERE idhabitacion = {idHabitacion} ALLOW FILTERING;";
                        RowSet resultReservas = _session.Execute(queryReservas);
                        ocupadas += (int)(resultReservas.FirstOrDefault()?.GetValue<long>("reservas") ?? 0);
                    }

                    resumen.Ocupadas = ocupadas;

                    // Calcular la cantidad de habitaciones disponibles
                    resumen.Disponibles = resumen.Cantidad - resumen.Ocupadas;

                    // Agregar el resumen al resultado
                    resumenTipoHabitacion.Add(resumen);
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

            return resumenTipoHabitacion;
        }



        #endregion



        #region reporteVenta


        public List<int> ObtenerMesesPorHotel(int idHotel)
        {
            List<int> meses = new List<int>();

            try
            {
                conectar(); // Establecer la conexión a tu base de datos Cassandra

                string queryHabitacion = $@"SELECT idhabitacion
                                             FROM habitacion
                                             WHERE idhotel_hab = {idHotel}
                                             ALLOW FILTERING;";

                RowSet resultHabitacion = _session.Execute(queryHabitacion);

                HashSet<int> mesesSet = new HashSet<int>();

                foreach (Row rowHabitacion in resultHabitacion)
                {
                    int idHabitacion = rowHabitacion.GetValue<int>("idhabitacion");

                    string queryReserva = $@"SELECT fechainicio
                                             FROM reserva
                                             WHERE idhabitacion = {idHabitacion}  ALLOW FILTERING ;";

                    RowSet resultReserva = _session.Execute(queryReserva);

                    foreach (Row rowReserva in resultReserva)
                    {
                        LocalDate fechaInicio = rowReserva.GetValue<LocalDate>("fechainicio");
                        int numeroMes = fechaInicio.Month;
                        mesesSet.Add(numeroMes);
                    }
                }

                meses = new List<int>(mesesSet);
                meses.Sort(); // Ordenar los meses de forma ascendente
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

            return meses;
        }


        public float ObtenerPrecioNoche(int idHabitacion)
        {
            float precioNoche = 0;

            try
            {
                conectar();

                string queryHabitacion = $@"SELECT idtipo_hab
                                            FROM habitacion
                                            WHERE idhabitacion = {idHabitacion} ALLOW FILTERING;";

                Row resultHabitacion = _session.Execute(queryHabitacion).FirstOrDefault();

                if (resultHabitacion != null)
                {
                    int idTipoHabitacion = resultHabitacion.GetValue<int>("idtipo_hab");

                    string queryTipoHabitacion = $@"SELECT precionoche
                                                    FROM tipohabitacion
                                                    WHERE idtipo = {idTipoHabitacion} ALLOW FILTERING;";

                    Row resultTipoHabitacion = _session.Execute(queryTipoHabitacion).FirstOrDefault();

                    if (resultTipoHabitacion != null)
                    {
                        precioNoche = resultTipoHabitacion.GetValue<float>("precionoche");
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

            return precioNoche;
        }

        public int ObtenerIdHotelPorHabitacion(int idHabitacion)
        {
            int idHotel = 0;

            try
            {
                conectar(); // Establecer la conexión a tu base de datos Cassandra

                string query = $@"SELECT idhotel_hab FROM habitacion WHERE idhabitacion = {idHabitacion} ALLOW FILTERING";
                RowSet result = _session.Execute(query);
                Row row = result.FirstOrDefault();

                if (row != null)
                {
                    idHotel = row.GetValue<int>("idhotel_hab");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw e;
            }
            finally
            {
                desconectar(); // Cerrar la conexión a la base de datos
            }

            return idHotel;
        }


        public float CalcularIngresosPorReserva(int idHotel, int mes)
        {
            float total = 0;

            try
            {
                DateTime fechaInicio = new DateTime(DateTime.Now.Year, mes, 1);
                DateTime fechaFin = fechaInicio.AddMonths(1);

                conectar(); // Establecer la conexión a tu base de datos Cassandra

                string query = $@"SELECT fechainicio, fechafin, idhabitacion
                  FROM reserva ALLOW FILTERING;";

                RowSet result = _session.Execute(query);

                foreach (Row row in result)
                {
                    LocalDate reservaFechaInicio = row.GetValue<LocalDate>("fechainicio");
                    LocalDate reservaFechaFin = row.GetValue<LocalDate>("fechafin");

                    DateTime reservaFechaInicioDT = new DateTime(reservaFechaInicio.Year, reservaFechaInicio.Month, reservaFechaInicio.Day);
                    DateTime reservaFechaFinDT = new DateTime(reservaFechaFin.Year, reservaFechaFin.Month, reservaFechaFin.Day);
                    int idHabitacion = row.GetValue<int>("idhabitacion");

                    // Obtener el idHotel correspondiente a la habitacion
                    int idHotelHabitacion = ObtenerIdHotelPorHabitacion(idHabitacion); // Función para obtener el idHotel según el idHabitacion

                    // Validar que el idHotel de la habitacion coincida con el idHotel proporcionado y que la reserva esté dentro del mes indicado
                    if (idHotelHabitacion == idHotel && reservaFechaInicioDT >= fechaInicio && reservaFechaInicioDT < fechaFin)
                    {
                        float precioNoche = ObtenerPrecioNoche(idHabitacion); // Función para obtener el precio por noche según el idHabitacion

                        TimeSpan duracionEstancia = reservaFechaFinDT - reservaFechaInicioDT;
                        float costoEstancia = duracionEstancia.Days * precioNoche;

                        total += costoEstancia;
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
                desconectar(); // Cerrar la conexión a la base de datos
            }

            return total;
        }



        public float ObtenerSumaCostoServicio(int idHotel, int mes)
        {
            float total = 0;
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, mes, 1);
            DateTime fechaFin = fechaInicio.AddMonths(1);
            var Err = false;

            try
            {
                conectar(); // Establecer la conexión a tu base de datos Cassandra

                string queryHabitacion = $@"SELECT idhabitacion
                                        FROM habitacion
                                        WHERE idhotel_hab = {idHotel} ALLOW FILTERING;";
                RowSet resultHabitacion = _session.Execute(queryHabitacion);

                HashSet<int> idHabitaciones = new HashSet<int>();

                foreach (Row row in resultHabitacion)
                {
                    int idHabitacion = row.GetValue<int>("idhabitacion");
                    idHabitaciones.Add(idHabitacion);
                }

                foreach (int idHabitacion in idHabitaciones)
                {
                    string queryReserva = $@"SELECT costoservicio, fechainicio
                                        FROM reserva
                                        WHERE idhabitacion = {idHabitacion} ALLOW FILTERING;";
                    RowSet resultReserva = _session.Execute(queryReserva);

                    foreach (Row row in resultReserva)
                    {
                        LocalDate reservaFechaInicio = row.GetValue<LocalDate>("fechainicio");

                        DateTime reservaFechaInicioDT = new DateTime(reservaFechaInicio.Year, reservaFechaInicio.Month, reservaFechaInicio.Day);

                        if (reservaFechaInicioDT >= fechaInicio && reservaFechaInicioDT < fechaFin)
                        {
                            float costoServicio = row.GetValue<float>("costoservicio");
                            total += costoServicio;
                        }
                    }
                }
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

            return Convert.ToSingle(total);
        }



        #endregion

        // Aca

        public void ActualizarCheckin()
        {
            try
            {
                conectar();

                // 1. Seleccionar codigoreservacion, fechainicio, checkin de la tabla reserva
                string query = @"SELECT codigoreservacion, fechainicio, checkin FROM reserva  ALLOW FILTERING";
                RowSet result = _session.Execute(query);

                foreach (Row row in result)
                {
                    int codigoreservacion = row.GetValue<int>("codigoreservacion");
                    LocalDate fechainicioLD = row.GetValue<LocalDate>("fechainicio");
                    DateTime fechainicio = new DateTime(fechainicioLD.Year, fechainicioLD.Month, fechainicioLD.Day);

                    bool checkin = row.GetValue<bool>("checkin");

                    // 2. Verificar si el checkin es false y si la fechainicio es igual o menor que el dÃ­a actual
                    if (!checkin && fechainicio <= DateTime.Now.Date)
                    {
                        // 3. Actualizar el checkin a true en la tabla reserva
                        string updateQuery = $"UPDATE reserva SET checkin = true WHERE codigoreservacion = {codigoreservacion}";
                        _session.Execute(updateQuery);
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
        }





        public DataTable cObtenerReservas()
        {
            DataTable dataTable = new DataTable();

            try
            {
                conectar();
                string query = "SELECT codigoreservacion, usuarioreserva, idhabitacion  FROM reserva WHERE fechainicio > '2023-06-06' ALLOW FILTERING";
                RowSet result = _session.Execute(query);


                dataTable.Columns.Add("codigoreservacion");
                dataTable.Columns.Add("usuarioreserva");
                dataTable.Columns.Add("idhabitacion");


                foreach (Row row in result)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["codigoreservacion"] = row.GetValue<int>("codigoreservacion");
                    dataRow["usuarioreserva"] = row.GetValue<string>("usuarioreserva");
                    dataRow["idhabitacion"] = row.GetValue<int>("idhabitacion");
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

        public void rEliminarReservas(int codigo)
        {
            try
            {
                conectar();

                string query = $@"delete from reserva where codigoreservacion = {codigo}";

                _session.Execute(query);





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

    
