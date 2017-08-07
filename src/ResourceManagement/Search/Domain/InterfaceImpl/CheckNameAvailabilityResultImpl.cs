// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Search.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Search.Fluent.Models;

    internal partial class CheckNameAvailabilityResultImpl 
    {
        /// <summary>
        /// Gets true if the specified name is valid and available for use, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult.IsAvailable
        {
            get
            {
                return this.IsAvailable();
            }
        }

        /// <summary>
        /// Gets the reason why the user-provided name for the search service could not be used, if any. The
        /// Reason element is only returned if NameAvailable is false.
        /// </summary>
        string Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult.UnavailabilityReason
        {
            get
            {
                return this.UnavailabilityReason();
            }
        }

        /// <summary>
        /// Gets an error message explaining the Reason value in more detail.
        /// </summary>
        string Microsoft.Azure.Management.Search.Fluent.ICheckNameAvailabilityResult.UnavailabilityMessage
        {
            get
            {
                return this.UnavailabilityMessage();
            }
        }
    }
}