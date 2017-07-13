// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update
{
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNSRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMXRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateCNameRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet;

    /// <summary>
    /// The stage of the NS record set definition allowing to add or remove a NS record.
    /// </summary>
    public interface IWithNSRecordNameServer
    {
        /// <summary>
        /// Rmoves a NS record with the provided name server from this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet WithoutNameServer(string nameServerHostName);

        /// <summary>
        /// Creates a NS record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet WithNameServer(string nameServerHostName);
    }

    /// <summary>
    /// The stage of the SOA record definition allowing to update its attributes.
    /// </summary>
    public interface IWithSoaRecordAttributes
    {
        /// <summary>
        /// Specifies time in seconds that a secondary name server should wait before trying to contact the
        /// the primary name server for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The refresh time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord WithRefreshTimeInSeconds(long refreshTimeInSeconds);

        /// <summary>
        /// Specifies the email server associated with the SOA record.
        /// </summary>
        /// <param name="emailServerHostName">The email server.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord WithEmailServer(string emailServerHostName);

        /// <summary>
        /// Specifies the serial number for the zone file.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord WithSerialNumber(long serialNumber);

        /// <summary>
        /// Specifies the time in seconds that a secondary name server will treat its cached zone file as valid
        /// when the primary name server cannot be contacted.
        /// </summary>
        /// <param name="expireTimeInSeconds">The expire time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord WithExpireTimeInSeconds(long expireTimeInSeconds);

        /// <summary>
        /// Specifies the time in seconds that a secondary name server should wait before trying to contact
        /// the primary name server again after a failed attempt to check for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The retry time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord WithRetryTimeInSeconds(long refreshTimeInSeconds);

        /// <summary>
        /// Specifies the time in seconds that any name server or resolver should cache a negative response.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The TTL for cached negative response.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive);
    }

    /// <summary>
    /// The stage of the SRV record definition allowing to add or remove service record.
    /// </summary>
    public interface IWithSrvRecordEntry
    {
        /// <summary>
        /// Removes a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host.</param>
        /// <param name="weight">The relative weight (preference) of the records.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet WithoutRecord(string target, int port, int priority, int weight);

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet WithRecord(string target, int port, int priority, int weight);
    }

    /// <summary>
    /// The set of configurations that can be updated for DNS record set irrespective of their type  RecordType.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithTtl,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithMetadata,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithETagCheck
    {
    }

    /// <summary>
    /// The stage of the MX record set definition allowing to add or remove MX record.
    /// </summary>
    public interface IWithMXRecordMailExchange
    {
        /// <summary>
        /// Removes MX record with the provided mail exchange server and priority from this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet WithoutMailExchange(string mailExchangeHostName, int priority);

        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet WithMailExchange(string mailExchangeHostName, int priority);
    }

    /// <summary>
    /// The stage of the AAAA record set update allowing to add or remove AAAA record.
    /// </summary>
    public interface IWithAaaaRecordIPv6Address
    {
        /// <summary>
        /// Creates an AAAA record with the provided IPv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet WithIPv6Address(string ipv6Address);

        /// <summary>
        /// Removes an AAAA record with the provided IPv6 address from this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet WithoutIPv6Address(string ipv6Address);
    }

    /// <summary>
    /// The stage of the CNAME record set update allowing to update the CNAME record.
    /// </summary>
    public interface IWithCNameRecordAlias :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithCNameRecordAliasBeta
    {
    }

    /// <summary>
    /// The stage of the CName record set definition allowing to add or remove CName record.
    /// </summary>
    public interface IWithPtrRecordTargetDomainName
    {
        /// <summary>
        /// Creates a CName record with the provided canonical name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet WithTargetDomainName(string targetDomainName);

        /// <summary>
        /// Removes the CName record with the provided canonical name from this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet WithoutTargetDomainName(string targetDomainName);
    }

    /// <summary>
    /// The stage of the record set update allowing to enable ETag validation.
    /// </summary>
    public interface IWithETagCheck :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithETagCheckBeta
    {
    }

    /// <summary>
    /// The stage of the SRV record definition allowing to add or remove TXT record.
    /// </summary>
    public interface IWithTxtRecordTextValue :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IWithTxtRecordTextValueBeta
    {
        /// <summary>
        /// Removes a Txt record with the given text from this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet WithoutText(string text);

        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet WithText(string text);
    }

    /// <summary>
    /// The stage of the record set update allowing to specify TTL for the records in this record set.
    /// </summary>
    public interface IWithTtl
    {
        /// <summary>
        /// Specifies the TTL for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">TTL in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate WithTimeToLive(long ttlInSeconds);
    }

    /// <summary>
    /// An update allowing metadata to be modified for the resource.
    /// </summary>
    public interface IWithMetadata
    {
        /// <summary>
        /// Removes a metadata from the record set.
        /// </summary>
        /// <param name="key">The key of the metadata to remove.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate WithoutMetadata(string key);

        /// <summary>
        /// Adds a metadata to the record set.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate WithMetadata(string key, string value);
    }

    /// <summary>
    /// The stage of the A record set update allowing to add or remove A record.
    /// </summary>
    public interface IWithARecordIPv4Address
    {
        /// <summary>
        /// Removes the A record with the provided IPv4 address from the record set.
        /// </summary>
        /// <param name="ipv4Address">An IPv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet.IUpdateARecordSet WithoutIPv4Address(string ipv4Address);

        /// <summary>
        /// Creates an A record with the provided IPv4 address in the record set.
        /// </summary>
        /// <param name="ipv4Address">An IPv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet.IUpdateARecordSet WithIPv4Address(string ipv4Address);
    }

    /// <summary>
    /// The stage of the CNAME record set update allowing to update the CNAME record.
    /// </summary>
    public interface IWithCNameRecordAliasBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// The new alias for the CNAME record set.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateCNameRecordSet.IUpdateCNameRecordSet WithAlias(string alias);
    }

    /// <summary>
    /// The stage of the record set update allowing to enable ETag validation.
    /// </summary>
    public interface IWithETagCheckBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that If-Match header needs to set to the current eTag value associated
        /// with the record set.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate WithETagCheck();

        /// <summary>
        /// Specifies that if-Match header needs to set to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update.IUpdate WithETagCheck(string eTagValue);
    }

    /// <summary>
    /// The stage of the SRV record definition allowing to add or remove TXT record.
    /// </summary>
    public interface IWithTxtRecordTextValueBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Removes a Txt record with the given text (split into 255 char chunks) from this record set.
        /// </summary>
        /// <param name="textChunks">The text value as list.</param>
        /// <return>The next stage of the record set update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet WithoutText(IList<string> textChunks);
    }
}