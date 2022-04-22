// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "LLC helpers have cancellationToken based on customer need.", Scope = "member", Target = "~M:Azure.Analytics.Synapse.AccessControl.RoleAssignmentsClient.GetRoleAssignmentByIdAsync(System.String)~System.Threading.Tasks.Task{Azure.Response{Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails}}")]
[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "LLC helpers have cancellationToken based on customer need.", Scope = "member", Target = "~M:Azure.Analytics.Synapse.AccessControl.RoleAssignmentsClient.GetRoleAssignmentById(System.String)~Azure.Response{Azure.Analytics.Synapse.AccessControl.RoleAssignmentDetails}")]
[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "LLC helpers have cancellationToken based on customer need.", Scope = "member", Target = "~M:Azure.Analytics.Synapse.AccessControl.RoleAssignmentsClient.CheckPrincipalAccess(Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessRequest)~Azure.Response{Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessResponse}")]
[assembly: SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "LLC helpers have cancellationToken based on customer need.", Scope = "member", Target = "~M:Azure.Analytics.Synapse.AccessControl.RoleAssignmentsClient.CheckPrincipalAccessAsync(Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessRequest)~System.Threading.Tasks.Task{Azure.Response{Azure.Analytics.Synapse.AccessControl.CheckPrincipalAccessResponse}}")]
