// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.DevTestLabs
{
    public partial class DevTestLabArmTemplateData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of <see cref="DevTestLabArmTemplateData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        public DevTestLabArmTemplateData(AzureLocation location) : base(location)
        {
        }
    }
}
