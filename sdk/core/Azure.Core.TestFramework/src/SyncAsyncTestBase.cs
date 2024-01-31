// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Core.TestFramework
{
    public class SyncAsyncTestBase
    {
        public bool IsAsync { get; }

        public SyncAsyncTestBase(bool isAsync)
        {
            IsAsync = isAsync;
        }

        protected MockTransport CreateMockTransport()
        {
            return new MockTransport()
            {
                ExpectSyncPipeline = !IsAsync
            };
        }

        protected MockTransport CreateMockTransport(Func<MockRequest, MockResponse> responseFactory)
        {
            return new MockTransport(responseFactory)
            {
                ExpectSyncPipeline = !IsAsync
            };
        }

        protected MockTransport CreateMockTransport(params MockResponse[] responses)
        {
            return new MockTransport(responses)
            {
                ExpectSyncPipeline = !IsAsync
            };
        }

        // Buffering in the transport will replace any mock stream a test is using
        // to validate the functional case it is testing. Use this method to create
        // a mock transport when the test needs the stream to be preserved to function
        // correctly.
        protected MockTransport CreateNonBufferingTransport(params MockResponse[] responses)
        {
            MockTransport transport = CreateMockTransport(responses);
            transport.BufferResponse = false;
            return transport;
        }

        protected Stream WrapStream(Stream stream)
        {
            return new AsyncValidatingStream(IsAsync, stream);
        }
    }
}
