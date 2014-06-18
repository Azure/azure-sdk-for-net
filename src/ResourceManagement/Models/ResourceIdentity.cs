using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Management.Resources.Models
{
    public partial class ResourceIdentity
    {
        public ResourceIdentity(string name, string resourceType, string apiVersion)
        {
            ResourceName = name;
            ResourceProviderNamespace = GetProviderFromResourceType(resourceType);
            ResourceType = GetTypeFromResourceType(resourceType);
            ResourceProviderApiVersion = apiVersion;
        }

        public static string GetProviderFromResourceType(string resourceType)
        {
            if (resourceType == null)
            {
                return null;
            }

            int indexOfSlash = resourceType.IndexOf('/');
            if (indexOfSlash < 0)
            {
                return string.Empty;
            }
            else
            {
                return resourceType.Substring(0, indexOfSlash);
            }
        }

        public static string GetTypeFromResourceType(string resourceType)
        {
            if (resourceType == null)
            {
                return null;
            }

            int lastIndexOfSlash = resourceType.LastIndexOf('/');
            if (lastIndexOfSlash < 0)
            {
                return string.Empty;
            }
            else
            {
                return resourceType.Substring(lastIndexOfSlash + 1);
            }
        }
    }
}
