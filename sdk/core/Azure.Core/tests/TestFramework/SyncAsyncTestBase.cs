// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Core.Testing
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

        protected MockTransport CreateMockTransport(params MockResponse[] responses)
        {
            return new MockTransport(responses)
            {
                ExpectSyncPipeline = !IsAsync
            };
        }

        protected Stream WrapStream(Stream stream)
        {
            return new AsyncValidatingStream(IsAsync, stream);
        }
    }
}
