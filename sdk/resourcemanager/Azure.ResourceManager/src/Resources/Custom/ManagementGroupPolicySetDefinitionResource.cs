// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Resources
{
    public partial class ManagementGroupPolicySetDefinitionResource : ArmResource, IOperationSource<ManagementGroupPolicySetDefinitionResource>
    {
        ManagementGroupPolicySetDefinitionResource IOperationSource<ManagementGroupPolicySetDefinitionResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PolicySetDefinitionData.DeserializePolicySetDefinitionData(document.RootElement);
            return new ManagementGroupPolicySetDefinitionResource(Client, data);
        }

        async ValueTask<ManagementGroupPolicySetDefinitionResource> IOperationSource<ManagementGroupPolicySetDefinitionResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PolicySetDefinitionData.DeserializePolicySetDefinitionData(document.RootElement);
            return new ManagementGroupPolicySetDefinitionResource(Client, data);
        }
    }
}
