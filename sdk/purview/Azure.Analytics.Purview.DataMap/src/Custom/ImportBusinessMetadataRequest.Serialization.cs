using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace Azure.Analytics.Purview.DataMap;

public partial class ImportBusinessMetadataRequest
{
    // CUSTOM CODE NOTE:
    // Implement custom serialization code to compose a request with Content-Type:
    // multipart/form-data, which currently cannot be auto-generated.

    internal virtual RequestContent ToRequestContent()
    {
        MultipartFormDataContent content = new MutipartFormDataContent();
        content.Add(MultipartContent.Create(File), new Dictionary<string, string>()
        {
            ["Content-Disposition"] = $"form-data; name=file; filename=file",
            ["Content-Type"] = "multipart/form-data",
        });
        return content;
    }

}

