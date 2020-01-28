// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Testing
{
    public class TestProperties
    {
        public TestProperties(bool isAsync, object serviceVersion)
        {
            IsAsync = isAsync;
            ServiceVersion = serviceVersion;
        }

        public bool IsAsync { get; }
        public object ServiceVersion { get; }
    }
}
