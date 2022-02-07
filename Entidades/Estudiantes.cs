

using System.ComponentModel.DataAnnotations;

namespace Tarea_3.Entidades
{

    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string? Nombres { get; set; }
        public string? Email { get; set; }

        public bool Activo { get; set; }

        public Estudiantes()
        {

        }
    }

}