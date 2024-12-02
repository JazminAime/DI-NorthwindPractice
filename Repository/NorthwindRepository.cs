using EjemploClase.Model;
using EjemploClase.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EjemploClase.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContextNorthwind _dataContext;

        public NorthwindRepository(DataContextNorthwind dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            var result = await _dataContext.Employees.ToListAsync();
            return result;
        }
        public async Task<int> ObtenerCantidadEmpleados()
        {
            var result = await _dataContext.Employees.CountAsync();
            return result;
        }
        public async Task<Employees> ObtenerEmpleadoPorID(int id)
        {
            var result = await _dataContext.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado)
        {
            var result = await _dataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == nombreEmpleado);
            return result;
        }
        public async Task<Employees> ObtenerIDEmpleadoPorTitulo(string titulo)
        {
            var result = from emp in _dataContext.Employees where emp.Title == titulo select emp;
            return await result.FirstOrDefaultAsync();
        }
        public async Task<Employees> ObtenerEmpleadoPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,

                         };
            return await result.FirstOrDefaultAsync();
        }
        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         orderby emp.FirstName
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,

                         };
            return await result.ToListAsync();
        }
        public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {
            var result = from emp in _dataContext.Employees
                         orderby emp.BirthDate
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,

                         };
            return await result.FirstOrDefaultAsync();
        }
        public async Task<List<EmployeeTitleCount>> ObtenerCantidadEmpleadosPorTitulo()
        {
            var result = await _dataContext.Employees
                .GroupBy(emp => emp.Title) // Agrupa los empleados por su titulo
                .Select(g => new EmployeeTitleCount // Proyecta los resultados en una nueva clase
                {
                    Title = g.Key, // Titulo
                    Count = g.Count() // Numero de empleados con ese titulo
                })
                .ToListAsync();

            return result;
        }
        public async Task<List<ProductWithCategory>> ObtenerProductosConCategoria()
        {
            var result = from prod in _dataContext.Products
                         join cat in _dataContext.Categories on prod.CategoryID equals cat.CategoryID
                         select new ProductWithCategory // Proyecta los resultados en una nueva clase
                         {
                             ProductID = prod.ProductID,
                             ProductName = prod.ProductName,
                             CategoryName = cat.CategoryName // Inclute informacion de otra tabla
                         };

            return await result.ToListAsync();
        }
        public async Task<List<Products>> ObtenerProductosConPalabraChef()
        {
            var result = _dataContext.Products
            .Where(p => p.ProductName != null && EF.Functions.Like(p.ProductName, "%chef%"));
            return await result.ToListAsync();
        }
        public async Task<bool> EliminarOrdenPorID(int orderID)
        {
            Orders? order = await _dataContext.Orders.Where(r => r.OrderID == orderID).FirstOrDefaultAsync();
            OrderDetails? orderDetail = await _dataContext.OrderDetails.Where(r => r.OrderID == order.OrderID).FirstOrDefaultAsync();

            _dataContext.OrderDetails.Remove(orderDetail);
            _dataContext.Orders.Remove(order);

            var resultado = _dataContext.SaveChanges();
            return true;
        }
        public async Task<bool> InsertarEmpleado()
        {
            Employees employee = new Employees();
            employee.Title = "sales manager";
            employee.City = "Rosario";
            employee.FirstName = "Jazmin";
            employee.LastName = "Falcon";
            employee.Country = "Argentina";
            employee.HireDate = DateTime.Now;
            employee.BirthDate = DateTime.Now;
            var newEmployee = await _dataContext.AddAsync(employee);
            var result = _dataContext.SaveChanges();

            return (result > 0);

        }
        public async Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre)
        {
            bool actualizado = false;
            Employees result = await _dataContext.Employees.Where(r => r.EmployeeID == idEmpleado).FirstOrDefaultAsync();
            if (result != null)
            {
                result.FirstName = nombre;
                var resultado = _dataContext.SaveChanges();
                actualizado = true;
            }
            return actualizado;
        }
    }
}
