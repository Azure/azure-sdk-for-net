using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.V2.Compute
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
