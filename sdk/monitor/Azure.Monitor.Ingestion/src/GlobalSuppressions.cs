﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "CancellationToken can be passed through RequestOptions")]
[assembly: SuppressMessage("Usage", "AZC0016:Invalid ServiceVersion member name.", Justification = "Generated code: https://github.com/Azure/autorest.csharp/issues/1524")]
[assembly: SuppressMessage("Usage", "AZC0001:Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.IoT, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure", Justification = "<Pending>", Scope = "namespace", Target = "~N:Azure.Monitor.Ingestion")]
