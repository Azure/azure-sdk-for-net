// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal class NDJsonWriter: IDisposable
    {
        private static readonly byte[] Separator = { (byte)'\n'};

        public NDJsonWriter()
        {
            Stream = new MemoryStream();
            JsonWriter = new Utf8JsonWriter(Stream, new JsonWriterOptions(){ SkipValidation = true });
        }

        private MemoryStream Stream { get; }
        public Utf8JsonWriter JsonWriter { get; }

        public void WriteNewLine()
        {
            JsonWriter.Flush();
            JsonWriter.Reset();
            Stream.Write(Separator, 0, 1);
        }

        public Memory<byte> ToBytes()
        {
            JsonWriter.Flush();
            return Stream.ToArray();
        }

        public override string ToString()
        {
            Stream.Position = 0;
            using var streamReader = new StreamReader(Stream);
            return streamReader.ReadToEnd();
        }

        public void Dispose()
        {
            Stream?.Dispose();
            JsonWriter?.Dispose();
        }
    }
}