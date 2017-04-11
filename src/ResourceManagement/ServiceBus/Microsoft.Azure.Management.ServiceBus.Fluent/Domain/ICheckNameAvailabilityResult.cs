// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using Management.Fluent.ServiceBus.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The result of checking for Service Bus namespace name availability.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ICheckNameAvailabilityResult  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<CheckNameAvailabilityResultInner>
    {
        /// <summary>
        /// Gets an error message explaining the Reason value in more detail.
        /// </summary>
        string UnavailabilityMessage { get; }

        /// <summary>
        /// Gets the unavailabilityReason that a namespace name could not be used. The
        /// Reason element is only returned if NameAvailable is false.
        /// </summary>
        UnavailableReason UnavailabilityReason { get; }

        /// <summary>
        /// Gets a boolean value that indicates whether the name is available for
        /// you to use. If true, the name is available. If false, the name has
        /// already been taken or invalid and cannot be used.
        /// </summary>
        bool IsAvailable { get; }
    }
}