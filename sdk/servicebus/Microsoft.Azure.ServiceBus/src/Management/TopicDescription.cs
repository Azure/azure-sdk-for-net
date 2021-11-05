// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the metadata description of the topic.
    /// </summary>
    public class TopicDescription : IEquatable<TopicDescription>
    {
        internal TimeSpan duplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1);
        internal string path;
        TimeSpan defaultMessageTimeToLive = TimeSpan.MaxValue;
        TimeSpan autoDeleteOnIdle = TimeSpan.MaxValue;
        string userMetadata = null;

        /// <summary>
        /// Initializes a new instance of TopicDescription class with the specified relative path.
        /// </summary>
        /// <param name="path">Path of the topic relative to the namespace base address.</param>
        public TopicDescription(string path)
        {
            this.Path = path;
        }

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
        /// The <see cref="TimeSpan"/> idle interval after which the topic is automatically deleted.
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
        /// The maximum size of the topic in megabytes, which is the size of memory allocated for the topic.
        /// </summary>
        /// <remarks>Default value is 1024.</remarks>
        public long MaxSizeInMB { get; set; } = 1024;

        /// <summary>
        /// This value indicates if the topic requires guard against duplicate messages. If true, duplicate messages having same
        /// <see cref="Message.MessageId"/> and sent to topic within duration of <see cref="DuplicateDetectionHistoryTimeWindow"/>
        /// will be discarded.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool RequiresDuplicateDetection { get; set; } = false;

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
        /// Path of the topic relative to the namespace base address.
        /// </summary>
        /// <remarks>Max length is 260 chars. Cannot start or end with a slash.
        /// Cannot have restricted characters: '@','?','#','*'</remarks>
        public string Path
        {
            get => this.path;
            set
            {
                EntityNameHelper.CheckValidTopicName(value, nameof(Path));
                this.path = value;
            }
        }

        /// <summary>
        /// The <see cref="AuthorizationRules"/> on the topic to control user access at entity level.
        /// </summary>
        public AuthorizationRules AuthorizationRules { get; internal set; } = new AuthorizationRules();

        /// <summary>
        /// The current status of the topic (Enabled / Disabled).
        /// </summary>
        /// <remarks>When an entity is disabled, that entity cannot send or receive messages.</remarks>
        public EntityStatus Status { get; set; } = EntityStatus.Active;

        /// <summary>
        /// Indicates whether the topic is to be partitioned across multiple message brokers.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool EnablePartitioning { get; set; } = false;

        /// <summary>
        /// Defines whether ordering needs to be maintained. If true, messages sent to topic will be
        /// forwarded to the subscription in order.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool SupportOrdering { get; set; } = false;

        /// <summary>
        /// Indicates whether server-side batched operations are enabled.
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        public bool EnableBatchedOperations { get; set; } = true;

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

        internal bool FilteringMessagesBeforePublishing { get; set; } = false;

        internal string ForwardTo { get; set; } = null;

        internal bool EnableExpress { get; set; } = false;

        internal bool EnableSubscriptionPartitioning { get; set; } = false;

        /// <summary>
        /// List of properties that were retrieved using GetTopic but are not understood by this version of client is stored here.
        /// The list will be sent back when an already retrieved TopicDescription will be used in UpdateTopic call.
        /// </summary>
        internal List<object> UnknownProperties { get; set; }

        public override int GetHashCode()
        {
            return this.Path?.GetHashCode() ?? base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as TopicDescription;
            return this.Equals(other);
        }

        public bool Equals(TopicDescription otherDescription)
        {
            if (otherDescription is TopicDescription other
                && this.Path.Equals(other.Path, StringComparison.OrdinalIgnoreCase)
                && this.AutoDeleteOnIdle.Equals(other.AutoDeleteOnIdle)
                && this.DefaultMessageTimeToLive.Equals(other.DefaultMessageTimeToLive)
                && (!this.RequiresDuplicateDetection || this.DuplicateDetectionHistoryTimeWindow.Equals(other.DuplicateDetectionHistoryTimeWindow))
                && this.EnableBatchedOperations == other.EnableBatchedOperations
                && this.EnablePartitioning == other.EnablePartitioning
                && this.MaxSizeInMB == other.MaxSizeInMB
                && this.RequiresDuplicateDetection.Equals(other.RequiresDuplicateDetection)
                && this.Status.Equals(other.Status)
                && string.Equals(this.userMetadata, other.userMetadata, StringComparison.OrdinalIgnoreCase)
                && string.Equals(this.ForwardTo, other.ForwardTo, StringComparison.OrdinalIgnoreCase)
                && this.EnableExpress == other.EnableExpress
                && this.IsAnonymousAccessible == other.IsAnonymousAccessible
                && this.FilteringMessagesBeforePublishing == other.FilteringMessagesBeforePublishing
                && this.EnableSubscriptionPartitioning == other.EnableSubscriptionPartitioning
                && (this.AuthorizationRules != null && other.AuthorizationRules != null
                    || this.AuthorizationRules == null && other.AuthorizationRules == null)
                && (this.AuthorizationRules == null || this.AuthorizationRules.Equals(other.AuthorizationRules)))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(TopicDescription o1, TopicDescription o2)
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

        public static bool operator !=(TopicDescription o1, TopicDescription o2)
        {
            return !(o1 == o2);
        }
    }
}
