﻿using System;
using System.Windows.Forms;
using BLL;
using BE;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class frmProducto : Form
    {
        private string nombreAnterior;
        public frmProducto()
        {
            InitializeComponent();
            bllProducto = new BLLProducto();
            bllCategoria = new BLLCategoria();
        }
        BLLProducto bllProducto;
        BLLCategoria bllCategoria;
        BEProducto beProducto;
        private void Listar()
        {
            try
            {
                dgvListadoProd.DataSource = null;
                dgvListadoProd.DataSource = bllProducto.Listar();
                this.Formato();
                this.Limpiar();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoProd.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Buscar()
        {
            try
            {
                dgvListadoProd.DataSource = bllProducto.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotalReg.Text = "Total registros: " + Convert.ToString(dgvListadoProd.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Formato()
        {
            dgvListadoProd.Columns[0].Visible = false;
            dgvListadoProd.Columns[1].HeaderText = "Categoría";
            dgvListadoProd.Columns[1].Width = 50;
            dgvListadoProd.Columns[2].HeaderText = "Código Barra";
            dgvListadoProd.Columns[2].Width = 50;
            dgvListadoProd.Columns[3].Width = 100;
            dgvListadoProd.Columns[4].Width = 60;
            dgvListadoProd.Columns[4].HeaderText = "Precio Venta";
            dgvListadoProd.Columns[5].HeaderText = "Stock";
            dgvListadoProd.Columns[5].Width = 50;
            dgvListadoProd.Columns[6].Width = 150;
            dgvListadoProd.Columns[6].HeaderText = "Descripción";
            dgvListadoProd.Columns[7].Width = 50;
            dgvListadoProd.Columns[7].HeaderText = "Ubicación";
            dgvListadoProd.Columns[8].Width = 140;
            dgvListadoProd.Columns[8].HeaderText = "Fecha Vencimiento";
            dgvListadoProd.Columns[9].Width = 20;
            dgvListadoProd.Columns[9].HeaderText = "Est.";
            dgvListadoProd.Columns[10].Width = 50;
            dgvListadoProd.Columns[10].HeaderText = "Código";
        }
        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtCodigoBarra.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtUbicacion.Clear();
            panelCodigo.BackgroundImage = null;
            BtnGuardar.Enabled = false;
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            txtCodigo.Visible = false;
            errorProvider1.Clear();

            dgvListadoProd.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CargarCategoria()
        {
            try
            {
                cmbCategoria.DataSource = bllCategoria.Listar();
                cmbCategoria.ValueMember = "codigo";
                cmbCategoria.DisplayMember = "nombre";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.Listar();
            txtCodigo.Visible = false;
            this.CargarCategoria();
        }
        private void ControlarStockFilaColor()
        {
            int cantidadStock = 0;
            foreach (DataGridViewRow item in dgvListadoProd.Rows)
            {
                cantidadStock = Convert.ToInt32(item.Cells[5].Value);
                if (cantidadStock <= 15 && cantidadStock >= 10)
                {
                    item.DefaultCellStyle.BackColor = Color.Orange;
                }
                if (cantidadStock <= 9 && cantidadStock >= 0)
                {
                    item.DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            //OpenFileDialog file = new OpenFileDialog();
            //file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            //if (file.ShowDialog() == DialogResult.OK)
            //{
            //    picBox.Image = Image.FromFile(file.FileName);
            //    txtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("/")+1 );
            //    this.rutaOrigen = file.FileName;
            //}
        }
        private bool UserRegex()
        {
            bool salida = true;
            switch (true)
            {
                case bool _ when Regex.IsMatch(txtNombre.Text, @"^(?![a-zA-Z\s\p{L}]+$)"):
                    MessageBox.Show("El nombre acepta caracteres alfabéticos", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtPrecio.Text, @"^(?![0-9\p{N}]+$)"):
                    MessageBox.Show("El precio solo acepta caracteres númericos.\nControlar espacios en blanco.", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtUbicacion.Text, "^(?![a-zA-Z0-9]+$)"):
                    MessageBox.Show("La ubicación solo acepta caracteres alfanúmericos.\nControlar espacios en blanco.", "ERROR");
                    salida = false;
                    break;
                case bool _ when Regex.IsMatch(txtCodigoBarra.Text, "^(?![0-9]+$)"):
                    MessageBox.Show("El código de barra solo acepta caracteres númericos.\nControlar espacios en blanco.", "ERROR");
                    salida = false;
                    break;

                default:
                    break;
            }
            return salida;
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode codigoBarra = new BarcodeLib.Barcode();
            codigoBarra.IncludeLabel = true;
            if (!String.IsNullOrEmpty(txtCodigoBarra.Text))
            {
                panelCodigo.BackgroundImage = codigoBarra.Encode(BarcodeLib.TYPE.CODE128, txtCodigoBarra.Text, Color.Black, Color.White, 300, 76);
            }
            else
            {
                this.MensajeError("Debe completar el campo, Código de Barra!");
            }

            BtnGuardar.Enabled = true;

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Image imagenCodigo = (Image)panelCodigo.BackgroundImage.Clone();

            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.AddExtension = true;
            dialogo.Filter = "Image PNG (*.png)|*.png";
            dialogo.ShowDialog();
            if (!string.IsNullOrEmpty(dialogo.FileName))
            {
                imagenCodigo.Save(dialogo.FileName, ImageFormat.Png);
            }
            imagenCodigo.Dispose();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                DateTime hoy = DateTime.Now;
                //evaluar los meses q se cargar dateTFecha.Value >= hoy.AddMonths(2) || 
                if (cmbCategoria.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty || txtUbicacion.Text == string.Empty || txtCodigoBarra.Text == string.Empty)
                {
                    this.MensajeError("Algunos de los datos faltan o son incorrectos");
                    errorProvider1.SetError(cmbCategoria, "Seleccionar una categoria");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                    errorProvider1.SetError(dateTFecha, "Fecha de vencimiento superior o igual a 2 meses de la fecha actual");
                    errorProvider1.SetError(txtPrecio, "El precio es necesario");
                    errorProvider1.SetError(txtUbicacion, "Debe completar la ubicación del producto en el deposito");
                    errorProvider1.SetError(txtCodigoBarra, "Debe completar el código de barra, este puede ser scaneado");
                }
                else
                {
                    if (UserRegex())
                    {
                        beProducto = new BEProducto();
                        beProducto.codigoCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                        beProducto.codigoBarra = txtCodigoBarra.Text.Trim();
                        beProducto.nombre = txtNombre.Text.Trim().ToLower();
                        beProducto.precioVenta = Convert.ToDecimal(txtPrecio.Text.Trim());
                        beProducto.stock = 0;
                        beProducto.descripcion = txtDescripcion.Text.Trim();
                        beProducto.ubicacion = txtUbicacion.Text.Trim();
                        beProducto.fechaVencimiento = Convert.ToDateTime(dateTFecha.Value.ToString("dd/MM/yyyy"));
                        respuesta = bllProducto.Crear(beProducto);

                        if (respuesta)
                        {
                            this.MensajeOk("El producto fue registrado correctamente.");
                            this.Listar();
                        }
                        else
                        {
                            this.MensajeError("El producto no se pudo insertar.\nPuede ser que el nombre del producto ya exista.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListadoProd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                txtCodigo.Visible = true;
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtCodigo.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["codigo"].Value);
                cmbCategoria.SelectedValue = Convert.ToInt32(dgvListadoProd.CurrentRow.Cells["codigoCategoria"].Value);
                this.nombreAnterior = Convert.ToString(dgvListadoProd.CurrentRow.Cells["nombre"].Value);
                txtNombre.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["nombre"].Value);
                txtPrecio.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["precioVenta"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["descripcion"].Value);
                txtCodigoBarra.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["codigoBarra"].Value);
                dateTFecha.Value = Convert.ToDateTime(dgvListadoProd.CurrentRow.Cells["fechaVencimiento"].Value);
                txtUbicacion.Text = Convert.ToString(dgvListadoProd.CurrentRow.Cells["ubicacion"].Value);
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccionar desde la celda Nombre"+"| Error: "+ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                bool respuesta = false;
                if (cmbCategoria.Text == string.Empty && txtNombre.Text == string.Empty && txtPrecio.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                    errorProvider1.SetError(cmbCategoria, "Seleccionar una categoria");
                    errorProvider1.SetError(txtNombre, "Ingresar nombre");
                }
                else
                {
                    if (UserRegex())
                    {
                        beProducto = new BEProducto();
                        beProducto.Codigo = Convert.ToInt32(txtCodigo.Text.Trim());
                        beProducto.codigoCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                        beProducto.codigoBarra = txtCodigoBarra.Text.Trim().Length > 0 ? txtCodigoBarra.Text.Trim() : "";
                        beProducto.nombre = txtNombre.Text.Trim().ToLower();
                        beProducto.precioVenta = Convert.ToDecimal(txtPrecio.Text);
                        beProducto.descripcion = txtDescripcion.Text;
                        beProducto.ubicacion = txtUbicacion.Text.Trim();
                        beProducto.fechaVencimiento = Convert.ToDateTime(dateTFecha.Value.ToString("dd/MM/yyyy"));

                        respuesta = bllProducto.Modificar(beProducto, this.nombreAnterior.ToLower());
                        if (respuesta)
                        {
                            this.MensajeOk("El producto se actualizo correctamente");
                            this.Listar();
                            txtCodigo.Visible = false;
                            tabControl1.SelectedIndex = 0;
                        }
                        else
                        {
                            this.MensajeError("El producto no se pudo actualizar.\nPuede ser que el nombre del producto ya exista.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabControl1.SelectedIndex = 0;
        }

        private void dgvListadoProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dgvListadoProd.Columns["Seleccionar"].Index))
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListadoProd.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);//Determino si esta o no esta marcado el checkBox(Documentacion DataGridView)
            }
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
            {
                dgvListadoProd.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;

                dgvListadoProd.DataSource = null;
                dgvListadoProd.DataSource = bllProducto.ListarTodos();
            }
            else
            {
                dgvListadoProd.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;

                dgvListadoProd.DataSource = null;
                dgvListadoProd.DataSource = bllProducto.Listar();
            }
        }
        public static bool estaListoParaUsar(string file)
        {
            try
            {
                using (FileStream inputStream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoProd = 0;
                foreach (DataGridViewRow row in dgvListadoProd.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        codigoProd = Convert.ToInt32(row.Cells[10].Value);
                    }
                }
                if (codigoProd>0)
                {
                    DialogResult opcion;
                    opcion = MessageBox.Show("Esta seguro que va a eliminar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion.Equals(DialogResult.OK))
                    {
                        int codigo;
                        bool flag = false;
                        foreach (DataGridViewRow row in dgvListadoProd.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                codigo = Convert.ToInt32(row.Cells[10].Value);
                                flag = bllProducto.Eliminar(codigo);
                            }
                        }

                        if (flag)
                        {
                            this.MensajeOk("El producto fue eliminado correctamente");
                            this.Limpiar();
                            this.Listar();
                        }
                        else
                        {
                            this.MensajeError("Algo salío mal, la categoría no se pudo eliminar");
                        }
                    }
                }
                else
                {
                    this.MensajeError("Debe seleccionar un producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea desactivar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoProd.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[10].Value);
                            flag = bllProducto.Baja(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("El producto fue dada de baja correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de baja el producto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Esta seguro que desea desactivar el/los registro/s?", "MarketSoft", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion.Equals(DialogResult.OK))
                {
                    int codigo;
                    bool flag = false;
                    foreach (DataGridViewRow row in dgvListadoProd.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToInt32(row.Cells[10].Value);
                            flag = bllProducto.Alta(codigo);
                        }
                    }

                    if (flag)
                    {
                        this.MensajeOk("El producto fue dada de alta correctamente");
                        this.Limpiar();
                        this.Listar();
                    }

                    else
                    {
                        this.MensajeError("Algo salío mal al dar de alta el producto");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvListadoProd_DataSourceChanged(object sender, EventArgs e)
        {
        }

        private void dgvListadoProd_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            bool flag = true;
            if (flag)
            {
                ControlarStockFilaColor();
            }
        }
    }
}
