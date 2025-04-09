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
        ///   An event processor will take a slow approach to requesting
        ///   partition ownership when balancing work with other processors, waiting
        ///   until a load balancing cycle is schedule to run, claiming 1 partition
        ///   per cycle until a stabilized distribution is achieved.
        ///
        ///   <para>When using this strategy, it will be considerably longer for all partitions of
        ///   an Event Hub to be owned by a processor when processing first starts, the
        ///   number of active processors changes, or when partitions are scaled.</para>
        ///
        ///   <para>The Balanced strategy is generally not recommended, as it does not provide
        ///   any tangible benefits unless the load balancing interval is set below 10 seconds,
        ///   which is strongly discouraged.  The Balanced strategy mainly exists to ensure backwards
        ///   compatibility with earlier library versions.</para>
        /// </summary>
        ///
        Balanced,

        /// <summary>
        ///   An event processor will attempt to claim ownership of its fair share of
        ///   partitions consistently, claiming 1 partition at a time until work is balanced
        ///   between all active processors.
        ///
        ///   <para>When using this strategy, load balancing cycles run without delay until
        ///   ownership is evenly distributed, ensuring that partitions are processed more quickly
        ///   when processing first starts, the number of active processors changes, or
        ///   when partitions are scaled.</para>
        ///
        ///   <para>The Greedy strategy will not cause additional competition for township of a given
        ///   when compared to other strategies, as it allows claims from other processors to safely
        ///   interleave.  Greedy is the recommended default strategy for processors.</para>
        /// </summary>
        ///
        Greedy
    }
}
