// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;

    public class ServiceBusEntityConnection : ServiceBusConnection
    {
        public ServiceBusEntityConnection(string entityConnectionString)
            : this(entityConnectionString, Constants.DefaultOperationTimeout, RetryPolicy.Default)
        {
        }

        public ServiceBusEntityConnection(string entityConnectionString, TimeSpan operationTimeout, RetryPolicy retryPolicy)
            : base(operationTimeout, retryPolicy)
        {
            if (string.IsNullOrWhiteSpace(entityConnectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(entityConnectionString));
            }

            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(entityConnectionString);

            if (string.IsNullOrWhiteSpace(builder.EntityPath))
            {
                throw Fx.Exception.Argument(nameof(entityConnectionString), "EntityConnectionString should contain EntityPath.");
            }

            this.InitializeConnection(builder);
            this.EntityPath = builder.EntityPath;
        }

        public string EntityPath { get; }
    }
}