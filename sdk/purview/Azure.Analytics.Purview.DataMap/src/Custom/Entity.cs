// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Purview.DataMap;

public partial class Entity
{
    // CUSTOM CODE NOTE:
    //   This file is the central hub of .NET client customization for Purview DataMap.

    /// <summary> Upload the file for creating Business Metadata in BULK. </summary>
    /// <param name="file"> InputStream of file. </param>
    /// <param name="cancellationToken"> The cancellation token to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
    public virtual Response<BulkImportResult> ImportBusinessMetadata(BinaryData file, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(file, nameof(file));

        RequestContext context = new RequestContext { CancellationToken = cancellationToken };
        BusinessMetadataOptions businessMetadataOptions = new BusinessMetadataOptions(file);
        using MultiPartFormDataRequestContent content = (MultiPartFormDataRequestContent)businessMetadataOptions.ToRequestContent();
        Response response = ImportBusinessMetadata(content, content.ContentType, context);
        return Response.FromValue(BulkImportResult.DeserializeBulkImportResult(JsonDocument.Parse(response.Content).RootElement, new ModelReaderWriterOptions("W")), response);
    }
}
