namespace SistemaEscolar.Domain.Entities;

public class Estudiante : BaseEntity
{
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; private set; } = string.Empty;
    public string Matricula { get; private set; } = string.Empty;
    public string CorreoElectronico { get; private set; } = string.Empty;

    private readonly List<Calificacion> _calificaciones = new();
    public IReadOnlyCollection<Calificacion> Calificaciones => _calificaciones.AsReadOnly();

    public Estudiante(string nombre, string apellido, string matricula, string correoElectronico)
    {
        ActualizarDatos(nombre, apellido, correoElectronico);
        Matricula = matricula;
    }

    public void ActualizarDatos(string nombre, string apellido, string correoElectronico)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es requerido.");
        if (string.IsNullOrWhiteSpace(apellido)) throw new ArgumentException("El apellido es requerido.");
        if (!correoElectronico.Contains('@')) throw new ArgumentException("El correo no es válido.");

        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correoElectronico;
        FechaModificacion = DateTime.UtcNow;
    }
}