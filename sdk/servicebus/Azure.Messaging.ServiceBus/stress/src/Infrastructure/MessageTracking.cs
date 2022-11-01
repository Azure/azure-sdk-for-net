// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Messaging.ServiceBus;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   A class that allows for keeping track of messages as they are sent from a sender or session sender
///   until they are received by the processor or receiver. It is used by the sender to
///   add property values to the <see cref="ServiceBusMessage"/>. It is used by the processors and receivers
///   to keep track of previously read messages and determine if messages being processed are out of order,
///   duplicated, or have corrupted bodies.
/// </summary>
///
public static class EventTracking
{
    /// <summary>
    ///   The name of the <see cref="ServiceBusMessage"/> property that holds the sender-assigned index number.
    /// </summary>
    ///
    public static readonly string IndexNumberPropertyName = "IndexNumber";

    /// <summary>
    ///   The name of the <see cref="ServiceBusMessage"/> property that holds the time the message was sent.
    /// </summary>
    ///
    public static readonly string SendTimePropertyName = "SendTime";

    /// <summary>
    ///   The name of the <see cref="EventData"/> property that holds the session Id the sender
    ///   was intending to send to, if any.
    /// </summary>
    ///
    public static readonly string SessionIdPropertyName = "SessionId";

    /// <summary>
    ///   The name of the <see cref="ServiceBusMessage"/> property that holds the ID assigned to this event by
    ///   the sender.
    /// </summary>
    ///
    public static readonly string IdPropertyName = "MessageId";

    /// <summary>
    ///   The name of the <see cref="ServiceBusMessage"/> property that holds the hash of the message body assigned by the sender.
    /// </summary>
    ///
    public static readonly string MessageBodyHashPropertyName = "MessageBodyHash";

    /// <summary>
    ///   Adds properties to the given <see cref="ServiceBusMessage"/> instance, allowing for the processor to determine that events
    ///   were received in order, not duplicated, and have valid event bodies.
    /// </summary>
    ///
    /// <param name="message">The <see cref="ServiceBusMessage"/> instance to augment.</param>
    /// <param name="sha256Hash">The <see cref="SHA256"/> instance to hash the event body.</param>
    /// <param name="indexNumber">The producer assigned index number for this event.</param>
    /// <param name="sessionId">The session id, if any, that this message was intended to be sent to.</param>
    ///
    public static void AugmentMessage(ServiceBusMessage message,
                                    SHA256 sha256Hash,
                                    int indexNumber,
                                    string sessionId=null)
    {
        message.ApplicationProperties.Add(IndexNumberPropertyName, indexNumber);
        message.ApplicationProperties.Add(SendTimePropertyName, DateTimeOffset.UtcNow);
        message.ApplicationProperties.Add(IdPropertyName, Guid.NewGuid().ToString());

        message.ApplicationProperties.Add(MessageBodyHashPropertyName, sha256Hash.ComputeHash(message.Body.ToArray()).ToString());

        if (!string.IsNullOrEmpty(partition))
        {
            message.ApplicationProperties.Add(SessionIdPropertyName, sessionId);
        }
    }

    /// <summary>
    ///   Processes the <see cref="ServiceBusMessage"/> instance held in the <see cref="ProcessMessageEventArgs"/> in order to determine
    ///   if the event has already been seen, if the event was received out of order, or if the body is invalid.
    /// </summary>
    ///
    /// <param name="args">The <see cref="ProcessMessageEventArgs"/> received from the processor to be used for processing.</param>
    /// <param name="sha256Hash">The <see cref="SHA256"/> instance to hash the event body.</param>
    /// <param name="metrics">The <see cref="Metrics"/> instance used to send information about the processed event to Application Insights.</param>
    /// <param name="readMessages">The dictionary holding the key values of the unique Id's of all the messages that have been read so far.</param>
    ///
    public static async void ProcessEventAsync(ProcessMessageEventArgs args,
                                               SHA256 sha256Hash,
                                               Metrics metrics,
                                               ConcurrentDictionary<string, byte> readMessages) => CheckMessage(args.Message, sha256Hash, null, metrics, readMessages);

    /// <summary>
    ///   Processes the <see cref="ServiceBusMessage"/> instance held in the <see cref="ProcessSessionMessageEventArgs"/> in order to determine
    ///   if the event has already been seen, if the event was received out of order, or if the body is invalid.
    /// </summary>
    ///
    /// <param name="args">The <see cref="ProcessSessionMessageEventArgs"/> received from the processor to be used for processing.</param>
    /// <param name="sha256Hash">The <see cref="SHA256"/> instance to hash the event body.</param>
    /// <param name="metrics">The <see cref="Metrics"/> instance used to send information about the processed event to Application Insights.</param>
    /// <param name="readMessages">The dictionary holding the key values of the unique Id's of all the messages that have been read so far.</param>
    ///
    public static async void ProcessSessionEventAsync(ProcessSessionMessageEventArgs args,
                                               SHA256 sha256Hash,
                                               Metrics metrics,
                                               ConcurrentDictionary<string, byte> readMessages) => CheckMessage(args.Message, sha256Hash, args.SessionId, metrics, readMessages);

    // TODO: Receive message method

    /// <summary>
    ///   Validates a messages . This instance checks if the message has an id, if the message has already been seen before by this instance, that the
    ///   intended session was the one the message was received from, that the message was received in order, that none were missed, and that
    ///   the body is valid.
    /// </summary>
    ///
    /// <param name="message">The <see cref="ServiceBusReceivedMessage"/> to be checked.</param>
    /// <param name="sha256Hash">The <see cref="SHA256"/> instance to hash the message body.</param>
    /// <param name="metrics">The metrics instance used to send metrics to application insights.</param>
    /// <param name="readMessages">The dictionary holding the key values of the unique Id's of all the messages that have been read so far.</param>
    ///
    /// <returns>The sender assigned index number of the event that was just read, or -1 if this event was unkown or a duplicate.</returns>
    ///
    /// <remarks>
    ///   One instance should be created for each processor or receiver role. This instance will be able to keep track of all the events the
    ///   processor or receiver has received for each partition it is reading or processing from.
    /// </remarks>
    ///
    private static int CheckMessage(ServiceBusReceivedMessage message,
                                  SHA256 sha256Hash,
                                  string sessionId,
                                  Metrics metrics,
                                  ConcurrentDictionary<string, byte> readMessages)
    {
        // Id Checks
        var hasId = message.ApplicationProperties.TryGetValue(IdPropertyName, out var messageIdProperty);
        var messageId = messageIdProperty?.ToString();

        if (!hasId)
        {
            metrics.Client.GetMetric(Metrics.UnknownEventsProcessed).TrackValue(1);
            return -1;
        }

        if (readMessages.ContainsKey(eventId))
        {
            metrics.Client.GetMetric(Metrics.DuplicateEventsDiscarded).TrackValue(1);
            return -1;
        }

        // Hashed message body checks
        message.ApplicationProperties.TryGetValue(MessageBodyHashPropertyName, out var expected);
        var expectedMessageBodyHash = expected.ToString();
        var receivedMessageBodyHash = sha256Hash.ComputeHash(message.Body.ToArray()).ToString();

        if (expectedMessageBodyHash != receivedMessageBodyHash)
        {
            var messageProperties = new Dictionary<string,string>();
            messageProperties.Add(Metrics.PublisherAssignedId, eventId.ToString());
            messageProperties.Add(Metrics.PublisherAssignedIndex, indexNumber.ToString());
            messageProperties.Add(Metrics.EventBody, eventData.EventBody.ToString());
            metrics.Client.TrackEvent(Metrics.InvalidBodies, messageProperties);
            return -1;
        }

        // Finished Checks - mark as read
        readEvents.TryAdd(eventId, 0);

        return indexNumber;
    }
}