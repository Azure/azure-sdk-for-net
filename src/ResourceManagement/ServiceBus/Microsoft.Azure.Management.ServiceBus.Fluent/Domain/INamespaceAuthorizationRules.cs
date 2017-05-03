// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition;
    using Microsoft.Azure.Management.ServiceBus.Fluent;

    /// <summary>
    /// Entry point to namespace authorization rules management API.
    /// </summary>
    public interface INamespaceAuthorizationRules  :
        IBeta,
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRules<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<NamespaceAuthorizationRule.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ServiceBus.Fluent.INamespacesOperations>
    {
    }
}