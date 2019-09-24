// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace Azure.Core.Extensions.Tests
{
    internal class TestClientOptionsMultipleParameters : ClientOptions
    {
        public string OtherParameter { get; }
        public ServiceVersion Version { get; }

        public enum ServiceVersion
        {
            A,
            B,
            C,
            D
        }
        public TestClientOptionsMultipleParameters(string otherParameter = "some default value", ServiceVersion version = ServiceVersion.D)
        {
            OtherParameter = otherParameter;
            Version = version;
        }
    }
}