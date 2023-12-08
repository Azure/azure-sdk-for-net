// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.GeoJson;

namespace Azure.Communication.Messages
{
    /// <summary>  </summary>
    public class MessageTemplateLocation : MessageTemplateValue
    {
        /// <summary>  </summary>
        public MessageTemplateLocation(string name, GeoPosition position)
         : base(name)
        {
            Position = position;
        }

        /// <summary> The geo position of the location. </summary>
        public GeoPosition Position { get; }
        /// <summary> The name of the location. </summary>
        public string LocationName { get; set; }
        /// <summary> The address of the location. </summary>
        public string Address { get; set; }

        internal override MessageTemplateValueInternal ToMessageTemplateValueInternal()
        {
            return new MessageTemplateValueInternal(MessageTemplateValueKind.Location)
            {
                Location = new MessageTemplateParameterLocation
                {
                    Name = LocationName,
                    Address = Address,
                    Latitude = Position.Latitude,
                    Longitude = Position.Longitude
                }
            };
        }
    }
}
