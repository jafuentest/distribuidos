using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace streamClient
{
    public partial class Ventana : Form
    {
        #region encabezado de la clase
        /// <summary>
        /// Atributos de la ventana
        /// </summary>
        private string mensaje;
        private Socket s;
        private int delay;
        private int dibujo;
        private int i = 0;
        private Thread clienteH;
        private bool lleno;
        private List<string> mili = new List<string>();

        /// <summary>
        /// Constructor de la ventana
        /// </summary>
        public Ventana()
        {
            InitializeComponent();
            this.lento.Enabled = true;
            this.rapido.Enabled = true;
            this.normal.Enabled = false;
            this.delay = 1000;
            this.dibujo = 0;
            this.lleno = false;
        }
        #endregion

        #region manejo de componentes visuales
        /// <summary>
        /// Controla el listview para simular el buffer
        /// </summary>
        public void Mensaje()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(Mensaje));
            else
                this.buffer.Items.Add(mensaje);
        }

        /// <summary>
        /// Controla el pictureBox para la simulacion de "reproduccion de video"
        /// </summary>
        public void Pintar()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(Pintar));
            else
            {
                this.pantalla.Image = Image.FromFile(this.mili[this.dibujo] + this.dibujo.ToString() + ".jpg");
                this.dibujo++;
                if (this.dibujo == 10)
                    this.dibujo = 0;
            }
        }
        #endregion

        #region servicios de socket
        /// <summary>
        /// Toma el ip de la red en la que se encuentra conectada la maquina
        /// </summary>
        /// <returns>retorna la direccion de red</returns>
        private string getIp()
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
        /// Genera la coneccion con el servidor via TCP/IP
        /// </summary>
        private void cliente()
        {
            while (i < 10)
            {
                // 1. Crea el socket
                s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // 2. Llena los parametros de red
                IPAddress IP = IPAddress.Parse(this.TB_red.Text);
                IPEndPoint IPE = new IPEndPoint(IP, Int32.Parse(this.numeroPuerto.Text));
                mensaje = "Recibiendo servicios en la Red " + this.TB_red.Text;
                this.Mensaje();

                // 3. Conecta con el servidor
                s.Connect(IPE);
                byte[] secuencia = Encoding.UTF8.GetBytes(i.ToString());
                s.Send(secuencia, secuencia.Length, SocketFlags.None);

                // 4. Recibe y transforma los datos
                byte[] buffer = new byte[1000000];
                s.Receive(buffer, buffer.Length, SocketFlags.None);
                var msg = Encoding.Unicode.GetString(buffer);
                string date = System.DateTime.Now.ToShortTimeString();
                mensaje = "Paquete recibido" + date + " " + i.ToString() + ".jpg";
                this.Mensaje();
                this.mili.Insert(i, DateTime.UtcNow.Millisecond.ToString());
                FileStream fs = File.Create(this.mili[i] + i.ToString() + ".jpg");
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
                i++;
                Thread.Sleep(this.delay);
                Pintar();
            }
            this.lleno = true;
            this.continuar();
        }

        /// <summary>
        /// En caso de que el buffer este lleno este metodo continua con la reproduccion del video en pantalla
        /// </summary>
        private void continuar()
        { 
            while (true)
            {
                Thread.Sleep(this.delay);
                Pintar();
            }
        }

        /// <summary>
        /// Evento del boton inicio, da comienzo a la interaccion cliente servidor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inicio_Click(object sender, EventArgs e)
        {
            if (this.inicio.Text.Equals("Inicio"))
            {
                if (!this.lleno)
                {
                    this.numeroPuerto.Enabled = false;
                    this.TB_red.Enabled = false;
                    this.inicio.Text = "Detener";
                    mensaje = "Conectando con el servidor ...";
                    this.Mensaje();
                    clienteH = new Thread(this.cliente);
                    clienteH.Start();
                }
                else
                {
                    this.numeroPuerto.Enabled = false;
                    this.TB_red.Enabled = false;
                    this.inicio.Text = "Detener";
                    clienteH.Resume();
                }
            }
            else
            {
                this.numeroPuerto.Enabled = true;
                this.TB_red.Enabled = true;
                this.inicio.Text = "Inicio";
                s.Close();
                mensaje = "Coneccion con el servidor cerrada ...";
                this.Mensaje();
                clienteH.Suspend();
            }
        }
        #endregion
        #region eventos de velocidad
        private void normal_Click(object sender, EventArgs e)
        {
            this.velocidades(2);
        }

        private void rapido_Click(object sender, EventArgs e)
        {
            this.velocidades(3);
        }

        private void lento_Click(object sender, EventArgs e)
        {
            this.velocidades(1);
        }

        /// <summary>
        /// Este metodo controla la velocidad de reproduccion
        /// </summary>
        /// <param name="parametro">tipo de velocidadn 1: lento 2: normal 3: rapido</param>
        private void velocidades(int parametro)
        {
            switch (parametro)
            {
                case 1:
                    this.lento.Enabled  = false;
                    this.normal.Enabled = true;
                    this.rapido.Enabled = true;
                    this.delay = 3000;
                    mensaje = "Velocidad de reproduccion 3 segundos";
                    this.Mensaje();
                    break;
                case 2:
                    this.lento.Enabled  = true;
                    this.normal.Enabled = false;
                    this.rapido.Enabled = true;
                    this.delay = 1000;
                    mensaje = "Velocidad de reproduccion 1 segundo";
                    this.Mensaje();
                    break;
                case 3:
                    this.lento.Enabled  = true;
                    this.normal.Enabled = true;
                    this.rapido.Enabled = false;
                    this.delay = 500;
                    mensaje = "Velocidad de reproduccion 0.5 segundos";
                    this.Mensaje();
                    break;
            }
        }
        #endregion
    }
}
