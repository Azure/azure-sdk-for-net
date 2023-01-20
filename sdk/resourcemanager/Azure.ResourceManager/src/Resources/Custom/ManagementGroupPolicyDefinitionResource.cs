// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Resources
{
    public partial class ManagementGroupPolicyDefinitionResource : ArmResource, IOperationSource<ManagementGroupPolicyDefinitionResource>
    {
        ManagementGroupPolicyDefinitionResource IOperationSource<ManagementGroupPolicyDefinitionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PolicyDefinitionData.DeserializePolicyDefinitionData(document.RootElement);
            return new ManagementGroupPolicyDefinitionResource(Client, data);
        }

        async ValueTask<ManagementGroupPolicyDefinitionResource> IOperationSource<ManagementGroupPolicyDefinitionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PolicyDefinitionData.DeserializePolicyDefinitionData(document.RootElement);
            return new ManagementGroupPolicyDefinitionResource(Client, data);
        }
    }
}
