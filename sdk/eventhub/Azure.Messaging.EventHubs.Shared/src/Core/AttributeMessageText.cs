// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   The set of common message text used in attributes,
    ///   which are unable to be represented in the shared
    ///   resources due to the constraint of needing to be
    ///   defined as a constant.
    /// </summary>
    ///
    internal static class AttributeMessageText
    {
        /// <summary>
        ///   The message text detailing numeric offset deprecation.
        /// </summary>
        ///
        public const string LongOffsetOffsetPropertyObsolete = "The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use 'OffsetString' instead.";

        /// <summary>
        ///   The message text detailing numeric offset deprecation.
        /// </summary>
        ///
        public const string LongOffsetOffsetParameterObsolete = "The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use the overload with a string-based offset instead.";

        /// <summary>
        ///   The message text detailing numeric offset deprecation.
        /// </summary>
        ///
        public const string LongLastEnqueuedOffsetOffsetObsolete = "The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Please use 'LastEnqueuedOffsetString' instead.";

        /// <summary>
        ///   The message text detailing numeric offset deprecation for the checkpoint-related operations.
        /// </summary>
        ///
        public const string LongOffsetCheckpointObsolete = "The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset instead.";

        /// <summary>
        ///   The message text detailing numeric offset deprecation for the checkpoint-related operations.
        /// </summary>
        ///
        public const string LongOffsetUpdateCheckpointObsolete = "The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Checkpoints created from a numeric offset may not work in all cases going forward. Please use a string-based offset via the overload accepting 'CheckpointPosition' instead.";

        /// <summary>
        ///   The message text detailing numeric offset deprecation when positioning readers.
        /// </summary>
        ///
        public const string LongOffsetEventPositionObsolete = "The Event Hubs service does not guarantee a numeric offset for all resource configurations.  Reading events using a numeric offset may not work in all cases going forward. Please use a string-based offset instead.";

        /// <summary>
        ///   The message text detailing sequence-only checkpoints for processors.
        /// </summary>
        ///
        public const string SequenceNumberOnlyCheckpointObsolete = "The Event Hubs service does not guarantee that a sequence number-only checkpoint can access the event stream for all resource configurations.  Reading events may not work in all cases going forward. Please provide a string-based offset.";
    }
}
