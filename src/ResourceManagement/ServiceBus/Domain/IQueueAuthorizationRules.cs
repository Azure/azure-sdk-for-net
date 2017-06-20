// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.QueueAuthorizationRule.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent;

    /// <summary>
    /// Entry point to queue authorization rules management API.
    /// </summary>
    public interface IQueueAuthorizationRules  :
        IBeta,
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRules<Microsoft.Azure.Management.ServiceBus.Fluent.IQueueAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<QueueAuthorizationRule.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<IQueuesOperations>
    {
    }
}