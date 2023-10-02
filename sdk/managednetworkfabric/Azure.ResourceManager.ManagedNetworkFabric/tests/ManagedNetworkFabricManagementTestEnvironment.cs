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

        /// <summary>
        ///   The name of the resource group to be used for playback tests. Recorded.
        /// </summary>
        public string ResourceGroupName => GetRecordedVariable("RESOURCE_GROUP_NAME");

        /// <summary>
        ///   The name of the resource group that has successufully provisioned NFC to be used for playback tests. Recorded.
        /// </summary>
        public string NFCResourceGroupName => GetRecordedVariable("NFC_RESOURCE_GROUP_NAME");

        /// <summary>
        ///   The ARM ID of the Netowork Fabric Controller that has successufully provisioned to be used for playback tests. Recorded.
        /// </summary>
        public string Provisioned_NFC_ID => GetRecordedVariable("PROVISIONED_NFC_ID");

        /// <summary>
        ///   The ARM ID of the Netowork Fabric  that has successufully provisioned to be used for playback tests. Recorded.
        /// </summary>
        public string Provisioned_NF_ID => GetRecordedVariable("PROVISIONED_NF_ID");

        /// <summary>
        ///   The ARM ID of the L3Isoltaion Domain to be used for playback tests. Recorded.
        ///   This ID is used for the  creation of the Internal and External Networks.
        /// </summary>
        public string Existing_L3ISD_ID => GetRecordedVariable("EXISTING_L3ISD_ID");

        /// <summary>
        ///   The ARM ID of the Route Policy to be used for playback tests. Recorded.
        ///   This ID is used in the creation of the Network To Network Interconnects Resource.
        /// </summary>
        public string ExistingRoutePolicyId => GetRecordedVariable("EXISTING_ROUTEPOLICY_ID");

        /// <summary>
        ///   The name of the Network Rack to be used for playback tests. Recorded.
        ///   This is used as the Rack is not created by the user. We use the existing rack to perform other opertions.
        /// </summary>
        public string NetworkRackName => GetRecordedVariable("EXISTING_RACK_NAME");

        /// <summary>
        ///   The name of the Network Device to be used for playback tests. Recorded.
        ///   This is used as the Network Device is not created by the user. We use the existing device to perform other opertions.
        ///   Note: Only the device under not provisioned can be updated.
        /// </summary>
        public string NetworkDeviceNameUnderDeprovisionedNF => GetRecordedVariable("EXISTING_DEVICE_NAME_UNDER_DEPROVISONED_NF");

        /// <summary>
        ///   The name of the Network Device to be used for playback tests. Recorded.
        ///   This is used for the Interface Update.
        /// </summary>
        public string NetworkDeviceNameUnderProvisionedNF => GetRecordedVariable("EXISTING_DEVICE_NAME_UNDER_PROVISONED_NF");

        /// <summary>
        ///   The name of the Network Interface to be used for playback tests. Recorded.
        ///   This is used as the Network Interface is not created by the user. We use the existing interface to perform other opertions.
        /// </summary>
        public string NetworkInterfaceName => GetRecordedVariable("EXISTING_INTERFACE_NAME");

        /// <summary>
        ///   The ARM ID of the Network Fabric that is not provisined to be used for playback tests. Recorded.
        ///   This ID is used create the Network To Network Interconnect Resource.
        /// </summary>
        public string Existing_NotProvisioned_NF_ID => GetRecordedVariable("EXISTING_NOT_PROVISIONED_NF_ID");

        /// <summary>
        ///   The name of the Network Fabric Controller to be used for playback tests. Recorded.
        /// </summary>
        public string NetworkFabricControllerName => GetRecordedVariable("NFC_NAME");

        /// <summary>
        ///   The name of the Network Fabric to be used for playback tests. Recorded.
        /// </summary>
        public string NetworkFabricName => GetRecordedVariable("NF_NAME");

        /// <summary>
        ///   The name of the Network To Network InterConnect to be used for playback tests. Recorded.
        /// </summary>
        public string NetworkToNetworkInterConnectName => GetRecordedVariable("NNI_NAME");

        /// <summary>
        ///   The name of the IP Prefix to be used for playback tests. Recorded.
        /// </summary>
        public string IpPrefixName => GetRecordedVariable("IP_PREFIX_NAME");

        /// <summary>
        ///   The name of the IP Community to be used for playback tests. Recorded.
        /// </summary>
        public string IpCommunityName => GetRecordedVariable("IP_COMMUNITY_NAME");

        /// <summary>
        ///   The name of the IP Extended Community to be used for playback tests. Recorded.
        /// </summary>
        public string IpExtendedCommunityName => GetRecordedVariable("IP_EXTENDED_COMMUNITY_NAME");

        /// <summary>
        ///   The name of the Route Policy to be used for playback tests. Recorded.
        /// </summary>
        public string RoutePolicyName => GetRecordedVariable("ROUTE_POLICY_NAME");

        /// <summary>
        ///   The name of the L2 Isolation Domain to be used for playback tests. Recorded.
        /// </summary>
        public string L2IsolationDomainName => GetRecordedVariable("L2ISD_NAME");

        /// <summary>
        ///   The name of the L3 Isolation Domain to be used for playback tests. Recorded.
        /// </summary>
        public string L3IsolationDomainName => GetRecordedVariable("L3ISD_NAME");

        /// <summary>
        ///   The name of the Internal Network to be used for playback tests. Recorded.
        /// </summary>
        public string InternalNetworkName => GetRecordedVariable("INTERNAL_NETWORK_NAME");

        /// <summary>
        ///   The name of the External Network to be used for playback tests. Recorded.
        /// </summary>
        public string ExternalNetworkName => GetRecordedVariable("EXTERNAL_NETWORK_NAME");

        /// <summary>
        ///   The name of the Internet Gateway to be used for playback tests. Recorded.
        /// </summary>
        public string InternetGatewayName => GetRecordedVariable("INTERNET_GATEWAY_NAME");

        /// <summary>
        ///   The name of the Internet Gateway Rule to be used for playback tests. Recorded.
        /// </summary>
        public string InternetGatewayRuleName => GetRecordedVariable("INTERNET_GATEWAY_RULE_NAME");

        /// <summary>
        ///   The name of the Access Control List to be used for playback tests. Recorded.
        /// </summary>
        public string AccessControlListName => GetRecordedVariable("ACCESS_CONTROL_LIST_NAME");

        /// <summary>
        ///   The name of the Network Packet Broker to be used for playback tests. Recorded.
        /// </summary>
        public string NetworkPacketBrokerName => GetRecordedVariable("NETWORK_PACKET_BROKER_NAME");

        /// <summary>
        /// The name of the Network Tap Rule to be used for playback tests. Recorded.
        /// </summary>
        public string NetworkTapRuleName => GetRecordedVariable("NETWORK_TAP_RULE_NAME");

        /// <summary>
        /// The name of the Network Tap to be used for playback tests. Recorded.
        /// </summary>
        public string NetworkTapName => GetRecordedVariable("NETWORK_TAP_NAME");

        /// <summary>
        /// The name of the Neighbor Group to be used for playback tests. Recorded.
        /// </summary>
        public string NeighborGroupName => GetRecordedVariable("NEIGHBOR_GROUP_NAME");

        /// <summary>
        /// The name of the Existing Network Fabric to be used for playback tests. Recorded.
        /// </summary>
        public string ExistingNetworkFabricName => GetRecordedVariable("EXISTING_NETWORK_FABRIC_NAME");
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
