// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary>
    /// Represents a row in the table of results returned from the logs query.
    /// </summary>
    public class LogsQueryResultRow
    {
        private readonly Dictionary<string, int> _columnMap;
        private readonly IReadOnlyList<LogsQueryResultColumn> _columns;
        private readonly JsonElement _row;

        internal LogsQueryResultRow(Dictionary<string, int> columnMap, IReadOnlyList<LogsQueryResultColumn> columns, JsonElement row)
        {
            _columnMap = columnMap;
            _columns = columns;
            _row = row;
        }

        /// <summary>
        /// Returns the cell count.
        /// </summary>
        public int Count => _row.GetArrayLength();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="int"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="int"/> value of the column.</returns>
        public int GetInt32(int index) => _row[index].GetInt32();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="long"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="long"/> value of the column.</returns>
        public long GetInt64(int index) => _row[index].GetInt64();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="bool"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="bool"/> value of the column.</returns>
        public bool GetBoolean(int index) => _row[index].GetBoolean();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="decimal"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="decimal"/> value of the column.</returns>
        public decimal GetDecimal(int index) => decimal.Parse(_row[index].GetString(), CultureInfo.InvariantCulture);

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="double"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="double"/> value of the column.</returns>
        public double GetDouble(int index) => _row[index].GetDouble();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="string"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="string"/> value of the column.</returns>
        public string GetString(int index) => _row[index].GetString();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="DateTimeOffset"/> value of the column.</returns>
        public DateTimeOffset GetDateTimeOffset(int index) => _row[index].GetDateTimeOffset();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="TimeSpan"/> value of the column.</returns>
        public TimeSpan GetTimeSpan(int index) => _row[index].GetTimeSpan("c");

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="Guid"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Guid"/> value of the column.</returns>
        public Guid GetGuid(int index) => _row[index].GetGuid();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="BinaryData"/> value of the column.</returns>
        public BinaryData GetDynamic(int index) => new BinaryData(_row[index].GetString());

        /// <summary>
        /// Returns <c>true</c> if the value of the column at the specified index is <c>null</c>, otherwise <c>false</c>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns><c>true</c> if the value is <c>null</c>, otherwise <c>false</c>.</returns>
        public bool IsNull(int index) => _row[index].ValueKind == JsonValueKind.Null;

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="int"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="int"/> value of the column.</returns>
        public int GetInt32(string name) => GetInt32(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="long"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="long"/> value of the column.</returns>
        public long GetInt64(string name) => GetInt64(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="bool"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="bool"/> value of the column.</returns>
        public bool GetBoolean(string name) => GetBoolean(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="decimal"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="decimal"/> value of the column.</returns>
        public decimal GetDecimal(string name) => GetDecimal(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="double"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="double"/> value of the column.</returns>
        public double GetDouble(string name) => GetDouble(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="string"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="string"/> value of the column.</returns>
        public string GetString(string name) => GetString(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="DateTimeOffset"/> value of the column.</returns>
        public DateTimeOffset GetDateTimeOffset(string name) => GetDateTimeOffset(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="TimeSpan"/> value of the column.</returns>
        public TimeSpan GetTimeSpan(string name) => GetTimeSpan(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="Guid"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Guid"/> value of the column.</returns>
        public Guid GetGuid(string name) => GetGuid(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="Guid"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="BinaryData"/> value of the column.</returns>
        public BinaryData GetDynamic(string name) => GetDynamic(_columnMap[name]);

        /// <summary>
        /// Returns true if the value of the column with the specified name is null, otherwise false.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns><c>true</c> if the value is <c>null</c>, otherwise <c>false</c>.</returns>
        public bool IsNull(string name) => IsNull(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="object"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="object"/> value of the column.</returns>
        public object GetObject(int index)
        {
            if (IsNull(index))
            {
                return null;
            }

            var element = _row[index];
            switch (_columns[index].Type.ToString())
            {
                case LogsColumnType.DatetimeTypeValue:
                    return GetDateTimeOffset(index);
                case LogsColumnType.BoolTypeValue:
                    return GetBoolean(index);
                case LogsColumnType.GuidTypeValue:
                    return GetGuid(index);
                case LogsColumnType.IntTypeValue:
                    return GetInt32(index);
                case LogsColumnType.LongTypeValue:
                    return GetInt64(index);
                case LogsColumnType.RealTypeValue:
                    return GetDouble(index);
                case LogsColumnType.StringTypeValue:
                    return GetString(index);
                case LogsColumnType.TimespanTypeValue:
                    return GetTimeSpan(index);
                case LogsColumnType.DecimalTypeValue:
                    return GetDecimal(index);
                case LogsColumnType.DynamicValueTypeValue:
                    return GetDynamic(index);
            }

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

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="object"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="object"/> value of the column.</returns>
        public object GetObject(string name) => GetObject(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="object"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="object"/> value of the column.</returns>
        public object this[int index] => GetObject(index);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="object"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="object"/> value of the column.</returns>
        public object this[string name] => GetObject(name);

        internal bool TryGetColumn(string name, out int column) => _columnMap.TryGetValue(name, out column);

        /// <inheritdoc/>
        public override string ToString()
        {
            return _row.ToString();
        }
    }
}
