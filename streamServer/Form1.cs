using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace streamServer
{
    public partial class Form1 : Form
    {
        #region encabezado de la clase
        string mensaje;
        int _puerto;
        Socket sListen;
        Thread hilo;
        /// <summary>
        /// constructor de la clase
        /// </summary>
        public Form1()
        {
            InitializeComponent();
           // servidor = new Servidor(this.procesos);
           // _puerto = Convert.ToInt32(this.puerto.Text);
        }
        #endregion
        #region controlador visual
        /// <summary>
        /// controlador del listview
        /// </summary>
        public void Mensaje()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(Mensaje));
            else
                this.procesos.Items.Add(mensaje);
        }
        #endregion
        #region seccion de control del servicio TCP/IP
        /// <summary>
        /// registra la red en la que esta conectado el servidor
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
        /// metodo que manipula el servicio de escucha
        /// </summary>
        public void demonio()
        {
            string localIP =  this.getIp();            
            // 1. creando el socket del servicio
            sListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 2. rellenando los datos de red
            IPAddress IP = IPAddress.Parse(localIP);
            IPEndPoint IPE = new IPEndPoint(IP, Int32.Parse( this.numeroPuerto.Text ));
            // 3. creando el servicio
            sListen.Bind(IPE);
            // 4. inicio del monitoreo de peticiones
            mensaje = "Escuchando peticiones ... en la Red " + localIP;
            this.Mensaje();
            sListen.Listen(2);
            // 5. mantenimiento del servicio en escucha
            while (true)
            {
                Socket clientSocket;
                try
                {
                    clientSocket = sListen.Accept();
                    mensaje = "Aceptada solicitud de cliente";
                    this.Mensaje();
                }
                catch
                {
                    throw;
                }
                // envia la imagen
                byte[] buffer2 = new byte[1000000];
                clientSocket.Receive(buffer2, buffer2.Length, SocketFlags.None);
                var msg = Encoding.Unicode.GetString(buffer2);
                byte[] buffer = ReadImageFile("img\\" + msg[0] + ".jpg");
                    mensaje = "Enviando imagen " + msg + " a cliente";
                    this.Mensaje();
                    clientSocket.Send(buffer, buffer.Length, SocketFlags.None);
            }
        }
        /// <summary>
        /// transforma la imagen en un arreglo de bytes
        /// </summary>
        /// <param name="img">path de la imagen</param>
        /// <returns>imagen serializada en bytes</returns>
        private static byte[] ReadImageFile(String img)
        {
            FileInfo fileinfo = new FileInfo(img);
            byte[] buf = new byte[fileinfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            GC.ReRegisterForFinalize(fileinfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }
        /// <summary>
        /// evento para el inicio del servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inicio_Click(object sender, EventArgs e)
        {
            if (this.inicio.Text.Equals("Iniciar"))
            {
                if (Int32.Parse(this.numeroPuerto.Text) >= 50000)
                {
                    this.numeroPuerto.Enabled = false;
                    this.inicio.Text = "Detener";
                    this.procesos.Items.Add("Iniciando...");
                    hilo = new Thread(this.demonio);
                    hilo.Start();
                }
                else
                    System.Windows.Forms.MessageBox.Show("El puerto debe de no menor a 50000");
            }
            else
            {
                this.numeroPuerto.Enabled = true;
                this.inicio.Text = "Iniciar";
                hilo.Suspend();
                sListen.Close();
            }
        }
        #endregion
    }
}