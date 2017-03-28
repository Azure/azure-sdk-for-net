// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    internal partial class CheckNameAvailabilityResultImpl 
    {
        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for
        /// you to use. If true, the name is available. If false, the name has
        /// already been taken or invalid and cannot be used.
        /// </summary>
        bool Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult.IsAvailable
        {
            get
            {
                return this.IsAvailable();
            }
        }

        /// <summary>
        /// Gets the unavailabilityReason that a namespace name could not be used. The
        /// Reason element is only returned if NameAvailable is false.
        /// </summary>
        Management.Fluent.ServiceBus.Models.UnavailableReason Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult.UnavailabilityReason
        {
            get
            {
                return this.UnavailabilityReason() as Management.Fluent.ServiceBus.Models.UnavailableReason;
            }
        }

        /// <summary>
        /// Gets an error message explaining the Reason value in more detail.
        /// </summary>
        string Microsoft.Azure.Management.Servicebus.Fluent.ICheckNameAvailabilityResult.UnavailabilityMessage
        {
            get
            {
                return this.UnavailabilityMessage();
            }
        }
    }
}