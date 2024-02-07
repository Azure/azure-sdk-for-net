namespace Microsoft.ApplicationInsights.Tests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility;

    internal class TelemetryMock : ITelemetry
    {
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

        public string StringField { get; set; }

        public TimeSpan TimeSpanField { get; set; }

        public Uri UriField { get; set; }

        public EnumType EnumField { get; set; }

        public EnumType? NullableEnumField { get; set; }

        public IDictionary<string, string> Properties { get; } = new Dictionary<string, string>();

        public IDictionary<string, double> Metrics { get; } = new Dictionary<string, double>();

        public DateTimeOffset Timestamp { get; set; }

        public TelemetryContext Context { get; set; } = new TelemetryContext();

        public TelemetryContextMock ContextMock { get; set; } = new TelemetryContextMock();

        public string Sequence { get; set; }

        public IExtension Extension { get; set; }

        public void Sanitize()
        {
            throw new NotImplementedException();
        }

        public ITelemetry DeepClone()
        {
            return this;
        }

        public void SerializeData(ISerializationWriter serializationWriter)
        {
        }

        public class TelemetryContextMock
        {
            public OperationContextMock Operation { get; set; }

            public class OperationContextMock
            {
                public string Name { get; set; }
            }
        }
    }
}
