// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Microsoft.Azure.Search
{
    internal partial class IndexesOperations
    {
        public SearchIndexClient GetClient(string indexName)
        {
            // Argument checking is done by the SearchIndexClient constructor. Note that HttpClient can't be shared in
            // case it has already been used (SearchIndexClient will attempt to set the Timeout property on it).
            Uri indexBaseUri = new Uri(Client.BaseUri, String.Format("indexes('{0}')", indexName));
            return new SearchIndexClient(indexBaseUri, Client.Credentials);
        }
    }
}
