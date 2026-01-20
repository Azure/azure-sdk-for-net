// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.LargeInstance
{
    /// <summary></summary>
    internal partial class OperationStatusResultOperationSource : IOperationSource<OperationStatusResult>
    {
        /// <summary></summary>
        internal OperationStatusResultOperationSource()
        {
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        OperationStatusResult IOperationSource<OperationStatusResult>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            return ModelReaderWriter.Read<OperationStatusResult>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerLargeInstanceContext.Default);
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        async ValueTask<OperationStatusResult> IOperationSource<OperationStatusResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return ModelReaderWriter.Read<OperationStatusResult>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerLargeInstanceContext.Default);
        }
    }
}
