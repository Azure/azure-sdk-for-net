// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

// Preserve enum ordinals from Azure.Provisioning.CognitiveServices 1.2.0.
// TypeSpec generation inserted new enum values before existing members, which
// would otherwise shift the underlying integer values and break ApiCompat.
[assembly: CodeGenEnumValue("CognitiveServicesConnectionCategory", "AzureKeyVault", 105)]
[assembly: CodeGenEnumValue("CognitiveServicesConnectionCategory", "AzureContainerAppEnvironment", 106)]
[assembly: CodeGenEnumValue("CognitiveServicesConnectionCategory", "AzureStorageAccount", 107)]
[assembly: CodeGenEnumValue("CognitiveServicesConnectionCategory", "Databricks", 108)]
[assembly: CodeGenEnumValue("CognitiveServicesConnectionCategory", "RemoteTool", 109)]
[assembly: CodeGenEnumValue("CognitiveServicesConnectionCategory", "AppInsights", 110)]
[assembly: CodeGenEnumValue("CognitiveServicesConnectionCategory", "AppConfig", 111)]
[assembly: CodeGenEnumValue("ServiceAccountProvisioningState", "Canceled", 7)]
