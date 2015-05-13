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
using System.Collections.Specialized;
using System.IO;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Testing;
using Network.Tests.Networks.TestOperations;

namespace Network.Tests
{
    public class NetworkTestBase : TestBase, IDisposable
    {
        private const string CloudServiceNamingExtension = ".cloudapp.net";
        private const string TestArtifactsNamePrefix = "NetworkTests";

        //needed for test artifacts cleaning up
        private object _syncObject = new object();
        private StringCollection _networkSecurityGroupsToCleanup = new StringCollection();
        private string _defaultLocation;

        public NetworkTestBase()
        {
            NetworkClient = GetServiceClient<NetworkManagementClient>();
            ManagementClient = GetServiceClient<ManagementClient>();
            _defaultLocation = ManagementTestUtilities.GetDefaultLocation(ManagementClient, "Compute");
        }

        public NetworkManagementClient NetworkClient { get; private set; }
        public ManagementClient ManagementClient { get; private set; }

        public string DefaultLocation
        {
            get
            {
                return _defaultLocation;
            }
        }

        private void RegisterToCleanup(string artifactName, StringCollection cleanupList)
        {
            lock (_syncObject)
            {
                cleanupList.Add(artifactName);
            }
        }

        private void UnregisterToCleanup(string artifactName, StringCollection cleanupList)
        {
            lock (_syncObject)
            {
                cleanupList.Remove(artifactName);
            }
        }

        public void CreateNetworkSecurityGroup(string name, string label, string location)
        {
            NetworkSecurityGroupCreateParameters parameters = new NetworkSecurityGroupCreateParameters()
            {
                Name = name,
                Label = label,
                Location = location
            };

            NetworkClient.NetworkSecurityGroups.Create(parameters);
            RegisterToCleanup(name, _networkSecurityGroupsToCleanup);
        }

        public void SetRuleToSecurityGroup(
            string securityGroupName,
            string ruleName,
            string action,
            string sourceAddressPrefix,
            string sourcePortRange,
            string destinationAddressPrefix,
            string destinationPortRange,
            int priority,
            string protocol,
            string type)
        {
            NetworkSecuritySetRuleParameters parameters = new NetworkSecuritySetRuleParameters()
            {
                Action = "Allow",
                SourceAddressPrefix = sourceAddressPrefix,
                SourcePortRange = sourcePortRange,
                DestinationAddressPrefix = destinationAddressPrefix,
                DestinationPortRange = destinationPortRange,
                Priority = priority,
                Protocol = protocol,
                Type = type
            };

            NetworkClient.NetworkSecurityGroups.SetRule(securityGroupName, ruleName, parameters);
        }

        public string GenerateRandomNetworkSecurityGroupName()
        {
            return GenerateRandomName(TestArtifactType.NetworkSecurityGroup);
        }

        public string GenerateRandomName()
        {
            return TestUtilities.GenerateName(TestArtifactsNamePrefix);
        }

        private string GenerateRandomName(TestArtifactType artifact)
        {
            return TestUtilities.GenerateName(TestArtifactsNamePrefix);
        }

        public void DeleteNetworkSecurityGroup(string securityGroupName)
        {
            NetworkClient.NetworkSecurityGroups.Delete(securityGroupName);
            UnregisterToCleanup(securityGroupName, _networkSecurityGroupsToCleanup);
        }

        public void SetSimpleVirtualNetwork()
        {
            SetNetworkConfiguration testOperation = new SetNetworkConfiguration(NetworkClient, NetworkTestConstants.SimpleNetworkConfigurationParameters);
            testOperation.Invoke();
        }

        public void DeleteNetworkConfiguration()
        {
            SetNetworkConfiguration testOperation = new SetNetworkConfiguration(NetworkClient, NetworkTestConstants.DeleteNetworkConfigurationParameters);
            testOperation.Invoke();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void Cleanup()
        {
            foreach (string group in _networkSecurityGroupsToCleanup)
            {
                try
                {
//                    NetworkClient.NetworkSecurityGroups.Delete(group);
                }
                catch { }
            }

            DeleteNetworkConfiguration();

            NetworkClient.Dispose();
            ManagementClient.Dispose();
        }

        private enum TestArtifactType
        {
            NetworkSecurityGroup
        }
    }
}
