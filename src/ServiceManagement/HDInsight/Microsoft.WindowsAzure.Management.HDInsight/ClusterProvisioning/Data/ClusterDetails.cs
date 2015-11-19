// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using Microsoft.Hadoop.Client;

    /// <summary>
    /// Represents cluster properties and provides cluster scoped operations.
    /// </summary>
    public sealed class ClusterDetails
    {
        private string stateString;

        /// <summary>
        /// Gets or sets the Name of the cluster.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the a string value of the state of the cluster.
        /// </summary>
        public string StateString
        {
            get { return this.stateString; }
            set
            {
                this.stateString = value;
                this.UpdateState(this.stateString);
            }
        }

        /// <summary>
        /// Gets or sets the version of the HDInsight cluster.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the version status of the HDInsight cluster.
        /// </summary>
        public VersionStatus VersionStatus { get; set; }

        /// <summary>
        /// Gets or sets the version of the HDInsight cluster as a number.
        /// </summary>
        public Version VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the parsed value of the state of the cluster
        /// Note: For compatibility reassons, any new or null states will revert to "UNKOWN".
        /// but the value will be preserved in State.
        /// </summary>
        public ClusterState State { get; set; }

        /// <summary>
        /// Gets or sets a possible error state for the cluster (if exists).
        /// </summary>
        public ClusterErrorStatus Error { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate of the cluster.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the connection URL for the cluster.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings",
            Justification = "Value coming from the server. Value of parsing vs value of breaking is not worth it")]
        public string ConnectionUrl { get; set; }

        /// <summary>
        /// Gets or sets the login username for the cluster.
        /// </summary>
        public string HttpUserName { get; set; }

        /// <summary>
        /// Gets or sets the password associated with Http requests to the cluster.
        /// </summary>
        public string HttpPassword { get; set; }

        /// <summary>
        /// Gets or sets the Rdp user name associated with the cluster.
        /// </summary>
        public string RdpUserName { get; set; }

        /// <summary>
        /// Gets or sets the Datacenter location of the cluster.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the HDInsight deployment ID associated with this cluster.
        /// </summary>
        public string DeploymentId { get; set; }

        /// <summary>
        /// Gets or sets the count of worker nodes.
        /// </summary>
        public int ClusterSizeInNodes { get; set; }

        /// <summary>
        /// Gets or sets the default storage account registered with this cluster.
        /// </summary>
        public WabStorageAccountConfiguration DefaultStorageAccount { get; set; }

        /// <summary>
        /// Gets or sets the subscriptionid associated with this cluster.
        /// </summary>
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the flavor associated with this cluster.
        /// </summary>
        public ClusterType ClusterType { get; set; }

        /// <summary>
        /// Gets or sets the OS Type for the nodes of this cluster.
        /// </summary>
        public OSType OSType { get; set; }

        /// <summary>
        /// Gets or sets the id of virtual network to deploy the cluster.
        /// </summary>
        public string VirtualNetworkId { get; set; }

        /// <summary>
        /// Gets or sets the name of the subnet to deploy the cluster.
        /// </summary>
        public string SubnetName { get; set; }

        /// <summary>
        /// Gets or sets the additional storage accounts registered with this cluster.
        /// </summary>
        public IEnumerable<WabStorageAccountConfiguration> AdditionalStorageAccounts { get; set; }

        /// <summary>
        /// Initializes a new instance of the ClusterDetails class.
        /// </summary>
        public ClusterDetails()
        {
        }

        internal ClusterDetails(string dnsName, string state)
        {
            this.Name = dnsName;
            this.StateString = state;
            this.UpdateState(state);
        }

        private void UpdateState(string state)
        {
            ClusterState parsedState;
            this.State = (state == null || !Enum.TryParse(state, true, out parsedState)) ? ClusterState.Unknown : parsedState;
        }

        internal void ChangeState(ClusterState newState)
        {
            this.StateString = newState.ToString();
            this.State = newState;
        }

        /// <summary>
        /// Creates and returns a new instance of HDInsightApplicationHistoryClient.
        /// </summary>
        /// <returns>
        /// Returns an HDInsight Application History Client.
        /// </returns>
        public IHDInsightApplicationHistoryClient CreateHDInsightApplicationHistoryClient()
        {
            return new HDInsightApplicationHistoryClient(this);
        }

        /// <summary>
        /// Creates and returns a new instance of HDInsightApplicationHistoryClient.
        /// </summary>
        /// <param name="timeout">
        /// The timeout to use for operations made by this client.
        /// </param>
        /// <returns>
        /// Returns an HDInsight Application History Client.
        /// </returns>
        public IHDInsightApplicationHistoryClient CreateHDInsightApplicationHistoryClient(TimeSpan timeout)
        {
            return new HDInsightApplicationHistoryClient(this, timeout);
        }
    }
}
