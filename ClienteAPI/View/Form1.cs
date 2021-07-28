using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClienteAPI.Controller;
using ClienteAPI.Model;

namespace ClienteAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Servicio REST Json");
            comboBox1.Items.Add("Servicio SOA Xml");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SolcititarServicio();
        }

        public void SolcititarServicio()
        {
            listBox1.Items.Clear();

            var Controlador = new PeliculaController();

            if (comboBox1.SelectedIndex == 0)
            {
                var Peliculas = Controlador.ListarPeliculasJSON();

                foreach (var Pelicula in Peliculas)
                {
                    listBox1.Items.Add(Pelicula.id);
                    listBox1.Items.Add(Pelicula.nombre);
                    listBox1.Items.Add(Pelicula.director);
                    listBox1.Items.Add(Pelicula.fecha);
                    listBox1.Items.Add("----------------------------");
                }

            }
            else if (comboBox1.SelectedIndex == 1)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnviarServicio();
        }

        public void EnviarServicio()
        {
            var Controlador = new PeliculaController();

            if (comboBox1.SelectedIndex == 0)
            {

                RespuestaModel Respuesta = new RespuestaModel();
                PeliculaModel Pelicula = new PeliculaModel();

                Pelicula.id = "0";
                Pelicula.nombre = txtNombre.Text;
                Pelicula.director = txtDirector.Text;
                Pelicula.fecha =Convert.ToDateTime(dtpFecha.Value.ToShortDateString());

                Respuesta = Controlador.GrabarPeliculaJSON(Pelicula);

                MessageBox.Show(Respuesta.Mensaje, "Mensaje");

            }
        }
    }
}
