// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// A helper class for working with the query APIs for digital twins.
    /// </summary>
    public static class QueryChargeHelper
    {
        /// <summary>
        /// A constant that is used to as the query-charge header field in the query page response.
        /// </summary>
        private const string QueryChargeHeader = "query-charge";

        /// <summary>
        /// Extract the query-charge field from a page header.
        /// </summary>
        /// <param name="page">The page that contains the query-charge header.</param>
        /// <param name="queryCharge">The query charge extracted from the header.</param>
        /// <returns>True if the header contains a query-charge field, otherwise false.</returns>
        /// <remarks>
        /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
        /// </remarks>
        /// <code snippet="Snippet:DigitalTwinsSampleQueryTwinsWithQueryCharge">
        /// // This code snippet demonstrates how you could extract the query charges incurred when calling
        /// // the query API. It iterates over the response pages first to access to the query-charge header,
        /// // and then the digital twin results within each page.
        ///
        /// AsyncPageable&lt;string&gt; asyncPageableResponseWithCharge = client.QueryAsync(&quot;SELECT * FROM digitaltwins&quot;);
        /// int pageNum = 0;
        ///
        /// // The &quot;await&quot; keyword here is required as a call is made when fetching a new page.
        /// await foreach (Page&lt;string&gt; page in asyncPageableResponseWithCharge.AsPages())
        /// {
        ///     Console.WriteLine($&quot;Page {++pageNum} results:&quot;);
        ///
        ///     // Extract the query-charge header from the page
        ///     if (QueryChargeHelper.TryGetQueryCharge(page, out float queryCharge))
        ///     {
        ///         Console.WriteLine($&quot;Query charge was: {queryCharge}&quot;);
        ///     }
        ///
        ///     // Iterate over the twin instances.
        ///     // The &quot;await&quot; keyword is not required here as the paged response is local.
        ///     foreach (string response in page.Values)
        ///     {
        ///         BasicDigitalTwin twin = JsonSerializer.Deserialize&lt;BasicDigitalTwin&gt;(response);
        ///         Console.WriteLine($&quot;Found digital twin &apos;{twin.Id}&apos;&quot;);
        ///     }
        /// }
        /// </code>
        public static bool TryGetQueryCharge(Page<string> page, out float queryCharge)
        {
            Argument.AssertNotNull(page, nameof(page));

            if (!page.GetRawResponse().Headers.TryGetValue(QueryChargeHeader, out string queryChargeHeaderValue))
            {
                queryCharge = 0f;
                return false;
            }

            return float.TryParse(queryChargeHeaderValue, out queryCharge);
        }
    }
}
