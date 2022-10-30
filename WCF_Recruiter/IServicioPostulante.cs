using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Recruiter
{
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioPostulante" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioPostulante
    {
        [OperationContract]
        List<PostulanteDC> ListarPostulantes();

        [OperationContract]
        Boolean InsertarPostulante(PostulanteDC objPostulanteDC);
        [OperationContract]
        Boolean ActualizarPostulante(PostulanteDC objPostulanteDC);
        [OperationContract]
        Boolean EliminarPostulante(Int16 cod_pos);
    }

    [DataContract]
    [Serializable]

    public class PostulanteDC
    {
        [DataMember]
        public Int16 codPostulante { get; set; }
        [DataMember]
        public String Nombres { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public DateTime Fec_nac { get; set; }
        [DataMember]
        public String Sexo { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public DateTime Fec_Reg { get; set; }
        [DataMember]
        public String Usu_Reg { get; set; }
        [DataMember]
        public DateTime Fec_Mod { get; set; }
        [DataMember]
        public String Usu_Mod { get; set; }
        [DataMember]
        public Int16 codCargo { get; set; }
        [DataMember]
        public Int16 codDistrito { get; set; }
        [DataMember]
        public Int16 codPregrado { get; set; }
        [DataMember]
        public Int16 codDoctorado { get; set; }
        [DataMember]
        public Int16 codMaster { get; set; }
        [DataMember]
        public Int16 codCent_Estu { get; set; }
        [DataMember]
        public Boolean Estado { get; set; }
    }
}
