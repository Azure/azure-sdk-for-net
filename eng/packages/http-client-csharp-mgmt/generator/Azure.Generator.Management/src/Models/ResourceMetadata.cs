// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Management.Models
{
    internal record ResourceMetadata(string ResourceType, InputModelType ResourceModel, InputClient ResourceClient, bool IsSingleton, ResourceScope ResourceScope);
}
