// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Avs;
using Microsoft.Azure.Management.Avs.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Avs.Tests
{
    public class WorkloadNetworksTests : TestBase
    {
        [Fact]
        public void WorkloadNetworksDhcp()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "wezamlyn-test-117";
            string cloudName = "wezamlyn-test-117";

            using var avsClient = context.GetServiceClient<AvsClient>();

            // DHCP
            var dhcpId = "dhcpRelay";
            
            List<string> serverAddressess = new List<string>() {"10.1.1.1", "10.1.1.2"};
            var dhcpProperties = new WorkloadNetworkDhcpRelay(displayName: dhcpId, serverAddresses: serverAddressess);
            var dhcp = new WorkloadNetworkDhcp(properties: dhcpProperties);

            avsClient.WorkloadNetworks.CreateDhcp(rgName, cloudName, dhcpId, dhcp);

            avsClient.WorkloadNetworks.ListDhcp(rgName, cloudName);

            avsClient.WorkloadNetworks.GetDhcp(rgName, dhcpId, cloudName);

            dhcp.Properties.DisplayName = "modifiedDhcpRelay";
            avsClient.WorkloadNetworks.UpdateDhcp(rgName, cloudName, dhcpId, dhcp);

            avsClient.WorkloadNetworks.DeleteDhcp(rgName, cloudName, dhcpId);
        }

        [Fact]
        public void WorkloadNetworksDns()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "wezamlyn-test-117";
            string cloudName = "wezamlyn-test-117";

            using var avsClient = context.GetServiceClient<AvsClient>();
            
            // DNS Zones

            var defaultDnsZoneId = "defaultDnsZone";
            var defaultDomain = new List<string>() {};
            var defaultDnsServerIps = new List<string>() { "1.1.1.1" };
            var defaultDnsZone = new WorkloadNetworkDnsZone(displayName: defaultDnsZoneId, domain: defaultDomain, dnsServerIps: defaultDnsServerIps);

            var resDefaultDnsZone = avsClient.WorkloadNetworks.CreateDnsZone(rgName, cloudName, defaultDnsZoneId, defaultDnsZone);

            // Get ARM ID for DNS Service
            var defaultDnsZoneIdSplit = resDefaultDnsZone.Id.Split("/");
            var defaultDnsZoneArmId = defaultDnsZoneIdSplit[defaultDnsZoneIdSplit.Length-1];
            
            var fqdnDnsZoneId = "fqdnDnsZone";
            var fqdnDomain = new List<string>() { "fqdndnszone.com" };
            var fqdnDnsServerIps = new List<string>() { "1.1.1.1" };
            var fqdnDnsZone = new WorkloadNetworkDnsZone(displayName: fqdnDnsZoneId, domain: fqdnDomain, dnsServerIps: fqdnDnsServerIps);
        
            var resFqdnDnsZone = avsClient.WorkloadNetworks.CreateDnsZone(rgName, cloudName, fqdnDnsZoneId, fqdnDnsZone);

            // Get ARM ID for DNS Service
            var fqdnDnsZoneIdSplit = resFqdnDnsZone.Id.Split("/");
            var fqdnDnsZoneArmId = fqdnDnsZoneIdSplit[fqdnDnsZoneIdSplit.Length-1];

            avsClient.WorkloadNetworks.ListDnsZones(rgName, cloudName);

            avsClient.WorkloadNetworks.GetDnsZone(rgName, cloudName, defaultDnsZoneId);

            defaultDnsZone.DisplayName = "modifiedDnsZone";
            avsClient.WorkloadNetworks.UpdateDnsZone(rgName, cloudName, defaultDnsZoneId, defaultDnsZone);

            // DNS Services

            var dnsServiceId = "dns-forwarder";
            var dnsServiceIp = "5.5.5.5";
            var logLevel = "INFO";
            var dnsService = new WorkloadNetworkDnsService(displayName: dnsServiceId, dnsServiceIp: dnsServiceIp, logLevel: logLevel);

            dnsService.DefaultDnsZone = defaultDnsZoneArmId;
            dnsService.FqdnZones = new List<string>() { fqdnDnsZoneArmId };

            avsClient.WorkloadNetworks.CreateDnsService(rgName, cloudName, dnsServiceId,  dnsService);

            avsClient.WorkloadNetworks.ListDnsServices(rgName, cloudName);

            avsClient.WorkloadNetworks.GetDnsService(rgName, cloudName, dnsServiceId);

            dnsService.DisplayName = "modifiedDnsService";
            avsClient.WorkloadNetworks.UpdateDnsService(rgName, cloudName, dnsServiceId, dnsService);

            avsClient.WorkloadNetworks.DeleteDnsService(rgName, dnsServiceId, cloudName);

            // Delete DNS Zones

            avsClient.WorkloadNetworks.DeleteDnsZone(rgName, defaultDnsZoneId, cloudName);

            avsClient.WorkloadNetworks.DeleteDnsZone(rgName, fqdnDnsZoneId, cloudName);
        }

        [Fact]
        public void WorkloadNetworksGatewaysSegments()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "wezamlyn-test-117";
            string cloudName = "wezamlyn-test-117";

            using var avsClient = context.GetServiceClient<AvsClient>();

            // Gateways

            var gatewayResults = avsClient.WorkloadNetworks.ListGateways(rgName, cloudName);

            // Segments

            var gatewayName = gatewayResults.First().DisplayName;
            var segmentId = "segment";
            var segmentSubnet = new WorkloadNetworkSegmentSubnet(gatewayAddress: "10.2.3.1/24");
            var segment = new WorkloadNetworkSegment(displayName: segmentId, connectedGateway: gatewayName, subnet: segmentSubnet);

            avsClient.WorkloadNetworks.CreateSegments(rgName, cloudName, segmentId, segment);

            avsClient.WorkloadNetworks.ListSegments(rgName, cloudName);

            avsClient.WorkloadNetworks.GetSegment(rgName, cloudName, segmentId);

            segment.DisplayName = "modifiedSegment";
            avsClient.WorkloadNetworks.UpdateSegments(rgName, cloudName, segmentId, segment);

            avsClient.WorkloadNetworks.DeleteSegment(rgName, cloudName, segmentId);
        }

        [Fact]
        public void WorkloadNetworksVirtualMachinesVmGroupsPortMirroring()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "wezamlyn-test-117";
            string cloudName = "wezamlyn-test-117";

            using var avsClient = context.GetServiceClient<AvsClient>();

            // Virtual Machines

            var virtualMachinesList = avsClient.WorkloadNetworks.ListVirtualMachines(rgName, cloudName);

            // VM Groups

            var sourceVmGroupId = "sourceVmGroup";
            var sourceVmGroup = new WorkloadNetworkVMGroup(displayName: sourceVmGroupId);

            var destVmGroupId = "destVmGroup";
            var destVmGroup = new WorkloadNetworkVMGroup(displayName: destVmGroupId);

            if (virtualMachinesList.Count() >= 2)
            {
                string[] sourceMembers = {virtualMachinesList.ElementAt(0).DisplayName};
                sourceVmGroup.Members = sourceMembers;

                string[] destMembers = {virtualMachinesList.ElementAt(1).DisplayName};
                destVmGroup.Members = destMembers;
            }

            var resSourceVmGroup = avsClient.WorkloadNetworks.CreateVMGroup(rgName, cloudName, sourceVmGroupId, sourceVmGroup);

            // Get ARM ID for Port Mirroring
            var sourceIdSplit = resSourceVmGroup.Id.Split("/");
            var sourceArmId = sourceIdSplit[sourceIdSplit.Length-1];

            var resDestVmGroup = avsClient.WorkloadNetworks.CreateVMGroup(rgName, cloudName, destVmGroupId, destVmGroup);

            // Get ARM ID for Port Mirroring
            var destIdSplit = resDestVmGroup.Id.Split("/");
            var destArmId = destIdSplit[destIdSplit.Length-1];

            avsClient.WorkloadNetworks.ListVMGroups(rgName, cloudName);

            avsClient.WorkloadNetworks.GetVMGroup(rgName, cloudName, sourceVmGroupId);

            sourceVmGroup.DisplayName = "modifiedVmGroup";
            avsClient.WorkloadNetworks.UpdateVMGroup(rgName, cloudName, sourceVmGroupId, sourceVmGroup);

            // Port Mirroring

            var portMirroringId = "portMirroring";
            var portMirroring = new WorkloadNetworkPortMirroring(displayName: portMirroringId, direction: "BIDIRECTIONAL");
            portMirroring.Source = sourceArmId;
            portMirroring.Destination = destArmId;
            
            avsClient.WorkloadNetworks.CreatePortMirroring(rgName, cloudName, portMirroringId, portMirroring);

            avsClient.WorkloadNetworks.ListPortMirroring(rgName, cloudName);

            avsClient.WorkloadNetworks.GetPortMirroring(rgName, cloudName, portMirroringId);

            portMirroring.DisplayName = "modifiedPortMirroring";
            avsClient.WorkloadNetworks.UpdatePortMirroring(rgName, cloudName,portMirroringId, portMirroring);

            avsClient.WorkloadNetworks.DeletePortMirroring(rgName, portMirroringId, cloudName);

            // Delete VM Groups

            avsClient.WorkloadNetworks.DeleteVMGroup(rgName, sourceVmGroupId, cloudName);

            avsClient.WorkloadNetworks.DeleteVMGroup(rgName, destVmGroupId, cloudName);            
        }
    }
}