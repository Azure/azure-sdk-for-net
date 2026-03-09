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
    public partial class MessageTemplateLocation
    {
        /// <summary> The geo position of the location. </summary>
        public GeoPosition Position
        {
            get => new GeoPosition(Longitude, Latitude);
            set
            {
                Latitude = value.Latitude;
                Longitude = value.Longitude;
            }
        }

        /// <summary> Initializes a new instance of <see cref="MessageTemplateLocation"/>. </summary>
        /// <param name="name"> Name of the Template value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public MessageTemplateLocation(string name) : base(name, MessageTemplateValueKind.Location)
        {
            Argument.AssertNotNull(name, nameof(name));
        }
    }
}
