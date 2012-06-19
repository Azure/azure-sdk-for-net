using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [CollectionDataContract(Name = "DataVirtualHardDisks", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class DataVirtualHardDiskCollection : List<DataVirtualHardDisk>
    {
        private DataVirtualHardDiskCollection() { }

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

    [DataContract(Name = "DataVirtualHardDisk", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class DataVirtualHardDisk : AzureDataContractBase
    {
        private DataVirtualHardDisk() { }

        [DataMember(Order = 0, IsRequired=true)]
        public HostCaching HostCaching { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string DiskLabel { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public string DiskName { get; private set; }

        [DataMember(Name="Lun", Order = 3, IsRequired = false, EmitDefaultValue=false)]
        public int? LogicalUnitNumber { get; private set; }

        [DataMember(Name="LogicalDiskSizeInGB", Order = 4, IsRequired = true)]
        public int LogicalDiskSize { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        public Uri MediaLink { get; private set; }
    }
}
