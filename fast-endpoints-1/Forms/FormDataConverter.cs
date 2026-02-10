using System.Text.Json;
using System.Text.Json.Serialization;
using Endpoints.Forms.Form1;

namespace Endpoints.Forms;

public class FormDataConverter : JsonConverter<FormData>
{
    public override FormData? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDoc.RootElement;
        if (!jsonObject.TryGetProperty("DataSourceId", out var typeProp))
            if (!jsonObject.TryGetProperty("dataSourceId", out typeProp))
                throw new JsonException("Missing Datasource Id.");
        
        int x = typeProp.GetInt32();
        
        FormData? result = null;
        if (x == 5)
        {
            result = JsonSerializer.Deserialize<Form1Data>(jsonObject.GetRawText(), options);
        } 
        // else if () // ADD MORE FORMS HERE
        // {
        //     
        // }
        
        return result;
    }

    public override void Write(Utf8JsonWriter writer, FormData value, JsonSerializerOptions options)
    {
        var clone = new JsonSerializerOptions(options);
        clone.Converters.Remove(this);

        switch (value)
        {
            case Form1Data form:
                JsonSerializer.Serialize(writer, form, clone);
                break;
            // case Form2Data form2:
            //     JsonSerializer.Serialize(writer, form2, clone);
            //     break;
        }
    }
}
