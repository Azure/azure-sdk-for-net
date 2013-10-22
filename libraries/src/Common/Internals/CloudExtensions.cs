//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;

namespace Microsoft.WindowsAzure.Common.Internals
{
    /// <summary>
    /// Internal extensions.
    /// </summary>
    public static class CloudExtensions
    {
        /// <summary>
        /// Create an ArgumentException for empty parameters.
        /// </summary>
        /// <param name="parameterName">The parameter name.</param>
        /// <returns>The ArgumentException.</returns>
        public static ArgumentException CreateArgumentEmptyException(string parameterName)
        {
            return new ArgumentException(
                string.Format(CultureInfo.InvariantCulture, Properties.Resources.ArgumentCannotBeEmpty, parameterName),
                parameterName);
        }

        /// <summary>
        /// Get the assembly version of a service client.
        /// </summary>
        /// <typeparam name="T">Type of the service client.</typeparam>
        /// <param name="client">The service client.</param>
        /// <returns>The assembly version of the client.</returns>
        public static string GetAssemblyVersion<T>(this ServiceClient<T> client)
            where T : ServiceClient<T>
        {
            Type type = client.GetType();
            string version =
                type
                .Assembly
                .FullName
                .Split(',')
                .Select(c => c.Trim())
                .Where(c => c.StartsWith("Version="))
                .FirstOrDefault()
                .Substring("Version=".Length);
            return version;
        }

        /// <summary>
        /// Get the HTTP pipeline formed from the ancestors of the starting
        /// handler.
        /// </summary>
        /// <param name="handler">The starting handler.</param>
        /// <returns>The HTTP pipeline.</returns>
        public static IEnumerable<HttpMessageHandler> GetHttpPipeline(this HttpMessageHandler handler)
        {
            while (handler != null)
            {
                yield return handler;

                DelegatingHandler delegating = handler as DelegatingHandler;
                handler = delegating != null ? delegating.InnerHandler : null;
            }
        }

        /// <summary>
        /// Get the HTTP pipeline for the given service client.
        /// </summary>
        /// <typeparam name="T">Type of the service client.</typeparam>
        /// <param name="client">The service client.</param>
        /// <returns>The client's HTTP pipeline.</returns>
        public static IEnumerable<HttpMessageHandler> GetHttpPipeline<T>(this ServiceClient<T> client)
            where T : ServiceClient<T>
        {
            return (client != null) ?
                client.HttpMessageHandler.GetHttpPipeline() :
                Enumerable.Empty<HttpMessageHandler>();
        }

        /// <summary>
        /// Add a handler to the end of the client's HTTP pipeline.
        /// </summary>
        /// <typeparam name="T">Type of the service client.</typeparam>
        /// <param name="client">The service client.</param>
        /// <param name="handler">The handler to add.</param>
        public static void AddHandlerToPipeline<T>(this ServiceClient<T> client, DelegatingHandler handler)
            where T : ServiceClient<T>
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            else if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }

            // Get our handler references
            DisposableReference<HttpMessageHandler> inner = client._innerHandler;
            DisposableReference<HttpMessageHandler> current = client._handler;
            DisposableReference<HttpMessageHandler> next = new DisposableReference<HttpMessageHandler>(handler);
            
            // Drop the current inner handler (note that current will still
            // maintain a reference via its pipeline to prevent its disposal)
            if (inner != null)
            {
                client._innerHandler = null;
                inner.ReleaseReference();
                inner = null;
            }

            // Associate the next handler with the current handler (and take a
            // reference on it)
            handler.InnerHandler = new IndisposableDelegatingHandler(current.Reference);
            current.AddReference();

            // Update the client's handler references
            client._innerHandler = current;
            client._handler = next;

            // Recreate our HttpClient with the new root of our pipeline
            HttpClient oldClient = client.HttpClient;
            client.HttpClient = new HttpClient(handler, false);
            ServiceClient<T>.CloneHttpClient(oldClient, client.HttpClient);
        }
    }
}
