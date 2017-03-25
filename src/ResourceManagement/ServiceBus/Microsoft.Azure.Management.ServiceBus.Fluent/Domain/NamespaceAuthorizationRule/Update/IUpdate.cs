// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRule.Update
{
    using Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Update;
    using Microsoft.Azure.Management.Servicebus.Fluent;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of the namespace authorization rule update.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Servicebus.Fluent.INamespaceAuthorizationRule>,
        IWithListenOrSendOrManage<Microsoft.Azure.Management.Servicebus.Fluent.NamespaceAuthorizationRule.Update.IUpdate>
    {
    }
}