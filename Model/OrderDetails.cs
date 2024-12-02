using System.ComponentModel.DataAnnotations;

namespace EjemploClase.Model
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        public int ProductID { get; set; }
    }
}
