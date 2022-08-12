// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>The main configuration provider, this also handles the initial HTTP requests and response via IAsyncConverter.</summary>
    /// <seealso cref="HttpRequestMessage" />
    /// <seealso cref="HttpResponseMessage" />
    [Extension("AuthenticationEvents", "AuthenticationEvents")]
    internal class AuthEventConfigProvider : IExtensionConfigProvider, IAsyncConverter<HttpRequestMessage, HttpResponseMessage>
    {
        private readonly ILogger _logger;
        private Uri _base_uri;

        /// <summary>The listeners that are attached to the functions that implement the AuthenticationEventTriggerAttribute.</summary>
        public Dictionary<string, AuthEventListener> Listeners { get; } = new Dictionary<string, AuthEventListener>();

        /// <summary>Initializes a new instance of the <see cref="AuthEventConfigProvider" /> class.</summary>
        /// <param name="loggerFactory">The logger factory from the WebJobs framework.</param>
        public AuthEventConfigProvider(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AuthEventConfigProvider>();
        }

        /// <summary>Initializes the specified configuration.
        /// This is where we create the main HTTP Listener endpoint and bind the trigger. (For all intents and purposes this is not obsolete).</summary>
        /// <param name="context">The context we get from the Webjobs framework.</param>
        [Obsolete("Is not obsolete marked by webjobs team, but chatted and this is correct. It is not being deprecated")]
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<AuthenticationEventsTriggerAttribute>()
                    .BindToTrigger(new AuthEventBindingProvider(this));

            _base_uri = context.GetWebhookHandler();
            //LogInformation(string.Format(AuthEventResource.Log_EventHandler_Url, Uri));
        }

        internal void LogInformation(string message)
        {
            Console.WriteLine(message);
            _logger.LogInformation(message);
        }

        internal void DisplayAzureFunctionInfoToConsole(string functionName)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Listeners.Count == 1)
            {
                Console.WriteLine();
                Console.WriteLine(AuthEventResource.Out_Console_Seperator);
            }
            Console.Write(AuthEventResource.Out_Console_FunctName);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(functionName);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(AuthEventResource.Out_Console_FunctUrl);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{_base_uri}&functionName={functionName}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(AuthEventResource.Out_Console_Seperator);
            Console.ResetColor();
        }

        /// <summary>The main entry point when we get an HTTP post.</summary>
        /// <param name="input">The incoming HTTP request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The HTTP response that is build based on the events request's response.<br /></returns>
        /// <exception cref="MissingFieldException">Is thrown if the function parameter is not in the incoming query string.</exception>
        /// <exception cref="MissingMethodException">Is thrown if the incoming function parameter is not associated to a trigger listener.</exception>
        /// <exception cref="InvalidOperationException">Is thrown when the incoming request method is NOT 'POST'.</exception>
        public async Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage input, CancellationToken cancellationToken)
        {
            try
            {
                NameValueCollection queryStringParmeters = HttpUtility.ParseQueryString(input.RequestUri.Query);
                //First lets test if the is request is for an openapi document
                if (queryStringParmeters["openapi"] != null)
                    return GetOpenApiDocument(queryStringParmeters["openapi"]);

                if (input.Method != HttpMethod.Post)
                    throw new InvalidOperationException("Method can only be post.");

                //We find the attached listener assigned to the function and execute it.
                var functionName = queryStringParmeters["function"] ?? queryStringParmeters["functionName"];
                if (string.IsNullOrEmpty(functionName))
                    throw new MissingFieldException(string.Format(CultureInfo.CurrentCulture, AuthEventResource.Ex_Missing_Function, string.Join(", ", Listeners.Select(l => l.Key))));

                KeyValuePair<string, AuthEventListener> listener = Listeners.FirstOrDefault(l => l.Key.Equals(functionName, StringComparison.OrdinalIgnoreCase));
                if (listener.Key == null)
                    throw new MissingMethodException(string.Format(CultureInfo.CurrentCulture,AuthEventResource.Ex_Invalid_Function, functionName, string.Join(", ", Listeners.Select(l => l.Key))));

                //We create an event response handler and attach it to the income HTTP message, then on the trigger we set the function response
                //in the event response handler and after the executor calls the functions we have reference to the function response.
                AuthEventResponseHandler eventsResponseHandler = new();
                input.Properties.Add(AuthEventResponseHandler.EventResponseProperty, eventsResponseHandler);

                TriggeredFunctionData triggerData = new()
                {
                    TriggerValue = input
                };

                FunctionResult result = await listener.Value.FunctionExecutor.TryExecuteAsync(triggerData, cancellationToken).ConfigureAwait(false);
                if (result.Succeeded)
                    return (HttpResponseMessage)eventsResponseHandler.Response;
                else
                    return Helpers.HttpErrorResponse(result.Exception);
            }
            catch (Exception ex)
            {
                return Helpers.HttpErrorResponse(ex);
            }
        }

        private static HttpResponseMessage GetOpenApiDocument(string eventNamespace)
        {
            try
            {
                OpenApiDocument document = OpenApiDocument.Load(eventNamespace);
                if (document == null)
                    throw new Exception(AuthEventResource.Ex_OpenApi_Missing);
                return Helpers.HttpJsonResponse(document.EmbedReferences());
            }
            catch (Exception ex)
            {
                return Helpers.HttpErrorResponse(ex);
            }
        }
    }
}
