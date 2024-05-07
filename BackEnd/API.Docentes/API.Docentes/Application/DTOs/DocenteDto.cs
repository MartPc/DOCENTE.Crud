using API.Docentes.Domain.Entities;

namespace API.Docentes.Application.DTOs
{
    public class DocenteDto
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoCelular { get; set; }
        public string NumeroContrato { get; set; }
        public CiudadDto Ciudad { get; set; }
        public EscalafonTecnicoDto EscalafonTecnico { get; set; }
        public EscalafonExtensionDto EscalafonExtension { get; set; }

    }

    public class DocenteGetAllDto
    {

        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoCelular { get; set; }
        public string NumeroContrato { get; set; }
        public CiudadDto Ciudad { get; set; }
        public EscalafonTecnicoDto EscalafonTecnico { get; set; }
        public EscalafonExtensionDto EscalafonExtension { get; set; }
    }

    public class DocenteCreateDto
    {
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoCelular { get; set; }
        public string NumeroContrato { get; set; }
        public int CiudadId { get; set; }
        public int EscalafonTecnicoId { get; set; }
        public int EscalafonExtensionId { get; set; }

    }

    public class DocenteUpdateDto
    {
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoCelular { get; set; }
        public string NumeroContrato { get; set; }
        public int CiudadId { get; set; }
        public int EscalafonTecnicoId { get; set; }
        public int EscalafonExtensionId { get; set; }

    }
}
