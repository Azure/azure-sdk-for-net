// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Text;
using Xunit;
using Fluent.Tests.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;

namespace Fluent.Tests.Network
{
    public class NSGTests
    {

        [Fact]
        public void CreateUpdateTest()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var testId = TestUtilities.GenerateName("");
                var newName = "nsg" + testId;
                var manager = TestHelper.CreateNetworkManager();
                var nsg = manager.NetworkSecurityGroups.Define(newName)
                    .WithRegion(Region.US_WEST)
                    .WithNewResourceGroup("rg" + testId)
                    .DefineRule("rule1")
                        .AllowOutbound()
                        .FromAnyAddress()
                        .FromPort(80)
                        .ToAnyAddress()
                        .ToPort(80)
                        .WithProtocol(SecurityRuleProtocol.Tcp)
                        .Attach()
                    .DefineRule("rule2")
                        .AllowInbound()
                        .FromAnyAddress()
                        .FromAnyPort()
                        .ToAnyAddress()
                        .ToPortRange(22, 25)
                        .WithAnyProtocol()
                        .WithPriority(200)
                        .WithDescription("foo!!")
                        .Attach()
                    .Create();

                // Verify
                Assert.True(nsg.Region.Equals(Region.US_WEST));
                Assert.True(nsg.SecurityRules.Count == 2);

                var resource = manager.NetworkSecurityGroups.GetByGroup("rg" + testId, newName);
                resource = resource.Update()
                    .WithoutRule("rule1")
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .DefineRule("rule3")
                        .AllowInbound()
                        .FromAnyAddress()
                        .FromAnyPort()
                        .ToAnyAddress()
                        .ToAnyPort()
                        .WithProtocol(SecurityRuleProtocol.Udp)
                        .Attach()
                    .WithoutRule("rule1")
                    .UpdateRule("rule2")
                        .DenyInbound()
                        .FromAddress("100.0.0.0/29")
                        .FromPort(88)
                        .WithPriority(300)
                        .WithDescription("bar!!!")
                        .Parent()
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag1"));

                manager.NetworkSecurityGroups.DeleteById(resource.Id);
                manager.ResourceManager.ResourceGroups.DeleteByName(resource.ResourceGroupName);
            }
        }


        public void Print(INetworkSecurityGroup resource)
        {
            var info = new StringBuilder();
            info.Append("NSG: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                    .Append("\n\tTags: ").Append(resource.Tags);

            // Output security rules
            foreach (INetworkSecurityRule rule in resource.SecurityRules.Values)
            {
                info.Append("\n\tRule: ").Append(rule.Name)
                    .Append("\n\t\tAccess: ").Append(rule.Access)
                    .Append("\n\t\tDirection: ").Append(rule.Direction)
                    .Append("\n\t\tFrom address: ").Append(rule.SourceAddressPrefix)
                    .Append("\n\t\tFrom port range: ").Append(rule.SourcePortRange)
                    .Append("\n\t\tTo address: ").Append(rule.DestinationAddressPrefix)
                    .Append("\n\t\tTo port: ").Append(rule.DestinationPortRange)
                    .Append("\n\t\tProtocol: ").Append(rule.Protocol)
                    .Append("\n\t\tPriority: ").Append(rule.Priority)
                    .Append("\n\t\tDescription: ").Append(rule.Description);
            }

            info.Append("\n\tNICs: ").Append(resource.NetworkInterfaceIds);
            TestHelper.WriteLine(info.ToString());
        }
    }
}
