// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;
    using ServiceBus.Fluent;

    /// <summary>
    /// Entry point to authorization rules management API.
    /// </summary>
    /// <typeparam name="Rule">The specific rule type.</typeparam>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IAuthorizationRules<RuleT>  :
        ISupportsGettingByName<RuleT>,
        ISupportsListing<RuleT>,
        ISupportsDeletingByName,
        IHasManager<IServiceBusManager>
    {
    }
}