// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Management.Migrate.ResourceMover.Tests
{
    public class TestHelper : IDisposable
    {
        private const string subscriptionId = "e80eb9fa-c996-4435-aa32-5af6f3d3077c";

        public IResourceMoverServiceAPIClient ResourceMoverServiceClient { get; private set; }

        public TestHelper()
        {
        }

        public void Initialize(MockContext context)
        {
            this.ResourceMoverServiceClient = this.GetResourceMoverServiceClient(context);
            this.ResourceMoverServiceClient.SubscriptionId = subscriptionId;
        }

        public void Initialize(MockContext context, string subscriptionId)
        {
            this.ResourceMoverServiceClient = this.GetResourceMoverServiceClient(context);
            this.ResourceMoverServiceClient.SubscriptionId = subscriptionId;
        }

        public void Dispose()
        {
            ResourceMoverServiceClient.Dispose();
        }
    }
}