//-----------------------------------------------------------------------
// <copyright file="CanonicalizationHelperBase.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Auth
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    internal static partial class CanonicalizationHelper
    {
        /// <summary>
        /// Gets the canonicalized resource string for a Blob or Queue service request under the Shared Key authentication scheme.
        /// </summary>
        /// <param name="address">The resource URI.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The canonicalized resource string.</returns>
        internal static string GetCanonicalizedResourceForSharedKey(Uri address, string accountName)
        {
            // Resource path
            // Note that AbsolutePath starts with a '/'.
            string resourcePath = string.Concat(
                "/",
                accountName,
                address.AbsolutePath);
            CanonicalizedString canonicalizedResource = new CanonicalizedString(resourcePath);

            // Query parameters
            Dictionary<string, string> queryVariables = HttpUtility.ParseQueryString(address.Query);
            List<string> queryVariableKeys = new List<string>(queryVariables.Keys);
            queryVariableKeys.Sort(StringComparer.OrdinalIgnoreCase);

            foreach (string key in queryVariableKeys)
            {
                string queryParamString = string.Concat(
                    key.ToLowerInvariant(),
                    ":",
                    queryVariables[key]);

                canonicalizedResource.AppendCanonicalizedElement(queryParamString);
            }

            return canonicalizedResource.Value;
        }

        /// <summary>
        /// Gets the canonicalized resource string under the Shared Key Lite authentication scheme.
        /// </summary>
        /// <param name="address">The resource URI.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The canonicalized resource string.</returns>
        internal static string GetCanonicalizedResourceForSharedKeyLite(Uri address, string accountName)
        {
            /// Algorithm is as follows
            /// 1. Start with the empty string ("")
            /// 2. Append the account name owning the resource preceded by a
            ///     the name of the account making the request but the account that owns the
            ///     resource being accessed.
            /// 3. Append the path part of the un-decoded HTTP Request-URI, up-to but not
            ///     including the query string.
            /// 4. If the request addresses a particular component of a resource, like?comp=
            ///     metadata then append the sub-resource including question mark (like ?comp=
            ///     metadata)
            StringBuilder canonicalizedResource = new StringBuilder("/");
            canonicalizedResource.Append(accountName);

            // Note that AbsolutePath starts with a '/'.
            canonicalizedResource.Append(address.AbsolutePath);
            Dictionary<string, string> queryVariables = HttpUtility.ParseQueryString(address.Query);

            // Add only comp for the Shared Key Lite scheme
            string compQueryParameterValue;
            if (queryVariables.TryGetValue("comp", out compQueryParameterValue) &&
                (compQueryParameterValue != null))
            {
                canonicalizedResource.Append("?comp=");
                canonicalizedResource.Append(compQueryParameterValue);
            }

            return canonicalizedResource.ToString();
        }
    }
}
