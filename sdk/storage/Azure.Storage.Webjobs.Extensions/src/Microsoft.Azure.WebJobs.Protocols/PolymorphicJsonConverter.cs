// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <remarks>
    /// Unlike $type in JSON.NET, this converter decouples the message data from the .NET class and assembly names.
    /// It also allows emitting a type on the root object.
    /// </remarks>
#if PUBLICPROTOCOL
    public class PolymorphicJsonConverter : JsonConverter
#else
    internal class PolymorphicJsonConverter : JsonConverter
#endif
    {
        private readonly string _typePropertyName;
        private readonly IDictionary<string, Type> _nameToTypeMap;
        private readonly IDictionary<Type, string> _typeToNameMap;

        /// <summary>Initializes a new instance of the <see cref="PolymorphicJsonConverter"/> class.</summary>
        /// <param name="typeMapping">The type names to use when serializing types.</param>
        public PolymorphicJsonConverter(IDictionary<string, Type> typeMapping)
            : this("$$type", typeMapping)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PolymorphicJsonConverter"/> class.</summary>
        /// <param name="typePropertyName">The name of the property in which to serialize the type name.</param>
        /// <param name="typeMapping">The type names to use when serializing types.</param>
        public PolymorphicJsonConverter(string typePropertyName, IDictionary<string, Type> typeMapping)
        {
            if (typePropertyName == null)
            {
                throw new ArgumentNullException("typePropertyName");
            }

            if (typeMapping == null)
            {
                throw new ArgumentNullException("typeMapping");
            }

            _typePropertyName = typePropertyName;
            _nameToTypeMap = typeMapping;

            _typeToNameMap = new Dictionary<Type, string>();

            foreach (KeyValuePair<string, Type> item in _nameToTypeMap)
            {
                _typeToNameMap.Add(item.Value, item.Key);
            }
        }

        /// <summary>Gets the name of the property in which to serialize the type name.</summary>
        public string TypePropertyName
        {
            get { return _typePropertyName; }
        }
        
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return _typeToNameMap.ContainsKey(objectType);
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }

            if (objectType == null)
            {
                throw new NotSupportedException("Deserialization is not supported without specifying a default object Type.");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JToken json = JToken.ReadFrom(reader);

            Type typeToCreate = GetTypeToCreate(json) ?? objectType;

            object target = Activator.CreateInstance(typeToCreate);
            serializer.Populate(json.CreateReader(), target);
            return target;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            Type valueType = value.GetType();

            // Now that we've handled the type, temporarily remove this converter so we can serialize this element and
            // its children without infinite recursion.
            IContractResolver originalContractResolver = serializer.ContractResolver;
            serializer.ContractResolver = new NonCircularContractResolver(valueType);

            JObject json = JObject.FromObject(value, serializer);

            string typeName = GetTypeName(valueType);

            if (typeName != null)
            {
                if (json.Property(_typePropertyName) != null)
                {
                    json.Remove(_typePropertyName);
                }

                json.AddFirst(new JProperty(_typePropertyName, typeName));
            }

            serializer.Serialize(writer, json);

            // Restore this converter so that subsequent siblings can use it.
            serializer.ContractResolver = originalContractResolver;
        }

        /// <summary>Gets all type name mappings in a type hierarchy.</summary>
        /// <typeparam name="T">The root type of the type hierarchy.</typeparam>
        /// <returns>All type name mappings in the type hierarchy.</returns>
        public static IDictionary<string, Type> GetTypeMapping<T>()
        {
            IDictionary<string, Type> typeMapping = new Dictionary<string, Type>();

            foreach (Type type in GetTypesInHierarchy<T>())
            {
                typeMapping.Add(GetDeclaredTypeName(type), type);
            }

            return typeMapping;
        }

        private static IEnumerable<Type> GetTypesInHierarchy<T>()
        {
            return typeof(T).Assembly.GetTypes().Where(t => typeof(T).IsAssignableFrom(t));
        }

        private static string GetDeclaredTypeName(Type type)
        {
            Debug.Assert(type != null, "type must not be null");

            JsonTypeNameAttribute[] attributes = (JsonTypeNameAttribute[])type.GetCustomAttributes(
                typeof(JsonTypeNameAttribute), inherit: false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].TypeName;
            }

            return type.Name;
        }

        private string GetTypeName(Type type)
        {
            if (!_typeToNameMap.ContainsKey(type))
            {
                return null;
            }

            return _typeToNameMap[type];
        }

        private Type GetTypeToCreate(JToken token)
        {
            JObject tokenObject = token as JObject;

            if (tokenObject == null)
            {
                return null;
            }

            JProperty typeProperty = tokenObject.Property(_typePropertyName);

            if (typeProperty == null)
            {
                return null;
            }

            JValue typeValue = typeProperty.Value as JValue;

            if (typeValue == null)
            {
                return null;
            }

            string typeString = typeValue.Value as string;

            if (typeString == null)
            {
                return null;
            }

            if (!_nameToTypeMap.ContainsKey(typeString))
            {
                return null;
            }

            return _nameToTypeMap[typeString];
        }

        private class NonCircularContractResolver : DefaultContractResolver
        {
            private readonly Type _contractType;

            public NonCircularContractResolver(Type contractType)
            {
                Debug.Assert(contractType != null, "contract type must not be null");
                _contractType = contractType;
            }

            protected override JsonContract CreateContract(Type objectType)
            {
                JsonContract contract = base.CreateContract(objectType);

                if (_contractType.IsAssignableFrom(objectType))
                {
                    contract.Converter = null;
                }

                return contract;
            }
        }
    }
}
