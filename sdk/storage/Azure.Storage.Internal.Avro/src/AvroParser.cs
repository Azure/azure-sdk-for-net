// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Storage.Internal.Avro
{
    internal static class AvroParser
    {
        public static List<object> Parse(Stream stream, CancellationToken cancellationToken = default) =>
            ReadObjectContainerFileAsync(stream, async: false, cancellationToken).EnsureCompleted();

        public static async Task<List<object>> ParseAsync(Stream stream, CancellationToken cancellationToken = default) =>
            await ReadObjectContainerFileAsync(stream, async: true, cancellationToken).ConfigureAwait(false);

        private static async Task<List<object>> ReadObjectContainerFileAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken = default)
        {
            // Four bytes, ASCII 'O', 'b', 'j', followed by 1.
            byte[] header = await ReadFixedBytesAsync(stream, AvroConstants.InitBytes.Length, async, cancellationToken).ConfigureAwait(false);
            Debug.Assert(header[0] == AvroConstants.InitBytes[0]);
            Debug.Assert(header[1] == AvroConstants.InitBytes[1]);
            Debug.Assert(header[2] == AvroConstants.InitBytes[2]);
            Debug.Assert(header[3] == AvroConstants.InitBytes[3]);

            // File metadata is written as if defined by the following map schema:
            // { "type": "map", "values": "bytes"}
            Dictionary<string, string> metadata = await ReadMapAsync(stream, ReadStringAsync, async, cancellationToken).ConfigureAwait(false);
            Debug.Assert(metadata[AvroConstants.CodecKey] == "null");

            // The 16-byte, randomly-generated sync marker for this file.
            byte[] syncMarker = await ReadFixedBytesAsync(stream, AvroConstants.SyncMarkerSize, async, cancellationToken).ConfigureAwait(false);

            // Parse the schema
            using JsonDocument schema = JsonDocument.Parse(metadata[AvroConstants.SchemaKey]);
            AvroType itemType = AvroType.FromSchema(schema.RootElement);

            // File data blocks
            var data = new List<object>();
            while (stream.Position < stream.Length)
            {
                long length = await ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false);
                await ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false); // Ignore the block size
                while (length-- > 0)
                {
                    object value = await itemType.ReadAsync(stream, async, cancellationToken).ConfigureAwait(false);
                    data.Add(value);
                }
                await ReadFixedBytesAsync(stream, AvroConstants.SyncMarkerSize, async, cancellationToken).ConfigureAwait(false); // Ignore the sync check
            }
            return data;
        }

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

        private static async Task<byte> ReadByteAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadFixedBytesAsync(stream, 1, async, cancellationToken).ConfigureAwait(false);
            return bytes[0];
        }

        // Stolen because the linked references in the Avro spec were subpar...
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

        public static Task<object> ReadNullAsync() => Task.FromResult<object>(null);

        public static async Task<bool> ReadBoolAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte b = await ReadByteAsync(stream, async, cancellationToken).ConfigureAwait(false);
            return b != 0;
        }

        public static async Task<long> ReadLongAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken) =>
            await ReadZigZagLongAsync(stream, async, cancellationToken).ConfigureAwait(false);

        public static async Task<int> ReadIntAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken) =>
            (int)(await ReadLongAsync(stream, async, cancellationToken).ConfigureAwait(false));

        public static async Task<float> ReadFloatAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadFixedBytesAsync(stream, 4, async, cancellationToken).ConfigureAwait(false);
            return BitConverter.ToSingle(bytes, 0);
        }

        public static async Task<double> ReadDoubleAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadFixedBytesAsync(stream, 8, async, cancellationToken).ConfigureAwait(false);
            return BitConverter.ToDouble(bytes, 0);
        }

        public static async Task<byte[]> ReadBytesAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            int size = await ReadIntAsync(stream, async, cancellationToken).ConfigureAwait(false);
            return await ReadFixedBytesAsync(stream, size, async, cancellationToken).ConfigureAwait(false);
        }

        public static async Task<string> ReadStringAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken)
        {
            byte[] bytes = await ReadBytesAsync(stream, async, cancellationToken).ConfigureAwait(false);
            return Encoding.UTF8.GetString(bytes);
        }

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

        public static async Task<Dictionary<string, T>> ReadMapAsync<T>(
            Stream stream,
            Func<Stream, bool, CancellationToken, Task<T>> parseItemAsync,
            bool async,
            CancellationToken cancellationToken)
        {
            #pragma warning disable AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            #pragma warning disable AZC0108 // Incorrect 'async' parameter value.
            Func<Stream, bool, CancellationToken, Task<KeyValuePair<string, T>>> parsePair =
                async (s, a, c) => await ReadMapPairAsync(s, parseItemAsync, a, c).ConfigureAwait(false);
            #pragma warning restore AZC0108 // Incorrect 'async' parameter value.
            #pragma warning restore AZC0110 // DO NOT use await keyword in possibly synchronous scope.
            IEnumerable<KeyValuePair<string, T>> entries =
                await ReadArrayAsync(stream, parsePair, async, cancellationToken).ConfigureAwait(false);
            return entries.ToDictionary();
        }

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

        internal static List<T> Map<T>(this JsonElement array, Func<JsonElement, T> selector)
        {
            var values = new List<T>();
            foreach (JsonElement element in array.EnumerateArray())
            {
                values.Add(selector(element));
            }
            return values;
        }

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

    internal abstract class AvroType
    {
        public abstract Task<object> ReadAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken);

        public static AvroType FromSchema(JsonElement schema)
        {
            switch (schema.ValueKind)
            {
                // Primitives
                case JsonValueKind.String:
                    {
                        string type = schema.GetString();
                        switch (type)
                        {
                            case "null":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Null };
                            case "boolean":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Boolean };
                            case "int":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Int };
                            case "long":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Long };
                            case "float":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Float };
                            case "double":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Double };
                            case "bytes":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Bytes };
                            case "string":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.String };
                            default:
                                throw new InvalidOperationException($"Unexpected Avro type {type} in {schema}");
                        }
                    }
                // Union types
                case JsonValueKind.Array:
                    return new AvroUnionType { Types = schema.Map(FromSchema) };
                // Everything else
                case JsonValueKind.Object:
                    {
                        string type = schema.GetProperty("type").GetString();
                        switch (type)
                        {
                            // Primitives can be defined as strings or objects
                            case "null":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Null };
                            case "boolean":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Boolean };
                            case "int":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Int };
                            case "long":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Long };
                            case "float":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Float };
                            case "double":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Double };
                            case "bytes":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.Bytes };
                            case "string":
                                return new AvroPrimitiveType { Primitive = AvroPrimitive.String };
                            case "record":
                                if (schema.TryGetProperty("aliases", out var _)) throw new InvalidOperationException($"Unexpected aliases on {schema}");
                                string name = schema.GetProperty("name").GetString();
                                Dictionary<string, AvroType> fields = new Dictionary<string, AvroType>();
                                foreach (JsonElement field in schema.GetProperty("fields").EnumerateArray())
                                {
                                    fields[field.GetProperty("name").GetString()] = FromSchema(field.GetProperty("type"));
                                }
                                return new AvroRecordType { Schema = name, Fields = fields };
                            case "enum":
                                if (schema.TryGetProperty("aliases", out var _)) throw new InvalidOperationException($"Unexpected aliases on {schema}");
                                return new AvroEnumType { Symbols = schema.GetProperty("symbols").Map(s => s.GetString()) };
                            case "map":
                                return new AvroMapType { ItemType = FromSchema(schema.GetProperty("values")) };
                            case "array": // Unused today
                            case "union": // Unused today
                            case "fixed": // Unused today
                            default:
                                throw new InvalidOperationException($"Unexpected Avro type {type} in {schema}");
                        }
                    }
                default:
                    throw new InvalidOperationException($"Unexpected JSON Element: {schema}");
            }
        }
    }

    internal enum AvroPrimitive { Null, Boolean, Int, Long, Float, Double, Bytes, String };

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
