// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    [CodeGenSuppress("Write", typeof(Utf8JsonWriter))]
    public partial class RecurrentSchedule : IUtf8JsonSerializable
    {
        

        internal static RecurrentSchedule DeserializeRecurrentSchedule(JsonElement element)
        {
            string timeZone = default;
            IList<int> days = default;
            IList<int> hours = default;
            IList<int> minutes = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("timeZone"))
                {
                    timeZone = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("days"))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (!int.TryParse(item.GetString(), out int day))
                        {
                            throw new FormatException("The format of RecurrentSchedule.days value should be integer");
                        }

                        array.Add(day);
                    }
                    days = array;
                    continue;
                }
                if (property.NameEquals("hours"))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    hours = array;
                    continue;
                }
                if (property.NameEquals("minutes"))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    minutes = array;
                    continue;
                }
            }
            return new RecurrentSchedule(timeZone, days, hours, minutes);
        }
    }
}
