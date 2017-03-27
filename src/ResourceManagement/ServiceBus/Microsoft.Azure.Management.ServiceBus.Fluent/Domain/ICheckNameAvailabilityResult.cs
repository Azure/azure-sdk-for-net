// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using Management.Fluent.ServiceBus.Models;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// The result of checking for Service Bus namespace name availability.
    /// </summary>
    public interface ICheckNameAvailabilityResult  :
        IHasInner<CheckNameAvailabilityResultInner>
    {
        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for
        /// you to use. If true, the name is available. If false, the name has
        /// already been taken or invalid and cannot be used.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets the unavailabilityReason that a namespace name could not be used. The
        /// Reason element is only returned if NameAvailable is false.
        /// </summary>
        UnavailableReason UnavailabilityReason { get; }

        /// <summary>
        /// Gets an error message explaining the Reason value in more detail.
        /// </summary>
        string UnavailabilityMessage { get; }
    }
}