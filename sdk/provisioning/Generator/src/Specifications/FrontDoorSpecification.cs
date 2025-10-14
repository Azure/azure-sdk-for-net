// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.FrontDoor;

namespace Azure.Provisioning.Generator.Specifications;

public class FrontDoorSpecification() :
    Specification("FrontDoor", typeof(FrontDoorExtensions), ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    {
        CustomizeResource<FrontDoorResource>(r =>
        {
            r.Name = "FrontDoorResource";
        });
    }
}
