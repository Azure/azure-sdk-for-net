// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// An error associated with a service acknowledgement.
    /// </summary>
    public class AckMessageError
    {
        /// <summary>
        ///  The name of error
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The details of the error
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AckMessageError"/> class.
        /// </summary>
        /// <param name="name">The name of error</param>
        /// <param name="message">The detailed message</param>
        public AckMessageError(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
