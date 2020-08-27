// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Avro.File;
using Avro.Generic;
using Avro.Specific;
using Azure.Core.Serialization;

namespace Azure.Data.SchemaRegistry.Avro
{
    /// <summary>
    /// A <see cref="AvroObjectSerializer"/> implementation that uses <see cref="JsonSerializer"/> to for serialization/deserialization.
    /// </summary>
    public class AvroObjectSerializer : ObjectSerializer//, IMemberNameConverter
    {
        //private readonly ConcurrentDictionary<MemberInfo, string?> _cache;
        //private readonly JsonSerializerOptions _options;

        private readonly SchemaRegistryClient _client;
        private readonly string _schemaContent;
        private readonly string _groupName;


        /// <summary>
        /// Initializes new instance of <see cref="AvroObjectSerializer"/>.
        /// </summary>
        public AvroObjectSerializer(SchemaRegistryClient client, string schemaContent, string groupName) //: this(new JsonSerializerOptions())
        {
            _client = client;
            _schemaContent = schemaContent;
            _groupName = groupName;

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

        /// <inheritdoc />
        public override void Serialize(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            //if (!(value is IEnumerable<GenericRecord> records))
            //{
            //    throw new ArgumentException("Wrong value type.");
            //}





            if (!(value is ISpecificRecord specificRecord))
            {
                throw new ArgumentException("Wrong value type.");
            }

            ////https://stackoverflow.com/a/4667999/294804
            //// Get the generic type definition
            //MethodInfo method = inputType.GetMethod("Linq", BindingFlags.Public | BindingFlags.Static);

            //// Build a method with the specific type argument you're interested in
            //method = method.MakeGenericMethod(typeOne);
            //// The "null" is because it's a static method
            //method.Invoke(null, arguments);


            //var datumWriter = new GenericDatumWriter<inputType>(_schema);
            //using var writer = DataFileWriter<GenericRecord>.OpenWriter(datumWriter, stream);
            //foreach (var record in records)
            //{
            //    writer.Append(record);
            //}








            //var buffer = JsonSerializer.SerializeToUtf8Bytes(value, inputType, _options);
            //stream.Write(buffer, 0, buffer.Length);
        }

        /// <inheritdoc />
        public override async ValueTask SerializeAsync(Stream stream, object value, Type inputType, CancellationToken cancellationToken)
        {
            await Task.Run(() => Serialize(stream, value, inputType, cancellationToken), cancellationToken).ConfigureAwait(false);
            //await JsonSerializer.SerializeAsync(stream, value, inputType, _options, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public override object Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            //using var memoryStream = new MemoryStream();
            //stream.CopyTo(memoryStream);
            //return JsonSerializer.Deserialize(memoryStream.ToArray(), returnType, _options);
            var records = new List<GenericRecord>();
            using var reader = DataFileReader<GenericRecord>.OpenReader(stream);
            while (reader.HasNext())
            {
                records.Add(reader.Next());
            }

            return records;
        }

        /// <inheritdoc />
        public override async ValueTask<object> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken)
        {
            return await Task.Run(() => Deserialize(stream, returnType, cancellationToken), cancellationToken).ConfigureAwait(false);
            //return await JsonSerializer.DeserializeAsync(stream, returnType, _options, cancellationToken).ConfigureAwait(false);
        }

        ///// <inheritdoc/>
        //string? IMemberNameConverter.ConvertMemberName(MemberInfo member)
        //{
        //    Argument.AssertNotNull(member, nameof(member));

        //    return _cache.GetOrAdd(member, m =>
        //    {
        //        // Mimics property enumeration based on:
        //        // * https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L130-L191
        //        // * TODO: Add support for fields when .NET 5 GAs (https://github.com/Azure/azure-sdk-for-net/issues/13627)

        //        if (m is PropertyInfo propertyInfo)
        //        {
        //            // Ignore indexers.
        //            if (propertyInfo.GetIndexParameters().Length > 0)
        //            {
        //                return null;
        //            }

        //            // Only support public getters and/or setters.
        //            if (propertyInfo.GetMethod?.IsPublic == true ||
        //                propertyInfo.SetMethod?.IsPublic == true)
        //            {
        //                if (propertyInfo.GetCustomAttribute<JsonIgnoreAttribute>() != null)
        //                {
        //                    return null;
        //                }

        //                // Ignore - but do not assert correctness - for JsonExtensionDataAttribute based on
        //                // https://github.com/dotnet/corefx/blob/v3.1.0/src/System.Text.Json/src/System/Text/Json/Serialization/JsonClassInfo.cs#L244-L261
        //                if (propertyInfo.GetCustomAttribute<JsonExtensionDataAttribute>() != null)
        //                {
        //                    return null;
        //                }

        //                // No need to validate collisions since they are based on the serialized name.
        //                return GetPropertyName(propertyInfo);
        //            }
        //        }

        //        // The member is unsupported or ignored.
        //        return null;
        //    });
        //}

        //private string GetPropertyName(MemberInfo memberInfo)
        //{
        //    // Mimics property name determination based on
        //    // https://github.com/dotnet/runtime/blob/dc8b6f90/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/JsonPropertyInfo.cs#L53-L90

        //    JsonPropertyNameAttribute nameAttribute = memberInfo.GetCustomAttribute<JsonPropertyNameAttribute>(false);
        //    if (nameAttribute != null)
        //    {
        //        return nameAttribute.Name
        //            ?? throw new InvalidOperationException($"The JSON property name for '{memberInfo.DeclaringType}.{memberInfo.Name}' cannot be null.");
        //    }
        //    else if (_options.PropertyNamingPolicy != null)
        //    {
        //        return _options.PropertyNamingPolicy.ConvertName(memberInfo.Name)
        //            ?? throw new InvalidOperationException($"The JSON property name for '{memberInfo.DeclaringType}.{memberInfo.Name}' cannot be null.");
        //    }
        //    else
        //    {
        //        return memberInfo.Name;
        //    }
        //}
    }
}
