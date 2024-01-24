// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Messages
{
    /// <summary>  </summary>
    public class MessageTemplateLocation : MessageTemplateValue
    {
        /// <summary>  </summary>
        public MessageTemplateLocation(string name, double latitude, double longitude, string locationName = null, string address = null)
         : base(name)
        {
            Latitude = latitude;
            Longitude = longitude;
            LocationName = locationName;
            Address = address;
        }

        /// <summary> The name of the location. </summary>
        public string LocationName { get; set; }
        /// <summary> The address of the location. </summary>
        public string Address { get; set; }
        /// <summary> The latitude of the location. </summary>
        public double Latitude { get; set; }
        /// <summary> The longitude of the location. </summary>
        public double Longitude { get; set; }

        internal override MessageTemplateValueInternal ToMessageTemplateValueInternal()
        {
            return new MessageTemplateValueInternal(MessageTemplateValueKind.Location)
            {
                Location = new MessageTemplateParameterLocation
                {
                    Name = LocationName,
                    Address = Address,
                    Latitude = Latitude,
                    Longitude = Longitude
                }
            };
        }
    }
}
