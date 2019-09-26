using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;

namespace Parcial1_JohnsielWF.Registros
{
    public partial class rEvaluacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
            
                EvaluacionTextBox.Text = "0";
                EstudianteTexBox.Text = string.Empty;
                CategoriaTextBox.Text = "0";
                ValorTextBox.Text = string.Empty;
                LogradoTextBox.Text = "0";
                PromedioTextBox.Text = "0";
                ViewState["Evaluacion"] = new Evaluacion();
                // ViewState["Detalle"] = new Pagos().Detalle;
                BindGrid();

            }

        }

        private void Limpiar()
        {
            EstudianteTexBox.Text = string.Empty;
            CategoriaTextBox.Text = "0";
            ValorTextBox.Text = "0";
            LogradoTextBox.Text = "0";
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();






        }
        
     public  Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion = (Evaluacion)ViewState["Evaluacion"];
            evaluacion.EvaluacionId = Convert.ToInt32(EvaluacionTextBox.Text);
           evaluacion.Estudiante = EstudianteTexBox.Text;
            evaluacion.Promedio = Convert.ToDecimal(PromedioTextBox.Text);
            evaluacion.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            
           



            return evaluacion;
        }




        
        private void LlenaCampo(Evaluacion evaluacion)
        {

            ((Evaluacion)ViewState["Evaluacion"]).Detalle = evaluacion.Detalle;
            EvaluacionTextBox.Text = evaluacion.EvaluacionId.ToString();
            EstudianteTexBox.Text = evaluacion.Estudiante;
            
            PromedioTextBox.Text = evaluacion.Estudiante.ToString();
            FechaTextBox.Text = evaluacion.Fecha.ToString();


            this.BindGrid();



        }
        
        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Evaluacion> db = new RepositorioBase<Evaluacion>();
            Evaluacion evaluacion = db.Buscar(Convert.ToInt32(EvaluacionTextBox.Text));
            return (evaluacion != null);

        }


        protected void BindGrid()
        {
            if (ViewState["Evaluacion"] != null)
            {
                DetalleGridView.DataSource = ((Evaluacion)ViewState["Evaluacion"]).Detalle;
                DetalleGridView.DataBind();
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Evaluacion evaluacion;
            bool paso = false;

            evaluacion = LlenaClase();


            if (EvaluacionTextBox.Text == 0.ToString())
            {
                paso = EvaluacionBLL.Guardar(evaluacion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "No se puede modificar", "Error", "error");
                    return;
                }
                paso = EvaluacionBLL.Modificar(evaluacion);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, " Se ha Guardado", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();

        }

        protected void BuscarBotton_Click(object sender, EventArgs e)
        {

            int id;

            RepositorioBase<Evaluacion> db = new RepositorioBase<Evaluacion>();
            Evaluacion analisis = new Evaluacion();
            int.TryParse(EvaluacionTextBox.Text, out id);
            Limpiar();


            analisis = db.Buscar(id);

            if (analisis != null)
            {

                LlenaCampo(analisis);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese analisis", "Error", "error");

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {


            if (Utilitarios.Utils.ToInt(EvaluacionTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(EvaluacionTextBox.Text);

                if (EvaluacionBLL.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, Anlaisis no existe", "error", "error");
            }

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Evaluacion evaluacion = new Evaluacion();

            evaluacion = (Evaluacion)ViewState["Evaluacion"];

            //pago.Detalle.Add(new Entidades.PagosDetalle(0,0, Convert.ToDateTime(FechaTextBox.Text),Convert.ToDecimal( MontoAnalisisTextBox.Text),0,Convert.ToDecimal( MontoAPagarTextBox.Text)));
            evaluacion.Detalle.Add(new Entidades.EvaluacionDetalle(0,0, CategoriaTextBox.Text,Convert.ToDecimal(ValorTextBox.Text) , Convert.ToDecimal(LogradoTextBox.Text),Convert.ToDecimal(PromedioTextBox.Text)));

            ViewState["Evaluacion"] = evaluacion;

            this.BindGrid();

        }
    }
}