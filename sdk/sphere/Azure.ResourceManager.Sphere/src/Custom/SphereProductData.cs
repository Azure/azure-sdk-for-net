// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Sphere.Models;

namespace Azure.ResourceManager.Sphere
{
    public partial class SphereProductData
    {
        /// <summary> Description of the product. </summary>
        public string Description
        {
            get => Properties?.Description;
            set
            {
                EnsureProperties();
                Properties.Description = value;
            }
        }

        /// <summary> The status of the last operation. </summary>
        public SphereProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        private void EnsureProperties() => Properties ??= new ProductProperties();
    }
}
