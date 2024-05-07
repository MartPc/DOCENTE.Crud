using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Docentes.Domain.Entities
{
    public class Docente
    {
        [Key]
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoCelular { get; set; }
        public string NumeroContrato { get; set; }
        [ForeignKey("Ciudad")]
        public int CiudadId { get; set; }
        [ForeignKey("EscalafonTecnico")]
        public int EscalafonTecnicoId { get; set; }
        [ForeignKey("EscalafonExtension")]
        public int EscalafonExtensionId { get; set; }

        public Ciudad Ciudad { get; set; }
        public EscalafonTecnico EscalafonTecnico { get; set; }
        public EscalafonExtension EscalafonExtension { get; set; }

    }
}
