namespace CrudAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Existencias { get; set; }
        public double Precio { get; set; }
    }
}
