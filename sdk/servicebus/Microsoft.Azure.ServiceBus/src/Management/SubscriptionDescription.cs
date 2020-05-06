// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// Represents the metadata description of the subscription.
    /// </summary>
    public class SubscriptionDescription : IEquatable<SubscriptionDescription>
    {
        string topicPath, subscriptionName;
        TimeSpan lockDuration = TimeSpan.FromSeconds(60);
        TimeSpan defaultMessageTimeToLive = TimeSpan.MaxValue;
        TimeSpan autoDeleteOnIdle = TimeSpan.MaxValue;
        int maxDeliveryCount = 10;
        string forwardTo = null;
        string forwardDeadLetteredMessagesTo = null;
        string userMetadata = null;

        /// <summary>
        /// Initializes a new instance of SubscriptionDescription class with the specified name and topic path.
        /// </summary>
        /// <param name="topicPath">Path of the topic relative to the namespace base address.</param>
        /// <param name="subscriptionName">Name of the subscription.</param>
        public SubscriptionDescription(string topicPath, string subscriptionName)
        {
            this.TopicPath = topicPath;
            this.SubscriptionName = subscriptionName;
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
        /// This indicates whether the subscription supports the concept of session. Sessionful-messages follow FIFO ordering.
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
        /// The <see cref="TimeSpan"/> idle interval after which the subscription is automatically deleted.
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
        /// Indicates whether this subscription has dead letter support when a message expires.
        /// </summary>
        /// <remarks>If true, the expired messages are moved to dead-letter sub-queue. Default value is false.</remarks>
        public bool EnableDeadLetteringOnMessageExpiration { get; set; } = false;

        /// <summary>
        /// indicates whether messages need to be forwarded to dead-letter sub queue when subscription rule evaluation fails.
        /// </summary>
        /// <remarks>Defaults to true.</remarks>
        public bool EnableDeadLetteringOnFilterEvaluationExceptions { get; set; } = true;

        /// <summary>
        /// Path of the topic under which subscription exists.
        /// </summary>
        /// <remarks>Value cannot be null or empty. Value cannot exceed 260 chars. Cannot start or end with a slash. 
        /// Cannot have restricted characters: '@','?','#','*'</remarks>
        public string TopicPath
        {
            get => this.topicPath;
            set
            {
                EntityNameHelper.CheckValidTopicName(value, nameof(TopicPath));
                this.topicPath = value;
            }
        }

        /// <summary>
        /// Name of the subscription.
        /// </summary>
        /// <remarks>Value cannot be null or empty. Value cannot exceed 50 chars.
        /// Cannot have restricted characters: '@','?','#','*','/','\'</remarks>
        public string SubscriptionName
        {
            get => this.subscriptionName;
            set
            {
                EntityNameHelper.CheckValidSubscriptionName(value, nameof(SubscriptionName));
                this.subscriptionName = value;
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
        /// The current status of the subscription (Enabled / Disabled).
        /// </summary>
        /// <remarks>When an entity is disabled, that entity cannot send or receive messages.</remarks>
        public EntityStatus Status { get; set; } = EntityStatus.Active;

        /// <summary>
        /// The path of the recipient entity to which all the messages sent to the subscription are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive messages from this subscription. The destination entity 
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
                if (this.topicPath.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                this.forwardTo = value;
            }
        }

        /// <summary>
        /// The path of the recipient entity to which all the dead-lettered messages of this subscription are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive dead-lettered messages from this subscription. The destination
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
                if (this.topicPath.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                this.forwardDeadLetteredMessagesTo = value;
            }
        }

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

        /// <summary>
        /// List of properties that were retrieved using GetSubscription but are not understood by this version of client is stored here.
        /// The list will be sent back when an already retrieved SubscriptionDescription will be used in UpdateSubscription call.
        /// </summary>
        internal List<object> UnknownProperties { get; set; }

        internal RuleDescription DefaultRuleDescription { get; set; }

        public override int GetHashCode()
        {
            int hash = 7;
            unchecked
            {
                hash = (hash * 7) + this.TopicPath?.GetHashCode() ?? 0;
                hash = (hash * 7) + this.SubscriptionName?.GetHashCode() ?? 0;
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var other = obj as SubscriptionDescription;
            return this.Equals(other);
        }

        public bool Equals(SubscriptionDescription otherDescription)
        {
            if (otherDescription is SubscriptionDescription other
                && this.SubscriptionName.Equals(other.SubscriptionName, StringComparison.OrdinalIgnoreCase)
                && this.TopicPath.Equals(other.TopicPath, StringComparison.OrdinalIgnoreCase)
                && this.AutoDeleteOnIdle.Equals(other.AutoDeleteOnIdle)
                && this.DefaultMessageTimeToLive.Equals(other.DefaultMessageTimeToLive)
                && this.EnableBatchedOperations == other.EnableBatchedOperations
                && this.EnableDeadLetteringOnMessageExpiration == other.EnableDeadLetteringOnMessageExpiration
                && this.EnableDeadLetteringOnFilterEvaluationExceptions == other.EnableDeadLetteringOnFilterEvaluationExceptions
                && string.Equals(this.ForwardDeadLetteredMessagesTo, other.ForwardDeadLetteredMessagesTo, StringComparison.OrdinalIgnoreCase)
                && string.Equals(this.ForwardTo, other.ForwardTo, StringComparison.OrdinalIgnoreCase)
                && this.LockDuration.Equals(other.LockDuration)
                && this.MaxDeliveryCount == other.MaxDeliveryCount
                && this.RequiresSession.Equals(other.RequiresSession)
                && this.Status.Equals(other.Status)
                && string.Equals(this.userMetadata, other.userMetadata, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(SubscriptionDescription o1, SubscriptionDescription o2)
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

        public static bool operator !=(SubscriptionDescription o1, SubscriptionDescription o2)
        {
            return !(o1 == o2);
        }
    }
}
