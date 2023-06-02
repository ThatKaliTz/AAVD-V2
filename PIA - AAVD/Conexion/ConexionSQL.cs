using PIA___MAD.Pantallas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___MAD;
using System.Data; //Agregar
using System.Data.SqlClient;
using static PIA___MAD.Clases;
using Cassandra;

namespace PIA___MAD.SQL_Conexion
{
    class ConexionSQL
    {
        // Rogelio
        //SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-HDV4NUF; Initial Catalog=PIA_MAD; Integrated Security=True");
        // Mich
        SqlConnection conexion = new SqlConnection("Data Source=.; Initial Catalog=PIA_MAD; Integrated Security=True");

        SqlDataReader respuesta;

        #region LogIn

        public bool Login(string _user, string _pass, int _rol)
        {

            try
            {

                //Abrimos la conexion
                conexion.Open();
                // Creamos el query para pasarlo al comando
                string query = "SELECT * FROM Usuario";

                // creamos una instancia de SQLCommand y le pasamos el query
                SqlCommand cmd = new SqlCommand(query, conexion);


                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                // Obtenemos el índice de las columnas
                int correoIndex = sqlDataReader.GetOrdinal("correoElec");
                int passIndex = sqlDataReader.GetOrdinal("Contrasenia");
                int rolIndex = sqlDataReader.GetOrdinal("isAdmin");
                int estatusIndex = sqlDataReader.GetOrdinal("isHabilitado");


                //"While no se acabe las columnas y filas"
                while (sqlDataReader.Read())
                {
                    //Obtenemos los registros de cada columna (el numero depende del orden en el que lo creaste en el sql)
                    string user = sqlDataReader.GetString(correoIndex); //0 = correo
                    string pass = sqlDataReader.IsDBNull(passIndex) ? null : sqlDataReader.GetString(passIndex);
                    int rol = sqlDataReader.GetInt32(rolIndex); // isAdmin?
                    int estado = sqlDataReader.GetInt32(estatusIndex);
                    
                    if(user == _user && pass == null && rol == _rol && estado == 1)
                    {
                        // Pedir nueva contra
                        LogIn.nuevaContra = true;
                        conexion.Close();
                        return true;
                    }
                    else if (user == _user && pass == _pass && rol == _rol && estado == 1)
                    {
                        MessageBox.Show("Usted entró con exito", "Correcto");
                        conexion.Close();

                        return true;
                    }
                    else
                    {
                        //MessageBox.Show("no pudo iniciar sesion -__-", "!!!");

                    }
                }

                //SqlCommand cons = new SqlCommand("prueba1", con);
                //cons.CommandType = CommandType.StoredProcedure;
                //cons.Parameters.AddWithValue("@nom", 123);

                //cons.ExecuteNonQuery();
                conexion.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false; // si no pongo esto no jala la funcion -_____-

        }

        public void Deshabilitar(string usuario, int estado)
        {
            try
            {
                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_InhabilitarUsuario", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                spCom.Parameters.AddWithValue("@correoElec", usuario);
                spCom.Parameters.AddWithValue("@isHabilitado", estado);
                spCom.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void Habilitar(string usuario)
        {
            try
            {
                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_HabilitarUsuario", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                spCom.Parameters.AddWithValue("@correoElec", usuario);
                spCom.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public void ActualizarContra(string usuario, string contrasenia)
        {
            try
            {
                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_ActualizarContra", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                spCom.Parameters.AddWithValue("@correoElec", usuario);
                spCom.Parameters.AddWithValue("@nuevaContrasenia", contrasenia);
                spCom.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public DataTable viewInhabilitados()
        {

            conexion.Open();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM vw_UsuariosInhabilitados", conexion);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            conexion.Close();

            return dt;



        }

        #endregion


        #region regUsuario


        public void registrarUsuario(
            string @correoElec,
            string @Nombre,
            string @apPaterno,
            string @apMaterno,
            string @Contrasenia,
            string @calle,
            string @colonia,
            string @ciudad,
            string @estado,
            string @Telefono,
            DateTime @FechaNacim,
            int @numNomina)
        {
            try
            {
                string @Domicilio = @calle + " " + @colonia + " " + @ciudad + " " + @estado;
                DateTime @FechaReg = DateTime.Now;
                TimeSpan @HoraReg = DateTime.Now.TimeOfDay;


                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_InsertUsuario", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                spCom.Parameters.AddWithValue("@correoElec", @correoElec);
                spCom.Parameters.AddWithValue("@Nombre", @Nombre);
                spCom.Parameters.AddWithValue("@apPaterno", @apPaterno);
                spCom.Parameters.AddWithValue("@apMaterno", @apMaterno);
                spCom.Parameters.AddWithValue("@Contrasenia", @Contrasenia);
                spCom.Parameters.AddWithValue("@Domicilio", @Domicilio);
                spCom.Parameters.AddWithValue("@Telefono", @Telefono);
                spCom.Parameters.AddWithValue("@FechaNacim", @FechaNacim);
                spCom.Parameters.AddWithValue("@numNomina", @numNomina);
                spCom.Parameters.AddWithValue("@fechaRegistro", @FechaReg);
                spCom.Parameters.AddWithValue("@horaRegistro", @HoraReg);
                spCom.Parameters.AddWithValue("@isAdmin", 0);
                spCom.Parameters.AddWithValue("@isHabilitado", 1);

                spCom.ExecuteNonQuery();

                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        #endregion


        #region regCliente


        public void registarCliente(
            string @RFC,
            string @Nombre,
            string @apellidoPaterno,
            string @apellidoMaterno,
            string @correoCliente,
            string @Referencia,
            string @estadoCivil,
            string @calle,
            string @colonia,
            string @ciudad,
            string @estado,
            int @Telefono,
            DateTime @FechaNacim)
        {
            try
            {
                string @Domicilio = @calle + " " + @colonia + " " + @ciudad + " " + @estado;
                //DateTime @FechaReg = DateTime.Now;
                //TimeSpan @HoraReg = DateTime.Now.TimeOfDay;


                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_insertarClientes", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                spCom.Parameters.AddWithValue("@RFC", @RFC);
                Validaciones.cliente = @RFC;
                spCom.Parameters.AddWithValue("@Nombre", @Nombre);
                spCom.Parameters.AddWithValue("@apellidoPaterno", @apellidoPaterno);
                spCom.Parameters.AddWithValue("@apellidoMaterno", @apellidoMaterno);
                spCom.Parameters.AddWithValue("@Domicilio", @Domicilio);
                spCom.Parameters.AddWithValue("@correoCliente", @correoCliente);
                spCom.Parameters.AddWithValue("@Referencia", @Referencia);
                spCom.Parameters.AddWithValue("@Telefono", @Telefono);
                spCom.Parameters.AddWithValue("@fechaNacim", @FechaNacim);
                spCom.Parameters.AddWithValue("@estadoCivil", @estadoCivil);

                spCom.ExecuteNonQuery();

                conexion.Close();

                gestion(Validaciones.usuario, @RFC);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        public void gestion(string @idUsuario, string @idCliente)
        {
            try
            {
                DateTime @fechaGestion = DateTime.Now;
                TimeSpan @horaGestion = DateTime.Now.TimeOfDay;


                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_gestionCliente", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                spCom.Parameters.AddWithValue("@idUsuario", @idUsuario);
                spCom.Parameters.AddWithValue("@idCliente", @idCliente);
                spCom.Parameters.AddWithValue("@fechaGestion", @fechaGestion);
                spCom.Parameters.AddWithValue("@horaGestion", @horaGestion);

                spCom.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region regHotel

        public void registrarHotel(string @nombreHotel, int @numeroPisos, string @ciudadHotel, string @estadoHotel,
            string @paisHotel, string @calleHotel, string @coloniaHotel, int @zonaTur, string @serviciosAd, int @frentePlaya, int @cantidadPiscinas,
            int @salonEvento, DateTime @fechaOperacion)
        {

            try
            {

                DateTime @FechaReg = DateTime.Now;
                TimeSpan @HoraReg = DateTime.Now.TimeOfDay;
                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_insertarHotel", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                //spCom.Parameters.AddWithValue("@idHotel", @idHotel);
                spCom.Parameters.AddWithValue("@nombreHotel", @nombreHotel);
                spCom.Parameters.AddWithValue("@numeroPisos", @numeroPisos);
                spCom.Parameters.AddWithValue("@ciudadHotel", @ciudadHotel);
                spCom.Parameters.AddWithValue("@estadoHotel", @estadoHotel);
                spCom.Parameters.AddWithValue("@paisHotel", @paisHotel);
                spCom.Parameters.AddWithValue("@calleHotel", @calleHotel);
                spCom.Parameters.AddWithValue("@coloniaHotel", @coloniaHotel);
                spCom.Parameters.AddWithValue("@zonaTur", @zonaTur);
                spCom.Parameters.AddWithValue("@serviciosAd", @serviciosAd);
                spCom.Parameters.AddWithValue("@frentePlaya", @frentePlaya);
                spCom.Parameters.AddWithValue("@cantidadPiscinas", @cantidadPiscinas);
                spCom.Parameters.AddWithValue("@salonEvento", @salonEvento);
                spCom.Parameters.AddWithValue("@fechaOperacion", @fechaOperacion);
                spCom.Parameters.AddWithValue("@idUsuario", Validaciones.usuario);
                spCom.Parameters.AddWithValue("@fechaRegistro", @FechaReg);
                spCom.Parameters.AddWithValue("@horaRegistro", @HoraReg);
                spCom.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion


        #region regTipoHab

        public void registrarTipoHabitacion(string @nombreTipo,
            float @precioNoche, int @limitePersonas, int @numeroCamas, string @tiposCamas,
            string @nivelHabitacion, int @amenidadPiscina, int @amenidadPlaya, int @amenidadJardin, string @idUsuario)
        {

            try
            {

                DateTime @FechaReg = DateTime.Now;
                TimeSpan @HoraReg = DateTime.Now.TimeOfDay;
                conexion.Open();
                SqlCommand spCom = new SqlCommand("sp_insertarTipoHabitacion", conexion);
                spCom.CommandType = CommandType.StoredProcedure;
                //spCom.Parameters.AddWithValue("@idHotel", @idHotel);
                //spCom.Parameters.AddWithValue("@idTipo", @idTipo);
                spCom.Parameters.AddWithValue("@nombreTipo", @nombreTipo);
                spCom.Parameters.AddWithValue("@precioNoche", @precioNoche);
                spCom.Parameters.AddWithValue("@limitePersonas", @limitePersonas);
                spCom.Parameters.AddWithValue("@numeroCamas", @numeroCamas);
                spCom.Parameters.AddWithValue("@tiposCamas", @tiposCamas);
                spCom.Parameters.AddWithValue("@nivelHabitacion", @nivelHabitacion);
                spCom.Parameters.AddWithValue("@amenidadPiscina", @amenidadPiscina);
                spCom.Parameters.AddWithValue("@amenidadPlaya", @amenidadPlaya);
                spCom.Parameters.AddWithValue("@amenidadJardin", @amenidadJardin);
                spCom.Parameters.AddWithValue("@idUsuario", @idUsuario);

                // Parámetro de salida
                SqlParameter idHotelTipoHabParam = new SqlParameter("@idHotelTipoHab", SqlDbType.Int);
                idHotelTipoHabParam.Direction = ParameterDirection.Output;
                spCom.Parameters.Add(idHotelTipoHabParam);
                spCom.ExecuteNonQuery();

                // Obtener el valor de la variable de salida
                int idHotelTipoHab = Convert.ToInt32(spCom.Parameters["@idHotelTipoHab"].Value);
                habID.HotelID = Convert.ToString(idHotelTipoHab);

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        #endregion


        #region regHabitacion

        public DataTable ObtenerTipoHabitacionPorHotel(int idHotel)
        {
            string functionName = "ObtenerTipoHabitacionPorHotel";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@idHotel)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@idHotel", idHotel);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;
        }

        public void InsertarHabitacion(int idTipoHabitacion)
        {
            DateTime fechaRegistro = DateTime.Now;
            TimeSpan horaRegistro = DateTime.Now.TimeOfDay;

            try
            {
                conexion.Open();

                SqlCommand spCom = new SqlCommand("InsertarHabitacion", conexion);
                spCom.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado
                spCom.Parameters.AddWithValue("@fechaRegistro", fechaRegistro);
                spCom.Parameters.AddWithValue("@horaRegistro", horaRegistro);
                spCom.Parameters.AddWithValue("@idTipo_hab", idTipoHabitacion);

                spCom.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        #endregion


        #region reservaciones

        // Cliente (primer dataGrid)
        public DataTable reservaApellido(string a)
        {

            string functionName = "FiltrarClientesPorApellidoPaterno";
            DataTable dataTable = new DataTable();

            try
            {

                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@apellidoPaterno)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@apellidoPaterno", a);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;


        }

        public DataTable FiltrarClientesPorRFC(string RFC)
        {
            string functionName = "FiltrarClientesPorRFC";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@RFC)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@RFC", RFC);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;

        }

        public DataTable FiltrarClientesPorCorreo(string correoCliente)
        {
            string functionName = "FiltrarClientesPorCorreo";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@correoCliente)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@correoCliente", correoCliente);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        // Hotel (segundo dataGrid)
        public DataTable FiltrarHotelesReservacion(string ciudad)
        {
            string functionName = "FiltrarHotelesReservacion";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@ciudad, @fechaActual)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@ciudad", ciudad);
                command.Parameters.AddWithValue("@fechaActual", DateTime.Now.Date);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }



        public DataTable FiltrarHotelesPorCiudad(string ciudad)
        {
            string functionName = "FiltrarHotelesPorCiudad";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@ciudad)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@ciudad", ciudad);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }


        #endregion


        #region reservHabitacion

        public DataTable rObtenerHabitacionesDisponibles(int idHotel, DateTime dateInicio,
            DateTime dateFin, int personasAHospedar)
        {
            string functionName = "rObtenerHabitacionesDisponibles";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@idHotel, @dateInicio, @dateFin, @personasAHospedar)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@idHotel", idHotel);
                command.Parameters.AddWithValue("@dateInicio", dateInicio);
                command.Parameters.AddWithValue("@dateFin", dateFin);
                command.Parameters.AddWithValue("@personasAHospedar", personasAHospedar);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }

        public Guid InsertarReserva(DateTime fechaInicio, DateTime fechaFin, string servUtilizados, float costoServicio,
         string metodoPago, float descuento, float anticipo, string numeroFactura, int cantidadPersonas, string usuarioReserva,
         DateTime fechaReservacion, TimeSpan horaReservacion, string idClientefk, int idHabitacionfk)
        {
            Guid codigoReservacion = Guid.Empty;

            try
            {

                conexion.Open();
                SqlCommand command = new SqlCommand("InsertarReserva", conexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);
                command.Parameters.AddWithValue("@servUtilizados", servUtilizados);
                command.Parameters.AddWithValue("@costoServicio", costoServicio);
                command.Parameters.AddWithValue("@metodoPago", metodoPago);
                command.Parameters.AddWithValue("@descuento", descuento);
                command.Parameters.AddWithValue("@anticipo", anticipo);
                command.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                command.Parameters.AddWithValue("@cantidadPersonas", cantidadPersonas);
                command.Parameters.AddWithValue("@usuarioReserva", usuarioReserva);
                command.Parameters.AddWithValue("@fechaReservacion", fechaReservacion);
                command.Parameters.AddWithValue("@horaReservacion", horaReservacion);
                command.Parameters.AddWithValue("@idClientefk", idClientefk);
                command.Parameters.AddWithValue("@idHabitacionfk", idHabitacionfk);

                SqlParameter codigoReservacionParam = new SqlParameter("@codigoReservacion", SqlDbType.UniqueIdentifier);
                codigoReservacionParam.Direction = ParameterDirection.Output;
                command.Parameters.Add(codigoReservacionParam);

                command.ExecuteNonQuery();
                codigoReservacion = (Guid)codigoReservacionParam.Value;
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return codigoReservacion;

        }

        #endregion


        #region checkIn

        public void ActualizarCheckIn()
        {
            DateTime actualDate = DateTime.Now.Date;

            try
            {
                // Abrir la conexión
                conexion.Open();

                // Crear el comando SQL
                SqlCommand command = new SqlCommand("ActualizarCheckIn", conexion);
                command.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro de entrada
                command.Parameters.AddWithValue("@actualDate", actualDate);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
            }

        }


        public DataTable ObtenerCheckIn(Guid codigoReservacion)
        {
            // Crear una nueva tabla para almacenar los resultados
            DataTable dataTable = new DataTable();
            string functionName = "ObtenerCheckIn";

            try
            {
                // Abrir la conexión
                conexion.Open();


                string query = $"SELECT * FROM dbo.{functionName}(@codigoReservacion)";
                SqlCommand command = new SqlCommand(query, conexion);

                // Agregar el parámetro de entrada
                command.Parameters.AddWithValue("@codigoReservacion", codigoReservacion);

                // Crear el adaptador de datos y llenar la tabla con los resultados
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                // Ejecutar el comando
                conexion.Close();

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
            }


            // Devolver la tabla con los resultados
            return dataTable;

        }


        #endregion


        #region checkOut

        public void ActualizarCheckOut()
        {
            DateTime actualDate = DateTime.Now.Date;

            try
            {
                // Abrir la conexión
                conexion.Open();

                // Crear el comando SQL
                SqlCommand command = new SqlCommand("ActualizarCheckOut", conexion);
                command.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro de entrada
                command.Parameters.AddWithValue("@actualDate", actualDate);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public DataTable ObtenerReservaCheckOut(Guid codigoReservacion)
        {
            // Crear una nueva tabla para almacenar los resultados
            DataTable dataTable = new DataTable();
            string functionName = "ObtenerReservaCheckOut";

            try
            {
                // Abrir la conexión
                conexion.Open();


                string query = $"SELECT * FROM dbo.{functionName}(@codigoReservacion)";
                SqlCommand command = new SqlCommand(query, conexion);

                // Agregar el parámetro de entrada
                command.Parameters.AddWithValue("@codigoReservacion", codigoReservacion);

                // Crear el adaptador de datos y llenar la tabla con los resultados
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                // Ejecutar el comando
                conexion.Close();

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
            }


            // Devolver la tabla con los resultados
            return dataTable;

        }


        public DataTable obtenerHabitacionesCheckOut(int idHotel, DateTime dateInicio,
            DateTime dateFin, int personasAHospedar, Guid codigoReservacion)
        {
            string functionName = "obtenerHabitacionesCheckOut";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@idHotel, @dateInicio, @dateFin, @personasAHospedar, @codigoReservacion)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@idHotel", idHotel);
                command.Parameters.AddWithValue("@dateInicio", dateInicio);
                command.Parameters.AddWithValue("@dateFin", dateFin);
                command.Parameters.AddWithValue("@personasAHospedar", personasAHospedar);
                command.Parameters.AddWithValue("@codigoReservacion", codigoReservacion);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;
        }


        public void ActualizarReservaExtendida(Guid codigoReservacion, int idHabitacionfk, DateTime fechaFin)
        {

            var Err = false;

            try
            {
                // Abrir la conexión
                conexion.Open();

                // Crear el comando SQL
                SqlCommand command = new SqlCommand("ActualizarReservaExtendida", conexion);
                command.CommandType = CommandType.StoredProcedure;

                // Parámetros
                command.Parameters.AddWithValue("@codigoReservacion", codigoReservacion);
                command.Parameters.AddWithValue("@idHabitacionfk", idHabitacionfk);
                command.Parameters.AddWithValue("@fechaFin", fechaFin);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
                Err = true;
            }

            if (!Err)
                MessageBox.Show("Su fecha se extendio", "Reserva completada", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


        public void ActualizarReserva(Guid codigoReservacion, float anticipo, string servUtilizados, float costoServicio, string metodoPago)
        {
            try
            {
                // Abrir la conexión
                conexion.Open();

                SqlCommand command = new SqlCommand("ActualizarReserva", conexion);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@codigoReservacion", codigoReservacion);
                command.Parameters.AddWithValue("@anticipo", anticipo);
                command.Parameters.AddWithValue("@servUtilizados", servUtilizados);
                command.Parameters.AddWithValue("@costoServicio", costoServicio);
                command.Parameters.AddWithValue("@metodoPago", metodoPago);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
            }

        }



        public decimal ObtenerTotalReserva(Guid codigoReservacion)
        {
            decimal total = 0.0m;
            try
            {
                // Abrir la conexión
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT dbo.ObtenerTotalReserva(@codigoReservacion)", conexion);
                command.Parameters.AddWithValue("@codigoReservacion", codigoReservacion);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            total = reader.GetDecimal(0);
                        }
                    }
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                Console.WriteLine("Error: " + ex.Message);
            }

            return total;
        }




        #endregion


        #region reporteVenta

        // Filtro busqueda hotel
        public DataTable FiltrarHotelesPorAnioRegistro (int anio)
        {

            string functionName = "FiltrarHotelesPorAnioRegistro";
            DataTable dataTable = new DataTable();

            try
            {

                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@anio)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@anio", anio);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;

        }

        public DataTable FiltrarHotelesPorPais(string pais)
        {
            string functionName = "FiltrarHotelesPorPais";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@pais)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@pais", pais);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }

        public DataTable FiltrarHotelesPorNombre(string nombreHotel)
        {
            string functionName = "FiltrarHotelesPorNombre";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@nombreHotel)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombreHotel", nombreHotel);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }

        // Segundo dataGrid

        public DataTable ObtenerMesesPorHotel(int idHotel)
        {

            string functionName = "ObtenerMesesPorHotel";
            DataTable dataTable = new DataTable();

            try
            {

                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@idHotel)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@idHotel", idHotel);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;


        }

        public float ObtenerSumaCostoServicio(int idHotel, int mes)
        {
            float totalCostoServicio = 0.0f;
            decimal total = 0.0m;

            try
            {

                // Abrir la conexión
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT dbo.sumaCostoServicio(@idHotel, @mes)", conexion);
                command.Parameters.AddWithValue("@idHotel", idHotel);
                command.Parameters.AddWithValue("@mes", mes);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            total = reader.GetDecimal(0);
                        }
                    }
                }

                conexion.Close();

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show("Error: " + ex.Message);
            }

            // Retornar el valor de totalCostoServicio
            totalCostoServicio = Convert.ToSingle(total);
            return totalCostoServicio;
            
        }

        public float CalcularIngresosPorReserva(int idHotel, int mes)
        {
            float totalCostoServicio = 0.0f;
            decimal total = 0.0m;

            try
            {

                // Abrir la conexión
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT dbo.CalcularIngresosPorReserva(@idHotel, @mes)", conexion);
                command.Parameters.AddWithValue("@idHotel", idHotel);
                command.Parameters.AddWithValue("@mes", mes);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            total = reader.GetDecimal(0);
                        }
                    }
                }

                conexion.Close();

            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show("Error: " + ex.Message);
            }

            // Retornar el valor de totalCostoServicio
            totalCostoServicio = Convert.ToSingle(total);
            return totalCostoServicio;

        }




        #endregion


        #region reporteOcupacion

        // Filtro busqueda hotel
        public DataTable ocupFiltrarHotelesPorAnioRegistro(int anio)
        {

            string functionName = "ocupFiltrarHotelesPorAnioRegistro";
            DataTable dataTable = new DataTable();

            try
            {

                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@anio)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@anio", anio);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;

        }

        public DataTable ocupFiltrarHotelesPorPais(string pais)
        {
            string functionName = "ocupFiltrarHotelesPorPais";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@pais)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@pais", pais);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }

        public DataTable ocupFiltrarHotelesPorNombre(string nombreHotel)
        {
            string functionName = "ocupFiltrarHotelesPorNombre";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@nombreHotel)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@nombreHotel", nombreHotel);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }

        public DataTable ocupFiltrarHotelesPorCiudad(string ciudad)
        {
            string functionName = "ocupFiltrarHotelesPorCiudad";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@ciudad)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@ciudad", ciudad);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }


        // Primer data
        public int ObtenerLimitePersonasPorHotel(int idHotel)
        {
            int limitePersonas = 0;

            try
            {
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT dbo.ObtenerLimitePersonasPorHotel(@idHotel)", conexion);
                // Agregar el parámetro de entrada
                command.Parameters.AddWithValue("@idHotel", idHotel);


                // Ejecutar la función y obtener el resultado
                var value = command.ExecuteScalar();

                if (value != DBNull.Value)
                {
                    limitePersonas = (int)value;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show("Error: " + ex.Message);
            }

            // Devolver el resultado
                return limitePersonas;
        }
  


        public int ObtenerCantidadPersonasReservadasPorHotel(int idHotel)
        {
            int cantidadPersonasReservadas = 0;

            try
            {
                // Abrir la conexión
                conexion.Open();
                SqlCommand command = new SqlCommand("SELECT dbo.ObtenerCantidadPersonasReservadasPorHotel(@idHotel)", conexion);
                // Agregar el parámetro de entrada
                command.Parameters.AddWithValue("@idHotel", idHotel);

                // Ejecutar la función y obtener el resultado
                var value = command.ExecuteScalar();

                if (value != DBNull.Value)
                {
                    cantidadPersonasReservadas = (int)value;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                MessageBox.Show("Error: " + ex.Message);
            }

            // Devolver el resultado
            return cantidadPersonasReservadas;
        }




        // Segundo data
        public DataTable ObtenerDispoOcupHabitaciones(int idHotel)
        {

            string functionName = "ObtenerDispoOcupHabitaciones";
            DataTable dataTable = new DataTable();

            try
            {

                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@idHotel)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@idHotel", idHotel);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;


        }



        #endregion


        #region historialCliente

        // Reservas anuales
        public DataTable ObtenerReservasPorAnio(int anio)
        {

            string functionName = "ObtenerReservasPorAnio";
            DataTable dataTable = new DataTable();

            try
            {

                conexion.Open();

                string query = $"SELECT * FROM dbo.{functionName}(@anio)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@anio", anio);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            return dataTable;

        }


        // Reservas por cliente
        public DataTable ObtenerReservasPorCliente(string apellidoPaterno)
        {
            string functionName = "ObtenerReservasPorCliente";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@apellidoPaterno)";
                SqlCommand command = new SqlCommand(query, conexion);
                command.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }

        #endregion


        #region Cancelaciones

        public void cEliminarReserva(Guid codigoReservacion)
        {
            try
            {
                // Abrir la conexión
                conexion.Open();

                // Crear el comando SQL
                SqlCommand command = new SqlCommand("cEliminarReserva", conexion);
                command.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro de entrada
                command.Parameters.AddWithValue("@codigoReservacion", codigoReservacion);

                // Ejecutar el comando
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public DataTable cObtenerReservas()
        {
            string functionName = "cObtenerReservas";
            DataTable dataTable = new DataTable();

            try
            {
                conexion.Open();
                string query = $"SELECT * FROM dbo.{functionName}(@fechaActual)";
                SqlCommand command = new SqlCommand(query, conexion);
                // Agregar el parámetro @fechaActual a la función
                command.Parameters.AddWithValue("@fechaActual", DateTime.Now.Date);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dataTable;

        }

        #endregion
    }
}

    
