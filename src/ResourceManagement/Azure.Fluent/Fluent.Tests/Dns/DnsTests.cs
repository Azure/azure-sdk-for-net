// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Dns.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.Dns
{
    public class DnsTests
    {
        [Fact]
        public void CanCreateUpdateDnsZone()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.US_EAST;
                var groupName = TestUtilities.GenerateName("rgdnschash");
                var topLevelDomain = $"{TestUtilities.GenerateName("www.contoso-")}.com";

                var azure = TestHelper.CreateRollupClient();

                try
                {
                    IDnsZone dnsZone = azure.DnsZones.Define(topLevelDomain)
                    .WithNewResourceGroup(groupName, region)
                    .DefineARecordSet("www")
                        .WithIpv4Address("23.96.104.40")
                        .WithIpv4Address("24.97.105.41")
                        .WithTimeToLive(7200) // Overwrite default 3600 seconds
                        .Attach()
                    .DefineAaaaRecordSet("www")
                        .WithIpv6Address("2001:0db8:85a3:0000:0000:8a2e:0370:7334")
                        .WithIpv6Address("2002:0db9:85a4:0000:0000:8a2e:0371:7335")
                        .Attach()
                    .DefineMxRecordSet("email")
                        .WithMailExchange("mail.contoso-mail-exchange1.com", 1)
                        .WithMailExchange("mail.contoso-mail-exchange2.com", 2)
                        .WithMetadata("mxa", "mxaa")
                        .WithMetadata("mxb", "mxbb")
                        .Attach()
                    .DefineNsRecordSet("partners")
                        .WithNameServer("ns1-05.azure-dns.com")
                        .WithNameServer("ns2-05.azure-dns.net")
                        .WithNameServer("ns3-05.azure-dns.org")
                        .WithNameServer("ns4-05.azure-dns.info")
                        .Attach()
                    .DefineTxtRecordSet("@")
                        .WithText("windows-apps-verification=2ZzjfideIJFLFje83")
                        .Attach()
                    .DefineTxtRecordSet("www")
                        .WithText("some info about www.contoso.com")
                        .Attach()
                    .DefineSrvRecordSet("_sip._tcp")
                        .WithRecord("bigbox.contoso-service.com", 5060, 10, 60)
                        .WithRecord("smallbox1.contoso-service.com", 5060, 10, 20)
                        .WithRecord("smallbox2.contoso-service.com", 5060, 10, 20)
                        .WithRecord("backupbox.contoso-service.com", 5060, 10, 0)
                        .Attach()
                    .DefinePtrRecordSet("40")
                        .WithTargetDomainName("www.contoso.com")
                        .WithTargetDomainName("mail.contoso.com")
                        .Attach()
                    .DefinePtrRecordSet("41")
                        .WithTargetDomainName("www.contoso.com")
                        .WithTargetDomainName("mail.contoso.com")
                        .Attach()
                    .WithCnameRecordSet("documents", "doc.contoso.com")
                    .WithCnameRecordSet("userguide", "doc.contoso.com")
                    .WithTag("a", "aa")
                    .WithTag("b", "bb")
                    .Create();

                    // Check Dns zone properties
                    Assert.True(dnsZone.Name.StartsWith(topLevelDomain));
                    Assert.True(dnsZone.NameServers.Count() > 0); // Default '@' name servers
                    Assert.True(dnsZone.Tags.Count == 2);

                    // Check SOA record - external child resource (created by default)
                    var soaRecordSet = dnsZone.GetSoaRecordSet();
                    Assert.True(soaRecordSet.Name.StartsWith("@"));
                    var soaRecord = soaRecordSet.Record;
                    Assert.NotNull(soaRecord);

                    // Check explicitly created external child resources [A, AAAA, MX, NS, TXT, SRV, PTR, CNAME]
                    //

                    // Check A records
                    var aRecordSets = dnsZone.ARecordSets.List();
                    Assert.True(aRecordSets.Count() == 1);
                    Assert.True(aRecordSets[0].TimeToLive == 7200);

                    // Check AAAA records
                    var aaaaRecordSets = dnsZone.AaaaRecordSets.List();
                    Assert.True(aaaaRecordSets.Count() == 1);
                    Assert.True(aaaaRecordSets[0].Name.StartsWith("www"));
                    Assert.True(aaaaRecordSets[0].Ipv6Addresses.Count() == 2);

                    // Check MX records
                    var mxRecordSets = dnsZone.MxRecordSets.List();
                    Assert.True(mxRecordSets.Count() == 1);
                    var mxRecordSet = mxRecordSets[0];
                    Assert.NotNull(mxRecordSet);
                    Assert.True(mxRecordSet.Name.StartsWith("email"));
                    Assert.True(mxRecordSet.Metadata.Count() == 2);
                    Assert.True(mxRecordSet.Records.Count() == 2);
                    foreach (var mxRecord in mxRecordSet.Records)
                    {
                        Assert.True(mxRecord.Exchange.StartsWith("mail.contoso-mail-exchange1.com")
                                || mxRecord.Exchange.StartsWith("mail.contoso-mail-exchange2.com"));
                        Assert.True(mxRecord.Preference == 1
                                || mxRecord.Preference == 2);
                    }

                    // Check NS records
                    var nsRecordSets = dnsZone.NsRecordSets.List();
                    Assert.True(nsRecordSets.Count() == 2); // One created above with name 'partners' + the default '@'

                    // Check TXT records
                    var txtRecordSets = dnsZone.TxtRecordSets.List();
                    Assert.True(txtRecordSets.Count() == 2);

                    // Check SRV records
                    var srvRecordSets = dnsZone.SrvRecordSets.List();
                    Assert.True(srvRecordSets.Count() == 1);

                    // Check PTR records
                    var ptrRecordSets = dnsZone.PtrRecordSets.List();
                    Assert.True(ptrRecordSets.Count() == 2);

                    // Check CNAME records
                    var cnameRecordSets = dnsZone.CnameRecordSets.List();
                    Assert.True(cnameRecordSets.Count() == 2);

                    dnsZone.Update()
                        .WithoutTxtRecordSet("www")
                        .WithoutCnameRecordSet("userguide")
                        .WithCnameRecordSet("help", "doc.contoso.com")
                        .UpdateNsRecordSet("partners")
                            .WithoutNameServer("ns4-05.azure-dns.info")
                            .WithNameServer("ns4-06.azure-dns.info")
                            .Parent()
                        .UpdateARecordSet("www")
                            .WithoutIpv4Address("23.96.104.40")
                            .WithIpv4Address("23.96.104.42")
                            .Parent()
                        .UpdateSrvRecordSet("_sip._tcp")
                            .WithoutRecord("bigbox.contoso-service.com", 5060, 10, 60)
                            .WithRecord("mainbox.contoso-service.com", 5060, 10, 60)
                            .Parent()
                        .UpdateSoaRecord()
                            .WithNegativeResponseCachingTimeToLiveInSeconds(600)
                            .WithTimeToLive(7200)
                            .Parent()
                        .DefineMxRecordSet("email-internal")
                            .WithMailExchange("mail.contoso-mail-exchange1.com", 1)
                            .WithMailExchange("mail.contoso-mail-exchange2.com", 2)
                            .Attach()
                        .Apply();

                    // Check TXT records
                    txtRecordSets = dnsZone.TxtRecordSets.List();
                    Assert.Equal(1, txtRecordSets.Count());

                    // Check CNAME records
                    cnameRecordSets = dnsZone.CnameRecordSets.List();
                    Assert.Equal(2, cnameRecordSets.Count());
                    foreach (var cnameRecordSet in cnameRecordSets)
                    {
                        Assert.True(cnameRecordSet.CanonicalName.StartsWith("doc.contoso.com"));
                        Assert.True(cnameRecordSet.Name.StartsWith("documents") || cnameRecordSet.Name.StartsWith("help"));
                    }

                    // Check NS records
                    nsRecordSets = dnsZone.NsRecordSets.List();
                    Assert.True(nsRecordSets.Count() == 2); // One created above with name 'partners' + the default '@'
                    foreach (var nsRecordSet in nsRecordSets)
                    {
                        Assert.True(nsRecordSet.Name.StartsWith("partners") || nsRecordSet.Name.StartsWith("@"));
                        if (nsRecordSet.Name.StartsWith("partners"))
                        {
                            Assert.Equal(4, nsRecordSet.NameServers.Count());
                            foreach (var nameServer in nsRecordSet.NameServers)
                            {
                                Assert.False(nameServer.StartsWith("ns4-05.azure-dns.info"));
                            }
                        }
                    }

                    // Check A records
                    aRecordSets = dnsZone.ARecordSets.List();
                    Assert.Equal(1, aRecordSets.Count());
                    var aRecordSet = aRecordSets[0];
                    Assert.Equal(2, aRecordSet.Ipv4Addresses.Count());
                    foreach (var ipV4Address in aRecordSet.Ipv4Addresses)
                    {
                        Assert.False(ipV4Address.StartsWith("23.96.104.40"));
                    }

                    // Check SRV records
                    srvRecordSets = dnsZone.SrvRecordSets.List();
                    Assert.True(srvRecordSets.Count() == 1);
                    var srvRecordSet = srvRecordSets[0];
                    Assert.Equal(4, srvRecordSet.Records.Count());
                    foreach (var srvRecord in srvRecordSet.Records)
                    {
                        Assert.False(srvRecord.Target.StartsWith("bigbox.contoso-service.com"));
                    }

                    // Check SOA Records
                    soaRecordSet = dnsZone.GetSoaRecordSet();
                    Assert.True(soaRecordSet.Name.StartsWith("@"));
                    soaRecord = soaRecordSet.Record;
                    Assert.NotNull(soaRecord);
                    Assert.Equal(600, soaRecord.MinimumTtl);
                    Assert.True(soaRecordSet.TimeToLive == 7200);

                    // Check MX records
                    mxRecordSets = dnsZone.MxRecordSets.List();
                    Assert.True(mxRecordSets.Count() == 2);

                    dnsZone.Update()
                            .UpdateMxRecordSet("email")
                                .WithoutMailExchange("mail.contoso-mail-exchange2.com", 2)
                                .WithoutMetadata("mxa")
                                .WithMetadata("mxc", "mxcc")
                                .WithMetadata("mxd", "mxdd")
                                .Parent()
                            .WithTag("d", "dd")
                            .Apply();

                    Assert.True(dnsZone.Tags.Count() == 3);
                    // Check "mail" MX record
                    mxRecordSet = dnsZone.MxRecordSets.GetByName("email");
                    Assert.True(mxRecordSet.Records.Count() == 1);
                    Assert.True(mxRecordSet.Metadata.Count() == 3);
                    Assert.True(mxRecordSet.Records[0].Exchange.StartsWith("mail.contoso-mail-exchange1.com"));

                    azure.DnsZones.DeleteById(dnsZone.Id);
                }
                catch (Exception exception)
                {
                    Assert.True(false, exception.Message);
                }
                finally
                {
                    azure.ResourceGroups.DeleteByName(groupName);
                }
            }
        }
    }
}
