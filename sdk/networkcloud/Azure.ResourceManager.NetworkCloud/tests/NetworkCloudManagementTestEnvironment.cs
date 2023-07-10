// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.NetworkCloud.Tests
{
    public class NetworkCloudManagementTestEnvironment : TestEnvironment
    {
        private TokenCredential _credential;
        public string ClusterExtendedLocation => GetRecordedVariable("CLUSTER_EXTENDED_LOCATION");
        public ResourceIdentifier ClusterId => new ResourceIdentifier(GetRecordedVariable("CLUSTER_ID"));
        public string ClusterManagedRG => GetRecordedVariable("CLUSTER_MANAGED_RESOURCE_GROUP");
        public string ClusterName => GetRecordedVariable("CLUSTER_NAME");
        public string ClusterRG => GetRecordedVariable("CLUSTER_RG");
        public System.DateTimeOffset DayFromNow => System.DateTimeOffset.Parse(GetRecordedVariable("DAY_FROM_NOW"));
        public string DefaultCniNetworkName => GetRecordedVariable("DEFAULT_CNI_NETWORK_NAME");
        public string L2IsolationDomainId => GetRecordedVariable("L2_ISOLATION_DOMAIN_ID");
        public string L2NetworkName => GetRecordedVariable("L2_NETWORK_NAME");
        public string L3Ipv4Prefix => GetRecordedVariable("L3_IPV4_PREFIX");
        public string L3Ipv6Prefix => GetRecordedVariable("L3_IPV6_PREFIX");
        public string L3IsolationDomainId => GetRecordedVariable("L3_ISOLATION_DOMAIN_ID");
        public string L3NetworkName => GetRecordedVariable("L3_NETWORK_NAME");
        public long L3Vlan => long.Parse(GetRecordedVariable("L3_VLAN"));
        public string ManagerExtendedLocation => GetRecordedVariable("MANAGER_EXTENDED_LOCATION");
        public string NFControllerId => GetRecordedVariable("NF_CONTROLLER_ID");
        public string TrunkedNetworkName => GetRecordedVariable("TRUNKED_NETWORK_NAME");
        public string TrunkedNetworkVlans => GetRecordedVariable("TRUNKED_VLANS");

        public string CSNAttachmentId => GetRecordedVariable("CSN_ATTACHMENT_ID");
        public string CSNAttachmentName => GetRecordedVariable("CSN_ATTACHMENT_NAME");
        public string L3NAttachmentId => GetRecordedVariable("L3_ATTACHMENT_ID");
        public string L3NAttachmentName => GetRecordedVariable("L3_ATTACHMENT_NAME");
        public string VMImage => GetRecordedVariable("VM_IMAGE");
        public string VMImageRepoPwd => GetRecordedVariable("VM_IMAGE_REPO_PWD", options => options.IsSecret());
        public string VMImageRepoUri => GetRecordedVariable("VM_IMAGE_REPO_URI");
        public string VMImageRepoUser => GetRecordedVariable("VM_IMAGE_REPO_USER");

        // Support using the Default Credential created by Azure CLI so
        // that we don't have to support creating a service principal, etc. to run these tests.
        public override TokenCredential Credential
        {
            get
            {
                if (_credential != null)
                {
                    return _credential;
                }

                // Fall back to using base implementation if USE_DEFAULT_CRED environment variable isn't "true"
                // so CI works using previous behavior of using a service principal for tests.
                if (GetOptionalVariable("USE_DEFAULT_CRED") != "true") {
                    _credential = base.Credential;
                }
                else if (Mode == RecordedTestMode.Playback)
                {
                    _credential = new MockCredential();
                }
                else
                {
                    _credential = new DefaultAzureCredential();
                }

                return _credential;
            }
        }
    }
}
