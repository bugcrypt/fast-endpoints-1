namespace Endpoints.Forms;

public abstract class FormVM
{
    public required int Id { get; set; }
    public required int DataSourceId { get; set; }
    public required int? ActionType { get; set; }
    public required FormData Data { get; set; }
}
