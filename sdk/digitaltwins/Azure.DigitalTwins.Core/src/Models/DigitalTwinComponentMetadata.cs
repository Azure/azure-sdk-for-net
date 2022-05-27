// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// An optional, helper class for deserializing a digital twin.
    /// The $metadata class on a <see cref="BasicDigitalTwinComponent"/>.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    [JsonConverter(typeof(DigitalTwinComponentMetadataJsonConverter))]
    public class DigitalTwinComponentMetadata : IDictionary<string, DigitalTwinPropertyMetadata>
    {
        /// <summary>
        /// TODO
        /// </summary>
        public DigitalTwinPropertyMetadata this[string key] { get => PropertyMetadata[key]; set => PropertyMetadata[key] = value; }

        /// <summary>
        /// The date and time the component was last updated.
        /// </summary>
        [JsonPropertyName(DigitalTwinsJsonPropertyNames.MetadataLastUpdateTime)]
        public string LastUpdatedOn { get; set; }

        /// <summary>
        /// This field will contain metadata about changes on properties on the component.
        /// The key will be the property name, and the value is the metadata.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public IDictionary<string, DigitalTwinPropertyMetadata> PropertyMetadata { get; set; } = new Dictionary<string, DigitalTwinPropertyMetadata>();
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// TODO
        /// </summary>
        public ICollection<string> Keys => PropertyMetadata.Keys;

        /// <summary>
        /// TODO
        /// </summary>
        public ICollection<DigitalTwinPropertyMetadata> Values => PropertyMetadata.Values;

        /// <summary>
        /// TODO
        /// </summary>
        public int Count => PropertyMetadata.Count;

        /// <summary>
        /// TODO
        /// </summary>
        public bool IsReadOnly => PropertyMetadata.IsReadOnly;

        /// <summary>
        /// TODO
        /// </summary>
        public void Add(string key, DigitalTwinPropertyMetadata value)
        {
            PropertyMetadata.Add(key, value);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Add(KeyValuePair<string, DigitalTwinPropertyMetadata> item)
        {
            PropertyMetadata.Add(item);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void Clear()
        {
            PropertyMetadata.Clear();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool Contains(KeyValuePair<string, DigitalTwinPropertyMetadata> item)
        {
            return PropertyMetadata.Contains(item);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool ContainsKey(string key)
        {
            return PropertyMetadata.ContainsKey(key);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void CopyTo(KeyValuePair<string, DigitalTwinPropertyMetadata>[] array, int arrayIndex)
        {
            PropertyMetadata.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public IEnumerator<KeyValuePair<string, DigitalTwinPropertyMetadata>> GetEnumerator()
        {
            return PropertyMetadata.GetEnumerator();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool Remove(string key)
        {
            return PropertyMetadata.Remove(key);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool Remove(KeyValuePair<string, DigitalTwinPropertyMetadata> item)
        {
            return PropertyMetadata.Remove(item);
        }

        /// <summary>
        /// TODO
        /// </summary>
        public bool TryGetValue(string key, out DigitalTwinPropertyMetadata value)
        {
            return PropertyMetadata.TryGetValue(key, out value);
        }

        /// <summary>
        /// TODO
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)PropertyMetadata).GetEnumerator();
        }
    }
}
