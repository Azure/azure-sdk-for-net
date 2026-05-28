// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net.Http;
using System.Net.Http.Headers;

namespace Azure.AI.Agents.Persistent;

internal partial class UploadFileRequest
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Manual, custom multipart/form-data serialization needed.
     *
     */

    internal virtual MultiPartFormDataRequestContent ToMultipartRequestContent()
    {
        MultiPartFormDataRequestContent content = new();
        ContentDispositionHeaderValue header = new("form-data") { Name = "file" };
        var _dataStream = new StreamContent(Data.ToStream());
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
