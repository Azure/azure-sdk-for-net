// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Processor
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.Processor;

    class TestEventProcessor : IEventProcessor
    {
        public event EventHandler<PartitionContext> OnOpen;
        public event EventHandler<Tuple<PartitionContext, CloseReason>> OnClose;
        public event EventHandler<Tuple<PartitionContext, ReceivedEventArgs>> OnProcessEvents;
        public event EventHandler<Tuple<PartitionContext, Exception>> OnProcessError;

        Task IEventProcessor.CloseAsync(PartitionContext context, CloseReason reason)
        {
            this.OnClose?.Invoke(this, new Tuple<PartitionContext, CloseReason>(context, reason));
            return Task.CompletedTask;
        }

        Task IEventProcessor.ProcessErrorAsync(PartitionContext context, Exception error)
        {
            this.OnProcessError?.Invoke(this, new Tuple<PartitionContext, Exception>(context, error));
            return Task.CompletedTask;
        }

        Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> events)
        {
            var eventsArgs = new ReceivedEventArgs();
            eventsArgs.events = events;
            this.OnProcessEvents?.Invoke(this, new Tuple<PartitionContext, ReceivedEventArgs>(context, eventsArgs));
            EventData lastEvent = events?.LastOrDefault();

            // Checkpoint with last event?
            if (eventsArgs.checkPointLastEvent && lastEvent != null)
            {
                return context.CheckpointAsync(lastEvent);
            }

            // Checkpoint batch? This should checkpoint with last message delivered.
            else if (eventsArgs.checkPointBatch)
            {
                return context.CheckpointAsync();
            }

            // No checkpoint? Then just return CompletedTask
            return Task.CompletedTask;
        }

        Task IEventProcessor.OpenAsync(PartitionContext context)
        {
            this.OnOpen?.Invoke(this, context);
            return Task.CompletedTask;
        }
    }

    class SecondTestEventProcessor : IEventProcessor
    {
        Task IEventProcessor.CloseAsync(PartitionContext context, CloseReason reason)
        {
            return Task.CompletedTask;
        }

        Task IEventProcessor.ProcessErrorAsync(PartitionContext context, Exception error)
        {
            return Task.CompletedTask;
        }

        Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> events)
        {
            return Task.CompletedTask;
        }

        Task IEventProcessor.OpenAsync(PartitionContext context)
        {
            return Task.CompletedTask;
        }
    }

    class TestEventProcessorFactory : IEventProcessorFactory
    {
        public event EventHandler<Tuple<PartitionContext, TestEventProcessor>> OnCreateProcessor;

        IEventProcessor IEventProcessorFactory.CreateEventProcessor(PartitionContext context)
        {
            var processor = new TestEventProcessor();
            this.OnCreateProcessor?.Invoke(this, new Tuple<PartitionContext, TestEventProcessor>(context, processor));
            return processor;
        }

        public static void ErrorNotificationHandler(ExceptionReceivedEventArgs t)
        {
            String identifier = "Host:" + t.Hostname + "Partition:" + t.PartitionId + " Action:" + t.Action;
            var log = string.Format("{0} Exception caught (Identifier: {0}): {1}", identifier, t.Exception);
            Debug.WriteLine(log);
            Console.WriteLine(log);
        }
    }

    class ReceivedEventArgs
    {
        public IEnumerable<EventData> events;
        public bool checkPointLastEvent = true;
        public bool checkPointBatch = false;
    }
}
