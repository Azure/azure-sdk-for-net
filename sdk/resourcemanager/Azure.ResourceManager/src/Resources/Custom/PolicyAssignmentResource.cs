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
    /// A Class representing a PolicyAssignment along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="PolicyAssignmentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetPolicyAssignmentResource method.
    /// Otherwise you can get one from its parent resource <see cref="ArmResource" /> using the GetPolicyAssignment method.
    /// </summary>
    public partial class PolicyAssignmentResource : ArmResource, IOperationSource<PolicyAssignmentResource>
    {
        PolicyAssignmentResource IOperationSource<PolicyAssignmentResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PolicyAssignmentData.DeserializePolicyAssignmentData(document.RootElement);
            return new PolicyAssignmentResource(Client, data);
        }

        async ValueTask<PolicyAssignmentResource> IOperationSource<PolicyAssignmentResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PolicyAssignmentData.DeserializePolicyAssignmentData(document.RootElement);
            return new PolicyAssignmentResource(Client, data);
        }
    }
}
