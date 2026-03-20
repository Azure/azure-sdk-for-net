// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ApiManagement;

namespace Azure.Provisioning.Generator.Specifications;

public class ApiManagementSpecification() :
    Specification("ApiManagement", typeof(ApiManagementExtensions), serviceDirectory: "apimanagement", ignorePropertiesWithoutPath: true)
{
    protected override void Customize()
    {
        // Rename to avoid AZC0012: type name 'Api' is too generic
        CustomizeModel<ApiResource>(m => m.Name = "ApiManagementApi");

        // Fix readonly Name on child resources.
        // The ARM API uses parameter names like apiId, backendId, etc.
        // instead of names ending in "Name", so the generator cannot
        // auto-detect them. The TypeSpec provisioning generator will
        // resolve this systematically.
        CustomizeProperty<ApiDiagnosticResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiIssueResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiIssueAttachmentResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiIssueCommentResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementAuthorizationServerResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementBackendResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementCacheResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementCertificateResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementDiagnosticResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementGatewayResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementGatewayCertificateAuthorityResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementGatewayHostnameConfigurationResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementGlobalSchemaResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementGroupResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementLoggerResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementNamedValueResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementOpenIdConnectProviderResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementPortalDelegationSettingResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementPortalRevisionResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementPortalSignInSettingResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementPortalSignUpSettingResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementProductResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementProductPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementProductTagResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementSubscriptionResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementTagResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiManagementUserResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiOperationResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiOperationPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiOperationTagResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiReleaseResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiSchemaResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiTagResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiTagDescriptionResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ApiVersionSetResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<AuthorizationAccessPolicyContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<AuthorizationContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<AuthorizationProviderContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<DocumentationContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<PolicyFragmentContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<PolicyRestrictionContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<PortalConfigContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ResolverContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceApiResolverPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceApiWikiResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceProductApiLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceProductGroupLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceProductWikiResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceTagApiLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceTagOperationLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceTagProductLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiDiagnosticResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiOperationResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiOperationPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiReleaseResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiSchemaResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceApiVersionSetResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceBackendResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceCertificateResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceDiagnosticResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceGroupResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceLoggerResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceNamedValueResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspacePolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspacePolicyFragmentResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceProductResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceProductApiLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceProductGroupLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceProductPolicyResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceSchemaResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceSubscriptionResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceTagResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceTagApiLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceTagOperationLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<ServiceWorkspaceTagProductLinkResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
        CustomizeProperty<WorkspaceContractResource>("Name", p => { p.IsReadOnly = false; p.IsRequired = true; });
    }
}
