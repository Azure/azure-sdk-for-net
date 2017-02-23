// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition
{
    using Microsoft.Azure.Management.Dns.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition;

    /// <summary>
    /// The entirety of the DNS zone definition.
    /// </summary>
    public interface IDefinition  :
        IBlank,
        IWithCreate
    {
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        ICreatable<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        IWithRecordSet,
        IDefinitionWithTags<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the DNS zone definition allowing to specify the resource group.
    /// </summary>
    public interface IBlank  :
        IWithGroupAndRegion<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the DNS zone definition allowing to specify record set.
    /// </summary>
    public interface IWithRecordSet 
    {
        /// <summary>
        /// Specifies definition of a PTR record set.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.IPtrRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefinePtrRecordSet(string name);

        /// <summary>
        /// Specifies definition of a MX record set.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.IMXRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineMXRecordSet(string name);

        /// <summary>
        /// Specifies definition of an NS record set.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <return>The stage representing configuration for the NS record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.INSRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineNSRecordSet(string name);

        /// <summary>
        /// Specifies definition of a SRV record set.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.ISrvRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineSrvRecordSet(string name);

        /// <summary>
        /// Specifies definition of an AAAA record set.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.IAaaaRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineAaaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of a Txt record set.
        /// </summary>
        /// <param name="name">The name of the Txt record set.</param>
        /// <return>The stage representing configuration for the Txt record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.ITxtRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineTxtRecordSet(string name);

        /// <summary>
        /// Specifies definition of an A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.IARecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineARecordSet(string name);

        /// <summary>
        /// Specifies definition of a CName record set.
        /// </summary>
        /// <param name="name">Name of the CName record set.</param>
        /// <param name="alias">The CName record alias.</param>
        /// <return>The next stage of DNS zone definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate WithCNameRecordSet(string name, string alias);
    }
}