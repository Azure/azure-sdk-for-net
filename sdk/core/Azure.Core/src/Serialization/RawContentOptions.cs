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
        internal RawContentOptions() { }

        /// <summary>
        /// By default, anonymous and dynamic types used to create and access protocol method request
        /// and response content will map property names used in .NET code to exact names in the
        /// content data.  Setting this value to true has the effect of converting property names used with
        /// anonymous and dynamic types to camel case when accessing the content data.
        /// If needed, it can be overridden per instance by passing a value for <see cref="PropertyNameConversion"/>
        /// to [TODO: cref] RequestContent.Create() or <see cref="AzureCoreExtensions.ToDynamicFromJson(BinaryData, PropertyNameConversion, DynamicDateTimeHandling)"/>.
        /// </summary>
        public bool UseCamelCaseNamingConvention { get; set; }

        internal DynamicDataOptions GetDynamicOptions()
        {
            DynamicDataOptions options = new DynamicDataOptions()
            {
                DateTimeHandling = DynamicDateTimeHandling.Rfc3339
            };

            if (UseCamelCaseNamingConvention)
            {
                options.PropertyNameConversion = PropertyNameConversion.CamelCase;
            }

            return options;
        }
    }
}
