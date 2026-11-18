// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Plugins
{
    #region Snippet:ServiceBus_TestableProcessor
    public sealed class TestableServiceBusProcessor : ServiceBusProcessor
    {
        public Task RaiseProcessMessageAsync(ProcessMessageEventArgs args) =>
            base.OnProcessMessageAsync(args);

        public Task RaiseProcessErrorAsync(ProcessErrorEventArgs args) =>
            base.OnProcessErrorAsync(args);
    }
    #endregion
}
