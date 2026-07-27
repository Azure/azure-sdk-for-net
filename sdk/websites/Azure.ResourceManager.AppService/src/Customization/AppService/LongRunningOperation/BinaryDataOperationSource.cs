// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    internal partial class BinaryDataOperationSource : IOperationSource<BinaryData>
    {
        internal BinaryDataOperationSource()
        {
        }

        BinaryData IOperationSource<BinaryData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            return ModelReaderWriter.Read<BinaryData>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerAppServiceContext.Default);
        }

        async ValueTask<BinaryData> IOperationSource<BinaryData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return ModelReaderWriter.Read<BinaryData>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerAppServiceContext.Default);
        }
    }
}
