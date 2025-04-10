// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#if NETFRAMEWORK
using System.Diagnostics;
using System.Diagnostics.Tracing;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Instrumentation.SqlClient.Implementation;

/// <summary>
/// On .NET Framework, neither System.Data.SqlClient nor Microsoft.Data.SqlClient emit DiagnosticSource events.
/// Instead they use EventSource:
/// For System.Data.SqlClient see: <a href="https://github.com/microsoft/referencesource/blob/3b1eaf5203992df69de44c783a3eda37d3d4cd10/System.Data/System/Data/Common/SqlEventSource.cs#L29">reference source</a>.
/// For Microsoft.Data.SqlClient see: <a href="https://github.com/dotnet/SqlClient/blob/ac8bb3f9132e6c104dc3e307fe2d569daed0776f/src/Microsoft.Data.SqlClient/src/Microsoft/Data/SqlClient/SqlClientEventSource.cs#L15">SqlClientEventSource</a>.
///
/// We hook into these event sources and process their BeginExecute/EndExecute events.
/// </summary>
/// <remarks>
/// Note that before version 2.0.0, Microsoft.Data.SqlClient used
/// "Microsoft-AdoNet-SystemData" (same as System.Data.SqlClient), but since
/// 2.0.0 has switched to "Microsoft.Data.SqlClient.EventSource".
/// </remarks>
internal sealed class SqlEventSourceListener : EventListener
{
    internal const string AdoNetEventSourceName = "Microsoft-AdoNet-SystemData";
    internal const string MdsEventSourceName = "Microsoft.Data.SqlClient.EventSource";

    internal const int BeginExecuteEventId = 1;
    internal const int EndExecuteEventId = 2;

    private readonly AsyncLocal<long> beginTimestamp = new();
    private EventSource? adoNetEventSource;
    private EventSource? mdsEventSource;

    public override void Dispose()
    {
        if (this.adoNetEventSource != null)
        {
            this.DisableEvents(this.adoNetEventSource);
        }

        if (this.mdsEventSource != null)
        {
            this.DisableEvents(this.mdsEventSource);
        }

        base.Dispose();
    }

    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource?.Name.StartsWith(AdoNetEventSourceName, StringComparison.Ordinal) == true)
        {
            this.adoNetEventSource = eventSource;
            this.EnableEvents(eventSource, EventLevel.Informational, EventKeywords.All);
        }
        else if (eventSource?.Name.StartsWith(MdsEventSourceName, StringComparison.Ordinal) == true)
        {
            this.mdsEventSource = eventSource;
            this.EnableEvents(eventSource, EventLevel.Informational, EventKeywords.All);
        }

        base.OnEventSourceCreated(eventSource);
    }

    protected override void OnEventWritten(EventWrittenEventArgs eventData)
    {
        try
        {
            if (eventData.EventId == BeginExecuteEventId)
            {
                this.OnBeginExecute(eventData);
            }
            else if (eventData.EventId == EndExecuteEventId)
            {
                this.OnEndExecute(eventData);
            }
        }
        catch (Exception exc)
        {
            SqlClientInstrumentationEventSource.Log.UnknownErrorProcessingEvent(nameof(SqlEventSourceListener), nameof(this.OnEventWritten), exc);
        }
    }

    private static (bool HasError, string? ErrorNumber, string? ExceptionType) ExtractErrorFromEvent(EventWrittenEventArgs eventData)
    {
        var compositeState = (int)eventData.Payload[1];

        if ((compositeState & 0b001) != 0b001)
        {
            if ((compositeState & 0b010) == 0b010)
            {
                var errorNumber = $"{eventData.Payload[2]}";
                var exceptionType = eventData.EventSource.Name == MdsEventSourceName
                    ? "Microsoft.Data.SqlClient.SqlException"
                    : "System.Data.SqlClient.SqlException";
                return (true, errorNumber, exceptionType);
            }
            else
            {
                return (true, null, null);
            }
        }

        return (false, null, null);
    }

    private void OnBeginExecute(EventWrittenEventArgs eventData)
    {
        /*
           Expected payload:
            [0] -> ObjectId
            [1] -> DataSource
            [2] -> Database
            [3] -> CommandText

            Note:
            - For "Microsoft-AdoNet-SystemData" v1.0: [3] CommandText = CommandType == CommandType.StoredProcedure ? CommandText : string.Empty; (so it is set for only StoredProcedure command types)
                (https://github.com/dotnet/SqlClient/blob/v1.0.19239.1/src/Microsoft.Data.SqlClient/netfx/src/Microsoft/Data/SqlClient/SqlCommand.cs#L6369)
            - For "Microsoft-AdoNet-SystemData" v1.1: [3] CommandText = sqlCommand.CommandText (so it is set for all command types)
                (https://github.com/dotnet/SqlClient/blob/v1.1.0/src/Microsoft.Data.SqlClient/netfx/src/Microsoft/Data/SqlClient/SqlCommand.cs#L7459)
            - For "Microsoft.Data.SqlClient.EventSource" v2.0+: [3] CommandText = sqlCommand.CommandText (so it is set for all command types).
                (https://github.com/dotnet/SqlClient/blob/f4568ce68da21db3fe88c0e72e1287368aaa1dc8/src/Microsoft.Data.SqlClient/netcore/src/Microsoft/Data/SqlClient/SqlCommand.cs#L6641)
         */

        if (SqlClientInstrumentation.TracingHandles == 0 && SqlClientInstrumentation.MetricHandles == 0)
        {
            return;
        }

        var options = SqlClientInstrumentation.TracingOptions;

        if (eventData.Payload.Count < 4)
        {
            SqlClientInstrumentationEventSource.Log.InvalidPayload(nameof(SqlEventSourceListener), nameof(this.OnBeginExecute));
            return;
        }

        var dataSource = (string)eventData.Payload[1];
        var databaseName = (string)eventData.Payload[2];
        var startTags = SqlActivitySourceHelper.GetTagListFromConnectionInfo(dataSource, databaseName, options, out var activityName);
        var activity = SqlActivitySourceHelper.ActivitySource.StartActivity(
            activityName,
            ActivityKind.Client,
            default(ActivityContext),
            startTags);

        if (activity == null)
        {
            // There is no listener or it decided not to sample the current request.
            this.beginTimestamp.Value = Stopwatch.GetTimestamp();
            return;
        }

        if (activity.IsAllDataRequested)
        {
            var commandText = (string)eventData.Payload[3];
            if (!string.IsNullOrEmpty(commandText) && options.SetDbStatementForText)
            {
                if (options.EmitOldAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeDbStatement, commandText);
                }

                if (options.EmitNewAttributes)
                {
                    activity.SetTag(SemanticConventions.AttributeDbQueryText, commandText);
                }
            }
        }
    }

    private void OnEndExecute(EventWrittenEventArgs eventData)
    {
        /*
           Expected payload:
            [0] -> ObjectId
            [1] -> CompositeState bitmask (0b001 -> successFlag, 0b010 -> isSqlExceptionFlag , 0b100 -> synchronousFlag)
            [2] -> SqlExceptionNumber
         */

        if (SqlClientInstrumentation.TracingHandles == 0 && SqlClientInstrumentation.MetricHandles == 0)
        {
            return;
        }

        if (eventData.Payload.Count < 3)
        {
            SqlClientInstrumentationEventSource.Log.InvalidPayload(nameof(SqlEventSourceListener), nameof(this.OnEndExecute));
            return;
        }

        if (SqlClientInstrumentation.TracingHandles == 0 && SqlClientInstrumentation.MetricHandles != 0)
        {
            this.RecordDuration(null, eventData);
            return;
        }

        var activity = Activity.Current;
        if (activity?.Source != SqlActivitySourceHelper.ActivitySource)
        {
            return;
        }

        try
        {
            if (activity.IsAllDataRequested)
            {
                var (hasError, errorNumber, exceptionType) = ExtractErrorFromEvent(eventData);

                if (hasError)
                {
                    if (errorNumber != null && exceptionType != null)
                    {
                        activity.SetStatus(ActivityStatusCode.Error, errorNumber);
                        activity.SetTag(SemanticConventions.AttributeDbResponseStatusCode, errorNumber);
                        activity.SetTag(SemanticConventions.AttributeErrorType, exceptionType);
                    }
                    else
                    {
                        activity.SetStatus(ActivityStatusCode.Error, "Unknown Sql failure.");
                    }
                }
            }
        }
        finally
        {
            activity.Stop();
            this.RecordDuration(activity, eventData);
        }
    }

    private void RecordDuration(Activity? activity, EventWrittenEventArgs eventData)
    {
        if (SqlClientInstrumentation.MetricHandles == 0)
        {
            return;
        }

        var tags = default(TagList);

        if (activity != null && activity.IsAllDataRequested)
        {
            foreach (var name in SqlActivitySourceHelper.SharedTagNames)
            {
                var value = activity.GetTagItem(name);
                if (value != null)
                {
                    tags.Add(name, value);
                }
            }
        }
        else
        {
            tags.Add(SemanticConventions.AttributeDbSystem, SqlActivitySourceHelper.MicrosoftSqlServerDatabaseSystemName);

            var (hasError, errorNumber, exceptionType) = ExtractErrorFromEvent(eventData);

            if (hasError)
            {
                if (errorNumber != null && exceptionType != null)
                {
                    tags.Add(SemanticConventions.AttributeDbResponseStatusCode, errorNumber);
                    tags.Add(SemanticConventions.AttributeErrorType, exceptionType);
                }
            }
        }

        var duration = activity?.Duration.TotalSeconds
            ?? SqlActivitySourceHelper.CalculateDurationFromTimestamp(this.beginTimestamp.Value);
        SqlActivitySourceHelper.DbClientOperationDuration.Record(duration, tags);
    }
}
#endif
