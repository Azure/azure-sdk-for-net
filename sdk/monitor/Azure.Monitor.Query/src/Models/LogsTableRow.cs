// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary>
    /// Represents a row in the table of results returned from the logs query.
    /// </summary>
    [CodeGenModel("LogsQueryResultRow")]
    public class LogsTableRow: IReadOnlyList<object>
    {
        private readonly Dictionary<string, int> _columnMap;
        private readonly IReadOnlyList<LogsTableColumn> _columns;
        internal JsonElement _row;

        internal LogsTableRow(Dictionary<string, int> columnMap, IReadOnlyList<LogsTableColumn> columns, JsonElement row)
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
        /// <returns>The <see cref="Nullable{Int32}"/> value of the column.</returns>
        public int? GetInt32(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : _row[index].GetInt32();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="long"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Nullable{Int64}"/> value of the column.</returns>
        public long? GetInt64(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : _row[index].GetInt64();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="bool"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Nullable{Boolean}"/> value of the column.</returns>
        public bool? GetBoolean(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : _row[index].GetBoolean();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="decimal"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Nullable{Decimal}"/> value of the column.</returns>
        /// <exception cref="FormatException">column value is not in the correct format.</exception>
        /// <exception cref="OverflowException">column value represents a number less than <see cref="decimal.MinValue"/> or greater than <see cref="decimal.MaxValue"/>, or is NaN or Infinity or -Infinity.</exception>
        /// <exception cref="InvalidOperationException">Unsupported <see cref="JsonValueKind"/>.</exception>
        public decimal? GetDecimal(int index) => _row[index].ValueKind switch
                                                    {
                                                        JsonValueKind.Null => null,
                                                        JsonValueKind.Undefined => null,
                                                        JsonValueKind.True => 1m,
                                                        JsonValueKind.False => 0m,
                                                        JsonValueKind.Number => _row[index].GetDecimal(),
                                                        JsonValueKind.String => _row[index].GetString() switch
                                                                                {
                                                                                    "NaN" or "Infinity" or "-Infinity"
                                                                                        => throw new OverflowException($"{_columns[index]} value was either too large or too small for a Decimal."),

                                                                                    string value
                                                                                        => decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal result)
                                                                                            ? result
                                                                                            : throw new FormatException($"The input string '{value}' for {_columns[index]} was not in a correct format so couln't be parsed as Decimal."),

                                                                                    _ => null
                                                                                },
                                                        _ => throw new InvalidOperationException($"Cannot convert {_columns[index]} value kind {_row[index].ValueKind}")
                                                    };

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="double"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Nullable{Double}"/> value of the column.</returns>
        public double? GetDouble(int index)
        {
            if (_row[index].ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            else
            {
                if (_row[index].ValueKind == JsonValueKind.String)
                {
                    string result = _row[index].GetString();
                    switch (result) {
                        case "NaN":
                            return Double.NaN;
                        case "Infinity":
                            return Double.PositiveInfinity;
                        case "-Infinity":
                            return Double.NegativeInfinity;
                    }
                }
                return _row[index].GetDouble();
            }
        }

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="string"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="string"/> value of the column.</returns>
        public string GetString(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : _row[index].GetString();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Nullable{DateTimeOffset}"/> value of the column.</returns>
        public DateTimeOffset? GetDateTimeOffset(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : _row[index].GetDateTimeOffset();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Nullable{TimeSpan}"/> value of the column.</returns>
        public TimeSpan? GetTimeSpan(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : _row[index].GetTimeSpan("c");

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="Guid"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="Nullable{Guid}"/> value of the column.</returns>
        public Guid? GetGuid(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : _row[index].GetGuid();

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="BinaryData"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="BinaryData"/> value of the column.</returns>
        public BinaryData GetDynamic(int index) => _row[index].ValueKind == JsonValueKind.Null ? null : new BinaryData(_row[index].GetString());

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="int"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Nullable{Int32}"/> value of the column.</returns>
        public int? GetInt32(string name) => GetInt32(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="long"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Nullable{Int64}"/> value of the column.</returns>
        public long? GetInt64(string name) => GetInt64(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="bool"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Nullable{Boolean}"/> value of the column.</returns>
        public bool? GetBoolean(string name) => GetBoolean(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="decimal"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Nullable{Decimal}"/> value of the column.</returns>
        public decimal? GetDecimal(string name) => GetDecimal(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="double"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Nullable{Double}"/> value of the column.</returns>
        public double? GetDouble(string name) => GetDouble(_columnMap[name]);

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
        /// <returns>The <see cref="Nullable{DateTimeOffset}"/> value of the column.</returns>
        public DateTimeOffset? GetDateTimeOffset(string name) => GetDateTimeOffset(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Nullable{TimeSpan}"/> value of the column.</returns>
        public TimeSpan? GetTimeSpan(string name) => GetTimeSpan(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="Guid"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="Nullable{Guid}"/> value of the column.</returns>
        public Guid? GetGuid(string name) => GetGuid(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column with the specified name as <see cref="Guid"/>.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <returns>The <see cref="BinaryData"/> value of the column.</returns>
        public BinaryData GetDynamic(string name) => GetDynamic(_columnMap[name]);

        /// <summary>
        /// Gets the value of the column at the specified index as <see cref="object"/>.
        /// </summary>
        /// <param name="index">The column index.</param>
        /// <returns>The <see cref="object"/> value of the column.</returns>
        internal object GetObject(int index)
        {
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
        internal object GetObject(string name) => GetObject(_columnMap[name]);

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

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<object>)this).GetEnumerator();
        }

        /// <inheritdoc />
        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return GetObject(i);
            }
        }
    }
}
