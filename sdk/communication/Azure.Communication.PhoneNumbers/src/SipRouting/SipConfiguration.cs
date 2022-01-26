// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    public partial class SipConfiguration
    {
        /// <summary> Initializes a new instance of SipConfiguration. </summary>
        /// <param name="trunks"> SIP trunks for routing calls. Map key is trunk&apos;s FQDN (1-249 characters). </param>
        /// <param name="routes"> Trunk routes for routing calls. </param>
        public SipConfiguration(IDictionary<string, SipTrunk> trunks, IEnumerable<SipTrunkRoute> routes)
        {
            Trunks = trunks;
            Routes = routes.ToList();
        }

        /// <summary>
        /// SIP trunks for routing calls.
        /// Map key is trunk&apos;s FQDN (1-249 characters).
        /// </summary>
        public IDictionary<string, SipTrunk>  Trunks { get; }
        /// <summary> Trunk routes for routing calls. </summary>
        public IEnumerable<SipTrunkRoute> Routes { get; }

        // <summary> Initializes a new instance of SipConfiguration. </summary>
        /// <param name="writer"></param>
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
            Optional<IDictionary<string, SipTrunk>> trunks = default;
            Optional<IList<SipTrunkRoute>> routes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("trunks"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    Dictionary<string, SipTrunk> dictionary = new Dictionary<string, SipTrunk>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, SipTrunk.DeserializeSipTrunk(property0.Value));
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
