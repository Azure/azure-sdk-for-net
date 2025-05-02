﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Projects
{
    public partial class Connections
    {
        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="Connection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public Connection Get(string connectionName, bool includeCredentials = false)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return GetWithCredentials(connectionName);
            }

            return GetConnection(connectionName);
        }

        /// <summary>
        /// Get a connection by name.
        /// </summary>
        /// <param name="connectionName">The name of the connection. Required.</param>
        /// <param name="includeCredentials">Whether to include credentials in the response. Default is false.</param>
        /// <returns>A <see cref="Connection"/> object.</returns>
        /// <exception cref="RequestFailedException">Thrown when the request fails.</exception>
        public async Task<Response<Connection>> GetAsync(string connectionName, bool includeCredentials = false)
        {
            if (string.IsNullOrWhiteSpace(connectionName))
            {
                throw new ArgumentException("Connection name cannot be null or empty.", nameof(connectionName));
            }

            // Use the instance method instead of incorrectly calling it as static
            if (includeCredentials)
            {
                return await GetWithCredentialsAsync(connectionName).ConfigureAwait(false);
            }

            return await GetConnectionAsync(connectionName).ConfigureAwait(false);
        }
    }
}
