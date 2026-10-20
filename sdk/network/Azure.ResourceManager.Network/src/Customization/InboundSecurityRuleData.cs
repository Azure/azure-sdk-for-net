// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;

namespace Azure.ResourceManager.Network
{
    public partial class InboundSecurityRuleData
    {
        // The current resource schema omits etag, but the legacy model conversion must not discard it.
        /// <summary> Gets the entity tag retained in persisted resource metadata. </summary>
        public ETag? ETag
        {
            get
            {
                if (_additionalBinaryDataProperties != null && _additionalBinaryDataProperties.TryGetValue("etag", out BinaryData value))
                {
                    using JsonDocument document = JsonDocument.Parse(value);
                    return document.RootElement.ValueKind == JsonValueKind.Null ? null : new ETag(document.RootElement.GetString());
                }
                return null;
            }
        }
    }
}
