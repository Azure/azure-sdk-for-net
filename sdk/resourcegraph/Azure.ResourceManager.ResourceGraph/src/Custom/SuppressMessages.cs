// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Diagnostics.CodeAnalysis;

// Suppress AZC0030 for FacetRequest - this is the GA name from the previous SDK version
[assembly: SuppressMessage("Usage", "AZC0030:Model name 'FacetRequest' ends with 'Request'.", Justification = "Backward compatibility with GA SDK", Scope = "type", Target = "~T:Azure.ResourceManager.ResourceGraph.Models.FacetRequest")]
