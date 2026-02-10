using Endpoints.Forms.Form1;
using FastEndpoints;

namespace Endpoints.Forms;

public class GetEndpoint : EndpointWithoutRequest<FormVM>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("api/data");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Form1VM f = new()
        {
            Id = 2,
            DataSourceId = 3,
            RecordId = "12345",
            ActionType = 1,
            Data = new Form1Data
            {
                Month = 1,
                Year = 2021,
                Period = 5
            }
        };
        
        await Send.OkAsync(f, ct);
    }
}