// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    public static class VirtualMachineImageEnumExtensions
    {
        public static ImageReference ImageReference(this KnownLinuxVirtualMachineImage image)
        {
            string referenceString = EnumNameAttribute.GetName(image);
            return GetImageReference(referenceString, image.ToString());
        }

        public static ImageReference ImageReference(this KnownWindowsVirtualMachineImage image)
        {
            string referenceString = EnumNameAttribute.GetName(image);
            return GetImageReference(referenceString, image.ToString());
        }

        private static ImageReference GetImageReference(string referenceString, string enumAsString)
        {
            var parts = referenceString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Count() != 3)
            {
                throw new ArgumentException("The EnumNameAttribute for " + enumAsString + " is not in correct format");
            }
            return new ImageReference
            {
                Publisher = parts[0],
                Offer = parts[1],
                Sku = parts[2],
                Version = "latest"
            };
        }
    }
}
