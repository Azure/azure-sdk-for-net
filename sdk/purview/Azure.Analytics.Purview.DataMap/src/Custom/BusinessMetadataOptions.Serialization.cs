// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Purview.DataMap;
public partial class BusinessMetadataOptions
{
    // CUSTOM CODE NOTE:
    // Implement custom serialization code to compose a request with Content-Type:
    // multipart/form-data, which currently cannot be auto-generated.

    internal virtual RequestContent ToRequestContent()
    {
        MultipartFormDataContent content = new MultipartFormDataContent();
        content.Add(MultipartContent.Create(File), "file", "file.csv", null);
        return content;
    }
}
