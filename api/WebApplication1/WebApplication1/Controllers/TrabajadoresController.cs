using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public TrabajadoresController(IConfiguration configuration,IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select trabajador_id , cedula, nombre,apellido1, apellido2, ingreso, 
                            nacimiento, edad, password_trab, rol, pago, email             
                            from
                            dbo.Trabajadores
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Trabajadores emp)
        {
            string query = @"
                           insert into dbo.Trabajadores ( cedula, nombre, apellido1, apellido2, ingreso, nacimiento ,
                           password_trab, rol, pago, email) 
                           values ( @cedula, @nombre, @apellido1, @apellido2, @ingreso, @nacimiento,
                             @password_trab, @rol, @pago, @email)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cedula", emp.cedula);
                    myCommand.Parameters.AddWithValue("@nombre", emp.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", emp.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", emp.apellido2);
                    myCommand.Parameters.AddWithValue("@ingreso", emp.ingreso);
                    myCommand.Parameters.AddWithValue("@nacimiento", emp.nacimiento);
                    myCommand.Parameters.AddWithValue("@password_trab", emp.password_trab);
                    myCommand.Parameters.AddWithValue("@rol", emp.rol);
                    myCommand.Parameters.AddWithValue("@pago", emp.pago);
                    myCommand.Parameters.AddWithValue("@email", emp.email);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Trabajadores emp)
        {
            string query = @"
                           update dbo.Trabajadores
                           set 
                            nombre=@nombre,
                            apellido1=@apellido1,
                            apellido2=@apellido2,
                            ingreso = @ingreso,
                            nacimiento = @nacimiento,
                            password_trab = @password_trab,
                            rol = @rol,
                            pago = @pago,
                            email = @email
                            where trabajador_id=@trabajador_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@trabajador_id", emp.trabajador_id);
                    myCommand.Parameters.AddWithValue("@cedula", emp.cedula);
                    myCommand.Parameters.AddWithValue("@nombre", emp.nombre);
                    myCommand.Parameters.AddWithValue("@apellido1", emp.apellido1);
                    myCommand.Parameters.AddWithValue("@apellido2", emp.apellido2);
                    myCommand.Parameters.AddWithValue("@ingreso", emp.ingreso);
                    myCommand.Parameters.AddWithValue("@nacimiento", emp.nacimiento);
                    myCommand.Parameters.AddWithValue("@password_trab", emp.password_trab);
                    myCommand.Parameters.AddWithValue("@rol", emp.rol);
                    myCommand.Parameters.AddWithValue("@pago", emp.pago);
                    myCommand.Parameters.AddWithValue("@email", emp.email);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{trabajador_id}")]
        public JsonResult Delete(int trabajador_id)
        {
            string query = @"
                           delete from dbo.Trabajadores
                            where trabajador_id=@trabajador_id,
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@trabajador_id", trabajador_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [HttpGet("{id}")]
        public JsonResult GetId(int id)
        {
            string query = @"
                            select trabajador_id , cedula, nombre,apellido1, apellido2, ingreso, 
                            nacimiento, edad, password_trab, rol, pago, email             
                            from
                            dbo.Trabajadores
                            where trabajador_id=@trabajador_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@trabajador_id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("email/{email}")]
        public JsonResult GetEmail(string email)
        {
            string query = @"
                            select * from
                            dbo.Trabajadores
                            where email=@email
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@email", email);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}

