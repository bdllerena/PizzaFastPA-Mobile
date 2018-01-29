using SQLite;

namespace PizzaFastPA.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string FechaNac { get; set; }
        public string Pizza1 { get; set; }
        public string Cantidad1 { get; set; }
        public string Pizza2 { get; set; }
        public string Cantidad2 { get; set; }
        public string Pizza3 { get; set; }
        public string Cantidad3 { get; set; }
        public bool Done { get; set; }
    }
}
