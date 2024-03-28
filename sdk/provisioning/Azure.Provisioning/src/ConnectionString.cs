// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning
{
    /// <summary>
    /// Represents a connection string.
    /// </summary>
    public abstract class ConnectionString
    {
        /// <summary>
        /// Gets the value of the connection string.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionString"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        protected ConnectionString(string value)
        {
            Value = value;
        }
    }
}
