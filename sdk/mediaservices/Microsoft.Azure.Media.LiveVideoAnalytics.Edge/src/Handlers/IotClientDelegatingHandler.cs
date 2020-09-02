// -----------------------------------------------------------------------
//  <copyright company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Media.LiveVideoAnalytics.Edge.Handlers
{
    /// <summary>
    /// Base class for IoT Client delegating handlers.
    /// </summary>
    internal abstract class IotClientDelegatingHandler : DelegatingHandler
    {
        private static readonly Regex PathRegex = new Regex(
            @"/api/(?<entitySetName>[^/]+)(/(?<entityName>[^/]+))?(/(?<entityAction>[^/]+))?",
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        /// <summary>
        /// Retrieves the IoT method suffix based on the request path.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <param name="isInstancePath">Indicates whether or not the request path is for an entity instance.</param>
        /// <param name="instanceAction">Post request entity action method suffix. </param>
        /// <returns>The IoT direct method suffix.</returns>
        protected static string GetMethodSuffix(HttpRequestMessage request, bool isInstancePath, string instanceAction)
        {
            string methodSuffix;
            switch (request.Method.Method.ToUpperInvariant())
            {
                case "DELETE":

                    methodSuffix = "Delete";
                    break;

                case "GET":

                    methodSuffix = isInstancePath ? "Get" : "List";
                    break;

                case "PUT":

                    methodSuffix = "Set";
                    break;

                case "POST":

                    if (string.IsNullOrWhiteSpace(instanceAction))
                    {
                        throw new InvalidOperationException("POST request with empty entity action operation is not allowed");
                    }

                    methodSuffix = Char.ToUpperInvariant(instanceAction[0]) + instanceAction.Substring(1);
                    break;

                default:

                    throw new InvalidOperationException();
            }

            return methodSuffix;
        }

        /// <summary>
        /// Sends the request to the IoT Hub and returns the response.
        /// </summary>
        /// <param name="methodName">Request method name.</param>
        /// <param name="requestString">Request string.</param>
        /// <returns>The response status and response string.</returns>
        protected abstract Task<(HttpStatusCode ResponseStatus, string ResponseString)> SendIotRequestAsync(string methodName, string requestString);

        /// <summary>
        /// This methods rewrites API requests into direct method calls.
        /// </summary>
        /// <param name="request">Original request to be rewritten.</param>
        /// <param name="cancellationToken">Asynchronous cancellation token.</param>
        /// <returns>Rewritten response message.</returns>
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestUri = request.RequestUri;

            var match = PathRegex.Match(requestUri.AbsolutePath);

            if (match.Success)
            {
                var entitySetName = match.Groups["entitySetName"].Value;
                var entityName = match.Groups["entityName"].Value;
                var entityAction = match.Groups["entityAction"].Value;

                // Define direct method call name and entity name
                var methodSuffix = GetMethodSuffix(request, isInstancePath: !string.IsNullOrWhiteSpace(entityName), entityAction);
                var methodName = entitySetName + methodSuffix;

                // Add AMS Edge API Version to the payload object
                var requestObject = request.Content != null
                    ? JObject.Parse(await request.Content.ReadAsStringAsync())
                    : new JObject();

                requestObject.Add("@apiVersion", "1.0");
                if (!string.IsNullOrWhiteSpace(entityName))
                {
                    requestObject.Add("name", entityName);
                }

                // Invoke the IoT Direct Method
                var requestString = JsonConvert.SerializeObject(requestObject);

                (var statusCode, var responseString) = await SendIotRequestAsync(methodName, requestString);

                // Convert it to an HTTP response
                var httpResponse = new HttpResponseMessage(statusCode);
                if (!string.IsNullOrWhiteSpace(responseString))
                {
                    httpResponse.Content = new StringContent(responseString, Encoding.UTF8, "application/json");
                }

                return httpResponse;
            }

            throw new InvalidOperationException("Unexpected request URI.");
        }
    }
}
