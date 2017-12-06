// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using FullDesktop.Tests.Helpers;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace FullDesktop.Tests.SpecTestSupport.Subscription
{
    public static class SubscriptionTestUtilities
    {
        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <returns>A subscription client, created from the current context (environment variables)</returns>
        public static SubscriptionDefinitionsClient GetSubscriptionDefinitionClientWithHandler(this TestBase testBase, MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<SubscriptionDefinitionsClient>(handlers: handler);
            return client;
        }
    }
}
