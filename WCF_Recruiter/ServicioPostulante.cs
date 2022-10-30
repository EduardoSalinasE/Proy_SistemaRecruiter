using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data.Entity.Core;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioPostulante" en el código y en el archivo de configuración a la vez.
    public class ServicioPostulante : IServicioPostulante
    {

        Proy_SistemaRecruiter Postulante = new Proy_SistemaRecruiter();

        public Boolean ActualizarPostulante(PostulanteDC objPostulanteDC)
        {
            try
            {
                Postulante.sp_ActualziarPostulante
                (
                Convert.ToInt16(objPostulanteDC.codPostulante),
                objPostulanteDC.Nombres,
                objPostulanteDC.Apellidos,
                objPostulanteDC.Dni,
                Convert.ToDateTime(objPostulanteDC.Fec_nac),
                objPostulanteDC.Sexo,
                objPostulanteDC.Telefono,
                objPostulanteDC.Email,
                objPostulanteDC.Direccion,
                Convert.ToDateTime(objPostulanteDC.Fec_Reg),
                objPostulanteDC.Usu_Reg,
                Convert.ToInt16(objPostulanteDC.codCargo),
                Convert.ToInt16(objPostulanteDC.codDistrito),
                Convert.ToInt16(objPostulanteDC.codPregrado),
                Convert.ToInt16(objPostulanteDC.codDoctorado),
                Convert.ToInt16(objPostulanteDC.codMaster),
                Convert.ToInt16(objPostulanteDC.codCent_Estu),
                Convert.ToBoolean(objPostulanteDC.Estado)
                );

                Postulante.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Boolean EliminarPostulante(short cod_pos)
        {
            try
            {
                Postulante.sp_EliminarPostulante(cod_pos);

                Postulante.SaveChanges();
                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Boolean InsertarPostulante(PostulanteDC objPostulanteDC)
        {
            try
            {
                Postulante.sp_InsertarPostulante
                (
                objPostulanteDC.Nombres,
                objPostulanteDC.Apellidos,
                objPostulanteDC.Dni,
                Convert.ToDateTime(objPostulanteDC.Fec_nac),
                objPostulanteDC.Sexo,
                objPostulanteDC.Telefono,
                objPostulanteDC.Email,
                objPostulanteDC.Direccion,
                objPostulanteDC.Usu_Reg,
                Convert.ToInt16(objPostulanteDC.codCargo),
                Convert.ToInt16(objPostulanteDC.codDistrito),
                Convert.ToInt16(objPostulanteDC.codPregrado),
                Convert.ToInt16(objPostulanteDC.codDoctorado),
                Convert.ToInt16(objPostulanteDC.codMaster),
                Convert.ToInt16(objPostulanteDC.codCent_Estu),
                Convert.ToBoolean(objPostulanteDC.Estado)
                );

                Postulante.SaveChanges();
                return true;

            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<PostulanteDC> ListarPostulantes()
        {
            try
            {
                List<PostulanteDC> objListaPostulanteDC = new List<PostulanteDC>();

                var query = (from miPostulante in Postulante.POSTULANTE select miPostulante).ToList();

                foreach (var resultado in query)
                {
                    PostulanteDC objPostulanteDC = new PostulanteDC();
                    objPostulanteDC.codPostulante = Convert.ToInt16(resultado.codPostulante);
                    objPostulanteDC.Nombres = resultado.Nombres;
                    objPostulanteDC.Apellidos = resultado.Apellidos;
                    objPostulanteDC.Dni = resultado.Dni;
                    objPostulanteDC.Fec_nac = Convert.ToDateTime(resultado.Fec_Nac);
                    objPostulanteDC.Sexo = resultado.Sexo;
                    objPostulanteDC.Telefono = resultado.Telefono;
                    objPostulanteDC.Email = resultado.Email;
                    objPostulanteDC.Direccion = resultado.Direccion;
                    objPostulanteDC.Fec_Reg = Convert.ToDateTime(resultado.Fec_Reg);
                    objPostulanteDC.Usu_Reg = resultado.Usu_Reg;
                    objPostulanteDC.Fec_Mod = Convert.ToDateTime(resultado.Fec_Mod);
                    objPostulanteDC.Usu_Mod = resultado.Usu_Mod;
                    objPostulanteDC.codCargo = Convert.ToInt16(resultado.codCargo);
                    objPostulanteDC.codDistrito = Convert.ToInt16(resultado.codDistrito);
                    objPostulanteDC.codPregrado = Convert.ToInt16(resultado.codPregrado);
                    objPostulanteDC.codDoctorado = Convert.ToInt16(resultado.codDoctorado);
                    objPostulanteDC.codMaster = Convert.ToInt16(resultado.codMaster);
                    objPostulanteDC.codCent_Estu = Convert.ToInt16(resultado.codCent_Estu);
                    objPostulanteDC.Estado = Convert.ToBoolean(resultado.Estado);

                    objListaPostulanteDC.Add(objPostulanteDC);
                }

                return objListaPostulanteDC;

            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
