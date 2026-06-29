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
    public partial class MockableAppServiceTenantResource
    {
        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<FunctionAppStack> GetFunctionAppStacksForLocationProvidersAsync(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetFunctionAppStacksForLocationProvidersAsync(location.ToString(), stackOsType, cancellationToken);

        /// <summary> Description for Get available Function app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<FunctionAppStack> GetFunctionAppStacksForLocationProviders(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetFunctionAppStacksForLocationProviders(location.ToString(), stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<WebAppStack> GetWebAppStacksByLocationAsync(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetWebAppStacksByLocationAsync(location.ToString(), stackOsType, cancellationToken);

        /// <summary> Description for Get available Web app frameworks and their versions for location. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<WebAppStack> GetWebAppStacksByLocation(AzureLocation location, ProviderStackOSType? stackOsType = default, CancellationToken cancellationToken = default)
            => GetWebAppStacksByLocation(location.ToString(), stackOsType, cancellationToken);

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
