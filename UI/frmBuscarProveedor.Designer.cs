
namespace UI
{
    partial class frmBuscarProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvListadoProveedor = new System.Windows.Forms.DataGridView();
            this.btnBuscarProv = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoProveedor
            // 
            this.dgvListadoProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoProveedor.Location = new System.Drawing.Point(48, 143);
            this.dgvListadoProveedor.Name = "dgvListadoProveedor";
            this.dgvListadoProveedor.RowHeadersWidth = 102;
            this.dgvListadoProveedor.RowTemplate.Height = 40;
            this.dgvListadoProveedor.Size = new System.Drawing.Size(2681, 736);
            this.dgvListadoProveedor.TabIndex = 0;
            this.dgvListadoProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoProveedor_CellDoubleClick);
            // 
            // btnBuscarProv
            // 
            this.btnBuscarProv.Location = new System.Drawing.Point(834, 62);
            this.btnBuscarProv.Name = "btnBuscarProv";
            this.btnBuscarProv.Size = new System.Drawing.Size(357, 58);
            this.btnBuscarProv.TabIndex = 1;
            this.btnBuscarProv.Text = "Buscar";
            this.btnBuscarProv.UseVisualStyleBackColor = true;
            this.btnBuscarProv.Click += new System.EventHandler(this.btnBuscarProv_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(48, 73);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(734, 38);
            this.txtBuscar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Razón Social:";
            // 
            // frmBuscarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(2765, 924);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscarProv);
            this.Controls.Add(this.dgvListadoProveedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscarProveedor";
            this.Text = "Seleccionar Proveedor";
            this.Load += new System.EventHandler(this.frmBuscarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoProveedor;
        private System.Windows.Forms.Button btnBuscarProv;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label1;
    }
}