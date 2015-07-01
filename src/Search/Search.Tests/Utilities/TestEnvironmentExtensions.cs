// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;

namespace Microsoft.Azure.Test
{
    internal static class TestEnvironmentExtensions
    {
        public static Uri GetBaseSearchUri(
            this TestEnvironment environment, 
            ExecutionMode executionMode, 
            string searchServiceName)
        {
            EnvironmentNames envName =
                environment.LookupEnvironmentFromBaseUri(executionMode, environment.BaseUri.AbsoluteUri);

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
