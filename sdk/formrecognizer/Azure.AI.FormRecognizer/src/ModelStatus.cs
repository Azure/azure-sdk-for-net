// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Custom
{

    /// <summary>
    /// </summary>
    [CodeGenSchema("ModelStatus")]
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum ModelStatus
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// </summary>
        [CodeGenSchemaMember("creating")]
        Training,

        /// <summary>
        /// </summary>
        Ready,

        /// <summary>
        /// </summary>
        Invalid
    }
}
