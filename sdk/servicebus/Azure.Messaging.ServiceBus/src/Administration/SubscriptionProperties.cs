// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Represents the static properties of the subscription.
    /// </summary>
    public class SubscriptionProperties : IEquatable<SubscriptionProperties>
    {
        private string _topicName, _subscriptionName;
        private TimeSpan _lockDuration = TimeSpan.FromSeconds(60);
        private TimeSpan _defaultMessageTimeToLive = TimeSpan.MaxValue;
        private TimeSpan _autoDeleteOnIdle = TimeSpan.MaxValue;
        private int _maxDeliveryCount = 10;
        private string _forwardTo;
        private string _forwardDeadLetteredMessagesTo;
        private string _userMetadata;

        /// <summary>
        /// Initializes a new instance of SubscriptionDescription class with the specified name and topic name.
        /// </summary>
        /// <param name="topicName">Name of the topic relative to the namespace base address.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        internal SubscriptionProperties(string topicName, string subscriptionName)
        {
            TopicName = topicName;
            SubscriptionName = subscriptionName;
        }

        internal SubscriptionProperties(CreateSubscriptionOptions options)
        {
            TopicName = options.TopicName;
            SubscriptionName = options.SubscriptionName;
            LockDuration = options.LockDuration;
            RequiresSession = options.RequiresSession;
            DefaultMessageTimeToLive = options.DefaultMessageTimeToLive;
            AutoDeleteOnIdle = options.AutoDeleteOnIdle;
            DeadLetteringOnMessageExpiration = options.DeadLetteringOnMessageExpiration;
            EnableDeadLetteringOnFilterEvaluationExceptions = options.EnableDeadLetteringOnFilterEvaluationExceptions;
            MaxDeliveryCount = options.MaxDeliveryCount;
            EnableBatchedOperations = options.EnableBatchedOperations;
            Status = options.Status;
            ForwardTo = options.ForwardTo;
            ForwardDeadLetteredMessagesTo = options.ForwardDeadLetteredMessagesTo;
            if (options.UserMetadata != null)
            {
                UserMetadata = options.UserMetadata;
            }
        }

        /// <summary>
        /// Duration of a peek lock receive. i.e., the amount of time that the message is locked by a given receiver so that
        /// no other receiver receives the same message.
        /// </summary>
        /// <remarks>Max value is 5 minutes. Default value is 60 seconds.</remarks>
        public TimeSpan LockDuration
        {
            get => _lockDuration;
            set
            {
                Argument.AssertPositive(value, nameof(LockDuration));
                _lockDuration = value;
            }
        }

        /// <summary>
        /// This indicates whether the subscription supports the concept of session. Sessionful-messages follow FIFO ordering.
        /// </summary>
        /// <remarks>
        /// If true, the receiver can only receive messages using <see cref="ServiceBusSessionProcessor"/>.
        /// Defaults to false.
        /// </remarks>
        public bool RequiresSession { get; set; }

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
        /// The <see cref="TimeSpan"/> idle interval after which the subscription is automatically deleted.
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
        /// Indicates whether this subscription has dead letter support when a message expires.
        /// </summary>
        /// <remarks>If true, the expired messages are moved to dead-letter subqueue. Default value is false.</remarks>
        public bool DeadLetteringOnMessageExpiration { get; set; }

        /// <summary>
        /// indicates whether messages need to be forwarded to dead-letter sub queue when subscription rule evaluation fails.
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        public bool EnableDeadLetteringOnFilterEvaluationExceptions { get; set; } = true;

        /// <summary>
        /// Name of the topic under which subscription exists.
        /// </summary>
        /// <remarks>Value cannot be null or empty. Value cannot exceed 260 chars. Cannot start or end with a slash.
        /// Cannot have restricted characters: '@','?','#','*'</remarks>
        public string TopicName
        {
            get => _topicName;
            set
            {
                EntityNameFormatter.CheckValidTopicName(value, nameof(TopicName));
                _topicName = value;
            }
        }

        /// <summary>
        /// Name of the subscription.
        /// </summary>
        /// <remarks>Value cannot be null or empty. Value cannot exceed 50 chars.
        /// Cannot have restricted characters: '@','?','#','*','/','\'</remarks>
        public string SubscriptionName
        {
            get => _subscriptionName;
            set
            {
                EntityNameFormatter.CheckValidSubscriptionName(value, nameof(SubscriptionName));
                _subscriptionName = value;
            }
        }

        /// <summary>
        /// The maximum delivery count of a message before it is dead-lettered.
        /// </summary>
        /// <remarks>The delivery count is increased when a message is received in <see cref="ServiceBusReceiveMode.PeekLock"/> mode
        /// and didn't complete the message before the message lock expired.
        /// Default value is 10. Minimum value is 1.</remarks>
        public int MaxDeliveryCount
        {
            get => _maxDeliveryCount;
            set
            {
                Argument.AssertAtLeast(
                    value,
                    AdministrationClientConstants.MinAllowedMaxDeliveryCount,
                    nameof(AutoDeleteOnIdle));

                _maxDeliveryCount = value;
            }
        }

        /// <summary>
        /// The current status of the subscription (Enabled / Disabled).
        /// </summary>
        /// <remarks>When an entity is disabled, that entity cannot send or receive messages.</remarks>
        public EntityStatus Status { get; set; } = EntityStatus.Active;

        /// <summary>
        /// The name of the recipient entity to which all the messages sent to the subscription are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive messages from this subscription. The destination entity
        /// must be an already existing entity.</remarks>
        public string ForwardTo
        {
            get => _forwardTo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _forwardTo = value;
                    return;
                }

                EntityNameFormatter.CheckValidQueueName(value, nameof(ForwardTo));
                if (_topicName.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                _forwardTo = value;
            }
        }

        /// <summary>
        /// The name of the recipient entity to which all the dead-lettered messages of this subscription are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive dead-lettered messages from this subscription. The destination
        /// entity must already exist.</remarks>
        public string ForwardDeadLetteredMessagesTo
        {
            get => _forwardDeadLetteredMessagesTo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _forwardDeadLetteredMessagesTo = value;
                    return;
                }

                EntityNameFormatter.CheckValidQueueName(value, nameof(ForwardDeadLetteredMessagesTo));
                if (_topicName.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                _forwardDeadLetteredMessagesTo = value;
            }
        }

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

        /// <summary>
        /// List of properties that were retrieved using GetSubscription but are not understood by this version of client is stored here.
        /// The list will be sent back when an already retrieved SubscriptionDescription will be used in UpdateSubscription call.
        /// </summary>
        internal List<XElement> UnknownProperties { get; set; }

        internal RuleProperties Rule { get; set; }

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 7;
            unchecked
            {
                hash = (hash * 7) + TopicName?.GetHashCode() ?? 0;
                hash = (hash * 7) + SubscriptionName?.GetHashCode() ?? 0;
            }

            return hash;
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public override bool Equals(object obj)
        {
            var other = obj as SubscriptionProperties;
            return Equals(other);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public bool Equals(SubscriptionProperties other)
        {
            if (other is SubscriptionProperties otherDescription
                && SubscriptionName.Equals(otherDescription.SubscriptionName, StringComparison.OrdinalIgnoreCase)
                && TopicName.Equals(otherDescription.TopicName, StringComparison.OrdinalIgnoreCase)
                && AutoDeleteOnIdle.Equals(otherDescription.AutoDeleteOnIdle)
                && DefaultMessageTimeToLive.Equals(otherDescription.DefaultMessageTimeToLive)
                && EnableBatchedOperations == otherDescription.EnableBatchedOperations
                && DeadLetteringOnMessageExpiration == otherDescription.DeadLetteringOnMessageExpiration
                && EnableDeadLetteringOnFilterEvaluationExceptions == otherDescription.EnableDeadLetteringOnFilterEvaluationExceptions
                && string.Equals(ForwardDeadLetteredMessagesTo, otherDescription.ForwardDeadLetteredMessagesTo, StringComparison.OrdinalIgnoreCase)
                && string.Equals(ForwardTo, otherDescription.ForwardTo, StringComparison.OrdinalIgnoreCase)
                && LockDuration.Equals(otherDescription.LockDuration)
                && MaxDeliveryCount == otherDescription.MaxDeliveryCount
                && RequiresSession.Equals(otherDescription.RequiresSession)
                && Status.Equals(otherDescription.Status)
                && string.Equals(_userMetadata, otherDescription._userMetadata, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(SubscriptionProperties left, SubscriptionProperties right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Equals(right);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(SubscriptionProperties left, SubscriptionProperties right)
        {
            return !(left == right);
        }
    }
}
