// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    /// <summary>
    /// Provides a compatibility shim for the BenchmarkReference class.
    /// </summary>
    public partial class BenchmarkReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenchmarkReference"/> type for compatibility with the previous public API surface.
        /// </summary>
        public BenchmarkReference() { }
        /// <summary>
        /// Gets or sets the Benchmark value preserved from the previous public API surface.
        /// </summary>
        public string Benchmark { get; set; }
        /// <summary>
        /// Gets or sets the Reference value preserved from the previous public API surface.
        /// </summary>
        public string Reference { get; set; }
    }
}
