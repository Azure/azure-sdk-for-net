// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Dns.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using DnsZone.Definition;
    using DnsZone.Update;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class DnsZoneImpl 
    {
        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The refreshed resource.</return>
        Microsoft.Azure.Management.Dns.Fluent.IDnsZone Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Dns.Fluent.IDnsZone>.Refresh()
        {
            return this.Refresh() as Microsoft.Azure.Management.Dns.Fluent.IDnsZone;
        }

        /// <summary>
        /// Gets name servers assigned for this zone.
        /// </summary>
        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Dns.Fluent.IDnsZone.NameServers
        {
            get
            {
                return this.NameServers() as System.Collections.Generic.IList<string>;
            }
        }

        /// <summary>
        /// Gets the maximum number of record sets that can be created in this zone.
        /// </summary>
        long Microsoft.Azure.Management.Dns.Fluent.IDnsZone.MaxNumberOfRecordSets
        {
            get
            {
                return this.MaxNumberOfRecordSets();
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing AAAA (IPv6 address) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.AaaaRecordSets
        {
            get
            {
                return this.AaaaRecordSets() as Microsoft.Azure.Management.Dns.Fluent.IAaaaRecordSets;
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing A (Ipv4 address) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IARecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.ARecordSets
        {
            get
            {
                return this.ARecordSets() as Microsoft.Azure.Management.Dns.Fluent.IARecordSets;
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Ns (name server) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.INsRecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.NsRecordSets
        {
            get
            {
                return this.NsRecordSets() as Microsoft.Azure.Management.Dns.Fluent.INsRecordSets;
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Srv (service) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ISrvRecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.SrvRecordSets
        {
            get
            {
                return this.SrvRecordSets() as Microsoft.Azure.Management.Dns.Fluent.ISrvRecordSets;
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing CName (canonical name) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ICnameRecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.CnameRecordSets
        {
            get
            {
                return this.CnameRecordSets() as Microsoft.Azure.Management.Dns.Fluent.ICnameRecordSets;
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Txt (text) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.ITxtRecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.TxtRecordSets
        {
            get
            {
                return this.TxtRecordSets() as Microsoft.Azure.Management.Dns.Fluent.ITxtRecordSets;
            }
        }

        /// <summary>
        /// Gets the current number of record sets in this zone.
        /// </summary>
        long Microsoft.Azure.Management.Dns.Fluent.IDnsZone.NumberOfRecordSets
        {
            get
            {
                return this.NumberOfRecordSets();
            }
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Ptr (pointer) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IPtrRecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.PtrRecordSets
        {
            get
            {
                return this.PtrRecordSets() as Microsoft.Azure.Management.Dns.Fluent.IPtrRecordSets;
            }
        }

        /// <return>The record set containing Soa (start of authority) record associated with this Dns zone.</return>
        Microsoft.Azure.Management.Dns.Fluent.ISoaRecordSet Microsoft.Azure.Management.Dns.Fluent.IDnsZone.GetSoaRecordSet()
        {
            return this.GetSoaRecordSet() as Microsoft.Azure.Management.Dns.Fluent.ISoaRecordSet;
        }

        /// <summary>
        /// Gets entry point to manage record sets in this zone containing Mx (mail exchange) records.
        /// </summary>
        Microsoft.Azure.Management.Dns.Fluent.IMxRecordSets Microsoft.Azure.Management.Dns.Fluent.IDnsZone.MxRecordSets
        {
            get
            {
                return this.MxRecordSets() as Microsoft.Azure.Management.Dns.Fluent.IMxRecordSets;
            }
        }

        /// <summary>
        /// Removes a Srv record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Srv record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutSrvRecordSet(string name)
        {
            return this.WithoutSrvRecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Specifies definition of a Srv record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">The name of the Srv record set.</param>
        /// <return>The stage representing configuration for the Srv record set.</return>
        DnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<DnsZone.Update.IUpdate> DnsZone.Update.IWithRecordSet.DefineSrvRecordSet(string name)
        {
            return this.DefineSrvRecordSet(name) as DnsRecordSet.UpdateDefinition.ISrvRecordSetBlank<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies definition of an A record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        DnsRecordSet.UpdateDefinition.IARecordSetBlank<DnsZone.Update.IUpdate> DnsZone.Update.IWithRecordSet.DefineARecordSet(string name)
        {
            return this.DefineARecordSet(name) as DnsRecordSet.UpdateDefinition.IARecordSetBlank<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies definition of a Cname record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Cname record set.</param>
        /// <param name="alias">The Cname record alias.</param>
        /// <return>The next stage of Dns zone definition.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithCnameRecordSet(string name, string alias)
        {
            return this.WithCnameRecordSet(name, alias) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing Ptr record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The stage representing configuration for the Ptr record set.</return>
        DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet DnsZone.Update.IWithRecordSet.UpdatePtrRecordSet(string name)
        {
            return this.UpdatePtrRecordSet(name) as DnsRecordSet.UpdatePtrRecordSet.IUpdatePtrRecordSet;
        }

        /// <summary>
        /// Specifies definition of a Mx record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The stage representing configuration for the Mx record set.</return>
        DnsRecordSet.UpdateDefinition.IMxRecordSetBlank<DnsZone.Update.IUpdate> DnsZone.Update.IWithRecordSet.DefineMxRecordSet(string name)
        {
            return this.DefineMxRecordSet(name) as DnsRecordSet.UpdateDefinition.IMxRecordSetBlank<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update of an existing A record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        DnsRecordSet.UpdateARecordSet.IUpdateARecordSet DnsZone.Update.IWithRecordSet.UpdateARecordSet(string name)
        {
            return this.UpdateARecordSet(name) as DnsRecordSet.UpdateARecordSet.IUpdateARecordSet;
        }

        /// <summary>
        /// Removes a Mx record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutMxRecordSet(string name)
        {
            return this.WithoutMxRecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Removes a Cname record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Cname record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutCnameRecordSet(string name)
        {
            return this.WithoutCnameRecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Removes a Ptr record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutPtrRecordSet(string name)
        {
            return this.WithoutPtrRecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing Mx record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The stage representing configuration for the Mx record set.</return>
        DnsRecordSet.UpdateMxRecordSet.IUpdateMxRecordSet DnsZone.Update.IWithRecordSet.UpdateMxRecordSet(string name)
        {
            return this.UpdateMxRecordSet(name) as DnsRecordSet.UpdateMxRecordSet.IUpdateMxRecordSet;
        }

        /// <summary>
        /// Begins the description of an update of an existing Txt record set in this Dns zone.
        /// </summary>
        /// <param name="name">The name of the Txt record set.</param>
        /// <return>The stage representing configuration for the Txt record set.</return>
        DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet DnsZone.Update.IWithRecordSet.UpdateTxtRecordSet(string name)
        {
            return this.UpdateTxtRecordSet(name) as DnsRecordSet.UpdateTxtRecordSet.IUpdateTxtRecordSet;
        }

        /// <summary>
        /// Specifies definition of a Ptr record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The stage representing configuration for the Ptr record set.</return>
        DnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<DnsZone.Update.IUpdate> DnsZone.Update.IWithRecordSet.DefinePtrRecordSet(string name)
        {
            return this.DefinePtrRecordSet(name) as DnsRecordSet.UpdateDefinition.IPtrRecordSetBlank<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Removes a Aaaa record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutAaaaRecordSet(string name)
        {
            return this.WithoutAaaaRecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Removes a Txt record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Txt record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutTxtRecordSet(string name)
        {
            return this.WithoutTxtRecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Specifies definition of an Ns record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The stage representing configuration for the Ns record set.</return>
        DnsRecordSet.UpdateDefinition.INsRecordSetBlank<DnsZone.Update.IUpdate> DnsZone.Update.IWithRecordSet.DefineNsRecordSet(string name)
        {
            return this.DefineNsRecordSet(name) as DnsRecordSet.UpdateDefinition.INsRecordSetBlank<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Gets Begins the description of an update of the Soa record in this Dns zone.
        /// </summary>
        /// <summary>
        /// Gets the stage representing configuration for the Txt record set.
        /// </summary>
        DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord DnsZone.Update.IWithRecordSet.UpdateSoaRecord()
        {
            return this.UpdateSoaRecord() as DnsRecordSet.UpdateSoaRecord.IUpdateSoaRecord;
        }

        /// <summary>
        /// Begins the description of an update of an existing Srv record set in this Dns zone.
        /// </summary>
        /// <param name="name">The name of the Srv record set.</param>
        /// <return>The stage representing configuration for the Srv record set.</return>
        DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet DnsZone.Update.IWithRecordSet.UpdateSrvRecordSet(string name)
        {
            return this.UpdateSrvRecordSet(name) as DnsRecordSet.UpdateSrvRecordSet.IUpdateSrvRecordSet;
        }

        /// <summary>
        /// Removes a Ns record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutNsRecordSet(string name)
        {
            return this.WithoutNsRecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Specifies definition of a Txt record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">The name of the Txt record set.</param>
        /// <return>The stage representing configuration for the Txt record set.</return>
        DnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<DnsZone.Update.IUpdate> DnsZone.Update.IWithRecordSet.DefineTxtRecordSet(string name)
        {
            return this.DefineTxtRecordSet(name) as DnsRecordSet.UpdateDefinition.ITxtRecordSetBlank<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Begins the description of an update of an existing Ns record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The stage representing configuration for the Ns record set.</return>
        DnsRecordSet.UpdateNsRecordSet.IUpdateNsRecordSet DnsZone.Update.IWithRecordSet.UpdateNsRecordSet(string name)
        {
            return this.UpdateNsRecordSet(name) as DnsRecordSet.UpdateNsRecordSet.IUpdateNsRecordSet;
        }

        /// <summary>
        /// Specifies definition of an Aaaa record set to be attached to the Dns zone.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The stage representing configuration for the Aaaa record set.</return>
        DnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<DnsZone.Update.IUpdate> DnsZone.Update.IWithRecordSet.DefineAaaaRecordSet(string name)
        {
            return this.DefineAaaaRecordSet(name) as DnsRecordSet.UpdateDefinition.IAaaaRecordSetBlank<DnsZone.Update.IUpdate>;
        }

        /// <summary>
        /// Removes a A record set in the Dns zone.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The next stage of Dns zone update.</return>
        DnsZone.Update.IUpdate DnsZone.Update.IWithRecordSet.WithoutARecordSet(string name)
        {
            return this.WithoutARecordSet(name) as DnsZone.Update.IUpdate;
        }

        /// <summary>
        /// Begins the description of an update of an existing Aaaa record set in this Dns zone.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The stage representing configuration for the Aaaa record set.</return>
        DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet DnsZone.Update.IWithRecordSet.UpdateAaaaRecordSet(string name)
        {
            return this.UpdateAaaaRecordSet(name) as DnsRecordSet.UpdateAaaaRecordSet.IUpdateAaaaRecordSet;
        }

        /// <summary>
        /// Specifies definition of a Srv record set.
        /// </summary>
        /// <param name="name">The name of the Srv record set.</param>
        /// <return>The stage representing configuration for the Srv record set.</return>
        DnsRecordSet.Definition.ISrvRecordSetBlank<DnsZone.Definition.IWithCreate> DnsZone.Definition.IWithRecordSet.DefineSrvRecordSet(string name)
        {
            return this.DefineSrvRecordSet(name) as DnsRecordSet.Definition.ISrvRecordSetBlank<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of an A record set.
        /// </summary>
        /// <param name="name">Name of the A record set.</param>
        /// <return>The stage representing configuration for the A record set.</return>
        DnsRecordSet.Definition.IARecordSetBlank<DnsZone.Definition.IWithCreate> DnsZone.Definition.IWithRecordSet.DefineARecordSet(string name)
        {
            return this.DefineARecordSet(name) as DnsRecordSet.Definition.IARecordSetBlank<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of a Cname record set.
        /// </summary>
        /// <param name="name">Name of the Cname record set.</param>
        /// <param name="alias">The Cname record alias.</param>
        /// <return>The next stage of Dns zone definition.</return>
        DnsZone.Definition.IWithCreate DnsZone.Definition.IWithRecordSet.WithCnameRecordSet(string name, string alias)
        {
            return this.WithCnameRecordSet(name, alias) as DnsZone.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies definition of a Mx record set.
        /// </summary>
        /// <param name="name">Name of the Mx record set.</param>
        /// <return>The stage representing configuration for the Mx record set.</return>
        DnsRecordSet.Definition.IMxRecordSetBlank<DnsZone.Definition.IWithCreate> DnsZone.Definition.IWithRecordSet.DefineMxRecordSet(string name)
        {
            return this.DefineMxRecordSet(name) as DnsRecordSet.Definition.IMxRecordSetBlank<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of a Ptr record set.
        /// </summary>
        /// <param name="name">Name of the Ptr record set.</param>
        /// <return>The stage representing configuration for the Ptr record set.</return>
        DnsRecordSet.Definition.IPtrRecordSetBlank<DnsZone.Definition.IWithCreate> DnsZone.Definition.IWithRecordSet.DefinePtrRecordSet(string name)
        {
            return this.DefinePtrRecordSet(name) as DnsRecordSet.Definition.IPtrRecordSetBlank<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of an Ns record set.
        /// </summary>
        /// <param name="name">Name of the Ns record set.</param>
        /// <return>The stage representing configuration for the Ns record set.</return>
        DnsRecordSet.Definition.INsRecordSetBlank<DnsZone.Definition.IWithCreate> DnsZone.Definition.IWithRecordSet.DefineNsRecordSet(string name)
        {
            return this.DefineNsRecordSet(name) as DnsRecordSet.Definition.INsRecordSetBlank<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of a Txt record set.
        /// </summary>
        /// <param name="name">The name of the Txt record set.</param>
        /// <return>The stage representing configuration for the Txt record set.</return>
        DnsRecordSet.Definition.ITxtRecordSetBlank<DnsZone.Definition.IWithCreate> DnsZone.Definition.IWithRecordSet.DefineTxtRecordSet(string name)
        {
            return this.DefineTxtRecordSet(name) as DnsRecordSet.Definition.ITxtRecordSetBlank<DnsZone.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies definition of an Aaaa record set.
        /// </summary>
        /// <param name="name">Name of the Aaaa record set.</param>
        /// <return>The stage representing configuration for the Aaaa record set.</return>
        DnsRecordSet.Definition.IAaaaRecordSetBlank<DnsZone.Definition.IWithCreate> DnsZone.Definition.IWithRecordSet.DefineAaaaRecordSet(string name)
        {
            return this.DefineAaaaRecordSet(name) as DnsRecordSet.Definition.IAaaaRecordSetBlank<DnsZone.Definition.IWithCreate>;
        }
    }
}