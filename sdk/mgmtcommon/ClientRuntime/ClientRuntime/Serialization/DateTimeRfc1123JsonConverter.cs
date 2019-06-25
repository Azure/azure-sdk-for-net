// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Serialization
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    /// <summary>
    /// JsonConverter that handles serialization for dates in RFC1123 format.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rfc", Justification = "Rfc is correct spelling")]
    public class DateTimeRfc1123JsonConverter : IsoDateTimeConverter
    {
        /// <summary>
        /// Initializes a new instance of DateJsonConverter.
        /// </summary>
        public DateTimeRfc1123JsonConverter()
        {
            this.DateTimeFormat = "R";
        }

        //TODO: This method can be removed if we used DateTimeOffsets instead
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                object o = base.ReadJson(reader, objectType, existingValue, serializer);

                //This is required because DateTime is really bad at parsing RFC1123 dates in C#.  Basically it parses the value but 
                //doesn't attach a DateTimeKind to it (even though RFC1123 specification says that the "Kind" should be UTC.  This results
                //in a DateTime WITHOUT a DateTimeKind specifier, which is bad bad bad.  We do the below in order to force the DateTimeKind
                //of the resulting DateTime to be DateTimeKind.Utc since that is what the RFC1123 specification implies.
                //See: http://stackoverflow.com/questions/1201378/how-does-datetime-touniversaltime-work
                //See: http://stackoverflow.com/questions/16442484/datetime-unspecified-kind
                DateTime? time = o as DateTime?;

                if (time.HasValue && time.Value.Kind == DateTimeKind.Unspecified)
                {
                    time = DateTime.SpecifyKind(time.Value, DateTimeKind.Utc);
                }

                return time;
            }
            catch (FormatException ex)
            {
                throw new JsonException("Unable to deserialize a Date.", ex);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                base.WriteJson(writer, value, serializer);
            }
            catch (FormatException ex)
            {
                throw new JsonException("Unable to serialize a Date.", ex);
            }
        }
    }
}
