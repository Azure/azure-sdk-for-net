// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using DnsRecordSet.Definition;
    using DnsRecordSet.UpdateCombined;
    using DnsRecordSet.UpdateDefinition;
    using DnsRecordSet.Update;
    using DnsZone.Definition;
    using DnsZone.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;
    using Models;

    internal abstract partial class DnsRecordSetImpl 
    {
        /// <summary>
        /// Rmoves a NS record with the provided name server from this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet DnsRecordSet.Update.IWithNSRecordNameServer.WithoutNameServer(string nameServerHostName)
        {
            return this.WithoutNameServer(nameServerHostName) as DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet;
        }

        /// <summary>
        /// Creates a NS record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet DnsRecordSet.Update.IWithNSRecordNameServer.WithNameServer(string nameServerHostName)
        {
            return this.WithNameServer(nameServerHostName) as DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet;
        }

        /// <summary>
        /// Removes a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host.</param>
        /// <param name="weight">The relative weight (preference) of the records.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet DnsRecordSet.Update.IWithSrvRecordEntry.WithoutRecord(string target, int port, int priority, int weight)
        {
            return this.WithoutRecord(target, port, priority, weight) as DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet;
        }

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet DnsRecordSet.Update.IWithSrvRecordEntry.WithRecord(string target, int port, int priority, int weight)
        {
            return this.WithRecord(target, port, priority, weight) as DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet;
        }

        /// <summary>
        /// Specifies the Ttl for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">Ttl in seconds.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithAttach<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithTtl<DnsZone.Update.IUpdate>.WithTimeToLive(long ttlInSeconds)
        {
            return this.WithTimeToLive(ttlInSeconds) as DnsRecordSet.UpdateDefinition.IWithAttach<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the Ttl for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">Ttl in seconds.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithAttach<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithTtl<DnsZone.Definition.IWithCreate>.WithTimeToLive(long ttlInSeconds)
        {
            return this.WithTimeToLive(ttlInSeconds) as DnsRecordSet.Definition.IWithAttach<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Removes a metadata from the record set.
        /// </summary>
        /// <param name="key">The key of the metadata to remove.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.Update.IUpdate DnsRecordSet.Update.IWithMetadata.WithoutMetadata(string key)
        {
            return this.WithoutMetadata(key) as DnsRecordSet.Update.IUpdate;
        }

        /// <summary>
        /// Adds a metadata to the record set.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.Update.IUpdate DnsRecordSet.Update.IWithMetadata.WithMetadata(string key, string value)
        {
            return this.WithMetadata(key, value) as DnsRecordSet.Update.IUpdate;
        }

        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet DnsRecordSet.Update.IWithTxtRecordTextValue.WithText(string text)
        {
            return this.WithText(text) as DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet;
        }

        /// <summary>
        /// Removes a Txt record with the given text from this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet DnsRecordSet.Update.IWithTxtRecordTextValue.WithoutText(string text)
        {
            return this.WithoutText(text) as DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet;
        }

        /// <summary>
        /// Creates an Aaaa record with the provided Ipv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet DnsRecordSet.Update.IWithAaaaRecordIPv6Address.WithIPv6Address(string ipv6Address)
        {
            return this.WithIpv6Address(ipv6Address) as DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet;
        }

        /// <summary>
        /// Removes an Aaaa record with the provided Ipv6 address from this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet DnsRecordSet.Update.IWithAaaaRecordIPv6Address.WithoutIPv6Address(string ipv6Address)
        {
            return this.WithoutIpv6Address(ipv6Address) as DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet;
        }

        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValueOrAttachable<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValue<DnsZone.Update.IUpdate>.WithText(string text)
        {
            return this.WithText(text) as DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValueOrAttachable<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithTxtRecordTextValueOrAttachable<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithTxtRecordTextValue<DnsZone.Definition.IWithCreate>.WithText(string text)
        {
            return this.WithText(text) as DnsRecordSet.Definition.IWithTxtRecordTextValueOrAttachable<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Removes the A record with the provided Ipv4 address from the record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateARecordSet.IUpdateARecordSet DnsRecordSet.Update.IWithARecordIPv4Address.WithoutIPv4Address(string ipv4Address)
        {
            return this.WithoutIpv4Address(ipv4Address) as DnsRecordSet.UpdateARecordSet.IUpdateARecordSet;
        }

        /// <summary>
        /// Creates an A record with the provided Ipv4 address in the record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateARecordSet.IUpdateARecordSet DnsRecordSet.Update.IWithARecordIPv4Address.WithIPv4Address(string ipv4Address)
        {
            return this.WithIpv4Address(ipv4Address) as DnsRecordSet.UpdateARecordSet.IUpdateARecordSet;
        }

        /// <summary>
        /// Specifies the Ttl for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">Ttl in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.Update.IUpdate DnsRecordSet.Update.IWithTtl.WithTimeToLive(long ttlInSeconds)
        {
            return this.WithTimeToLive(ttlInSeconds) as DnsRecordSet.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithSrvRecordEntryOrAttachable<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithSrvRecordEntry<DnsZone.Update.IUpdate>.WithRecord(string target, int port, int priority, int weight)
        {
            return this.WithRecord(target, port, priority, weight) as DnsRecordSet.UpdateDefinition.IWithSrvRecordEntryOrAttachable<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithSrvRecordEntryOrAttachable<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithSrvRecordEntry<DnsZone.Definition.IWithCreate>.WithRecord(string target, int port, int priority, int weight)
        {
            return this.WithRecord(target, port, priority, weight) as DnsRecordSet.Definition.IWithSrvRecordEntryOrAttachable<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        DnsZone.Update.IUpdate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<DnsZone.Update.IUpdate>.Attach()
        {
            return this.Attach() as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Creates an A record with the provided Ipv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithARecordIPv4AddressOrAttachable<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithARecordIPv4Address<DnsZone.Update.IUpdate>.WithIpv4Address(string ipv4Address)
        {
            return this.WithIpv4Address(ipv4Address) as DnsRecordSet.UpdateDefinition.IWithARecordIPv4AddressOrAttachable<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Creates an A record with the provided Ipv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithARecordIPv4AddressOrAttachable<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithARecordIPv4Address<DnsZone.Definition.IWithCreate>.WithIPv4Address(string ipv4Address)
        {
            return this.WithIpv4Address(ipv4Address) as DnsRecordSet.Definition.IWithARecordIPv4AddressOrAttachable<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        DnsZone.Definition.IWithCreate Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<DnsZone.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as DnsZone.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates a NS record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithNSRecordNameServerOrAttachable<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithNSRecordNameServer<DnsZone.Update.IUpdate>.WithNameServer(string nameServerHostName)
        {
            return this.WithNameServer(nameServerHostName) as DnsRecordSet.UpdateDefinition.IWithNSRecordNameServerOrAttachable<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a NS record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithNSRecordNameServerOrAttachable<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithNSRecordNameServer<DnsZone.Definition.IWithCreate>.WithNameServer(string nameServerHostName)
        {
            return this.WithNameServer(nameServerHostName) as DnsRecordSet.Definition.IWithNSRecordNameServerOrAttachable<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet DnsRecordSet.Update.IWithMXRecordMailExchange.WithMailExchange(string mailExchangeHostName, int priority)
        {
            return this.WithMailExchange(mailExchangeHostName, priority) as DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet;
        }

        /// <summary>
        /// Removes MX record with the provided mail exchange server and priority from this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet DnsRecordSet.Update.IWithMXRecordMailExchange.WithoutMailExchange(string mailExchangeHostName, int priority)
        {
            return this.WithoutMailExchange(mailExchangeHostName, priority) as DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet;
        }

        /// <summary>
        /// Specifies time in seconds that a secondary name server should wait before trying to contact the
        /// the primary name server for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The refresh time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord DnsRecordSet.Update.IWithSoaRecordAttributes.WithRefreshTimeInSeconds(long refreshTimeInSeconds)
        {
            return this.WithRefreshTimeInSeconds(refreshTimeInSeconds) as DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord;
        }

        /// <summary>
        /// Specifies the email server associated with the Soa record.
        /// </summary>
        /// <param name="emailServerHostName">The email server.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord DnsRecordSet.Update.IWithSoaRecordAttributes.WithEmailServer(string emailServerHostName)
        {
            return this.WithEmailServer(emailServerHostName) as DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord;
        }

        /// <summary>
        /// Specifies the time in seconds that any name server or resolver should cache a negative response.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The Ttl for cached negative response.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord DnsRecordSet.Update.IWithSoaRecordAttributes.WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive)
        {
            return this.WithNegativeResponseCachingTimeToLiveInSeconds(negativeCachingTimeToLive) as DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord;
        }

        /// <summary>
        /// Specifies the time in seconds that a secondary name server should wait before trying to contact
        /// the primary name server again after a failed attempt to check for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The retry time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord DnsRecordSet.Update.IWithSoaRecordAttributes.WithRetryTimeInSeconds(long refreshTimeInSeconds)
        {
            return this.WithRetryTimeInSeconds(refreshTimeInSeconds) as DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord;
        }

        /// <summary>
        /// Specifies the serial number for the zone file.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord DnsRecordSet.Update.IWithSoaRecordAttributes.WithSerialNumber(long serialNumber)
        {
            return this.WithSerialNumber(serialNumber) as DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord;
        }

        /// <summary>
        /// Specifies the time in seconds that a secondary name server will treat its cached zone file as valid
        /// when the primary name server cannot be contacted.
        /// </summary>
        /// <param name="expireTimeInSeconds">The expire time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord DnsRecordSet.Update.IWithSoaRecordAttributes.WithExpireTimeInSeconds(long expireTimeInSeconds)
        {
            return this.WithExpireTimeInSeconds(expireTimeInSeconds) as DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord;
        }

        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchangeOrAttachable<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchange<DnsZone.Update.IUpdate>.WithMailExchange(string mailExchangeHostName, int priority)
        {
            return this.WithMailExchange(mailExchangeHostName, priority) as DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchangeOrAttachable<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithMXRecordMailExchangeOrAttachable<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithMXRecordMailExchange<DnsZone.Definition.IWithCreate>.WithMailExchange(string mailExchangeHostName, int priority)
        {
            return this.WithMailExchange(mailExchangeHostName, priority) as DnsRecordSet.Definition.IWithMXRecordMailExchangeOrAttachable<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithAttach<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithMetadata<DnsZone.Update.IUpdate>.WithMetadata(string key, string value)
        {
            return this.WithMetadata(key, value) as DnsRecordSet.UpdateDefinition.IWithAttach<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Adds a metadata to the resource.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithAttach<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithMetadata<DnsZone.Definition.IWithCreate>.WithMetadata(string key, string value)
        {
            return this.WithMetadata(key, value) as DnsRecordSet.Definition.IWithAttach<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Gets the metadata associated with this record set.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet.Metadata
        {
            get
            {
                return this.Metadata() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets TTL of the records in this record set.
        /// </summary>
        long Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet.TimeToLive
        {
            get
            {
                return this.TimeToLive();
            }
        }

        /// <summary>
        /// Gets the type of records in this record set.
        /// </summary>
        RecordType Microsoft.Azure.Management.Dns.Fluent.IDnsRecordSet.RecordType
        {
            get
            {
                return this.RecordType();
            }
        }

        /// <summary>
        /// Creates a Ptr record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainNameOrAttachable<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainName<DnsZone.Update.IUpdate>.WithTargetDomainName(string targetDomainName)
        {
            return this.WithTargetDomainName(targetDomainName) as DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainNameOrAttachable<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Creates a Ptr record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithPtrRecordTargetDomainNameOrAttachable<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithPtrRecordTargetDomainName<DnsZone.Definition.IWithCreate>.WithTargetDomainName(string targetDomainName)
        {
            return this.WithTargetDomainName(targetDomainName) as DnsRecordSet.Definition.IWithPtrRecordTargetDomainNameOrAttachable<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates an Aaaa record with the provided Ipv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6AddressOrAttachable<DnsZone.Update.IUpdate> DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6Address<DnsZone.Update.IUpdate>.WithIpv6Address(string ipv6Address)
        {
            return this.WithIpv6Address(ipv6Address) as DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6AddressOrAttachable<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Creates an Aaaa record with the provided Ipv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set definition.</return>
        DnsRecordSet.Definition.IWithAaaaRecordIPv6AddressOrAttachable<DnsZone.Definition.IWithCreate> DnsRecordSet.Definition.IWithAaaaRecordIPv6Address<DnsZone.Definition.IWithCreate>.WithIPv6Address(string ipv6Address)
        {
            return this.WithIpv6Address(ipv6Address) as DnsRecordSet.Definition.IWithAaaaRecordIPv6AddressOrAttachable<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Creates a CName record with the provided canonical name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet DnsRecordSet.Update.IWithPtrRecordTargetDomainName.WithTargetDomainName(string targetDomainName)
        {
            return this.WithTargetDomainName(targetDomainName) as DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet;
        }

        /// <summary>
        /// Removes the CName record with the provided canonical name from this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet DnsRecordSet.Update.IWithPtrRecordTargetDomainName.WithoutTargetDomainName(string targetDomainName)
        {
            return this.WithoutTargetDomainName(targetDomainName) as DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet;
        }
    }
}