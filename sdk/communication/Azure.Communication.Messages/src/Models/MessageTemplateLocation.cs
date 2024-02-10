// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;

namespace Azure.Communication.Messages
{
    /// <summary> The message template's location value information. </summary>
    [CodeGenModel("MessageTemplateLocation")]
    public partial class MessageTemplateLocation
    {
        /// <summary> The latitude of the location. </summary>
        [CodeGenMember("Latitude")]
        internal double LatitudeInternal {
            get
            {
                return Position.Latitude;
            }
        }

        /// <summary> The longitude of the location. </summary>
        [CodeGenMember("Longitude")]
        internal double LongitudeInternal
        {
            get
            {
                return Position.Longitude;
            }
        }

        /// <summary> The geo position of the location. </summary>
        public GeoPosition Position { get; set; } = new GeoPosition();

        /// <summary> Initializes a new instance of <see cref="MessageTemplateLocation"/>. </summary>
        /// <param name="name"> Name of the Template value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public MessageTemplateLocation(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Kind = "location";
        }

        // This is a direct copy of the auto-rest generated constructor but we want to make the internal Latitude and Longitude read only
        /// <summary> Initializes a new instance of <see cref="MessageTemplateLocation"/>. </summary>
        /// <param name="name"> Name of the Template value. </param>
        /// <param name="latitudeInternal"> The latitude of the location. </param>
        /// <param name="longitudeInternal"> The longitude of the location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal MessageTemplateLocation(string name, double latitudeInternal, double longitudeInternal) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Kind = "location";
        }

        // This is a direct copy of the auto-rest generated constructor but we want to make the internal Latitude and Longitude read only
        /// <summary> Initializes a new instance of <see cref="MessageTemplateLocation"/>. </summary>
        /// <param name="name"> Name of the Template value. </param>
        /// <param name="kind"> The type discriminator describing a template parameter type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="locationName"> The [Optional] name of the location. </param>
        /// <param name="address"> The [Optional] address of the location. </param>
        /// <param name="latitudeInternal"> The latitude of the location. </param>
        /// <param name="longitudeInternal"> The longitude of the location. </param>
        internal MessageTemplateLocation(string name, string kind, IDictionary<string, BinaryData> serializedAdditionalRawData, string locationName, string address, double latitudeInternal, double longitudeInternal) : base(name, kind, serializedAdditionalRawData)
        {
            LocationName = locationName;
            Address = address;
        }
    }
}
