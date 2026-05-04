// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("AzureSDK", "AZC0034:Type name 'JsonWebKey' conflicts with 'Azure.Security.KeyVault.Keys.JsonWebKey (from Azure.Security.KeyVault.Keys)'.", Justification = "Renaming would be a breaking change for existing consumers.")]
