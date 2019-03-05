// ------------------------------------------------------------------------------------------------
// <copyright file="TestDataGenerator.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace PrivateDns.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.PrivateDns.Models;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    internal static class TestDataGenerator
    {
        private const string DefaultResourceLocation = "Central US";

        private static readonly Random Random;

        static TestDataGenerator()
        {
            Random = new Random();
        }

        public static string GenerateSubscriptionId()
        {
            return Guid.NewGuid().ToString();
        }

        public static string GenerateResourceGroupName()
        {
            return TestUtilities.GenerateName("hydratestrg");
        }

        public static string GeneratePrivateZoneArmId(string subscriptionId, string resourceGroupName, string privateZoneName)
        {
            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}";
        }

        public static string GenerateVirtualNetworkLinkArmId(string subscriptionId, string resourceGroupName, string privateZoneName, string virtualNetworkLinkName)
        {
            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/virtualNetworkLinks/{virtualNetworkLinkName}";
        }

        public static string GenerateVirtualNetworkArmId(string subscriptionId = null, string resourceGroupName = null, string virtualNetworkName = null)
        {
            subscriptionId = subscriptionId ?? GenerateSubscriptionId();
            resourceGroupName = resourceGroupName ?? GenerateResourceGroupName();
            virtualNetworkName = virtualNetworkName ?? GenerateVirtualNetworkName();

            return $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}";
        }

        public static string GeneratePrivateZoneName()
        {
            return TestUtilities.GenerateName("hydratest.privatednszone.com");
        }

        public static string GenerateRecordSetName()
        {
            return TestUtilities.GenerateName("hydratestrecord");
        }

        public static string GenerateVirtualNetworkName()
        {
            return TestUtilities.GenerateName("hydratestvnet");
        }

        public static string GenerateVirtualNetworkLinkName()
        {
            return TestUtilities.GenerateName("hydratestvnetlink");
        }

        public static ResourceGroup GenerateResourceGroup(string location = null)
        {
            return new ResourceGroup
            {
                Location = location ?? DefaultResourceLocation,
            };
        }

        public static PrivateZone GeneratePrivateZone(
            string location = null,
            IDictionary<string, string> tags = null)
        {
            return new PrivateZone
            {
                Location = location,
                Tags = tags,
            };
        }

        public static RecordSet GenerateRecordSet(RecordType recordType)
        {
            switch (recordType)
            {
                case RecordType.A:
                    return GenerateRecordSetWithARecords();
                default:
                    throw new ArgumentOutOfRangeException(nameof(recordType));
            }
        }

        public static VirtualNetworkLink GenerateVirtualNetworkLink(
            string virtualNetworkId = null,
            bool? registrationEnabled = null,
            string location = null,
            IDictionary<string, string> tags = null)
        {
            return new VirtualNetworkLink
            {
                Location = location,
                Tags = tags,
                VirtualNetwork = virtualNetworkId == null ? null : new Microsoft.Azure.Management.PrivateDns.Models.SubResource
                {
                    Id = virtualNetworkId,
                },
                RegistrationEnabled = registrationEnabled,
            };
        }

        public static VirtualNetwork GenerateVirtualNetwork(
            string location = null,
            string addressSpaceCidr = "10.0.0.0/16",
            string subnetName = "Default",
            string subnetAddressSpaceCidr = "10.0.0.0/24")
        {
            return new VirtualNetwork
            {
                AddressSpace = new AddressSpace
                {
                    AddressPrefixes = new List<string>
                    {
                        addressSpaceCidr
                    }
                },
                Subnets = new List<Subnet>
                {
                    new Subnet
                    {
                        Name = subnetName,
                        AddressPrefix = subnetAddressSpaceCidr
                    }
                },
                Location = location ?? DefaultResourceLocation,
            };
        }

        public static RecordSet GenerateRecordSet(
            IDictionary<string, string> metadata = null,
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                Metadata = metadata,
            };
        }

        public static RecordSet GenerateRecordSetWithARecords(
            string ipV4Address = "1.2.3.4",
            IDictionary<string, string> metadata = null,
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                Metadata = metadata,
                ARecords = new List<ARecord>
                {
                    new ARecord
                    {
                        Ipv4Address = ipV4Address,
                    },
                },
            };
        }

        public static RecordSet GenerateRecordSetWithAaaaRecords(
            string ipV6Address = "::1",
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                AaaaRecords = new List<AaaaRecord>
                {
                    new AaaaRecord
                    {
                        Ipv6Address = ipV6Address,
                    },
                },
            };
        }

        public static RecordSet GenerateRecordSetWithCnameRecord(
            string cname = "mycname",
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                CnameRecord = new CnameRecord
                {
                    Cname = cname,
                },
            };
        }

        public static RecordSet GenerateRecordSetWithMxRecords(
            string exchange = "ex.chan.ge",
            int? preference = null,
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                MxRecords = new List<MxRecord>
                {
                    new MxRecord
                    {
                        Exchange = exchange,
                        Preference = preference,
                    },
                },
            };
        }

        public static RecordSet GenerateRecordSetWithPtrRecords(
            string ptrdname = "ptrd.name",
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                PtrRecords = new List<PtrRecord>
                {
                    new PtrRecord
                    {
                        Ptrdname = ptrdname,
                    },
                },
            };
        }

        public static RecordSet GenerateRecordSetWithSrvRecords(
            int? port = 120,
            int priority = 1,
            string target = "targ.et",
            int weight = 5,
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                SrvRecords = new List<SrvRecord>
                {
                    new SrvRecord
                    {
                        Port = port,
                        Priority = priority,
                        Target = target,
                        Weight = weight,
                    },
                },
            };
        }

        public static RecordSet GenerateRecordSetWithTxtRecords(
            string[] value = null,
            uint ttl = 50)
        {
            return new RecordSet
            {
                Ttl = ttl,
                TxtRecords = new List<TxtRecord>
                {
                    new TxtRecord
                    {
                        Value = value,
                    },
                },
            };
        }

        public static IDictionary<string, string> GenerateTags(int numTags = 5, int startFrom = 0)
        {
            var tags = new Dictionary<string, string>();
            for (var i = 0; i < numTags; i++)
            {
                var tagKey = $"tagKey{startFrom + i}";
                var tagValue = $"tagValue{startFrom + i}";

                tags.Add(tagKey, tagValue);
            }

            return tags;
        }

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
