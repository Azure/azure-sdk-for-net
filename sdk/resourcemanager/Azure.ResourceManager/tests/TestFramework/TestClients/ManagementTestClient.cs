// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.Tests;

namespace Azure.Core.TestFramework.Tests
{
    public class ManagementTestClient
    {
        private readonly ClientDiagnostics _diagnostics;

        public ManagementTestClient() : this(null)
        {
        }

        public ManagementTestClient(TestClientOptions options)
        {
            options ??= new TestClientOptions();
            _diagnostics = new ClientDiagnostics(options);
        }

        public virtual TestResource GetTestResource()
        {
            return new TestResource();
        }

        public virtual TestResourceCollection GetTestResourceCollection()
        {
            return new TestResourceCollection();
        }

        public virtual TestResource DefaultSubscription => new TestResource();

        public virtual string Method()
        {
            return "success";
        }
    }
}
