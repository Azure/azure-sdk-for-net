// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Monitory.Query.Models
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
        public decimal GetDecimal(int index) => _row[index].GetDecimal();
        public float GetSingle(int index) => _row[index].GetSingle();
        public string GetString(int index) => _row[index].GetString();

        public int GetInt32(string name) => GetInt32(_columns[name]);
        public long GetInt64(string name) => GetInt64(_columns[name]);
        public bool GetBoolean(string name) => GetBoolean(_columns[name]);
        public decimal GetDecimal(string name) => GetDecimal(_columns[name]);
        public float GetSingle(string name) => GetSingle(_columns[name]);
        public string GetString(string name) => GetString(_columns[name]);

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
    }
}