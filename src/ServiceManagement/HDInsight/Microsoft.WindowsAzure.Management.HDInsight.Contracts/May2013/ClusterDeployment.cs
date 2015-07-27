//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ClusterDeployment
    {
        [IgnoreDataMember]
        public int TotalNodeCount
        {
            get
            {
                if (this.Roles == null)
                {
                    return 0;
                }

                return this.DataNodeCount + 1;
            }
        }

        [IgnoreDataMember]
        public int DataNodeCount
        {
            get
            {
                if (this.Roles == null)
                {
                    return 0;
                }

                return this.Roles.Sum((e) => e.RoleType != ClusterRoleType.HeadNode ? e.Count : 0);
            }
        }

        [DataMember( EmitDefaultValue = false )]
        public string ClusterUsername { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string ClusterPassword { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public DateTime CreatedDate { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = true )]
        public List<BlobContainerReference> AdditionalStorageAccounts { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<ClusterRole> Roles  { get; set; }

        [IgnoreDataMember]
        public bool IsRdpUserEnabled { get; set; }

        [IgnoreDataMember]
        public bool IsHttpUserEnabled { get; set; }

        [IgnoreDataMember]
        public string RdpUsername { get; set; }

        [IgnoreDataMember]
        public bool ClusterDashboardEnabled { get; set; }

        [IgnoreDataMember]
        public DateTime RdpExpirationDate { get; set; }

        public ClusterDeployment()
        {
            AdditionalStorageAccounts = new List<BlobContainerReference>();
            Roles = new List<ClusterRole>();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tClusterDeployment:"));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tDataNodeCount: {0}", this.DataNodeCount));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tTotalNodeCount: {0}", this.TotalNodeCount));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tVersion: {0}", this.Version));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tCreatedDate: {0}", this.CreatedDate));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tRdpUserEnabled: {0}", this.IsRdpUserEnabled));
            if (this.RdpUsername != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tRdpUsername: {0}", this.RdpUsername));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tRdpExpirationDate: {0}", this.RdpExpirationDate));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tClusterDashboardEnabled: {0}", this.ClusterDashboardEnabled));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tHttpUserEnabled: {0}", this.IsHttpUserEnabled));
            if (this.ClusterUsername != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tClusterUsername: {0}", this.ClusterUsername));
            if (this.ClusterPassword != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tClusterPassword: {0}", this.ClusterPassword));
            if (this.AdditionalStorageAccounts != null && this.AdditionalStorageAccounts.Count > 0)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tAdditionalStorageAccounts: {0}", DataContractsSerDeUtils.SerializeToXml(this.AdditionalStorageAccounts)));
            if (this.Roles != null && this.Roles.Count > 0)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tRoles: {0}", DataContractsSerDeUtils.SerializeToXml(this.Roles)));
            return builder.ToString();
        }
    }
}
