// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> Parameters for Create or Update request for ServiceResource. </summary>
    public partial class CosmosDBServiceCreateOrUpdateContent
    {
        /// <summary> Instance type for the service. </summary>
        public CosmosDBServiceSize? InstanceSize
        {
            get
            {
                return this.Properties.InstanceSize;
            }
            set
            {
                this.Properties.InstanceSize = value;
            }
        }

        /// <summary> Instance count for the service. </summary>
        public int? InstanceCount
        {
            get
            {
                return this.Properties.InstanceCount;
            }
            set
            {
                this.Properties.InstanceCount = value;
            }
        }

        /// <summary> ServiceType for the service. </summary>
        public CosmosDBServiceType? ServiceType
        {
            get
            {
                return this.Properties.ServiceType;
            }
            set
            {
                this.Properties.ServiceType = value.GetValueOrDefault();
            }
        }
    }
}
