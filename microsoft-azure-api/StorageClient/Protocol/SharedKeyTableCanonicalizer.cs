//-----------------------------------------------------------------------
// <copyright file="SharedKeyTableCanonicalizer.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the SharedKeyTableCanonicalizer class.
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
    public sealed class SharedKeyTableCanonicalizer : CanonicalizationStrategy
    {
        /// <summary>
        /// Canonicalizes the HTTP request.
        /// </summary>
        /// <param name="request">A web request.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The canonicalized string for the request.</returns>
        public override string CanonicalizeHttpRequest(HttpWebRequest request, string accountName)
        {
            CanonicalizedString canonicalizedString = new CanonicalizedString(request.Method);

            string httpContentMD5Value = request.Headers[HttpRequestHeader.ContentMd5];

            canonicalizedString.AppendCanonicalizedElement(httpContentMD5Value);

            string contentType = request.ContentType;
            canonicalizedString.AppendCanonicalizedElement(contentType);

            string date = request.Headers[Constants.HeaderConstants.Date];
            if (string.IsNullOrEmpty(date))
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.MissingXmsDateInHeader);
                throw new ArgumentException(errorMessage, "request");
            }

            canonicalizedString.AppendCanonicalizedElement(date);

            canonicalizedString.AppendCanonicalizedElement(GetCanonicalizedResource(request.Address, accountName));

            return canonicalizedString.ToString();
        }
    }
}