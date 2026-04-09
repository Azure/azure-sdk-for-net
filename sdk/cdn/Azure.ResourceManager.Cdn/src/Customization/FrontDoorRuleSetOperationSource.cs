// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Cdn
{
    // Operation source for FrontDoorRuleSetResource LRO operations.
    // Custom: This class is added because the TypeSpec uses Legacy.CustomPatchAsync
    // instead of ArmResourceCreateOrReplaceSync, so the generator does not produce
    // an OperationSource for FrontDoorRuleSet.
    internal partial class FrontDoorRuleSetOperationSource : IOperationSource<FrontDoorRuleSetResource>
    {
        private readonly ArmClient _client;

        internal FrontDoorRuleSetOperationSource(ArmClient client)
        {
            _client = client;
        }

        FrontDoorRuleSetResource IOperationSource<FrontDoorRuleSetResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = JsonDocument.Parse(response.ContentStream);
            FrontDoorRuleSetData data = FrontDoorRuleSetData.DeserializeFrontDoorRuleSetData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new FrontDoorRuleSetResource(_client, data);
        }

        async ValueTask<FrontDoorRuleSetResource> IOperationSource<FrontDoorRuleSetResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using JsonDocument document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            FrontDoorRuleSetData data = FrontDoorRuleSetData.DeserializeFrontDoorRuleSetData(document.RootElement, ModelSerializationExtensions.WireOptions);
            return new FrontDoorRuleSetResource(_client, data);
        }
    }
}
