// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

// Suppress AZC0030 for ArmResponseErrorResponse as it's generated from TypeSpec and the name comes from the API specification
[assembly: SuppressMessage("Azure.Sdk.Analyzers", "AZC0030:Model name 'ArmResponseErrorResponse' ends with 'Response'. We suggest renaming it to 'ResilienceManagementArmResponseErrorResponseResult' or another name with this suffix.", Justification = "Generated from TypeSpec API specification - model name is defined in Azure REST API specs", Scope = "type", Target = "~T:Azure.ResourceManager.ResilienceManagement.Models.ArmResponseErrorResponse")]
