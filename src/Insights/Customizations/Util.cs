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

        /// <summary>
        /// Collection of legacy resource providers.
        /// </summary>
        public static readonly HashSet<string> LegacyResourceProviders = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "microsoft.documentdb"
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
