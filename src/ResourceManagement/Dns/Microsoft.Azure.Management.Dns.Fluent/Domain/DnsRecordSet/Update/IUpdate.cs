// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Update
{
    using aaaRecordSet;
    using xtRecordSet;
    using xRecordSet;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update;
    using trRecordSet;
    using oaRecord;
    using RecordSet;
    using sRecordSet;
    using rvRecordSet;

    /// <summary>
    /// The stage of the record set update allowing to specify Ttl for the records in this record set.
    /// </summary>
    public interface IWithTtl 
    {
        /// <summary>
        /// Specifies the Ttl for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">Ttl in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        IUpdate WithTimeToLive(long ttlInSeconds);
    }

    /// <summary>
    /// The stage of the Aaaa record set update allowing to add or remove Aaaa record.
    /// </summary>
    public interface IWithAaaaRecordIpv6Address 
    {
        /// <summary>
        /// Removes an Aaaa record with the provided Ipv6 address from this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        aaaRecordSet.IUpdateAaaaRecordSet WithoutIpv6Address(string ipv6Address);

        /// <summary>
        /// Creates an Aaaa record with the provided Ipv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set update.</return>
        aaaRecordSet.IUpdateAaaaRecordSet WithIpv6Address(string ipv6Address);
    }

    /// <summary>
    /// The stage of the Srv record definition allowing to add or remove Txt record.
    /// </summary>
    public interface IWithTxtRecordTextValue 
    {
        /// <summary>
        /// Removes a Txt record with the given text from this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        xtRecordSet.IUpdateTxtRecordSet WithoutText(string text);

        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set update.</return>
        xtRecordSet.IUpdateTxtRecordSet WithText(string text);
    }

    /// <summary>
    /// The stage of the Mx record set definition allowing to add or remove Mx record.
    /// </summary>
    public interface IWithMxRecordMailExchange 
    {
        /// <summary>
        /// Removes Mx record with the provided mail exchange server and priority from this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        xRecordSet.IUpdateMxRecordSet WithoutMailExchange(string mailExchangeHostName, int priority);

        /// <summary>
        /// Creates and assigns priority to a Mx record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set update.</return>
        xRecordSet.IUpdateMxRecordSet WithMailExchange(string mailExchangeHostName, int priority);
    }

    /// <summary>
    /// The set of configurations that can be updated for Dns record set irrespective of their type RecordType.
    /// </summary>
    public interface IUpdate  :
        ISettable<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate>,
        IWithMetadata,
        IWithTtl
    {
    }

    /// <summary>
    /// The stage of the CName record set definition allowing to add or remove Cname record.
    /// </summary>
    public interface IWithPtrRecordTargetDomainName 
    {
        /// <summary>
        /// Creates a CName record with the provided canonical name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        trRecordSet.IUpdatePtrRecordSet WithTargetDomainName(string targetDomainName);

        /// <summary>
        /// Removes the CName record with the provided canonical name from this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set update.</return>
        trRecordSet.IUpdatePtrRecordSet WithoutTargetDomainName(string targetDomainName);
    }

    /// <summary>
    /// The stage of the Soa record definition allowing to update its attributes.
    /// </summary>
    public interface IWithSoaRecordAttributes 
    {
        /// <summary>
        /// Specifies time in seconds that a secondary name server should wait before trying to contact the
        /// the primary name server for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The refresh time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        oaRecord.IUpdateSoaRecord WithRefreshTimeInSeconds(long refreshTimeInSeconds);

        /// <summary>
        /// Specifies the email server associated with the Soa record.
        /// </summary>
        /// <param name="emailServerHostName">The email server.</param>
        /// <return>The next stage of the record set update.</return>
        oaRecord.IUpdateSoaRecord WithEmailServer(string emailServerHostName);

        /// <summary>
        /// Specifies the serial number for the zone file.
        /// </summary>
        /// <param name="serialNumber">The serial number.</param>
        /// <return>The next stage of the record set update.</return>
        oaRecord.IUpdateSoaRecord WithSerialNumber(long serialNumber);

        /// <summary>
        /// Specifies the time in seconds that a secondary name server will treat its cached zone file as valid
        /// when the primary name server cannot be contacted.
        /// </summary>
        /// <param name="expireTimeInSeconds">The expire time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        oaRecord.IUpdateSoaRecord WithExpireTimeInSeconds(long expireTimeInSeconds);

        /// <summary>
        /// Specifies the time in seconds that a secondary name server should wait before trying to contact
        /// the primary name server again after a failed attempt to check for a zone file update.
        /// </summary>
        /// <param name="refreshTimeInSeconds">The retry time in seconds.</param>
        /// <return>The next stage of the record set update.</return>
        oaRecord.IUpdateSoaRecord WithRetryTimeInSeconds(long refreshTimeInSeconds);

        /// <summary>
        /// Specifies the time in seconds that any name server or resolver should cache a negative response.
        /// </summary>
        /// <param name="negativeCachingTimeToLive">The Ttl for cached negative response.</param>
        /// <return>The next stage of the record set update.</return>
        oaRecord.IUpdateSoaRecord WithNegativeResponseCachingTimeToLiveInSeconds(long negativeCachingTimeToLive);
    }

    /// <summary>
    /// The stage of the A record set update allowing to add or remove A record.
    /// </summary>
    public interface IWithARecordIpv4Address 
    {
        /// <summary>
        /// Removes the A record with the provided Ipv4 address from the record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        RecordSet.IUpdateARecordSet WithoutIpv4Address(string ipv4Address);

        /// <summary>
        /// Creates an A record with the provided Ipv4 address in the record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set update.</return>
        RecordSet.IUpdateARecordSet WithIpv4Address(string ipv4Address);
    }

    /// <summary>
    /// The stage of the Ns record set definition allowing to add or remove a Ns record.
    /// </summary>
    public interface IWithNsRecordNameServer 
    {
        /// <summary>
        /// Rmoves a Ns record with the provided name server from this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set update.</return>
        sRecordSet.IUpdateNsRecordSet WithoutNameServer(string nameServerHostName);

        /// <summary>
        /// Creates a Ns record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set update.</return>
        sRecordSet.IUpdateNsRecordSet WithNameServer(string nameServerHostName);
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
        IUpdate WithoutMetadata(string key);

        /// <summary>
        /// Adds a metadata to the record set.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set update.</return>
        IUpdate WithMetadata(string key, string value);
    }

    /// <summary>
    /// The stage of the Srv record definition allowing to add or remove service record.
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
        rvRecordSet.IUpdateSrvRecordSet WithoutRecord(string target, int port, int priority, int weight);

        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set update.</return>
        rvRecordSet.IUpdateSrvRecordSet WithRecord(string target, int port, int priority, int weight);
    }
}