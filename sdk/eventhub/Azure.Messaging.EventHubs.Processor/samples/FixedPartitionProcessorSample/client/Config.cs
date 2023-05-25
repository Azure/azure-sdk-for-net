namespace Client;

using System;
using EventHubProcessors;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This class is used to configure this application.
/// </summary>
internal class Config : IConfig, IEventHubFixedPartitionProcessorConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Config"/> class.
    /// </summary>
    /// <param name="config">The configuration.</param>
    public Config(IConfiguration config)
    {
        this.STORAGE_CONNSTRING = config.GetValue<string>("STORAGE_CONNSTRING");
        this.STORAGE_CONTAINER_NAME = config.GetValue<string>("STORAGE_CONTAINER_NAME");
        this.INBOUND_EVENTHUB_CONNSTRING = config.GetValue<string>("INBOUND_EVENTHUB_CONNSTRING");
        this.INBOUND_EVENTHUB_CONSUMER_GROUP = config.GetValue<string>("INBOUND_EVENTHUB_CONSUMER_GROUP");
        this.INBOUND_EVENTHUB_MAX_BATCH_SIZE = Math.Clamp(config.GetValue<int>("INBOUND_EVENTHUB_MAX_BATCH_SIZE", 30), 1, 1000);
        this.ASSIGN_TO_X_PARTITIONS = Math.Clamp(config.GetValue<int>("ASSIGN_TO_X_PARTITIONS", 32), 1, 32);
        this.LEASE_FOR_X_SEC = TimeSpan.FromSeconds(Math.Clamp(config.GetValue<int>("LEASE_FOR_X_SEC", 60), 10, 60));
        this.RENEW_EVERY_X_SEC = TimeSpan.FromSeconds(Math.Clamp(config.GetValue<int>("RENEW_EVERY_X_SEC", 18), 1, 60));
    }

    /// <inheritdoc />
    public string STORAGE_CONNSTRING { get; }

    /// <inheritdoc />
    public string STORAGE_CONTAINER_NAME { get; }

    /// <inheritdoc />
    public string INBOUND_EVENTHUB_CONNSTRING { get; }

    /// <inheritdoc />
    public string INBOUND_EVENTHUB_CONSUMER_GROUP { get; }

    /// <inheritdoc />
    public int INBOUND_EVENTHUB_MAX_BATCH_SIZE { get; }

    /// <inheritdoc />
    public int ASSIGN_TO_X_PARTITIONS { get; }

    /// <inheritdoc />
    public TimeSpan LEASE_FOR_X_SEC { get; }

    /// <inheritdoc />
    public TimeSpan RENEW_EVERY_X_SEC { get; }

    /// <inheritdoc />
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(this.STORAGE_CONNSTRING))
        {
            throw new Exception("STORAGE_CONNSTRING is required.");
        }

        if (string.IsNullOrWhiteSpace(this.STORAGE_CONTAINER_NAME))
        {
            throw new Exception("STORAGE_CONTAINER_NAME is required.");
        }

        if (string.IsNullOrWhiteSpace(this.INBOUND_EVENTHUB_CONNSTRING))
        {
            throw new Exception("INBOUND_EVENTHUB_CONNSTRING is required.");
        }

        if (string.IsNullOrWhiteSpace(this.INBOUND_EVENTHUB_CONSUMER_GROUP))
        {
            throw new Exception("INBOUND_EVENTHUB_CONSUMER_GROUP is required.");
        }
    }
}