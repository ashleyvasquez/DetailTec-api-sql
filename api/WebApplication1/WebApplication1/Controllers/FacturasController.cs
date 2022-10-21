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
    public class FacturasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public FacturasController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select fact_id ,cita_id,snacks_consumidos,bebidas_consumidas, precio_servicio, monto, iva            
                            from
                            dbo.Facturas
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
        public JsonResult Post(Facturas emp)
        {
            string query = @"
                           insert into dbo.Facturas (cita_id,snacks_consumidos,bebidas_consumidas, precio_servicio, monto) 
                           values (@cita_id, @snacks_consumidos,@bebidas_consumidas, @precio_servicio, @monto)             
                     
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
       
                    myCommand.Parameters.AddWithValue("@cita_id", emp.cita_id);
                    myCommand.Parameters.AddWithValue("@snacks_consumidos", emp.snacks_consumidos);
                    myCommand.Parameters.AddWithValue("@bebidas_consumidas", emp.bebidas_consumidas);
                    myCommand.Parameters.AddWithValue("@precio_servicio", emp.precio_servicio);
                    myCommand.Parameters.AddWithValue("@monto", emp.monto);
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Facturas emp)
        {
            string query = @"
                           update dbo.Facturas
                           set 
                           cita_id=@cita_id,
                           snacks_consumidos=@snacks_consumidos,
                           bebidas_consumidas=@bebidas_consumidas,
                           precio_servicio=@precio_servicio,
                           monto = @monto
                          
                          
                           where fact_id= @fact_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@fact_id", emp.fact_id);
                    myCommand.Parameters.AddWithValue("@cita_id", emp.cita_id);
                    myCommand.Parameters.AddWithValue("@snacks_consumidos", emp.snacks_consumidos);
                    myCommand.Parameters.AddWithValue("@bebidas_consumidas", emp.bebidas_consumidas);
                    myCommand.Parameters.AddWithValue("@precio_servicio", emp.precio_servicio);
                    myCommand.Parameters.AddWithValue("@monto", emp.monto);
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{fact_id}")]
        public JsonResult Delete(int fact_id)
        {
            string query = @"
                           delete from dbo.Facturas
                            where fact_id=@fact_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@fact_id", fact_id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        [HttpGet("{fact_id}")]
        public JsonResult Getcedula(int fact_id)
        {
            string query = @"
                            select fact_id ,cita_id,snacks_consumidos,bebidas_consumidas, precio_servicio, monto, iva         
                            from
                            dbo.Facturas
                            where fact_id=@fact_id
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TrabajadoresAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@fact_id", fact_id);

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
