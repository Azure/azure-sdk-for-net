//-----------------------------------------------------------------------
// <copyright file="SharedKeyTableCanonicalizer.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Represents a canonicalizer that converts HTTP request data into a standard form appropriate for signing via 
    /// the Shared Key authentication scheme for the Table service.
    /// </summary>
    /// <seealso href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179428.aspx">Authentication for the Windows Azure Storage Services</seealso>
    public sealed class SharedKeyTableCanonicalizer : ICanonicalizer
    {
        private const string SharedKeyAuthorizationScheme = "SharedKey";
        private const int ExpectedCanonicalizedStringLength = 200;

        private static SharedKeyTableCanonicalizer instance = new SharedKeyTableCanonicalizer();

        /// <summary>
        /// Gets a static instance of the <see cref="SharedKeyTableCanonicalizer"/> object.
        /// </summary>
        /// <value>The static instance of the class.</value>
        /// <seealso href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179428.aspx">Authentication for the Windows Azure Storage Services</seealso>
        public static SharedKeyTableCanonicalizer Instance
        {
            get
            {
                return SharedKeyTableCanonicalizer.instance;
            }
        }

        private SharedKeyTableCanonicalizer()
        {
        }

        /// <summary>
        /// Gets the authorization scheme used for canonicalization.
        /// </summary>
        /// <value>The authorization scheme used for canonicalization.</value>
        /// <seealso href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179428.aspx">Authentication for the Windows Azure Storage Services</seealso>
        public string AuthorizationScheme
        {
            get
            {
                return SharedKeyAuthorizationScheme;
            }
        }

        /// <summary>
        /// Converts the specified HTTP request data into a standard form appropriate for signing.
        /// </summary>
        /// <param name="request">The HTTP request that needs to be signed.</param>
        /// <param name="accountName">The name of the storage account that the HTTP request will access.</param>
        /// <returns>The canonicalized string containing the HTTP request data in a standard form appropriate for signing.</returns>
        /// <seealso href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179428.aspx">Authentication for the Windows Azure Storage Services</seealso>
        public string CanonicalizeHttpRequest(HttpWebRequest request, string accountName)
        {
            // Add the method (GET, POST, PUT, or HEAD).
            CanonicalizedString canonicalizedString = new CanonicalizedString(request.Method, ExpectedCanonicalizedStringLength);

            // Add the Content-* HTTP headers. Empty values are allowed.
            canonicalizedString.AppendCanonicalizedElement(request.Headers[HttpRequestHeader.ContentMd5]);
            canonicalizedString.AppendCanonicalizedElement(request.ContentType);

            // Add the Date HTTP header (or the x-ms-date header if it is being used)
            AuthenticationUtility.AppendCanonicalizedDateHeader(canonicalizedString, request, true);

            // Add the canonicalized URI element
            string resourceString = AuthenticationUtility.GetCanonicalizedResourceString(request.Address, accountName, true);
            canonicalizedString.AppendCanonicalizedElement(resourceString);

            return canonicalizedString.ToString();
        }
    }
}
