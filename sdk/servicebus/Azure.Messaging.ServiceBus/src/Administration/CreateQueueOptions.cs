﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Administration
{
    /// <summary>
    /// Represents the set of options that can be specified for the creation of a queue.
    /// </summary>
    public class CreateQueueOptions : IEquatable<CreateQueueOptions>
    {
        private TimeSpan _duplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1);
        private string _name;
        private TimeSpan _lockDuration = TimeSpan.FromSeconds(60);
        private TimeSpan _defaultMessageTimeToLive = TimeSpan.MaxValue;
        private TimeSpan autoDeleteOnIdle = TimeSpan.MaxValue;
        private int _maxDeliveryCount = 10;
        private string _forwardTo;
        private string _forwardDeadLetteredMessagesTo;
        private string _userMetadata;

        /// <summary>
        /// Initializes a new instance of <see cref="CreateQueueOptions"/> with the specified relative name.
        /// </summary>
        /// <param name="name">Name of the queue relative to the namespace base address.</param>
        public CreateQueueOptions(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="CreateQueueOptions"/> based on the
        /// specified <see cref="QueueProperties"/> instance. This is useful for creating a new queue based
        /// on the properties of an existing queue.
        /// </summary>
        /// <param name="queue">Existing queue to create options from.</param>
        public CreateQueueOptions(QueueProperties queue)
        {
            Argument.AssertNotNull(queue, nameof(queue));
            Name = queue.Name;
            LockDuration = queue.LockDuration;
            MaxSizeInMegabytes = queue.MaxSizeInMegabytes;
            RequiresDuplicateDetection = queue.RequiresDuplicateDetection;
            RequiresSession = queue.RequiresSession;
            DefaultMessageTimeToLive = queue.DefaultMessageTimeToLive;
            AutoDeleteOnIdle = queue.AutoDeleteOnIdle;
            DeadLetteringOnMessageExpiration = queue.DeadLetteringOnMessageExpiration;
            DuplicateDetectionHistoryTimeWindow = queue.DuplicateDetectionHistoryTimeWindow;
            MaxDeliveryCount = queue.MaxDeliveryCount;
            EnableBatchedOperations = queue.EnableBatchedOperations;
            AuthorizationRules = queue.AuthorizationRules.Clone();
            Status = queue.Status;
            ForwardTo = queue.ForwardTo;
            ForwardDeadLetteredMessagesTo = queue.ForwardDeadLetteredMessagesTo;
            EnablePartitioning = queue.EnablePartitioning;
            if (queue.UserMetadata != null)
            {
                UserMetadata = queue.UserMetadata;
            }
        }

        /// <summary>
        /// Name of the queue relative to the namespace base address.
        /// </summary>
        /// <remarks>Max length is 260 chars. Cannot start or end with a slash.
        /// Cannot have restricted characters: '@','?','#','*'</remarks>
        public string Name
        {
            get => _name;
            set
            {
                EntityNameFormatter.CheckValidQueueName(value, nameof(Name));
                _name = value;
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
        /// The maximum size of the queue in megabytes, which is the size of memory allocated for the queue.
        /// </summary>
        /// <remarks>Default value is 1024.</remarks>
        public long MaxSizeInMegabytes { get; set; } = 1024;

        /// <summary>
        /// This value indicates if the queue requires guard against duplicate messages. If true, duplicate messages having same
        /// <see cref="ServiceBusMessage.MessageId"/> and sent to queue within duration of <see cref="DuplicateDetectionHistoryTimeWindow"/>
        /// will be discarded.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool RequiresDuplicateDetection { get; set; }

        /// <summary>
        /// This indicates whether the queue supports the concept of session. Sessionful-messages follow FIFO ordering.
        /// </summary>
        /// <remarks>
        /// If true, the receiver can only receive messages using <see cref="ServiceBusSessionReceiver"/>.
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
        /// The <see cref="TimeSpan"/> idle interval after which the queue is automatically deleted.
        /// </summary>
        /// <remarks>The minimum duration is 5 minutes. Default value is <see cref="TimeSpan.MaxValue"/>.</remarks>
        public TimeSpan AutoDeleteOnIdle
        {
            get => autoDeleteOnIdle;
            set
            {
                Argument.AssertAtLeast(
                    value,
                    AdministrationClientConstants.MinimumAllowedAutoDeleteOnIdle,
                    nameof(AutoDeleteOnIdle));

                autoDeleteOnIdle = value;
            }
        }

        /// <summary>
        /// Indicates whether this queue has dead letter support when a message expires.
        /// </summary>
        /// <remarks>If true, the expired messages are moved to dead-letter subqueue. Default value is false.</remarks>
        public bool DeadLetteringOnMessageExpiration { get; set; }

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
                    nameof(MaxDeliveryCount));

                _maxDeliveryCount = value;
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
        /// The name of the recipient entity to which all the messages sent to the queue are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive messages from this queue. The destination entity
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
                if (_name.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                _forwardTo = value;
            }
        }

        /// <summary>
        /// The name of the recipient entity to which all the dead-lettered messages of this queue are forwarded to.
        /// </summary>
        /// <remarks>If set, user cannot manually receive dead-lettered messages from this queue. The destination
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
                if (_name.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new InvalidOperationException("Entity cannot have auto-forwarding policy to itself");
                }

                _forwardDeadLetteredMessagesTo = value;
            }
        }

        /// <summary>
        /// Indicates whether the queue is to be partitioned across multiple message brokers.
        /// </summary>
        /// <remarks>Defaults to false.</remarks>
        public bool EnablePartitioning { get; set; }

        /// <summary>
        /// Custom metadata that user can associate with the queue.
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
        ///   Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? base.GetHashCode();
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public override bool Equals(object obj)
        {
            var other = obj as CreateQueueOptions;
            return Equals(other);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        public bool Equals(CreateQueueOptions other)
        {
            if (other is CreateQueueOptions otherOptions
                && Name.Equals(otherOptions.Name, StringComparison.OrdinalIgnoreCase)
                && AutoDeleteOnIdle.Equals(otherOptions.AutoDeleteOnIdle)
                && DefaultMessageTimeToLive.Equals(otherOptions.DefaultMessageTimeToLive)
                && (!RequiresDuplicateDetection || DuplicateDetectionHistoryTimeWindow.Equals(otherOptions.DuplicateDetectionHistoryTimeWindow))
                && EnableBatchedOperations == otherOptions.EnableBatchedOperations
                && DeadLetteringOnMessageExpiration == otherOptions.DeadLetteringOnMessageExpiration
                && EnablePartitioning == otherOptions.EnablePartitioning
                && string.Equals(ForwardDeadLetteredMessagesTo, otherOptions.ForwardDeadLetteredMessagesTo, StringComparison.OrdinalIgnoreCase)
                && string.Equals(ForwardTo, otherOptions.ForwardTo, StringComparison.OrdinalIgnoreCase)
                && LockDuration.Equals(otherOptions.LockDuration)
                && MaxDeliveryCount == otherOptions.MaxDeliveryCount
                && MaxSizeInMegabytes == otherOptions.MaxSizeInMegabytes
                && RequiresDuplicateDetection.Equals(otherOptions.RequiresDuplicateDetection)
                && RequiresSession.Equals(otherOptions.RequiresSession)
                && Status.Equals(otherOptions.Status)
                && string.Equals(_userMetadata, otherOptions._userMetadata, StringComparison.OrdinalIgnoreCase)
                && (AuthorizationRules != null && otherOptions.AuthorizationRules != null
                    || AuthorizationRules == null && otherOptions.AuthorizationRules == null)
                && (AuthorizationRules == null || AuthorizationRules.Equals(otherOptions.AuthorizationRules)))
            {
                return true;
            }

            return false;
        }

        /// <summary></summary>
        public static bool operator ==(CreateQueueOptions left, CreateQueueOptions right)
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

        /// <summary></summary>
        public static bool operator !=(CreateQueueOptions left, CreateQueueOptions right)
        {
            return !(left == right);
        }
    }
}
