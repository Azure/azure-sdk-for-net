// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace TrackOne
{
    /// <summary>
    /// Represents options can be set during the creation of a event hub receiver.
    /// </summary>
    internal class ReceiverOptions
    {
        private string identifier;

        /// <summary>Gets or sets the identifier of a receiver.</summary>
        /// <value>A string representing the identifier of a receiver.  It will return null if the identifier is not set.</value>
        /// <exception cref="System.ArgumentException">Thrown if the length of the value is greater than the maximum length of 64.</exception>
        public string Identifier
        {
            get => identifier;
            set
            {
                ReceiverOptions.ValidateReceiverIdentifier(value);
                identifier = value;
            }
        }

        /// <summary> Gets or sets a value indicating whether the runtime metric of a receiver is enabled. </summary>
        /// <value> true if a client wants to access <see cref="ReceiverRuntimeInformation"/> using <see cref="PartitionReceiver"/>. </value>
        public bool EnableReceiverRuntimeMetric
        {
            get; set;
        }

        private static void ValidateReceiverIdentifier(string identifier)
        {
            if (identifier != null &&
                identifier.Length > ClientConstants.MaxReceiverIdentifierLength)
            {
                throw Fx.Exception.Argument("Identifier", Resources.ReceiverIdentifierOverMaxValue.FormatForUser(ClientConstants.MaxReceiverIdentifierLength));
            }
        }
    }
}
