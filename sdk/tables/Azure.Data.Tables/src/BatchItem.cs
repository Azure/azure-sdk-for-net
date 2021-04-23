// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Data.Tables
{
    internal class BatchItem
    {
        public RequestType RequestType { get; set; }
        public ITableEntity Entity { get; set; }
        public HttpMessage Message { get; set; }

        public BatchItem(RequestType requestType, ITableEntity entity, HttpMessage message)
        {
            RequestType = requestType;
            Entity = entity;
            Message = message;
        }
    }
}
