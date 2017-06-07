using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [CollectionDataContract(Name = "Disks", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class VirtualHardDiskCollection : List<VirtualHardDisk>
    {
        private VirtualHardDiskCollection() { }

        /// <summary>
        /// Overrides the base ToString method to return the XML serialization
        /// of the data contract represented by the class.
        /// </summary>
        /// <returns>
        /// XML serialized representation of this class as a string.
        /// </returns>
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [DataContract(Name="Disk", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class VirtualHardDisk : AzureDataContractBase
    {
        private VirtualHardDisk() { }

        //this constructor called from CreateDiskAsync
        internal VirtualHardDisk(string name, string label, Uri mediaLink, OperatingSystemType osType)
        {
            //TODO: Validate params
            this.Name = name;
            this.Label = label;
            this.MediaLink = mediaLink;
            this.OSType = osType;
        }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public string AffinityGroup { get; private set; }

        [DataMember(Name="AttachedTo", Order = 1, IsRequired = false, EmitDefaultValue = false)]
        private AttachedTo _attachedTo;

        public string CloudServiceName { get { return _attachedTo == null ? null : _attachedTo.CloudServiceName; } }

        public string DeploymentName { get { return _attachedTo == null ? null : _attachedTo.DeploymentName; } }

        public string RoleName { get { return _attachedTo == null ? null : _attachedTo.RoleName; } }

        [DataMember(Name="OS", Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public OperatingSystemType OSType { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue=false)]
        public bool IsCorrupted { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        public string Location { get; private set; }

        [DataMember(Name = "LogicalDiskSizeInGB", Order = 5, IsRequired = false, EmitDefaultValue=false)]
        public int LogicalSize { get; private set; }

        [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
        public string Label { get; private set; }

        [DataMember(Order = 7, IsRequired = true)]
        public Uri MediaLink { get; private set; }

        [DataMember(Order = 8, IsRequired = true)]
        public String Name { get; private set; }

        [DataMember(Order = 9, IsRequired = false, EmitDefaultValue = false)]
        public String SourceImageName { get; private set; }

        [DataContract(Name = "AttachedTo", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class AttachedTo : AzureDataContractBase
        {
            [DataMember(Order = 0, IsRequired = true)]
            internal string DeploymentName { get; private set; }

            [DataMember(Name="HostedServiceName", Order = 1, IsRequired = true)]
            internal string CloudServiceName { get; private set; }

            [DataMember(Order = 2, IsRequired = true)]
            internal string RoleName { get; private set; }
        }
    }
}
