// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using Rest;

    internal struct SearchServiceName
    {
        private const string InvalidSearchUriMessage = 
            "Invalid search service name. Name contains characters that are not valid in a URL.";

        private readonly string _name;

        public SearchServiceName(string searchServiceName)
        {
            Name.ThrowIfNullOrEmpty(searchServiceName, "searchServiceName", "search service");
            _name = searchServiceName;
        }

        public static implicit operator string(SearchServiceName searchServiceName)
        {
            return searchServiceName._name ?? String.Empty;
        }

        public Uri BuildBaseUri()
        {
            Uri uri = TypeConversion.TryParseUri("https://" + this + ".search.windows.net/");
            Throw.IfArgument(uri == null, "searchServiceName", InvalidSearchUriMessage);
            return uri;
        }

        public Uri BuildBaseUriWithIndex(IndexName indexName)
        {
            Uri uri = 
                TypeConversion.TryParseUri("https://" + this + ".search.windows.net/indexes('" + indexName + "')/");
            Throw.IfArgument(uri == null, "searchServiceName", InvalidSearchUriMessage);
            return uri;
        }
    }
}
