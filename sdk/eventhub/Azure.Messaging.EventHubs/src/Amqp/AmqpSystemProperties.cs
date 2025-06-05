// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   Provides an abstraction over an <see cref="AmqpAnnotatedMessage" /> to represent
    ///   broker-owned data in the form of a "system properties" dictionary for the
    ///   associated <see cref="EventData" /> instance.
    /// </summary>
    ///
    /// <remarks>
    ///   This wrapper is necessary to preserve the behavior of the <see cref="EventData.SystemProperties" />
    ///   member without potentially drifting from the mutable data that exists on the AMQP message.
    /// </remarks>
    ///
    /// <seealso cref="IReadOnlyDictionary{TKey, TValue}" />
    ///
    internal class AmqpSystemProperties : IReadOnlyDictionary<string, object>
    {
        /// <summary>The set of system properties that are sourced from the Properties section of the <see cref="AmqpAnnotatedMessage" />.</summary>
        private static readonly string[] PropertySectionNames = new[]
        {
           Properties.MessageIdName,
           Properties.UserIdName,
           Properties.ToName,
           Properties.SubjectName,
           Properties.ReplyToName,
           Properties.CorrelationIdName,
           Properties.ContentTypeName,
           Properties.ContentEncodingName,
           Properties.AbsoluteExpiryTimeName,
           Properties.CreationTimeName,
           Properties.GroupIdName,
           Properties.GroupSequenceName,
           Properties.ReplyToGroupIdName
        };

        /// <summary>The AMQP message to use as the source for the system properties data.</summary>
        private readonly AmqpAnnotatedMessage _amqpMessage;

        /// <summary>
        ///   Attempts to retrieve the value of the requested <paramref name="key" />
        ///   from the dictionary.
        /// </summary>
        ///
        /// <param name="key">The key of the dictionary item to retrieve.</param>
        ///
        /// <returns>The value in the dictionary associated with the specified <paramref name="key"/>.</returns>
        ///
        /// <exception cref="KeyNotFoundException">Occurs when the specified <paramref name="key" /> does not exist in the dictionary.</exception>
        ///
        public object this[string key]
        {
            get
            {
                if (_amqpMessage.HasSection(AmqpMessageSection.Properties))
                {
                    if (key == Properties.MessageIdName)
                    {
                        return _amqpMessage.Properties.MessageId?.ToString();
                    }

                    if (key == Properties.UserIdName)
                    {
                        return _amqpMessage.Properties.UserId;
                    }

                    if (key == Properties.ToName)
                    {
                        return _amqpMessage.Properties.To?.ToString();
                    }

                    if (key == Properties.SubjectName)
                    {
                        return _amqpMessage.Properties.Subject;
                    }

                    if (key == Properties.ReplyToName)
                    {
                        return _amqpMessage.Properties.ReplyTo?.ToString();
                    }

                    if (key == Properties.CorrelationIdName)
                    {
                        return _amqpMessage.Properties.CorrelationId?.ToString();
                    }

                    if (key == Properties.ContentTypeName)
                    {
                        return _amqpMessage.Properties.ContentType;
                    }

                    if (key == Properties.ContentEncodingName)
                    {
                        return _amqpMessage.Properties.ContentEncoding;
                    }

                    if (key == Properties.AbsoluteExpiryTimeName)
                    {
                        return _amqpMessage.Properties.AbsoluteExpiryTime;
                    }

                    if (key == Properties.CreationTimeName)
                    {
                        return _amqpMessage.Properties.CreationTime;
                    }

                    if (key == Properties.GroupIdName)
                    {
                        return _amqpMessage.Properties.GroupId;
                    }

                    if (key == Properties.GroupSequenceName)
                    {
                        return _amqpMessage.Properties.GroupSequence;
                    }

                    if (key == Properties.ReplyToGroupIdName)
                    {
                        return _amqpMessage.Properties.ReplyToGroupId;
                    }
                }

                if (_amqpMessage.HasSection(AmqpMessageSection.MessageAnnotations))
                {
                    return _amqpMessage.MessageAnnotations[key] switch
                    {
                        AmqpMessageId id => id.ToString(),
                        AmqpAddress address => address.ToString(),
                        object value => value
                    };
                }

                // If no section was available to delegate to, mimic the behavior of the standard dictionary implementation.

                throw new KeyNotFoundException(string.Format(CultureInfo.InvariantCulture, Resources.DictionaryKeyNotFoundMask, key));
            }
        }

        /// <summary>
        ///   Allows iteration over the keys contained in the dictionary.
        /// </summary>
        ///
        public IEnumerable<string> Keys
        {
            get
            {
                if (_amqpMessage.HasSection(AmqpMessageSection.Properties))
                {
                    foreach (var name in PropertySectionNames)
                    {
                        if (ContainsKey(name))
                        {
                            yield return name;
                        }
                    }
                }

                if (_amqpMessage.HasSection(AmqpMessageSection.MessageAnnotations))
                {
                    foreach (var name in _amqpMessage.MessageAnnotations.Keys)
                    {
                        yield return name;
                    }
                }
            }
        }

        /// <summary>
        ///   Allows iteration over the values contained in the dictionary.
        /// </summary>
        ///
        public IEnumerable<object> Values
        {
            get
            {
                if (_amqpMessage.HasSection(AmqpMessageSection.Properties))
                {
                    foreach (var name in PropertySectionNames)
                    {
                        if (ContainsKey(name))
                        {
                            yield return this[name];
                        }
                    }
                }

                if (_amqpMessage.HasSection(AmqpMessageSection.MessageAnnotations))
                {
                    foreach (var name in _amqpMessage.MessageAnnotations.Keys)
                    {
                        yield return _amqpMessage.MessageAnnotations[name];
                    }
                }
            }
        }

        /// <summary>
        ///   The number of items contained in the dictionary.
        /// </summary>
        ///
        public int Count
        {
            get
            {
                var count = 0;

                if (_amqpMessage.HasSection(AmqpMessageSection.Properties))
                {
                    foreach (var name in PropertySectionNames)
                    {
                        if (ContainsKey(name))
                        {
                            ++count;
                        }
                    }
                }

                if (_amqpMessage.HasSection(AmqpMessageSection.MessageAnnotations))
                {
                    foreach (var name in _amqpMessage.MessageAnnotations.Keys)
                    {
                        ++count;
                    }
                }

                return count;
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpSystemProperties"/> class.
        /// </summary>
        ///
        /// <param name="amqpMessage">The <see cref="AmqpAnnotatedMessage" /> to use as the source of the system properties data.</param>
        ///
        public AmqpSystemProperties(AmqpAnnotatedMessage amqpMessage) => _amqpMessage = amqpMessage;

        /// <summary>
        ///   Determines whether the specified key exists in the dictionary.
        /// </summary>
        ///
        /// <param name="key">The key to locate.</param>
        ///
        /// <returns><c>true</c> if the dictionary contains the specified key; otherwise, <c>false</c>.</returns>
        ///
        public bool ContainsKey(string key)
        {
            // Check the set of well-known items from the Properties section.  For the key to be considered present,
            // the section must exist and there must be a value present.  This logic is necessary to preserve the behavior
            // of system properties in EventData before the AMQP annotated message abstraction was incorporated.

            if (_amqpMessage.HasSection(AmqpMessageSection.Properties))
            {
                if (key == Properties.MessageIdName)
                {
                    return (_amqpMessage.Properties.MessageId != null);
                }

                if (key == Properties.UserIdName)
                {
                    return (_amqpMessage.Properties.UserId != null);
                }

                if (key == Properties.ToName)
                {
                    return (_amqpMessage.Properties.To != null);
                }

                if (key == Properties.SubjectName)
                {
                    return (_amqpMessage.Properties.Subject != null);
                }

                if (key == Properties.ReplyToName)
                {
                    return (_amqpMessage.Properties.ReplyTo != null);
                }

                if (key == Properties.CorrelationIdName)
                {
                    return (_amqpMessage.Properties.CorrelationId != null);
                }

                if (key == Properties.ContentTypeName)
                {
                    return (_amqpMessage.Properties.ContentType != null);
                }

                if (key == Properties.ContentEncodingName)
                {
                    return (_amqpMessage.Properties.ContentEncoding != null);
                }

                if (key == Properties.AbsoluteExpiryTimeName)
                {
                    return (_amqpMessage.Properties.AbsoluteExpiryTime != null);
                }

                if (key == Properties.CreationTimeName)
                {
                    return (_amqpMessage.Properties.CreationTime != null);
                }

                if (key == Properties.GroupIdName)
                {
                    return (_amqpMessage.Properties.GroupId != null);
                }

                if (key == Properties.GroupSequenceName)
                {
                    return (_amqpMessage.Properties.GroupSequence != null);
                }

                if (key == Properties.ReplyToGroupIdName)
                {
                    return (_amqpMessage.Properties.ReplyToGroupId != null);
                }
            }

            // If the well-known property items were not found, then any message annotation with a matching
            // key is acceptable.

            if (_amqpMessage.HasSection(AmqpMessageSection.MessageAnnotations))
            {
                return _amqpMessage.MessageAnnotations.ContainsKey(key);
            }

            // If neither a well-known property or message annotation matched, the key
            // does not exist.

            return false;
        }

        /// <summary>
        ///   Attempts to retrieve the value that is associated with the specified key from the dictionary.
        /// </summary>
        ///
        /// <param name="key">The key to locate.</param>
        /// <param name="value">The value associated with the specified key, if the key is found; otherwise, <c>null</c>.  This parameter should be passed uninitialized.</param>
        ///
        /// <returns><c>true</c> the dictionary contains the specified <paramref name="key" />; otherwise, <c>false</c>.</returns>
        ///
        public bool TryGetValue(string key, out object value)
        {
            if (!ContainsKey(key))
            {
                value = default;
                return false;
            }

            value = this[key];
            return true;
        }

        /// <summary>
        ///   Produces an enumerator for the items in the dictionary.
        /// </summary>
        ///
        /// <returns>An enumerator can be used to iterate through the items in the dictionary.</returns>
        ///
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            foreach (var key in Keys)
            {
                yield return new KeyValuePair<string, object>(key, this[key]);
            }
        }

        /// <summary>
        ///   Produces an enumerator for the items in the dictionary.
        /// </summary>
        ///
        /// <returns>An enumerator can be used to iterate through the items in the dictionary.</returns>
        ///
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
