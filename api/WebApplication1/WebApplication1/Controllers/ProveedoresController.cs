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
    public class ProveedoresController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ProveedoresController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select proveedor_nombre,proveedor_id ,proveedor_apellido1, proveedor_apellido2,ced_juridica, direccion, email, 
                            contacto_nombre, contacto_numero, suc_id              
                            from
                            dbo.Proveedores
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
        public JsonResult Post(Proveedores emp)
        {
            string query = @"
                           insert into dbo.Proveedores (proveedor_nombre,proveedor_apellido1, proveedor_apellido2,ced_juridica, direccion, email, 
                            contacto_nombre, contacto_numero, suc_id) 
                           values (@proveedor_nombre, @proveedor_apellido1, @proveedor_apellido2,@ced_juridica, @direccion, @email, 
                            @contacto_nombre, @contacto_numero, @suc_id)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@proveedor_nombre", emp.proveedor_nombre);
                    myCommand.Parameters.AddWithValue("@proveedor_apellido1", emp.proveedor_apellido1);
                    myCommand.Parameters.AddWithValue("@proveedor_apellido2", emp.proveedor_apellido2);
                    myCommand.Parameters.AddWithValue("@ced_juridica", emp.ced_juridica);
                    myCommand.Parameters.AddWithValue("@direccion", emp.direccion);
                    myCommand.Parameters.AddWithValue("@email", emp.email);
                    myCommand.Parameters.AddWithValue("@contacto_nombre", emp.contacto_nombre);
                    myCommand.Parameters.AddWithValue("@contacto_numero", emp.contacto_numero);
                    myCommand.Parameters.AddWithValue("@suc_id", emp.suc_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Proveedores emp)
        {
            string query = @"
                           update dbo.Proveedores
                           set proveedor_nombre=@proveedor_nombre,
                            proveedor_apellido1=@proveedor_apellido1,
                            proveedor_apellido2=@proveedor_apellido2,
                            ced_juridica=@ced_juridica,
                            direccion=@direccion,
                            email = @email,
                            contacto_nombre = @contacto_nombre,
                            contacto_numero = @contacto_numero,
                            suc_id = @suc_id
                            where proveedor_id= @proveedor_id


                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@proveedor_nombre", emp.proveedor_nombre);
                    myCommand.Parameters.AddWithValue("@proveedor_id", emp.proveedor_id);
                    myCommand.Parameters.AddWithValue("@proveedor_apellido1", emp.proveedor_apellido1);
                    myCommand.Parameters.AddWithValue("@proveedor_apellido2", emp.proveedor_apellido2);
                    myCommand.Parameters.AddWithValue("@ced_juridica", emp.ced_juridica);
                    myCommand.Parameters.AddWithValue("@direccion", emp.direccion);
                    myCommand.Parameters.AddWithValue("@email", emp.email);
                    myCommand.Parameters.AddWithValue("@contacto_nombre", emp.contacto_nombre);
                    myCommand.Parameters.AddWithValue("@contacto_numero", emp.contacto_numero);
                    myCommand.Parameters.AddWithValue("@suc_id", emp.suc_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{proveedor_id}")]
        public JsonResult Delete(int proveedor_id)
        {
            string query = @"
                           delete from dbo.Proveedores
                            where proveedor_id=@proveedor_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@proveedor_id", proveedor_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [HttpGet("{proveedor_id}")]
        public JsonResult Getcedula(int proveedor_id)
        {
            string query = @"
                            select proveedor_nombre,proveedor_id ,proveedor_apellido1, proveedor_apellido2,ced_juridica, direccion, email, 
                            contacto_nombre, contacto_numero, suc_id          
                            from
                            dbo.Proveedores
                            where proveedor_id=@proveedor_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@proveedor_id", proveedor_id);

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
