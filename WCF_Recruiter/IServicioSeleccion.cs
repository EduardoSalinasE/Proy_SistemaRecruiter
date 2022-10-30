using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioSeleccion" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioSeleccion
    {
        [OperationContract]
        List<SeleccionDC> ListarSeleccionPostulante(Int16 cod);
    }
    [DataContract]
    [Serializable]
    public class SeleccionDC
    {
        [DataMember]
        public String Nombres { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public String Empresa { get; set; }
        [DataMember]
        public String Titulo { get; set; }
        [DataMember]
        public DateTime Fec_ini { get; set; }
        [DataMember]
        public DateTime Fec_Ter { get; set; }
        [DataMember]
        public String NombrePregrado { get; set; }
        [DataMember]
        public Int16 Estado { get; set; }
        [DataMember]
        public String NombreMaster { get; set; }
        [DataMember]
        public String NombreDoctorado { get; set; }
        [DataMember]
        public Int16 EstadoDoctorado { get; set; }
        [DataMember]
        public String NombreCentroEstudio { get; set; }
    }
}
