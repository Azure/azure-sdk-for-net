//-----------------------------------------------------------------------
// <copyright file="CloudService.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the CloudService and CloudServiceCollection classes.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

//disable warning about field never assigned to. 
//It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a collection of CloudServices. 
    /// Returned from <see cref="AzureHttpClient.ListCloudServicesAsync"/>
    /// </summary>
    [CollectionDataContract(Name="HostedServices", Namespace=AzureConstants.AzureSchemaNamespace)]
    public class CloudServiceCollection : List<CloudService>
    {
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

    /// <summary>
    /// Represents a Windows Azure cloud service
    /// </summary>
    [DataContract(Name="HostedService", Namespace=AzureConstants.AzureSchemaNamespace)]
    public class CloudService : AzureDataContractBase
    {
        /// <summary>
        /// Gets the Service Management API request URI 
        /// used to perform requests against the service.
        /// </summary>
        [DataMember(Order = 0)]
        public Uri Url { get; private set; }

        /// <summary>
        /// Gets the name of the cloud service. 
        /// This name is the DNS prefix name and can be used to access 
        /// the cloud service.
        /// For example, if the service name is MyService you could 
        /// access the access the service by calling: 
        /// http://MyService.cloudapp.net
        /// </summary>
        [DataMember(Order = 1)]
        public string ServiceName { get; private set; }

        //the next few are nested in the _props variable

        /// <summary>
        /// Gets the description for the cloud service.
        /// </summary>
        public string Description { get { return _props.Description; } }

        /// <summary>
        /// Gets the location of the service. 
        /// Valid locations are returned from 
        /// <see cref="AzureHttpClient.ListLocationsAsync"/>.
        /// If Location is set, AffinityGroup will be null.
        /// </summary>
        public string Location { get { return _props.Location; } }

        /// <summary>
        /// Gets the AffintyGroup with which this cloud service is associated, 
        /// if any.
        /// If AffinityGroup is set, Location will be null.
        /// </summary>
        public string AffinityGroup { get { return _props.AffinityGroup; } }

        /// <summary>
        /// Gets the user supplied label for the service.
        /// </summary>
        public string Label { get { return _props.Label.DecodeBase64(); } }

        /// <summary>
        /// Gets the current <see cref="CloudServiceStatus"/> 
        /// of the cloud service.
        /// </summary>
        public CloudServiceStatus Status { get { return _props.Status; } }

        /// <summary>
        /// Gets the date and time that the cloud service was created.
        /// </summary>
        public DateTime DateCreated { get { return _props.DateCreated; } }

        /// <summary>
        /// Gets the date and time that the cloud service was last modified.
        /// </summary>
        public DateTime DateLastModified { get { return _props.DateLastModified; } }

        /// <summary>
        /// Gets a collection of extended properties associated with 
        /// the cloud service.
        /// </summary>
        public ExtendedPropertyCollection ExtendedProperties { get { return _props.ExtendedProperties; } }

        /// <summary>
        /// Gets the <see cref="Deployment">deployments</see>, if any, 
        /// in this cloud service.
        /// This member is filled in only from the 
        /// <see cref="AzureHttpClient.GetCloudServicePropertiesAsync"/> method
        /// with the embedDetail parameter set to true. 
        /// Otherwise it will be null.
        /// </summary>
        [DataMember(Order = 3, IsRequired=false, EmitDefaultValue=false)]
        public List<Deployment> Deployments { get; private set; }

        /// <summary>
        /// Unknown what is for, or if it is used...
        /// </summary>
        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        public bool IsComplete { get; private set; }

        /// <summary>
        /// Gets the <see cref="Deployment">deployments</see>, if any, 
        /// in this cloud service.
        /// This member is filled in only from the 
        /// <see cref="AzureHttpClient.GetCloudServicePropertiesAsync"/> method
        /// with the embedDetail parameter set to true. 
        /// Otherwise it will be null.
        /// </summary>
        public Deployment ProductionDeployment
        {
            get
            {
                return Deployments == null ? null :
                       (from d in Deployments
                       where d.DeploymentSlot == DeploymentSlot.Production
                       select d).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the <see cref="Deployment">deployments</see>, if any, 
        /// in this cloud service.
        /// This member is filled in only from the 
        /// <see cref="AzureHttpClient.GetCloudServicePropertiesAsync"/> method
        /// with the embedDetail parameter set to true. 
        /// Otherwise it will be null.
        /// </summary>
        public Deployment StagingDeployment
        {
            get
            {
                return Deployments == null ? null :
                       (from d in Deployments
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
            internal string Description { get; set; }

            [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
            internal string AffinityGroup { get; set; }

            [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
            internal string Location { get; set; }

            [DataMember(Order = 2)]
            internal string Label { get; set; }

            [DataMember(Order = 3)]
            internal CloudServiceStatus Status { get; set; }

            [DataMember(Order = 4)]
            internal DateTime DateCreated { get; set; }

            [DataMember(Order = 5)]
            internal DateTime DateLastModified { get; set; }

            [DataMember(Order = 6)]
            internal ExtendedPropertyCollection ExtendedProperties { get; set; }
        }
    }
}
