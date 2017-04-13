// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using ServiceBus.Fluent;

    /// <summary>
    /// Entry point to authorization rules management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    /// <typeparam name="RuleT">The specific rule type.</typeparam>
    public interface IAuthorizationRules<RuleT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<RuleT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<RuleT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<IServiceBusManager>
    {
    }
}