using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data.Entity.Core;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioSeleccion" en el código y en el archivo de configuración a la vez.
    public class ServicioSeleccion : IServicioSeleccion
    {
        Proy_SistemaRecruiter Seleccion = new Proy_SistemaRecruiter();

        public List<SeleccionDC> ListarSeleccionPostulante(short cod)
        {
            try
            {
                List<SeleccionDC> objListSeleccionDC = new List<SeleccionDC>();

                var query = Seleccion.sp_Servicio_Seleccion(cod);

                foreach (var resultado in query)
                {
                    SeleccionDC objSeleccionDC = new SeleccionDC();

                    objSeleccionDC.Nombres = resultado.Nombres;
                    objSeleccionDC.Apellidos = resultado.Apellidos;
                    objSeleccionDC.Empresa = resultado.Empresa;
                    objSeleccionDC.Titulo = resultado.Titulo;
                    objSeleccionDC.Fec_ini = Convert.ToDateTime(resultado.Fec_ini);
                    objSeleccionDC.Fec_Ter = Convert.ToDateTime(resultado.Fec_Ter);
                    objSeleccionDC.NombrePregrado = resultado.NombrePregrado;
                    objSeleccionDC.Estado = Convert.ToInt16(resultado.Estado);
                    objSeleccionDC.NombreMaster = resultado.NombreMaster;
                    objSeleccionDC.NombreDoctorado = resultado.NombreDoctorado;
                    objSeleccionDC.EstadoDoctorado = Convert.ToInt16(resultado.EstadoDoctorado);
                    objSeleccionDC.NombreCentroEstudio = resultado.NombreCentroEstudio;

                    objListSeleccionDC.Add(objSeleccionDC);

                }

                return objListSeleccionDC;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
