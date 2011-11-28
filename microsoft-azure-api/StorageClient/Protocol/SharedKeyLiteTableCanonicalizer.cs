//-----------------------------------------------------------------------
// <copyright file="SharedKeyLiteTableCanonicalizer.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the SharedKeyLiteTableCanonicalizer class.
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
    /// Provides an implementation of the <see cref="CanonicalizationStrategy"/> class for tables
    /// for the Shared Key Lite authentication scheme.
    /// </summary>
    public sealed class SharedKeyLiteTableCanonicalizer : CanonicalizationStrategy
    {
        /// <summary>
        /// Canonicalizes the HTTP request.
        /// </summary>
        /// <param name="request">A web request.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The canonicalized string for the request.</returns>
        public override string CanonicalizeHttpRequest(HttpWebRequest request, string accountName)
        {
            string date = request.Headers[Constants.HeaderConstants.Date];

            if (string.IsNullOrEmpty(date))
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.MissingXmsDateInHeader);
                throw new ArgumentException(errorMessage, "request");
            }

            StringBuilder canonicalizedString = new StringBuilder(date);
            AppendStringToCanonicalizedString(canonicalizedString, GetCanonicalizedResource(request.Address, accountName));

            return canonicalizedString.ToString();
        }
    }
}