// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;

namespace StorSimple.Tests.Utilities
{
    /// <summary>
    /// Static helper methods used in writing tests
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Helper method to copy properties from one object to another (Shallow copy)
        /// Copies only properties which are present in both the source and the destination
        /// classes with matching names and types.
        /// Example usage would be to copy properties between model objects for request and response
        /// Say DeviceDetails and DeviceDetailsRequest
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="destination">Destination object</param>
        public static void CopyProperties(Object source, Object destination)
        {
            var sourceType = source.GetType();
            var destType = destination.GetType();
            foreach (var sourceProperty in sourceType.GetProperties())
            {
                // Copy only if destination has a property by the same name and type as the source
                var destProperty = destType.GetProperty(sourceProperty.Name);
                if (destProperty != null && destProperty.PropertyType == sourceProperty.PropertyType)
                {
                    // Get value out of the source object
                    var sourceValue = sourceProperty.GetGetMethod().Invoke(source, null); 
                    // set it on the destination object
                    destProperty.GetSetMethod().Invoke(destination, new[] { sourceValue });
                }
            }
        }
    }
}
