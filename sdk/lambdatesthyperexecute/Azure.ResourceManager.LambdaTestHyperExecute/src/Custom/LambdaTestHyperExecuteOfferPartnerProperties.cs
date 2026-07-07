// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.LambdaTestHyperExecute.Models
{
    public partial class LambdaTestHyperExecuteOfferPartnerProperties
    {
        /// <summary>
        /// [Obsolete] Backward-compatibility shim. Use <see cref="SubscribedLicensesCount"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been renamed to SubscribedLicensesCount.")]
        public int LicensesSubscribed
        {
            get => SubscribedLicensesCount;
            set => SubscribedLicensesCount = value;
        }
    }
}
