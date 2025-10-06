// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Files;

#pragma warning disable CS0618

[CodeGenType("AzureCreateFileRequestExpiresAfter")]
[CodeGenVisibility(nameof(AzureFileExpirationOptions), CodeGenVisibility.Internal)]
[Experimental("AOAI001")]
public partial class AzureFileExpirationOptions
{ }