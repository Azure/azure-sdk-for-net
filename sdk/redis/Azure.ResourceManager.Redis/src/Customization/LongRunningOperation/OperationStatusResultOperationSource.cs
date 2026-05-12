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

namespace Azure.ResourceManager.Redis
{
    // Generator-bug workaround: the MPG emitter generates a call to
    // OperationStatusResult.DeserializeOperationStatusResult(...), which is internal to
    // Azure.ResourceManager and inaccessible to consumer SDKs (CS0117). For cross-assembly
    // common types we must go through the public IPersistableModel<T> route via
    // ModelReaderWriter.Read<T>. Same workaround is in
    // Azure.ResourceManager.WorkloadsSapVirtualInstance, .LargeInstance, and .ComputeLimit.
    // Tracked: https://github.com/Azure/azure-sdk-for-net/issues/58709
    // TODO: delete this file once the emitter fix lands.
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
            return ModelReaderWriter.Read<OperationStatusResult>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerRedisContext.Default);
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        async ValueTask<OperationStatusResult> IOperationSource<OperationStatusResult>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return ModelReaderWriter.Read<OperationStatusResult>(new BinaryData(Encoding.UTF8.GetBytes(document.RootElement.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerRedisContext.Default);
        }
    }
}
