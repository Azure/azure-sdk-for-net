// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Reservations.Models
{
    /// <summary> The ReservationCatalog. </summary>
    public partial class ReservationCatalog
    {
        /// <summary> Amount in pricing currency. Tax not included. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PurchasePrice MsrpP1Y
        {
            get => Msrp?.P1Y;
        }
    }
}
