// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Internal.Avro
{
    internal static class AvroParser
    {
        /// <summary>
        /// Reads a fixed number of bytes from the stream.
        /// The number of bytes to return is the first int read from the stream.
        /// </summary>
        /// <remarks>
        /// Note that in the Avro spec, byte array length is specified as a long.
        /// This is fine for Quick Query and Change Feed, but could become a problem
        /// in the future.
        /// </remarks>
        public static async Task<byte[]> ReadFixedBytesAsync(
            Stream stream,
            int length,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] data = new byte[length];
            int start = 0;
            while (length > 0)
            {
                int n = async ?
                    await stream.ReadAsync(data, start, length, cancellationToken).ConfigureAwait(false) :
                    stream.Read(data, start, length);
                start += n;
                length -= n;

                // We hit the end of the stream
                if (n <= 0)
                    return data;
            }
            return data;
        }

        /// <summary>
        /// Reads a single byte from the stream.
        /// </summary>
        private static async Task<byte> ReadByteAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadFixedBytesAsync(stream, 1, async, cancellationToken).ConfigureAwait(false);
            return bytes[0];
        }

        /// <summary>
        /// Internal implementation of ReadLongAsync().
        /// </summary>
        private static async Task<long> ReadZigZagLongAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte b = await ReadByteAsync(stream, async, cancellationToken).ConfigureAwait(false);
            ulong next = b & 0x7FUL;
            int shift = 7;
            while ((b & 0x80) != 0)
            {
                b = await ReadByteAsync(stream, async, cancellationToken).ConfigureAwait(false);
                next |= (b & 0x7FUL) << shift;
                shift += 7;
            }
            long value = (long)next;
            return (-(value & 0x01L)) ^ ((value >> 1) & 0x7fffffffffffffffL);
        }

        /// <summary>
        /// Returns null.
        /// </summary>
        public static Task<object> ReadNullAsync() => Task.FromResult<object>(null);

        /// <summary>
        /// Reads a bool from the stream.
        /// </summary>
        public static async Task<bool> ReadBoolAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte b = await ReadByteAsync(stream, async, cancellationToken).ConfigureAwait(false);

            if (b != 0)
                return true;
            return false;
        }

        /// <summary>
        /// Reads a long from the stream.
        /// </summary>
        public static async Task<long> ReadLongAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken) =>
            await ReadZigZagLongAsync(stream, async, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Reads an int from the stream.
        /// </summary>
        public static async Task<int> ReadIntAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken) =>
            (int)(await ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false));

        /// <summary>
        /// Reads a float from the stream.
        /// </summary>
        public static async Task<float> ReadFloatAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadFixedBytesAsync(stream, 4, async, cancellationToken).ConfigureAwait(false);
            return BitConverter.ToSingle(bytes, 0);
        }

        /// <summary>
        /// Reads a double from the stream.
        /// </summary>
        public static async Task<double> ReadDoubleAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadFixedBytesAsync(stream, 8, async, cancellationToken).ConfigureAwait(false);
            return BitConverter.ToDouble(bytes, 0);
        }

        /// <summary>
        /// Reads a fixed number of bytes from the stream.
        /// </summary>
        public static async Task<byte[]> ReadBytesAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            // Note that byte array length is actually defined as a long in the Avro spec.
            // This is fine for now, but may need to be changed in the future.
            int size = await ReadIntAsync(stream, async, cancellationToken).ConfigureAwait(false);
            return await ReadFixedBytesAsync(stream, size, async, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads a string from the stream.
        /// </summary>
        public static async Task<string> ReadStringAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadBytesAsync(stream, async, cancellationToken).ConfigureAwait(false);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Reads a KeyValuePair from the stream.
        /// Used in ReadMapAsync().
        /// </summary>
        private static async Task<KeyValuePair<string, T>> ReadMapPairAsync<T>(
            Stream stream,
            Func<Stream, bool, CancellationToken, Task<T>> parseItemAsync,
            bool async,
            CancellationToken cancellationToken)
        {
            string key = await ReadStringAsync(stream, async, cancellationToken).ConfigureAwait(false);
            #pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            T value = await parseItemAsync(stream, async, cancellationToken).ConfigureAwait(false);
            #pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            return new KeyValuePair<string, T>(key, value);
        }

        /// <summary>
        /// Reads a map from the stream.
        /// </summary>
        public static async Task<Dictionary<string, T>> ReadMapAsync<T>(
            Stream stream,
            Func<Stream, bool, CancellationToken, Task<T>> parseItemAsync,
            bool async,
            CancellationToken cancellationToken)
        {
            Func<Stream, bool, CancellationToken, Task<KeyValuePair<string, T>>> parsePair =
                async (s, async, cancellationToken) => await ReadMapPairAsync(s, parseItemAsync, async, cancellationToken).ConfigureAwait(false);
            IEnumerable<KeyValuePair<string, T>> entries =
                await ReadArrayAsync(stream, parsePair, async, cancellationToken).ConfigureAwait(false);
            return entries.ToDictionary();
        }

        /// <summary>
        /// Reads an array of objects from the stream.
        /// </summary>
        private static async Task<IEnumerable<T>> ReadArrayAsync<T>(
            Stream stream,
            Func<Stream, bool, CancellationToken, Task<T>> parseItemAsync,
            bool async,
            CancellationToken cancellationToken)
        {
            // TODO: This is unpleasant, but I don't want to switch everything to IAsyncEnumerable for every array
            List<T> items = new List<T>();
            for (long length = await ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false);
                 length != 0;
                 length = await ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false))
            {
                // Ignore block sizes because we're not skipping anything
                if (length < 0)
                {
                    await ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false);
                    length = -length;
                }
                while (length-- > 0)
                {
                    #pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    T item = await parseItemAsync(stream, async, cancellationToken).ConfigureAwait(false);
                    #pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                    items.Add(item);
                };
            }
            return items;
        }

        /// <summary>
        /// Adds the select to each element in the array.
        /// </summary>
        internal static List<T> Map<T>(this JsonElement array, Func<JsonElement, T> selector)
        {
            var values = new List<T>();
            foreach (JsonElement element in array.EnumerateArray())
            {
                values.Add(selector(element));
            }
            return values;
        }

        /// <summary>
        /// Converts an IEnumerable of KeyValuePair into a Dictionary.
        /// </summary>
        internal static Dictionary<string, T> ToDictionary<T>(this IEnumerable<KeyValuePair<string, T>> values)
        {
            Dictionary<string, T> dict = new Dictionary<string, T>();
            foreach (KeyValuePair<string, T> pair in values)
            {
                dict[pair.Key] = pair.Value;
            }
            return dict;
        }
    }

    /// <summary>
    /// Parent class of AvroTypes.
    /// </summary>
    internal abstract class AvroType
    {
        /// <summary>
        /// Reads an object from the stream.
        /// </summary>
        public abstract Task<object> ReadAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken);

        /// <summary>
        /// Determinds the AvroType from the Avro Schema.
        /// </summary>
        public static AvroType FromSchema(JsonElement schema)
        {
            return schema.ValueKind switch
            {
                // Primitives
                JsonValueKind.String => FromStringSchema(schema),
                // Union types
                JsonValueKind.Array => FromArraySchema(schema),
                // Everything else
                JsonValueKind.Object => FromObjectSchema(schema),
                _ => throw new InvalidOperationException($"Unexpected JSON Element: {schema}"),
            };
        }

        private static AvroType FromStringSchema(JsonElement schema)
        {
            string type = schema.GetString();
            return type switch
            {
                AvroConstants.Null => new AvroPrimitiveType { Primitive = AvroPrimitive.Null },
                AvroConstants.Boolean => new AvroPrimitiveType { Primitive = AvroPrimitive.Boolean },
                AvroConstants.Int => new AvroPrimitiveType { Primitive = AvroPrimitive.Int },
                AvroConstants.Long => new AvroPrimitiveType { Primitive = AvroPrimitive.Long },
                AvroConstants.Float => new AvroPrimitiveType { Primitive = AvroPrimitive.Float },
                AvroConstants.Double => new AvroPrimitiveType { Primitive = AvroPrimitive.Double },
                AvroConstants.Bytes => new AvroPrimitiveType { Primitive = AvroPrimitive.Bytes },
                AvroConstants.String => new AvroPrimitiveType { Primitive = AvroPrimitive.String },
                _ => throw new InvalidOperationException($"Unexpected Avro type {type} in {schema}"),
            };
        }

        private static AvroType FromArraySchema(JsonElement schema)
        {
            return new AvroUnionType { Types = schema.Map(FromSchema) };
        }

        private static AvroType FromObjectSchema(JsonElement schema)
        {
            string type = schema.GetProperty("type").GetString();
            switch (type)
            {
                // Primitives can be defined as strings or objects
                case AvroConstants.Null:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.Null };
                case AvroConstants.Boolean:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.Boolean };
                case AvroConstants.Int:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.Int };
                case AvroConstants.Long:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.Long };
                case AvroConstants.Float:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.Float };
                case AvroConstants.Double:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.Double };
                case AvroConstants.Bytes:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.Bytes };
                case AvroConstants.String:
                    return new AvroPrimitiveType { Primitive = AvroPrimitive.String };
                case AvroConstants.Record:
                    if (schema.TryGetProperty(AvroConstants.Aliases, out var _))
                        throw new InvalidOperationException($"Unexpected aliases on {schema}");
                    string name = schema.GetProperty(AvroConstants.Name).GetString();
                    Dictionary<string, AvroType> fields = new Dictionary<string, AvroType>();
                    foreach (JsonElement field in schema.GetProperty(AvroConstants.Fields).EnumerateArray())
                    {
                        fields[field.GetProperty(AvroConstants.Name).GetString()] = FromSchema(field.GetProperty(AvroConstants.Type));
                    }
                    return new AvroRecordType { Schema = name, Fields = fields };
                case AvroConstants.Enum:
                    if (schema.TryGetProperty(AvroConstants.Aliases, out var _))
                        throw new InvalidOperationException($"Unexpected aliases on {schema}");
                    return new AvroEnumType { Symbols = schema.GetProperty(AvroConstants.Symbols).Map(s => s.GetString()) };
                case AvroConstants.Map:
                    return new AvroMapType { ItemType = FromSchema(schema.GetProperty(AvroConstants.Values)) };
                case AvroConstants.Array: // Unused today
                case AvroConstants.Union: // Unused today
                case AvroConstants.Fixed: // Unused today
                default:
                    throw new InvalidOperationException($"Unexpected Avro type {type} in {schema}");
            }
        }
    }

    internal enum AvroPrimitive { Null, Boolean, Int, Long, Float, Double, Bytes, String };

    /// <summary>
    /// AvroPrimativeType.
    /// </summary>
    internal class AvroPrimitiveType : AvroType
    {
        public AvroPrimitive Primitive { get; set; }

        public override async Task<object> ReadAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken) =>
            Primitive switch
            {
                #pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                AvroPrimitive.Null => await AvroParser.ReadNullAsync().ConfigureAwait(false),
                #pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
                AvroPrimitive.Boolean => await AvroParser.ReadBoolAsync(stream, async, cancellationToken).ConfigureAwait(false),
                AvroPrimitive.Int => await AvroParser.ReadIntAsync(stream, async, cancellationToken).ConfigureAwait(false),
                AvroPrimitive.Long => await AvroParser.ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false),
                AvroPrimitive.Float => await AvroParser.ReadFloatAsync(stream, async, cancellationToken).ConfigureAwait(false),
                AvroPrimitive.Double => await AvroParser.ReadDoubleAsync(stream, async, cancellationToken).ConfigureAwait(false),
                AvroPrimitive.Bytes => await AvroParser.ReadBytesAsync(stream, async, cancellationToken).ConfigureAwait(false),
                AvroPrimitive.String => await AvroParser.ReadStringAsync(stream, async, cancellationToken).ConfigureAwait(false),
                _ => throw new InvalidOperationException("Unknown Avro Primitive!")
            };
    }

    /// <summary>
    /// AvroEnumType.
    /// </summary>
    internal class AvroEnumType : AvroType
    {
        public IReadOnlyList<string> Symbols { get; set; }

        public override async Task<object> ReadAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            int value = await AvroParser.ReadIntAsync(stream, async, cancellationToken).ConfigureAwait(false);
            return Symbols[value];
        }
    }

    /// <summary>
    /// AvroUnionType.
    /// </summary>
    internal class AvroUnionType : AvroType
    {
        public IReadOnlyList<AvroType> Types { get; set; }

        public override async Task<object> ReadAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            int option = await AvroParser.ReadIntAsync(stream, async, cancellationToken).ConfigureAwait(false);
            return await Types[option].ReadAsync(stream, async, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// AvroMapType.
    /// </summary>
    internal class AvroMapType : AvroType
    {
        public AvroType ItemType { get; set; }

        public override async Task<object> ReadAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            Func<Stream, bool, CancellationToken, Task<object>> parseItemAsync =
                async (s, a, c) => await ItemType.ReadAsync(s, a, c).ConfigureAwait(false);
            return await AvroParser.ReadMapAsync(stream, parseItemAsync, async, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// AvroRecordType.
    /// </summary>
    internal class AvroRecordType : AvroType
    {
        public string Schema { get; set; }
        public IReadOnlyDictionary<string, AvroType> Fields { get; set; }

        public override async Task<object> ReadAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            Dictionary<string, object> record = new Dictionary<string, object>();
            record["$schema"] = Schema;
            foreach (KeyValuePair<string, AvroType> field in Fields)
            {
                record[field.Key] = await field.Value.ReadAsync(stream, async, cancellationToken).ConfigureAwait(false);
            }
            return record;
        }
    }
}
