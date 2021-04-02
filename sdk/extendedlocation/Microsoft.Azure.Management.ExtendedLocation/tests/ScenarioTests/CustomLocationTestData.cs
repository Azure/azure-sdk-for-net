// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ExtendedLocation.Tests.ScenarioTests
{
    /// <summary>
    /// Class that represents the Cluster
    /// </summary>
    public class CustomLocationTestData
    {
        public const string ResourceGroup = "e2e-testing-rg";
        public const string Location = "eastus";
        public const string CassandraTest = "/subscriptions/a5015e1c-867f-4533-8541-85cd470d0cfb/resourceGroups/e2e-testing-rg/providers/Microsoft.Kubernetes/connectedClusters/cldfe2econnectedcluster/providers/Microsoft.KubernetesConfiguration/extensions/cli-test-operator";
        public const string AnsibleTest = "/subscriptions/a5015e1c-867f-4533-8541-85cd470d0cfb/resourceGroups/e2e-testing-rg/providers/Microsoft.Kubernetes/connectedClusters/cldfe2econnectedcluster/providers/Microsoft.KubernetesConfiguration/extensions/cli-test-operator-ansible";
        public const string NamespaceTest = "cli-operator-namespace";
        public const string HostResourceIdTest = "subscriptions/a5015e1c-867f-4533-8541-85cd470d0cfb/resourceGroups/e2e-testing-rg/providers/Microsoft.Kubernetes/connectedClusters/cldfe2econnectedcluster";
        public const string ResourceName = "cl-csharp-sdk-test";
    }
}
