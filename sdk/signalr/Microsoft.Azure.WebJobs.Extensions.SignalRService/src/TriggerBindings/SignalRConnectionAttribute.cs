// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Applies to <see cref="ServerlessHub{T}"/> to customize the Azure SignalR connection name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SignalRConnectionAttribute : Attribute, IConnectionProvider
    {
        private string _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRConnectionAttribute"/> class.
        /// </summary>
        /// <param name="connection">Gets or sets the app setting name that contains the Azure SignalR connection.</param>
        public SignalRConnectionAttribute(string connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        /// <summary>
        /// Gets or sets the app setting name that contains the Azure SignalR connection.
        /// </summary>
        public string Connection { get => _connection; set => _connection = value ?? throw new ArgumentNullException(nameof(value)); }
    }
}