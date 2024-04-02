// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.Purview.DataMap;

public partial class BusinessMetadataOptions
{
    // CUSTOM CODE NOTE:
    // Implement custom serialization code to compose a request with Content-Type:
    // multipart/form-data, which currently cannot be auto-generated.

    internal virtual MultipartFormDataBinaryContent ToMultipartContent()
    {
        MultipartFormDataBinaryContent content = new();
        content.Add(File, "file", "file.csv");
        return content;
    }
}
