// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.SipRouting
{
    public partial class SipConfiguration : IUtf8JsonSerializable
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
        ///
        /// Map key is trunk&apos;s FQDN (1-249 characters).
        /// </summary>
        public IEnumerable<KeyValuePair<string, SipTrunk>> Trunks { get; set; }
        /// <summary> Trunk routes for routing calls. </summary>
        public IEnumerable<SipTrunkRoute> Routes { get; set; }

        internal void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Trunks))
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
            if (Optional.IsCollectionDefined(Routes))
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
    }
}
