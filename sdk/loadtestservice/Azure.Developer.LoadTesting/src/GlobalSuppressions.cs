// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure;
using static Azure.Developer.LoadTesting.LoadTestAdministrationClient;
using System.Threading;

[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "CancellationToken can be passed through RequestOptions")]
[assembly: SuppressMessage("Usage", "AZC0001:Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.IoT, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure", Justification = "<Pending>", Scope = "namespace", Target = "~N:Azure.Developer.LoadTesting")]
[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Developer.LoadTesting.LoadTestAdministrationClient.GetValidationStatus(System.String,System.Int32,System.Int32)~Azure.Developer.LoadTesting.LoadTestAdministrationClient.ValidationStatus")]
[assembly: SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Developer.LoadTesting.LoadTestAdministrationClient.GetValidationStatusAsync(System.String,System.Int32,System.Int32)~System.Threading.Tasks.Task{Azure.Developer.LoadTesting.LoadTestAdministrationClient.ValidationStatus}")]
