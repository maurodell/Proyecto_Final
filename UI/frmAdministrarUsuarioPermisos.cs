﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class frmAdministrarUsuarioPermisos : Form
    {
        public frmAdministrarUsuarioPermisos()
        {
            InitializeComponent();
            bllUsuario = new BLLUsuario();
            bllPermiso = new BLLPermiso();
            btnQuitar.Enabled = false;
        }
        BEUsuario beUsuario;
        BLLUsuario bllUsuario;
        BLLPermiso bllPermiso;
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Administración Permisos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Administración Permisos Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnConfigUser_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioSeleccionado = (BEUsuario)this.cmbUser.SelectedItem;
                beUsuario = new BEUsuario();
                beUsuario.Codigo = usuarioSeleccionado.Codigo;
                beUsuario.nombre = usuarioSeleccionado.nombre;
                btnQuitar.Enabled = true;
                ConfiguracionInicialTreeView(beUsuario);
            }
            catch (Exception)
            {

            }

        }
        private void ConfiguracionInicialTreeView(BEUsuario Usuario)
        {
            try
            {
                if (Usuario != null)
                {
                    bllPermiso.CompletarRolDeUsuario(Usuario);
                    MostrarPermisos2(Usuario);
                }
            }
            catch (Exception)
            {

            }

        }
        public void LlenarCmbRolFamilia()
        {
            try
            {
                this.cmbRol.DataSource = null;
                this.cmbRol.DataSource = bllPermiso.TraerTodosRolesFamilia();
            }
            catch (Exception)
            {

            }

        }
        public void LlenarCmbPermisos()
        {
            try
            {
                this.cmbPermisos.DataSource = null;
                this.cmbPermisos.DataSource = bllPermiso.TraerTodosPermisosConNombre();
            }
            catch (Exception)
            {

            }

        }
        private void ActualizarComboBoxUsuario()
        {
            this.cmbUser.DataSource = null;
            this.cmbUser.DataSource = bllUsuario.Listar();
            cmbUser.ValueMember = "codigo";
            cmbUser.DisplayMember = "nombre";
        }
        public void MostrarPermisos2(BEUsuario beUsuario)
        {
            try
            {
                if (beUsuario != null)
                { 
                    this.treeViewUserRol.Nodes.Clear();
                    TreeNode root = new TreeNode(beUsuario.nombre);
                    this.treeViewUserRol.Nodes.Add(root);
                    foreach (var item in beUsuario.Permisos)
                    {
                        MostrarTreeView(root, item);
                    }
                    treeViewUserRol.ExpandAll();
                }
            }
            catch (Exception)
            {

            }

        }
        public void MostrarTreeView(TreeNode tn, BEComponente componente)
        {
            try
            {
                TreeNode nodo = new TreeNode(componente._nombre);
                tn.Tag = componente;
                tn.Nodes.Add(nodo);
                if (componente.ObjenerHijos != null)
                {
                    foreach (var item in componente.ObjenerHijos)
                    {  //funcion recursiva
                        MostrarTreeView(nodo, item);
                    }
                }

            }
            catch (Exception)
            {

            }

        }
        private void frmAdministrarUsuarioPermisos_Load(object sender, EventArgs e)
        {
            ActualizarComboBoxUsuario();
            LlenarCmbRolFamilia();
            LlenarCmbPermisos();
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (beUsuario!=null)
                {
                    var permiso = (BEFamillia)cmbRol.SelectedItem;
                    bool existe = false;
                    existe = bllPermiso.ExisteRolEnUsuario2(beUsuario, permiso._codigo);
                    if (existe)
                    {
                        MessageBox.Show("El permiso ya fue asigando al usuario.");
                    }
                    else
                    {
                        bllPermiso.CompletarPermisos(permiso);
                        beUsuario.Permisos.Add(permiso);
                        MostrarPermisos2(beUsuario);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario!");
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllPermiso.GuardarPermisos(beUsuario))
                {
                    MessageBox.Show("Permisos guardados correctamente");
                    btnQuitar.Enabled = false;
                    treeViewUserRol.Nodes.Clear();
                }
                else
                {
                    MessageBox.Show("Algo salio mal, los permisos no se pudieron guardar " +
                                    "\n Contactar al provedor del sistema.");
                }
            }
            catch (Exception )
            {

            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeViewUserRol.SelectedNode != null)
                {
                    bool respuesta = false;
                    var nodoRol = treeViewUserRol.SelectedNode;

                    BEComponente rol = beUsuario.listaPermisos.Find(x => x._nombre.Equals(nodoRol.Text));

                    if (treeViewUserRol.SelectedNode != null)
                    {
                        if (nodoRol != null)
                        {
                            beUsuario.listaPermisos.Remove(rol);
                            respuesta = true;
                        }

                        if (respuesta)
                        {
                            MostrarPermisos2(beUsuario);
                            MensajeOk("Se quito de forma exitosa.");
                        }
                    }   
                    else
                    {
                        MensajeError("Debe seleccionar un usuario");
                    }
                }
                else
                {
                    MensajeError("Debe seleccionar un permisos o rol a quitar.");
                }

            }
            catch (Exception)
            {

            }


        }

        private void btnAsignarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                 if (beUsuario != null)
                {
                    var rol = (BEPermiso)cmbPermisos.SelectedItem;
                    bool existe = false;
                    existe = bllPermiso.ExistePermisosUsuario(beUsuario, rol._codigo);
                    if (existe)
                    {
                        MessageBox.Show("El permiso ya fue asigando al usuario.");
                    }
                    else
                    {
                        beUsuario.Permisos.Add(rol);
                        MostrarPermisos2(beUsuario);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario!");
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
