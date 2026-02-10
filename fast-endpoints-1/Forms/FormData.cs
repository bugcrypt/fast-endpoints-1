using System.Text.Json.Serialization;

namespace Endpoints.Forms;

[JsonConverter(typeof(FormDataConverter))]
public abstract class FormData
{
    public int DataSourceId { get; set; } = 5; 
    public string? Data1 { get; set; }
}
