// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.DataBox.Models
{
    public abstract partial class DataBoxValidationContent
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxValidationContent"/>. </summary>
        /// <param name="individualRequestDetails">
        /// List of request details contain validationType and its request as key and value respectively.
        /// Please note <see cref="DataBoxValidationInputContent"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DataBoxValidateAddressContent"/>, <see cref="CreateOrderLimitForSubscriptionValidationContent"/>, <see cref="DataTransferDetailsValidationContent"/>, <see cref="PreferencesValidationContent"/>, <see cref="SkuAvailabilityValidationContent"/> and <see cref="SubscriptionIsAllowedToCreateJobValidationContent"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="individualRequestDetails"/> is null. </exception>
        protected DataBoxValidationContent(IEnumerable<DataBoxValidationInputContent> individualRequestDetails)
        {
            Argument.AssertNotNull(individualRequestDetails, nameof(individualRequestDetails));

            IndividualRequestDetails = individualRequestDetails.ToList();
        }
    }
}
