// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Restore a supporting type for the preview-only data transfer API exposed by the
// previous GA package but omitted from the selected stable TypeSpec version.
/// <summary>
/// The properties of a DataTransfer Job.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public partial class DataTransferJobProperties : ProvisionableConstruct
{
    private BicepValue<string>? _jobName;
    private DataTransferDataSourceSink? _source;
    private DataTransferDataSourceSink? _destination;
    private BicepValue<string>? _status;
    private BicepValue<long>? _processedCount;
    private BicepValue<long>? _totalCount;
    private BicepValue<DateTimeOffset>? _lastUpdatedUtcOn;
    private BicepValue<int>? _workerCount;
    private CosmosDBErrorResult? _errorResult;
    private BicepValue<TimeSpan>? _duration;
    private BicepValue<DataTransferJobMode>? _mode;

    /// <summary>
    /// Job Name.
    /// </summary>
    public BicepValue<string> JobName
    {
        get { Initialize(); return _jobName!; }
    }

    /// <summary>
    /// Source DataStore details             Please note
    /// Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink is
    /// the base class. According to the scenario, a derived class of the base
    /// class might need to be assigned here, or this property needs to be
    /// casted to one of the possible derived classes.             The
    /// available derived classes include
    /// Azure.ResourceManager.CosmosDB.Models.AzureBlobDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.BaseCosmosDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.CosmosCassandraDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.CosmosMongoDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.CosmosMongoVCoreDataTransferDataSourceSink
    /// and
    /// Azure.ResourceManager.CosmosDB.Models.CosmosSqlDataTransferDataSourceSink.
    /// </summary>
    public DataTransferDataSourceSink Source
    {
        get { Initialize(); return _source!; }
        set { Initialize(); AssignOrReplace(ref _source, value); }
    }

    /// <summary>
    /// Destination DataStore details             Please note
    /// Azure.ResourceManager.CosmosDB.Models.DataTransferDataSourceSink is
    /// the base class. According to the scenario, a derived class of the base
    /// class might need to be assigned here, or this property needs to be
    /// casted to one of the possible derived classes.             The
    /// available derived classes include
    /// Azure.ResourceManager.CosmosDB.Models.AzureBlobDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.BaseCosmosDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.CosmosCassandraDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.CosmosMongoDataTransferDataSourceSink,
    /// Azure.ResourceManager.CosmosDB.Models.CosmosMongoVCoreDataTransferDataSourceSink
    /// and
    /// Azure.ResourceManager.CosmosDB.Models.CosmosSqlDataTransferDataSourceSink.
    /// </summary>
    public DataTransferDataSourceSink Destination
    {
        get { Initialize(); return _destination!; }
        set { Initialize(); AssignOrReplace(ref _destination, value); }
    }

    /// <summary>
    /// Job Status.
    /// </summary>
    public BicepValue<string> Status
    {
        get { Initialize(); return _status!; }
    }

    /// <summary>
    /// Processed Count.
    /// </summary>
    public BicepValue<long> ProcessedCount
    {
        get { Initialize(); return _processedCount!; }
    }

    /// <summary>
    /// Total Count.
    /// </summary>
    public BicepValue<long> TotalCount
    {
        get { Initialize(); return _totalCount!; }
    }

    /// <summary>
    /// Last Updated Time (ISO-8601 format).
    /// </summary>
    public BicepValue<DateTimeOffset> LastUpdatedUtcOn
    {
        get { Initialize(); return _lastUpdatedUtcOn!; }
    }

    /// <summary>
    /// Worker count.
    /// </summary>
    public BicepValue<int> WorkerCount
    {
        get { Initialize(); return _workerCount!; }
        set { Initialize(); _workerCount!.Assign(value); }
    }

    /// <summary>
    /// Error response for Faulted job.
    /// </summary>
    public CosmosDBErrorResult ErrorResult
    {
        get { Initialize(); return _errorResult!; }
    }

    /// <summary>
    /// Total Duration of Job.
    /// </summary>
    public BicepValue<TimeSpan> Duration
    {
        get { Initialize(); return _duration!; }
    }

    /// <summary>
    /// Mode of job execution.
    /// </summary>
    public BicepValue<DataTransferJobMode> Mode
    {
        get { Initialize(); return _mode!; }
        set { Initialize(); _mode!.Assign(value); }
    }

    /// <summary>
    /// Gets the error response for a faulted job.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ErrorResponse? Error =>
        ErrorResult is not null ? new ErrorResponse(ErrorResult) : null;

    /// <summary>
    /// Creates a new DataTransferJobProperties.
    /// </summary>
    public DataTransferJobProperties()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DataTransferJobProperties.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _jobName = DefineProperty<string>("JobName", ["jobName"], isOutput: true);
        _source = DefineModelProperty<DataTransferDataSourceSink>("Source", ["source"]);
        _destination = DefineModelProperty<DataTransferDataSourceSink>("Destination", ["destination"]);
        _status = DefineProperty<string>("Status", ["status"], isOutput: true);
        _processedCount = DefineProperty<long>("ProcessedCount", ["processedCount"], isOutput: true);
        _totalCount = DefineProperty<long>("TotalCount", ["totalCount"], isOutput: true);
        _lastUpdatedUtcOn = DefineProperty<DateTimeOffset>("LastUpdatedUtcOn", ["lastUpdatedUtcTime"], isOutput: true);
        _workerCount = DefineProperty<int>("WorkerCount", ["workerCount"]);
        _errorResult = DefineModelProperty<CosmosDBErrorResult>("ErrorResult", ["error"], isOutput: true);
        _duration = DefineProperty<TimeSpan>("Duration", ["duration"], isOutput: true);
        _mode = DefineProperty<DataTransferJobMode>("Mode", ["mode"]);
    }
}
