using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// Utility class
    /// </summary>
    public static class Util
    {
        private static readonly Uri DummyUri = new Uri("https://localhost");

        private const string ProviderNameVariable = "providerName";
        private static readonly List<UriTemplate> ResourceIdTemplates = new List<UriTemplate>
        {
            new UriTemplate("subscriptions/{subscriptionId}/resourcegroups/{resourceGroup}/providers/{providerName}/*"),
            new UriTemplate("subscriptions/{subscriptionId}/providers/{providerName}/*")
        };

        private static readonly HashSet<string> StorageResourceProviders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "microsoft.classicstorage",
            "microsoft.storage"
        };

        private static readonly HashSet<string> ComputeResourceProviders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "microsoft.classiccompute",
            "microsoft.compute"
        };

        /// <summary>
        /// Collection of legacy resource providers.
        /// </summary>
        public static readonly HashSet<string> LegacyResourceProviders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "microsoft.documentdb",
            "microsoft.sql",
            "microsoft.web",
            "newrelic.apm"
        };

        /// <summary>
        /// Check to see if the resourceId is backed by a legacy resouce provider
        /// </summary>
        /// <param name="resourceId">resource id</param>
        /// <returns>true, if the resourceId is a legacy resource</returns>
        internal static bool IsLegacyResource(string resourceId)
        {
            string resourceProvider = ExtractResourceProvider(resourceId);
            return LegacyResourceProviders.Contains(resourceProvider);
        }

        /// <summary>
        /// Check to see if the resourceId is backed by the storage resource provider
        /// </summary>
        /// <param name="resourceId">resource id</param>
        /// <returns>true, if the resource id is for a storage resource</returns>
        internal static bool IsStorageResourceProvider(string resourceId)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException("resourceId");
            }
            
            string resourceProvider = ExtractResourceProvider(resourceId);
            return StorageResourceProviders.Contains(resourceProvider);
        }

        /// <summary>
        /// Check to see if the resourceId is backed by the compute resource provider
        /// </summary>
        /// <param name="resourceId">resource id</param>
        /// <returns>true, if the resource id is for a compute resource</returns>
        internal static bool IsComputeResourceProvider(string resourceId)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException("resourceId");
            }

            string resourceProvider = ExtractResourceProvider(resourceId);
            return ComputeResourceProviders.Contains(resourceProvider);
        }

        /// <summary>
        /// Extract the resource provider from the resourceId
        /// </summary>
        /// <param name="resourceId">resource id</param>
        /// <returns>the resource provider name</returns>
        private static string ExtractResourceProvider(string resourceId)
        {
            string resourceProviderName = null;

            resourceId = resourceId.Trim('/');
            foreach (UriTemplate uriTemplate in ResourceIdTemplates)
            {
                UriTemplateMatch match = uriTemplate.Match(DummyUri, new Uri(DummyUri, resourceId));
                if (match != null)
                {
                    resourceProviderName = match.BoundVariables[ProviderNameVariable];
                    break;
                }
            }

            return resourceProviderName;
        }
    }
}
