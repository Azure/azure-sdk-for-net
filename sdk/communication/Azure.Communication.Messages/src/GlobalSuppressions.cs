// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("AzureSDK", "AZC0034:Type name 'MessageContent' conflicts with 'Azure.Messaging.MessageContent (from Azure.Core)'.", Justification = "Renaming would be a breaking change for existing consumers.")]
