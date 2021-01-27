﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0001:Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.Iot, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure", Justification = "<Pending>", Scope = "module")]
[assembly: SuppressMessage("Usage", "AZC0008:ClientOptions should have a nested enum called ServiceVersion", Justification = "<Pending>", Scope = "type", Target = "~T:Azure.Core.ClientOptions")]
[assembly: SuppressMessage("Usage", "AZC0014:Avoid using banned types in public API", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Core.Serialization.JsonObjectSerializer.#ctor(System.Text.Json.JsonSerializerOptions)")]
