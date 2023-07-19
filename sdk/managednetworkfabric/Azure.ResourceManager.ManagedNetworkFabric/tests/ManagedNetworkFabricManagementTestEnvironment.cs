// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class ManagedNetworkFabricManagementTestEnvironment : TestEnvironment
    {
        private TokenCredential _credential;

        private static string _testDate = DateTime.Now.ToString("MMdyy");

        public string ResourceGroupName => GetRecordedVariable("RESOURCE_GROUP_NAME");
        public string NFCResourceGroupName => GetRecordedVariable("NFC_RESOURCE_GROUP_NAME");
        public string Provisioned_NFC_ID => GetRecordedVariable("PROVISIONED_NFC_ID");
        public string Provisioned_NF_ID => GetRecordedVariable("PROVISIONED_NF_ID");
        public string Existing_L3ISD_ID => GetRecordedVariable("EXISTING_L3ISD_ID");

        public string NetworkRackName => GetRecordedVariable("EXISTING_RACK_NAME");
        public string NetworkDeviceName => GetRecordedVariable("EXISTING_DEVICE_NAME");
        public string NetworkInterfaceName => GetRecordedVariable("EXISTING_INTERFACE_NAME");

        public string NetworkFabricControllerName => GetRecordedVariable("NFC_NAME");
        public string NetworkFabricName => GetRecordedVariable("NF_NAME");
        public string NetworkToNetworkInterConnectName => GetRecordedVariable("NNI_NAME");
        public string IpPrefixName => GetRecordedVariable("IP_PREFIX_NAME");
        public string IpCommunityName => GetRecordedVariable("IP_COMMUNITY_NAME");
        public string IpExtendedCommunityName => GetRecordedVariable("IP_EXTENDED_COMMUNITY_NAME");
        public string RoutePolicyName => GetRecordedVariable("ROUTE_POLICY_NAME");
        public string L2IsolationDomainName => GetRecordedVariable("L2ISD_NAME");
        public string L3IsolationDomainName => GetRecordedVariable("L3ISD_NAME");
        public string InternalNetworkName => GetRecordedVariable("INTERNAL_NETWORK_NAME");
        public string ExternalNetworkName => GetRecordedVariable("EXTERNAL_NETWORK_NAME");

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
