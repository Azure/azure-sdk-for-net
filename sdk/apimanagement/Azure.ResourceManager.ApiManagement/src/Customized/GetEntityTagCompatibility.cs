// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ApiManagement
{
    // MPG currently exposes HEAD/check-existence operations as collection Exists/ExistsAsync methods
    // instead of the resource-level GetEntityTag/GetEntityTagAsync methods that AutoRest exposed.
    // These partials preserve the old public API surface until the generator supports that shape directly.
    internal static class GetEntityTagCompatibility
    {
        internal static async Task<Response<bool>> SendHeadAsync(ClientDiagnostics diagnostics, HttpPipeline pipeline, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                await pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                return ToExistsResponse(message.Response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        internal static Response<bool> SendHead(ClientDiagnostics diagnostics, HttpPipeline pipeline, string scopeName, Func<RequestContext, HttpMessage> createMessage, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = diagnostics.CreateScope(scopeName);
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = createMessage(context);
                pipeline.Send(message, context.CancellationToken);
                return ToExistsResponse(message.Response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        internal static Response<bool> ToExistsResponse(Response response)
        {
            return response.Status switch
            {
                200 => Response.FromValue(true, response),
                204 => Response.FromValue(true, response),
                404 => Response.FromValue(false, response),
                _ => throw new RequestFailedException(response)
            };
        }
    }

    public partial class ApiDiagnosticResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiDiagnosticCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiDiagnosticCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiIssueAttachmentResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiIssueAttachmentCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiIssueAttachmentCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiIssueCommentResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiIssueCommentCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiIssueCommentCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiIssueResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiIssueCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiIssueCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementAuthorizationServerResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementAuthorizationServerCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementAuthorizationServerCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementBackendResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementBackendCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementBackendCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementCacheResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementCacheCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementCacheCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementCertificateResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementCertificateCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementCertificateCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementDiagnosticResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementDiagnosticCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementDiagnosticCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementEmailTemplateResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementEmailTemplateCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementEmailTemplateCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementGatewayCertificateAuthorityResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementGatewayCertificateAuthorityCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementGatewayCertificateAuthorityCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementGatewayHostnameConfigurationResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementGatewayHostnameConfigurationCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementGatewayHostnameConfigurationCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementGatewayResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementGatewayCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementGatewayCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementGlobalSchemaResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementGlobalSchemaCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementGlobalSchemaCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementGroupResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementGroupCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementGroupCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementIdentityProviderResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementIdentityProviderCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementIdentityProviderCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementLoggerResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementLoggerCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementLoggerCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementNamedValueResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementNamedValueCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementNamedValueCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementOpenIdConnectProviderResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementOpenIdConnectProviderCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementOpenIdConnectProviderCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementPortalRevisionResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementPortalRevisionCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementPortalRevisionCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementProductPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementProductPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementProductPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementProductResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementProductCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementProductCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementSubscriptionResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementSubscriptionCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementSubscriptionCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementUserResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiManagementUserCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiManagementUserCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiOperationPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiOperationPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiOperationPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiOperationResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiOperationCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiOperationCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiReleaseResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiReleaseCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiReleaseCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiSchemaResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiSchemaCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiSchemaCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiTagDescriptionResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiTagDescriptionCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiTagDescriptionCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiVersionSetResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ApiVersionSetCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ApiVersionSetCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class DocumentationContractResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new DocumentationContractCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new DocumentationContractCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class PolicyFragmentContractResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new PolicyFragmentContractCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new PolicyFragmentContractCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class PolicyRestrictionContractResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new PolicyRestrictionContractCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new PolicyRestrictionContractCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class PortalConfigContractResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new PortalConfigContractCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new PortalConfigContractCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ResolverContractResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ResolverContractCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ResolverContractCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceApiResolverPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceApiResolverPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceApiResolverPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiDiagnosticResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiDiagnosticCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiDiagnosticCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiOperationPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiOperationPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiOperationPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiOperationResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiOperationCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiOperationCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiReleaseResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiReleaseCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiReleaseCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiSchemaResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiSchemaCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiSchemaCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceApiVersionSetResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceApiVersionSetCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceApiVersionSetCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceBackendResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceBackendCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceBackendCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceCertificateResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceCertificateCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceCertificateCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceDiagnosticResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceDiagnosticCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceDiagnosticCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceGroupResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceGroupCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceGroupCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceLoggerResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceLoggerCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceLoggerCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceNamedValueResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceNamedValueCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceNamedValueCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspacePolicyFragmentResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspacePolicyFragmentCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspacePolicyFragmentCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspacePolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspacePolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspacePolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceProductPolicyResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceProductPolicyCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceProductPolicyCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceProductResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceProductCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceProductCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceSchemaResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceSchemaCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceSchemaCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ServiceWorkspaceSubscriptionResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new ServiceWorkspaceSubscriptionCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new ServiceWorkspaceSubscriptionCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class TenantAccessInfoResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new TenantAccessInfoCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new TenantAccessInfoCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class WorkspaceContractResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await new WorkspaceContractCollection(Client, Id.Parent).ExistsAsync(Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => new WorkspaceContractCollection(Client, Id.Parent).Exists(Id.Name, cancellationToken: cancellationToken);
    }

    public partial class ApiManagementPortalDelegationSettingResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await GetEntityTagCompatibility.SendHeadAsync(_delegationSettingsClientDiagnostics, Pipeline, "ApiManagementPortalDelegationSettingResource.GetEntityTag", context => _delegationSettingsRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => GetEntityTagCompatibility.SendHead(_delegationSettingsClientDiagnostics, Pipeline, "ApiManagementPortalDelegationSettingResource.GetEntityTag", context => _delegationSettingsRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context), cancellationToken);
    }

    public partial class ApiManagementPortalSignInSettingResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await GetEntityTagCompatibility.SendHeadAsync(_signInSettingsClientDiagnostics, Pipeline, "ApiManagementPortalSignInSettingResource.GetEntityTag", context => _signInSettingsRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => GetEntityTagCompatibility.SendHead(_signInSettingsClientDiagnostics, Pipeline, "ApiManagementPortalSignInSettingResource.GetEntityTag", context => _signInSettingsRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context), cancellationToken);
    }

    public partial class ApiManagementPortalSignUpSettingResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await GetEntityTagCompatibility.SendHeadAsync(_signUpSettingsClientDiagnostics, Pipeline, "ApiManagementPortalSignUpSettingResource.GetEntityTag", context => _signUpSettingsRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => GetEntityTagCompatibility.SendHead(_signUpSettingsClientDiagnostics, Pipeline, "ApiManagementPortalSignUpSettingResource.GetEntityTag", context => _signUpSettingsRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context), cancellationToken);
    }

    public partial class ServiceApiWikiResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await GetEntityTagCompatibility.SendHeadAsync(_apiWikiClientDiagnostics, Pipeline, "ServiceApiWikiResource.GetEntityTag", context => _apiWikiRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, context), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => GetEntityTagCompatibility.SendHead(_apiWikiClientDiagnostics, Pipeline, "ServiceApiWikiResource.GetEntityTag", context => _apiWikiRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, context), cancellationToken);
    }

    public partial class ServiceProductWikiResource
    {
        /// <inheritdoc />
        public virtual async Task<Response<bool>> GetEntityTagAsync(CancellationToken cancellationToken = default)
            => await GetEntityTagCompatibility.SendHeadAsync(_productWikiClientDiagnostics, Pipeline, "ServiceProductWikiResource.GetEntityTag", context => _productWikiRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, context), cancellationToken).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual Response<bool> GetEntityTag(CancellationToken cancellationToken = default)
            => GetEntityTagCompatibility.SendHead(_productWikiClientDiagnostics, Pipeline, "ServiceProductWikiResource.GetEntityTag", context => _productWikiRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, context), cancellationToken);
    }
}
