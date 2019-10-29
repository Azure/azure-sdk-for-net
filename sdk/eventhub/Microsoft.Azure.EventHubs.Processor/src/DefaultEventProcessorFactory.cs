// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    class DefaultEventProcessorFactory<TEventProcessor> : IEventProcessorFactory
        where TEventProcessor : IEventProcessor, new()
    {
        readonly TEventProcessor instance;

        public DefaultEventProcessorFactory()
        {
        }

        public DefaultEventProcessorFactory(TEventProcessor instance)
        {
            this.instance = instance;
        }

        public IEventProcessor CreateEventProcessor(PartitionContext context)
        {
            if (this.instance == null)
            {
                return new TEventProcessor();
            }

            return this.instance;
        }
    }
}