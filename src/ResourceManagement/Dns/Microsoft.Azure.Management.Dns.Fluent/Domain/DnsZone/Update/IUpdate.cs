// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update
{
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMXRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNSRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet;
    using Microsoft.Azure.Management.Dns.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// The stage of the DNS zone update allowing to specify record set.
    /// </summary>
    public interface IWithRecordSet 
    {
        /// <summary>
        /// Begins the description of an update of an existing A record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateARecordSet.IUpdateARecordSet UpdateARecordSet(string name);

        /// <summary>
        /// Removes a TXT record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the TXT record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutTxtRecordSet(string name);

        /// <summary>
        /// Removes a MX record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutMXRecordSet(string name);

        /// <summary>
        /// Specifies definition of an AAAA record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineAaaaRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing MX record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateMXRecordSet.IUpdateMXRecordSet UpdateMXRecordSet(string name);

        /// <summary>
        /// Removes a SRV record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the SRV record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutSrvRecordSet(string name);

        /// <summary>
        /// Removes a CNAME record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutCNameRecordSet(string name);

        /// <summary>
        /// Specifies definition of an A record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IARecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineARecordSet(string name);

        /// <summary>
        /// Gets Begins the description of an update of the SOA record in this DNS zone.
        /// </summary>
        /// <summary>
        /// Gets the stage representing configuration for the TXT record set.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord UpdateSoaRecord();

        /// <summary>
        /// Specifies definition of a TXT record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">The name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineTxtRecordSet(string name);

        /// <summary>
        /// Specifies definition of a MX record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the MX record set.</param>
        /// <return>The stage representing configuration for the MX record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IMXRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineMXRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing PTR record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet UpdatePtrRecordSet(string name);

        /// <summary>
        /// Specifies definition of a PTR record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The stage representing configuration for the PTR record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefinePtrRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing NS record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <return>The stage representing configuration for the NS record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateNSRecordSet.IUpdateNSRecordSet UpdateNSRecordSet(string name);

        /// <summary>
        /// Removes a AAAA record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutAaaaRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing AAAA record set in this DNS zone.
        /// </summary>
        /// <param name="name">Name of the AAAA record set.</param>
        /// <return>The stage representing configuration for the AAAA record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet UpdateAaaaRecordSet(string name);

        /// <summary>
        /// Specifies definition of a CNAME record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the CNAME record set.</param>
        /// <param name="alias">The CNAME record alias.</param>
        /// <return>The next stage of DNS zone definition.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithCNameRecordSet(string name, string alias);

        /// <summary>
        /// Specifies definition of a SRV record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineSrvRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing TXT record set in this DNS zone.
        /// </summary>
        /// <param name="name">The name of the TXT record set.</param>
        /// <return>The stage representing configuration for the TXT record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet UpdateTxtRecordSet(string name);

        /// <summary>
        /// Begins the description of an update of an existing SRV record set in this DNS zone.
        /// </summary>
        /// <param name="name">The name of the SRV record set.</param>
        /// <return>The stage representing configuration for the SRV record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet UpdateSrvRecordSet(string name);

        /// <summary>
        /// Removes a PTR record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the PTR record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutPtrRecordSet(string name);

        /// <summary>
        /// Specifies definition of an NS record set to be attached to the DNS zone.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <return>The stage representing configuration for the NS record set.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsRecordSet.UpdateDefinition.INSRecordSetBlank<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate> DefineNSRecordSet(string name);

        /// <summary>
        /// Removes a NS record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the NS record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutNSRecordSet(string name);

        /// <summary>
        /// Removes a A record set in the DNS zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The next stage of DNS zone update.</return>
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate WithoutARecordSet(string name);
    }

    /// <summary>
    /// The template for an update operation, containing all the settings that can be modified.
    /// Call  Update.apply() to apply the changes to the resource in Azure.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>,
        Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IWithRecordSet,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.Dns.Fluent.DnsZone.Update.IUpdate>
    {
    }
}