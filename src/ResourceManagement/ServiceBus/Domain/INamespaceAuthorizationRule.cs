// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ServiceBus.Fluent.NamespaceAuthorizationRule.Update;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Type representing authorization rule defined for namespace.
    /// </summary>
    public interface INamespaceAuthorizationRule  :
        IBeta,
        Microsoft.Azure.Management.ServiceBus.Fluent.IAuthorizationRule<Microsoft.Azure.Management.ServiceBus.Fluent.INamespaceAuthorizationRule>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<NamespaceAuthorizationRule.Update.IUpdate>
    {
        /// <summary>
        /// Gets the name of the parent namespace name.
        /// </summary>
        string NamespaceName { get; }
    }
}