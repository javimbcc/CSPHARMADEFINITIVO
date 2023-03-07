using DAL.Modelo;
using Npgsql;

namespace WebApplication1.Models.DTOs.DataToList
{
    /*
     * Clase que contiene el paso de la respuesta de la base de datos a lista DTO con los datos que nos interesan
     * @authior Jmenabc
     */
    public class loginToList
    {

        //metodo para convertir el resultado de la query en Lista
        public static List<DlkCatAccEmpleadoDTOcs> ReaderToList(NpgsqlDataReader resultadoConsulta)
        {
            List<DlkCatAccEmpleadoDTOcs> UserData = new List<DlkCatAccEmpleadoDTOcs>();
            while (resultadoConsulta.Read())
            {

                UserData.Add(new DlkCatAccEmpleadoDTOcs(

                        resultadoConsulta[2].ToString(),
                        resultadoConsulta[3].ToString(),
                        resultadoConsulta[4].ToString()
                        
                    ));

            }
            return UserData;
        }
    }
}
