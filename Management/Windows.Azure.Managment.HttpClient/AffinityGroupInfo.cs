using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

//disable warning about field never assigned to. It gets assigned at deserialization time
#pragma warning disable 649

namespace Windows.Azure.Management.v1_7
{
    [CollectionDataContract(Name = "AffinityGroups", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class AffinityGroupCollection : List<AffinityGroup>
    {
        private AffinityGroupCollection() { }
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [DataContract(Name = "AffinityGroup", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class AffinityGroup : AzureDataContractBase
    {
        private AffinityGroup() { }

        [DataMember(Order = 0)]
        public String Name { get; private set; }

        public String Label
        {
            get
            {
                return _label.DecodeBase64();
            }
        }

        [DataMember(Name="Label", Order=1)]
        private String _label;

        [DataMember(Order=2)]
        public String Description { get; private set; }

        [DataMember(Order=3)]
        public String Location { get; private set; }

        [DataMember(Name="HostedServices", Order = 4, IsRequired = false, EmitDefaultValue = false)]
        public CloudServiceCollection CloudServices { get; set; }

        [DataMember(Name = "StorageServices", Order = 5, IsRequired = false, EmitDefaultValue = false)]
        public StorageAccountPropertiesCollection StorageAccounts { get; set; }

        [DataMember(Order=6, IsRequired=false, EmitDefaultValue=false)]
        public List<String> Capabilities { get; set; }

    }

    [DataContract(Name="CreateAffinityGroup", Namespace = AzureConstants.AzureSchemaNamespace)] 
    internal class CreateAffinityGroupInfo
    {
        private CreateAffinityGroupInfo() { }

        internal static CreateAffinityGroupInfo Create(String name, String label, String description, String location)
        {
            Validation.ValidateStringArg(name, "name");
            Validation.ValidateLabel(label);
            Validation.ValidateDescription(description);
            Validation.ValidateStringArg(location, "location");

            return new CreateAffinityGroupInfo
            {
                Name = name,
                Label = label.EncodeBase64(),
                Description = description,
                Location = location
            };
        }

        [DataMember(Order=0, IsRequired=true)]
        public String Name { get; private set; }

        [DataMember(Order = 1, IsRequired = true)]
        public String Label { get; private set; }

        [DataMember(Order = 2, IsRequired=false, EmitDefaultValue=false)]
        public String Description { get; private set; }

        [DataMember(Order = 3, IsRequired=true)]
        public String Location { get; private set; }
    }
}
