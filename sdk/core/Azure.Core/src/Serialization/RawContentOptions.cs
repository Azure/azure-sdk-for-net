// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Dynamic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Enables configuration of options for raw request and response content.
    /// </summary>
    public class RawContentOptions
    {
        /// <summary>
        /// Creates a new instance of RawContentOptions.
        /// </summary>
        public RawContentOptions() { }

        /// <summary>
        /// By default, anonymous and dynamic types used to create and access protocol method request
        /// and response content will map property names used in .NET code to exact names in the
        /// content data.  Setting this value to true has the effect of converting property names used with
        /// anonymous and dynamic types to camel case when accessing the content data.
        /// If needed, it can be overridden per instance by passing different options to
        /// to <see cref="RequestContent.Create(object, PropertyNamingConvention)"/> or <see cref="AzureCoreExtensions.ToDynamicFromJson(BinaryData, PropertyNamingConvention)"/>.
        /// </summary>
        public bool UseCamelCaseNamingConvention { get; set; }

        internal DynamicDataOptions GetDynamicOptions()
        {
            DynamicDataOptions options = new DynamicDataOptions()
            {
                DateTimeHandling = DynamicDateTimeHandling.Rfc3339
            };

            if (UseCamelCaseNamingConvention )
            {
                options.PropertyNamingConvention = PropertyNamingConvention.CamelCase;
            }

            return options;
        }
    }
}
