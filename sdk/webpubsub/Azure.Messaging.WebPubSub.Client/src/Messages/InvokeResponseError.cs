// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// Error details from an invoke response.
    /// </summary>
    public class InvokeResponseError
    {
        /// <summary>
        /// The error name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeResponseError"/> class.
        /// </summary>
        /// <param name="name">The error name</param>
        /// <param name="message">The error message</param>
        public InvokeResponseError(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
