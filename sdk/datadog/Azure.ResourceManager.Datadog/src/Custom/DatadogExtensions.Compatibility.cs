// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Datadog.Mocking;
using Azure.ResourceManager.Datadog.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Datadog
{
    [CodeGenSuppress("CreateOrUpdateMarketplaceAgreement", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdateMarketplaceAgreementAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    public static partial class DatadogExtensions
    {
        /// <summary> Create Datadog marketplace agreement in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<DatadogAgreement>> CreateOrUpdateMarketplaceAgreementAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableDatadogSubscriptionResource(subscriptionResource).CreateOrUpdateMarketplaceAgreementAsync(cancellationToken);

        /// <summary> Create Datadog marketplace agreement in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<DatadogAgreement> CreateOrUpdateMarketplaceAgreement(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableDatadogSubscriptionResource(subscriptionResource).CreateOrUpdateMarketplaceAgreement(cancellationToken);
    }
}
