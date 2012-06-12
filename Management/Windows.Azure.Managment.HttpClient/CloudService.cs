using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Linq;

//disable warning about field never assigned to. It gets assigned at deserialization time
#pragma warning disable 649

namespace Windows.Azure.Management.v1_7
{
    //TODO: Add this back when I know what the values are!
    //[DataContract(Name = "Status")]
    //public enum CloudServiceStatus
    //{
    //    //not sure what the other values are here...
    //    [EnumMember]
    //    Created,
    //}

    [CollectionDataContract(Name="HostedServices", Namespace=AzureConstants.AzureSchemaNamespace)]
    public class CloudServiceCollection : List<CloudService>
    {
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [CollectionDataContract(Name = "ExtendedProperties", ItemName = "ExtendedProperty", KeyName="Name", ValueName="Value", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ExtendedPropertyCollection : Dictionary<String, String>
    {
        private ExtendedPropertyCollection()
        {
        }

        internal ExtendedPropertyCollection(IDictionary<String, String> collection)
            : base(collection)
        {
        }

        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [DataContract(Name="HostedService", Namespace=AzureConstants.AzureSchemaNamespace)]
    public class CloudService : AzureDataContractBase
    {
        [DataMember(Order = 0)]
        public Uri Url { get; private set; }

        [DataMember(Order = 1)]
        public String ServiceName { get; private set; }

        //these are nested in the _props variable
        public String Description { get { return _props.Description; } }

        public String Location { get { return _props.Location; } }

        public String AffinityGroup { get { return _props.AffinityGroup; } }

        //TODO: store decoded value?
        public String Label { get { return _props.Label.DecodeBase64(); } }

        //public CloudServiceStatus Status { get { return _props.Status; } }
        public String Status { get { return _props.Status; } }

        public DateTime DateCreated { get { return _props.DateCreated; } }

        public DateTime DateLastModified { get { return _props.DateLastModified; } }

        public ExtendedPropertyCollection ExtendedProperties { get { return _props.ExtendedProperties; } }

        [DataMember(Order = 3, IsRequired=false, EmitDefaultValue=false)]
        public List<Deployment> Deployments { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        public Boolean IsComplete { get; private set; }

        public Deployment ProductionDeployment
        {
            get
            {
                return this.Deployments == null ? null :
                       (from d in this.Deployments
                       where d.DeploymentSlot == DeploymentSlot.Production
                       select d).FirstOrDefault();
            }
        }
        public Deployment StagingDeployment
        {
            get
            {
                return this.Deployments == null ? null :
                       (from d in this.Deployments
                       where d.DeploymentSlot == DeploymentSlot.Staging
                       select d).FirstOrDefault();
            }
        }

        [DataMember(Order=2, Name="HostedServiceProperties")]
        private CloudServicePropertiesInternal _props;

        [DataContract(Name = "HostedServiceProperties", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class CloudServicePropertiesInternal : AzureDataContractBase
        {
            [DataMember(Order=0, IsRequired=false, EmitDefaultValue=false)]
            internal String Description { get; set; }

            [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
            internal String AffinityGroup { get; set; }

            [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
            internal String Location { get; set; }

            [DataMember(Order = 2)]
            internal String Label { get; set; }

            [DataMember(Order = 3)]
            //internal CloudServiceStatus Status { get; set; }
            internal String Status { get; set; } //this is a String for now since I don't know what all of the values are...

            [DataMember(Order = 4)]
            internal DateTime DateCreated { get; set; }

            [DataMember(Order = 5)]
            internal DateTime DateLastModified { get; set; }

            [DataMember(Order = 6)]
            internal ExtendedPropertyCollection ExtendedProperties { get; set; }
        }
    }
}
