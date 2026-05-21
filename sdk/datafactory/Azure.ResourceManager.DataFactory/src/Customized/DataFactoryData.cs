// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization restores the public AdditionalProperties surface that the upstream
// SDK exposed on this resource Data class. The MPG generator only emits the
// "_additionalBinaryDataProperties" backing field; this partial re-exposes it
// as a public IDictionary<string, BinaryData> so downstream consumers continue
// to compile.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryData
    {
        /// <summary> Additional properties not covered by the strongly-typed surface. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;
    }
}
