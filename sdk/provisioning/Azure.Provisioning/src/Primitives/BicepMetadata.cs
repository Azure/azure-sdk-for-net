// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Primitives;

/// <summary>
/// Represents Bicep metadata and annotations that can be applied to resources.
/// These control how resources are rendered in Bicep but are not part of the
/// Azure resource definition itself.
/// </summary>
public sealed class BicepMetadata
{
    /// <summary>
    /// Optional description for the resource that appears as a @description decorator.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Optional batch size for resource deployment.
    /// If set, adds a @batchSize(n) decorator to control parallel deployment batching.
    /// </summary>
    public uint? BatchSize { get; set; }

    /// <summary>
    /// If true, adds a @onlyIfNotExists() decorator to the resource.
    /// This prevents recreation of the resource if it already exists.
    /// </summary>
    public bool OnlyIfNotExists { get; set; }
}
