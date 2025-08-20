// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.DeviceProvisioningServices.Models
{
    /// <summary> Description of the IoT hub. </summary>
    public partial class IotHubDefinitionDescription
    {
        /// <summary> Initializes a new instance of <see cref="IotHubDefinitionDescription"/>. </summary>
        /// <param name="connectionString"> Connection string of the IoT hub. </param>
        /// <param name="location"> ARM region of the IoT hub. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        public IotHubDefinitionDescription(string connectionString, AzureLocation location) : this(location)
        {
            ConnectionString = connectionString;
        }

        /// <summary> Initializes a new instance of <see cref="IotHubDefinitionDescription"/>. </summary>
        /// <param name="location"> ARM region of the IoT hub. </param>
        public IotHubDefinitionDescription(AzureLocation location)
        {
            Location = location;
        }
    }
}
