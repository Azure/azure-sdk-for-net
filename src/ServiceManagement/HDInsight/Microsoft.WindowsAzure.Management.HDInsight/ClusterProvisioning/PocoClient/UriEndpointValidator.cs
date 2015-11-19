// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.Storage;

    internal class UriEndpointValidator
    {
        private static Uri ConvertHttpToWasbPath(Uri httpPath)
        {
            if (!(string.Equals(httpPath.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(httpPath.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("httpPath should have a uri scheme of http or https", "httpPath");
            }

            int segmentTakeCount = 1;
            string containerName = httpPath.Segments.FirstOrDefault();

            // This skips the first '/' in the URI segments.
            if (!string.IsNullOrEmpty(containerName) && containerName.Equals("/") &&
                httpPath.Segments.Length > segmentTakeCount)
            {
                containerName = httpPath.Segments.Skip(segmentTakeCount).FirstOrDefault();
                segmentTakeCount++;
            }

            // Trim off the '/' char in the container name if there is one.
            if (!string.IsNullOrEmpty(containerName))
            {
                containerName = containerName.Trim('/');
            }

            string wasbPath = string.Format(CultureInfo.InvariantCulture, "{0}://{1}@{2}/{3}", Constants.WabsProtocol, containerName, httpPath.Host, string.Join(string.Empty, httpPath.Segments.Skip(segmentTakeCount)));

            return new Uri(wasbPath);
        }

        private static Uri ConvertToWasbUriIfNeeded(Uri uri)
        {
            if (!string.Equals(uri.Scheme, Constants.WabsProtocol, StringComparison.OrdinalIgnoreCase))
            {
                // Converts to wasb from Http path if needed.
                return ConvertHttpToWasbPath(uri);
            }

            return uri;
        }

        private static WabStorageAccountConfiguration GetStorageAccountForScript(ScriptAction sa, ClusterCreateParametersV2 details)
        {
            var accts = new List<WabStorageAccountConfiguration>();

            accts.Add(new WabStorageAccountConfiguration(
                details.DefaultStorageAccountName, details.DefaultStorageAccountKey, details.DefaultStorageContainer));
            accts.AddRange(details.AdditionalStorageAccounts);

            // Tests whether the host for the script is in the list of provided storage accounts. 
            var storage = (from acct in accts
                           where GetFullyQualifiedStorageAccountName(acct.Name).Equals(
                           sa.Uri.Host, StringComparison.OrdinalIgnoreCase)
                           select acct).FirstOrDefault();

            return storage;
        }

        public static string GetFullyQualifiedStorageAccountName(string accountName)
        {
            if (accountName == null)
            {
                throw new ArgumentNullException("accountName");
            }

            // Gets the full path of the storage account.
            if (!accountName.Contains('.'))
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}.blob.core.windows.net", accountName);
            }

            return accountName;
        }

        public static async Task ValidateAndResolveWasbScriptActionEndpointUri(Uri uri, WabStorageAccountConfiguration storage)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }

            // Try to check the existence of the script in the URI specified.
            var storageAbstractionCreds = new WindowsAzureStorageAccountCredentials()
            {
                Key = storage.Key,
                Name = GetFullyQualifiedStorageAccountName(storage.Name),
            };

            var storageAbstraction = new WabStorageAbstraction(storageAbstractionCreds);

            bool exists = false;

            try
            {
                // Firstly converts the URI to wasb style and then test it against wasb storage for existence.
                exists = await storageAbstraction.Exists(ConvertToWasbUriIfNeeded(uri));
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Script action URI: {0} cannot be retrieved correctly. Inner exception: {1}", uri.AbsoluteUri, e.Message), e);
            }

            if (!exists)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Script action URI: {0} cannot be retrieved correctly because it does not exist", uri.AbsoluteUri));
            }
        }

        public static async Task ValidateAndResolveHttpScriptActionEndpointUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            // Send a HTTP HEAD request to the URI to see if it is downloadable.
            using (HttpClient httpClient = new HttpClient())
            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Head, uri))
            {
                HttpResponseMessage response;

                try
                {
                    response = await httpClient.SendAsync(httpRequestMessage);
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Script action URI: {0} cannot be retrieved correctly. Inner exception: {1}", uri.AbsoluteUri, e.Message));
                }

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Script action URI: {0} cannot be retrieved correctly. HTTP Status code: {1}", uri.AbsoluteUri, response.StatusCode));
                }
            }
        }

        public static void ValidateAndResolveConfigActionEndpointUris(ClusterCreateParametersV2 details)
        {
            if (details == null || details.ConfigActions == null)
            {
                return;
            }

            foreach (ConfigAction ca in details.ConfigActions)
            {
                ScriptAction sa = ca as ScriptAction;

                if (sa == null)
                {
                    continue;
                }

                // Basic validation on the script action URI.
                if (sa.Uri == null || string.IsNullOrEmpty(sa.Uri.AbsoluteUri))
                {
                    throw new InvalidOperationException("Invalid Container. Script action URI cannot be null or empty");
                }

                var storageAccount = GetStorageAccountForScript(sa, details);

                if (storageAccount != null)
                {
                    // Check if the URI is in one of the provided storage accounts and whether it is reachable.
                    ValidateAndResolveWasbScriptActionEndpointUri(sa.Uri, storageAccount).Wait();
                }
                else
                {
                    // Check if the URI is publicly reachable in Http format.
                    ValidateAndResolveHttpScriptActionEndpointUri(sa.Uri).Wait();
                }
            }
        }
    }
}