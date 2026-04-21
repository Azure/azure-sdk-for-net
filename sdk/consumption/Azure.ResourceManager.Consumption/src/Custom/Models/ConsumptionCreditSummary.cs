// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using Azure;

namespace Azure.ResourceManager.Consumption.Models
{
    // This type was renamed to ConsumptionCreditSummaryData and moved to the root namespace.
    // Stub retained for backward compatibility.
    [Obsolete("This type is obsolete. Use ConsumptionCreditSummaryData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ConsumptionCreditSummary : ConsumptionCreditSummaryData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ETag? ETag
        {
            get => throw new NotSupportedException("This type is obsolete.");
            set => throw new NotSupportedException("This type is obsolete.");
        }
    }
}
