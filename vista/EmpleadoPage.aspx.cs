using System;
using Modelo;

namespace vista
{
    public partial class EmpleadoPage : System.Web.UI.Page
    {
        private Empleado empleadoService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empleadoService = new Empleado();

                drop_puesto.DataSource = empleadoService.ObtenerPuestos();
                drop_puesto.DataTextField = "puesto";
                drop_puesto.DataValueField = "id";
                drop_puesto.DataBind();

                CargarEmpleados();
            }
        }

        private void CargarEmpleados()
        {
            empleadoService = new Empleado(); 
            grid_empleados.DataSource = empleadoService.ObtenerEmpleados();
            grid_empleados.DataBind();
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            empleadoService = new Empleado();
            if (empleadoService.AgregarEmpleado(
                txt_codigo.Text,
                txt_nombres.Text,
                txt_apellidos.Text,
                txt_direccion.Text,
                txt_telefono.Text,
                txt_fn.Text,
                Convert.ToInt32(drop_puesto.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Ingreso Exitoso";

                CargarEmpleados();

                LimpiarCampos();
            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            empleadoService = new Empleado();
            if (empleadoService.ModificarEmpleado(
                Convert.ToInt32(grid_empleados.SelectedDataKey.Value),
                txt_codigo.Text,
                txt_nombres.Text,
                txt_apellidos.Text,
                txt_direccion.Text,
                txt_telefono.Text,
                txt_fn.Text,
                Convert.ToInt32(drop_puesto.SelectedValue)) > 0)
            {
                lbl_mensaje.Text = "Modificación Exitosa...";
                CargarEmpleados();

                btn_modificar.Visible = false;
                LimpiarCampos();
            }
        }

        protected void grid_empleados_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            empleadoService = new Empleado();
            if (empleadoService.EliminarEmpleado(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lbl_mensaje.Text = "Eliminación Exitosa...";

                CargarEmpleados();
            }
        }

        protected void grid_empleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = grid_empleados.SelectedRow.RowIndex;

            txt_codigo.Text = grid_empleados.SelectedRow.Cells[2].Text; 
            txt_nombres.Text = grid_empleados.SelectedRow.Cells[3].Text;
            txt_apellidos.Text = grid_empleados.SelectedRow.Cells[4].Text;
            txt_direccion.Text = grid_empleados.SelectedRow.Cells[5].Text;
            txt_telefono.Text = grid_empleados.SelectedRow.Cells[6].Text;

            string fechaTexto = grid_empleados.SelectedRow.Cells[7].Text;
            DateTime fecha;
            if (DateTime.TryParse(fechaTexto, out fecha))
            {
                txt_fn.Text = fecha.ToString("yyyy-MM-dd");
            }
            else
            {
                lbl_mensaje.Text = "Error: El formato de la fecha no es válido.";
                txt_fn.Text = string.Empty;
            }

            drop_puesto.SelectedValue = grid_empleados.DataKeys[index].Values["id_puesto"].ToString();

            btn_modificar.Visible = true;
            lbl_mensaje.Text = "Empleado seleccionado para edición.";
        }
        private void LimpiarCampos()
        {
            txt_codigo.Text = string.Empty;
            txt_nombres.Text = string.Empty;
            txt_apellidos.Text = string.Empty;
            txt_direccion.Text = string.Empty;
            txt_telefono.Text = string.Empty;
            txt_fn.Text = string.Empty;
            drop_puesto.SelectedIndex = 0;
        }
    }
}
