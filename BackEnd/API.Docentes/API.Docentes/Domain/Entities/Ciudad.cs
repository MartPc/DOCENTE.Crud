using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Docentes.Domain.Entities
{
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public Docente Docente { get; set; }

    }
}
