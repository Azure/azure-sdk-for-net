// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated discriminator subtypes include id and connectorId in their constructor chain, but the generated
    // abstract base constructor omits them. This preserves those generated subtype constructor calls.
    public abstract partial class ResourceDetails
    {
        /// <summary> Initializes a new instance of <see cref="ResourceDetails"/>. </summary>
        /// <param name="source"> The source of the resource details. </param>
        /// <param name="id"> The resource ID. </param>
        /// <param name="connectorId"> The connector ID. </param>
        /// <param name="additionalBinaryDataProperties"> Additional serialized properties. </param>
        protected internal ResourceDetails(Source? source, string id, string connectorId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Source = source ?? default;
            Id = id;
            ConnectorId = connectorId;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The resource ID. </summary>
        public string Id { get; }

        /// <summary> The connector ID. </summary>
        public string ConnectorId { get; }
    }
}
