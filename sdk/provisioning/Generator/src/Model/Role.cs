// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Generator.Model;

/// <summary>
/// Represents a well-known RBAC role for an Azure service.
/// </summary>
/// <param name="Name">Friendly name of the role.</param>
/// <param name="Value">GUID value of the role.</param>
/// <param name="Description">Description of the role.</param>
public record Role(
    string Name,
    string Value,
    string Description);
