namespace EventHubProcessors;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Azure Blob Lease class.
/// </summary>
[ExcludeFromCodeCoverage]
internal class AzureBlobLease
{
    /// <summary>
    /// Gets or sets the Id.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the renewal datetime.
    /// </summary>
    public DateTime RenewAt { get; set; }

    /// <summary>
    /// Gets or sets the timeout datetime.
    /// </summary>
    public DateTime TimeoutAt { get; set; }
}
