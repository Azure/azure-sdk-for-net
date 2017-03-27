// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.QueueAuthorizationRule.Update
{
    using Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Update;
    using Microsoft.Azure.Management.Servicebus.Fluent;
    using ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The entirety of the queue authorization rule update.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule>,
        IWithListenOrSendOrManage<Microsoft.Azure.Management.Servicebus.Fluent.QueueAuthorizationRule.Update.IUpdate>
    {
    }
}