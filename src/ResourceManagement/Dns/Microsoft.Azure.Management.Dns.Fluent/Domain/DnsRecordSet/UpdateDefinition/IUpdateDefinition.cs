// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition
{
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of the Aaaa record set definition allowing to add additional A records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAaaaRecordIpv6AddressOrAttachable<ParentT>  :
        IWithAaaaRecordIpv6Address<ParentT>,
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
    /// The first stage of a Aaaa record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IAaaaRecordSetBlank<ParentT>  :
        IWithAaaaRecordIpv6Address<ParentT>
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
        IWithSrvRecordEntryOrAttachable<ParentT> WithRecord(string target, int port, int priority, int weight);
    }

    /// <summary>
    /// The stage of the Mx record set definition allowing to add additional Mx records or attach the record set
    /// to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithMxRecordMailExchangeOrAttachable<ParentT>  :
        IWithMxRecordMailExchange<ParentT>,
        IWithAttach<ParentT>
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
        IWithAttach<ParentT> WithMetadata(string key, string value);
    }

    /// <summary>
    /// The stage of the Ns record set definition allowing to add additional Ns records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithNsRecordNameServerOrAttachable<ParentT>  :
        IWithNsRecordNameServer<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the record set definition allowing to specify Ttl for the records in this record set.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithTtl<ParentT> 
    {
        /// <summary>
        /// Specifies the Ttl for the records in the record set.
        /// </summary>
        /// <param name="ttlInSeconds">Ttl in seconds.</param>
        /// <return>The next stage of the record set definition.</return>
        IWithAttach<ParentT> WithTimeToLive(long ttlInSeconds);
    }

    /// <summary>
    /// The first stage of a Ptr record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IPtrRecordSetBlank<ParentT>  :
        IWithPtrRecordTargetDomainName<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a A record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IARecordSetBlank<ParentT>  :
        IWithARecordIpv4Address<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a Mx record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IMxRecordSetBlank<ParentT>  :
        IWithMxRecordMailExchange<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a Dns zone record set definition as a part of parent update.
    /// </summary>
    /// <typeparam name="Parent">The return type of the final Attachable.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        IARecordSetBlank<ParentT>,
        IWithARecordIpv4Address<ParentT>,
        IWithARecordIpv4AddressOrAttachable<ParentT>,
        IAaaaRecordSetBlank<ParentT>,
        IWithAaaaRecordIpv6Address<ParentT>,
        IWithAaaaRecordIpv6AddressOrAttachable<ParentT>,
        IMxRecordSetBlank<ParentT>,
        IWithMxRecordMailExchange<ParentT>,
        IWithMxRecordMailExchangeOrAttachable<ParentT>,
        INsRecordSetBlank<ParentT>,
        IWithNsRecordNameServer<ParentT>,
        IWithNsRecordNameServerOrAttachable<ParentT>,
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
    /// The final stage of the Dns zone record set definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the Dns zone record set
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
    /// The stage of the Mx record set definition allowing to add first Mx record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithMxRecordMailExchange<ParentT> 
    {
        /// <summary>
        /// Creates and assigns priority to a Mx record with the provided mail exchange server in this record set.
        /// </summary>
        /// <param name="mailExchangeHostName">The host name of the mail exchange server.</param>
        /// <param name="priority">The priority for the mail exchange host, lower the value higher the priority.</param>
        /// <return>The next stage of the record set definition.</return>
        IWithMxRecordMailExchangeOrAttachable<ParentT> WithMailExchange(string mailExchangeHostName, int priority);
    }

    /// <summary>
    /// The stage of the Ptr record set definition allowing to add first Cname record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithPtrRecordTargetDomainName<ParentT> 
    {
        /// <summary>
        /// Creates a Ptr record with the provided target domain name in this record set.
        /// </summary>
        /// <param name="targetDomainName">The target domain name.</param>
        /// <return>The next stage of the record set definition.</return>
        IWithPtrRecordTargetDomainNameOrAttachable<ParentT> WithTargetDomainName(string targetDomainName);
    }

    /// <summary>
    /// The stage of the Ns record set definition allowing to add a Ns record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithNsRecordNameServer<ParentT> 
    {
        /// <summary>
        /// Creates a Ns record with the provided name server in this record set.
        /// </summary>
        /// <param name="nameServerHostName">The name server host name.</param>
        /// <return>The next stage of the record set definition.</return>
        IWithNsRecordNameServerOrAttachable<ParentT> WithNameServer(string nameServerHostName);
    }

    /// <summary>
    /// The first stage of a Ns record definition.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface INsRecordSetBlank<ParentT>  :
        IWithNsRecordNameServer<ParentT>
    {
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
    /// The stage of the Ptr record set definition allowing to add additional Ptr records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithPtrRecordTargetDomainNameOrAttachable<ParentT>  :
        IWithPtrRecordTargetDomainName<ParentT>,
        IWithAttach<ParentT>
    {
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
        IWithTxtRecordTextValueOrAttachable<ParentT> WithText(string text);
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
    /// The stage of the Aaaa record set definition allowing to add first Aaaa record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithAaaaRecordIpv6Address<ParentT> 
    {
        /// <summary>
        /// Creates an Aaaa record with the provided Ipv6 address in this record set.
        /// </summary>
        /// <param name="ipv6Address">The Ipv6 address.</param>
        /// <return>The next stage of the record set definition.</return>
        IWithAaaaRecordIpv6AddressOrAttachable<ParentT> WithIpv6Address(string ipv6Address);
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add additional A records or
    /// attach the record set to the parent.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithARecordIpv4AddressOrAttachable<ParentT>  :
        IWithARecordIpv4Address<ParentT>,
        IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The stage of the A record set definition allowing to add first A record.
    /// </summary>
    /// <typeparam name="Parent">The return type of WithAttach.attach().</typeparam>
    public interface IWithARecordIpv4Address<ParentT> 
    {
        /// <summary>
        /// Creates an A record with the provided Ipv4 address in this record set.
        /// </summary>
        /// <param name="ipv4Address">The Ipv4 address.</param>
        /// <return>The next stage of the record set definition.</return>
        IWithARecordIpv4AddressOrAttachable<ParentT> WithIpv4Address(string ipv4Address);
    }
}