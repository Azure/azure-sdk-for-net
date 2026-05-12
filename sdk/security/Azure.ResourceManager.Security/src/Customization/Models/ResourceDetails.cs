// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Security.Models
{
    // Generated discriminator subtypes include id and connectorId in their constructor chain, but the generated
    // abstract base constructor omits them. This preserves those generated subtype constructor calls.
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
