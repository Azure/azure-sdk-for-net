// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    internal class ValueTypePreservingContractResolver : IContractResolver
    {
        private IContractResolver _innerResolver;
        private ConcurrentCache<Type, JsonObjectContract> _contractCache;

        public ValueTypePreservingContractResolver(IContractResolver innerResolver)
        {
            if (innerResolver == null)
            {
                throw new ArgumentNullException("innerResolver");
            }

            this._innerResolver = innerResolver;
            this._contractCache = new ConcurrentCache<Type, JsonObjectContract>();
        }

        public JsonContract ResolveContract(Type type)
        {
            JsonContract contract = this._innerResolver.ResolveContract(type);
            JsonObjectContract objectContract = contract as JsonObjectContract;

            if (objectContract != null)
            {
                contract = this._contractCache.GetOrAdd(type, t => ResolveObjectContract(objectContract, t));
            }

            return contract;
        }

        private static JsonObjectContract ResolveObjectContract(JsonObjectContract objectContract, Type type)
        {
            // Prepare to create a copy of the contract if necessary. We need to copy it if we're going to mutate
            // it, because JSON.NET caches it and we don't want to alter the shared cached state.
            var newContract = new Lazy<JsonObjectContract>(() => CopyContract(objectContract, type));

            foreach (JsonProperty property in objectContract.Properties)
            {
                if (property.PropertyType.GetTypeInfo().IsValueType && !IsNullable(property.PropertyType))
                {
                    JsonProperty newProperty =
                        newContract.Value.Properties.GetProperty(property.PropertyName, StringComparison.Ordinal);
                    newProperty.DefaultValueHandling = DefaultValueHandling.Include;
                }
            }

            return newContract.IsValueCreated ? newContract.Value : objectContract;
        }

        private static JsonObjectContract CopyContract(JsonObjectContract contract, Type type)
        {
            var copy = new JsonObjectContract(type);
            CopyCollection(contract.CreatorParameters, copy.CreatorParameters);
            copy.Converter = contract.Converter;
            copy.CreatedType = contract.CreatedType;
            copy.DefaultCreator = contract.DefaultCreator;
            copy.DefaultCreatorNonPublic = contract.DefaultCreatorNonPublic;
            copy.ExtensionDataGetter = contract.ExtensionDataGetter;
            copy.ExtensionDataSetter = contract.ExtensionDataSetter;
            copy.IsReference = contract.IsReference;
            copy.ItemConverter = contract.ItemConverter;
            copy.ItemIsReference = contract.ItemIsReference;
            copy.ItemReferenceLoopHandling = contract.ItemReferenceLoopHandling;
            copy.ItemRequired = contract.ItemRequired;
            copy.ItemTypeNameHandling = contract.ItemTypeNameHandling;
            copy.MemberSerialization = contract.MemberSerialization;
            CopyCollection(contract.OnDeserializedCallbacks, copy.OnDeserializedCallbacks);
            CopyCollection(contract.OnDeserializingCallbacks, copy.OnDeserializingCallbacks);
            CopyCollection(contract.OnErrorCallbacks, copy.OnErrorCallbacks);
            CopyCollection(contract.OnSerializedCallbacks, copy.OnSerializedCallbacks);
            CopyCollection(contract.OnSerializingCallbacks, copy.OnSerializingCallbacks);
            copy.OverrideCreator = contract.OverrideCreator;
            CopyCollection(contract.Properties, copy.Properties);
            return copy;
        }

        private static void CopyCollection<T>(ICollection<T> source, ICollection<T> target)
        {
            foreach (T t in source)
            {
                target.Add(t);
            }
        }

        private static bool IsNullable(Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        // Workaround for the lack of ConcurrentDictionary in .NET Core.
        private class ConcurrentCache<TKey, TValue>
        {
            private Dictionary<TKey, TValue> _dictionary;

            public ConcurrentCache()
            {
                this._dictionary = new Dictionary<TKey, TValue>();
            }

            public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
            {
                // Only call valueFactory once.
                var lazyValue = new Lazy<TValue>(() => valueFactory(key));

                while (true)
                {
                    // Reference may change, so take a snapshot.
                    Dictionary<TKey, TValue> localDictionaryRef = this._dictionary;

                    TValue value;
                    if (localDictionaryRef.TryGetValue(key, out value))
                    {
                        return value;
                    }

                    value = lazyValue.Value;

                    // Reads will be frequent, but writes will be infrequent, so copying the dictionary seems a
                    // reasonable tradeoff to get O(1) lookup performance. The alternative would be O(log n)
                    // for a binary search tree, which we'd have to write ourselves since ImmutableDictionary isn't
                    // supported for PCLs (only .NET 4.5 and .NET Core).
                    var newDictionary = new Dictionary<TKey, TValue>(localDictionaryRef);
                    newDictionary.Add(key, value);

                    Dictionary<TKey, TValue> newLocalRef =
                        Interlocked.CompareExchange(ref this._dictionary, newDictionary, localDictionaryRef);

                    if (newLocalRef == localDictionaryRef)
                    {
                        // Replacement made; Return the value.
                        return value;
                    }
                }
            }
        }
    }
}
