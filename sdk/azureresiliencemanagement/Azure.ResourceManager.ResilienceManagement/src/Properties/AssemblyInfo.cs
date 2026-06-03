// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: Azure.Core.AzureResourceProviderNamespace("Microsoft.AzureResilienceManagement")]

// Suppress AZC0030 for ArmResponseErrorResponse. The model is synthesized by the mgmt generator from the
// ArmResponse<ErrorResponse> template instantiation and has no corresponding TypeSpec model declaration,
// so it cannot be renamed via @@clientName in client.tsp.
[assembly: SuppressMessage("Azure.Sdk.Analyzers", "AZC0030:Model name 'ArmResponseErrorResponse' ends with 'Response'. We suggest renaming it to 'ArmResponseErrorResponseResult' or another name with this suffix.", Justification = "Generator-synthesized from ArmResponse<ErrorResponse>; not a TypeSpec-declared model, cannot be renamed via @@clientName.", Scope = "type", Target = "~T:Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponse")]
