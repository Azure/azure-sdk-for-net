// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class SynapseAccessControlClient
    {
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SynapseRoleAssignment> CreateRoleAssignment(SynapseRoleScope roleScope, string roleDefinitionId, string principalId, Guid? roleAssignmentName = null)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(roleDefinitionId, nameof(roleDefinitionId));
            Argument.AssertNotNullOrEmpty(principalId, nameof(principalId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(CreateRoleAssignment)}");
            scope.Start();
            try
            {
                string name = (roleAssignmentName ?? Guid.NewGuid()).ToString();

                Response createRoleAssignmentResponse = CreateRoleAssignment(
                    name,
                    RequestContent.Create(
                        new
                        {
                            RoleId = roleDefinitionId,
                            PrincipalId = principalId,
                            Scope = roleScope.ToString()
                        }));

                JsonDocument roleAssignment = JsonDocument.Parse(createRoleAssignmentResponse.Content.ToMemory());

                return Response.FromValue(new SynapseRoleAssignment(
                    roleAssignment.RootElement.GetProperty("id").ToString(),
                    new SynapseRoleAssignmentProperties(
                        roleAssignment.RootElement.GetProperty("principalId").ToString(),
                        roleAssignment.RootElement.GetProperty("roleDefinitionId").ToString(),
                        roleAssignment.RootElement.GetProperty("scope").ToString())),
                    createRoleAssignmentResponse);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SynapseRoleAssignment>> CreateRoleAssignmentAsync(SynapseRoleScope roleScope, string roleDefinitionId, string principalId, Guid? roleAssignmentName = null)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(roleDefinitionId, nameof(roleDefinitionId));
            Argument.AssertNotNullOrEmpty(principalId, nameof(principalId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(CreateRoleAssignment)}");
            scope.Start();
            try
            {
                string name = (roleAssignmentName ?? Guid.NewGuid()).ToString();

                Response createRoleAssignmentResponse = await CreateRoleAssignmentAsync(
                    name,
                    RequestContent.Create(
                        new
                        {
                            RoleId = roleDefinitionId,
                            PrincipalId = principalId,
                            Scope = roleScope.ToString()
                        })).ConfigureAwait(false);

                JsonDocument roleAssignment = await JsonDocument.ParseAsync(createRoleAssignmentResponse.ContentStream, default).ConfigureAwait(false);

                return Response.FromValue(new SynapseRoleAssignment(
                    roleAssignment.RootElement.GetProperty("id").ToString(),
                    new SynapseRoleAssignmentProperties(
                        roleAssignment.RootElement.GetProperty("principalId").ToString(),
                        roleAssignment.RootElement.GetProperty("roleDefinitionId").ToString(),
                        roleAssignment.RootElement.GetProperty("scope").ToString())),
                    createRoleAssignmentResponse);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response DeleteRoleAssignment(SynapseRoleScope roleScope, string roleAssignmentName)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(DeleteRoleAssignment)}");
            scope.Start();
            try
            {
                return DeleteRoleAssignmentById(
                    roleAssignmentName,
                    roleScope.ToString());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response> DeleteRoleAssignmentAsync(SynapseRoleScope roleScope, string roleAssignmentName)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(DeleteRoleAssignment)}");
            scope.Start();
            try
            {
                return await DeleteRoleAssignmentByIdAsync(
                    roleAssignmentName,
                    roleScope.ToString()).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // TODO: do not use roleScope ?
        // GetRoleAssignmentById(string roleAssignmentId, RequestOptions options = null)
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SynapseRoleAssignment> GetRoleAssignment(SynapseRoleScope roleScope, string roleAssignmentName)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleAssignment)}");
            scope.Start();
            try
            {
                Response roleAssignmentResponse = GetRoleAssignmentById(roleAssignmentName);

                JsonDocument roleAssignment = JsonDocument.Parse(roleAssignmentResponse.Content.ToMemory());

                return Response.FromValue(new SynapseRoleAssignment(
                    roleAssignment.RootElement.GetProperty("id").ToString(),
                    new SynapseRoleAssignmentProperties(
                        roleAssignment.RootElement.GetProperty("principalId").ToString(),
                        roleAssignment.RootElement.GetProperty("roleDefinitionId").ToString(),
                        roleAssignment.RootElement.GetProperty("scope").ToString())),
                    roleAssignmentResponse);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SynapseRoleAssignment>> GetRoleAssignmentAsync(SynapseRoleScope roleScope, string roleAssignmentName)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleAssignment)}");
            scope.Start();
            try
            {
                Response roleAssignmentResponse = await GetRoleAssignmentByIdAsync(roleAssignmentName).ConfigureAwait(false);

                JsonDocument roleAssignment = await JsonDocument.ParseAsync(roleAssignmentResponse.ContentStream, default).ConfigureAwait(false);

                return Response.FromValue(new SynapseRoleAssignment(
                    roleAssignment.RootElement.GetProperty("id").ToString(),
                    new SynapseRoleAssignmentProperties(
                        roleAssignment.RootElement.GetProperty("principalId").ToString(),
                        roleAssignment.RootElement.GetProperty("roleDefinitionId").ToString(),
                        roleAssignment.RootElement.GetProperty("scope").ToString())),
                    roleAssignmentResponse);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // TODO: change return type from list to pageable
        // TODO: get by roleId or get by principalId ?
        // ListRoleAssignments(string roleId = null, string principalId = null, string scope = null, string continuationToken = null, RequestOptions options = null)
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<SynapseRoleAssignment> GetRoleAssignments(SynapseRoleScope? roleScope = null)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = ListRoleAssignments(scope: roleScope.ToString());

                    JsonDocument roleAssignmentListJson = JsonDocument.Parse(response.Content.ToMemory());
                    List<SynapseRoleAssignment> roleAssignmentList = new List<SynapseRoleAssignment>();
                    foreach (var item in roleAssignmentListJson.RootElement.GetProperty("value").EnumerateArray())
                    {
                        roleAssignmentList.Add(new SynapseRoleAssignment(
                            item.GetProperty("id").ToString(),
                            new SynapseRoleAssignmentProperties(
                                item.GetProperty("principalId").ToString(),
                                item.GetProperty("roleDefinitionId").ToString(),
                                item.GetProperty("scope").ToString())));
                    }

                    return Page.FromValues(roleAssignmentList, null, response);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (null));
        }

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<SynapseRoleAssignment> GetRoleAssignmentsAsync(SynapseRoleScope? roleScope = null)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(ListRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = await ListRoleAssignmentsAsync(scope: roleScope.ToString()).ConfigureAwait(false);

                    JsonDocument roleAssignmentListJson = await JsonDocument.ParseAsync(response.ContentStream, default).ConfigureAwait(false);
                    List<SynapseRoleAssignment> roleAssignmentList = new List<SynapseRoleAssignment>();
                    foreach (var item in roleAssignmentListJson.RootElement.GetProperty("value").EnumerateArray())
                    {
                        roleAssignmentList.Add(new SynapseRoleAssignment(
                            item.GetProperty("id").ToString(),
                            new SynapseRoleAssignmentProperties(
                                item.GetProperty("principalId").ToString(),
                                item.GetProperty("roleDefinitionId").ToString(),
                                item.GetProperty("scope").ToString())));
                    }

                    return Page.FromValues(roleAssignmentList, null, response);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (null));
        }

        // TODO: do not use roleScope ?
        // GetRoleDefinitionById(string roleDefinitionId, RequestOptions options = null)
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Response<SynapseRoleDefinition> GetRoleDefinition(SynapseRoleScope roleScope, Guid roleDefinitionName)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinition)}");
            scope.Start();
            try
            {
                var response = GetRoleDefinitionById(roleDefinitionName.ToString());

                JsonDocument roleDefinitionJson = JsonDocument.Parse(response.Content.ToMemory());
                List<SynapsePermission> permissions = new List<SynapsePermission>();
                foreach (var permissionsItem in roleDefinitionJson.RootElement.GetProperty("permissions").EnumerateArray())
                {
                    List<string> actions = new List<string>();
                    List<string> notActions = new List<string>();
                    List<string> dataActions = new List<string>();
                    List<string> notDataActions = new List<string>();
                    foreach (var actionsItem in permissionsItem.GetProperty("actions").EnumerateArray())
                    {
                        actions.Add(actionsItem.GetString());
                    }
                    foreach (var notActionsItem in permissionsItem.GetProperty("notActions").EnumerateArray())
                    {
                        notActions.Add(notActionsItem.GetString());
                    }
                    foreach (var dataActionsItem in permissionsItem.GetProperty("dataActions").EnumerateArray())
                    {
                        dataActions.Add(dataActionsItem.GetString());
                    }
                    foreach (var notDataActionsItem in permissionsItem.GetProperty("notDataActions").EnumerateArray())
                    {
                        notDataActions.Add(notDataActionsItem.GetString());
                    }
                    permissions.Add(new SynapsePermission(actions, notActions, dataActions, notDataActions));
                }
                List<SynapseRoleScope> scopes = new List<SynapseRoleScope>();
                foreach (var scopesItem in roleDefinitionJson.RootElement.GetProperty("scopes").EnumerateArray())
                {
                    scopes.Add(scopesItem.GetString());
                }

                return Response.FromValue(new SynapseRoleDefinition(
                    roleDefinitionJson.RootElement.GetProperty("id").ToString(),
                    roleDefinitionJson.RootElement.GetProperty("name").ToString(),
                    roleDefinitionJson.RootElement.GetProperty("description").ToString(),
                    permissions,
                    scopes),
                    response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual async Task<Response<SynapseRoleDefinition>> GetRoleDefinitionAsync(SynapseRoleScope roleScope, Guid roleDefinitionName)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinition)}");
            scope.Start();
            try
            {
                var response = await GetRoleDefinitionByIdAsync(roleDefinitionName.ToString()).ConfigureAwait(false);

                JsonDocument roleDefinitionJson = await JsonDocument.ParseAsync(response.ContentStream, default).ConfigureAwait(false);
                List<SynapsePermission> permissions = new List<SynapsePermission>();
                foreach (var permissionsItem in roleDefinitionJson.RootElement.GetProperty("permissions").EnumerateArray())
                {
                    List<string> actions = new List<string>();
                    List<string> notActions = new List<string>();
                    List<string> dataActions = new List<string>();
                    List<string> notDataActions = new List<string>();
                    foreach (var actionsItem in permissionsItem.GetProperty("actions").EnumerateArray())
                    {
                        actions.Add(actionsItem.GetString());
                    }
                    foreach (var notActionsItem in permissionsItem.GetProperty("notActions").EnumerateArray())
                    {
                        notActions.Add(notActionsItem.GetString());
                    }
                    foreach (var dataActionsItem in permissionsItem.GetProperty("dataActions").EnumerateArray())
                    {
                        dataActions.Add(dataActionsItem.GetString());
                    }
                    foreach (var notDataActionsItem in permissionsItem.GetProperty("notDataActions").EnumerateArray())
                    {
                        notDataActions.Add(notDataActionsItem.GetString());
                    }
                    permissions.Add(new SynapsePermission(actions, notActions, dataActions, notDataActions));
                }
                List<SynapseRoleScope> scopes = new List<SynapseRoleScope>();
                foreach (var scopesItem in roleDefinitionJson.RootElement.GetProperty("scopes").EnumerateArray())
                {
                    scopes.Add(scopesItem.GetString());
                }

                return Response.FromValue(new SynapseRoleDefinition(
                    roleDefinitionJson.RootElement.GetProperty("id").ToString(),
                    roleDefinitionJson.RootElement.GetProperty("name").ToString(),
                    roleDefinitionJson.RootElement.GetProperty("description").ToString(),
                    permissions,
                    scopes),
                    response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // TODO: change return type from list to pageable
#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual Pageable<SynapseRoleDefinition> GetRoleDefinitions(SynapseRoleScope roleScope)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = ListRoleDefinitions(scope: roleScope.ToString());

                    JsonDocument roleDefinitionListJson = JsonDocument.Parse(response.Content.ToMemory());
                    List<SynapseRoleDefinition> roleDefinitionList = new List<SynapseRoleDefinition>();
                    foreach (var item in roleDefinitionListJson.RootElement.EnumerateArray())
                    {
                        List<SynapsePermission> permissions = new List<SynapsePermission>();
                        foreach (var permissionsItem in item.GetProperty("permissions").EnumerateArray())
                        {
                            List<string> actions = new List<string>();
                            List<string> notActions = new List<string>();
                            List<string> dataActions = new List<string>();
                            List<string> notDataActions = new List<string>();
                            foreach (var actionsItem in permissionsItem.GetProperty("actions").EnumerateArray())
                            {
                                actions.Add(actionsItem.GetString());
                            }
                            foreach (var notActionsItem in permissionsItem.GetProperty("notActions").EnumerateArray())
                            {
                                notActions.Add(notActionsItem.GetString());
                            }
                            foreach (var dataActionsItem in permissionsItem.GetProperty("dataActions").EnumerateArray())
                            {
                                dataActions.Add(dataActionsItem.GetString());
                            }
                            foreach (var notDataActionsItem in permissionsItem.GetProperty("notDataActions").EnumerateArray())
                            {
                                notDataActions.Add(notDataActionsItem.GetString());
                            }
                            permissions.Add(new SynapsePermission(actions, notActions, dataActions, notDataActions));
                        }
                        List<SynapseRoleScope> scopes = new List<SynapseRoleScope>();
                        foreach (var scopesItem in item.GetProperty("scopes").EnumerateArray())
                        {
                            scopes.Add(scopesItem.GetString());
                        }
                        roleDefinitionList.Add(new SynapseRoleDefinition(
                            item.GetProperty("id").ToString(),
                            item.GetProperty("name").ToString(),
                            item.GetProperty("description").ToString(),
                            permissions,
                            scopes
                            ));
                    }

                    return Page.FromValues(roleDefinitionList, null, response);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (null));
        }

#pragma warning disable AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        public virtual AsyncPageable<SynapseRoleDefinition> GetRoleDefinitionsAsync(SynapseRoleScope roleScope)
#pragma warning restore AZC0002 // DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = await ListRoleDefinitionsAsync(scope: roleScope.ToString()).ConfigureAwait(false);

                    JsonDocument roleDefinitionListJson = await JsonDocument.ParseAsync(response.ContentStream, default).ConfigureAwait(false);
                    List<SynapseRoleDefinition> roleDefinitionList = new List<SynapseRoleDefinition>();
                    foreach (var item in roleDefinitionListJson.RootElement.EnumerateArray())
                    {
                        List<SynapsePermission> permissions = new List<SynapsePermission>();
                        foreach (var permissionsItem in item.GetProperty("permissions").EnumerateArray())
                        {
                            List<string> actions = new List<string>();
                            List<string> notActions = new List<string>();
                            List<string> dataActions = new List<string>();
                            List<string> notDataActions = new List<string>();
                            foreach (var actionsItem in permissionsItem.GetProperty("actions").EnumerateArray())
                            {
                                actions.Add(actionsItem.GetString());
                            }
                            foreach (var notActionsItem in permissionsItem.GetProperty("notActions").EnumerateArray())
                            {
                                notActions.Add(notActionsItem.GetString());
                            }
                            foreach (var dataActionsItem in permissionsItem.GetProperty("dataActions").EnumerateArray())
                            {
                                dataActions.Add(dataActionsItem.GetString());
                            }
                            foreach (var notDataActionsItem in permissionsItem.GetProperty("notDataActions").EnumerateArray())
                            {
                                notDataActions.Add(notDataActionsItem.GetString());
                            }
                            permissions.Add(new SynapsePermission(actions, notActions, dataActions, notDataActions));
                        }
                        List<SynapseRoleScope> scopes = new List<SynapseRoleScope>();
                        foreach (var scopesItem in item.GetProperty("scopes").EnumerateArray())
                        {
                            scopes.Add(scopesItem.GetString());
                        }
                        roleDefinitionList.Add(new SynapseRoleDefinition(
                            item.GetProperty("id").ToString(),
                            item.GetProperty("name").ToString(),
                            item.GetProperty("description").ToString(),
                            permissions,
                            scopes
                            ));
                    }

                    return Page.FromValues(roleDefinitionList, null, response);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }, (null));
        }

        // TODO: don't have related APIs in Synaspe
        //public virtual Response<KeyVaultRoleDefinition> CreateOrUpdateRoleDefinition(KeyVaultRoleScope roleScope, Guid? roleDefinitionName = null, CancellationToken cancellationToken = default);
        //public virtual Response<KeyVaultRoleDefinition> CreateOrUpdateRoleDefinition(CreateOrUpdateRoleDefinitionOptions options, CancellationToken cancellationToken = default);
        //public virtual Task<Response<KeyVaultRoleDefinition>> CreateOrUpdateRoleDefinitionAsync(KeyVaultRoleScope roleScope, Guid? roleDefinitionName = null, CancellationToken cancellationToken = default);
        //public virtual Task<Response<KeyVaultRoleDefinition>> CreateOrUpdateRoleDefinitionAsync(CreateOrUpdateRoleDefinitionOptions options, CancellationToken cancellationToken = default);
        //public virtual Response DeleteRoleDefinition(KeyVaultRoleScope roleScope, Guid roleDefinitionName, CancellationToken cancellationToken = default);
        //public virtual Task<Response> DeleteRoleDefinitionAsync(KeyVaultRoleScope roleScope, Guid roleDefinitionName, CancellationToken cancellationToken = default);
    }
}
