// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.CallAutomation.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.EventCatcher
{
    internal class RecordedEventListener : IDisposable, IAsyncDisposable
    {
        private RecordedTestMode? _mode;
        private const string RecordingLocation = "SessionRecordedEvents";
        private ServiceBusClient _serviceBusClient;
        private ConcurrentDictionary<string, ServiceBusProcessor> _processorStore;
        private readonly ConcurrentBag<RecordedServiceBusReceivedMessage> _receivedEvents;
        private string _eventSessionFilePath;
        private EventRecordPlayer? _eventRecordPlayer;

        public IEnumerable<RecordedServiceBusReceivedMessage> ReceivedMessages => _receivedEvents;
        public IEnumerable<string> ActiveQueues => _processorStore.Keys;

        public event EventHandler<RecordedEventArgs> CollectionChanged = null!;

        public RecordedEventListener(RecordedTestMode mode, string sessionFilePath, Func<ServiceBusClient> serviceBusClientDelegate)
        {
            _mode = mode;
            _eventSessionFilePath = GetEventSessionFilePath(sessionFilePath);
            _processorStore = new ConcurrentDictionary<string, ServiceBusProcessor>();
            _receivedEvents = new ConcurrentBag<RecordedServiceBusReceivedMessage>();

            _serviceBusClient = serviceBusClientDelegate();
        }

        public async Task ServiceBusWithNewCall(
            Func<string> queueNameDelegate,
            Func<Task> registerCallback)
        {
            var queueName = queueNameDelegate();

            await registerCallback();

            // create a processor that we can use to process the messages
            var processor = _serviceBusClient.CreateProcessor(queueName, new ServiceBusProcessorOptions());

            RegisterMessageHandler(processor);
            RegisterErrorHandler(processor);
            await StartProcessorAsync(processor);

            _processorStore.TryAdd(queueName, processor);
        }

        private async Task AddAndRecordMessage(ProcessMessageEventArgs args)
        {
            await AddMessage(args).ContinueWith(async task => { await RecordMessage(args); });
            await args.CompleteMessageAsync(args.Message);
        }

        private async Task AddMessage(ProcessMessageEventArgs args)
        {
            // add to event store right away
            // no need to block the test while the recording is being written
            var recordedMessage = MessageConverter.ConvertToRecordedMessage(args.Message);
            _receivedEvents.Add(recordedMessage);
            // notify event subscribers
            OnNewServiceBusReceivedMessageAdded(new RecordedEventArgs(recordedMessage));
            await args.CompleteMessageAsync(args.Message);
        }

        public void InitializePlayerForPlayback()
        {
            InitializeEventPlayer();
            _eventRecordPlayer?.SetupForPlayback();

            if (_eventRecordPlayer != null && _eventRecordPlayer.Entries.Any())
            {
                foreach (var entry in _eventRecordPlayer.Entries)
                {
                    _receivedEvents.Add(entry);
                    // notify event subscribers
                    OnNewServiceBusReceivedMessageAdded(new RecordedEventArgs(entry));
                }
            }
        }

        private void InitializeEventPlayer()
        {
            if (_eventRecordPlayer != null)
            {
                return;
            }

            _eventRecordPlayer = new EventRecordPlayer(_eventSessionFilePath);
        }

        private void InitializePlayerForRecord()
        {
            InitializeEventPlayer();
            if (_eventRecordPlayer?.IsRecording == false)
            {
                _eventRecordPlayer?.SetupForRecording();
            }
        }

        private async Task RecordMessage(ProcessMessageEventArgs args)
        {
            InitializePlayerForRecord();
            var recordedMessage = MessageConverter.ConvertToRecordedMessage(args.Message);
            _eventRecordPlayer?.Record(recordedMessage);
            await Task.CompletedTask;
        }

        private void RegisterMessageHandler(ServiceBusProcessor processor)
        {
            switch (_mode)
            {
                // if mode is record: then store in event store + write to file
                case RecordedTestMode.Record:
                    processor.ProcessMessageAsync += AddAndRecordMessage;
                    break;
                // if mode is live: then store in event store - skip write to file
                case RecordedTestMode.Live:
                    processor.ProcessMessageAsync += AddMessage;
                    break;
            }
            // otherwise do nothing
        }

        private void RegisterErrorHandler(ServiceBusProcessor processor)
        {
            processor.ProcessErrorAsync += args =>
            {
                Console.WriteLine($"Processing message failed with message: {args.Exception.Message}");
                return Task.CompletedTask;
            };
        }

        private async Task StartProcessorAsync(ServiceBusProcessor processor)
        {
            if (_mode != RecordedTestMode.Playback)
            {
                await processor.StartProcessingAsync();
            }
        }

        private async Task StopProcessors()
        {
            if (_mode != RecordedTestMode.Playback)
            {
                var listOfTasks = new List<Task>();
                foreach (ServiceBusProcessor processor in _processorStore.Values)
                {
                    listOfTasks.Add(processor.StopProcessingAsync());
                }

                await Task.WhenAll(listOfTasks);
            }
        }

        private static string GetEventSessionFilePath(string testSessionFilePath)
        {
            // replace SessionRecords with directory name of event recordings - it'll be easier to correlate
            var relativeEventSessionFilePath = testSessionFilePath.Replace("SessionRecords", RecordingLocation);

            return Path.Combine(TestEnvironment.RepositoryRoot, relativeEventSessionFilePath);
        }

        // wrapper handler to access internal event store handler
        protected virtual void OnNewServiceBusReceivedMessageAdded(RecordedEventArgs e)
        {
            EventHandler<RecordedEventArgs> handler = CollectionChanged;
            handler?.Invoke(this, e);
            // CollectionChanged?.Invoke(this, e);
        }

        /// <inheritdoc />
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            _eventRecordPlayer?.Dispose();
            await StopProcessors().ConfigureAwait(false);
            _processorStore.Clear();
            await Task.CompletedTask;
        }
    }
}
