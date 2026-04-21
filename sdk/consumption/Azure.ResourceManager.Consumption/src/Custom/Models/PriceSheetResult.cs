// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using Azure;

namespace Azure.ResourceManager.Consumption.Models
{
    // This type was renamed to PriceSheetResultData and moved to the root namespace.
    // Stub retained for backward compatibility.
    [Obsolete("This type is obsolete. Use PriceSheetResultData instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PriceSheetResult : PriceSheetResultData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ETag? ETag
        {
            get => throw new NotSupportedException("This type is obsolete.");
        }
    }
}
