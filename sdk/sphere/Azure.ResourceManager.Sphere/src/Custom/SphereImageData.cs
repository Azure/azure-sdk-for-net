// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.ResourceManager.Sphere.Models;

namespace Azure.ResourceManager.Sphere
{
    public partial class SphereImageData
    {
        /// <summary> The image component id. </summary>
        public string ComponentId => Properties?.ComponentId;

        /// <summary> The image description. </summary>
        public string Description => Properties?.Description;

        /// <summary> Image as a UTF-8 encoded base 64 string on image create. This field contains the image URI on image reads. </summary>
        public string Image
        {
            get => Properties?.Image;
            set
            {
                EnsureProperties();
                Properties.Image = value;
            }
        }

        /// <summary> Image ID. </summary>
        public string ImageId
        {
            get => Properties?.ImageId;
            set
            {
                EnsureProperties();
                Properties.ImageId = value;
            }
        }

        /// <summary> Image name. </summary>
        public string ImageName => Properties?.ImageName;

        /// <summary> The image type. </summary>
        public SphereImageType? ImageType => Properties?.ImageType;

        /// <summary> The status of the last operation. </summary>
        public SphereProvisioningState? ProvisioningState => Properties?.ProvisioningState;

        /// <summary> Regional data boundary for an image. </summary>
        public RegionalDataBoundary? RegionalDataBoundary
        {
            get => Properties?.RegionalDataBoundary;
            set
            {
                EnsureProperties();
                Properties.RegionalDataBoundary = value;
            }
        }

        /// <summary> Location the image. </summary>
        public Uri Uri
        {
            get
            {
                string uri = Properties?.Uri;
                return uri is null ? null : (System.Uri.TryCreate(uri, System.UriKind.Absolute, out System.Uri parsed) ? parsed : null);
            }
        }

        private void EnsureProperties() => Properties ??= new ImageProperties();
    }
}
