using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data.Entity.Core;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioCentroEstudios" en el código y en el archivo de configuración a la vez.
    public class ServicioCentroEstudios : IServicioCentroEstudios
    {
        Proy_SistemaRecruiter CentroEstudios = new Proy_SistemaRecruiter();

        public Boolean ActualizarCentroEstudios(CentroEstudiosDC objCentroEstudiosDC)
        {
            try
            {
                CentroEstudios.sp_ActualizarCentroEstudio
                    (
                    Convert.ToInt16(objCentroEstudiosDC.codCentro_Estu),
                    Convert.ToBoolean(objCentroEstudiosDC.Tipo),
                    objCentroEstudiosDC.NombreCentroEstudios,
                    objCentroEstudiosDC.Direccion,
                    objCentroEstudiosDC.Telefono,
                    objCentroEstudiosDC.Email,
                    Convert.ToInt16(objCentroEstudiosDC.codDistrito)
                    );

                CentroEstudios.SaveChanges();
                return true;

            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarCentroEstudios(short cod_cen)
        {
            try
            {
                CentroEstudios.sp_EliminarCentroEstudio(cod_cen);

                CentroEstudios.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Boolean InsertarCentroEstudios(CentroEstudiosDC objCentroEstudiosDC)
        {
            try
            {
                CentroEstudios.sp_InsertarCentroEstudio
                    (
                    Convert.ToBoolean(objCentroEstudiosDC.Tipo),
                    objCentroEstudiosDC.NombreCentroEstudios,
                    objCentroEstudiosDC.Direccion,
                    objCentroEstudiosDC.Telefono,
                    objCentroEstudiosDC.Email,
                    Convert.ToInt16(objCentroEstudiosDC.codDistrito)
                    );

                CentroEstudios.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<CentroEstudiosDC> ListarCentroEstudios()
        {
            try
            {
                List<CentroEstudiosDC> objListaCentroEstudiosDC = new List<CentroEstudiosDC>();

                var query = (from miCentroEstudios in CentroEstudios.CENTRO_ESTUDIOS select miCentroEstudios).ToList();

                foreach (var resultado in query)
                {
                    CentroEstudiosDC objCentroEstudiosDC = new CentroEstudiosDC();
                    objCentroEstudiosDC.codCentro_Estu = Convert.ToInt16(resultado.codCentro_Estu);
                    objCentroEstudiosDC.Tipo = Convert.ToBoolean(resultado.Tipo);
                    objCentroEstudiosDC.NombreCentroEstudios = resultado.NombreCentroEstudio;
                    objCentroEstudiosDC.Direccion = resultado.Direccion;
                    objCentroEstudiosDC.Telefono = resultado.Telefono;
                    objCentroEstudiosDC.Email = resultado.Email;
                    objCentroEstudiosDC.codDistrito = Convert.ToInt16(resultado.codDistrito);

                    objListaCentroEstudiosDC.Add(objCentroEstudiosDC);
                }

                return objListaCentroEstudiosDC;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
