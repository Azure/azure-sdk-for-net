// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Serialization
{
    public sealed class SearchDateTimeConverterTests
    {
        [Test]
        public void SearchDateTimeConverterT()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ja-JP");
            var data = Encoding.UTF8.GetBytes(DateTime.MaxValue.ToString("o"));

            ReadOnlySpan<byte> jsonReadOnlySpan = new(data);
            Utf8JsonReader reader = new(jsonReadOnlySpan);
            reader.Read();

            DateTime dateTimeValue = SearchDateTimeConverter.Shared.Read(ref reader, typeof(DateTime), null);
            Assert.AreEqual(DateTime.MaxValue, dateTimeValue);
        }

        [Test]
        public void T()
        {
            using MemoryStream stream = new();
            using Utf8JsonWriter jsonWriter = new(stream);

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
            //CultureInfo.CurrentCulture = new CultureInfo("ja-JP");
            //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ja-JP");

            DateTime dateTime = new(DateTime.MaxValue.Ticks, DateTimeKind.Utc);

            SearchDateTimeConverter.Shared.Write(jsonWriter, dateTime, new JsonSerializerOptions());
            jsonWriter.Flush();

            ReadOnlySpan<byte> jsonReadOnlySpan = new(stream.ToArray());

            Utf8JsonReader jsonReader = new(jsonReadOnlySpan);
            jsonReader.Read();

            DateTime dateTimeValue = SearchDateTimeConverter.Shared.Read(ref jsonReader, typeof(DateTime), new JsonSerializerOptions());
            Assert.AreEqual(DateTime.MaxValue, dateTimeValue);
        }

        [Test]
        public void T2()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");

            using MemoryStream stream = new();
            using Utf8JsonWriter jsonWriter = new(stream);

            DateTimeOffset dateTime = new(DateTime.MaxValue.AddHours(-10));

            SearchDateTimeOffsetConverter.Shared.Write(jsonWriter, dateTime, new JsonSerializerOptions());
            jsonWriter.Flush();

            ReadOnlySpan<byte> jsonReadOnlySpan = new(stream.ToArray());

            Utf8JsonReader jsonReader = new(jsonReadOnlySpan);
            jsonReader.Read();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");

            DateTimeOffset dateTimeOffsetValue = SearchDateTimeOffsetConverter.Shared.Read(ref jsonReader, typeof(DateTimeOffset), new JsonSerializerOptions());
            Assert.AreEqual(DateTimeOffset.MaxValue, dateTimeOffsetValue);
        }
    }
}
