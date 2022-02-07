

using System.ComponentModel.DataAnnotations;

namespace Tarea_3.Entidades
{
    public class Carreras
    {
        [Key]
        public int CarreraId { get; set; }
        public string? Nombre { get; set; }


        public Carreras()
        {

        }
        public Carreras(int carreraId, string nombre)
        {
            this.CarreraId = carreraId;
            this.Nombre = nombre;
        }
    }

}