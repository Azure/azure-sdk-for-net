// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    [CodeGenSuppress("SipConfiguration")]
    internal partial class SipConfiguration
    {
        /// <summary>
        /// SIP trunks for routing calls.
        /// Map key is trunk&apos;s FQDN (1-249 characters).
        /// </summary>
        internal IReadOnlyDictionary<string, SipTrunk> Trunks { get; }

        /// <summary> Trunk routes for routing calls. </summary>
        internal IReadOnlyList<SipTrunkRoute> Routes { get; }

        internal SipConfiguration(IDictionary<string, SipTrunk> trunks)
        {
            Trunks = new ReadOnlyDictionary<string, SipTrunk>(trunks);
        }

        internal SipConfiguration(IEnumerable<SipTrunkRoute> routes)
        {
            Routes = routes.ToList().AsReadOnly();
        }

        // <summary> Initializes a new instance of SipConfiguration. </summary>
        /// <param name="writer"> JSON writer to write out the configuration. </param>
        internal void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Trunks != null)
            {
                writer.WritePropertyName("trunks");
                writer.WriteStartObject();

                foreach (KeyValuePair<string, SipTrunk> item in Trunks)
                {
                    if (item.Value != null)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteObjectValue(item.Value);
                    }
                    else
                    {
                        writer.WriteNull(item.Key);
                    }
                }
                writer.WriteEndObject();
            }
            if (Routes != null)
            {
                writer.WritePropertyName("routes");
                writer.WriteStartArray();

                foreach (SipTrunkRoute item in Routes)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static SipConfiguration DeserializeSipConfiguration(JsonElement element)
        {
            Optional<IReadOnlyDictionary<string, SipTrunk>> trunks = default;
            Optional<IReadOnlyList<SipTrunkRoute>> routes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("trunks"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string,SipTrunk> dictionary = new Dictionary<string, SipTrunk>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            var sipTrunk = SipTrunk.DeserializeSipTrunk(property0.Value);
                            sipTrunk.Fqdn = property0.Name;
                            dictionary.Add(property0.Name, sipTrunk);
                        }
                    }
                    trunks = dictionary;
                    continue;
                }
                if (property.NameEquals("routes"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }

                    List<SipTrunkRoute> array = new List<SipTrunkRoute>();

                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SipTrunkRoute.DeserializeSipTrunkRoute(item));
                    }
                    routes = array;
                    continue;
                }
            }
            return new SipConfiguration(Optional.ToDictionary(trunks), Optional.ToList(routes));
        }
    }
}
