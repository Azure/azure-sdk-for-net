//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.May2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ClusterContainer
    {
        [DataMember(Order = 1, EmitDefaultValue = false )]
        public ClusterState ClusterState { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public List<ContainerError> ContainerError { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public ClusterDeployment Deployment { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public DateTime UpdatedDate { get; set; }

        [DataMember(Order = 6, EmitDefaultValue = false)]
        public AzureClusterDeploymentAction DeploymentAction { get; set; }
        
        [DataMember(Order = 7, EmitDefaultValue = false)]
        public string ClusterName { get; set; }

        [DataMember(Order = 8, EmitDefaultValue = false)]
        public string Region { get; set; }

        [DataMember(Order = 9, EmitDefaultValue = true)]
        public List<BlobContainerReference> StorageAccounts { get; set; }

        [DataMember(Order = 10, EmitDefaultValue = false)]
        public Uri ClusterUri { get; set; }

        [DataMember(Order = 11, EmitDefaultValue = false)]
        public ComponentSettings Settings { get; set; }

        public ClusterContainer()
        {
            StorageAccounts = new List<BlobContainerReference>();
            Settings = new ComponentSettings();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"ClusterContainer:"));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tClusterName: {0}", this.ClusterName));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tClusterState: {0}", this.ClusterState));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tClusterUri: {0}", this.ClusterUri));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tDeploymentAction: {0}", this.DeploymentAction));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tRegion: {0}", this.Region));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tCreatedDate: {0}", this.CreatedDate));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tUpdatedDate: {0}", this.UpdatedDate));
            if (this.StorageAccounts != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tStorageAccounts: {0}", DataContractsSerDeUtils.SerializeToXml(this.StorageAccounts)));
            if (this.Settings != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tSettings: {0}", DataContractsSerDeUtils.SerializeToXml(this.Settings)));
            if (this.ContainerError != null)
            {
                foreach (var error in ContainerError)
                {
                    builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tContainer Error Code: {0}", error.ErrorCode));
                    builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\t\tContainer Error Description: {0}", error.ErrorDescription));
                }
            }
            if (this.Deployment != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture, this.Deployment.ToString()));
            return builder.ToString();
        }
    }
}
