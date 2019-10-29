// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    /// <summary>
    /// Interface that must be implemented by an event processor factory class.
    /// 
    /// <para>User-provided factories are needed if creating an event processor object requires more work than
    /// just a new with a parameterless constructor.</para>
    /// </summary>
    public interface IEventProcessorFactory
    {
        /// <summary>
        /// Method to create instance of <see cref="IEventProcessor"/> given a partition.
        /// </summary>
        /// <param name="context">Partition context information.</param> 
        /// <returns>An instance of <see cref="IEventProcessor"/>.</returns>
        IEventProcessor CreateEventProcessor(PartitionContext context);
    }
}