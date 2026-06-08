// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

// Suppress AZC0030 for ArmResponseErrorResponse: this type is synthesized by the mgmt generator from the
// template instantiation ArmResponse<ErrorResponse> and has no corresponding TypeSpec model declaration,
// so it cannot be renamed via @@clientName in client.tsp.
[assembly: SuppressMessage("Azure.Sdk.Analyzers", "AZC0030:Model name 'ArmResponseErrorResponse' ends with 'Response'. We suggest renaming it to 'ResilienceManagementArmResponseErrorResponseResult' or another name with this suffix.", Justification = "Generator-synthesized type from ArmResponse<ErrorResponse>; has no TypeSpec model to rename.", Scope = "type", Target = "~T:Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponse")]
