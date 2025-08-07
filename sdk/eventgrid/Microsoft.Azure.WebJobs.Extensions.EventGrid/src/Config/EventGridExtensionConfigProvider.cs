// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Config
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
        private readonly EventGridAsyncCollectorFactory _collectorFactory;
        private readonly HttpRequestProcessor _httpRequestProcessor;
        private readonly DiagnosticScopeFactory _diagnosticScopeFactory;

        // ApplicationInsights SDK listens to all Azure SDK sources that look like 'Azure.*'
        private const string DiagnosticScopeNamespace = "Azure.Messaging.EventGrid";
        private const string ResourceProviderNamespace = "Microsoft.EventGrid";
        private const string DiagnosticScopeName = "EventGrid.Process";

        // default constructor
        public EventGridExtensionConfigProvider(
            EventGridAsyncCollectorFactory collectorFactory,
            HttpRequestProcessor httpRequestProcessor,
            ILoggerFactory loggerFactory)
        {
            _collectorFactory = collectorFactory;
            _httpRequestProcessor = httpRequestProcessor;
            _loggerFactory = loggerFactory;
            _diagnosticScopeFactory = new DiagnosticScopeFactory(DiagnosticScopeNamespace, ResourceProviderNamespace, true, true, true);
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _logger = _loggerFactory.CreateLogger<EventGridExtensionConfigProvider>();

#pragma warning disable 618
            Uri url = context.GetWebhookHandler();
#pragma warning restore 618
            _logger.LogInformation($"registered EventGrid Endpoint = {url?.GetLeftPart(UriPartial.Path)}");

            // Register our extension binding providers
            // use converterManager as a hashTable
            // also take benefit of identity converter
            context
                .AddBindingRule<EventGridTriggerAttribute>() // following converters are for EventGridTriggerAttribute only
                .AddConverter<JToken, string>(jtoken => jtoken.ToString(Formatting.Indented))
                .AddConverter<JToken, string[]>(jarray => jarray.Select(ar => ar.ToString(Formatting.Indented)).ToArray())
                .AddConverter<JToken, DirectInvokeString>(jtoken => new DirectInvokeString(null))
                .AddConverter<DirectInvokeString, JToken>(directInvokeString => JToken.Parse(directInvokeString.Value))
                .AddConverter<JToken, EventGridEvent>(jobject => EventGridEvent.Parse(new BinaryData(jobject.ToString()))) // surface the type to function runtime
                .AddConverter<JToken, EventGridEvent[]>(jobject => EventGridEvent.ParseMany(new BinaryData(jobject.ToString())))
                .AddConverter<JToken, CloudEvent>(jobject => CloudEvent.Parse(new BinaryData(jobject.ToString())))
                .AddConverter<JToken, CloudEvent[]>(jobject => CloudEvent.ParseMany(new BinaryData(jobject.ToString())))
                .AddConverter<JToken, BinaryData>(jobject => new BinaryData(jobject.ToString()))
                .AddConverter<JToken, BinaryData[]>(jobject => jobject.Select(obj => new BinaryData(obj.ToString())).ToArray())
                .AddOpenConverter<JToken, OpenType.Poco>(typeof(JTokenToPocoConverter<>))
                .AddOpenConverter<JToken, OpenType.Poco[]>(typeof(JTokenToPocoConverter<>))
                .BindToTrigger<JToken>(new EventGridTriggerAttributeBindingProvider(this));

            // Register the output binding
            var rule = context.AddBindingRule<EventGridAttribute>();
            rule.BindToCollector(_collectorFactory.CreateCollector);
            rule.AddValidator((a, t) => _collectorFactory.Validate(a));
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
            if (string.IsNullOrEmpty(functionName) || !_listeners.TryGetValue(functionName, out EventGridListener listener))
            {
                _logger.LogInformation($"cannot find function: '{functionName}', available function names: [{string.Join(", ", _listeners.Keys.ToArray())}]");
                return new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent($"cannot find function: '{functionName}'") };
            }

            return await _httpRequestProcessor.ProcessAsync(req, functionName, ProcessEventsAsync, listener.BindingType, CancellationToken.None).ConfigureAwait(false);
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
                    executions.Add(ExecuteWithTracingAsync(functionName, triggerData));
                }
            }
            // Batch Dispatch
            else
            {
                TriggeredFunctionData triggerData = new TriggeredFunctionData
                {
                    TriggerValue = events
                };
                executions.Add(ExecuteWithTracingAsync(functionName, triggerData));
            }

            await Task.WhenAll(executions).ConfigureAwait(false);

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

        private async Task<FunctionResult> ExecuteWithTracingAsync(string functionName, TriggeredFunctionData triggerData)
        {
            using DiagnosticScope scope = _diagnosticScopeFactory.CreateScope(DiagnosticScopeName, ActivityKind.Consumer);
            if (scope.IsEnabled)
            {
                if (triggerData.TriggerValue is JArray evntArray)
                {
                    foreach (JToken eventToken in evntArray)
                    {
                        AddLinkIfEventHasContext(scope, eventToken);
                    }
                }
                else if (triggerData.TriggerValue is JToken eventToken)
                {
                    AddLinkIfEventHasContext(scope, eventToken);
                }
            }

            scope.Start();

            FunctionResult result = await _listeners[functionName].Executor.TryExecuteAsync(triggerData, CancellationToken.None).ConfigureAwait(false);
            if (result.Exception != null)
            {
                scope.Failed(result.Exception);
            }
            return result;
        }

        private static void AddLinkIfEventHasContext(DiagnosticScope scope, JToken evnt)
        {
            if (evnt is JObject eventObj &&
                eventObj.TryGetValue("traceparent", out JToken traceparent) &&
                traceparent.Type == JTokenType.String)
            {
                string tracestateStr = null;
                if (eventObj.TryGetValue("tracestate", out JToken tracestate) &&
                    tracestate.Type == JTokenType.String)
                {
                    tracestateStr = tracestate.Value<string>();
                }
                scope.AddLink(traceparent.Value<string>(), tracestateStr);
            }
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