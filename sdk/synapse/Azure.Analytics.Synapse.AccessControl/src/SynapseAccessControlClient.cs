// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class SynapseAccessControlClient
    {
        public virtual Response<SynapseRoleAssignment> CreateRoleAssignment(SynapseRoleScope roleScope, string roleDefinitionId, string principalId, Guid? roleAssignmentName = null, CancellationToken cancellationToken = default)
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
                        }),
                    new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    });

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

        public virtual async Task<Response<SynapseRoleAssignment>> CreateRoleAssignmentAsync(SynapseRoleScope roleScope, string roleDefinitionId, string principalId, Guid? roleAssignmentName = null, CancellationToken cancellationToken = default)
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
                        }),
                    new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    }).ConfigureAwait(false);

                JsonDocument roleAssignment = await JsonDocument.ParseAsync(createRoleAssignmentResponse.ContentStream, default, cancellationToken).ConfigureAwait(false);

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

        public virtual Response DeleteRoleAssignment(SynapseRoleScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(DeleteRoleAssignment)}");
            scope.Start();
            try
            {
                return DeleteRoleAssignmentById(
                    roleAssignmentName,
                    roleScope.ToString(),
                    new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        public virtual async Task<Response> DeleteRoleAssignmentAsync(SynapseRoleScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(DeleteRoleAssignment)}");
            scope.Start();
            try
            {
                return await DeleteRoleAssignmentByIdAsync(
                    roleAssignmentName,
                    roleScope.ToString(),
                    new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // TODO: do not use roleScope ?
        // GetRoleAssignmentById(string roleAssignmentId, RequestOptions options = null)
        public virtual Response<SynapseRoleAssignment> GetRoleAssignment(SynapseRoleScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleAssignment)}");
            scope.Start();
            try
            {
                Response roleAssignmentResponse = GetRoleAssignmentById(
                    roleAssignmentName,
                    new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    });

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

        public virtual async Task<Response<SynapseRoleAssignment>> GetRoleAssignmentAsync(SynapseRoleScope roleScope, string roleAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(roleAssignmentName, nameof(roleAssignmentName));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleAssignment)}");
            scope.Start();
            try
            {
                Response roleAssignmentResponse = await GetRoleAssignmentByIdAsync(
                    roleAssignmentName,
                    new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    }).ConfigureAwait(false);

                JsonDocument roleAssignment = await JsonDocument.ParseAsync(roleAssignmentResponse.ContentStream, default, cancellationToken).ConfigureAwait(false);

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
        public virtual Pageable<SynapseRoleAssignment> GetRoleAssignments(SynapseRoleScope? roleScope = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = ListRoleAssignments(
                        scope: roleScope.ToString(),
                        options: new RequestOptions()
                        {
                            CancellationToken = cancellationToken
                        });

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

        public virtual AsyncPageable<SynapseRoleAssignment> GetRoleAssignmentsAsync(SynapseRoleScope? roleScope = null, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(ListRoleAssignments)}");
                scope.Start();
                try
                {
                    var response = await ListRoleAssignmentsAsync(
                        scope: roleScope.ToString(),
                        options: new RequestOptions()
                        {
                            CancellationToken = cancellationToken
                        }).ConfigureAwait(false);

                    JsonDocument roleAssignmentListJson = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<SynapseRoleDefinition> GetRoleDefinition(SynapseRoleScope roleScope, Guid roleDefinitionName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinition)}");
            scope.Start();
            try
            {
                var response = GetRoleDefinitionById(
                    roleDefinitionName.ToString(),
                    options: new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    });

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

        public virtual async Task<Response<SynapseRoleDefinition>> GetRoleDefinitionAsync(SynapseRoleScope roleScope, Guid roleDefinitionName, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinition)}");
            scope.Start();
            try
            {
                var response = await GetRoleDefinitionByIdAsync(
                    roleDefinitionName.ToString(),
                    options: new RequestOptions()
                    {
                        CancellationToken = cancellationToken
                    }).ConfigureAwait(false);

                JsonDocument roleDefinitionJson = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
        public virtual Pageable<SynapseRoleDefinition> GetRoleDefinitions(SynapseRoleScope roleScope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateEnumerable(_ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = ListRoleDefinitions(
                        scope: roleScope.ToString(),
                        options: new RequestOptions()
                        {
                            CancellationToken = cancellationToken
                        });

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

        public virtual AsyncPageable<SynapseRoleDefinition> GetRoleDefinitionsAsync(SynapseRoleScope roleScope, CancellationToken cancellationToken = default)
        {
            return PageableHelpers.CreateAsyncEnumerable(async _ =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(GetRoleDefinitions)}");
                scope.Start();
                try
                {
                    var response = await ListRoleDefinitionsAsync(
                        scope: roleScope.ToString(),
                        options: new RequestOptions()
                        {
                            CancellationToken = cancellationToken
                        }).ConfigureAwait(false);

                    JsonDocument roleDefinitionListJson = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
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
