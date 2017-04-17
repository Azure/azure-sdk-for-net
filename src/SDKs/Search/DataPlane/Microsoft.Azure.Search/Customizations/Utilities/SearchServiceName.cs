// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Globalization;
    using Rest;

    internal class SearchServiceName
    {
        private const string InvalidSearchUriMessageFormat =
            "Invalid search service name: '{0}' Name contains characters that are not valid in a URL.";

        private const string InvalidSearchOrIndexUriMessageFormat =
            "Either the search service name '{0}' or the index name '{1}' is invalid. Names must contain only characters that are valid in a URL.";

        private readonly string _name;

        public SearchServiceName(string searchServiceName)
        {
            Name.ThrowIfNullOrEmpty(searchServiceName, "searchServiceName", "search service");
            _name = searchServiceName;
        }

        public static implicit operator string(SearchServiceName searchServiceName)
        {
            return searchServiceName.ToString();
        }

        public override string ToString()
        {
            return _name ?? String.Empty;
        }

        public Uri BuildBaseUri()
        {
            Uri uri = TypeConversion.TryParseUri("https://" + this + ".search.windows.net/");

            if (uri == null)
            {
                string message = String.Format(CultureInfo.InvariantCulture, InvalidSearchUriMessageFormat, _name);
                throw new ArgumentException(message, "searchServiceName");
            }

            return uri;
        }

        public Uri BuildBaseUriWithIndex(IndexName indexName, string fullyQualifiedDomainName = null)
        {
            fullyQualifiedDomainName = fullyQualifiedDomainName ?? "search.windows.net";

            if (fullyQualifiedDomainName != String.Empty)
            {
                fullyQualifiedDomainName = "." + fullyQualifiedDomainName;
            }

            Uri uri = TypeConversion.TryParseUri("https://" + this + fullyQualifiedDomainName + "/indexes('" + indexName + "')/");

            if (uri == null)
            {
                string message = String.Format(CultureInfo.InvariantCulture, InvalidSearchOrIndexUriMessageFormat, _name, indexName);
                throw new ArgumentException(message, "searchServiceName");
            }

            return uri;
        }
    }
}
