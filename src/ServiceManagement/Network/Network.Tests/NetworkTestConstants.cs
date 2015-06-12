// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Network.Tests
{
    using System.IO;
    using Microsoft.WindowsAzure.Management.Network.Models;

    public static class NetworkTestConstants
    {
        public const string VirtualNetworkSiteName = "virtualNetworkSiteName";
        public const string LocalNetworkSiteName = "localNetworkSiteName";
        public const string WideVNetLocation = "North Central US";
        public const string WideVNetSubnetName = "SubnetName";

        public const string EmptyNetworkConfigurationFilePath = @"TestData\DeleteNetworkConfiguration.xml";
        public const string SiteToSiteNetworkConfigurationFilePath = @"TestData\SiteToSiteNetworkConfiguration.xml";
        public const string PointToSiteNetworkConfigurationFilePath = @"TestData\PointToSiteNetworkConfiguration.xml";
        public const string WideVNetNetworkConfigurationFilePath = @"TestData\WideVNetNetworkConfiguration.xml";
        public const string SimpleNetworkConfigurationFilePath = @"TestData\SimpleNetworkConfiguration.xml";
        public const string DeleteNetworkConfigurationFilePath = @"TestData\DeleteNetworkConfiguration.xml";
        public const string CoexistenceFeatureNetworkConfigurationFilePath = @"TestData\CoexistenceFeatureNetworkConfiguration.xml";

        public const string VnetOneWebOneWorkerCscfgFilePath = @"TestData\VnetOneWebOneWorker.cscfg";
        public const string OneWebOneWorkerPkgFilePath = @"OneWebOneWorker.cspkg";

        public static readonly NetworkSetConfigurationParameters EmptyNetworkConfigurationParameters =
            CreateSetConfigurationParametersFromFile(EmptyNetworkConfigurationFilePath);
        public static readonly NetworkSetConfigurationParameters SiteToSiteNetworkConfigurationParameters =
            CreateSetConfigurationParametersFromFile(SiteToSiteNetworkConfigurationFilePath);
        public static readonly NetworkSetConfigurationParameters PointToSiteNetworkConfigurationParameters =
            CreateSetConfigurationParametersFromFile(PointToSiteNetworkConfigurationFilePath);
        public static readonly NetworkSetConfigurationParameters WideVNetNetworkConfigurationParameters =
            CreateSetConfigurationParametersFromFile(WideVNetNetworkConfigurationFilePath);
        public static readonly NetworkSetConfigurationParameters SimpleNetworkConfigurationParameters =
            CreateSetConfigurationParametersFromFile(SimpleNetworkConfigurationFilePath);
        public static readonly NetworkSetConfigurationParameters DeleteNetworkConfigurationParameters =
            CreateSetConfigurationParametersFromFile(DeleteNetworkConfigurationFilePath);
        public static readonly NetworkSetConfigurationParameters CoexistenceFeatureNetworkConfigurationParameters =
            CreateSetConfigurationParametersFromFile(CoexistenceFeatureNetworkConfigurationFilePath);

        public static readonly GatewayCreateParameters StaticRoutingGatewayParameters =
            CreateGatewayParameters(GatewayType.StaticRouting);
        public static readonly GatewayCreateParameters DynamicRoutingGatewayParameters =
            CreateGatewayParameters(GatewayType.DynamicRouting);

        public static NetworkSetConfigurationParameters CreateSetConfigurationParametersFromFile(string configurationFilePath)
        {
            return new NetworkSetConfigurationParameters()
            {
                Configuration = File.ReadAllText(configurationFilePath),
            };
        }

        public static GatewayCreateParameters CreateStaticRoutingGatewayParameters()
        {
            return CreateGatewayParameters(GatewayType.StaticRouting);
        }
        public static GatewayCreateParameters CreateDynamicRoutingGatewayParameters(string gatewaySku = GatewaySKU.Default)
        {
            return CreateGatewayParameters(GatewayType.DynamicRouting, gatewaySku);
        }
        public static GatewayCreateParameters CreateGatewayParameters(string gatewayType, string gatewaySku = GatewaySKU.Default)
        {
            return new GatewayCreateParameters()
            {
                GatewayType = gatewayType,
                GatewaySKU = gatewaySku,
            };
        }
    }
}
