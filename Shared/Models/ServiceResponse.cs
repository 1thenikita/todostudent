namespace TodoStudent.Shared.Models;

/// <summary>
/// Model for return result from service/endpoint.
/// </summary>
/// <typeparam name="T">Output entity.</typeparam>
public class ServiceResponse<T>
{
    /// <summary>
    /// Status of Response.
    /// </summary>
    public bool Status { get; set; }
    /// <summary>
    /// Name of Status Response (Success, Error, Verbose, etc.)
    /// </summary>
    public string Name { get; set; } = "Ошибка не указана.";
    
    /// <summary>
    /// Output entity.
    /// </summary>
    public T? Data { get; set; }
}