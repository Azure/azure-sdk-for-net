// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ClientRuntime.Tests.Common.Fakes;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;

namespace Microsoft.Rest.ClientRuntime.Tests.TransientFaultHandling
{
    public class RetryConditionTest
    {
        [Fact]
        public void PropertiesAreSetByConstrutor()
        {
            var condition = new RetryCondition(true, TimeSpan.FromSeconds(1));
            Assert.Equal(true, condition.RetryAllowed);
            Assert.Equal(TimeSpan.FromSeconds(1), condition.DelayBeforeRetry);

            condition = new RetryCondition(false, TimeSpan.Zero);
            Assert.Equal(false, condition.RetryAllowed);
            Assert.Equal(TimeSpan.Zero, condition.DelayBeforeRetry);
        }


        [Fact]
        public void InstantiateRetryDelegatingHandler()
        {
            RetryDelegatingHandler retryHandler = new RetryDelegatingHandler();
            FakeServiceClient fakeClient = new FakeServiceClient(new FakeHttpHandler(), retryHandler);

            var handlers = fakeClient.HttpMessageHandlers;
            if(handlers.Any<HttpMessageHandler>())
            {
                List<HttpMessageHandler> handlerList = handlers.ToList<HttpMessageHandler>();
                Assert.Equal(4, handlerList.Count);
            }
        }

    }
}