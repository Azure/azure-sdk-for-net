// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Confluent.Mocking;
using Azure.ResourceManager.Confluent.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Confluent
{
    [CodeGenSuppress("CreateMarketplaceAgreement", typeof(SubscriptionResource), typeof(CancellationToken))]
    [CodeGenSuppress("CreateMarketplaceAgreementAsync", typeof(SubscriptionResource), typeof(CancellationToken))]
    public static partial class ConfluentExtensions
    {
        /// <summary> Create Confluent Marketplace agreement in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Task<Response<ConfluentAgreement>> CreateMarketplaceAgreementAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableConfluentSubscriptionResource(subscriptionResource).CreateMarketplaceAgreementAsync(cancellationToken);

        /// <summary> Create Confluent Marketplace agreement in the subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public static Response<ConfluentAgreement> CreateMarketplaceAgreement(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
            => GetMockableConfluentSubscriptionResource(subscriptionResource).CreateMarketplaceAgreement(cancellationToken);
    }
}
