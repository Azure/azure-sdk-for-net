// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KubernetesConfiguration.Tests.TestSupport
{
    /// <summary>
    /// Class that represents the Cluster
    /// </summary>
    public class ClusterInfo
    {
        public readonly string ResourceGroup;
        public readonly string Name;
        public readonly string RpName;
        public readonly string Type;
        public readonly string Location;

        public enum ClusterType
        {
            connectedClusters,
            managedClusters
        }

        public const string ArcClusterRP = "Microsoft.Kubernetes";
        public const string AksClusterRP = "Microsoft.ContainerServices";

        public ClusterInfo(string name, ClusterType type, string location, string resourceGroup)
        {
            this.Name = name;
            this.Type = type.ToString();
            this.RpName = type == ClusterType.connectedClusters ? ArcClusterRP : AksClusterRP;
            this.Location = location;
            this.ResourceGroup = resourceGroup;
        }
    }
}
