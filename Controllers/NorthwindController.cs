using EjemploClase.EjemploConDY;
using EjemploClase.Model;
using EjemploClase.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EjemploClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _repository;
        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
           return await _repository.ObtenerTodosLosEmpleados();

        }
        [HttpGet]
        [Route("api/CantidadEmpleados")]
        public async Task<int> ObtenerCantidadEmpleados()
        {
            return await _repository.ObtenerCantidadEmpleados();

        }
        [HttpGet]
        [Route("api/ObtenerEmpleadoPorID")]
        public async Task<Employees> ObtenerEmpleadoPorID([FromQuery] int empleadoID)
        {
            return await _repository.ObtenerEmpleadoPorID(empleadoID);

        }
        [HttpGet]
        [Route("api/ObtenerEmpleadoPorNombre")]
        public async Task<Employees> ObtenerEmpleadosPorNombre([FromQuery] string nombreEmpleado)
        {
            return await _repository.ObtenerEmpleadosPorNombre(nombreEmpleado);

        }
        [HttpGet]
        [Route("api/ObtenerIDEmpleadoPorTitulo")]
        public async Task<Employees> ObtenerIDEmpleadoPorTitulo([FromQuery] string titulo)
        {
            return await _repository.ObtenerIDEmpleadoPorTitulo(titulo);

        }
        [HttpGet]
        [Route("api/ObtenerEmpleadoPorPais")]
        public async Task<Employees> ObtenerEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerEmpleadoPorPais(country);

        }
        [HttpGet]
        [Route("api/ObtenerTodosLosEmpleadosPorPais")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerTodosLosEmpleadosPorPais(country);

        }
        [HttpGet]
        [Route("api/ObtenerElEmpleadoMasGrande")]
        public async Task<Employees> ObtenerElEmpleadoMasGrande()
        {
            return await _repository.ObtenerElEmpleadoMasGrande();

        }
        [HttpGet]
        [Route("api/ObtenerCantidadEmpleadosPorTitulo")]
        public async Task<List<EmployeeTitleCount>> ObtenerCantidadEmpleadosPorTitulo()
        {
            return await _repository.ObtenerCantidadEmpleadosPorTitulo();
        }
        [HttpGet]
        [Route("api/ObtenerProductosConCategoria")]
        public async Task<List<ProductWithCategory>> ObtenerProductosConCategoria()
        {
            return await _repository.ObtenerProductosConCategoria();
        }
        [HttpGet]
        [Route("api/ObtenerProductosConPalabraChef")]
        public async Task<List<Products>> ObtenerProductosConPalabraChef()
        {
            return await _repository.ObtenerProductosConPalabraChef();
        }
        [HttpDelete]
        [Route("api/EliminarOrdenPorID")]
        public async Task<bool> EliminarOrdenPorID([Required, FromQuery] int id)
        {
            return await _repository.EliminarOrdenPorID(id);
        }
        [HttpPut]
        [Route("api/InsertarEmpleado")]
        public async Task<bool> InsertarEmpleado()
        {
            return await _repository.InsertarEmpleado();
        }
        [HttpPut]
        [Route("api/ModificarNombreEmpleado")]
        public async Task<bool> ModificarNombreEmpleado([Required, FromQuery] int id, [Required, FromQuery] string nombre)
        {
            return await _repository.ModificarNombreEmpleado(id, nombre);
        }
    }
}
