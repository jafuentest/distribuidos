using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace streamServer
{
    public partial class Ventana : Form
    {
        #region Encabezado
        private string mensaje;
        Socket serverSocket;
        Thread hiloTCP;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Ventana()
        {
            InitializeComponent();
        }
        #endregion

        #region Controlador visual
        /// <summary>
        /// Controlador del listview
        /// </summary>
        public void Mensaje()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(Mensaje));
            else
                this.procesos.Items.Add(mensaje);
        }
        #endregion

        #region Servicio de audio (UDP)
        /// <summary>
        /// Envía las pistas de sonido para cada imagen
        /// </summary>
        public void enviarAudio(char id, IPAddress ip)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            byte[] audio = ReadFile("audio\\" + id + ".mp3");
            IPEndPoint ep = new IPEndPoint(ip, Int32.Parse(this.puertoUDP.Text));
            mensaje = "Enviando audio al cliente";
            this.Mensaje();

            socket.SendTo(audio, ep);
            //socket.Close();
        }
        #endregion

        #region Servicio de imágenes (TCP/IP)
        /// <summary>
        /// Metodo que manipula el servicio de escucha
        /// </summary>
        public void demonio()
        {
            string localIP = this.getIp();
            // 1. Creando el socket del servicio
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2. Rellenando los datos de red
            IPAddress IP = IPAddress.Any;//Parse(localIP);
            IPEndPoint IPE = new IPEndPoint(IP, Int32.Parse(this.puertoTCP.Text));

            // 3. Creando el servicio
            serverSocket.Bind(IPE);

            // 4. Inicio del monitoreo de peticiones
            mensaje = "Escuchando peticiones en la Red " + IP.ToString();
            this.Mensaje();
            serverSocket.Listen(2);

            // 5. Mantenimiento del servicio en escucha
            while (true)
            {
                Socket clientSocket;
                try
                {
                    clientSocket = serverSocket.Accept();
                    mensaje = "Aceptada solicitud del cliente";
                    this.Mensaje();
                }
                catch
                {
                    throw;
                }

                // Envia la imagen
                byte[] recibido = new byte[1000000];
                clientSocket.Receive(recibido, recibido.Length, SocketFlags.None);
                var msg = Encoding.Unicode.GetString(recibido);

                byte[] enviado = ReadFile("img\\" + msg[0] + ".jpg");
                mensaje = "Enviando imagen " + msg + " al cliente";
                this.Mensaje();
                clientSocket.Send(enviado, enviado.Length, SocketFlags.None);
                enviarAudio(msg[0], IPAddress.Parse(((IPEndPoint) clientSocket.RemoteEndPoint).Address.ToString()));
            }
        }

        /// <summary>
        /// Registra la red en la que esta conectado el servidor
        /// </summary>
        /// <returns>string con la direccion de Red</returns>
        public string getIp()
        {
            string localIP = "";
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        /// <summary>
        /// Transforma la imagen en un arreglo de bytes
        /// </summary>
        /// <param name="fileName">path de la imagen</param>
        /// <returns>imagen serializada en bytes</returns>
        private static byte[] ReadFile(String fileName)
        {
            FileInfo fileinfo = new FileInfo(fileName);
            byte[] buf = new byte[fileinfo.Length];
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            GC.ReRegisterForFinalize(fileinfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }
        #endregion

        #region Eventos de la ventana
        /// <summary>
        /// Evento para el inicio del servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inicio_Click(object sender, EventArgs e)
        {
            if (this.inicio.Text.Equals("Iniciar"))
            {
                if (Int32.Parse(this.puertoTCP.Text) >= 5000)
                {
                    this.puertoTCP.Enabled = false;
                    this.puertoUDP.Enabled = false;
                    this.inicio.Text = "Detener";
                    this.procesos.Items.Add("Iniciando...");
                    hiloTCP = new Thread(this.demonio);
                    hiloTCP.Start();
                }
                else
                    System.Windows.Forms.MessageBox.Show("El puerto no debe ser menor a 5000");
            }
            else
            {
                this.puertoTCP.Enabled = true;
                this.puertoUDP.Enabled = true;
                this.inicio.Text = "Iniciar";
                hiloTCP.Suspend();
                serverSocket.Close();
            }
        }
        #endregion
    }
}