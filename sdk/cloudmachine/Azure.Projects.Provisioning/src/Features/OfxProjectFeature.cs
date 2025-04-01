// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Projects.Storage;

namespace Azure.Projects.Ofx;

public class OfxProjectFeature : AzureProjectFeature
{
    private readonly BlobContainerFeature _blobContainer;

    public OfxProjectFeature()
    {
        _blobContainer = new BlobContainerFeature("default", isObservable: true);
    }

    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        infrastructure.AddFeature(_blobContainer);
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        _blobContainer.EmitConstructs(infrastructure);
    }
}
