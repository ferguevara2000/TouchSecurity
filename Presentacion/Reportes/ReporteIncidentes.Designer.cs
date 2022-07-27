
namespace Presentacion.Reportes
{
    partial class ReporteIncidentes
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteIncidentes));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.vistaReportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.touchSecurityDataSet = new Presentacion.TouchSecurityDataSet();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.vistaReportesTableAdapter = new Presentacion.TouchSecurityDataSetTableAdapters.VistaReportesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vistaReportesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchSecurityDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.BarraTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // vistaReportesBindingSource
            // 
            this.vistaReportesBindingSource.DataMember = "VistaReportes";
            this.vistaReportesBindingSource.DataSource = this.touchSecurityDataSet;
            // 
            // touchSecurityDataSet
            // 
            this.touchSecurityDataSet.DataSetName = "TouchSecurityDataSet";
            this.touchSecurityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(763, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.BarraTitulo.Controls.Add(this.btnCerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(800, 38);
            this.BarraTitulo.TabIndex = 2;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.vistaReportesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 36);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 580);
            this.reportViewer1.TabIndex = 3;
            // 
            // vistaReportesTableAdapter
            // 
            this.vistaReportesTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteIncidentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.BarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteIncidentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteIncidentes";
            this.Load += new System.EventHandler(this.ReporteIncidentes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vistaReportesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.touchSecurityDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.BarraTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Panel BarraTitulo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TouchSecurityDataSet touchSecurityDataSet;
        private System.Windows.Forms.BindingSource vistaReportesBindingSource;
        private TouchSecurityDataSetTableAdapters.VistaReportesTableAdapter vistaReportesTableAdapter;
    }
}