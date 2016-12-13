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
    /// The entirety of the Dns zone definition.
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
    /// The stage of the Dns zone definition allowing to specify the resource group.
    /// </summary>
    public interface IBlank  :
        IWithGroupAndRegion<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate>
    {
    }

    /// <summary>
    /// The stage of the Dns zone definition allowing to specify record set.
    /// </summary>
    public interface IWithRecordSet 
    {
        /// <summary>
        /// Specifies definition of a Ptr record set.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The stage representing configuration for the Ptr record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.IPtrRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefinePtrRecordSet(string name);

        /// <summary>
        /// Specifies definition of a Mx record set.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The stage representing configuration for the Mx record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.IMxRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineMxRecordSet(string name);

        /// <summary>
        /// Specifies definition of an Ns record set.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The stage representing configuration for the Ns record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.INsRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineNsRecordSet(string name);

        /// <summary>
        /// Specifies definition of a Srv record set.
        /// </summary>
        /// <param name="name">The name of the Srv record set.</param>
        /// <return>The stage representing configuration for the Srv record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.Definition.ISrvRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate> DefineSrvRecordSet(string name);

        /// <summary>
        /// Specifies definition of an Aaaa record set.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The stage representing configuration for the Aaaa record set.</return>
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
        /// Specifies definition of a Cname record set.
        /// </summary>
        /// <param name="name">Name of the Cname record set.</param>
        /// <param name="alias">The Cname record alias.</param>
        /// <return>The next stage of Dns zone definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Definition.IWithCreate WithCnameRecordSet(string name, string alias);
    }
}