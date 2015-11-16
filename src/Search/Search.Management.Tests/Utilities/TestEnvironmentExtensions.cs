// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using System;

    /// <summary>
    /// Extensions to the TestEnvironment class.
    /// </summary>
    public static class TestEnvironmentExtensions
    {
        /// <summary>
        /// Gets the base URI of an Azure Search service for the given test environment and service name.
        /// </summary>
        /// <param name="environment">The test environment.</param>
        /// <param name="searchServiceName">The name of the search service.</param>
        /// <returns>The correct base URI of the search service in the given environment.</returns>
        public static Uri GetBaseSearchUri(this TestEnvironment environment, string searchServiceName)
        {
            EnvironmentNames envName = environment.LookupEnvironmentFromBaseUri(environment.BaseUri.AbsoluteUri);

            string domain;
            switch (envName)
            {
                case EnvironmentNames.Dogfood:
                    domain = "search-dogfood.windows-int.net";
                    break;

                case EnvironmentNames.Next:
                    domain = "search-next.windows-int.net";
                    break;

                case EnvironmentNames.Current:
                    domain = "search-current.windows-int.net";
                    break;

                case EnvironmentNames.Prod:
                default:
                    // Assume PROD if all else fails.
                    domain = "search.windows.net";
                    break;
            }

            string UriFormat = "https://{0}.{1}/";
            return new Uri(String.Format(UriFormat, searchServiceName, domain));
        }
    }
}
