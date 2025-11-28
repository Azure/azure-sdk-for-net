// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Dns.Tests;

public class BasicDnsTests
{
    internal static Trycep CreateAzureDnsNewZoneTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:CreateAzureDnsNewZone
                Infrastructure infra = new();

                ProvisioningParameter zoneName = new(nameof(zoneName), typeof(string))
                {
                    Description = "The name of the DNS zone to be created.  Must have at least 2 segments, e.g. hostname.org",
                    Value = BicepFunction.Interpolate($"{BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id)}.azurequickstart.org")
                };
                infra.Add(zoneName);

                ProvisioningParameter recordName = new(nameof(recordName), typeof(string))
                {
                    Description = "The name of the DNS record to be created.  The name is relative to the zone, not the FQDN.",
                    Value = "www"
                };
                infra.Add(recordName);

                DnsZone zone = new(nameof(zone), DnsZone.ResourceVersions.V2018_05_01)
                {
                    Name = zoneName,
                    Location = new AzureLocation("global")
                };
                infra.Add(zone);

                DnsARecord aRecord = new(nameof(aRecord), DnsARecord.ResourceVersions.V2018_05_01)
                {
                    Parent = zone,
                    Name = recordName,
                    TtlInSeconds = 3600,
                    ARecords =
                    {
                        new DnsARecordInfo() { Ipv4Addresses = IPAddress.Parse("203.0.113.1") },
                        new DnsARecordInfo() { Ipv4Addresses = IPAddress.Parse("203.0.113.2") }
                    }
                };
                infra.Add(aRecord);
                #endregion
                // TODO -- we omitted an output variable here for nameServers because we had a bug in Azure.Provisioning
                // when the type of an output is an array. This was fixed, but we did not release a stable version yet
                // we need to add the output once the fix was released in the next stable version.

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.network/azure-dns-new-zone/main.bicep")]
    public async Task CreateAzureDnsNewZone()
    {
        await using Trycep test = CreateAzureDnsNewZoneTest();
        test.Compare(
            """
            @description('The name of the DNS zone to be created.  Must have at least 2 segments, e.g. hostname.org')
            param zoneName string = '${uniqueString(resourceGroup().id)}.azurequickstart.org'

            @description('The name of the DNS record to be created.  The name is relative to the zone, not the FQDN.')
            param recordName string = 'www'

            resource zone 'Microsoft.Network/dnsZones@2018-05-01' = {
              name: zoneName
              location: 'global'
            }

            resource aRecord 'Microsoft.Network/dnsZones/A@2018-05-01' = {
              name: recordName
              parent: zone
              properties: {
                ARecords: [
                  {
                    ipv4Addresses: '203.0.113.1'
                  }
                  {
                    ipv4Addresses: '203.0.113.2'
                  }
                ]
                TTL: 3600
              }
            }
            """);
    }
}
