// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core
{
    public struct PageResponse<T>
    {
        public IEnumerable<T> Values { get; }
        public Response Response { get; }
        public string NextLink { get; }

        public PageResponse(IEnumerable<T> values, Response response, string nextLink)
        {
            Values = values;
            Response = response;
            NextLink = nextLink;
        }
    }
}
