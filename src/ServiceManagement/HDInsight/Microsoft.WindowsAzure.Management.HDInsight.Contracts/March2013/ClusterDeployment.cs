//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ClusterDeployment 
    {
        [DataMember( EmitDefaultValue = false )]
        public string ClusterUsername { get; set; }
 
        [DataMember( EmitDefaultValue = false )]
        public string ClusterPassword { get; set; }

        public int ClusterSize
        {
            get
            {
                if (this.NodeSizes == null)
                {
                    return 0;
                }

                return this.NodeSizes.Sum((e) => e.RoleType != ClusterNodeType.HeadNode ? e.Count : 0);
            }
        }

        [DataMember( EmitDefaultValue = false )]
        public string ClusterState { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public DateTime CreatedDate { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string Version { get; set; }

        [DataMember(EmitDefaultValue = true )]
        public List<ASVAccount> ASVAccounts { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<ClusterNodeSize> NodeSizes { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<SqlAzureMetaStore> SqlMetaStores { get; set; }

        public ClusterDeployment()
        {
            ASVAccounts = new List<ASVAccount>();
            NodeSizes = new List<ClusterNodeSize>();
            SqlMetaStores = new List<SqlAzureMetaStore>();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tClusterDeployment:"));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tClusterSize: {0}", this.ClusterSize));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tClusterState: {0}", this.ClusterState));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tVersion: {0}", this.Version));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tCreatedDate: {0}", this.CreatedDate));
            if(this.ClusterUsername != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tClusterUsername: {0}", this.ClusterUsername));
            if (this.ClusterPassword != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tClusterPassword: {0}", this.ClusterPassword));
            if (this.ASVAccounts != null && this.ASVAccounts.Count > 0)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tASVAccounts: {0}", DataContractsSerDeUtils.SerializeToXml(this.ASVAccounts)));
            if (this.NodeSizes != null && this.NodeSizes.Count > 0)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tNodeSizes: {0}", DataContractsSerDeUtils.SerializeToXml(this.NodeSizes)));
            if(this.SqlMetaStores != null && this.SqlMetaStores.Count > 0)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tSqlMetaStores: {0}", DataContractsSerDeUtils.SerializeToXml(this.SqlMetaStores)));
            return builder.ToString();
        }
    }
}
