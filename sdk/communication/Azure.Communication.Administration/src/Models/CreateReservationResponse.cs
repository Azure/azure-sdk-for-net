// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.Communication.Administration.Models
{
    [CodeGenModel("CreateSearchResponse")]
    [ExcludeFromCodeCoverage]
    internal partial class CreateReservationResponse
    {
        /// <summary> The id of a created reservation. </summary>
        [CodeGenMember("SearchId")]
        public string ReservationId { get; }
    }
}
