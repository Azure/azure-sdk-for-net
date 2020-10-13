// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Helper functions for mutating the <see cref="ExportImportDevice"/> instance.
    /// </summary>
    internal static class ExportImportDeviceExtensions
    {
        /// <summary>
        /// Initializes the <see cref="ExportImportDevice.Tags"/> property using provided values.
        /// </summary>
        public static ExportImportDevice WithTags(this ExportImportDevice device, IDictionary<string, object> tags)
        {
            foreach (var tag in tags)
            {
                device.Tags.Add(tag);
            }
            return device;
        }

        /// <summary>
        /// Initializes the <see cref="ExportImportDevice.Properties"/> property using provided values.
        /// </summary>
        public static ExportImportDevice WithPropertiesFrom(this ExportImportDevice device, TwinProperties properties)
        {

            var container = new PropertyContainer();
            if (properties != null)
            {
                foreach (var property in properties.Desired)
                {
                    container.Desired.Add(property);
                }
                foreach (var property in properties.Reported)
                {
                    container.Reported.Add(property);
                }
            }

            device.Properties = container;

            return device;
        }

        /// <summary>
        /// Initializes the <see cref="ExportImportDevice.ParentScopes"/> property using provided values.
        /// </summary>
        public static ExportImportDevice WithParentScopes(this ExportImportDevice device, IList<string> parentScopes)
        {
            foreach (var parentScope in parentScopes)
            {
                device.ParentScopes.Add(parentScope);
            }
            return device;
        }
    }
}