﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Inventario_Avanzado
{
    public partial class FPrincipal : Form
    {
        public FPrincipal()
        {
            InitializeComponent();
            subButton1.BackColor = Color.White;
            sub2Button1.BackColor = Color.White;
            sub3Button1.BackColor = Color.White;
            AbrirFOrmulario<FHidden>();
            customizeDesign();
        }


        private void AbrirFOrmulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelFormulario.Controls.OfType<MiForm>().FirstOrDefault(); // Busca en la coleccion el formulario
            // Si el formulario no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormulario.Controls.Add(formulario);
                panelFormulario.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Form1"] == null)
            {
                subButton1.BackColor = Color.White;
            }
            if (Application.OpenForms["Form2"] == null)
            {

                sub2Button1.BackColor = Color.White;
            }
            if (Application.OpenForms["Form3"] == null)
            {
                sub3Button1.BackColor = Color.White;
            }
        }

        private void LoadUserData()
        {
            lblUsuario.Text = UserCache.usuario;
            lblNombre.Text = UserCache.nombre;
            if (UserCache.tipo == 0)
            {
                lblTipo.Text = "Super Admin";
            }
            else if (UserCache.tipo == 1)
            {
                lblTipo.Text = "Administrador";
            }
            else
            {
                lblTipo.Text = "Empleado";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de Cerrar Sesion", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        #region Ocultamos los subBotones
        private void customizeDesign()
        {
            panelSubbutton1.Visible = false;
            panelSubbutton2.Visible = false;
            panelSubbutton3.Visible = false;
        }
        #endregion
        
        private void hideSubMenu()
        {
            if (panelSubbutton1.Visible == true)
                panelSubbutton1.Visible = false;
            if (panelSubbutton2.Visible == true)
                panelSubbutton2.Visible = false;
            if (panelSubbutton3.Visible == true)
                panelSubbutton3.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        #region a cada boton principal se le llama la funcion para mostrar los sub menus
        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubbutton1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubbutton2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubbutton3);
        }
        #endregion

        private void subButton1_Click(object sender, EventArgs e)
        {
            AbrirFOrmulario<Form1>();
            subButton1.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void sub2Button1_Click(object sender, EventArgs e)
        {
            AbrirFOrmulario<Form2>();
            sub2Button1.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void sub3Button1_Click(object sender, EventArgs e)
        {
            AbrirFOrmulario<Form3>();
            sub3Button1.BackColor = Color.FromArgb(12, 61, 92);
        }
    }

}
