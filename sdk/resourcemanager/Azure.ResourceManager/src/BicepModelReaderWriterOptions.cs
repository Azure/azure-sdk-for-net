// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace Azure.ResourceManager
{
    /// <summary>
    ///
    /// </summary>
    public class BicepModelReaderWriterOptions : ModelReaderWriterOptions
    {
        /// <summary>
        ///
        /// </summary>
        public BicepModelReaderWriterOptions() : base("bicep")
        {
        }

        /// <summary>
        ///
        /// </summary>
        public Dictionary<object, Dictionary<string, object>> ParameterOverrides { get; } = new();
    }
}
