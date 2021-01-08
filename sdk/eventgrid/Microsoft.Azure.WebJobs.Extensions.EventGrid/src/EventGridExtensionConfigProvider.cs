// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    /// <summary>
    /// Defines the configuration options for the EventGrid binding.
    /// </summary>
    [Extension("EventGrid", "EventGrid")]
    internal class EventGridExtensionConfigProvider : IExtensionConfigProvider,
                       IAsyncConverter<HttpRequestMessage, HttpResponseMessage>
    {
        private ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly Func<EventGridAttribute, IAsyncCollector<EventGridEvent>> _converter;
        private readonly HttpRequestProcessor _httpRequestProcessor;

        // for end to end testing
        internal EventGridExtensionConfigProvider(
            Func<EventGridAttribute, IAsyncCollector<EventGridEvent>> converter,
            HttpRequestProcessor httpRequestProcessor,
            ILoggerFactory loggerFactory)
        {
            _converter = converter;
            _httpRequestProcessor = httpRequestProcessor;
            _loggerFactory = loggerFactory;
        }

        // default constructor
        public EventGridExtensionConfigProvider(HttpRequestProcessor httpRequestProcessor, ILoggerFactory loggerFactory)
        {
            _converter = (attr => new EventGridAsyncCollector(new EventGridPublisherClient(new Uri(attr.TopicEndpointUri), new AzureKeyCredential(attr.TopicKeySetting))));
            _httpRequestProcessor = httpRequestProcessor;
            _loggerFactory = loggerFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _logger = _loggerFactory.CreateLogger(LogCategories.CreateTriggerCategory("EventGrid"));

#pragma warning disable 618
            Uri url = context.GetWebhookHandler();
#pragma warning restore 618
            _logger.LogInformation($"registered EventGrid Endpoint = {url?.GetLeftPart(UriPartial.Path)}");

            // Register our extension binding providers
            // use converterManager as a hashTable
            // also take benefit of identity converter
            context
                .AddBindingRule<EventGridTriggerAttribute>() // following converters are for EventGridTriggerAttribute only
                .AddConverter<JToken, string>((jtoken) => jtoken.ToString(Formatting.Indented))
                .AddConverter<JToken, string[]>((jarray) => jarray.Select(ar => ar.ToString(Formatting.Indented)).ToArray())
                .AddConverter<JToken, DirectInvokeString>((jtoken) => new DirectInvokeString(null))
                .AddConverter<JToken, EventGridEvent>((jobject) => jobject.ToObject<EventGridEvent>()) // surface the type to function runtime
                .AddConverter<JToken, EventGridEvent[]>((jobject) => jobject.ToObject<EventGridEvent[]>()) // surface the type to function runtime
                .AddOpenConverter<JToken, OpenType.Poco>(typeof(JTokenToPocoConverter<>))
                .AddOpenConverter<JToken, OpenType.Poco[]>(typeof(JTokenToPocoConverter<>))
                .BindToTrigger<JToken>(new EventGridTriggerAttributeBindingProvider(this));

            // Register the output binding
            var rule = context
                .AddBindingRule<EventGridAttribute>()
                .AddConverter<string, EventGridEvent>((str) => EventGridEvent.Parse(str).Single())
                .AddConverter<JObject, EventGridEvent>((jobject) =>  EventGridEvent.Parse(jobject.ToString()).Single());
            rule.BindToCollector(_converter);
            rule.AddValidator((a, t) =>
            {
                // if app setting is missing, it will be caught by runtime
                // this logic tries to validate the practicality of attribute properties
                if (string.IsNullOrWhiteSpace(a.TopicKeySetting))
                {
                    throw new InvalidOperationException($"The '{nameof(EventGridAttribute.TopicKeySetting)}' property must be the name of an application setting containing the Topic Key");
                }

                if (!Uri.IsWellFormedUriString(a.TopicEndpointUri, UriKind.Absolute))
                {
                    throw new InvalidOperationException($"The '{nameof(EventGridAttribute.TopicEndpointUri)}' property must be a valid absolute Uri");
                }
            });
        }

        private Dictionary<string, EventGridListener> _listeners = new Dictionary<string, EventGridListener>();

        internal void AddListener(string key, EventGridListener listener)
        {
            _listeners.Add(key, listener);
        }

        public async Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage input, CancellationToken cancellationToken)
        {
            var response = ProcessAsync(input);
            return await response.ConfigureAwait(false);
        }

        private async Task<HttpResponseMessage> ProcessAsync(HttpRequestMessage req)
        {
            // webjobs.script uses req.GetQueryNameValuePairs();
            // which requires webapi.core...but this does not work for .netframework2.0
            // TODO change this once webjobs.script is migrated
            var functionName = HttpUtility.ParseQueryString(req.RequestUri.Query)["functionName"];
            if (String.IsNullOrEmpty(functionName) || !_listeners.ContainsKey(functionName))
            {
                _logger.LogInformation($"cannot find function: '{functionName}', available function names: [{string.Join(", ", _listeners.Keys.ToArray())}]");
                return new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent($"cannot find function: '{functionName}'") };
            }

            return await _httpRequestProcessor.ProcessAsync(req, functionName, ProcessEventsAsync, CancellationToken.None).ConfigureAwait(false);
        }

        private async Task<HttpResponseMessage> ProcessEventsAsync(JArray events, string functionName, CancellationToken cancellationToken)
        {
            List<Task<FunctionResult>> executions = new List<Task<FunctionResult>>();

            // Single Dispatch
            if (_listeners[functionName].SingleDispatch)
            {
                foreach (var ev in events)
                {
                    // assume each event is a JObject
                    TriggeredFunctionData triggerData = new TriggeredFunctionData
                    {
                        TriggerValue = ev
                    };
                    executions.Add(_listeners[functionName].Executor.TryExecuteAsync(triggerData, CancellationToken.None));
                }
                await Task.WhenAll(executions).ConfigureAwait(false);
            }
            // Batch Dispatch
            else
            {
                TriggeredFunctionData triggerData = new TriggeredFunctionData
                {
                    TriggerValue = events
                };
                executions.Add(_listeners[functionName].Executor.TryExecuteAsync(triggerData, CancellationToken.None));
            }

            // FIXME without internal queuing, we are going to process all events in parallel
            // and return 500 if there's at least one failure...which will cause EventGrid to resend the entire payload
            foreach (var execution in executions)
            {
                if (!execution.Result.Succeeded)
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(execution.Result.Exception.Message) };
                }
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

        private class JTokenToPocoConverter<T> : IConverter<JToken, T>
        {
            public T Convert(JToken input)
            {
                return input.ToObject<T>();
            }
        }
    }
}
