// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// Attribute used to override the default ServiceBus account used by triggers and binders.
    /// </summary>
    /// <remarks>
    /// This attribute can be applied at the parameter/method/class level, and the precedence
    /// is in that order.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter)]
    public sealed class ServiceBusAccountAttribute : Attribute, IConnectionProvider
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="account">A string value indicating the Service Bus connection string to use. This
        /// string should be in one of the following formats. These checks will be applied in order and the
        /// first match wins.
        /// - The name of an "AzureWebJobs" prefixed app setting or connection string name. E.g., if your setting
        ///   name is "AzureWebJobsMyServiceBus", you can specify "MyServiceBus" here.
        /// - Can be a string containing %% values (e.g. %StagingServiceBus%). The value provided will be passed
        ///   to any INameResolver registered on the JobHostConfiguration to resolve the actual setting name to use.
        /// - Can be an app setting or connection string name of your choosing.
        /// </param>
        public ServiceBusAccountAttribute(string account)
        {
            Account = account;
        }

        /// <summary>
        /// Gets or sets the name of the app setting that contains the Service Bus connection string.
        /// </summary>
        public string Account { get; private set; }

        /// <summary>
        /// Gets or sets the app setting name that contains the Service Bus connection string.
        /// </summary>
        string IConnectionProvider.Connection
        {
            get
            {
                return Account;
            }
            set
            {
                Account = value;
            }
        }
    }
}
