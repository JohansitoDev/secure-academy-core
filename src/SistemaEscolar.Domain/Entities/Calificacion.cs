namespace SistemaEscolar.Domain.Entities;

public class Calificacion : BaseEntity
{
    public Guid EstudianteId { get; private set; }
    public Guid AsignaturaId { get; private set; }
    public int NotaTeorica { get; private set; }
    public int NotaPractica { get; private set; }
    public int NotaFinal => NotaTeorica + NotaPractica;

    public Calificacion(Guid estudianteId, Guid asignaturaId, int notaTeorica, int notaPractica)
    {
        EstudianteId = estudianteId;
        AsignaturaId = asignaturaId;
        AsignarNotas(notaTeorica, notaPractica);
    }

    public void AsignarNotas(int notaTeorica, int notaPractica)
    {
        if (notaTeorica < 0 || notaTeorica > 40) 
            throw new ArgumentOutOfRangeException(nameof(notaTeorica), "La nota teórica debe estar entre 0 y 40.");
        
        if (notaPractica < 0 || notaPractica > 60) 
            throw new ArgumentOutOfRangeException(nameof(notaPractica), "La nota práctica debe estar entre 0 y 60.");

        NotaTeorica = notaTeorica;
        NotaPractica = notaPractica;
        FechaModificacion = DateTime.UtcNow;
    }
}