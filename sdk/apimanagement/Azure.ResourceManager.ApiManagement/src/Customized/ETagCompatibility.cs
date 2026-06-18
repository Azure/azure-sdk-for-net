// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

namespace Azure.ResourceManager.ApiManagement
{
    // The old AutoRest SDK exposed many If-Match parameters as Azure.ETag/Azure.ETag?.
    // MPG currently generates these inline @header("If-Match") parameters as string.
    // We tried C#-scoped @@alternateType on the escaped inline TypeSpec parameter, but
    // the emitter rejects all usable references (`If-Match`, ifMatch, IfMatch).
    // These overloads preserve only signatures currently reported by ApiCompat and
    // forward to the generated string-based overloads.
    public partial class ApiDiagnosticResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiDiagnosticResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiGatewayConfigConnectionResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiIssueAttachmentResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiIssueCommentResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiIssueResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiIssueResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiIssuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementAuthorizationServerResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementAuthorizationServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementAuthorizationServerResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementAuthorizationServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementBackendResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementBackendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementBackendResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementBackendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementCacheResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementCachePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementCacheResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementCachePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementCertificateResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiManagementDiagnosticResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementDiagnosticResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.DiagnosticContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiManagementEmailTemplateResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementEmailTemplateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), content, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementEmailTemplateResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementEmailTemplateCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), content, cancellationToken);
    }

    public partial class ApiManagementGatewayCertificateAuthorityResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiManagementGatewayHostnameConfigurationResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiManagementGatewayResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGatewayResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementGatewayData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiManagementGlobalSchemaResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiManagementGroupResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementGroupResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementIdentityProviderResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementIdentityProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementIdentityProviderResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementIdentityProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementLoggerResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementLoggerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementLoggerResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementLoggerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementNamedValueResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource> Update(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(waitUntil, ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementNamedValueResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(waitUntil, ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementOpenIdConnectProviderResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementOpenIdConnectProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementOpenIdConnectProviderResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementOpenIdConnectProviderPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiManagementPortalDelegationSettingResource
    {
        /// <inheritdoc />
        public virtual Azure.Response Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalDelegationSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiManagementPortalRevisionResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource> Update(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(waitUntil, ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalRevisionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(waitUntil, ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiManagementPortalSignInSettingResource
    {
        /// <inheritdoc />
        public virtual Azure.Response Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignInSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiManagementPortalSignUpSettingResource
    {
        /// <inheritdoc />
        public virtual Azure.Response Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiManagementPortalSignUpSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiManagementProductPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiManagementProductResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), deleteSubscriptions, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), deleteSubscriptions, cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementProductResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiManagementSubscriptionResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, notify, appType, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementSubscriptionResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, notify, appType, cancellationToken);
    }

    public partial class ApiManagementTagResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), content, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementTagResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), content, cancellationToken);
    }

    public partial class ApiManagementUserResource
    {
        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiManagementUserResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), deleteSubscriptions, notify, appType, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), deleteSubscriptions, notify, appType, cancellationToken);
    }

    public partial class ApiOperationPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiOperationResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiOperationResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiReleaseResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiReleaseResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ApiResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), deleteRevisions, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), deleteRevisions, cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ApiSchemaResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), force, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), force, cancellationToken);
    }

    public partial class ApiTagDescriptionResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ApiVersionSetResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ApiVersionSetResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class AuthorizationAccessPolicyContractResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class AuthorizationContractResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class AuthorizationProviderContractResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class DocumentationContractResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.DocumentationContractResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.DocumentationContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.DocumentationContractResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.DocumentationContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class PolicyFragmentContractResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class PolicyRestrictionContractResource
    {
        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PolicyRestrictionContractResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.PolicyRestrictionContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PolicyRestrictionContractResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.PolicyRestrictionContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class PortalConfigContractCollection
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalConfigContractResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string portalConfigId, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.PortalConfigContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => CreateOrUpdate(waitUntil, portalConfigId, ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.PortalConfigContractResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string portalConfigId, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.PortalConfigContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => CreateOrUpdateAsync(waitUntil, portalConfigId, ifMatch.ToString(), data, cancellationToken);
    }

    public partial class PortalConfigContractResource
    {
        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.PortalConfigContractResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.PortalConfigContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.PortalConfigContractResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.PortalConfigContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ResolverContractResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ResolverContractResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ResolverContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ResolverContractResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ResolverContractPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceApiResolverPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceApiWikiResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiWikiResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.WikiUpdateContract wikiUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), wikiUpdateContract, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceApiWikiResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.WikiUpdateContract wikiUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), wikiUpdateContract, cancellationToken);
    }

    public partial class ServiceProductWikiResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductWikiResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.WikiUpdateContract wikiUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), wikiUpdateContract, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceProductWikiResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.WikiUpdateContract wikiUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), wikiUpdateContract, cancellationToken);
    }

    public partial class ServiceWorkspaceApiDiagnosticResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiDiagnosticResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.DiagnosticUpdateContract diagnosticUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), diagnosticUpdateContract, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiDiagnosticResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.DiagnosticUpdateContract diagnosticUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), diagnosticUpdateContract, cancellationToken);
    }

    public partial class ServiceWorkspaceApiOperationPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceWorkspaceApiOperationResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiOperationResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiOperationResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiOperationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspaceApiPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceWorkspaceApiReleaseResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiReleaseResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiReleaseResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.ApiReleaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }

    public partial class ServiceWorkspaceApiResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), deleteRevisions, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteRevisions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), deleteRevisions, cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspaceApiSchemaResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), force, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), force, cancellationToken);
    }

    public partial class ServiceWorkspaceApiVersionSetResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiVersionSetResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceApiVersionSetResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiVersionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspaceBackendResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceBackendResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementBackendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceBackendResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementBackendPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspaceCertificateResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceWorkspaceDiagnosticResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceDiagnosticResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.DiagnosticUpdateContract diagnosticUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), diagnosticUpdateContract, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceDiagnosticResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.DiagnosticUpdateContract diagnosticUpdateContract, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), diagnosticUpdateContract, cancellationToken);
    }

    public partial class ServiceWorkspaceGroupResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceGroupResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceGroupResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspaceLoggerResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceLoggerResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementLoggerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceLoggerResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementLoggerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspaceNamedValueResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceWorkspaceNamedValueResource> Update(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(waitUntil, ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.ServiceWorkspaceNamedValueResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementNamedValuePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(waitUntil, ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspacePolicyFragmentResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceWorkspacePolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceWorkspaceProductPolicyResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceWorkspaceProductResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), deleteSubscriptions, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, bool? deleteSubscriptions = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), deleteSubscriptions, cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceProductResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceProductResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementProductPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class ServiceWorkspaceSchemaResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);
    }

    public partial class ServiceWorkspaceSubscriptionResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceSubscriptionResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, notify, appType, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceSubscriptionResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementSubscriptionPatch patch, bool? notify = default(bool?), Azure.ResourceManager.ApiManagement.Models.AppType? appType = default(Azure.ResourceManager.ApiManagement.Models.AppType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, notify, appType, cancellationToken);
    }

    public partial class ServiceWorkspaceTagResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceTagResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), content, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.ServiceWorkspaceTagResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.ApiManagementTagCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), content, cancellationToken);
    }

    public partial class TenantAccessInfoCollection
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.AccessName accessName, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => CreateOrUpdate(waitUntil, accessName, ifMatch.ToString(), content, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ApiManagement.Models.AccessName accessName, Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => CreateOrUpdateAsync(waitUntil, accessName, ifMatch.ToString(), content, cancellationToken);
    }

    public partial class TenantAccessInfoResource
    {
        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), patch, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.TenantAccessInfoResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.Models.TenantAccessInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), patch, cancellationToken);
    }

    public partial class WorkspaceContractResource
    {
        /// <inheritdoc />
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Delete(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => DeleteAsync(waitUntil, ifMatch.ToString(), cancellationToken);

        /// <inheritdoc />
        public virtual Azure.Response<Azure.ResourceManager.ApiManagement.WorkspaceContractResource> Update(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.WorkspaceContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => Update(ifMatch.ToString(), data, cancellationToken);

        /// <inheritdoc />
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ApiManagement.WorkspaceContractResource>> UpdateAsync(Azure.ETag ifMatch, Azure.ResourceManager.ApiManagement.WorkspaceContractData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            => UpdateAsync(ifMatch.ToString(), data, cancellationToken);
    }
}
