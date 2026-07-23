// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService.Mocking
{
    // ROOT CAUSE: After the spec switched the by-location stack ops to LocationResourceParameter,
    // the generator no longer emits per-tenant stack-by-location helpers
    // (GetFunctionAppStacksForLocationProviders, GetWebAppStacksByLocation). The shims below
    // restore those methods by calling the still-generated ProviderOperationGroup REST client
    // directly.
    //
    // The Provider_ListOperations method was dropped from the latest spec API version; keep
    // [Obsolete] [EditorBrowsable(Never)] stubs that throw NotSupportedException so existing GA
    // callers do not lose binary compatibility but are clearly informed at runtime.
    public partial class MockableAppServiceTenantResource
    {
        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<FunctionAppStack> GetFunctionAppStacksForLocationProvidersAsync(AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new CompatGetFunctionAppStacksForLocationAsyncCollectionResultOfT(
                ProviderOperationGroupRestClient,
                location,
                stackOsType?.ToString(),
                context,
                "MockableAppServiceTenantResource.GetFunctionAppStacksForLocationProviders");
        }

        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<FunctionAppStack> GetFunctionAppStacksForLocationProviders(AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new CompatGetFunctionAppStacksForLocationCollectionResultOfT(
                ProviderOperationGroupRestClient,
                location,
                stackOsType?.ToString(),
                context,
                "MockableAppServiceTenantResource.GetFunctionAppStacksForLocationProviders");
        }

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<WebAppStack> GetWebAppStacksByLocationAsync(AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new CompatGetWebAppStacksByLocationAsyncCollectionResultOfT(
                ProviderOperationGroupRestClient,
                location,
                stackOsType?.ToString(),
                context,
                "MockableAppServiceTenantResource.GetWebAppStacksByLocation");
        }

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<WebAppStack> GetWebAppStacksByLocation(AzureLocation location, ProviderStackOSType? stackOsType = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new CompatGetWebAppStacksByLocationCollectionResultOfT(
                ProviderOperationGroupRestClient,
                location,
                stackOsType?.ToString(),
                context,
                "MockableAppServiceTenantResource.GetWebAppStacksByLocation");
        }

        /// <summary> Description for Gets all available operations for the Microsoft.Web resource provider. Also exposes resource metric definitions. NOTE: The underlying REST operation is no longer surfaced by the new generator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. The underlying REST operation 'Provider_ListOperations' was removed in the latest API version.", false)]
        public virtual AsyncPageable<CsmOperationDescription> GetOperationsProvidersAsync(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Provider_ListOperations is no longer exposed by the App Service REST API.");

        /// <summary> Description for Gets all available operations for the Microsoft.Web resource provider. NOTE: The underlying REST operation is no longer surfaced by the new generator. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is no longer supported. The underlying REST operation 'Provider_ListOperations' was removed in the latest API version.", false)]
        public virtual Pageable<CsmOperationDescription> GetOperationsProviders(CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Provider_ListOperations is no longer exposed by the App Service REST API.");
    }
}
