// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Formatting = Newtonsoft.Json.Formatting;

namespace Azure.Communication.CallingServer
{
    internal class CallAutomationClientAutomatedLiveTestsBase : RecordedTestBase<CallAutomationClientTestEnvironment>
    {
        private const string URIDomainRegEx = @"https://([^/?]+)";

        private Dictionary<string, ConcurrentDictionary<Type, CallAutomationEventBase>> _eventstore;
        private ConcurrentDictionary<string, string> _incomingcontextstore;
        private ConcurrentDictionary<string, ServiceBusProcessor> _processorStore;

        private ServiceBusClient _serviceBusClient;
        private HttpClient _httpClient;

        public CallAutomationClientAutomatedLiveTestsBase(bool isAsync) : base(isAsync)
        {
            _eventstore = new Dictionary<string, ConcurrentDictionary<Type, CallAutomationEventBase>>();
            _incomingcontextstore = new ConcurrentDictionary<string, string>();
            _processorStore = new ConcurrentDictionary<string, ServiceBusProcessor>();

            var clientOptions = new ServiceBusClientOptions() { TransportType = ServiceBusTransportType.AmqpWebSockets };
            _serviceBusClient = new ServiceBusClient(TestEnvironment.ServicebusString, clientOptions);
            _httpClient = new HttpClient();

            SanitizedHeaders.Add("x-ms-content-sha256");
            SanitizedHeaders.Add("X-FORWARDED-HOST");
            JsonPathSanitizers.Add("$..id");
            JsonPathSanitizers.Add("$..rawId");
            JsonPathSanitizers.Add("$..value");
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainRegEx, "https://sanitized.skype.com"));
        }

        [TearDown]
        public async Task CleanUp()
        {
            // cleanup servicebus
            List<string> unsubList = new List<string>();
            foreach (var processor in _processorStore)
            {
                unsubList.Add(processor.Key);
            }

            // unsubscribe;
            var jsonString = JsonConvert.SerializeObject(unsubList);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            _ = await _httpClient.PostAsync(TestEnvironment.DispatcherEndpoint + $"/api/servicebuscallback/unsubscribe", content);
        }

        public bool SkipCallingServerInteractionLiveTests
            => TestEnvironment.Mode != RecordedTestMode.Playback && Environment.GetEnvironmentVariable("SKIP_CALLINGSERVER_INTERACTION_LIVE_TESTS")== "TRUE";

        /// <summary>
        /// Creates a <see cref="CallAutomationClient" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallAutomationClient" />.</returns>
        protected CallAutomationClient CreateInstrumentedCallAutomationClientWithConnectionString()
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;

            CallAutomationClient callAutomationClient;
            if (TestEnvironment.PMAEndpoint == null || TestEnvironment.PMAEndpoint.Length == 0)
            {
                callAutomationClient = new CallAutomationClient(connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
            }
            else
            {
                callAutomationClient = new CallAutomationClient(new Uri(TestEnvironment.PMAEndpoint), connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs());
            }

            return InstrumentClient(callAutomationClient);
        }

        protected async Task<string> ServiceBusWithNewCall(CommunicationIdentifier caller, CommunicationIdentifier reciever)
        {
            string callerId = ParseIdsFromIdentifier(caller);
            string recieverId = ParseIdsFromIdentifier(reciever);
            string uniqueId = callerId + recieverId;

            // subscribe;
            HttpResponseMessage response = await _httpClient.PostAsync(TestEnvironment.DispatcherEndpoint + $"/api/servicebuscallback/subscribe?q={uniqueId}", null);
            response.EnsureSuccessStatusCode();

            // create a processor that we can use to process the messages
            var processor = _serviceBusClient.CreateProcessor(uniqueId, new ServiceBusProcessorOptions());

            // add handler to process messages
            processor.ProcessMessageAsync += MessageHandler;

            // add handler to process any errors
            processor.ProcessErrorAsync += ErrorHandler;

            // start processing
            await processor.StartProcessingAsync();

            _processorStore.TryAdd(uniqueId, processor);
            return uniqueId;
        }

        protected async Task<string?> WaitForIncomingCallContext(string callerMRIInput, TimeSpan timeOut)
        {
            string caller = RemoveAllNonChar(callerMRIInput);

            var timeOutTime = DateTime.Now.Add(timeOut);
            while (DateTime.Now < timeOutTime)
            {
                if (_incomingcontextstore.TryGetValue(caller, out var incomingcon))
                {
                    _incomingcontextstore.TryRemove(caller, out _);
                    return incomingcon;
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            return null;
        }

        protected async Task<CallAutomationEventBase?> WaitForEvent<T>(string callConnectionId, TimeSpan timeOut)
        {
            var timeOutTime = DateTime.Now.Add(timeOut);
            while (DateTime.Now < timeOutTime)
            {
                if (_eventstore.TryGetValue(callConnectionId, out var mylist))
                {
                    if (mylist.TryRemove(typeof(T), out var matchingEvent))
                    {
                        return matchingEvent;
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            return null;
        }

        protected string GetResourceId()
        {
            return TestEnvironment.ResourceIdentifier;
        }

        /// <summary>
        /// Creates a <see cref="CommunicationIdentityClient" /> with the connectionstring via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        /// <returns>The instrumented <see cref="CommunicationIdentityClient" />.</returns>
        protected CommunicationIdentityClient CreateInstrumentedCommunicationIdentityClient()
            => InstrumentClient(
                new CommunicationIdentityClient(
                    TestEnvironment.LiveTestStaticConnectionString,
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2021_03_07))));

        protected async Task<CommunicationUserIdentifier> CreateIdentityUserAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            return await communicationIdentityClient.CreateUserAsync().ConfigureAwait(false);
        }

        private async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();

            if (!string.IsNullOrEmpty(body))
            {
                Console.WriteLine($"Events: {JToken.Parse(body).ToString(Formatting.Indented)}");

                if (body.Contains("\"incomingCallContext\":\""))
                {
                    // for incoming call event grid event
                    string incomingCallContext = body.Split(new[] { "\"incomingCallContext\":\"" }, StringSplitOptions.None)[1].Split(new[] { "\"" }, StringSplitOptions.None)[0];

                    string uniqueId = ParseFromAndTo(body);

                    _incomingcontextstore.TryAdd(RemoveAllNonChar(uniqueId), incomingCallContext);
                }
                else
                {
                    // for call automation callback events
                    CallAutomationEventBase callBackEvent = CallAutomationEventParser.Parse(BinaryData.FromString(body));

                    if (_eventstore.TryGetValue(callBackEvent.CallConnectionId, out var mylist))
                    {
                        mylist.AddOrUpdate(callBackEvent.GetType(), callBackEvent, (key, oldValue) => callBackEvent);
                    }
                    else
                    {
                        ConcurrentDictionary<Type, CallAutomationEventBase> events = new ConcurrentDictionary<Type, CallAutomationEventBase>();
                        events.TryAdd(callBackEvent.GetType(), callBackEvent);
                        _eventstore.Add(callBackEvent.CallConnectionId, events);
                    }
                }
            }

            // complete the message. messages is deleted from the queue.
            await args.CompleteMessageAsync(args.Message);
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates a <see cref="CallAutomationClientOptions" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallAutomationClientOptions" />.</returns>
        private CallAutomationClientOptions CreateServerCallingClientOptionsWithCorrelationVectorLogs()
        {
            CallAutomationClientOptions callClientOptions = new CallAutomationClientOptions();
            callClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(callClientOptions);
        }

        private string ParseFromAndTo(string unparsed)
        {
            // TODO: Update this part once incmoing call can be parsed with event grid in the future
            string fromId = unparsed.Split(new string[] { "\"from\":{\"kind\":" }, StringSplitOptions.None)[1].Split(new string[] { "\"rawId\":\"" }, StringSplitOptions.None)[1].Split(new string[] { "\"" }, StringSplitOptions.None)[0];
            string toId = unparsed.Split(new string[] { "\"to\":{\"kind\":" }, StringSplitOptions.None)[1].Split(new string[] { "\"rawId\":\"" }, StringSplitOptions.None)[1].Split(new string[] { "\"" }, StringSplitOptions.None)[0];

            return fromId + toId;
        }

        private string ParseIdsFromIdentifier(CommunicationIdentifier inputIdentifier)
        {
            switch (inputIdentifier)
            {
                case null:
                    throw new ArgumentNullException();
                case CommunicationUserIdentifier:
                    return RemoveAllNonChar(((CommunicationUserIdentifier)inputIdentifier).RawId);
                case PhoneNumberIdentifier:
                    return RemoveAllNonChar(((PhoneNumberIdentifier)inputIdentifier).RawId);
                case MicrosoftTeamsUserIdentifier:
                    return RemoveAllNonChar(((MicrosoftTeamsUserIdentifier)inputIdentifier).RawId);
                default:
                    throw new NotSupportedException();
            }
        }

        private static string RemoveAllNonChar(string inputId)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9_-]");
            return rgx.Replace(inputId, "");
        }
    }
}
