// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec operation is generated as a collection CreateOrUpdate call, but GA also exposed resource-level Update methods; forward those GA methods to the generated collection operation.
    public partial class SecurityAutomationResource
    {
        /// <summary> Updates a security automation. </summary>
        public virtual Task<ArmOperation<SecurityAutomationResource>> UpdateAsync(WaitUntil waitUntil, SecurityAutomationData data, CancellationToken cancellationToken = default)
            => new SecurityAutomationCollection(Client, ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName)).CreateOrUpdateAsync(waitUntil, Id.Name, data, cancellationToken);

        /// <summary> Updates a security automation. </summary>
        public virtual ArmOperation<SecurityAutomationResource> Update(WaitUntil waitUntil, SecurityAutomationData data, CancellationToken cancellationToken = default)
            => new SecurityAutomationCollection(Client, ResourceGroupResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName)).CreateOrUpdate(waitUntil, Id.Name, data, cancellationToken);
    }
}
