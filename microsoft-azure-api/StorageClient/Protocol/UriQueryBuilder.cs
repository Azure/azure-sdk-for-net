//-----------------------------------------------------------------------
// <copyright file="UriQueryBuilder.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the UriQueryBuilder.cs class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A <see cref="UriBuilder"/> style class for creating Uri query strings.
    /// </summary>
    internal class UriQueryBuilder
    {
        /// <summary>
        /// Stores the query parameters.
        /// </summary>
        private Dictionary<string, string> parameters = new Dictionary<string, string>();

        /// <summary>
        /// Add the value with Uri escaping.
        /// </summary>
        /// <param name="name">The query name.</param>
        /// <param name="value">The query value.</param>
        public void Add(string name, string value)
        {
            if (value != null)
            {
                value = Uri.EscapeDataString(value);
            }

            this.parameters.Add(name, value);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;

            foreach (var pair in this.parameters)
            {
                if (first)
                {
                    first = false;
                    sb.Append("?");
                }
                else
                {
                    sb.Append("&");
                }

                sb.Append(pair.Key);

                if (pair.Value != null)
                {
                    sb.AppendFormat("={0}", pair.Value);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Add query parameter to an existing Uri. This takes care of any existing query parameters in the Uri.
        /// </summary>
        /// <param name="uri">Original Uri which may contain query parameters already.</param>
        /// <returns>The appended Uri.</returns>
        internal Uri AddToUri(Uri uri)
        {
            // The correct way to add query parameters to a Uri http://msdn.microsoft.com/en-us/library/system.uribuilder.query.aspx
            string queryToAppend = this.ToString();

            if (queryToAppend.Length > 1)
            {
                queryToAppend = queryToAppend.Substring(1);
            }

            UriBuilder baseUri = new UriBuilder(uri);

            if (baseUri.Query != null && baseUri.Query.Length > 1)
            {
                baseUri.Query = baseUri.Query.Substring(1) + "&" + queryToAppend;
            }
            else
            {
                baseUri.Query = queryToAppend;
            }

            return baseUri.Uri;
        }
    }
}
