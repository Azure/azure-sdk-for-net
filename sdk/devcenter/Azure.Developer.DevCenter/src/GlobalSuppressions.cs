// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0031: Model name 'EnvironmentDefinition' ends with 'Definition'. Suggest to rename it to an appropriate name.", Justification = "Environment Definition is a Deployment Environment concept", Scope = "namespaceanddescendants", Target = "~N:Azure.Developer.DevCenter")]
[assembly: SuppressMessage("Usage", "AZC0030: Model name 'EnvironmentDefinitionParameter' ends with 'Parameter'. Suggest to rename it to 'EnvironmentDefinitionContent' or 'EnvironmentDefinitionPatch' or any other appropriate name.", Justification = "Environment Definition Parameter is a Deployment Environment concept", Scope = "namespaceanddescendants", Target = "~N:Azure.Developer.DevCenter")]
[assembly: SuppressMessage("AzureSDK", "AZC0034:Type name 'SkuName' conflicts with 'Azure.Storage.Blobs.Models.SkuName (from Azure.Storage.Blobs)'.", Justification = "Renaming would be a breaking change for existing consumers.")]
