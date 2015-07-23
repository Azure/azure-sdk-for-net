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
    internal static class Util
    {
        private static readonly Uri dummyUri = new Uri("https://localhost");

        /// <summary>
        /// Checks whether the resource is from document db
        /// </summary>
        internal static bool IsDocumentDb(string resourceUri)
        {
            resourceUri = resourceUri.Trim('/');
            var uriTemplate = new UriTemplate("subscriptions/{subscriptionId}/resourcegroups/{resourceGroup}/providers/microsoft.documentdb");
            var match = uriTemplate.Match(dummyUri, new Uri(dummyUri, resourceUri));
            return match != null;
        }
    }
}
