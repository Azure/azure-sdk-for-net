// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;

namespace Azure.Projects.Ofx;

/// <summary>
/// Represents a provisioning feature that emits the default observable file exchange (OFX) infrastructure.
/// </summary>
public class OfxFeatures : AzureProjectFeature
{
    private readonly BlobContainerFeature _blobContainer;
    /// <summary>
    /// Initializes a new instance of the <see cref="OfxFeatures"/> class.
    /// </summary>
    public OfxFeatures()
    {
        _blobContainer = new BlobContainerFeature("default", isObservable: true);
    }

    /// <summary>
    /// Emits the required features for the OFX infrastructure into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit features into.</param>
    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        infrastructure.AddFeature(_blobContainer);
    }

    /// <summary>
    /// Emits the provisioning constructs for the OFX infrastructure into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit constructs into.</param>
    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        _blobContainer.EmitConstructs(infrastructure);
    }
}
