// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avro;
using Avro.Generic;
using Avro.IO;
using Avro.Specific;
using Azure.Core.Serialization;
using Azure.Data.SchemaRegistry.Models;

namespace Azure.Data.SchemaRegistry.Avro
{
    /// <summary>
    /// A <see cref="AvroObjectSerializer"/> implementation that uses <see cref="SchemaRegistryClient"/> for SpecificRecord serialization/deserialization.
    /// </summary>
    public class AvroObjectSerializer : ObjectSerializer//, IMemberNameConverter
    {
        //private readonly ConcurrentDictionary<MemberInfo, string?> _cache;
        //private readonly JsonSerializerOptions _options;

        private readonly SchemaRegistryClient _client;
        //private readonly string _schemaContent;
        private readonly string _groupName;
        private readonly AvroObjectSerializerOptions _options;


        /// <summary>
        /// Initializes new instance of <see cref="AvroObjectSerializer"/>.
        /// </summary>
        public AvroObjectSerializer(SchemaRegistryClient client, string groupName, AvroObjectSerializerOptions options = null) //: this(new JsonSerializerOptions())
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            //_schemaContent = schemaContent;
            _groupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
            _options = options;

        }

        ///// <summary>
        ///// Initializes new instance of <see cref="AvroObjectSerializer"/>.
        ///// </summary>
        ///// <param name="options">The <see cref="JsonSerializerOptions"/> instance to use when serializing/deserializing.</param>
        ///// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        //public AvroObjectSerializer(JsonSerializerOptions options)
        //{
        //    //_options = options ?? throw new ArgumentNullException(nameof(options));

        //    //// TODO: Consider using WeakReference cache to allow the GC to collect if the JsonObjectSerialized is held for a long duration.
        //    //_cache = new ConcurrentDictionary<MemberInfo, string?>();
        //}


        //private void Map(object value)
        //{
        //    if (value is Schema.Type.Array)
        //}

        //private static Dictionary<Type, (>

        //private class SpecificRecordSerializer
        //{
        //    private readonly Type _type;
        //    //private readonly string _schema;



        //    public SpecificRecordSerializer(Type type)
        //    {
        //        if (type == null)
        //        {
        //            throw new ArgumentNullException(nameof(type));
        //        }

        //        _type = type;
        //        //_schema = schema;
        //    }

        //    public void Serialize(Stream stream, object value)
        //    {
        //        ////throw new NotImplementedException();
        //        ////https://stackoverflow.com/a/1151470/294804
        //        //var datumWriterType = typeof(SpecificDatumWriter<>).MakeGenericType(_type);
        //        ////https://stackoverflow.com/a/2451341/294804
        //        //dynamic writer = Activator.CreateInstance(datumWriterType, schema);


        //        ////https://stackoverflow.com/a/4667999/294804
        //        //var writerType = typeof(DataFileWriter<>).MakeGenericType(typeof(Employee));
        //        ////var openWriterMethod = writerType.GetMethod("OpenWriter", BindingFlags.Public | BindingFlags.Static);
        //        //var datumBaseType = typeof(DatumWriter<>).MakeGenericType(typeof(Employee));
        //        //var openWriterMethod = writerType.GetMethod("OpenWriter", new[] { datumBaseType, typeof(Stream) });
        //        //dynamic fileWriter = openWriterMethod?.Invoke(null, new[] { writer, writeFileStream });

        //        ////var writer = new SpecificDatumWriter<Employee>(schema);
        //        ////var fileWriter = DataFileWriter<Employee>.OpenWriter(writer, employeePath);







        //        //fileWriter?.Append(employee);
        //        //fileWriter?.Close();

        //        if (!(value is ISpecificRecord specificRecord))
        //        {
        //            throw new ArgumentException("Wrong value type.");
        //        }

        //        //https://stackoverflow.com/a/1151470/294804
        //        var datumWriterType = typeof(SpecificDatumWriter<>).MakeGenericType(_type);
        //        //https://stackoverflow.com/a/2451341/294804
        //        dynamic writer = Activator.CreateInstance(datumWriterType, specificRecord.Schema);
        //        var binaryEncoder = new BinaryEncoder(stream);

        //        writer?.Write(value, binaryEncoder);
        //        binaryEncoder.Flush();
        //    }

        //    //public ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        //    //{
        //    //    throw new NotImplementedException();
        //    //}

        //    public object Deserialize(Stream stream)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    //public ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        //    //{
        //    //    throw new NotImplementedException();
        //    //}
        //}

        private static Schema GetSchemaFromType(Type type)
        {
            //https://stackoverflow.com/a/5898469/294804
            var schemaField = type.GetField("_SCHEMA", BindingFlags.Public | BindingFlags.Static);
            if (!(schemaField?.GetValue(null) is Schema schema))
            {
                throw new MissingFieldException($"Field _SCHEMA is missing on type {type.Name}.");
            }

            return schema;
        }

        //private static Schema GetSchemaFromValue(object value)
        //{
        //    //https://stackoverflow.com/a/5898469/294804
        //    var schemaField = type.GetField("_SCHEMA", BindingFlags.Public | BindingFlags.Static);
        //    if (!(schemaField?.GetValue(null) is Schema schema))
        //    {
        //        throw new MissingFieldException($"Field _SCHEMA is missing on type {type.Name}.");
        //    }

        //    return schema;
        //}

        private static readonly byte[] s_emptyRecordFormatIndicator = { 0, 0, 0, 0 };

        /// <inheritdoc />
        public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            //if (!(value is IEnumerable<GenericRecord> records))
            //{
            //    throw new ArgumentException("Wrong value type.");
            //}

            //if (!(value is ISpecificRecord specificRecord))
            //{
            //    throw new ArgumentException("Wrong value type.");
            //}

            var isSpecific = typeof(ISpecificRecord).IsAssignableFrom(inputType);
            if (isSpecific)
            {
                //var schema = GetSchemaFromType(inputType);
                var schema = ((ISpecificRecord)value).Schema;
                var schemaProperties = _options.AutoRegisterSchemas
                    ? _client.RegisterSchema(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString())
                    : _client.GetSchemaId(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString());

                ////https://stackoverflow.com/a/1151470/294804
                //var datumWriterType = typeof(SpecificDatumWriter<>).MakeGenericType(inputType);
                ////https://stackoverflow.com/a/2451341/294804
                //dynamic writer = Activator.CreateInstance(datumWriterType, schema);


                //stream.Write(s_emptyRecordFormatIndicator, 0, 4);
                //var schemaId = Encoding.UTF8.GetBytes(schemaProperties.Value.Id);
                //stream.Write(schemaId, 0, 32);

                //var binaryEncoder = new BinaryEncoder(stream);
                //var writeMethod = datumWriterType.GetMethod("Write", new[] { inputType, typeof(Encoder) });
                //writeMethod?.Invoke(writer, new[] { value, binaryEncoder });
                //binaryEncoder.Flush();


                //https://stackoverflow.com/a/1151470/294804
                //var datumWriterType = typeof(SpecificDatumWriter<>).MakeGenericType(inputType);
                //https://stackoverflow.com/a/2451341/294804
                var writer = new SpecificDatumWriter<object>(schema);


                stream.Write(s_emptyRecordFormatIndicator, 0, 4);
                var schemaId = Encoding.UTF8.GetBytes(schemaProperties.Value.Id);
                stream.Write(schemaId, 0, 32);

                var binaryEncoder = new BinaryEncoder(stream);
                writer.Write(value, binaryEncoder);
                //var writeMethod = datumWriterType.GetMethod("Write", new[] { inputType, typeof(Encoder) });
                //writeMethod?.Invoke(writer, new[] { value, binaryEncoder });
                binaryEncoder.Flush();
                return;
            }

            var isGeneric = typeof(GenericRecord).IsAssignableFrom(inputType);
            if (isGeneric)
            {
                var schema = ((GenericRecord)value).Schema;
                var schemaProperties = _options.AutoRegisterSchemas
                    ? _client.RegisterSchema(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString())
                    : _client.GetSchemaId(_groupName, schema.Fullname, SerializationType.Avro, schema.ToString());

                var writer = new GenericDatumWriter<object>(schema);
                stream.Write(s_emptyRecordFormatIndicator, 0, 4);
                var schemaId = Encoding.UTF8.GetBytes(schemaProperties.Value.Id);
                stream.Write(schemaId, 0, 32);

                var binaryEncoder = new BinaryEncoder(stream);
                writer.Write(value, binaryEncoder);
                binaryEncoder.Flush();
                return;
            }
            //var genericWriter = new GenericDatumWriter<object>(null);



            //stream.Write(s_emptyRecordFormatIndicator, 0, 4);
            //var schemaId = Encoding.UTF8.GetBytes(schemaProperties.Value.Id);
            //stream.Write(schemaId, 0, 32);

            //var binaryEncoder = new BinaryEncoder(stream);
            //writer.Write(value, binaryEncoder);
            ////var writeMethod = datumWriterType.GetMethod("Write", new[] { inputType, typeof(Encoder) });
            ////writeMethod?.Invoke(writer, new[] { value, binaryEncoder });
            //binaryEncoder.Flush();

        }

        /// <inheritdoc />
        public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            await Task.Run(() => Serialize(stream, value, inputType, cancellationToken), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            //using var memoryStream = new MemoryStream();
            //stream.CopyTo(memoryStream);
            //return JsonSerializer.Deserialize(memoryStream.ToArray(), returnType, _options);



            //var records = new List<GenericRecord>();
            //using var reader = DataFileReader<GenericRecord>.OpenReader(stream);
            //while (reader.HasNext())
            //{
            //    records.Add(reader.Next());
            //}

            //return records;

            var isSpecific = typeof(ISpecificRecord).IsAssignableFrom(returnType);
            if (isSpecific)
            {
                using var memoryStream = new MemoryStream();
                stream.Position = 0;
                stream.CopyTo(memoryStream);
                var message = new Memory<byte>(memoryStream.ToArray());

                var recordFormatIdentifier = message.Slice(0, 4).ToArray();
                if (!recordFormatIdentifier.SequenceEqual(s_emptyRecordFormatIndicator))
                {
                    throw new InvalidDataContractException("The record format identifier for the message is invalid.");
                }

                var schemaIdBytes = message.Slice(4, 32).ToArray();
                var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
                var schema = Schema.Parse(_client.GetSchema(schemaId).Value.Content);
                var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());

                var binaryDecoder = new BinaryDecoder(valueStream);
                ////https://stackoverflow.com/a/1151470/294804
                //var datumReaderType = typeof(SpecificDatumReader<>).MakeGenericType(returnType);
                ////https://stackoverflow.com/a/2451341/294804
                //dynamic reader = Activator.CreateInstance(datumReaderType, schema, schema);

                //var readMethod = datumReaderType.GetMethod("Read", new[] { returnType, typeof(Decoder) });
                //return readMethod?.Invoke(reader, new object[] { null, binaryDecoder });
                var reader = new SpecificDatumReader<object>(schema, schema);
                return reader.Read(null, binaryDecoder);
            }

            var isGeneric = typeof(GenericRecord).IsAssignableFrom(returnType);
            if (isGeneric)
            {
                using var memoryStream = new MemoryStream();
                stream.Position = 0;
                stream.CopyTo(memoryStream);
                var message = new Memory<byte>(memoryStream.ToArray());

                var recordFormatIdentifier = message.Slice(0, 4).ToArray();
                if (!recordFormatIdentifier.SequenceEqual(s_emptyRecordFormatIndicator))
                {
                    throw new InvalidDataContractException("The record format identifier for the message is invalid.");
                }

                var schemaIdBytes = message.Slice(4, 32).ToArray();
                var schemaId = Encoding.UTF8.GetString(schemaIdBytes);
                var schema = Schema.Parse(_client.GetSchema(schemaId).Value.Content);
                var valueStream = new MemoryStream(message.Slice(36, message.Length - 36).ToArray());

                var binaryDecoder = new BinaryDecoder(valueStream);
                var reader = new GenericDatumReader<object>(schema, schema);
                return reader.Read(null, binaryDecoder);
            }


            return null;
        }

        /// <inheritdoc />
        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            return await Task.Run(() => Deserialize(stream, returnType, cancellationToken), cancellationToken).ConfigureAwait(false);
        }
    }
}
