// ---------------------------------------------------------------------------------- 
// 
// Copyright Microsoft Corporation 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// http://www.apache.org/licenses/LICENSE-2.0 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// ---------------------------------------------------------------------------------- 

using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HDInsight.Tests.Helpers
{
    // Excludes api version when matching mocked records. 
    // If alternate api version is provided, uses that to match records else removes the api-version matching.
    public class PermissiveRecordMatcherWithApiExclusion : IRecordMatcher
    {
        protected bool _ignoreGenericResource;
        protected Dictionary<string, string> _providersToIgnore;
        protected Dictionary<string, string> _userAgentsToIgnore;

        public PermissiveRecordMatcherWithApiExclusion(bool ignoreResourcesClient, Dictionary<string, string> providers)
        {
            _ignoreGenericResource = ignoreResourcesClient;
            _providersToIgnore = providers;
        }

        public PermissiveRecordMatcherWithApiExclusion(
            bool ignoreResourcesClient,
            Dictionary<string, string> providers,
            Dictionary<string, string> userAgents)
        {
            _ignoreGenericResource = ignoreResourcesClient;
            _providersToIgnore = providers;
            _userAgentsToIgnore = userAgents;
        }

        public virtual string GetMatchingKey(System.Net.Http.HttpRequestMessage request)
        {
            var path = request.RequestUri.PathAndQuery;
            if (path.Contains("?&"))
            {
                path = path.Replace("?&", "?");
            }

            string version;
            if (ContainsIgnoredProvider(path, out version))
            {
                path = RemoveOrReplaceApiVersion(path, version);
            }
            else if (_userAgentsToIgnore != null && _userAgentsToIgnore.Any())
            {
                var agent = request.Headers.FirstOrDefault(h => h.Key.Equals("User-Agent"));
                if (agent.Key != null)
                {
                    foreach (var userAgnet in _userAgentsToIgnore)
                    {
                        if (agent.Value.Any(v => v.StartsWith(userAgnet.Key, StringComparison.OrdinalIgnoreCase)))
                        {
                            path = RemoveOrReplaceApiVersion(path, userAgnet.Value);
                            break;
                        }
                    }
                }
            }

            var encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
            return string.Format("{0} {1}", request.Method, encodedPath);
        }

        public virtual string GetMatchingKey(RecordEntry recordEntry)
        {
            var encodedPath = recordEntry.EncodedRequestUri;
            var path = recordEntry.RequestUri;
            var changed = false;
            if (path.Contains("?&"))
            {
                path = recordEntry.RequestUri.Replace("?&", "?");
                changed = true;
            }

            string version;
            if (ContainsIgnoredProvider(path, out version))
            {
                path = RemoveOrReplaceApiVersion(path, version);
                changed = true;
            }

            if (changed)
            {
                encodedPath = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
            }

            return string.Format("{0} {1}", recordEntry.RequestMethod, encodedPath);
        }

        protected bool ContainsIgnoredProvider(string requestUri, out string version)
        {
            if (_ignoreGenericResource &&
                !requestUri.Contains("providers") &&
                !requestUri.StartsWith("/certificates?", StringComparison.OrdinalIgnoreCase) &&
                !requestUri.StartsWith("/pools", StringComparison.OrdinalIgnoreCase) &&
                !requestUri.StartsWith("/jobs", StringComparison.OrdinalIgnoreCase) &&
                !requestUri.StartsWith("/jobschedules", StringComparison.OrdinalIgnoreCase) &&
                !requestUri.Contains("/applications?") &&
                !requestUri.Contains("/servicePrincipals?") &&
                !requestUri.StartsWith("/webhdfs/v1/?aclspec", StringComparison.OrdinalIgnoreCase))
            {
                version = String.Empty;
                return true;
            }

            foreach (var provider in _providersToIgnore)
            {
                var providerString = string.Format("providers/{0}", provider.Key);
                if (requestUri.Contains(providerString))
                {
                    version = provider.Value;
                    return true;
                }
            }


            version = string.Empty;
            return false;
        }

        protected string RemoveOrReplaceApiVersion(string requestUri, string version)
        {
            if (!string.IsNullOrWhiteSpace(version))
            {
                return Regex.Replace(requestUri, @"([\?&])api-version=[^&]+", string.Format("$1api-version={0}", version));
            }
            else
            {
                var result = Regex.Replace(requestUri, @"&api-version=[^&]+", string.Empty);
                return Regex.Replace(result, @"\?api-version=[^&]+[&]*", "?");
            }
        }
    }
}