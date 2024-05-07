using System.ComponentModel.DataAnnotations;

namespace API.Docentes.Domain.Entities
{
    public class EscalafonTecnico
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public Docente Docente { get; set; }
    }
}
