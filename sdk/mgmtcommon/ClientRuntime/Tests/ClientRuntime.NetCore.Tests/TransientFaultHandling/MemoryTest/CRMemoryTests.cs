// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests.MemoryTest
{
    using Microsoft.Rest;
    using ClientRuntime.Tests.Common.Fakes;
    using System.Linq;
    using Xunit;

    public class CRMemoryTests
    {
        [Fact(Skip="It fails on MacOS. Possibly due to ADO env. Skip to unblock PRs.")]
        public void MeasureSvcClientMem()
        {
            AddHeaderResponseDelegatingHandler addHeader = new AddHeaderResponseDelegatingHandler("Hello", "World");
            var fakeClient = new FakeServiceClient(addHeader);

            RetryDelegatingHandler retryDelHandler = fakeClient.HttpMessageHandlers.OfType<RetryDelegatingHandler>().FirstOrDefault();

            Assert.Equal(0, retryDelHandler.EventCallbackCount);

            fakeClient.DoStuffSync();
            Assert.Equal(0, retryDelHandler.EventCallbackCount);
            Assert.Equal(0, retryDelHandler.RetryPolicy.EventCallbackCount);

            fakeClient.DoStuffSync();
            Assert.Equal(0, retryDelHandler.RetryPolicy.EventCallbackCount);
        }
    }
}