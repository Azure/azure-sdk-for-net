// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Kubernetes;

namespace Azure.ResourceManager.ContainerOrchestratorRuntime.Tests
{
    public class ContainerOrchestratorRuntimeManagementTestEnvironment : TestEnvironment
    {
        public ResourceIdentifier ConnectedCluster = ConnectedClusterResource.CreateResourceIdentifier("b9e38f20-7c9c-4497-a25d-1a0c5eef2108", "xinyuhe-canary", "test-cluster-euap-arc");
    }
}