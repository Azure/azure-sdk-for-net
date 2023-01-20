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
    /// A Class representing a SubscriptionPolicySetDefinition along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SubscriptionPolicySetDefinitionResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSubscriptionPolicySetDefinitionResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" /> using the GetSubscriptionPolicySetDefinition method.
    /// </summary>
    public partial class SubscriptionPolicySetDefinitionResource : ArmResource, IOperationSource<SubscriptionPolicySetDefinitionResource>
    {
        SubscriptionPolicySetDefinitionResource IOperationSource<SubscriptionPolicySetDefinitionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PolicySetDefinitionData.DeserializePolicySetDefinitionData(document.RootElement);
            return new SubscriptionPolicySetDefinitionResource(Client, data);
        }

        async ValueTask<SubscriptionPolicySetDefinitionResource> IOperationSource<SubscriptionPolicySetDefinitionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PolicySetDefinitionData.DeserializePolicySetDefinitionData(document.RootElement);
            return new SubscriptionPolicySetDefinitionResource(Client, data);
        }
    }
}
