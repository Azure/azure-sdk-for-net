// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#if !NETFRAMEWORK
using System.Data;
using System.Diagnostics;
#if NET
using System.Diagnostics.CodeAnalysis;
#endif
using System.Globalization;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Instrumentation.SqlClient.Implementation;

#if NET
[RequiresUnreferencedCode(SqlClientInstrumentation.SqlClientTrimmingUnsupportedMessage)]
#endif
internal sealed class SqlClientDiagnosticListener : ListenerHandler
{
    public const string SqlDataBeforeExecuteCommand = "System.Data.SqlClient.WriteCommandBefore";
    public const string SqlMicrosoftBeforeExecuteCommand = "Microsoft.Data.SqlClient.WriteCommandBefore";

    public const string SqlDataAfterExecuteCommand = "System.Data.SqlClient.WriteCommandAfter";
    public const string SqlMicrosoftAfterExecuteCommand = "Microsoft.Data.SqlClient.WriteCommandAfter";

    public const string SqlDataWriteCommandError = "System.Data.SqlClient.WriteCommandError";
    public const string SqlMicrosoftWriteCommandError = "Microsoft.Data.SqlClient.WriteCommandError";

    private readonly PropertyFetcher<object> commandFetcher = new("Command");
    private readonly PropertyFetcher<object> connectionFetcher = new("Connection");
    private readonly PropertyFetcher<string> dataSourceFetcher = new("DataSource");
    private readonly PropertyFetcher<string> databaseFetcher = new("Database");
    private readonly PropertyFetcher<CommandType> commandTypeFetcher = new("CommandType");
    private readonly PropertyFetcher<string> commandTextFetcher = new("CommandText");
    private readonly PropertyFetcher<Exception> exceptionFetcher = new("Exception");
    private readonly PropertyFetcher<int> exceptionNumberFetcher = new("Number");
    private readonly AsyncLocal<long> beginTimestamp = new();

    public SqlClientDiagnosticListener(string sourceName)
        : base(sourceName)
    {
    }

    public override bool SupportsNullActivity => true;

    public override void OnEventWritten(string name, object? payload)
    {
        if (SqlClientInstrumentation.TracingHandles == 0 && SqlClientInstrumentation.MetricHandles == 0)
        {
            return;
        }

        var options = SqlClientInstrumentation.TracingOptions;
        var activity = Activity.Current;
        switch (name)
        {
            case SqlDataBeforeExecuteCommand:
            case SqlMicrosoftBeforeExecuteCommand:
                {
                    _ = this.commandFetcher.TryFetch(payload, out var command);
                    if (command == null)
                    {
                        SqlClientInstrumentationEventSource.Log.NullPayload(nameof(SqlClientDiagnosticListener), name);
                        return;
                    }

                    _ = this.connectionFetcher.TryFetch(command, out var connection);
                    _ = this.databaseFetcher.TryFetch(connection, out var databaseName);
                    _ = this.dataSourceFetcher.TryFetch(connection, out var dataSource);

                    var startTags = SqlActivitySourceHelper.GetTagListFromConnectionInfo(dataSource, databaseName, options, out var activityName);
                    activity = SqlActivitySourceHelper.ActivitySource.StartActivity(
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
                        try
                        {
                            if (options.Filter?.Invoke(command) == false)
                            {
                                SqlClientInstrumentationEventSource.Log.CommandIsFilteredOut(activity.OperationName);
                                activity.IsAllDataRequested = false;
                                activity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            SqlClientInstrumentationEventSource.Log.CommandFilterException(ex);
                            activity.IsAllDataRequested = false;
                            activity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
                            return;
                        }

                        if (this.commandTypeFetcher.TryFetch(command, out var commandType) &&
                            this.commandTextFetcher.TryFetch(command, out var commandText))
                        {
                            switch (commandType)
                            {
                                case CommandType.StoredProcedure:
                                    if (options.EmitOldAttributes)
                                    {
                                        activity.SetTag(SemanticConventions.AttributeDbStatement, commandText);
                                    }

                                    if (options.EmitNewAttributes)
                                    {
                                        activity.SetTag(SemanticConventions.AttributeDbOperationName, "EXECUTE");
                                        activity.SetTag(SemanticConventions.AttributeDbCollectionName, commandText);
                                        activity.SetTag(SemanticConventions.AttributeDbQueryText, commandText);
                                    }

                                    break;

                                case CommandType.Text:
                                    if (options.SetDbStatementForText)
                                    {
                                        var sanitizedSql = SqlProcessor.GetSanitizedSql(commandText);
                                        if (options.EmitOldAttributes)
                                        {
                                            activity.SetTag(SemanticConventions.AttributeDbStatement, sanitizedSql);
                                        }

                                        if (options.EmitNewAttributes)
                                        {
                                            activity.SetTag(SemanticConventions.AttributeDbQueryText, sanitizedSql);
                                        }
                                    }

                                    break;

                                case CommandType.TableDirect:
                                    break;
                                default:
                                    break;
                            }
                        }

                        try
                        {
                            options.Enrich?.Invoke(activity, "OnCustom", command);
                        }
                        catch (Exception ex)
                        {
                            SqlClientInstrumentationEventSource.Log.EnrichmentException(ex);
                        }
                    }
                }

                break;
            case SqlDataAfterExecuteCommand:
            case SqlMicrosoftAfterExecuteCommand:
                {
                    if (activity == null)
                    {
                        SqlClientInstrumentationEventSource.Log.NullActivity(name);
                        this.RecordDuration(null, payload);
                        return;
                    }

                    if (activity.Source != SqlActivitySourceHelper.ActivitySource)
                    {
                        this.RecordDuration(null, payload);
                        return;
                    }

                    activity.Stop();
                    this.RecordDuration(activity, payload);
                }

                break;
            case SqlDataWriteCommandError:
            case SqlMicrosoftWriteCommandError:
                {
                    if (activity == null)
                    {
                        SqlClientInstrumentationEventSource.Log.NullActivity(name);
                        this.RecordDuration(null, payload);
                        return;
                    }

                    if (activity.Source != SqlActivitySourceHelper.ActivitySource)
                    {
                        this.RecordDuration(null, payload);
                        return;
                    }

                    try
                    {
                        if (activity.IsAllDataRequested)
                        {
                            if (this.exceptionFetcher.TryFetch(payload, out var exception) && exception != null)
                            {
                                activity.AddTag(SemanticConventions.AttributeErrorType, exception.GetType().FullName);

                                if (this.exceptionNumberFetcher.TryFetch(exception, out var exceptionNumber))
                                {
                                    activity.AddTag(SemanticConventions.AttributeDbResponseStatusCode, exceptionNumber.ToString(CultureInfo.InvariantCulture));
                                }

                                activity.SetStatus(ActivityStatusCode.Error, exception.Message);

                                if (options.RecordException)
                                {
                                    activity.AddException(exception);
                                }
                            }
                            else
                            {
                                SqlClientInstrumentationEventSource.Log.NullPayload(nameof(SqlClientDiagnosticListener), name);
                            }
                        }
                    }
                    finally
                    {
                        activity.Stop();
                        this.RecordDuration(activity, payload, hasError: true);
                    }
                }

                break;
            default:
                break;
        }
    }

    private void RecordDuration(Activity? activity, object? payload, bool hasError = false)
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
        else if (payload != null)
        {
            if (this.commandFetcher.TryFetch(payload, out var command) && command != null &&
                this.connectionFetcher.TryFetch(command, out var connection))
            {
                this.databaseFetcher.TryFetch(connection, out var databaseName);
                this.dataSourceFetcher.TryFetch(connection, out var dataSource);

                var connectionTags = SqlActivitySourceHelper.GetTagListFromConnectionInfo(
                    dataSource,
                    databaseName,
                    SqlClientInstrumentation.TracingOptions,
                    out _);

                foreach (var tag in connectionTags)
                {
                    tags.Add(tag.Key, tag.Value);
                }

                if (this.commandTypeFetcher.TryFetch(command, out var commandType) &&
                    commandType == CommandType.StoredProcedure)
                {
                    if (this.commandTextFetcher.TryFetch(command, out var commandText))
                    {
                        tags.Add(SemanticConventions.AttributeDbOperationName, "EXECUTE");
                        tags.Add(SemanticConventions.AttributeDbCollectionName, commandText);
                    }
                }
            }

            if (hasError)
            {
                if (this.exceptionFetcher.TryFetch(payload, out var exception) && exception != null)
                {
                    tags.Add(SemanticConventions.AttributeErrorType, exception.GetType().FullName);

                    if (this.exceptionNumberFetcher.TryFetch(exception, out var exceptionNumber))
                    {
                        tags.Add(SemanticConventions.AttributeDbResponseStatusCode, exceptionNumber.ToString(CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        var duration = activity?.Duration.TotalSeconds
            ?? SqlActivitySourceHelper.CalculateDurationFromTimestamp(this.beginTimestamp.Value);
        SqlActivitySourceHelper.DbClientOperationDuration.Record(duration, tags);
    }
}
#endif
