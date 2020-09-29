// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    internal static class AzureSearchHttpParser
    {
        private static readonly string[] AzureSearchHostSuffixes =
        {
            ".search.windows.net",
        };

        private static readonly string[] AzureSearchSupportedVerbs = { "GET", "POST", "PUT", "HEAD", "DELETE" };
        private static readonly string[] DocumentOperationNotMonikerActions = { "search.index", "index", "search", "suggest", "autocomplete", "$count" };

        private static readonly Dictionary<string, string> OperationNames = new Dictionary<string, string>
        {
            // Index operations
            ["POST /indexes"] = "Create index",
            ["PUT /indexes/*"] = "Update index",
            ["GET /indexes"] = "List indexes",
            ["GET /indexes/*"] = "Get index",
            ["DELETE /indexes/*"] = "Delete index",
            ["GET /indexes/*/stats"] = "Get index statistics",
            ["POST /indexes/*/analyze"] = "Analyze text",

            // Document operations
            ["POST /indexes/*/docs/index"] = "Add/update/delete documents",
            ["POST /indexes/*/docs/search.index"] = "Add/update/delete documents",
            ["GET /indexes/*/docs"] = "Search documents",
            ["POST /indexes/*/docs/search"] = "Search documents",
            ["GET /indexes/*/docs/suggest"] = "Suggestions",
            ["POST /indexes/*/docs/suggest"] = "Suggestions",
            ["GET /indexes/*/docs/autocomplete"] = "Autocomplete",
            ["POST /indexes/*/docs/autocomplete"] = "Autocomplete",
            ["GET /indexes/*/docs/*"] = "Lookup document",
            ["GET /indexes/*/docs/$count"] = "Count documents",

            // Indexer operations
            ["POST /datasources"] = "Create data source",
            ["POST /indexers"] = "Create indexer",
            ["DELETE /datasources/*"] = "Delete data source",
            ["DELETE /indexers/*"] = "Delete indexer",
            ["GET /datasources/*"] = "Get data source",
            ["GET /indexers/*"] = "Get indexer",
            ["GET /indexers/*/status"] = "Get indexer status",
            ["GET /datasources"] = "List data sources",
            ["GET /indexers"] = "List indexers",
            ["POST /indexers/*/reset"] = "Reset indexer",
            ["POST /indexers/*/run"] = "Run indexer",
            ["PUT /datasources/*"] = "Update data source",
            ["PUT /indexers/*"] = "Update indexer",

            // Service operations
            ["GET /servicestats"] = "Get service statistics",

            // Skillset operations
            ["POST /skillsets/*"] = "Create skillset",
            ["DELETE /skillsets/*"] = "Delete skillset",
            ["GET /skillsets/*"] = "Get skillset",
            ["GET /skillsets"] = "List skillsets",
            ["PUT /skillsets/*"] = "Update skillset",

            // Synonym operations
            ["POST /synonymmaps"] = "Create synonym map",
            ["PUT /synonymmaps/*"] = "Update synonym map",
            ["GET /synonymmaps"] = "List synonym maps",
            ["GET /synonymmaps/*"] = "Get synonym map",
            ["DELETE /synonymmaps/*"] = "Delete synonym map",
        };

        /// <summary>
        /// Tries parsing given dependency telemetry item.
        /// </summary>
        /// <param name="httpDependency">Dependency item to parse. It is expected to be of HTTP type.</param>
        /// <returns><code>true</code> if successfully parsed dependency.</returns>
        internal static bool TryParse(ref RemoteDependencyData httpDependency)
        {
            var name = httpDependency.Name;
            var host = httpDependency.Target;
            var url = httpDependency.Data;

            if (name == null || host == null || url == null)
            {
                return false;
            }

            if (!HttpParsingHelper.EndsWithAny(host, AzureSearchHostSuffixes))
            {
                return false;
            }

            ////
            //// Azure Search REST API: https://docs.microsoft.com/en-us/rest/api/searchservice/
            ////

            HttpParsingHelper.ExtractVerb(name, out var verb, out var nameWithoutVerb, AzureSearchSupportedVerbs);

            var resourcePath = ParseResourcePath(nameWithoutVerb);

            // populate properties
            foreach (var resource in resourcePath)
            {
                if (resource.Value != null)
                {
                    var propertyName = GetPropertyNameForResource(resource.Key);
                    if (propertyName != null)
                    {
                        httpDependency.Properties[propertyName] = resource.Value;
                    }
                }
            }

            var operation = BuildOperationMoniker(verb, resourcePath);
            var operationName = GetOperationName(operation);

            httpDependency.Type = RemoteDependencyConstants.AzureSearch;

            return true;
        }

        internal static List<KeyValuePair<string, string>> ParseResourcePath(string requestPath)
        {
            if (!requestPath.Contains("("))
            {
                return HttpParsingHelper.ParseResourcePath(requestPath);
            }

            // Parse OData v4 url format
            List<string> tokens = HttpParsingHelper.TokenizeRequestPath(requestPath);

            int pairCount = tokens.Count + 1;
            var results = new List<KeyValuePair<string, string>>(pairCount);
            for (int i = 0; i < tokens.Count; i++)
            {
                var current = tokens[i];

                var valueStart = current.IndexOf('(');
                var valueEnd = current.IndexOf(')');

                if (valueStart == -1)
                {
                    var next = tokens.Count < (i + 1) ? tokens[++i] : null;
                    results.Add(new KeyValuePair<string, string>(current, next));
                }
                else
                {
                    var key = current.Substring(0, valueStart);
                    var value = current.Substring(valueStart + 2, valueEnd - valueStart - 3);

                    results.Add(new KeyValuePair<string, string>(key, value));
                }
            }

            return results;
        }

        internal static string BuildOperationMoniker(string verb, List<KeyValuePair<string, string>> resourcePath)
        {
            var operation = HttpParsingHelper.BuildOperationMoniker(verb, resourcePath);

            // Do not generate asterisk for docs path
            if (resourcePath.Count > 1 && resourcePath[1].Key == "docs" && DocumentOperationNotMonikerActions.Contains(resourcePath[1].Value))
            {
                operation = operation.Remove(operation.Length - 1) + resourcePath[1].Value;
            }

            return operation;
        }

        private static string GetPropertyNameForResource(string resourceType)
        {
            switch (resourceType)
            {
                case "indexes":
                    return "Index";
                case "datasources":
                    return "Data Source";
                case "indexers":
                    return "Indexer";
                case "skillsets":
                    return "Skillset";
                case "synonymmaps":
                    return "Synonymmap";
                default:
                    return null;
            }
        }

        private static string GetOperationName(string operation)
        {
            if (!OperationNames.TryGetValue(operation, out var operationName))
            {
                return operation;
            }

            return operationName;
        }
    }
}
