using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
