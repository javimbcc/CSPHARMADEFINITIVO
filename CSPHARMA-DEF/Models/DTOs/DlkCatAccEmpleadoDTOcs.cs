namespace WebApplication1.Models.DTOs
{
    /*
     * Clase Empleado DTO en el que recogemos el codigo de empleado
     * la clave y el nivel de acceso
     * @author Jmenabc
     */
    public class DlkCatAccEmpleadoDTOcs
    {

        //Atributos
        private string codEmpleado;

        private string claveEmpleado;

        private string nivelAccesoEmpleado;

        //Getter y setter

        public string CodEmpleado { get => codEmpleado; set => codEmpleado = value; }
        public string ClaveEmpleado { get => claveEmpleado; set => claveEmpleado = value; }
        public string NivelAccesoEmpleado { get => nivelAccesoEmpleado; set => nivelAccesoEmpleado = value; }

        //Constructor

        public DlkCatAccEmpleadoDTOcs(string CodEmpleado, string ClaveEmpleado, string NivelAccesoEmpleado)
        {

            this.CodEmpleado = CodEmpleado;
            this.ClaveEmpleado = ClaveEmpleado;
            this.NivelAccesoEmpleado = NivelAccesoEmpleado;

        }


    }
}
