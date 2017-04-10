// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Update
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// An app service certificate order definition allowing auto-renew settings to be set.
    /// </summary>
    public interface IWithAutoRenew 
    {
        /// <summary>
        /// Specifies if the certificate should be auto-renewed.
        /// </summary>
        /// <param name="enabled">True if the certificate order should be auto-renewed.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Update.IUpdate WithAutoRenew(bool enabled);
    }

    /// <summary>
    /// The template for an app service certificate order update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.AppService.Fluent.IAppServiceCertificateOrder>,
        Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Update.IWithAutoRenew,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.AppService.Fluent.AppServiceCertificateOrder.Update.IUpdate>
    {
    }
}