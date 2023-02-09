namespace WebApplication1.Models.DTOs
{
    /*
     * Clase Empleado DTO en el que recogemos el codigo de empleado
     * la clave y el nivel de acceso
     * @author Jmenabc
     */
    public class DlkCatAccEmpleadoDTOcs
    {
        public string CodEmpleado { get; set; }

        public string ClaveEmpleado { get; set; } = null!;

        public string NivelAccesoEmpleado { get; set; }


        public DlkCatAccEmpleadoDTOcs(string CodEmpleado, string ClaveEmpleado, string NivelAccesoEmpleado)
        {

            this.CodEmpleado = CodEmpleado;
            this.ClaveEmpleado = ClaveEmpleado;
            this.NivelAccesoEmpleado = NivelAccesoEmpleado;

        }
    }
}
