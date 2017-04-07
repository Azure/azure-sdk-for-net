// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An app service certificate definition allowing region to be set.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// An app service certificate definition allowing PFX certificate file to be set.
    /// </summary>
    public interface IWithCertificate 
    {
        /// <summary>
        /// Specifies the PFX certificate file to upload.
        /// </summary>
        /// <param name="file">The PFX certificate file.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithPfxFilePassword WithPfxFile(string file);

        /// <summary>
        /// Specifies the PFX file from a URL.
        /// </summary>
        /// <param name="url">The URL pointing to the PFX file.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithPfxFilePassword WithPfxFileFromUrl(string url);

        /// <summary>
        /// Specifies the app service certificate.
        /// </summary>
        /// <param name="certificateOrder">The app service certificate order.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithCreate WithExistingCertificateOrder(IAppServiceCertificateOrder certificateOrder);

        /// <summary>
        /// Specifies the PFX byte array to upload.
        /// </summary>
        /// <param name="pfxByteArray">The PFX byte array.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithPfxFilePassword WithPfxByteArray(params byte[] pfxByteArray);
    }

    /// <summary>
    /// An app service certificate definition allowing resource group to be set.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithCertificate>
    {
    }

    /// <summary>
    /// An app service certificate definition with sufficient inputs to create a new
    /// app service certificate in the cloud, but exposing additional optional inputs to
    /// specify.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificate>
    {
    }

    /// <summary>
    /// An app service certificate definition allowing PFX certificate password to be set.
    /// </summary>
    public interface IWithPfxFilePassword 
    {
        /// <summary>
        /// Specifies the password to the PFX certificate.
        /// </summary>
        /// <param name="password">The PFX certificate password.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithCreate WithPfxPassword(string password);
    }

    /// <summary>
    /// Container interface for all the definitions that need to be implemented.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IBlank,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithGroup,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithCertificate,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithPfxFilePassword,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificate.Definition.IWithCreate
    {
    }
}