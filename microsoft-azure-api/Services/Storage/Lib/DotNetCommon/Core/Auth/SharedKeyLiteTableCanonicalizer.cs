//-----------------------------------------------------------------------
// <copyright file="SharedKeyLiteTableCanonicalizer.cs" company="Microsoft">
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
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    /// <summary>
    /// Represents a canonicalizer that converts HTTP request data into a standard form appropriate for signing via 
    /// the Shared Key Lite authentication scheme for the Table service.
    /// </summary>
    /// <seealso href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179428.aspx">Authentication for the Windows Azure Storage Services</seealso>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Canonicalizer", Justification = "Reviewed: Canonicalizer can be used as an identifier name.")]
    public sealed class SharedKeyLiteTableCanonicalizer : ICanonicalizer
    {
        private const string SharedKeyLiteAuthorizationScheme = "SharedKeyLite";
        private const int ExpectedCanonicalizedStringLength = 150;

        private static SharedKeyLiteTableCanonicalizer instance = new SharedKeyLiteTableCanonicalizer();

        /// <summary>
        /// Gets a static instance of the <see cref="SharedKeyLiteTableCanonicalizer"/> object.
        /// </summary>
        /// <value>The static instance of the class.</value>
        /// <seealso href="http://msdn.microsoft.com/en-us/library/windowsazure/dd179428.aspx">Authentication for the Windows Azure Storage Services</seealso>
        public static SharedKeyLiteTableCanonicalizer Instance
        {
            get
            {
                return SharedKeyLiteTableCanonicalizer.instance;
            }
        }

        private SharedKeyLiteTableCanonicalizer()
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
                return SharedKeyLiteAuthorizationScheme;
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
            CommonUtility.AssertNotNull("request", request);

            // Add the x-ms-date or Date HTTP header
            string dateHeaderValue = AuthenticationUtility.GetPreferredDateHeaderValue(request);
            CanonicalizedString canonicalizedString = new CanonicalizedString(dateHeaderValue, ExpectedCanonicalizedStringLength);

            // Add the canonicalized URI element
            string resourceString = AuthenticationUtility.GetCanonicalizedResourceString(request.RequestUri, accountName, true);
            canonicalizedString.AppendCanonicalizedElement(resourceString);

            return canonicalizedString.ToString();
        }
    }
}
