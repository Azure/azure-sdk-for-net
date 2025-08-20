// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

// the generator will generate a SubResource class in the Azure.ResourceManager.Resources.Models
// but since we already have that in the resourcemanager package in the same namespace
// to avoid the compile error, we need this attribute to remove it
[assembly: CodeGenSuppressType("SubResource")]

namespace Azure.ResourceManager.Resources.Models
{
}
