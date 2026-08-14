// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.GeoJson;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Communication.Messages
{
    /// <summary> The message template's location value information. </summary>
    [CodeGenSuppress("MessageTemplateLocation", typeof(string), typeof(double), typeof(double))]
    public partial class MessageTemplateLocation
    {
        /// <summary> The latitude of the location. </summary>
        [CodeGenMember("Latitude")]
        internal double LatitudeInternal
        {
            get => Position.Latitude;
            set => Position = new GeoPosition(Position.Longitude, value);
        }

        /// <summary> The longitude of the location. </summary>
        [CodeGenMember("Longitude")]
        internal double LongitudeInternal
        {
            get => Position.Longitude;
            set => Position = new GeoPosition(value, Position.Latitude);
        }

        /// <summary> The geo position of the location. </summary>
        public GeoPosition Position { get; set; } = new GeoPosition();

        /// <summary> Initializes a new instance of <see cref="MessageTemplateLocation"/>. </summary>
        /// <param name="name"> Name of the Template value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public MessageTemplateLocation(string name) : base(name, MessageTemplateValueKind.Location)
        {
            Argument.AssertNotNull(name, nameof(name));
        }
    }
}
