// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

//This file is needed because we had to turn off the post processor which makes a bunch of types public.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("ArmIdWrapper")]
[assembly: CodeGenSuppressType("AppServiceGithubToken")]
[assembly: CodeGenSuppressType("AppServiceResource")]
[assembly: CodeGenSuppressType("AppserviceGithubTokenRequest")]
[assembly: CodeGenSuppressType("CsmMoveResourceEnvelope")]
[assembly: CodeGenSuppressType("DefaultErrorResponse")]
[assembly: CodeGenSuppressType("DefaultErrorResponseError")]
[assembly: CodeGenSuppressType("DefaultErrorResponseErrorDetailsItem")]
[assembly: CodeGenSuppressType("ExtendedLocation")]
[assembly: CodeGenSuppressType("ManagedServiceIdentity")]
[assembly: CodeGenSuppressType("ManagedServiceIdentityTypeExtensions")]
[assembly: CodeGenSuppressType("ProxyOnlyResource")]
[assembly: CodeGenSuppressType("StaticSiteUserProvidedFunctionAppProperties")]
[assembly: CodeGenSuppressType("UserAssignedIdentity")]
[assembly: CodeGenSuppressType("ManagedServiceIdentityType")]
[assembly: CodeGenSuppressType("ArmAppServiceModelFactory")]

namespace Azure.ResourceManager.AppService.Models
{
#pragma warning disable SA1402 // File may only contain a single type
    internal partial class AllowedAudiencesValidation { }
    internal partial class ApiManagementConfig { }
    internal partial class AppServiceApiDefinitionInfo { }
    internal partial class AppServiceBlobStorageTokenStore { }
    internal partial class AppServiceHttpSettingsRoutes { }
    internal partial class AppServiceStaticWebAppsRegistration { }
    internal partial class CsmOperationDescriptionProperties { }
    internal partial class DetectorMetadata { }
    internal partial class FileSystemTokenStore { }
    internal partial class FrontEndConfiguration { }
    internal partial class LoginRoutes { }
    internal partial class LoginScopes { }
    internal partial class PrivateLinkResourcesWrapper { }
    internal partial class RoutingRuleExperiments { }
    internal partial class WebAppEnabledConfig { }
    internal partial class PrivateLinkResourcesWrapper { }
#pragma warning restore SA1402 // File may only contain a single type
}
