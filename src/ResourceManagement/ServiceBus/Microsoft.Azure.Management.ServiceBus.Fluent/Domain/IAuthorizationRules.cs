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
    public interface IAuthorizationRules<RuleT>  :
        ISupportsGettingByName<RuleT>,
        ISupportsDeletingByName,
        IHasManager<IServiceBusManager>
    {
    }
}