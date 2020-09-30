﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a user in Azure Communication Services.</summary>
    public class CommunicationUser : CommunicationIdentifier
    {
        /// <summary>The id of the communication user.</summary>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationUser"/>.
        /// </summary>
        /// <param name="id">Id of the communication user.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="id"/> is empty.
        /// </exception>
        public CommunicationUser(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Id = id;
        }
    }
}
