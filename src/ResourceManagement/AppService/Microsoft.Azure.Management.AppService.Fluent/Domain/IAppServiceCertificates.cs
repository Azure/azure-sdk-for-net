// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using AppServiceCertificate.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point for certificate management API.
    /// </summary>
    public interface IAppServiceCertificates  :
        ISupportsCreating<AppServiceCertificate.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>,
        ISupportsGettingById<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>,
        ISupportsDeletingByGroup
    {
    }
}