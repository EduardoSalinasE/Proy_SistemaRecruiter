using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data.Entity.Core;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioProcesos" en el código y en el archivo de configuración a la vez.
    public class ServicioProcesos : IServicioProcesos
    {
        Proy_SistemaRecruiter Procesos = new Proy_SistemaRecruiter();

        public List<ProcesosDC> ListarProcesosPostulantesFecha(DateTime fecini, DateTime fecfin)
        {
            try
            {
                List<ProcesosDC> objListProcesosDC = new List<ProcesosDC>();

                var query = Procesos.sp_Servicio_Procesos(fecini, fecfin);

                foreach (var resultado in query)
                {
                    ProcesosDC objProcesosDC = new ProcesosDC();

                    objProcesosDC.codProceso = Convert.ToInt16(resultado.codProceso);
                    objProcesosDC.Plaza = resultado.Plaza;
                    objProcesosDC.Estado = Convert.ToBoolean(resultado.Estado);
                    objProcesosDC.Fec_ini = Convert.ToDateTime(resultado.Fec_ini);
                    objProcesosDC.Fec_Fin = Convert.ToDateTime(resultado.Fec_Fin);
                    objProcesosDC.Nombres = resultado.Nombres;
                    objProcesosDC.Apellidos = resultado.Apellidos;
                    objProcesosDC.Resultado_Proceso = Convert.ToInt16(resultado.Resultado_Proceso);

                    objListProcesosDC.Add(objProcesosDC);
                }

                return objListProcesosDC;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
