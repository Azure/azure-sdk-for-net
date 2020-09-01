// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   The set of extension methods for the <see cref="Type" /> class.
    /// </summary>
    ///
    internal static class TypeExtensions
    {
        /// <summary>The set of mappings from CLR types to AMQP types for property values.</summary>
        private static readonly IReadOnlyDictionary<Type, AmqpProperty.Type> AmqpPropertyTypeMap = new Dictionary<Type, AmqpProperty.Type>
        {
            { typeof(byte), AmqpProperty.Type.Byte },
            { typeof(sbyte), AmqpProperty.Type.SByte },
            { typeof(char), AmqpProperty.Type.Char },
            { typeof(short), AmqpProperty.Type.Int16 },
            { typeof(ushort), AmqpProperty.Type.UInt16 },
            { typeof(int), AmqpProperty.Type.Int32 },
            { typeof(uint), AmqpProperty.Type.UInt32 },
            { typeof(long), AmqpProperty.Type.Int64 },
            { typeof(ulong), AmqpProperty.Type.UInt64 },
            { typeof(float), AmqpProperty.Type.Single },
            { typeof(double), AmqpProperty.Type.Double },
            { typeof(decimal), AmqpProperty.Type.Decimal },
            { typeof(bool), AmqpProperty.Type.Boolean },
            { typeof(Guid), AmqpProperty.Type.Guid },
            { typeof(string), AmqpProperty.Type.String },
            { typeof(Uri), AmqpProperty.Type.Uri },
            { typeof(DateTime), AmqpProperty.Type.DateTime },
            { typeof(DateTimeOffset), AmqpProperty.Type.DateTimeOffset },
            { typeof(TimeSpan), AmqpProperty.Type.TimeSpan },
        };

        /// <summary>
        ///   Translates the given <see cref="Type" /> to the corresponding
        ///   <see cref="AmqpProperty.Type" />.
        /// </summary>
        ///
        /// <param name="instance">The instance that this method was invoked on.</param>
        ///
        /// <returns>The AMQP property type that best matches the specified <paramref name="instance"/>.</returns>
        ///
        public static AmqpProperty.Type ToAmqpPropertyType(this Type instance)
        {
            if (instance == null)
            {
                return AmqpProperty.Type.Null;
            }

            if (AmqpPropertyTypeMap.TryGetValue(instance, out AmqpProperty.Type amqpType))
            {
                return amqpType;
            }

            return AmqpProperty.Type.Unknown;
        }
    }
}
