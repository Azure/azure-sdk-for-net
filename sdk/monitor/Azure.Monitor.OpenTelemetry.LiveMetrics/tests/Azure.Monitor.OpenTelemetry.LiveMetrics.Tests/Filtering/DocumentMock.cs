// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering.Tests
{
    using System;
    using System.Collections.Generic;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

    internal class DocumentMock : DocumentIngress
    {
        internal DocumentMock() { }

        internal DocumentMock(IList<KeyValuePairString> properties) : base(DocumentIngressDocumentType.Request, new List<string>(), properties)
        {
        }

        public enum EnumType
        {
            Value1 = 0,
            Value2,
            Value3
        }

        public bool BooleanField { get; set; }

        public bool? NullableBooleanField { get; set; }

        public int IntField { get; set; }

        public int? NullableIntField { get; set; }

        public double DoubleField { get; set; }

        public double? NullableDoubleField { get; set; }

        public string? StringField { get; set; }

        public TimeSpan TimeSpanField { get; set; }

        public Uri? UriField { get; set; }

        public EnumType EnumField { get; set; }

        public EnumType? NullableEnumField { get; set; }

        public IDictionary<string, double> Metrics { get; } = new Dictionary<string, double>();

        public string? Name { get; set; }

        public string? Id { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
