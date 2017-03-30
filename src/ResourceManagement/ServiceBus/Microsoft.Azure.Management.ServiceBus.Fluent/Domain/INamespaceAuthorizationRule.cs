// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using NamespaceAuthorizationRule.Update;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// Type representing authorization rule defined for namespace.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface INamespaceAuthorizationRule  :
        IAuthorizationRule<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule>,
        IUpdatable<NamespaceAuthorizationRule.Update.IUpdate>
    {
        /// <summary>
        /// Gets the name of the parent namespace name.
        /// </summary>
        string NamespaceName { get; }
    }
}