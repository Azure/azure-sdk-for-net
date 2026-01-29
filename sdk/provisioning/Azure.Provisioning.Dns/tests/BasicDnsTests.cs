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
                        new DnsARecordInfo() { Ipv4Address = IPAddress.Parse("203.0.113.1") },
                        new DnsARecordInfo() { Ipv4Address = IPAddress.Parse("203.0.113.2") }
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
                    ipv4Address: '203.0.113.1'
                  }
                  {
                    ipv4Address: '203.0.113.2'
                  }
                ]
                TTL: 3600
              }
            }
            """);
    }

    [Test]
    public async Task TestCnameAndIpv4andIpv6ARecords()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                DnsZone zone = DnsZone.FromExisting(nameof(zone), DnsZone.ResourceVersions.V2018_05_01);
                zone.Name = "contoso.com";
                infra.Add(zone);

                DnsCnameRecord cnameRecord = new(nameof(cnameRecord), DnsCnameRecord.ResourceVersions.V2018_05_01)
                {
                    Parent = zone,
                    Name = "www",
                    TtlInSeconds = 3600,
                    Cname = "contoso.azurewebsites.net"
                };
                infra.Add(cnameRecord);

                DnsARecord dnsRecordA = new("dnsRecordA")
                {
                    Parent = zone,
                    Name = "privatev4",
                    TtlInSeconds = 3600,
                    ARecords =
                    [
                        new DnsARecordInfo()
                        {
                            Ipv4Address = IPAddress.Parse("127.0.0.1")
                        },
                        new DnsARecordInfo()
                        {
                            Ipv4Address = IPAddress.Parse("192.168.0.1")
                        }
                    ],
                };
                infra.Add(dnsRecordA);

                DnsAaaaRecord aaaaRecord = new(nameof(aaaaRecord), DnsAaaaRecord.ResourceVersions.V2018_05_01)
                {
                    Parent = zone,
                    Name = "privatev6",
                    TtlInSeconds = 3600,
                    AaaaRecords =
                    {
                        new DnsAaaaRecordInfo() { Ipv6Address = IPAddress.Parse("0000:0000:0000:0000:0000:0000:0000:0001") },
                        new DnsAaaaRecordInfo() { Ipv6Address = IPAddress.Parse("FD00::45:AA:1") }
                    }
                };
                infra.Add(aaaaRecord);

                DnsTxtRecord spfTxtRecord = new(nameof(spfTxtRecord), DnsTxtRecord.ResourceVersions.V2018_05_01)
                {
                    Parent = zone,
                    Name = "@",
                    TtlInSeconds = 3600,
                    TxtRecords = {
                        new DnsTxtRecordInfo()
                        {
                            Values = [ "v=spf1 -all" ]
                        }
                    }
                };
                infra.Add(spfTxtRecord);

                DnsTxtRecord notesTXTRecord = new(nameof(notesTXTRecord), DnsTxtRecord.ResourceVersions.V2018_05_01)
                {
                    Parent = zone,
                    Name = "notes",
                    TtlInSeconds = 3600,
                    TxtRecords = {
                        new DnsTxtRecordInfo()
                        {
                            Values = [
                                "Usually people set SPF rules in TXT records.",
                                "But they are actually free form text records."
                            ]
                        }
                    }
                };
                infra.Add(notesTXTRecord);

                return infra;
            }
        );

        test.Compare(
            """
            resource zone 'Microsoft.Network/dnsZones@2018-05-01' existing = {
              name: 'contoso.com'
            }

            resource cnameRecord 'Microsoft.Network/dnsZones/CNAME@2018-05-01' = {
              name: 'www'
              parent: zone
              properties: {
                CNAMERecord: {
                  cname: 'contoso.azurewebsites.net'
                }
                TTL: 3600
              }
            }

            resource dnsRecordA 'Microsoft.Network/dnsZones/A@2018-05-01' = {
              name: 'privatev4'
              parent: zone
              properties: {
                ARecords: [
                  {
                    ipv4Address: '127.0.0.1'
                  }
                  {
                    ipv4Address: '192.168.0.1'
                  }
                ]
                TTL: 3600
              }
            }

            resource aaaaRecord 'Microsoft.Network/dnsZones/AAAA@2018-05-01' = {
              name: 'privatev6'
              parent: zone
              properties: {
                AAAARecords: [
                  {
                    ipv6Address: '::1'
                  }
                  {
                    ipv6Address: 'fd00::45:aa:1'
                  }
                ]
                TTL: 3600
              }
            }

            resource spfTxtRecord 'Microsoft.Network/dnsZones/TXT@2018-05-01' = {
              name: '@'
              properties: {
                TXTRecords: [
                  {
                    value: [
                      'v=spf1 -all'
                    ]
                  }
                ]
                TTL: 3600
              }
              parent: zone
            }

            resource notesTXTRecord 'Microsoft.Network/dnsZones/TXT@2018-05-01' = {
              name: 'notes'
              properties: {
                TXTRecords: [
                  {
                    value: [
                      'Usually people set SPF rules in TXT records.'
                      'But they are actually free form text records.'
                    ]
                  }
                ]
                TTL: 3600
              }
              parent: zone
            }
            """
        );
    }
}
