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

namespace Microsoft.WindowsAzure.Management.HDInsight.Tests
{
    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data.Rdfe;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core;
    using Microsoft.WindowsAzure.Management.HDInsight.Logging;


    internal class TestPocoClientFlowThrough : DisposableObject, IHDInsightManagementPocoClient
    {
        private IHDInsightManagementPocoClient underlying;
        public ClusterCreateParametersV2 LastCreateRequest { get; private set; }

        public TestPocoClientFlowThrough(IHDInsightManagementPocoClient underlying)
        {
            this.underlying = underlying;
        }

        public event EventHandler<ClusterProvisioningStatusEventArgs> ClusterProvisioning;

        public IAbstractionContext Context { get { return this.underlying.Context; } }

        public void RaiseClusterProvisioningEvent(object sender, ClusterProvisioningStatusEventArgs e)
        {
            if (this.ClusterProvisioning != null)
            {
                this.underlying.RaiseClusterProvisioningEvent(sender, e);
            }
        }

        public Task<ICollection<ClusterDetails>> ListContainers()
        {
            return underlying.ListContainers();
        }

        public Task<ClusterDetails> ListContainer(string dnsName)
        {
            return underlying.ListContainer(dnsName);
        }

        public Task<ClusterDetails> ListContainer(string dnsName, string location)
        {
            return underlying.ListContainer(dnsName, location);
        }
		
        public Task CreateContainer(ClusterCreateParametersV2 details)
        {
            this.LastCreateRequest = details;
            return underlying.CreateContainer(details);
        }

        public Task DeleteContainer(string dnsName)
        {
            return underlying.DeleteContainer(dnsName);
        }

        public Task DeleteContainer(string dnsName, string location)
        {
            return underlying.DeleteContainer(dnsName, location);
        }

        public Task<Guid> ChangeClusterSize(string dnsName, string location, int newSize)
        {
            return underlying.ChangeClusterSize(dnsName, location, newSize);
        }

        public Task<Guid> EnableDisableProtocol(
            UserChangeRequestUserType protocol,
            UserChangeRequestOperationType operation,
            string dnsName,
            string location,
            string userName,
            string password,
            DateTimeOffset expiration)
        {
            return underlying.EnableDisableProtocol(protocol, operation, dnsName, location, userName, password, expiration);
        }

        public Task<Guid> EnableHttp(string dnsName, string location, string httpUserName, string httpPassword)
        {
            return underlying.EnableHttp(dnsName, location, httpUserName, httpPassword);
        }

        public Task<Guid> DisableHttp(string dnsName, string location)
        {
            return underlying.DisableHttp(dnsName, location);
        }

        public Task<Guid> EnableRdp(string dnsName, string location, string rdpUserName, string rdpPassword, DateTime expiry)
        {
            return underlying.EnableRdp(dnsName, location, rdpUserName, rdpPassword, expiry);
        }

        public Task<Guid> DisableRdp(string dnsName, string location)
        {
            return underlying.DisableRdp(dnsName, location);
        }

        public Task<bool> IsComplete(string dnsName, string location, Guid operationId)
        {
            return underlying.IsComplete(dnsName, location, operationId);
        }

        public Task<UserChangeRequestStatus> GetStatus(string dnsName, string location, Guid operationId)
        {
            return underlying.GetStatus(dnsName, location, operationId);
        }

        public Task<Operation> GetRdfeOperationStatus(Guid operationId)
        {
            return underlying.GetRdfeOperationStatus(operationId);
        }

        public ILogger Logger
        {
            get { return underlying.Logger; }
        }
    }
}
