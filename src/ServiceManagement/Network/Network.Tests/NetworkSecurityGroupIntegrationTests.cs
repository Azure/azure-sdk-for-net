using System;
using System.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Network.Tests
{
    public class NetworkSecurityGroupIntegrationTests
    {
        #region NetworkSecurityGroups
        [Fact]
        public void TestCreateNetworkSecurityGroupWithNullNameFails()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    const string securityGroupName = null;
                    const string securityGroupLabel = null;
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    try
                    {
                        _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    }

                    // assert
                    catch (ArgumentNullException ane)
                    {
                        Assert.Contains("parameters.Name", ane.Message);
                        // succeed
                        return;
                    }
                }

                // fail if the above call succeeded
                Assert.True(false);
            }
        }

        [Fact]
        public void TestCreateNetworkSecurityGroupSucceeds()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    // assert
                    NetworkSecurityGroupGetResponse response = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, null);
                    Assert.Equal(securityGroupName, response.Name);
                    Assert.Equal(securityGroupLabel, response.Label);
                    Assert.Equal(securityGroupLocation, response.Location);
                }
            }
        }

        [Fact(Skip = "Test failing. Ed needs to re-record these.")]
        public void TestCreateNetworkSecurityGroupFullDetailsSucceeds()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    // assert
                    NetworkSecurityGroupGetResponse response = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, "full");
                    Assert.Equal(securityGroupName, response.Name);
                    Assert.Equal(securityGroupLabel, response.Label);
                    Assert.Equal(securityGroupLocation, response.Location);
                    Assert.Empty(response.Rules);
                }
            }
        }

        [Fact]
        public void TestListNetworkSecurityGroup()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    // action
                    int networkSecurityGroupCount = _testFixture.NetworkClient.NetworkSecurityGroups.List().Count();
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    var response = _testFixture.NetworkClient.NetworkSecurityGroups.List();

                    // assert
                    Assert.Equal(networkSecurityGroupCount + 1, response.Count());
                }
            }
        }

        [Fact(Skip = "Bug in RDFE in that Delete doesn't work." +
                     "When fixed, also uncomment the deletion in the Dispose of NetworkTestBase")]
        public void TestDeleteNetworkSecurityGroup()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;

                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    NetworkSecurityGroupGetResponse getResponse = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, null);

                    Assert.Equal(securityGroupName, getResponse.Name);

                    var beforeDeletionListResponse = _testFixture.NetworkClient.NetworkSecurityGroups.List();

                    // action
                    _testFixture.DeleteNetworkSecurityGroup(securityGroupName);

                    // assert
                    Assert.Throws<CloudException>(() => _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, null));

                    var afterDeletionListResponse = _testFixture.NetworkClient.NetworkSecurityGroups.List();
                    Assert.Equal(beforeDeletionListResponse.NetworkSecurityGroups.Count, afterDeletionListResponse.NetworkSecurityGroups.Count + 1);
                }
            }
        }
        #endregion

        #region NetworkSecurityRules

        [Fact(Skip = "Test failing. Ed needs to re-record these.")]
        public void TestSetAndDeleteNetworkSecurityRule()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    // setup
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = _testFixture.DefaultLocation;
                    string ruleName = _testFixture.GenerateRandomName();
                    string action = "Allow";
                    string sourceAddressPrefix = "*";
                    string sourcePortRange = "*";
                    string destinationAddressPrefix = "*";
                    string destinationPortRange = "*";
                    int priority = 500;
                    string protocol = "TCP";
                    string type = "Inbound";

                    // action
                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);
                    _testFixture.SetRuleToSecurityGroup(
                        securityGroupName,
                        ruleName,
                        action,
                        sourceAddressPrefix,
                        sourcePortRange,
                        destinationAddressPrefix,
                        destinationPortRange,
                        priority,
                        protocol,
                        type);

                    // assert
                    NetworkSecurityGroupGetResponse response = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, "full");
                    Assert.Equal(securityGroupName, response.Name);
                    Assert.Equal(securityGroupLabel, response.Label);
                    Assert.Equal(securityGroupLocation, response.Location);
                    Assert.NotEmpty(response.Rules);

                    NetworkSecurityRule rule = response.Rules.First();
                    Assert.Equal(ruleName, rule.Name);
                    Assert.Equal(sourceAddressPrefix, rule.SourceAddressPrefix);
                    Assert.Equal(sourcePortRange, rule.SourcePortRange);
                    Assert.Equal(destinationAddressPrefix, rule.DestinationAddressPrefix);
                    Assert.Equal(destinationPortRange, rule.DestinationPortRange);
                    Assert.Equal(priority, rule.Priority);
                    Assert.Equal(protocol, rule.Protocol);

                    // Pending a fix in RDFE
/*
                    Assert.Equal(action, rule.Action);
                    Assert.Equal(type, rule.Type);
*/

                    // action
                    _testFixture.NetworkClient.NetworkSecurityGroups.DeleteRule(securityGroupName, ruleName);
                    NetworkSecurityGroupGetResponse afterDeleteGetRuleresponse = _testFixture.NetworkClient.NetworkSecurityGroups.Get(securityGroupName, "full");
                    Assert.Empty(afterDeleteGetRuleresponse.Rules);
                }
            }
        }

        #endregion

        #region Subnets

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void AddAndRemoveNetworkSecurityGroupToSubnet()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                using (NetworkTestBase _testFixture = new NetworkTestBase())
                {
                    //setup

                    // create Network Security Group
                    string securityGroupName = _testFixture.GenerateRandomNetworkSecurityGroupName();
                    string securityGroupLabel = _testFixture.GenerateRandomName();
                    string securityGroupLocation = "North Central US";

                    _testFixture.CreateNetworkSecurityGroup(securityGroupName, securityGroupLabel, securityGroupLocation);

                    // create vnet with subnet
                    string vnetName = "virtualNetworkSiteName";
                    string subnetName = "FrontEndSubnet5";
                    _testFixture.SetSimpleVirtualNetwork();

                    NetworkSecurityGroupAddAssociationParameters parameters = new NetworkSecurityGroupAddAssociationParameters()
                    {
                        Name = securityGroupName
                    };

                    // action
                    _testFixture.NetworkClient.NetworkSecurityGroups.AddToSubnet(vnetName, subnetName, parameters);
                    var listNetworkResponse = _testFixture.NetworkClient.Networks.List();

                    // assert
                    var getResponse = _testFixture.NetworkClient.NetworkSecurityGroups.GetForSubnet(vnetName, subnetName);
                    Assert.Equal(securityGroupName, getResponse.Name);
                    Assert.Equal(listNetworkResponse.VirtualNetworkSites.First(vnet =>
                        vnetName.Equals(vnet.Name)).Subnets.First(subnet =>
                        subnetName.Equals(subnet.Name))
                        .NetworkSecurityGroup, securityGroupName);

                    // action
                    _testFixture.NetworkClient.NetworkSecurityGroups.RemoveFromSubnet(vnetName, subnetName, securityGroupName);


                    // assert
                    Assert.Throws<CloudException>(() => _testFixture.NetworkClient.NetworkSecurityGroups.GetForSubnet(vnetName, subnetName));
                }
            }
        }

        #endregion
    }
}
