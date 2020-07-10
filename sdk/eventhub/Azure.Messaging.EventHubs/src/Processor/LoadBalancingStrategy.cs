// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Processor
{
    /// <summary>
    ///   The strategy that an event processor will use to make decisions about
    ///   partition ownership when performing load balancing to share work with
    ///   other event processors.
    /// </summary>
    ///
    public enum LoadBalancingStrategy
    {
        /// <summary>
        ///   An event processor will take a measured approach to requesting
        ///   partition ownership when balancing work with other processors, slowly
        ///   claiming partitions until a stabilized distribution is achieved.
        ///
        ///   <para>When using this strategy, it may take longer for all partitions of
        ///   an Event Hub to be owned by a processor when processing first starts, the
        ///   number of active processors changes, or when partitions are scaled.  The
        ///   Balanced strategy will reduce contention for a partition, ensuring that once
        ///   it is claimed, processing will be more likely to be steady and consistent.</para>
        /// </summary>
        ///
        Balanced,

        /// <summary>
        ///   An event processor will attempt to claim ownership of its fair share of
        ///   partitions aggressively when balancing work with other processors.
        ///
        ///   <para>When using this strategy, all partitions of an Event Hub will be claimed
        ///   quickly when processing first starts, the number of active processors changes, or
        ///   when partitions are scaled.  The Greedy strategy is likely to cause competition for
        ///   ownership of a given partition, causing it to see sporadic processing and some amount of
        ///   duplicate events until balance has been reached and work is distributed equally among the
        ///   active processors.</para>
        /// </summary>
        ///
        Greedy
    }
}
