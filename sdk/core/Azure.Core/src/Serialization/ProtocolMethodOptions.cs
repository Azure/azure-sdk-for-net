// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Dynamic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Enables configuration of options for raw response content.
    /// </summary>
    public class ProtocolMethodOptions
    {
        /// <summary>
        /// Creates a new instance of ProtocolMethodOptions.
        /// </summary>
        internal ProtocolMethodOptions()
        {
            ResponseContentDateTimeFormat = DynamicData.RoundTripFormat;
        }

        /// <summary>
        /// The format used for property names by the service.
        /// </summary>
        public PropertyNameFormat ResponseContentPropertyNameFormat { get; set; }

        /// <summary>
        /// The format used for DateTime values by the service.
        /// </summary>
        public string ResponseContentDateTimeFormat { get; set; }

        internal DynamicDataOptions GetDynamicOptions()
        {
            DynamicDataOptions options = new()
            {
                DateTimeFormat = ResponseContentDateTimeFormat,
                PropertyNameFormat = ResponseContentPropertyNameFormat
            };

            return options;
        }
    }
}
