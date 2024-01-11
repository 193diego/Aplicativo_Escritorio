using Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Bohorquez
{
    public partial class frmmenu : MaterialSkin.Controls.MaterialForm
    {
        public frmmenu(String nombreUsuario)
        {
            InitializeComponent();
            lbUsuario.Text = nombreUsuario;
        }
        private void CargarMateriales()
        {
            DataTable dtMateriales = LogicaMaterial.ObtenerMateriales();
            cboIdMaterial.DataSource = dtMateriales;
            cboIdMaterial.DisplayMember = "NOMBRE_MATERIAL";
            cboIdMaterial.ValueMember = "ID_MATERIAL";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cAMISAS_POLOSDataSet.CONTROL_CALIDAD' Puede moverla o quitarla según sea necesario.
            this.cONTROL_CALIDADTableAdapter.Fill(this.cAMISAS_POLOSDataSet.CONTROL_CALIDAD);
            // TODO: esta línea de código carga datos en la tabla 'cAMISAS_POLOSDataSet.PRODUCCION' Puede moverla o quitarla según sea necesario.
            this.pRODUCCIONTableAdapter.Fill(this.cAMISAS_POLOSDataSet.PRODUCCION);
            CargarMateriales();
            CargarDatosdvgOP();
            CargarDatosdvgM();
            CargarDatosdvgP();
            dgvOrdenProduccion.SelectionChanged += dgvOrdenProduccion_SelectionChanged;

        }
        private void CargarDatosdvgOP()
        {
            dgvOrdenProduccion.DataSource = LogicaOrdenProduccion.ObtenerOrdenesProduccion();
        }
        private void CargarDatosdvgM()
        {
            dgvMateriales.DataSource = LogicaMateriales.ObtenerMaterialesI();
        }
        private void CargarDatosdvgP()
        {
            dgvProduccion.DataSource = LogicaProduccion.ObtenerProduccion();
        }


        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialCard4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel28_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel32_Click(object sender, EventArgs e)
        {

        }

        private void materialCard14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validaciones.SoloNumeros(txtNuOrden.Text))
                {
                    string nombreUsuario = Convert.ToString(lbUsuario.Text);
                    int numeroOrden = int.Parse(txtNuOrden.Text);
                    int cantidad = int.Parse(nupdCantidad.Text);
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaEntrega = dtpFechaEntrega.Value;
                    string modelo = cboModelo.Text;
                    string talla = cboTalla.Text;
                    string color = cboColor.Text;
                    string estadoProduccion = cboEstadoProduccion.Text;
                    int idMaterial = ObtenerIdMaterialSeleccionado();

                    LogicaOrdenProduccion.InsertarOrdenProduccion(nombreUsuario, numeroOrden, cantidad, fechaInicio, fechaEntrega, modelo, talla, color, estadoProduccion, idMaterial);
                    LimpiarCamposOP();

                    MessageBox.Show("Orden de producción agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosdvgOP();
                }
                else
                {
                    MessageBox.Show("El campo Número de Orden debe contener solo números.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la orden de producción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCamposOP()
        {
            txtNuOrden.Clear();
            nupdCantidad.Value = 0;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaEntrega.Value = DateTime.Now;
            cboModelo.SelectedIndex = -1;
            cboTalla.SelectedIndex = -1;
            cboColor.SelectedIndex = -1;
            cboIdMaterial.SelectedIndex = -1;
            cboEstadoProduccion.SelectedIndex = -1;
        }
        private int ObtenerIdMaterialSeleccionado()
        {
            return (int)cboIdMaterial.SelectedValue;
        }
        private void materialButton3_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarSP_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = conexion.conectar())
            {
                using (SqlCommand cmd = new SqlCommand("EDITAR_PRODUCCION", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_PRODUCCION", txtidordebproduccionp.Text);
                    cmd.Parameters.AddWithValue("@ETAPA_PRODUCCION", cboEtapaProduccionP.Text);
                    cmd.Parameters.AddWithValue("@FECHA", dtpFechaP.Value);
                    cmd.Parameters.AddWithValue("@CANTIDAD_PRODUCIDA", nupCantidadProducidaP);

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro actualizado correctamente.");
                }
            }
        }


        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvOrdenProduccion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrdenProduccion.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvOrdenProduccion.SelectedRows[0];
                txtNuOrden.Text = selectedRow.Cells["NUMERO_ORDEN"].Value.ToString();
                nupdCantidad.Text = selectedRow.Cells["CANTIDAD"].Value.ToString();
                dtpFechaInicio.Text = selectedRow.Cells["FECHA_INICIO"].Value.ToString();
                dtpFechaEntrega.Text = selectedRow.Cells["FECHA_ENTREGA"].Value.ToString();
                cboModelo.Text = selectedRow.Cells["MODELO"].Value.ToString();
                cboTalla.Text = selectedRow.Cells["TALLA"].Value.ToString();
                cboColor.Text = selectedRow.Cells["COLOR"].Value.ToString();
                cboIdMaterial.Text = selectedRow.Cells["ID_MATERIAL"].Value.ToString();
                cboEstadoProduccion.Text = selectedRow.Cells["ESTADO_PRODUCCION"].Value.ToString();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            CargarDatosdvgM();
        }

        private void btnBuscarOD_Click(object sender, EventArgs e)
        {
            try
            {
                string caracterBusqueda = txtCaracter.Text;
                DataTable dtResultado = LogicaOrdenProduccion.BuscarOrdenProduccion(caracterBusqueda);
                dgvOrdenProduccion.DataSource = dtResultado;
                MessageBox.Show($"Se encontraron {dtResultado.Rows.Count} resultado(s).", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarOD_Click(object sender, EventArgs e)
        {
            txtCaracter.Clear();
            CargarDatosdvgOP();
        }

        private void btnEliminarOP_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenProduccion.SelectedRows.Count > 0)
                {
                    int numeroOrden = Convert.ToInt32(dgvOrdenProduccion.SelectedRows[0].Cells["NUMERO_ORDEN"].Value);
                    LogicaOrdenProduccion.EliminarOrdenProduccion(numeroOrden);


                    MessageBox.Show("Orden de producción eliminada exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar el DataGridView después de la eliminación
                    LimpiarCamposOP();
                    CargarDatosdvgOP();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la orden de producción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarOP_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrdenProduccion.SelectedRows.Count > 0 & Validaciones.SoloNumeros(txtNuOrden.Text))
                {
                    DataGridViewRow selectedRow = dgvOrdenProduccion.SelectedRows[0];
                    int idOrdenProduccion = Convert.ToInt32(selectedRow.Cells["ID_ORDEN_PRODUCCION"].Value);
                    string nombreUsuario = Convert.ToString(lbUsuario.Text);
                    int numeroOrden = int.Parse(txtNuOrden.Text);
                    int cantidad = int.Parse(nupdCantidad.Text);
                    DateTime fechaInicio = dtpFechaInicio.Value;
                    DateTime fechaEntrega = dtpFechaEntrega.Value;
                    string modelo = cboModelo.Text;
                    string talla = cboTalla.Text;
                    string color = cboColor.Text;
                    string estadoProduccion = cboEstadoProduccion.Text;
                    int idMaterial = ObtenerIdMaterialSeleccionado();
                    LogicaOrdenProduccion.EditarOrdenProduccion(nombreUsuario, numeroOrden, cantidad, fechaInicio, fechaEntrega, modelo, talla, color, estadoProduccion, idMaterial, idOrdenProduccion);

                    MessageBox.Show("Orden de producción editada exitosamente.", "Edición Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposOP();
                    CargarDatosdvgOP();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar la orden de producción: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrdenProduccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMateriales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMateriales.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMateriales.SelectedRows[0];
                cboNombreMaterialI.Text = selectedRow.Cells["NOMBRE_MATERIAL"].Value.ToString();
                txtCantidadDisponibleI.Text = selectedRow.Cells["CANTIDAD_DISPONIBLE"].Value.ToString();
                nupCantidadMinimaI.Text = selectedRow.Cells["CANTIDAD_MINIMA"].Value.ToString();
                txtPrecioUnitarioI.Text = selectedRow.Cells["PRECIO_UNITARIO"].Value.ToString();
            }
        }

        private void dgvProduccion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduccion.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProduccion.SelectedRows[0];
                txtidordebproduccionp.Text = selectedRow.Cells["ID_ORDEN_PRODUCCION"].Value.ToString();
                cboEtapaProduccionP.Text = selectedRow.Cells["ETAPA_PRODUCCION"].Value.ToString();
                dtpFechaP.Text = selectedRow.Cells["FECHA"].Value.ToString();
                nupCantidadProducidaP.Text = selectedRow.Cells["CANTIDAD_PRODUCIDA"].Value.ToString();
            }

        }


        private void btnLimpiarP_Click(object sender, EventArgs e)
        {
            CargarDatosdvgP();
        }



        private void btnAgregarM_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = conexion.conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("INSERTAR_INVENTARIO", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NOMBRE_MATERIAL", cboNombreMaterialI.Text);
                        cmd.Parameters.AddWithValue("@CANTIDAD_DISPONIBLE", Convert.ToInt32(txtCantidadDisponibleI.Text));
                        cmd.Parameters.AddWithValue("@CANTIDAD_MINIMA", Convert.ToInt32(nupCantidadMinimaI.Text));
                        cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", Convert.ToDecimal(txtPrecioUnitarioI.Text));

                        cmd.ExecuteNonQuery();
                        cboNombreMaterialI.SelectedValue = -1;
                        txtCantidadDisponibleI.Clear();
                        txtPrecioUnitarioI.Clear();


                    }
                }

                MessageBox.Show("Datos de inventario agregados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosdvgM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCalidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboIdOrdenProduccionP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = dtpDesdeR.Value;
                DateTime fechaFin = dtpHastaR.Value;

                using (SqlConnection cn = conexion.conectar())
                {
                    // Crear el comando SQL con la función definida en la base de datos
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ObtenerDetallesOrdenesPorFecha(@FechaInicio, @FechaFin)", cn))
                    {
                        // Agregar los parámetros de fecha a la consulta SQL
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                        DataTable tablaResultado = new DataTable();

                        adaptador.Fill(tablaResultado);
                        dgvReporte.DataSource = tablaResultado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.cONTROL_CALIDADTableAdapter.FillBy(this.cAMISAS_POLOSDataSet.CONTROL_CALIDAD);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void btnEditarM_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = conexion.conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("EDITAR_INVENTARIO", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@NOMBRE_MATERIAL", SqlDbType.VarChar).Value = cboNombreMaterialI.Text;

                        int cantidadDisponible;
                        if (int.TryParse(txtCantidadDisponibleI.Text, out cantidadDisponible))
                        {
                            cmd.Parameters.Add("@CANTIDAD_DISPONIBLE", SqlDbType.Int).Value = cantidadDisponible;
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cmd.Parameters.Add("@CANTIDAD_MINIMA", SqlDbType.Int).Value = Convert.ToInt32(nupCantidadMinimaI.Text);
                        cmd.Parameters.Add("@PRECIO_UNITARIO", SqlDbType.Decimal).Value = Convert.ToDecimal(txtPrecioUnitarioI.Text);

                        cmd.ExecuteNonQuery();

                        cboNombreMaterialI.SelectedIndex = -1;
                        txtCantidadDisponibleI.Clear();
                        nupCantidadMinimaI.Value = 0;
                        txtPrecioUnitarioI.Clear();
                    }
                }

                MessageBox.Show("Datos de inventario editados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatosdvgM();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al editar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarM_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cboNombreMaterialI.Text))
                {
                    using (SqlConnection cn = conexion.conectar())
                    {
                        using (SqlCommand cmd = new SqlCommand("ELIMINAR_INVENTARIO", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@ID_MATERIAL", SqlDbType.Int).Value = Convert.ToInt32(txtidmaterial.Text);

                            cmd.ExecuteNonQuery();

                            CargarDatosdvgM();
                        }
                    }

                    MessageBox.Show("Datos de inventario eliminados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosdvgM();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarSP_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = conexion.conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("INSERTAR_PRODUCCION", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Asegúrate de obtener los valores correctos de tus controles TextBox
                        cmd.Parameters.Add("@ID_PRODUCCION", SqlDbType.VarChar).Value = txtidordebproduccionp.Text;
                        cmd.Parameters.Add("@ETAPA_PRODUCCION", SqlDbType.VarChar).Value = cboEtapaProduccionP.Text;
                        cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = dtpFechaP.Value;
                        cmd.Parameters.Add("@CANTIDAD_PRODUCIDA", SqlDbType.Int).Value = Convert.ToInt32(nupCantidadProducidaP.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro insertado correctamente.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al insertar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarSP_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = conexion.conectar())
                {
                    using (SqlCommand cmd = new SqlCommand("ELIMINAR_PRODUCCION", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ID_PRODUCCION", SqlDbType.VarChar).Value = txtidordebproduccionp.Text;

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro eliminado correctamente.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
