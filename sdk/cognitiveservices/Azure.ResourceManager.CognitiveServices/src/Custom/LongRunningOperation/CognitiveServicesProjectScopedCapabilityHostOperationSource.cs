// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.CognitiveServices
{
    // This helper class is used by the CognitiveServicesProjectCapabilityHostCollection and CognitiveServicesProjectCapabilityHostResource customization code.
    /// <summary></summary>
    internal partial class CognitiveServicesProjectCapabilityHostOperationSource : IOperationSource<CognitiveServicesProjectCapabilityHostResource>
    {
        private readonly ArmClient _client;

        /// <summary></summary>
        /// <param name="client"></param>
        internal CognitiveServicesProjectCapabilityHostOperationSource(ArmClient client)
        {
            _client = client;
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        CognitiveServicesProjectCapabilityHostResource IOperationSource<CognitiveServicesProjectCapabilityHostResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            CognitiveServicesCapabilityHostData data = CognitiveServicesCapabilityHostData.DeserializeCognitiveServicesCapabilityHostData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new CognitiveServicesProjectCapabilityHostResource(_client, data);
        }

        /// <param name="response"> The response from the service. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        async ValueTask<CognitiveServicesProjectCapabilityHostResource> IOperationSource<CognitiveServicesProjectCapabilityHostResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            CognitiveServicesCapabilityHostData data = CognitiveServicesCapabilityHostData.DeserializeCognitiveServicesCapabilityHostData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new CognitiveServicesProjectCapabilityHostResource(_client, data);
        }
    }
}
