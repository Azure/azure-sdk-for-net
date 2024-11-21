// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Azure.Messaging.WebPubSub;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using Moq;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class TestExtensionConfig : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<BindingDataAttribute>().
                BindToInput(attr => attr.ToBeAutoResolve);

            var rule1 = context.AddBindingRule<SocketIOAttribute>();
            rule1.BindToCollector(CreateTestCollector);
        }

        private object Mock<T>()
        {
            throw new NotImplementedException();
        }

        private IAsyncCollector<SocketIOAction> CreateTestCollector(SocketIOAttribute attribute)
        {
            var service = new Mock<WebPubSubServiceClient>();
            //service.Setup(x => x.SendToAll(It.IsAny<RequestContent>(), It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
            //    .Returns(new MockResponse(200));
            var store = new SocketLifetimeStore();
            return new WebPubSubForSocketIOAsyncCollector(new WebPubSubForSocketIOService(service.Object), store);
        }

        [Binding]
        private sealed class BindingDataAttribute : Attribute
        {
            public BindingDataAttribute(string toBeAutoResolve)
            {
                ToBeAutoResolve = toBeAutoResolve;
            }

            [AutoResolve]
            public string ToBeAutoResolve { get; set; }
        }
    }
}
