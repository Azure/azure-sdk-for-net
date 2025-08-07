// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.ResourceManager
{
    /// <summary>
    /// Provides the options for reading and writing Bicep.
    /// </summary>
    [Experimental("AZPROVISION001")]
    public class BicepModelReaderWriterOptions : ModelReaderWriterOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BicepModelReaderWriterOptions"/>.
        /// </summary>
        public BicepModelReaderWriterOptions() : base("bicep")
        {
        }

        /// <summary>
        /// The set of property overrides to apply when writing the bicep. The key of the dictionary corresponds to the
        /// instance being written, and the value is a dictionary of property names to property values.
        /// </summary>
        public IDictionary<object, IDictionary<string, string>> PropertyOverrides { get; } = new Dictionary<object, IDictionary<string, string>>();
    }
}
