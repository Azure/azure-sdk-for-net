// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    public class LogsQueryResultRow
    {
        private readonly Dictionary<string, int> _columns;
        private readonly JsonElement _row;

        internal LogsQueryResultRow(Dictionary<string, int> columns, JsonElement row)
        {
            _columns = columns;
            _row = row;
        }

        public int Count => _row.GetArrayLength();

        public int GetInt32(int index) => _row[index].GetInt32();
        public long GetInt64(int index) => _row[index].GetInt64();
        public bool GetBoolean(int index) => _row[index].GetBoolean();
        public decimal GetDecimal(int index) => decimal.Parse(_row[index].GetString(), CultureInfo.InvariantCulture);
        public double GetDouble(int index) => _row[index].GetDouble();
        public string GetString(int index) => _row[index].GetString();
        public DateTimeOffset GetDateTimeOffset(int index) => _row[index].GetDateTimeOffset();
        public TimeSpan GetTimeSpan(int index) => _row[index].GetTimeSpan("c");
        public Guid GetGuid(int index) => _row[index].GetGuid();

        public bool IsNull(int index) => _row[index].ValueKind == JsonValueKind.Null;

        public int GetInt32(string name) => GetInt32(_columns[name]);
        public long GetInt64(string name) => GetInt64(_columns[name]);
        public bool GetBoolean(string name) => GetBoolean(_columns[name]);
        public decimal GetDecimal(string name) => GetDecimal(_columns[name]);
        public double GetDouble(string name) => GetDouble(_columns[name]);
        public string GetString(string name) => GetString(_columns[name]);
        public DateTimeOffset GetDateTimeOffset(string name) => GetDateTimeOffset(_columns[name]);
        public TimeSpan GetTimeSpan(string name) => GetTimeSpan(_columns[name]);
        public Guid GetGuid(string name) => GetGuid(_columns[name]);
        public bool IsNull(string name) => IsNull(_columns[name]);

        public object GetObject(int index)
        {
            var element = _row[index];
            switch (element.ValueKind)
            {
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out int intValue))
                    {
                        return intValue;
                    }

                    if (element.TryGetInt64(out long longValue))
                    {
                        return longValue;
                    }

                    return element.GetDouble();
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                default:
                    throw new NotSupportedException($"Unsupported value kind {element.ValueKind}");
            }
        }

        public object GetObject(string name) => GetObject(_columns[name]);

        public object this[int index] => GetObject(index);
        public object this[string name] => GetObject(name);

        internal bool TryGetColumn(string name, out int column) => _columns.TryGetValue(name, out column);
    }
}