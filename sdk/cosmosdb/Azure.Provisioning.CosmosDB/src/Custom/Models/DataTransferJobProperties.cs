// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
#pragma warning disable CS1591

using System;
using System.ComponentModel;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.CosmosDB;

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

    public BicepValue<string> JobName
    {
        get { Initialize(); return _jobName!; }
    }

    public DataTransferDataSourceSink Source
    {
        get { Initialize(); return _source!; }
        set { Initialize(); AssignOrReplace(ref _source, value); }
    }

    public DataTransferDataSourceSink Destination
    {
        get { Initialize(); return _destination!; }
        set { Initialize(); AssignOrReplace(ref _destination, value); }
    }

    public BicepValue<string> Status
    {
        get { Initialize(); return _status!; }
    }

    public BicepValue<long> ProcessedCount
    {
        get { Initialize(); return _processedCount!; }
    }

    public BicepValue<long> TotalCount
    {
        get { Initialize(); return _totalCount!; }
    }

    public BicepValue<DateTimeOffset> LastUpdatedUtcOn
    {
        get { Initialize(); return _lastUpdatedUtcOn!; }
    }

    public BicepValue<int> WorkerCount
    {
        get { Initialize(); return _workerCount!; }
        set { Initialize(); _workerCount!.Assign(value); }
    }

    public CosmosDBErrorResult ErrorResult
    {
        get { Initialize(); return _errorResult!; }
    }

    public BicepValue<TimeSpan> Duration
    {
        get { Initialize(); return _duration!; }
    }

    public BicepValue<DataTransferJobMode> Mode
    {
        get { Initialize(); return _mode!; }
        set { Initialize(); _mode!.Assign(value); }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public ErrorResponse? Error =>
        ErrorResult is not null ? new ErrorResponse(ErrorResult) : null;

    public DataTransferJobProperties()
    {
    }

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
