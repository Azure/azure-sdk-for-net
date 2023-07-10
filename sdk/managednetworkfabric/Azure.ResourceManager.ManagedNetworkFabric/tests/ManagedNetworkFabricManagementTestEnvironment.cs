// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class ManagedNetworkFabricManagementTestEnvironment : TestEnvironment
    {
        private TokenCredential _credential;
        public string ResourceGroupName => GetRecordedVariable("RESOURCE_GROUP_NAME");
        public string NFCResourceGroupName => GetRecordedVariable("NFC_RESOURCE_GROUP_NAME");
        public string NFCLocation => GetRecordedVariable("NFC_LOCATION");
        public string NetworkFabricControllerName => GetRecordedVariable("Network_Fabric_Controller_Name");
        public string ValidNetworkFabricControllerId => GetRecordedVariable("Valid_Network_Fabric_Controller_Id");
        public string NetworkFabricName => GetRecordedVariable("Network_Fabric_Name");
        public string NetworkFabricNameForPostAction => GetRecordedVariable("Network_Fabric_Name_For_Post_Action");
        public string ValidNetworkFabricName => GetRecordedVariable("Valid_Network_Fabric_Name");
        public string ValidNetworkFabricNameForNNI => GetRecordedVariable("Valid_Network_Fabric_Name_For_NNI");
        public ResourceIdentifier ValidNetworkFabricId => new ResourceIdentifier(GetRecordedVariable("Valid_Network_Fabric_Id"));
        public ResourceIdentifier ValidNetworkFabricIdForNNI => new ResourceIdentifier(GetRecordedVariable("Valid_Network_Fabric_Id_For_NNI"));
        public string NetworkRackName => GetRecordedVariable("Network_Rack_Name");
        public string NetworkDeviceName => GetRecordedVariable("Network_Device_Name");
        public string NetworkInterfaceName => GetRecordedVariable("Network_Interface_Name");
        public string NetworkToNetworkInterConnectName => GetRecordedVariable("Network_To_Network_InterConnect_Name");
        public string IpPrefixName => GetRecordedVariable("IP_PREFIX_NAME");
        public string IpCommunityName => GetRecordedVariable("IP_COMMUNITY_NAME");
        public string IpExtendedCommunityName => GetRecordedVariable("IP_EXTENDED_COMMUNITY_NAME");
        public string RoutePolicyName => GetRecordedVariable("ROUTE_POLICY_NAME");
        public string L2IsolationDomainName => GetRecordedVariable("L2_Isolation_Domain_Name");
        public string L3IsolationDomainName => GetRecordedVariable("L3_Isolation_Domain_Name");
        public ResourceIdentifier ValidL3IsolationDomainId => new ResourceIdentifier(GetRecordedVariable("Valid_L3_Isolation_Domain_Id"));
        public string ValidL3IsolationDomainName => GetRecordedVariable("Valid_L3_Isolation_Domain_Name");
        public string InternalNetworkName => GetRecordedVariable("Internal_Network_Name");
        public string ExternalNetworkName => GetRecordedVariable("External_Network_Name");

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
                if (GetOptionalVariable("USE_DEFAULT_CRED") != "true")
                {
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
