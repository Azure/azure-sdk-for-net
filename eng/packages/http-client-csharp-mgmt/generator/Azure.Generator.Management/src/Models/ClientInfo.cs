// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Providers;

namespace Azure.Generator.Management.Models
{
    /// <summary>
    /// Record to combine client provider and related field providers
    /// </summary>
    internal record ClientInfo(ClientProvider Provider, FieldProvider ClientField, FieldProvider DiagnosticsField);
}
