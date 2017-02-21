// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for OperationMonitoringLevel.
    /// </summary>
    public static class OperationMonitoringLevel
    {
        public const string None = "None";
        public const string Error = "Error";
        public const string Information = "Information";
        public const string ErrorInformation = "Error, Information";
    }
}
