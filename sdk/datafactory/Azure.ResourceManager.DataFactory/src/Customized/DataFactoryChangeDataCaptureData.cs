// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization restores the public AdditionalProperties surface that the upstream
// SDK exposed on this resource Data class.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryChangeDataCaptureData
    {
        /// <summary> Additional properties not covered by the strongly-typed surface. </summary>
        public IDictionary<string, BinaryData> AdditionalProperties => _additionalBinaryDataProperties;
    }
}
