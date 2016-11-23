// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update
{
    using Microsoft.Azure.Management.Dns.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNsRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMxRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet;

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// <p>
    /// Call Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        IAppliable<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        IWithRecordSet,
        IUpdateWithTags<IUpdate>
    {
    }

    /// <summary>
    /// The stage of the Dns zone update allowing to specify record set.
    /// </summary>
    public interface IWithRecordSet 
    {
        /// <summary>
        /// Specifies definition of a Ptr record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The stage representing configuration for the Ptr record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<IUpdate> DefinePtrRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing A record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet.IUpdateARecordSet UpdateARecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing Ptr record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The stage representing configuration for the Ptr record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet UpdatePtrRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing Srv record set in this Dns zone.
        /// </summary>
        /// <param name="name">The name of the Srv record set.</param>
        /// <return>The stage representing configuration for the Srv record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet UpdateSrvRecordSet(string name);

        /// <summary>
        /// Specifies definition of a Mx record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The stage representing configuration for the Mx record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IMxRecordSetBlank<IUpdate> DefineMxRecordSet(string name);

        /// <summary>
        /// Specifies definition of a Srv record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">The name of the Srv record set.</param>
        /// <return>The stage representing configuration for the Srv record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<IUpdate> DefineSrvRecordSet(string name);

        /// <summary>
        /// Specifies definition of an A record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IARecordSetBlank<IUpdate> DefineARecordSet(string name);

        /// <summary>
        /// Specifies definition of a Cname record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Cname record set.</param>
        /// <param name="alias">The Cname record alias.</param>
        /// <return>The next stage of Dns zone definition.</return>
        IUpdate WithCnameRecordSet(string name, string alias);

        /// <summary>
        /// Removes a Ptr record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutPtrRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of the Soa record in this Dns zone.
        /// </summary>
        /// <return>The stage representing configuration for the Txt record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord UpdateSoaRecord();

        /// <summary>
        /// Begins the description of an update of an existing Aaaa record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The stage representing configuration for the Aaaa record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet UpdateAaaaRecordSet(string name);

        /// <summary>
        /// Removes a Aaaa record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutAaaaRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing Txt record set in this Dns zone.
        /// </summary>
        /// <param name="name">The name of the Txt record set.</param>
        /// <return>The stage representing configuration for the Txt record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet UpdateTxtRecordSet(string name);

        /// <summary>
        /// Specifies definition of an Ns record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The stage representing configuration for the Ns record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.INsRecordSetBlank<IUpdate> DefineNsRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing Mx record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The stage representing configuration for the Mx record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMxRecordSet.IUpdateMxRecordSet UpdateMxRecordSet(string name);

        /// <summary>
        /// Removes a Srv record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Srv record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutSrvRecordSet(string name);

        /// <summary>
        /// Removes a Cname record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Cname record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutCnameRecordSet(string name);

        /// <summary>
        /// Specifies definition of an Aaaa record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The stage representing configuration for the Aaaa record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<IUpdate> DefineAaaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of a Txt record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">The name of the Txt record set.</param>
        /// <return>The stage representing configuration for the Txt record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<IUpdate> DefineTxtRecordSet(string name);

        /// <summary>
        /// Removes a A record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutARecordSet(string name);

        /// <summary>
        /// Removes a Mx record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutMxRecordSet(string name);

        /// <summary>
        /// Removes a Txt record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Txt record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutTxtRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing Ns record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The stage representing configuration for the Ns record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNsRecordSet.IUpdateNsRecordSet UpdateNsRecordSet(string name);

        /// <summary>
        /// Removes a Ns record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        IUpdate WithoutNsRecordSet(string name);
    }
}