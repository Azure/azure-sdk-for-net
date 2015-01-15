//-----------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------

using System;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.WindowsAzure.Management.HDInsight.Contracts.March2013
{
    [DataContract(Namespace = Constants.XsdNamespace)]
    public class ClusterContainer
    {
        [DataMember( EmitDefaultValue = false )]
        public string DnsName { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string SubscriptionId { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string ContainerState { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string ContainerError { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string AzureStorageAccount { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string AzureStorageLocation { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public virtual ClusterDeployment Deployment { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public DateTime CreatedDate { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public DateTime UpdatedDate { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string IncarnationID { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public AzureClusterDeploymentAction DeploymentAction { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public string CNameMapping { get; set; }

        [DataMember( EmitDefaultValue = false )]
        public int ContainerErrorCode { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"ClusterContainer:"));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tDnsName: {0}", this.DnsName));
            if (this.AzureStorageAccount != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tAzureStorageAccount: {0}", this.AzureStorageAccount));
            if (this.AzureStorageLocation != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tAzureStorageLocation: {0}", this.AzureStorageLocation));
            if (this.CNameMapping != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tCNameMapping: {0}", this.CNameMapping));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tContainerState: {0}", this.ContainerState));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tDeploymentAction: {0}", this.DeploymentAction));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tIncarnationID: {0}", this.IncarnationID));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tSubscriptionId: {0}", this.SubscriptionId));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tCreatedDate: {0}", this.CreatedDate));
            builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tUpdatedDate: {0}", this.UpdatedDate));
            if (this.ContainerError != null)
            {
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tContainerError: {0}", this.ContainerError));
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,"\tContainerErrorCode: {0}", this.ContainerErrorCode));
            }
            if (this.Deployment != null)
                builder.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture, this.Deployment.ToString()));
            return builder.ToString();
        }
    }
}
