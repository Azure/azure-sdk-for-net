// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Update
{
    /// <summary>
    /// The stage of the Service Bus authorization rule update allowing to enable send policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the update.</typeparam>
    public interface IWithSend<T> 
    {
        /// <return>The next stage of the update.</return>
        T WithSendingEnabled();
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule update allowing to enable listen, send or manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the update.</typeparam>
    public interface IWithListenOrSendOrManage<T>  :
        Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Update.IWithListen<T>,
        Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Update.IWithSendOrManage<T>
    {
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule update allowing to enable send or manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the update.</typeparam>
    public interface IWithSendOrManage<T>  :
        Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Update.IWithSend<T>,
        Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Update.IWithManage<T>
    {
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule update allowing to enable listen policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the update.</typeparam>
    public interface IWithListen<T> 
    {
        /// <return>The next stage of the update.</return>
        T WithListeningEnabled();
    }

    /// <summary>
    /// The stage of Service Bus authorization rule update allowing to enable manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the update.</typeparam>
    public interface IWithManage<T> 
    {
        /// <return>The next stage of the update.</return>
        T WithManagementEnabled();
    }
}