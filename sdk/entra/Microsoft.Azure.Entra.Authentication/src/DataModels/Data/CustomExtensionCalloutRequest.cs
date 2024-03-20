namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
{
    /// <summary>
    /// Abstract class that represents the inbound Json payload.
    /// </summary>
    public abstract class CustomExtensionCalloutRequest
    {
        /// <summary>
        /// Gets the event type identifier for the inbound request
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the custom extension identifier for the inbound request
        /// </summary>
        public string Source { get; set; }
    }
}
