// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Resources
{
    /// <summary>
    /// A Class representing a SubscriptionPolicyDefinition along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SubscriptionPolicyDefinitionResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSubscriptionPolicyDefinitionResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" /> using the GetSubscriptionPolicyDefinition method.
    /// </summary>
    public partial class SubscriptionPolicyDefinitionResource : ArmResource, IOperationSource<SubscriptionPolicyDefinitionResource>
    {
        SubscriptionPolicyDefinitionResource IOperationSource<SubscriptionPolicyDefinitionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PolicyDefinitionData.DeserializePolicyDefinitionData(document.RootElement);
            return new SubscriptionPolicyDefinitionResource(Client, data);
        }

        async ValueTask<SubscriptionPolicyDefinitionResource> IOperationSource<SubscriptionPolicyDefinitionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PolicyDefinitionData.DeserializePolicyDefinitionData(document.RootElement);
            return new SubscriptionPolicyDefinitionResource(Client, data);
        }
    }
}
