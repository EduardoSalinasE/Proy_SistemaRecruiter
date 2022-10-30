using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioCentroEstudios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioCentroEstudios
    {
        [OperationContract]
        List<CentroEstudiosDC> ListarCentroEstudios();

        [OperationContract]
        Boolean InsertarCentroEstudios(CentroEstudiosDC objCentroEstudiosDC);
        [OperationContract]
        Boolean ActualizarCentroEstudios(CentroEstudiosDC objCentroEstudiosDC);
        [OperationContract]
        Boolean EliminarCentroEstudios(Int16 cod_cen);

    }

    [DataContract]
    [Serializable]
    public class CentroEstudiosDC
    {
        [DataMember]
        public Int16 codCentro_Estu { get; set; }
        [DataMember]
        public Boolean Tipo { get; set; }
        [DataMember]
        public String NombreCentroEstudios { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public Int16 codDistrito { get; set; }
    }
}
