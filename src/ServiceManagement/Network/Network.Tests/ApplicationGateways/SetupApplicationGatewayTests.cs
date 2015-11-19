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
using System;
using System.Net;
using System.IO;
using System.Linq;
using Microsoft.WindowsAzure.Management.Network.Models;
using Xunit;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Network.Tests.ApplicationGateways
{
    public class SetupApplicationGatewayTests
    {
        private string gatewayName = "HyakSpecTesting";
        private string gatewayDescription = "Application Gateway created to test hyak spec";
        private string vnet = "kagavnet1";
        private string subnet = "Subnet-1";

        [Fact]
        public void CreateApplicationGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                ApplicationGatewayOperationResponse result = new ApplicationGatewayOperationResponse();

                //CREATE gateway
                var createParams = new CreateApplicationGatewayParameters
                {
                    Name = gatewayName,
                    Description = gatewayDescription,
                    VnetName = vnet,
                    Subnets = new List<string>() { subnet }
                };
                result = networkTestClient.ApplicationGateways.CreateApplicationGateway(createParams);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);

                //Verify gateway
                var gateway = new ApplicationGatewayGetResponse();
                gateway = networkTestClient.ApplicationGateways.GetApplicationGateway(gatewayName);
                Assert.Equal(gateway.Name, gatewayName);
                Assert.Equal(gateway.VnetName, vnet);
                Assert.Equal(gateway.Description, gatewayDescription);

                //SET gateway config
                ApplicationGatewaySetConfiguration config = GenerateConfig();
                result = networkTestClient.ApplicationGateways.SetConfigApplicationGateway(gatewayName, config);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);

                //START gateway
                result = networkTestClient.ApplicationGateways.StartApplicationGateway(gatewayName);
                Assert.Equal(result.StatusCode, HttpStatusCode.OK);

                //Verify gateway config                
                var getConfig = networkTestClient.ApplicationGateways.GetConfigApplicationGateway(gatewayName);
                VerifyGetApplicationGatewayConfigDetails(config, getConfig);
            }
        }


        private static ApplicationGatewaySetConfiguration GenerateConfig()
        {
            ApplicationGatewaySetConfiguration config = new ApplicationGatewaySetConfiguration();

            var frontEndIP1 = new FrontendIPConfiguration
            {
                Name = "FrontendIP1",
                Type = "Private"                
            };
            var frontEndPort1 = new FrontendPort
            {
                Name = "Port1",
                Port = 80,
            };

            var probe1 = new Probe
            {
                Name = "Probe1",                
                Protocol = "Http",
                Host = "127.0.0.1",
                Path = "/",
                Interval = 45,
                Timeout = 25,
                UnhealthyThreshold = 2
            };

            var backendServer1 = new BackendServer
            {
                IPAddress = "10.0.0.1",
            };

            var backendServer2 = new BackendServer
            {
                IPAddress = "10.0.0.2",
            };
            var backendAddressPool1 = new BackendAddressPool
            {
                Name = "Pool1",
                BackendServers = new List<BackendServer> { backendServer1, backendServer2 },
            };

            var backendHttpSettings1 = new BackendHttpSettings
            {
                Name = "Setting1",
                Port = 80,
                Protocol = Protocol.Http,
                CookieBasedAffinity = "Enabled",
                RequestTimeout = 45,
                Probe = "Probe1"
            };

            var httpListener1 = new AGHttpListener
            {
                Name = "Listener1",
                FrontendPort = "Port1",
                Protocol = Protocol.Http,
                FrontendIP = "FrontendIP1",
                //SslCert = string.Empty,
            };

            var httpLoadBalancingRule1 = new HttpLoadBalancingRule
            {
                Name = "Rule1",
                Type = "Basic",
                BackendHttpSettings = "Setting1",
                Listener = "Listener1",
                BackendAddressPool = "Pool1",
            };

            config.FrontendIPConfigurations = new List<FrontendIPConfiguration> { frontEndIP1 };
            config.FrontendPorts = new List<FrontendPort> { frontEndPort1 };
            config.Probes = new List<Probe> { probe1 };
            config.BackendAddressPools = new List<BackendAddressPool> { backendAddressPool1 };
            config.BackendHttpSettingsList = new List<BackendHttpSettings> { backendHttpSettings1 };
            config.HttpListeners = new List<AGHttpListener> { httpListener1 };
            config.HttpLoadBalancingRules = new List<HttpLoadBalancingRule> { httpLoadBalancingRule1 };

            return config;
        }

        private static void VerifyGetApplicationGatewayConfigDetails(
            ApplicationGatewaySetConfiguration setConfig, ApplicationGatewayGetConfiguration getConfig)
        {
            Assert.Equal(setConfig.FrontendIPConfigurations.Count, getConfig.FrontendIPConfigurations.Count);
            foreach (var getVar in setConfig.FrontendIPConfigurations)
            {
                Assert.True(getConfig.FrontendIPConfigurations.Any(setVar => 
                    (String.Equals(setVar.Name, getVar.Name, StringComparison.InvariantCultureIgnoreCase) &&
                    setVar.StaticIPAddress == getVar.StaticIPAddress && setVar.Type == getVar.Type)));
            }

            Assert.Equal(setConfig.FrontendPorts.Count, getConfig.FrontendPorts.Count);
            foreach (var getVar in setConfig.FrontendPorts)
            {
                Assert.True(getConfig.FrontendPorts.Any(setVar =>
                    (String.Equals(setVar.Name, getVar.Name, StringComparison.InvariantCultureIgnoreCase) &&
                    setVar.Port == getVar.Port)));
            }

            Assert.Equal(setConfig.Probes.Count, getConfig.Probes.Count);
            foreach (var getVar in setConfig.Probes)
            {
                Assert.True(getConfig.Probes.Any(setVar =>
                    (String.Equals(setVar.Name, getVar.Name, StringComparison.InvariantCultureIgnoreCase) &&                    
                    (String.Equals(setVar.Protocol, getVar.Protocol, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.Path, getVar.Path, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.Host, getVar.Host, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.Path, getVar.Path, StringComparison.InvariantCultureIgnoreCase)) &&
                    (setVar.Interval == getVar.Interval) &&
                    (setVar.Timeout == getVar.Timeout) &&
                    (setVar.UnhealthyThreshold == getVar.UnhealthyThreshold))));
            }

           Assert.Equal(setConfig.BackendAddressPools.Count, getConfig.BackendAddressPools.Count);
            foreach (var getVar in setConfig.BackendAddressPools)
            {
                var setVar = getConfig.BackendAddressPools.FirstOrDefault(addrPool =>
                    (String.Equals(addrPool.Name, getVar.Name, StringComparison.InvariantCultureIgnoreCase)));
                Assert.NotNull(setVar);
                Assert.Equal(getVar.BackendServers.Count, setVar.BackendServers.Count);
                foreach (var getPool in getVar.BackendServers)
                {
                    Assert.True(getVar.BackendServers.Any(setPool =>
                        (String.Equals(setPool.IPAddress, getPool.IPAddress, StringComparison.InvariantCultureIgnoreCase))));
                }
            }

            Assert.Equal(setConfig.BackendHttpSettingsList.Count, getConfig.BackendHttpSettingsList.Count);
            foreach (var getVar in setConfig.BackendHttpSettingsList)
            {
                Assert.True(getConfig.BackendHttpSettingsList.Any(setVar =>
                    (String.Equals(setVar.Name, getVar.Name, StringComparison.InvariantCultureIgnoreCase)) &&
                    (setVar.Port == getVar.Port) &&
                    (setVar.Protocol == getVar.Protocol) &&
                    (String.Equals(setVar.CookieBasedAffinity, getVar.CookieBasedAffinity, StringComparison.InvariantCultureIgnoreCase)) &&
                    (setVar.RequestTimeout == getVar.RequestTimeout) &&
                    (String.Equals(setVar.Probe, getVar.Probe, StringComparison.InvariantCultureIgnoreCase))));
            }

            Assert.Equal(setConfig.HttpListeners.Count, getConfig.HttpListeners.Count);
            foreach (var getVar in setConfig.HttpListeners)
            {
                Assert.True(getConfig.HttpListeners.Any(setVar =>
                    (String.Equals(setVar.Name, getVar.Name, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.FrontendPort, getVar.FrontendPort, StringComparison.InvariantCultureIgnoreCase)) &&
                    (setVar.Protocol == getVar.Protocol) &&
                    (String.Equals(setVar.SslCert, getVar.SslCert, StringComparison.InvariantCultureIgnoreCase))));
            }

            Assert.Equal(setConfig.HttpLoadBalancingRules.Count, getConfig.HttpLoadBalancingRules.Count);
            foreach (var getVar in setConfig.HttpLoadBalancingRules)
            {
                Assert.True(getConfig.HttpLoadBalancingRules.Any(setVar =>
                    (String.Equals(setVar.Name, getVar.Name, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.Type, getVar.Type, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.BackendHttpSettings, getVar.BackendHttpSettings, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.Listener, getVar.Listener, StringComparison.InvariantCultureIgnoreCase)) &&
                    (String.Equals(setVar.BackendAddressPool, getVar.BackendAddressPool, StringComparison.InvariantCultureIgnoreCase))));
            }
        }
    }
}
