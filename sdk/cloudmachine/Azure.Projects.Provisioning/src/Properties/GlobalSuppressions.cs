// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0005:DO provide protected parameterless constructor for mocking.", Justification = "<Pending>", Scope = "type", Target = "~T:Azure.Projects.ProjectClient")]
[assembly: SuppressMessage("Usage", "AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Projects.ProjectClient.#ctor(Azure.Identity.DefaultAzureCredential,Microsoft.Extensions.Configuration.IConfiguration)")]
[assembly: SuppressMessage("AZC0007:DO provide a minimal constructor that takes only the parameters required to connect to the service.", "Usage", Justification = "<Pending>", Scope = "member", Target = "~M:Azure.Projects.ProjectClient.#ctor(Azure.Core.TokenCredential,Microsoft.Extensions.Configuration.IConfiguration)")]
