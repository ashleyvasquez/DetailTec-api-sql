using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Citas
    {
        public int cita_id { get; set; }
        public string date { get; set; }
        public int cedula { get; set; }
        public int placa { get; set; }

        public int suc_id { get; set; }

        public int lavado_id { get; set; }

        public int trabajador_id { get; set; }

        
        public void setId(int newId)
        {
            this.cita_id = newId;
        }

        public void setDate(string newDate)
        {
            this.date = newDate;
        }

        public void setCedula(int newCedula)
        {
            this.cedula = newCedula;
        }

        public void setPlaca(int newPlaca)
        {
            this.placa = newPlaca;
        }
        public void setSuc_id(int newSuc_id)
        {
            this.suc_id = newSuc_id;
        }

        public void setLavado_id(int newLavado_id)
        {
            this.lavado_id = newLavado_id;
        }

        public void setTrabajador_id(int newTrabajador_id)
        {
            this.trabajador_id = newTrabajador_id;
        }



    }
}
