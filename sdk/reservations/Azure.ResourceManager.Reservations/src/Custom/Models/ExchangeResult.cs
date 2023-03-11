// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Reservations.Models
{
    /// <summary> Exchange operation result. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExchangeResult
    {
        /// <summary> It should match what is used to GET the operation result. </summary>
        public ResourceIdentifier Id { get; }
    }
}
