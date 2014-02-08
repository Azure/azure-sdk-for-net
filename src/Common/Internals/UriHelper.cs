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

using System.Text;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public static class UriHelper
    {
        /// <summary>
        /// Concatenates parts of the Uri together ensuring that
        /// any duplicate '/' characters are removed.
        /// </summary>
        /// <param name="parts">Parts of the Uri to be combined.</param>
        /// <returns>Concatenated Uri</returns>
        public static string Concatenate(params string[] parts)
        {
            if (parts == null || parts.Length == 0)
            {
                return null;
            }

            var url = new StringBuilder();
            foreach (var part in parts)
            {
                if (string.IsNullOrEmpty(part))
                {
                    continue;
                }

                // Skip the first character if it is '/' and the last
                // character in the url is also '/'
                if (url.Length > 0 && 
                    url[url.Length - 1] == '/' && 
                    part[0] == '/')
                {
                    url.Append(part.Substring(1));
                }
                else
                {
                    url.Append(part);
                }
            }
            return url.ToString();
        }
    }
}
