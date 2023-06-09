// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        internal ProtocolMethodOptions() { }

        /// <summary>
        /// By default, anonymous and dynamic types used to create and access protocol method
        /// request and response content will map property names used in .NET code to exact names
        /// in the content data.  Setting this value has the effect of establishing a naming
        /// convention that will be used with dynamic response content when accessing the content
        /// data. If needed, it can be overridden per instance by passing different options to
        /// <see cref="AzureCoreExtensions.ToDynamicFromJson(BinaryData, PropertyNamingConvention)"/>.
        ///
        /// Naming conventions can be used with <see cref="RequestContent"/> as well by
        /// calling the <see cref="RequestContent.Create(object, PropertyNamingConvention)"/>
        /// overload.
        /// </summary>
        public PropertyNamingConvention ResponseContentConvention { get; set; }

        internal DynamicDataOptions GetDynamicOptions()
        {
            DynamicDataOptions options = new DynamicDataOptions()
            {
                DateTimeHandling = DynamicDateTimeHandling.Rfc3339
            };

            options.PropertyNamingConvention = ResponseContentConvention;

            return options;
        }
    }
}
