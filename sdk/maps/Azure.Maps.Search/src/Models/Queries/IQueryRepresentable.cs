// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Maps.Search.Models
{
    /// <summary> query representable </summary>
    public interface IQueryRepresentable
    {
        /// <summary> The query string will be passed verbatim to the search API for processing. </summary>
        string Query(MapsSearchClient client);
    }
}
