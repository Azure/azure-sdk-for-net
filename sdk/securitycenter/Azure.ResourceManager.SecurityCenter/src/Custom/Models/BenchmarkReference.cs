// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
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
