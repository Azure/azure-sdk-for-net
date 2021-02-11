// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Represents the static properties of the topic.
    /// </summary>
    public class TopicProperties : IEquatable<TopicProperties>
    {
        private TimeSpan _duplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1);
        private string _name;
        private TimeSpan _defaultMessageTimeToLive = TimeSpan.MaxValue;
        private TimeSpan _autoDeleteOnIdle = TimeSpan.MaxValue;
        private string _userMetadata;

        /// <summary>
        /// Initializes a new instance of TopicDescription class with the specified relative name.
        /// </summary>
        /// <param name="name">Name of the topic relative to the namespace base address.</param>
        internal TopicProperties(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of TopicProperties from the provided options.
        /// </summary>
        /// <param name="options">Options used to create the properties instance.</param>
        internal TopicProperties(CreateTopicOptions options)
        {
            Name = options.Name;
            MaxSizeInMegabytes = options.MaxSizeInMegabytes;
            RequiresDuplicateDetection = options.RequiresDuplicateDetection;
            DefaultMessageTimeToLive = options.DefaultMessageTimeToLive;
            AutoDeleteOnIdle = options.AutoDeleteOnIdle;
            DuplicateDetectionHistoryTimeWindow = options.DuplicateDetectionHistoryTimeWindow;
            EnableBatchedOperations = options.EnableBatchedOperations;
            AuthorizationRules = options.AuthorizationRules;
            Status = options.Status;
            EnableBatchedOperations = options.EnableBatchedOperations;
            EnablePartitioning = options.EnablePartitioning;
            if (options.UserMetadata != null)
            {
                UserMetadata = options.UserMetadata;
            }
        }

        /// <summary>
        /// The default time to live value for the messages. This is the duration after which the message expires, starting from when
        /// the message is sent to Service Bus. </summary>
        /// <remarks>
        /// This is the default value used when <see cref="ServiceBusMessage.TimeToLive"/> is not set on a
        ///  message itself. Messages older than their TimeToLive value will expire and no longer be retained in the message store.
        ///  Subscribers will be unable to receive expired messages.
        ///  Default value is <see cref="TimeSpan.MaxValue"/>.
        ///  </remarks>
        public TimeSpan DefaultMessageTimeToLive
        {
            get => _defaultMessageTimeToLive;
            set
            {
                Argument.AssertInRange(
                    value,
                    AdministrationClientConstants.MinimumAllowedTimeToLive,
                    AdministrationClientConstants.MaximumAllowedTimeToLive,
                    nameof(DefaultMessageTimeToLive));

                _defaultMessageTimeToLive = value;
            }
        }

        /// <summary>
        /// The <see cref="TimeSpan"/> idle interval after which the topic is automatically deleted.
        /// </summary>
        /// <remarks>The minimum duration is 5 minutes. Default value is <see cref="TimeSpan.MaxValue"/>.</remarks>
        public TimeSpan AutoDeleteOnIdle
        {
            get => _autoDeleteOnIdle;
            set
            {
                Argument.AssertAtLeast(
                    value,
                    AdministrationClientConstants.MinimumAllowedAutoDeleteOnIdle,
                    nameof(AutoDeleteOnIdle));

                _autoDeleteOnIdle = value;
            }
        }

        /// <summary>
        /// The maximum size of the topic in megabytes, which is the size of memory allocated for the topic.
        /// </summary>
        /// <remarks>Default value is 1024.</remarks>
        public long MaxSizeInMegabytes { get; set; } = 1024;

        /// <summary>
        /// This value indicates if the topic requires guard against duplicate messages. If true, duplicate messages having same
        /// <see cref="ServiceBusMessage.MessageId"/> and sent to topic within duration of <see cref="DuplicateDetectionHistoryTimeWindow"/>
        /// will be discarded.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool RequiresDuplicateDetection { get; set; }

        /// <summary>
        /// The <see cref="TimeSpan"/> duration of duplicate detection history that is maintained by the service.
        /// </summary>
        /// <remarks>
        /// The default value is 1 minute. Max value is 7 days and minimum is 20 seconds.
        /// </remarks>
        public TimeSpan DuplicateDetectionHistoryTimeWindow
        {
            get => _duplicateDetectionHistoryTimeWindow;
            set
            {
                Argument.AssertInRange(
                    value,
                    AdministrationClientConstants.MinimumDuplicateDetectionHistoryTimeWindow,
                    AdministrationClientConstants.MaximumDuplicateDetectionHistoryTimeWindow,
                    nameof(DuplicateDetectionHistoryTimeWindow));

                _duplicateDetectionHistoryTimeWindow = value;
            }
        }

        /// <summary>
        /// Name of the topic relative to the namespace base address.
        /// </summary>
        /// <remarks>Max length is 260 chars. Cannot start or end with a slash.
        /// Cannot have restricted characters: '@','?','#','*'</remarks>
        public string Name
        {
            get => _name;
            set
            {
                EntityNameFormatter.CheckValidTopicName(value, nameof(Name));
                _name = value;
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
        public bool EnablePartitioning { get; set; }

        /// <summary>
        /// Defines whether ordering needs to be maintained. If true, messages sent to topic will be
        /// forwarded to the subscription in order.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool SupportOrdering { get; set; }

        /// <summary>
        /// Indicates whether server-side batched operations are enabled.
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        public bool EnableBatchedOperations { get; set; } = true;

        /// <summary>
        /// Custom metadata that user can associate with the description.
        /// </summary>
        /// <remarks>Cannot be null. Max length is 1024 chars.</remarks>
        public string UserMetadata
        {
            get => _userMetadata;
            set
            {
                Argument.AssertNotNull(value, nameof(UserMetadata));
                Argument.AssertNotTooLong(
                    value,
                    AdministrationClientConstants.MaxUserMetadataLength,
                    nameof(UserMetadata));

                _userMetadata = value;
            }
        }

        internal bool IsAnonymousAccessible { get; set; }

        internal bool FilteringMessagesBeforePublishing { get; set; }

        internal string ForwardTo { get; set; }

        internal bool EnableExpress { get; set; }

        internal bool EnableSubscriptionPartitioning { get; set; }

        /// <summary>
        /// List of properties that were retrieved using GetTopic but are not understood by this version of client is stored here.
        /// The list will be sent back when an already retrieved TopicDescription will be used in UpdateTopic call.
        /// </summary>
        internal List<XElement> UnknownProperties { get; set; }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? base.GetHashCode();
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public override bool Equals(object obj)
        {
            var other = obj as TopicProperties;
            return Equals(other);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public bool Equals(TopicProperties other)
        {
            if (other is TopicProperties otherDescription
                && Name.Equals(otherDescription.Name, StringComparison.OrdinalIgnoreCase)
                && AutoDeleteOnIdle.Equals(otherDescription.AutoDeleteOnIdle)
                && DefaultMessageTimeToLive.Equals(otherDescription.DefaultMessageTimeToLive)
                && (!RequiresDuplicateDetection || DuplicateDetectionHistoryTimeWindow.Equals(otherDescription.DuplicateDetectionHistoryTimeWindow))
                && EnableBatchedOperations == otherDescription.EnableBatchedOperations
                && EnablePartitioning == otherDescription.EnablePartitioning
                && MaxSizeInMegabytes == otherDescription.MaxSizeInMegabytes
                && RequiresDuplicateDetection.Equals(otherDescription.RequiresDuplicateDetection)
                && Status.Equals(otherDescription.Status)
                && string.Equals(_userMetadata, otherDescription._userMetadata, StringComparison.OrdinalIgnoreCase)
                && string.Equals(ForwardTo, other.ForwardTo, StringComparison.OrdinalIgnoreCase)
                && EnableExpress == other.EnableExpress
                && IsAnonymousAccessible == other.IsAnonymousAccessible
                && FilteringMessagesBeforePublishing == other.FilteringMessagesBeforePublishing
                && EnableSubscriptionPartitioning == other.EnableSubscriptionPartitioning
                && (AuthorizationRules != null && otherDescription.AuthorizationRules != null
                    || AuthorizationRules == null && otherDescription.AuthorizationRules == null)
                && (AuthorizationRules == null || AuthorizationRules.Equals(otherDescription.AuthorizationRules)))
            {
                return true;
            }

            return false;
        }

        /// <summary></summary>
        public static bool operator ==(TopicProperties left, TopicProperties right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary></summary>
        public static bool operator !=(TopicProperties left, TopicProperties right)
        {
            return !(left == right);
        }
    }
}
