// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of the MX record set definition allowing to add additional MX records or attach the record set
    /// to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithMXRecordMailExchangeOrAttachable<ParentT>  :
        IWithMXRecordMailExchange<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a MX record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IMXRecordSetBlank<ParentT>  :
        IWithMXRecordMailExchange<ParentT>
    {
    }

    /// <summary>
    /// The stage of the Srv record definition allowing to add first service record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithSrvRecordEntry<ParentT> 
    {
        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithSrvRecordEntryOrAttachable<ParentT> WithRecord(string target, int port, int priority, int weight);
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add additional A records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithARecordIPv4AddressOrAttachable<ParentT>  :
        IWithARecordIPv4Address<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a Srv record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface ISrvRecordSetBlank<ParentT>  :
        IWithSrvRecordEntry<ParentT>
    {
    }

    /// <summary>
    /// The stage of the Aaaa record set definition allowing to add first Aaaa record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAaaaRecordIPv6Address<ParentT> 
    {
        /// <summary>
        /// Creates an Aaaa record with the provided Ipv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6AddressOrAttachable<ParentT> WithIpv6Address(string ipv6Address);
    }

    /// <summary>
    /// The stage of the Srv record definition allowing to add first Txt record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithTxtRecordTextValue<ParentT> 
    {
        /// <summary>
        /// Creates a Txt record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValueOrAttachable<ParentT> WithText(string text);
    }

    /// <summary>
    /// The first stage of a Txt record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface ITxtRecordSetBlank<ParentT>  :
        IWithTxtRecordTextValue<ParentT>
    {
    }

    /// <summary>
    /// The stage of the Srv record set definition allowing to add additional Srv records or attach the record set
    /// to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithSrvRecordEntryOrAttachable<ParentT>  :
        IWithSrvRecordEntry<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the NS record set definition allowing to add a NS record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithNSRecordNameServer<ParentT> 
    {
        /// <summary>
        /// Creates a NS record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithNSRecordNameServerOrAttachable<ParentT> WithNameServer(string nameServerHostName);
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add first A record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithARecordIPv4Address<ParentT> 
    {
        /// <summary>
        /// Creates an A record with the provided Ipv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithARecordIPv4AddressOrAttachable<ParentT> WithIpv4Address(string ipv4Address);
    }

    /// <summary>
    /// The stage of the Aaaa record set definition allowing to add additional A records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAaaaRecordIPv6AddressOrAttachable<ParentT>  :
        IWithAaaaRecordIPv6Address<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a A record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IARecordSetBlank<ParentT>  :
        IWithARecordIPv4Address<ParentT>
    {
    }

    /// <summary>
    /// The stage of the NS record set definition allowing to add additional NS records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithNSRecordNameServerOrAttachable<ParentT>  :
        IWithNSRecordNameServer<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the DNS zone record set definition.
    /// At this stage, any remaining optional settings can be specified, or the DNS zone record set
    /// definition can be attached to the parent traffic manager profile definition
    /// using DnsRecordSet.UpdateDefinitionStages.WithAttach.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of DnsRecordSet.UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>,
        IWithMetadata<ParentT>,
        IWithTtl<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a Aaaa record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IAaaaRecordSetBlank<ParentT>  :
        IWithAaaaRecordIPv6Address<ParentT>
    {
    }

    /// <summary>
    /// The stage of the record set definition allowing to specify metadata.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithMetadata<ParentT> 
    {
        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT> WithMetadata(string key, string value);
    }

    /// <summary>
    /// The entirety of a DNS zone record set definition as a part of parent update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IARecordSetBlank<ParentT>,
        IWithARecordIPv4Address<ParentT>,
        IWithARecordIPv4AddressOrAttachable<ParentT>,
        IAaaaRecordSetBlank<ParentT>,
        IWithAaaaRecordIPv6Address<ParentT>,
        IWithAaaaRecordIPv6AddressOrAttachable<ParentT>,
        IMXRecordSetBlank<ParentT>,
        IWithMXRecordMailExchange<ParentT>,
        IWithMXRecordMailExchangeOrAttachable<ParentT>,
        INSRecordSetBlank<ParentT>,
        IWithNSRecordNameServer<ParentT>,
        IWithNSRecordNameServerOrAttachable<ParentT>,
        IPtrRecordSetBlank<ParentT>,
        IWithPtrRecordTargetDomainName<ParentT>,
        IWithPtrRecordTargetDomainNameOrAttachable<ParentT>,
        ISrvRecordSetBlank<ParentT>,
        IWithSrvRecordEntry<ParentT>,
        IWithSrvRecordEntryOrAttachable<ParentT>,
        ITxtRecordSetBlank<ParentT>,
        IWithTxtRecordTextValue<ParentT>,
        IWithTxtRecordTextValueOrAttachable<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a PTR record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IPtrRecordSetBlank<ParentT>  :
        IWithPtrRecordTargetDomainName<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a NS record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface INSRecordSetBlank<ParentT>  :
        IWithNSRecordNameServer<ParentT>
    {
    }

    /// <summary>
    /// The stage of the MX record set definition allowing to add first MX record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithMXRecordMailExchange<ParentT> 
    {
        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchangeOrAttachable<ParentT> WithMailExchange(string mailExchangeHostName, int priority);
    }

    /// <summary>
    /// The stage of the record set definition allowing to specify TTL for the records in this record set.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithTtl<ParentT> 
    {
        /// <summary>
        /// Specifies the Ttl for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">Ttl in seconds.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT> WithTimeToLive(long ttlInSeconds);
    }

    /// <summary>
    /// The stage of the PTR record set definition allowing to add first CNAME record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithPtrRecordTargetDomainName<ParentT> 
    {
        /// <summary>
        /// Creates a PTR record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainNameOrAttachable<ParentT> WithTargetDomainName(string targetDomainName);
    }

    /// <summary>
    /// The stage of the Txt record set definition allowing to add additional Txt records or attach the record set
    /// to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithTxtRecordTextValueOrAttachable<ParentT>  :
        IWithTxtRecordTextValue<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the PTR record set definition allowing to add additional PTR records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithPtrRecordTargetDomainNameOrAttachable<ParentT>  :
        IWithPtrRecordTargetDomainName<ParentT>,
        IWithAttach<ParentT>
    {
    }
}