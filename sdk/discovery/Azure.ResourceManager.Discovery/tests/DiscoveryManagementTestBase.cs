// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Discovery.Tests
{
    // The scenario tests replay recordings for the Microsoft.Discovery resource provider.
    // This package does not provision live Discovery resources, so the tests execute in
    // playback only; running them live would target placeholder resource names.
    // Request bodies are not compared during matching (CompareBodies = false): the recordings
    // are adapted from service captures, so the request payload shape can differ while the URI,
    // method, and response remain identical.
    [PlaybackOnly("No live Discovery resources are provisioned for this package; recordings are used for playback.")]
    public class DiscoveryManagementTestBase : ManagementRecordedTestBase<DiscoveryManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected DiscoveryManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
            CompareBodies = false;
        }

        protected DiscoveryManagementTestBase(bool isAsync)
            : base(isAsync)
        {
            CompareBodies = false;
        }

        protected void InitializeClient()
        {
            Client = GetArmClient();
        }

        /// <summary>
        /// Returns a client-side reference to a resource group (no network call), so a test's only
        /// recorded traffic is the resource operation under test.
        /// </summary>
        protected ResourceGroupResource GetResourceGroupReference(string resourceGroupName)
        {
            ResourceIdentifier rgId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, resourceGroupName);
            return Client.GetResourceGroupResource(rgId);
        }

        /// <summary>Returns a client-side reference to the subscription (no network call).</summary>
        protected SubscriptionResource GetSubscriptionReference()
        {
            ResourceIdentifier subId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            return Client.GetSubscriptionResource(subId);
        }
    }
}
