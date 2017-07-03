// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition
{
    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable listen, send or manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithListenOrSendOrManage<T>  :
        Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition.IWithListen<T>,
        Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition.IWithSendOrManage<T>
    {
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithManage<T> 
    {
        /// <return>The next stage of the definition.</return>
        T WithManagementEnabled();
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable send or manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithSendOrManage<T>  :
        Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition.IWithSend<T>,
        Microsoft.Azure.Management.ServiceBus.Fluent.AuthorizationRule.Definition.IWithManage<T>
    {
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable send policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithSend<T> 
    {
        /// <return>The next stage of the definition.</return>
        T WithSendingEnabled();
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable listen policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithListen<T> 
    {
        /// <return>The next stage of the definition.</return>
        T WithListeningEnabled();
    }
}