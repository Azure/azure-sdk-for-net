// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;

namespace Azure.Provisioning.Generator.Specifications;

public class FrontDoorSpecification() :
    Specification("FrontDoor", typeof(FrontDoorSpecification), ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    {
    }
}
