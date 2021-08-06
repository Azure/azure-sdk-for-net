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
        //public virtual Pageable<SynapseRoleAssignment> ListRoleAssignments(string roleDefinitionId = null, string principalId = null, SynapseRoleScope? roleScope = null, string continuationToken = null, CancellationToken cancellationToken = default)
        //{
        //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(ListRoleAssignments)}");
        //    scope.Start();
        //    try
        //    {
        //        var response = ListRoleAssignments(
        //            roleId: roleDefinitionId,
        //            principalId: principalId,
        //            scope: roleScope.ToString(),
        //            continuationToken: continuationToken,
        //            options: new RequestOptions()
        //            {
        //                CancellationToken = cancellationToken
        //            });

        //        JsonElement roleAssignmentListJson = JsonDocument.Parse(response.Content.ToMemory()).RootElement.GetProperty("value");
        //        List<SynapseRoleAssignment> roleAssignmentsList = new List<SynapseRoleAssignment>();
        //        foreach (var item in roleAssignmentListJson.EnumerateArray())
        //        {
        //            roleAssignmentsList.Add(new SynapseRoleAssignment(
        //                item.GetProperty("id").GetString(),
        //                new SynapseRoleAssignmentProperties(
        //                    item.GetProperty("principalId").ToString(),
        //                    item.GetProperty("roleDefinitionId").ToString(),
        //                    item.GetProperty("scope").ToString())));
        //        }

        //        List<Page<SynapseRoleAssignment>> pagelist = new List<Page<SynapseRoleAssignment>>();
        //        pagelist.Add(Page.FromValues(roleAssignmentsList, continuationToken, response));
        //        return Pageable<SynapseRoleAssignment>.FromPages(pagelist);
        //    }
        //    catch (Exception ex)
        //    {
        //        scope.Failed(ex);
        //        throw;
        //    }
        //}

        //public virtual async Task<Pageable<SynapseRoleAssignment>> ListRoleAssignmentsAsync(string roleDefinitionId = null, string principalId = null, SynapseRoleScope? roleScope = null, string continuationToken = null, CancellationToken cancellationToken = default)
        //{
        //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SynapseAccessControlClient)}.{nameof(ListRoleAssignments)}");
        //    scope.Start();
        //    try
        //    {
        //        var response = await ListRoleAssignmentsAsync(
        //            roleId: roleDefinitionId,
        //            principalId: principalId,
        //            scope: roleScope.ToString(),
        //            continuationToken: continuationToken,
        //            options: new RequestOptions()
        //            {
        //                CancellationToken = cancellationToken
        //            }).ConfigureAwait(false);

        //        JsonDocument roleAssignmentListJson = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
        //        List<SynapseRoleAssignment> roleAssignmentsList = new List<SynapseRoleAssignment>();
        //        foreach (var item in roleAssignmentListJson.RootElement.GetProperty("value").EnumerateArray())
        //        {
        //            roleAssignmentsList.Add(new SynapseRoleAssignment(
        //                item.GetProperty("id").GetString(),
        //                new SynapseRoleAssignmentProperties(
        //                    item.GetProperty("principalId").ToString(),
        //                    item.GetProperty("roleDefinitionId").ToString(),
        //                    item.GetProperty("scope").ToString())));
        //        }

        //        List<Page<SynapseRoleAssignment>> pagelist = new List<Page<SynapseRoleAssignment>>();
        //        pagelist.Add(Page.FromValues(roleAssignmentsList, continuationToken, response));
        //        return Pageable<SynapseRoleAssignment>.FromPages(pagelist);
        //    }
        //    catch (Exception ex)
        //    {
        //        scope.Failed(ex);
        //        throw;
        //    }
        //}

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

        // TODO: Not used roleScope ?
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
    }
}
