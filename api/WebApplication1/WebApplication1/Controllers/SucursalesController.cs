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
    public class SucursalesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public SucursalesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select suc_nombre,suc_id ,provincia, canton,distrito, telefono, apertura, 
                            gerente_id, ingreso_gerente              
                            from
                            dbo.Sucursales
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
        public JsonResult Post(Sucursales emp)
        {
            string query = @"
                           insert into dbo.Sucursales (suc_nombre ,provincia, canton,distrito, telefono, apertura, 
                            gerente_id, ingreso_gerente) 
                           values (@suc_nombre ,@provincia, @canton,@distrito, @telefono, @apertura, 
                            @gerente_id, @ingreso_gerente)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@suc_nombre", emp.suc_nombre);
                    myCommand.Parameters.AddWithValue("@provincia", emp.provincia);
                    myCommand.Parameters.AddWithValue("@canton", emp.canton);
                    myCommand.Parameters.AddWithValue("@distrito", emp.distrito);
                    myCommand.Parameters.AddWithValue("@telefono", emp.telefono);
                    myCommand.Parameters.AddWithValue("@apertura", emp.apertura);
                    myCommand.Parameters.AddWithValue("@gerente_id", emp.gerente_id);
                    myCommand.Parameters.AddWithValue("@ingreso_gerente", emp.ingreso_gerente);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Sucursales emp)
        {
            string query = @"
                           update dbo.Sucursales
                           set suc_nombre=@suc_nombre,
                            provincia=@provincia,
                            canton=@canton,
                            distrito=@distrito,
                            telefono=@telefono,
                            apertura = @apertura,
                            gerente_id = @gerente_id,
                            ingreso_gerente = @ingreso_gerente
                            where suc_id= @suc_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@suc_nombre", emp.suc_nombre);
                    myCommand.Parameters.AddWithValue("@suc_id", emp.suc_id);
                    myCommand.Parameters.AddWithValue("@provincia", emp.provincia);
                    myCommand.Parameters.AddWithValue("@canton", emp.canton);
                    myCommand.Parameters.AddWithValue("@distrito", emp.distrito);
                    myCommand.Parameters.AddWithValue("@telefono", emp.telefono);
                    myCommand.Parameters.AddWithValue("@apertura", emp.apertura);
                    myCommand.Parameters.AddWithValue("@gerente_id", emp.gerente_id);
                    myCommand.Parameters.AddWithValue("@ingreso_gerente", emp.ingreso_gerente);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{suc_id}")]
        public JsonResult Delete(int suc_id)
        {
            string query = @"
                           delete from dbo.Sucursales
                            where suc_id=@suc_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@suc_id", suc_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [HttpGet("{suc_id}")]
        public JsonResult Getcedula(int suc_id)
        {
            string query = @"
                            select suc_nombre,suc_id ,provincia, canton,distrito, telefono, apertura, 
                            gerente_id, ingreso_gerente         
                            from
                            dbo.Sucursales
                            where suc_id=@suc_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@suc_id", suc_id);

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
