// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.Projects;

public partial class WeeklyRecurrenceSchedule : RecurrenceSchedule
{
    /// <param name="writer"> The JSON writer. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        string format = options.Format == "W" ? ((IPersistableModel<WeeklyRecurrenceSchedule>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(WeeklyRecurrenceSchedule)} does not support writing '{format}' format.");
        }
        base.JsonModelWriteCore(writer, options);
        writer.WritePropertyName("daysOfWeek"u8);
        writer.WriteStartArray();
        foreach (System.DayOfWeek item in DaysOfWeek)
        {
            writer.WriteNumberValue((int)item);
        }
        writer.WriteEndArray();
    }

    /// <param name="element"> The JSON element to deserialize. </param>
    /// <param name="options"> The client options for reading and writing models. </param>
    internal static WeeklyRecurrenceSchedule DeserializeWeeklyRecurrenceSchedule(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        RecurrenceType @type = default;
        IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        IList<System.DayOfWeek> daysOfWeek = default;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("type"u8))
            {
                @type = new RecurrenceType(prop.Value.GetString());
                continue;
            }
            if (prop.NameEquals("daysOfWeek"u8))
            {
                List<System.DayOfWeek> array = new List<System.DayOfWeek>();
                foreach (var item in prop.Value.EnumerateArray())
                {
                    array.Add((System.DayOfWeek)item.GetInt32());
                }
                daysOfWeek = array;
                continue;
            }
            if (options.Format != "W")
            {
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
        }
        return new WeeklyRecurrenceSchedule(@type, additionalBinaryDataProperties, daysOfWeek);
    }
}
