// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory
{
    // Customization restores the public AdditionalProperties surface that the pre-MPG AutoRest SDK
    // exposed on this resource Data class.
    //
    // Spec context: Factory.tsp -> Factory inherits Azure.ResourceManager.CommonTypes.TrackedResource,
    // whose OpenAPI/swagger envelope carries an `additionalProperties: BinaryData` slot. The AutoRest
    // generator projected this slot as a public `IDictionary<string, BinaryData> AdditionalProperties`.
    // The MPG generator (http-client-csharp-mgmt) instead emits only the internal
    // `_additionalBinaryDataProperties` backing field, breaking the published API. This partial
    // re-projects the backing field as a public read-only dictionary so downstream consumers continue
    // to compile. Wire format is unchanged.
    public partial class DataFactoryData
    {
        /// <summary> Additional properties not covered by the strongly-typed surface. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;
    }
}
