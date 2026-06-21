namespace SistemaEscolar.Domain.Entities;

public class Profesor : BaseEntity
{
    public string Nombre { get; private set; } = string.Empty;
    public string Apellido { get; private set; } = string.Empty;
    public string CorreoElectronico { get; private set; } = string.Empty;

    public Profesor(string nombre, string apellido, string correoElectronico)
    {
        if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            throw new ArgumentException("Nombre y apellido son obligatorios.");
        
        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correoElectronico;
    }
}