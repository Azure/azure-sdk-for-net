//-----------------------------------------------------------------------
// <copyright file="SharedKeyCanonicalizer.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the SharedKeyCanonicalizer class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using Microsoft.WindowsAzure.StorageClient;

    /// <summary>
    /// Provides an implementation of the <see cref="CanonicalizationStrategy"/> class for requests against 
    /// the Table service under the Shared Key authentication scheme.
    /// </summary>
    public sealed class SharedKeyCanonicalizer : CanonicalizationStrategy
    {
        /// <summary>
        /// Canonicalizes the HTTP request.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The canonicalized string for the request.</returns>
        public override string CanonicalizeHttpRequest(HttpWebRequest request, string accountName)
        {
            return CanonicalizeHttpRequestVersion2(
                request.Address,
                accountName,
                request.Method,
                request.ContentType,
                request.ContentLength,
                string.Empty,
                request.Headers);
        }
    }
}