// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Definition;
    using Management.ServiceBus.Fluent.Models;

    /// <summary>
    /// Entry point to namespace authorization rules management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface INamespaceAuthorizationRules  :
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRules<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<NamespaceAuthorizationRule.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<INamespacesOperations>
    {
    }
}