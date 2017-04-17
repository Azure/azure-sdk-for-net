// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of the MX record set definition allowing to add first MX record.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithMXRecordMailExchange<ParentT> 
    {
        /// <summary>
        /// Creates and assigns priority to a MX record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchangeOrAttachable<ParentT> WithMailExchange(string mailExchangeHostName, int priority);
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add first A record.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithARecordIPv4Address<ParentT> 
    {
        /// <summary>
        /// Creates an A record with the provided IPv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The IPv4 address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithARecordIPv4AddressOrAttachable<ParentT> WithIPv4Address(string ipv4Address);
    }

    /// <summary>
    /// The stage of the SRV record definition allowing to add first service record.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithSrvRecordEntry<ParentT> 
    {
        /// <summary>
        /// Specifies a service record for a service.
        /// </summary>
        /// <param name="target">The canonical name of the target host running the service.</param>
        /// <param name="port">The port on which the service is bounded.</param>
        /// <param name="priority">The priority of the target host, lower the value higher the priority.</param>
        /// <param name="weight">The relative weight (preference) of the records with the same priority, higher the value more the preference.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithSrvRecordEntryOrAttachable<ParentT> WithRecord(string target, int port, int priority, int weight);
    }

    /// <summary>
    /// The first stage of an MX record definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IMXRecordSetBlank<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchange<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a SRV record definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface ISrvRecordSetBlank<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithSrvRecordEntry<ParentT>
    {
    }

    /// <summary>
    /// The stage of the TXT record definition allowing to add first Txt record.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithTxtRecordTextValue<ParentT> 
    {
        /// <summary>
        /// Creates a TXT record with the given text in this record set.
        /// </summary>
        /// <param name="text">The text value.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValueOrAttachable<ParentT> WithText(string text);
    }

    /// <summary>
    /// The first stage of a TXT record definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface ITxtRecordSetBlank<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValue<ParentT>
    {
    }

    /// <summary>
    /// The stage of the SRV record set definition allowing to add additional SRV records or attach the record set
    /// to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithSrvRecordEntryOrAttachable<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithSrvRecordEntry<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add additional A records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithARecordIPv4AddressOrAttachable<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithARecordIPv4Address<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the MX record set definition allowing to add additional MX records or attach the record set
    /// to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithMXRecordMailExchangeOrAttachable<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchange<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the NS record set definition allowing to add additional NS records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithNSRecordNameServerOrAttachable<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithNSRecordNameServer<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the AAAA record set definition allowing to add additional A records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAaaaRecordIPv6AddressOrAttachable<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6Address<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a A record definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IARecordSetBlank<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithARecordIPv4Address<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the DNS zone record set definition.
    /// At this stage, any remaining optional settings can be specified, or the DNS zone record set
    /// definition can be attached to the parent traffic manager profile definition
    /// using  DnsRecordSet.UpdateDefinitionStages.WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  DnsRecordSet.UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithMetadata<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithTtl<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a AAAA record definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IAaaaRecordSetBlank<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6Address<ParentT>
    {
    }

    /// <summary>
    /// The stage of the NS record set definition allowing to add a NS record.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithNSRecordNameServer<ParentT> 
    {
        /// <summary>
        /// Creates a NS record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithNSRecordNameServerOrAttachable<ParentT> WithNameServer(string nameServerHostName);
    }

    /// <summary>
    /// The stage of the record set definition allowing to specify metadata.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithMetadata<ParentT> 
    {
        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the metadata.</param>
        /// <param name="value">The value for the metadata.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT> WithMetadata(string key, string value);
    }

    /// <summary>
    /// The entirety of a DNS zone record set definition as a part of parent update.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IARecordSetBlank<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithARecordIPv4Address<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithARecordIPv4AddressOrAttachable<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6Address<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6AddressOrAttachable<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IMXRecordSetBlank<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchange<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithMXRecordMailExchangeOrAttachable<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.INSRecordSetBlank<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithNSRecordNameServer<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithNSRecordNameServerOrAttachable<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainName<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainNameOrAttachable<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithSrvRecordEntry<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithSrvRecordEntryOrAttachable<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValue<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValueOrAttachable<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a PTR record definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IPtrRecordSetBlank<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainName<ParentT>
    {
    }

    /// <summary>
    /// The stage of the record set definition allowing to specify TTL for the records in this record set.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithTtl<ParentT> 
    {
        /// <summary>
        /// Specifies the TTL for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">TTL in seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT> WithTimeToLive(long ttlInSeconds);
    }

    /// <summary>
    /// The stage of the PTR record set definition allowing to add first CNAME record.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithPtrRecordTargetDomainName<ParentT> 
    {
        /// <summary>
        /// Creates a PTR record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainNameOrAttachable<ParentT> WithTargetDomainName(string targetDomainName);
    }

    /// <summary>
    /// The first stage of a NS record definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface INSRecordSetBlank<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithNSRecordNameServer<ParentT>
    {
    }

    /// <summary>
    /// The stage of the TXT record set definition allowing to add additional TXT records or attach the record set
    /// to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithTxtRecordTextValueOrAttachable<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithTxtRecordTextValue<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the AAAA record set definition allowing to add first AAAA record.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAaaaRecordIPv6Address<ParentT> 
    {
        /// <summary>
        /// Creates an AAAA record with the provided IPv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAaaaRecordIPv6AddressOrAttachable<ParentT> WithIPv6Address(string ipv6Address);
    }

    /// <summary>
    /// The stage of the PTR record set definition allowing to add additional PTR records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithPtrRecordTargetDomainNameOrAttachable<ParentT>  :
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithPtrRecordTargetDomainName<ParentT>,
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IWithAttach<ParentT>
    {
    }
}