// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Security.Models
{
    public abstract partial class ResourceDetails
    {
        protected internal ResourceDetails(Source? source, string id, string connectorId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Source = source ?? default;
            Id = id;
            ConnectorId = connectorId;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Id { get; }

        public string ConnectorId { get; }
    }
}
