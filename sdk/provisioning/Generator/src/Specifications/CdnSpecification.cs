// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Cdn;

namespace Azure.Provisioning.Generator.Specifications;

public class CdnSpecification() :
    Specification("Cdn", typeof(CdnExtensions), ignorePropertiesWithoutPath: false /* TODO -- temp */)
{
    protected override void Customize()
    {
        CustomizeResource<ProfileResource>(r => r.Name = "CdnProfile");
    }
}
