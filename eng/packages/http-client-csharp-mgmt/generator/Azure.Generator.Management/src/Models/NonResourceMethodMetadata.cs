// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;

namespace Azure.Generator.Management.Models;

internal record NonResourceMethodMetadata(
    InputServiceMethod Method,
    ResourceScope OperationScope,
    ResourceMetadata? CarrierResource);
