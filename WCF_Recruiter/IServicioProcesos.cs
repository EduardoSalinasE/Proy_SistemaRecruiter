using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioProcesos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioProcesos
    {
        [OperationContract]
        List<ProcesosDC> ListarProcesosPostulantesFecha(DateTime fecini, DateTime fecfin);

    }
    [DataContract]
    [Serializable]
    public class ProcesosDC
    {
        [DataMember]
        public Int16 codProceso { get; set; }
        [DataMember]
        public String Plaza { get; set; }
        [DataMember]
        public Boolean Estado{ get; set; }
        [DataMember]
        public DateTime Fec_ini { get; set; }
        [DataMember]
        public DateTime Fec_Fin { get; set; }
        [DataMember]
        public String Nombres { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public Int16 Resultado_Proceso { get; set; }
    }
}
