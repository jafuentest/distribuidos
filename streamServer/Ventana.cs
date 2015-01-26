using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace streamServer
{
    public partial class Ventana : Form
    {
        #region Encabezado
        private string mensaje;
        Socket sListen;
        Thread hiloTCP;
        Thread hiloUDP;
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
        /// Envía las pistas de sonido para cada imágen
        /// </summary>
        public void enviarAudio(String id)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress broadcast = IPAddress.Parse("192.168.1.255");

            byte[] enviado = Encoding.ASCII.GetBytes("Some text"); //ReadFile("audio\\" + nombre[0] + ".jpg");
            mensaje = "Enviando audio al cliente";
            this.Mensaje();

            IPEndPoint ep = new IPEndPoint(broadcast, Int32.Parse(this.puertoUDP.Text));
            s.SendTo(enviado, ep);
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
            sListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // 2. Rellenando los datos de red
            IPAddress IP = IPAddress.Parse(localIP);
            IPEndPoint IPE = new IPEndPoint(IP, Int32.Parse(this.puertoTCP.Text));

            // 3. Creando el servicio
            sListen.Bind(IPE);

            // 4. Inicio del monitoreo de peticiones
            mensaje = "Escuchando peticiones en la Red " + localIP;
            this.Mensaje();
            sListen.Listen(2);

            // 5. Mantenimiento del servicio en escucha
            while (true)
            {
                Socket clientSocket;
                try
                {
                    clientSocket = sListen.Accept();
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
                if (Int32.Parse(this.puertoTCP.Text) >= 50000)
                {
                    this.puertoTCP.Enabled = false;
                    this.inicio.Text = "Detener";
                    this.procesos.Items.Add("Iniciando...");
                    hiloTCP = new Thread(this.demonio);
                    hiloTCP.Start();
                }
                else
                    System.Windows.Forms.MessageBox.Show("El puerto debe de no menor a 50000");
            }
            else
            {
                this.puertoTCP.Enabled = true;
                this.inicio.Text = "Iniciar";
                hiloTCP.Suspend();
                sListen.Close();
            }
        }
        #endregion
    }
}