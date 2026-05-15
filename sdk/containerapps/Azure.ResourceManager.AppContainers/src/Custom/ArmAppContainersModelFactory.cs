// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers.Models
{
    // TODO: Remove this suppression when https://github.com/Azure/azure-sdk-for-net/issues/57525 is fixed.
    // The TypeSpec model uses an intentionally empty LogicAppProperties envelope. The generator keeps that
    // empty envelope internal, so suppress the public model-factory overload that would expose the internal type.
    [CodeGenSuppress("LogicAppData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(ContainerAppLogicAppConfiguration))]
    public static partial class ArmAppContainersModelFactory
    {
    }
}
