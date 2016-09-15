namespace Microsoft.Azure.Batch.Protocol.Models
{
    /// <summary>
    /// Optional arguments applicable to all service requests.
    /// </summary>
    public interface IOptions
    {
        /// <summary>
        /// Caller generated request identity, in the form of a GUID with no
        /// decoration such as curly braces e.g.
        /// 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.
        /// </summary>
        string ClientRequestId { get; set; }

        /// <summary>
        /// Specifies if the server should return the client-request-id
        /// identifier in the response.
        /// </summary>
        bool? ReturnClientRequestId { get; set; }
    }

    /// <summary>
    /// Optional arguments for service requests which support timeouts.
    /// </summary>
    public interface ITimeoutOptions : IOptions
    {
        /// <summary>
        /// Sets the maximum time that the server can spend processing the
        /// request, in seconds. The default is 30 seconds.
        /// </summary>
        int? Timeout { get; set; }

    }

    /// <summary>
    /// Represents an options object supporting the OData $filter parameter.
    /// </summary>
    public interface IODataFilter
    {
        /// <summary>
        /// Gets or sets the OData $filter clause.
        /// </summary>
        string Filter { get; set; }
    }

    /// <summary>
    /// Represents an options object supporting the OData $select parameter.
    /// </summary>
    public interface IODataSelect
    {
        /// <summary>
        /// Gets or sets the OData $select clause.
        /// </summary>
        string Select { get; set; }
    }

    /// <summary>
    /// Represents an options object supporting the OData $expand parameter.
    /// </summary>
    public interface IODataExpand
    {
        /// <summary>
        /// Gets or sets the OData $expand clause.
        /// </summary>
        string Expand { get; set; }
    }
}
