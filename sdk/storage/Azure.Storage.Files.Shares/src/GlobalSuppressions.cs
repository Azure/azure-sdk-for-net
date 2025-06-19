// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "AZC0034:Type name conflicts", Justification = "Storage-specific enum that shares name with Blobs storage", Scope = "type", Target = "~T:Azure.Storage.Files.Shares.Models.CopyStatus")]
[assembly: SuppressMessage("Usage", "AZC0035:Output model type should have a corresponding method in a model factory class", Justification = "Storage model types", Scope = "type", Target = "~T:Azure.Storage.Files.Shares.Models.ShareFilePermission")]
[assembly: SuppressMessage("Usage", "AZC0035:Output model type should have a corresponding method in a model factory class", Justification = "Storage client types", Scope = "type", Target = "~T:Azure.Storage.Files.Shares.ShareDirectoryClient")]
[assembly: SuppressMessage("Usage", "AZC0035:Output model type should have a corresponding method in a model factory class", Justification = "Storage client types", Scope = "type", Target = "~T:Azure.Storage.Files.Shares.ShareFileClient")]
[assembly: SuppressMessage("Usage", "AZC0035:Output model type should have a corresponding method in a model factory class", Justification = "Generated storage model types", Scope = "type", Target = "~T:Azure.Storage.Files.Shares.Models.ShareServiceProperties")]
[assembly: SuppressMessage("Usage", "AZC0035:Output model type should have a corresponding method in a model factory class", Justification = "Storage client types", Scope = "type", Target = "~T:Azure.Storage.Files.Shares.ShareClient")]