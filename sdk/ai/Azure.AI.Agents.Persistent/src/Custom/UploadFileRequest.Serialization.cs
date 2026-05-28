// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net.Http;
using System.Net.Http.Headers;
using Azure.Core;

namespace Azure.AI.Agents.Persistent;

internal partial class UploadFileRequest : IUtf8JsonSerializable
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Manual, custom multipart/form-data serialization needed.
     *
     */

    internal virtual MultipartFormDataRequestContent ToMultipartRequestContent()
    {
        MultipartFormDataRequestContent content = new();
        ContentDispositionHeaderValue header = new("form-data") { Name = "file"};
        var _dataStream = new StreamContent(Data);
        if (System.Linq.Enumerable.Any(Filename, c => c > 127))
        {
            header.FileNameStar = Filename;
        }
        else
        {
            header.FileName = Filename;
        }
        _dataStream.Headers.ContentDisposition = header;
        (content.HttpContent as System.Net.Http.MultipartFormDataContent).Add(_dataStream, "file");
        content.Add(Purpose.ToString(), "purpose");
        return content;
    }
}
