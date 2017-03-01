// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for RoutingSource.
    /// </summary>
    public static class RoutingSource
    {
        public const string DeviceMessages = "DeviceMessages";
        public const string TwinChangeEvents = "TwinChangeEvents";
        public const string DeviceLifecycleEvents = "DeviceLifecycleEvents";
        public const string DeviceJobLifecycleEvents = "DeviceJobLifecycleEvents";
    }
}
