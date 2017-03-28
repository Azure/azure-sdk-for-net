// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent.AuthorizationRule.Definition
{
    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable listen, send or manage policy.
    /// </summary>
    /// <typeparam name="">The next stage of the definition.</typeparam>
    public interface IWithListenOrSendOrManage<T>  :
        IWithListen<T>,
        IWithSendOrManage<T>
    {
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable manage policy.
    /// </summary>
    /// <typeparam name="">The next stage of the definition.</typeparam>
    public interface IWithManage<T> 
    {
        /// <return>The next stage of the definition.</return>
        T WithManagementEnabled();
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable send or manage policy.
    /// </summary>
    /// <typeparam name="">The next stage of the definition.</typeparam>
    public interface IWithSendOrManage<T>  :
        IWithSend<T>,
        IWithManage<T>
    {
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable send policy.
    /// </summary>
    /// <typeparam name="">The next stage of the definition.</typeparam>
    public interface IWithSend<T> 
    {
        /// <return>The next stage of the definition.</return>
        T WithSendingEnabled();
    }

    /// <summary>
    /// The stage of the Service Bus authorization rule definition allowing to enable listen policy.
    /// </summary>
    /// <typeparam name="">The next stage of the definition.</typeparam>
    public interface IWithListen<T> 
    {
        /// <return>The next stage of the definition.</return>
        T WithListeningEnabled();
    }
}