// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ClientModel.Tests;

public class TestLogger : ILogger
{
    private LogLevel _logLevel;
    private string _name;

    public TestLogger(string name, LogLevel logLevel)
    {
        _logLevel = logLevel;
        _name = name;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= _logLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (IsEnabled(logLevel))
        {
            int eventNum = eventId.Id;
            IReadOnlyList<KeyValuePair<string, string?>> arguments = GetProperties(state);

            string requestId = GetValue(arguments, "requestId");

            switch (eventNum)
            {
                case 1:
                    TestLoggingEventSource.Log.Request(requestId, GetValue(arguments, "method"), GetValue(arguments, "uri"), GetValue(arguments, "headers"), GetValue(arguments, "assemblyName"));
                    break;
                case 2:
                    TestLoggingEventSource.Log.RequestContent(requestId, Encoding.UTF8.GetBytes(GetValue(arguments, "content")));
                    break;
                case 5:
                    TestLoggingEventSource.Log.Response(requestId, int.Parse(GetValue(arguments, "status")), GetValue(arguments, "reasonPhrase"), GetValue(arguments, "headers"), double.Parse(GetValue(arguments, "seconds")));
                    break;
                case 6:
                    TestLoggingEventSource.Log.ResponseContent(requestId, Encoding.UTF8.GetBytes(GetValue(arguments, "content")));
                    break;
                case 7:
                    TestLoggingEventSource.Log.ResponseDelay(requestId, double.Parse(GetValue(arguments, "seconds")));
                    break;
                case 8:
                    TestLoggingEventSource.Log.ErrorResponse(requestId, int.Parse(GetValue(arguments, "status")), GetValue(arguments, "reasonPhrase"), GetValue(arguments, "headers"), double.Parse(GetValue(arguments, "seconds")));
                    break;
                case 9:
                    TestLoggingEventSource.Log.ErrorResponseContent(requestId, Encoding.UTF8.GetBytes(GetValue(arguments, "content")));
                    break;
                case 10:
                    TestLoggingEventSource.Log.RequestRetrying(requestId, int.Parse(GetValue(arguments, "retryCount")), double.Parse(GetValue(arguments, "delaySeconds")));
                    break;
                case 11:
                    TestLoggingEventSource.Log.ResponseContentBlock(requestId, int.Parse(GetValue(arguments, "blockNumber")), Encoding.UTF8.GetBytes(GetValue(arguments, "content")));
                    break;
                case 12:
                    TestLoggingEventSource.Log.ErrorResponseContentBlock(requestId, int.Parse(GetValue(arguments, "blockNumber")), Encoding.UTF8.GetBytes(GetValue(arguments, "content")));
                    break;
                case 13:
                    TestLoggingEventSource.Log.ResponseContentText(requestId, GetValue(arguments, "content"));
                    break;
                case 14:
                    TestLoggingEventSource.Log.ErrorResponseContentText(requestId, GetValue(arguments, "content"));
                    break;
                case 15:
                    TestLoggingEventSource.Log.ResponseContentTextBlock(requestId, int.Parse(GetValue(arguments, "blockNumber")), GetValue(arguments, "content"));
                    break;
                case 16:
                    TestLoggingEventSource.Log.ErrorResponseContentTextBlock(requestId, int.Parse(GetValue(arguments, "blockNumber")), GetValue(arguments, "content"));
                    break;
                case 17:
                    TestLoggingEventSource.Log.RequestContentText(requestId, GetValue(arguments, "content"));
                    break;
                case 18:
                    TestLoggingEventSource.Log.ExceptionResponse(requestId, GetValue(arguments, "exception"));
                    break;
            }
        }
    }

    private static string GetValue(IReadOnlyList<KeyValuePair<string, string?>> arguments, string key)
        => arguments.Single(kvp => kvp.Key == key).Value ?? string.Empty;

    private static KeyValuePair<string, string?>[] GetProperties(object? state)
    {
        if (state is IReadOnlyList<KeyValuePair<string, object?>> keyValuePairs)
        {
            var arguments = new KeyValuePair<string, string?>[keyValuePairs.Count];
            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                KeyValuePair<string, object?> keyValuePair = keyValuePairs[i];
                arguments[i] = new KeyValuePair<string, string?>(keyValuePair.Key, keyValuePair.Value?.ToString());
            }
            return arguments;
        }

        return Array.Empty<KeyValuePair<string, string?>>();
    }
}
