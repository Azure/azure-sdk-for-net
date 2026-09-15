// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class CustomDnsSuffixConfigurationResource
    {
        /// <summary> Delete Custom Dns Suffix configuration of an App Service Environment. </summary>
        public virtual Task<ArmOperation<BinaryData>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => AppServiceBinaryDataDeleteOperation.DeleteWithOriginalUriAsync(
                _customDnsSuffixConfigurationsClientDiagnostics,
                Pipeline,
                context => _customDnsSuffixConfigurationsRestClient.CreateDeleteAseCustomDnsSuffixConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context),
                "CustomDnsSuffixConfigurationResource.Delete",
                waitUntil,
                cancellationToken);

        /// <summary> Delete Custom Dns Suffix configuration of an App Service Environment. </summary>
        public virtual ArmOperation<BinaryData> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => AppServiceBinaryDataDeleteOperation.DeleteWithOriginalUri(
                _customDnsSuffixConfigurationsClientDiagnostics,
                Pipeline,
                context => _customDnsSuffixConfigurationsRestClient.CreateDeleteAseCustomDnsSuffixConfigurationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, context),
                "CustomDnsSuffixConfigurationResource.Delete",
                waitUntil,
                cancellationToken);
    }
}
