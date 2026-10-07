// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Plugins
{
    #region Snippet:ServiceBus_TestableSessionProcessor
    public sealed class TestableServiceBusSessionProcessor : ServiceBusSessionProcessor
    {
        protected override ServiceBusProcessor InnerProcessor { get; } =
            new TestableServiceBusProcessor();

        public Task RaiseProcessMessageAsync(ProcessSessionMessageEventArgs args) =>
            base.OnProcessSessionMessageAsync(args);

        public Task RaiseProcessErrorAsync(ProcessErrorEventArgs args) =>
            base.OnProcessErrorAsync(args);

        public Task RaiseSessionInitializingAsync(ProcessSessionEventArgs args) =>
            base.OnSessionInitializingAsync(args);

        public Task RaiseSessionClosingAsync(ProcessSessionEventArgs args) =>
            base.OnSessionClosingAsync(args);
    }
    #endregion
}
