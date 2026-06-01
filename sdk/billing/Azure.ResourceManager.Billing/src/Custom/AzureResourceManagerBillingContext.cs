// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Billing.Models;

namespace Azure.ResourceManager.Billing
{
    // Source-generator registration for back-compat *Content POCOs that live in
    // src/Custom/Models/ rather than src/Generated/Models/. The generated half of
    // AzureResourceManagerBillingContext only knows about generated types; the new
    // *Request models are already registered there. These six attributes register
    // the matching GA 1.2.2 *Content types so that
    // ModelReaderWriter.Read<T>(data, options, AzureResourceManagerBillingContext.Default)
    // can locate the type builder for them.
    [ModelReaderWriterBuildable(typeof(BillingSubscriptionMergeContent))]
    [ModelReaderWriterBuildable(typeof(BillingSubscriptionSplitContent))]
    [ModelReaderWriterBuildable(typeof(CancelSubscriptionContent))]
    [ModelReaderWriterBuildable(typeof(SavingsPlanUpdateValidateContent))]
    [ModelReaderWriterBuildable(typeof(BillingTransferDetailCreateOrUpdateContent))]
    [ModelReaderWriterBuildable(typeof(PartnerTransferDetailCreateOrUpdateContent))]
    public partial class AzureResourceManagerBillingContext
    {
    }
}
