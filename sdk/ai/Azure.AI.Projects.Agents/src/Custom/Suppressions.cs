// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

// AZC0015: We return AsyncCollectionResult<T> and CollectionResult<T> instead of Pageable<T>.
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult<AgentRecord>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgent(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult<AgentRecord>>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentAsync(System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult<AgentVersion>>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersionAsync(System.String,Azure.AI.Projects.Agents.AgentVersionCreationOptions,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersion(System.String,Azure.AI.Projects.Agents.AgentVersionCreationOptions,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult<AgentVersion>>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersionFromManifestAsync(System.String,System.String,Azure.AI.Projects.Agents.AgentManifestOptions,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersionFromManifest(System.String,System.String,Azure.AI.Projects.Agents.AgentManifestOptions,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns AsyncCollectionResult<AgentRecord>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentsAsync(System.Nullable{Azure.AI.Projects.Agents.AgentKind},System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns CollectionResult<AgentRecord>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgents(System.Nullable{Azure.AI.Projects.Agents.AgentKind},System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns AsyncCollectionResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentVersionsAsync(System.String,System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns CollectionResult<AgentVersion>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentVersions(System.String,System.Nullable{System.Int32},System.Nullable{Azure.AI.Projects.Agents.AgentListOrder},System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentVersionAsync(System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentVersion(System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentAsync(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgent(System.String,System.Threading.CancellationToken)")]

// AgentsClient.RestClient
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentAsync(System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgent(System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersionAsync(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersion(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersionFromManifestAsync(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentVersionFromManifest(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentFromManifestAsync(System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.CreateAgentFromManifest(System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentVersionAsync(System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentVersion(System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentVersionAsync(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentVersion(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentAsync(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgent(System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgentAsync(System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.GetAgent(System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.UpdateAgentAsync(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.UpdateAgent(System.String,System.ClientModel.BinaryContent,System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.UpdateAgentFromManifestAsync(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.UpdateAgentFromManifest(System.String,System.ClientModel.BinaryContent,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentAsync(System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgent(System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentVersionAsync(System.String,System.String,System.Threading.CancellationToken)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentVersion(System.String,System.String,System.Threading.CancellationToken)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentAsync(System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgent(System.String,System.ClientModel.Primitives.RequestOptions)")]

[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns Task<ClientResult>.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentVersionAsync(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]
[assembly: SuppressMessage("Usage", "AZC0015", Justification = "Returns ClientResult.", Scope = "member", Target = "~M:Azure.AI.Projects.Agents.AgentsClient.DeleteAgentVersion(System.String,System.String,System.ClientModel.Primitives.RequestOptions)")]

// AZC0007 Suppress the watrning on AgentsClient creatrion.
[assembly: SuppressMessage("Usage", "AZC0007", Justification = "Custom constructor for AgentsClient.", Scope = "member", Target = "~T:Azure.AI.Projects.Agents.AgentsClient")]
