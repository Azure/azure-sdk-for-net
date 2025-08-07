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

        // Cluster Manager
        public string ManagerExtendedLocation => GetRecordedVariable("MANAGER_EXTENDED_LOCATION");

        // Cluster

        public string ClusterManagedRG => GetRecordedVariable("CLUSTER_MANAGED_RESOURCE_GROUP");
        public string ClusterName => GetRecordedVariable("CLUSTER_NAME");
        public ResourceIdentifier ClusterId => new ResourceIdentifier(GetRecordedVariable("CLUSTER_ID"));
        public string ClusterExtendedLocation => GetRecordedVariable("CLUSTER_EXTENDED_LOCATION");
        public string ClusterRG => GetRecordedVariable("CLUSTER_RG");
        public string ClusterVersion => GetRecordedVariable("CLUSTER_VERSION");
        public string UserAssignedIdentity => GetRecordedVariable("USER_ASSIGNED_IDENTITY");
        public string ContainerUri => GetRecordedVariable("CONTAINER_URI", options => options.IsSecret("https://sanitized.blob.core.windows.net/container"));
        public string VaultUri => GetRecordedVariable("VAULT_URI", options => options.IsSecret("https://sanitized.vault.azure.net"));

        // Kubernetes Cluster

        public string KubernetesClusterName => GetRecordedVariable("KUBERNETES_CLUSTER_NAME");
        public string KubernetesClusterRG => GetRecordedVariable("KUBERNETES_CLUSTER_RG");
        public ResourceIdentifier KubernetesClusterId => new ResourceIdentifier(GetRecordedVariable("KUBERNETES_CLUSTER_ID"));
        public string KubernetesVersion => GetRecordedVariable("KUBERNETES_VERSION");
        public string KubernetesVersionUpdate => GetRecordedVariable("KUBERNETES_VERSION_UPDATE");

        // Virtual Machine

        public string VMImage => GetRecordedVariable("VM_IMAGE");
        public string VMImageRepoPwd => GetRecordedVariable("VM_IMAGE_REPO_PWD", options => options.IsSecret());
        public string VMImageRepoUri => GetRecordedVariable("VM_IMAGE_REPO_URI");
        public string VMImageRepoUser => GetRecordedVariable("VM_IMAGE_REPO_USER");
        public string VMName => GetRecordedVariable("VIRTUAL_MACHINE_NAME");
        public string VMSSHPubicKey => GetRecordedVariable("VM_SSH_PUBLIC_KEY", options => options.IsSecret());

        // Console

        public string ConsoleExpirationDate => GetRecordedVariable("CONSOLE_EXPIRATION_DATE");

        // Networks

        public string IsolationDomainIds => GetRecordedVariable("ISOLATION_DOMAIN_IDS");
        public string CloudServicesNetworkId => GetRecordedVariable("CLOUD_SERVICES_NETWORK_ID");
        public string CSNAttachmentId => GetRecordedVariable("CSN_ATTACHMENT_ID");
        public string L2IsolationDomainId => GetRecordedVariable("L2_ISOLATION_DOMAIN_ID");
        public string L3IsolationDomainId => GetRecordedVariable("L3_ISOLATION_DOMAIN_ID");
        public string L3NetworkName => GetRecordedVariable("L3_NETWORK_NAME");
        public long L3Vlan => long.Parse(GetRecordedVariable("L3_VLAN"));
        public string L3Ipv4Prefix => GetRecordedVariable("L3_IPV4_PREFIX");
        public string L3Ipv6Prefix => GetRecordedVariable("L3_IPV6_PREFIX");
        public string L3NAttachmentId => GetRecordedVariable("L3_ATTACHMENT_ID");
        public string TrunkedNetworkVlans => GetRecordedVariable("TRUNKED_VLANS");
        public string SubnetId => GetRecordedVariable("SUBNET_ID");

        // BMC KeySet

        public string BMCSSHPubicKey => GetRecordedVariable("BMC_SSH_PUBLIC_KEY");

        // Misc.

        public System.DateTimeOffset DayFromNow => System.DateTimeOffset.Parse(GetRecordedVariable("DAY_FROM_NOW"));
        public string LawId => GetRecordedVariable("LAW_ID");
        public string InterfaceName => GetRecordedVariable("INTERFACE_NAME");
        public string BMMKeySetSSHPublicKey => GetRecordedVariable("BMM_KS_SSH_PUBLIC_KEY");
        public string BMMKeySetGroupId => GetRecordedVariable("BMM_KS_GROUP_ID");

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