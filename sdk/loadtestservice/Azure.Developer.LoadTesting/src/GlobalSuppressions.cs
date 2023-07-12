// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0001:Use one of the following pre-approved namespace groups (https://azure.github.io/azure-sdk/registered_namespaces.html): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.IoT, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure", Justification = "<Pending>", Scope = "namespace", Target = "~N:Azure.Developer.LoadTesting")]
[assembly: SuppressMessage("Usage", "AZC0018: Protocol method should have requestContext as the last parameter and don't have model as parameter type or return type. Protocol method should not have optional parameters if ambiguity exists between protocol method and convenience method.", Justification = "Flag keep-non-overloadable-protocol-signature is on.")]
