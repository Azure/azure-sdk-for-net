// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Analytics.Purview.DataMap;
internal partial class ImportBusinessMetadataRequest
{
    // CUSTOM CODE NOTE:
    // Implement custom serialization code to compose a request with Content-Type:
    // multipart/form-data, which currently cannot be auto-generated.

    public String FileName { get; set; }

    internal virtual RequestContent ToRequestContent()
    {
        MultipartFormDataContent content = new MultipartFormDataContent();
        content.Add(MultipartContent.Create(File), "file", FileName, null);
        return content;
    }

    public ImportBusinessMetadataRequest(BinaryData file, String fileName)
    {
        Argument.AssertNotNull(file, nameof(file));

        File = file;
        FileName = fileName;
    }

    /// <summary> Initializes a new instance of <see cref="ImportBusinessMetadataRequest"/>. </summary>
    /// <param name="file"> InputStream of file. </param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="fileName"> Name of file. </param>
    internal ImportBusinessMetadataRequest(BinaryData file, IDictionary<string, BinaryData> serializedAdditionalRawData, String fileName)
    {
        File = file;
        FileName = fileName;
        _serializedAdditionalRawData = serializedAdditionalRawData;
    }
}
