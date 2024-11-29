using EjemploClase.Model;

namespace EjemploClase.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employees>> ObtenerTodosLosEmpleados();
        Task<int> ObtenerCantidadEmpleados();
        Task<Employees> ObtenerEmpleadoPorID(int id);
        Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado);
        Task<Employees> ObtenerIDEmpleadoPorTitulo(string titulo);
        Task<Employees> ObtenerEmpleadoPorPais(string country);
        Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country);
        Task<Employees> ObtenerElEmpleadoMasGrande();
        Task<List<EmployeeTitleCount>> ObtenerCantidadEmpleadosPorTitulo();
        Task<List<ProductWithCategory>> ObtenerProductosConCategoria();
        Task<List<Products>> ObtenerProductosConPalabraChef();

    }
}
