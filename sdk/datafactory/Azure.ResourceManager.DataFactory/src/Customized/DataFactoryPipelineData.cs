// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory
{
    // Customization restores the public AdditionalProperties surface on this Data class.
    //
    // Spec context: PipelineResource.tsp is a ProxyResource whose OpenAPI/swagger envelope carries an
    // `additionalProperties: BinaryData` slot. The pre-MPG AutoRest SDK exposed it as a public
    // `IDictionary<string, BinaryData> AdditionalProperties`; the MPG generator emits only the internal
    // `_additionalBinaryDataProperties` backing field. This partial re-projects the field publicly so
    // downstream consumers continue to compile. Wire format is unchanged.
    public partial class DataFactoryPipelineData
    {
        /// <summary> Additional properties not covered by the strongly-typed surface. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;
    }
}
