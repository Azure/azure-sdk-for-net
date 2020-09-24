// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    public partial class TableBatchResponse
    {
        internal IDictionary<string, (HttpMessage Message, RequestType RequestType)> _requestLookup;

        internal TableBatchResponse(ConcurrentDictionary<string, (HttpMessage Message, RequestType RequestType)> requestLookup)
        {
            _requestLookup = requestLookup;
        }

        public bool IsBatchSuccessful => _requestLookup.Values.Any(r => r.Message.Response.Status >= 400);

        public int ResponseCount => _requestLookup.Keys.Count;

        public Response GetResponseForEntity(string rowKey)
        {
            if (!_requestLookup.TryGetValue(rowKey, out (HttpMessage Message, RequestType RequestType) tuple))
            {
                throw new InvalidOperationException("The batch operation did not contain an entity with the specified rowKey");
            }

            return tuple.Message.Response;
        }
    }
}
