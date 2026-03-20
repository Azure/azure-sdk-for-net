// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

// AZC0015: We return AsyncCollectionResult<T> and CollectionResult<T> instead of Pageable<T>.
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult<AgentRecord>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgent(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult<AgentRecord>>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentAsync(System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult<AgentVersion>>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersionAsync(System.String,Azure.AI.Projects.Agents.AgentVersionCreationOptions,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersion(System.String,Azure.AI.Projects.Agents.AgentVersionCreationOptions,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult<AgentVersion>>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersionFromManifestAsync(System.String,System.String,Azure.AI.Projects.Agents.AgentManifestOptions,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersionFromManifest(System.String,System.String,Azure.AI.Projects.Agents.AgentManifestOptions,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns AsyncCollectionResult<AgentRecord>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentsAsync(System.Nullable{Azure.AI.Projects.Agents.AgentKind},System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns CollectionResult<AgentRecord>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgents(System.Nullable{Azure.AI.Projects.Agents.AgentKind},System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns AsyncCollectionResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentVersionsAsync(System.String,System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns CollectionResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentVersions(System.String,System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentVersionAsync(System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentVersion(System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentAsync(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgent(System.String,System.Threading.CancellationToken)")]

// AgentsClient.RestClient
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentAsync(System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgent(System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersionAsync(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersion(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersionFromManifestAsync(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentVersionFromManifest(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentFromManifestAsync(System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.CreateAgentFromManifest(System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentVersionAsync(System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentVersion(System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentVersionAsync(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentVersion(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentAsync(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgent(System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgentAsync(System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.GetAgent(System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.UpdateAgentAsync(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.UpdateAgent(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.UpdateAgentFromManifestAsync(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.UpdateAgentFromManifest(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentAsync(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgent(System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentVersionAsync(System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentVersion(System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentAsync(System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgent(System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentVersionAsync(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentAdministrationClient.DeleteAgentVersion(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]

// AZC0007 Suppress the warning on AgentAdministrationClient creation.
[assembly: SuppressMessage("Usage", "AZC0007", Justification = "Custom constructor for AgentsClient.", Scope = "member", Target = "~T:Azure.AI.Projects.Agents.AgentAdministrationClient")]
