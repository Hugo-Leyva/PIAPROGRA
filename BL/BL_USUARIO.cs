using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_USUARIO
    {
        public static List<ConsultarUSUARIO> Consultar(string P_Cadena)
        {
            List<ConsultarUSUARIO> lstUsuarios = new List<ConsultarUSUARIO>();

            var dpParametros = new
            {
                P_Accion = 1,
            };

            DataTable Dt = Contexto.Funcion_StoreDB1(P_Cadena, "spConsultaUsuarios");

            lstUsuarios = (from item in Dt.AsEnumerable()
                           select new ConsultarUSUARIO
                           {
                               IdUsuario = item.Field<int>("idUsuario"),
                               Nombre = item.Field<string>("Nombre"),
                               APaterno = item.Field<string>("APaterno"),
                               AMaterno = item.Field<string>("AMaterno"),
                               Usuario = item.Field<string>("Usuario"),
                               Contra = item.Field<string>("Contra"),
                               IsActivo = item.Field<bool>("IsActivo"),
                               FecRegistro = item.Field<DateTime>("FecRegistro")
                           }
                           ).ToList<ConsultarUSUARIO>();

            return lstUsuarios;

        }
    }
}
