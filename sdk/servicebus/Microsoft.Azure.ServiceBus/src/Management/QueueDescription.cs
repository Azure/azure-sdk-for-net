// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// Represents the metadata description of the queue.
    /// </summary>
    public class QueueDescription : IEquatable<QueueDescription>
    {
        internal TimeSpan duplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1);
        internal string path;
        internal bool? internalSupportOrdering = null;
        TimeSpan lockDuration = TimeSpan.FromSeconds(60);
        TimeSpan defaultMessageTimeToLive = TimeSpan.MaxValue;
        TimeSpan autoDeleteOnIdle = TimeSpan.MaxValue;
        int maxDeliveryCount = 10;
        string forwardTo = null;
        string forwardDeadLetteredMessagesTo = null;
        string userMetadata = null;

        /// <summary>
        /// Initializes a new instance of QueueDescription class with the specified relative path.
        /// </summary>
        /// <param name="path">Path of the queue relative to the namespace base address.</param>
        public QueueDescription(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Path of the queue relative to the namespace base address.
        /// </summary>
        /// <remarks>Max length is 260 chars. Cannot start or end with a slash.
        /// Cannot have restricted characters: '@','?','#','*'</remarks>
        public string Path
        {
            get => this.path;
            set
            {
                EntityNameHelper.CheckValidQueueName(value, nameof(Path));
                this.path = value;
            }
        }

        /// <summary>
        /// Duration of a peek lock receive. i.e., the amount of time that the message is locked by a given receiver so that
        /// no other receiver receives the same message.
        /// </summary>
        /// <remarks>Max value is 5 minutes. Default value is 60 seconds.</remarks>
        public TimeSpan LockDuration
        {
            get => this.lockDuration;
            set
            {
                TimeoutHelper.ThrowIfNonPositiveArgument(value, nameof(LockDuration));
                this.lockDuration = value;
            }
        }

        /// <summary>
        /// The maximum size of the queue in megabytes, which is the size of memory allocated for the queue.
        /// </summary>
        /// <remarks>Default value is 1024.</remarks>
        public long MaxSizeInMB { get; set; } = 1024;

        /// <summary>
        /// This value indicates if the queue requires guard against duplicate messages. If true, duplicate messages having same
        /// <see cref="Message.MessageId"/> and sent to queue within duration of <see cref="DuplicateDetectionHistoryTimeWindow"/>
        /// will be discarded.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool RequiresDuplicateDetection { get; set; } = false;

        /// <summary>
        /// This indicates whether the queue supports the concept of session. Sessionful-messages follow FIFO ordering.
        /// </summary>
        /// <remarks>
        /// If true, the receiver can only receive messages using <see cref="SessionClient.AcceptMessageSessionAsync()"/>.
        /// Defaults to false.
        /// </remarks>
        public bool RequiresSession { get; set; } = false;

        /// <summary>
        /// The default time to live value for the messages. This is the duration after which the message expires, starting from when
        /// the message is sent to Service Bus. </summary>
        /// <remarks>
        /// This is the default value used when <see cref="Message.TimeToLive"/> is not set on a
        ///  message itself. Messages older than their TimeToLive value will expire and no longer be retained in the message store.
        ///  Subscribers will be unable to receive expired messages.
        ///  Default value is <see cref="TimeSpan.MaxValue"/>.
        ///  </remarks>
        public TimeSpan DefaultMessageTimeToLive
        {
            get => this.defaultMessageTimeToLive;
            set
            {
                if (value < ManagementClientConstants.MinimumAllowedTimeToLive || value > ManagementClientConstants.MaximumAllowedTimeToLive)
                {
                    throw new ArgumentOutOfRangeException(nameof(DefaultMessageTimeToLive),
                        $"The value must be between {ManagementClientConstants.MinimumAllowedTimeToLive} and {ManagementClientConstants.MaximumAllowedTimeToLive}");
                }

                this.defaultMessageTimeToLive = value;
            }
        }

        /// <summary>
        /// The <see cref="TimeSpan"/> idle interval after which the queue is automatically deleted.
        /// </summary>
        /// <remarks>The minimum duration is 5 minutes. Default value is <see cref="TimeSpan.MaxValue"/>.</remarks>
        public TimeSpan AutoDeleteOnIdle
        {
            get => this.autoDeleteOnIdle;
            set
            {
                if (value < ManagementClientConstants.MinimumAllowedAutoDeleteOnIdle)
                {
                    throw new ArgumentOutOfRangeException(nameof(AutoDeleteOnIdle),
                        $"The value must be greater than {ManagementClientConstants.MinimumAllowedAutoDeleteOnIdle}");
                }

                this.autoDeleteOnIdle = value;
            }
        }

        /// <summary>
        /// Indicates whether this queue has dead letter support when a message expires.
        /// </summary>
        /// <remarks>If true, the expired messages are moved to dead-letter sub-queue. Default value is false.</remarks>
        public bool EnableDeadLetteringOnMessageExpiration { get; set; } = false;

        /// <summary>
        /// The <see cref="TimeSpan"/> duration of duplicate detection history that is maintained by the service.
        /// </summary>
        /// <remarks>
        /// The default value is 1 minute. Max value is 7 days and minimum is 20 seconds.
        /// </remarks>
        public TimeSpan DuplicateDetectionHistoryTimeWindow
        {
            get => this.duplicateDetectionHistoryTimeWindow;
            set
            {
                if (value < ManagementClientConstants.MinimumDuplicateDetectionHistoryTimeWindow || value > ManagementClientConstants.MaximumDuplicateDetectionHistoryTimeWindow)
                {
                    throw new ArgumentOutOfRangeException(nameof(DuplicateDetectionHistoryTimeWindow),
                        $"The value must be between {ManagementClientConstants.MinimumDuplicateDetectionHistoryTimeWindow} and {ManagementClientConstants.MaximumDuplicateDetectionHistoryTimeWindow}");
                }

                this.duplicateDetectionHistoryTimeWindow = value;
            }
        }

        /// <summary>
        /// The maximum delivery count of a message before it is dead-lettered.
        /// </summary>
        /// <remarks>The delivery count is increased when a message is received in <see cref="ReceiveMode.PeekLock"/> mode
        /// and didn't complete the message before the message lock expired.
        /// Default value is 10. Minimum value is 1.</remarks>
        public int MaxDeliveryCount
        {
            get => this.maxDeliveryCount;
            set
            {
                if (value < ManagementClientConstants.MinAllowedMaxDeliveryCount)
                {
                    throw new ArgumentOutOfRangeException(nameof(MaxDeliveryCount),
                        $"The value must be greater than {ManagementClientConstants.MinAllowedMaxDeliveryCount}");
                }

                this.maxDeliveryCount = value;
            }
        }

        /// <summary>
        /// Indicates whether server-side batched operations are enabled.
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        public bool EnableBatchedOperations { get; set; } = true;

        /// <summary>
        /// The <see cref="AuthorizationRules"/> on the queue to control user access at entity level.
        /// </summary>
        public AuthorizationRules AuthorizationRules { get; internal set; } = new AuthorizationRules();

        /// <summary>
        /// The current status of the queue (Enabled / Disabled).
        /// </summary>
        /// <remarks>When an entity is disabled, that entity cannot send or receive messages.</remarks>
        public EntityStatus Status { get; set; } = EntityStatus.Active;

        /// <summary>
        /// The path of the recipient entity to which all the messages sent to the queue are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive messages from this queue. The destination entity
        /// must be an already existing entity.</remarks>
        public string ForwardTo
        {
            get => this.forwardTo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.forwardTo = value;
                    return;
                }

                EntityNameHelper.CheckValidQueueName(value, nameof(ForwardTo));
                if (this.path.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                this.forwardTo = value;
            }
        }

        /// <summary>
        /// The path of the recipient entity to which all the dead-lettered messages of this queue are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive dead-lettered messages from this queue. The destination
        /// entity must already exist.</remarks>
        public string ForwardDeadLetteredMessagesTo
        {
            get => this.forwardDeadLetteredMessagesTo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.forwardDeadLetteredMessagesTo = value;
                    return;
                }

                EntityNameHelper.CheckValidQueueName(value, nameof(ForwardDeadLetteredMessagesTo));
                if (this.path.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                this.forwardDeadLetteredMessagesTo = value;
            }
        }

        /// <summary>
        /// Indicates whether the queue is to be partitioned across multiple message brokers.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool EnablePartitioning { get; set; } = false;

        /// <summary>
        /// Custom metdata that user can associate with the description.
        /// </summary>
        /// <remarks>Cannot be null. Max length is 1024 chars.</remarks>
        public string UserMetadata
        {
            get => this.userMetadata;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(UserMetadata), $"Value cannot be null");
                }

                if (value.Length > ManagementClientConstants.MaxUserMetadataLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(UserMetadata), $"Length cannot cross {ManagementClientConstants.MaxUserMetadataLength} characters");
                }

                this.userMetadata = value;
            }
        }

        internal bool IsAnonymousAccessible { get; set; } = false;

        internal bool SupportOrdering
        { 
            get
            {
                return this.internalSupportOrdering ?? !this.EnablePartitioning;
            }
            set
            {
                this.internalSupportOrdering = value;
            }
        }

        internal bool EnableExpress { get; set; } = false;

        /// <summary>
        /// List of properties that were retrieved using GetQueue but are not understood by this version of client is stored here.
        /// The list will be sent back when an already retrieved QueueDescription will be used in UpdateQueue call.
        /// </summary>
        internal List<XElement> UnknownProperties { get; set; }

        public override int GetHashCode()
        {
            return this.Path?.GetHashCode() ?? base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as QueueDescription;
            return this.Equals(other);
        }

        public bool Equals(QueueDescription otherDescription)
        {
            if (otherDescription is QueueDescription other
                && this.Path.Equals(other.Path, StringComparison.OrdinalIgnoreCase)
                && this.AutoDeleteOnIdle.Equals(other.AutoDeleteOnIdle)
                && this.DefaultMessageTimeToLive.Equals(other.DefaultMessageTimeToLive)
                && (!this.RequiresDuplicateDetection || this.DuplicateDetectionHistoryTimeWindow.Equals(other.DuplicateDetectionHistoryTimeWindow))
                && this.EnableBatchedOperations == other.EnableBatchedOperations
                && this.EnableDeadLetteringOnMessageExpiration == other.EnableDeadLetteringOnMessageExpiration
                && this.EnablePartitioning == other.EnablePartitioning
                && string.Equals(this.ForwardDeadLetteredMessagesTo, other.ForwardDeadLetteredMessagesTo, StringComparison.OrdinalIgnoreCase)
                && string.Equals(this.ForwardTo, other.ForwardTo, StringComparison.OrdinalIgnoreCase)
                && this.LockDuration.Equals(other.LockDuration)
                && this.MaxDeliveryCount == other.MaxDeliveryCount
                && this.MaxSizeInMB == other.MaxSizeInMB
                && this.RequiresDuplicateDetection.Equals(other.RequiresDuplicateDetection)
                && this.RequiresSession.Equals(other.RequiresSession)
                && this.Status.Equals(other.Status)
                && this.SupportOrdering.Equals(other.SupportOrdering)
                && this.EnableExpress == other.EnableExpress
                && this.IsAnonymousAccessible == other.IsAnonymousAccessible
                && string.Equals(this.userMetadata, other.userMetadata, StringComparison.OrdinalIgnoreCase)
                && (this.AuthorizationRules != null && other.AuthorizationRules != null
                    || this.AuthorizationRules == null && other.AuthorizationRules == null)
                && (this.AuthorizationRules == null || this.AuthorizationRules.Equals(other.AuthorizationRules)))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(QueueDescription o1, QueueDescription o2)
        {
            if (ReferenceEquals(o1, o2))
            {
                return true;
            }

            if (ReferenceEquals(o1, null) || ReferenceEquals(o2, null))
            {
                return false;
            }

            return o1.Equals(o2);
        }

        public static bool operator !=(QueueDescription o1, QueueDescription o2)
        {
            return !(o1 == o2);
        }
    }
}
