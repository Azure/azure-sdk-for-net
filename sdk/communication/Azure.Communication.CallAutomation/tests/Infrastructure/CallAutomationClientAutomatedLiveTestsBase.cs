// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Azure.Communication.CallAutomation.Tests.EventCatcher;
using Azure.Communication.Identity;
using Azure.Communication.PhoneNumbers;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Formatting = Newtonsoft.Json.Formatting;

namespace Azure.Communication.CallAutomation.Tests.Infrastructure
{
    internal class CallAutomationClientAutomatedLiveTestsBase : RecordedTestBase<CallAutomationClientTestEnvironment>
    {
        private const string URIDomainRegEx = @"https://([^/?]+)";
        private const string TestDispatcherRegEx = @"https://incomingcalldispatcher.azurewebsites.net";
        private const string TestDispatcherQNameRegEx = @"(?<=\?q=)(.*)";

        private Dictionary<string, ConcurrentDictionary<Type, CallAutomationEventBase>> _eventstore;
        private ConcurrentDictionary<string, string> _incomingcontextstore;
        private RecordedEventListener _recordedEventListener;
        private HttpPipeline _pipeline;

#pragma warning disable CS8618
        public CallAutomationClientAutomatedLiveTestsBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
#pragma warning restore CS8618
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
            SanitizedHeaders.Add("X-FORWARDED-HOST");
            SanitizedHeaders.Add("Repeatability-Request-ID");
            SanitizedHeaders.Add("Repeatability-First-Sent");
            JsonPathSanitizers.Add("$..id");
            JsonPathSanitizers.Add("$..rawId");
            JsonPathSanitizers.Add("$..value");
            JsonPathSanitizers.Add("$..botAppId");
            JsonPathSanitizers.Add("$..ivrContext");
            JsonPathSanitizers.Add("$..dialog.botAppId");
            BodyKeySanitizers.Add(new BodyKeySanitizer(@"https://sanitized.skype.com/api/servicebuscallback/events?q=SanitizedSanitized") { JsonPath = "..callbackUri" });
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(TestDispatcherRegEx, "https://sanitized.skype.com"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(URIDomainRegEx, "https://sanitized.skype.com"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(TestDispatcherQNameRegEx, SanitizeValue));
        }

        [SetUp]
        public void TestSetup()
        {
            _eventstore = new Dictionary<string, ConcurrentDictionary<Type, CallAutomationEventBase>>();
            _incomingcontextstore = new ConcurrentDictionary<string, string>();
            _recordedEventListener = new RecordedEventListener(Mode, GetSessionFilePath(), CreateServiceBusClient);

            _pipeline = BuildHttpPipeline();

#pragma warning disable CS8622
            _recordedEventListener.CollectionChanged += RecordedEventListenerOnCollectionChanged;
#pragma warning disable CS8622
            if (Mode == RecordedTestMode.Playback)
            {
                // when in playback, pre-load all recorded events into event store
                _recordedEventListener.InitializePlayerForPlayback();
            }
        }

        [TearDown]
        public async Task CleanUp()
        {
            try
            {
                await _recordedEventListener.DisposeAsync();
                _eventstore.Clear();
                _incomingcontextstore.Clear();
                await Task.CompletedTask;
            }
            catch
            { }
        }

        public bool SkipCallingServerInteractionLiveTests
            => TestEnvironment.Mode != RecordedTestMode.Playback && Environment.GetEnvironmentVariable("SKIP_CALLINGSERVER_INTERACTION_LIVE_TESTS")== "TRUE";

        /// <summary>
        /// Creates a <see cref="CallAutomationClient" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallAutomationClient" />.</returns>
        protected CallAutomationClient CreateInstrumentedCallAutomationClientWithConnectionString(CommunicationUserIdentifier? source = null)
        {
            var connectionString = TestEnvironment.LiveTestStaticConnectionString;

            CallAutomationClient callAutomationClient;
            if (TestEnvironment.PMAEndpoint == null || TestEnvironment.PMAEndpoint.Length == 0)
            {
                callAutomationClient = new CallAutomationClient(connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs(source));
            }
            else
            {
                callAutomationClient = new CallAutomationClient(new Uri(TestEnvironment.PMAEndpoint), connectionString, CreateServerCallingClientOptionsWithCorrelationVectorLogs(source));
            }

            return InstrumentClient(callAutomationClient);
        }

        protected async Task<string> ServiceBusWithNewCall(CommunicationIdentifier caller, CommunicationIdentifier reciever)
        {
            string callerId = ParseIdsFromIdentifier(caller);
            string recieverId = ParseIdsFromIdentifier(reciever);
            string uniqueId = callerId + recieverId;
            await _recordedEventListener.ServiceBusWithNewCall(
                queueNameDelegate: () => uniqueId,
                registerCallback: () => RegisterCallBackWithDispatcher(uniqueId));

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
                    InstrumentClientOptions(new CommunicationIdentityClientOptions(CommunicationIdentityClientOptions.ServiceVersion.V2023_10_01))));

        protected async Task<CommunicationUserIdentifier> CreateIdentityUserAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            return await communicationIdentityClient.CreateUserAsync().ConfigureAwait(false);
        }

        protected async Task WaitForOperationCompletion(int milliSeconds = 10000)
        {
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
                await Task.Delay(milliSeconds);
        }

        protected async Task CleanUpCall(CallAutomationClient client, string? callConnectionId)
        {
            try
            {
                if (!string.IsNullOrEmpty(callConnectionId))
                {
                    if (Mode != RecordedTestMode.Playback)
                    {
                        using (Recording.DisableRecording())
                        {
                            await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Creates a <see cref="CallAutomationClientOptions" />
        /// </summary>
        /// <returns>The instrumented <see cref="CallAutomationClientOptions" />.</returns>
        private CallAutomationClientOptions CreateServerCallingClientOptionsWithCorrelationVectorLogs(CommunicationUserIdentifier? source = null)
        {
            CallAutomationClientOptions callClientOptions = new CallAutomationClientOptions() { Source = source };
            callClientOptions.Diagnostics.LoggedHeaderNames.Add("MS-CV");
            return InstrumentClientOptions(callClientOptions);
        }

        private void RecordedEventListenerOnCollectionChanged(object sender, RecordedEventArgs recordedEventArgs)
        {
            HandleServiceBusReceivedMessage(recordedEventArgs.ReceivedMessage);
        }

        private void HandleServiceBusReceivedMessage(RecordedServiceBusReceivedMessage receivedMessage)
        {
            string body = receivedMessage.Body.ToString();

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
                    if (Mode == RecordedTestMode.Playback)
                    {
                        return "Sanitized";
                    }
                    else
                    {
                        /* Change the plus + sign to it's unicode without the special characters i.e. u002B.
                         * It's required because the dispacther app receives the incoming call context for pstn call
                         * with the + as unicode in it and builds the topic id with it to send the event.*/
                        return RemoveAllNonChar(((PhoneNumberIdentifier)inputIdentifier).RawId).Insert(1, "u002B");
                    }
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

        private HttpPipeline BuildHttpPipeline()
        {
            var clientOptions = CreateServerCallingClientOptionsWithCorrelationVectorLogs();
            return clientOptions.CustomBuildHttpPipeline(
                ConnectionString.Parse(TestEnvironment.LiveTestStaticConnectionString));
        }

        private HttpMessage CreateRegisterCallbackWithDispatcherRequest(string uniqueId)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;

            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(TestEnvironment.DispatcherEndpoint, false);
            uri.AppendPath("/api/servicebuscallback/subscribe", false);
            uri.AppendQuery("q", uniqueId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            return message;
        }

        private async Task RegisterCallBackWithDispatcher(string uniqueId)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                // this value has been sanitized in recording using URIRegexSanitizer
                uniqueId = SanitizeValue;
            }

            using var message = CreateRegisterCallbackWithDispatcherRequest(uniqueId);
            await _pipeline.SendAsync(message, CancellationToken.None).ConfigureAwait(false);
            var response = message.Response;
            if (response.IsError)
            {
                throw new RequestFailedException(response);
            }
        }

        private HttpMessage CreateDeRegisterCallBackWithDispatcherRequest(IEnumerable<string> ids)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;

            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(TestEnvironment.DispatcherEndpoint, false);
            uri.AppendPath("/api/servicebuscallback/unsubscribe", false);

            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");

            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(ids);
            request.Content = content;
            return message;
        }

        private async Task DeRegisterCallBackWithDispatcher()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                // Skip when playback
                return;
            }
            using var message = CreateDeRegisterCallBackWithDispatcherRequest(_recordedEventListener.ActiveQueues);
            await _pipeline.SendAsync(message, CancellationToken.None).ConfigureAwait(false);
            var response = message.Response;
            if (response.IsError)
            {
                throw new RequestFailedException(response);
            }
        }

        private ServiceBusClient CreateServiceBusClient()
        {
            var serviceBusClient = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString,
                new ServiceBusClientOptions() { TransportType = ServiceBusTransportType.AmqpWebSockets });
            return InstrumentClient(serviceBusClient);
        }
    }
}
