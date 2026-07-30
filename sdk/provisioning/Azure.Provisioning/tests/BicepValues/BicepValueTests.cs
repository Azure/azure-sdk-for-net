// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.BicepValues;

public class BicepValueTests
{
    [Test]
    public void ValidateLiteralBicepValue()
    {
        // string value
        TestHelpers.AssertExpression("'test'", new BicepValue<string>("test"));

        // int value
        TestHelpers.AssertExpression("42", new BicepValue<int>(42));
        TestHelpers.AssertExpression("-42", new BicepValue<int>(-42));

        // long value
        TestHelpers.AssertExpression("42", new BicepValue<long>(42L));
        TestHelpers.AssertExpression("2147483647", new BicepValue<long>(2147483647L));
        TestHelpers.AssertExpression("json('2147483648')", new BicepValue<long>(2147483648));
        TestHelpers.AssertExpression("-2147483648", new BicepValue<long>(-2147483648L));
        TestHelpers.AssertExpression("json('-2147483649')", new BicepValue<long>(-2147483649));
        TestHelpers.AssertExpression("json('9223372036854775807')", new BicepValue<long>(9223372036854775807));

        // bool value
        TestHelpers.AssertExpression("true", new BicepValue<bool>(true));
        TestHelpers.AssertExpression("false", new BicepValue<bool>(false));

        // double value
        TestHelpers.AssertExpression("json('3.14')", new BicepValue<double>(3.14));
        TestHelpers.AssertExpression("json('-3.14')", new BicepValue<double>(-3.14));
        // double value with whole numbers
        TestHelpers.AssertExpression("314", new BicepValue<double>(314d));
        TestHelpers.AssertExpression("2147483647", new BicepValue<double>(2147483647d));
        TestHelpers.AssertExpression("json('2147483648')", new BicepValue<double>(2147483648d));
        TestHelpers.AssertExpression("-2147483647", new BicepValue<double>(-2147483647d));
        TestHelpers.AssertExpression("-2147483648", new BicepValue<double>(-2147483648d));
        TestHelpers.AssertExpression("json('-2147483649')", new BicepValue<double>(-2147483649d));
    }

    [Test]
    public void ValidateFloatingPointUsesInvariantCulture()
    {
        CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
        try
        {
            // Use Danish culture where decimal separator is comma (e.g. "0,5" instead of "0.5")
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");

            // BicepValue<double> should produce dot-separated decimals regardless of locale
            TestHelpers.AssertExpression("json('0.5')", new BicepValue<double>(0.5));
            TestHelpers.AssertExpression("json('3.14')", new BicepValue<double>(3.14));
            TestHelpers.AssertExpression("json('-1.23')", new BicepValue<double>(-1.23));

            // BicepValue<float> should also produce dot-separated decimals
            TestHelpers.AssertExpression("json('0.5')", new BicepValue<float>(0.5f));
            TestHelpers.AssertExpression("json('0.25')", new BicepValue<float>(0.25f));
            TestHelpers.AssertExpression("json('-0.125')", new BicepValue<float>(-0.125f));

            // Very small fractional values
            TestHelpers.AssertExpression("json('0.001')", new BicepValue<double>(0.001));

            // Large values with fractional parts
            TestHelpers.AssertExpression("json('123456.789')", new BicepValue<double>(123456.789));

            // Values that are whole numbers should still render as int, even under non-invariant culture
            TestHelpers.AssertExpression("0", new BicepValue<double>(0.0));
            TestHelpers.AssertExpression("1", new BicepValue<double>(1.0));
            TestHelpers.AssertExpression("-1", new BicepValue<double>(-1.0));
            TestHelpers.AssertExpression("0", new BicepValue<float>(0.0f));
        }
        finally
        {
            Thread.CurrentThread.CurrentCulture = originalCulture;
        }
    }

    [Test]
    public void ValidateFloatingPointEdgeCases()
    {
        // Zero
        TestHelpers.AssertExpression("0", new BicepValue<double>(0.0));
        TestHelpers.AssertExpression("0", new BicepValue<float>(0.0f));

        // Negative zero should still be 0
        TestHelpers.AssertExpression("0", new BicepValue<double>(-0.0));
        TestHelpers.AssertExpression("0", new BicepValue<float>(-0.0f));

        // Very small decimals (the original bug scenario: minCapacity = 0.5)
        TestHelpers.AssertExpression("json('0.5')", new BicepValue<double>(0.5));
        TestHelpers.AssertExpression("json('0.25')", new BicepValue<double>(0.25));

        // Boundary: double whole number at int max/min
        TestHelpers.AssertExpression("2147483647", new BicepValue<double>((double)int.MaxValue));
        TestHelpers.AssertExpression("-2147483648", new BicepValue<double>((double)int.MinValue));

        // Just beyond int range with fractional part
        TestHelpers.AssertExpression("json('2147483647.5')", new BicepValue<double>(2147483647.5));
        TestHelpers.AssertExpression("json('-2147483648.5')", new BicepValue<double>(-2147483648.5));

        // float value
        TestHelpers.AssertExpression("json('0.5')", new BicepValue<float>(0.5f));
        TestHelpers.AssertExpression("json('-0.25')", new BicepValue<float>(-0.25f));
        // float value with whole numbers
        TestHelpers.AssertExpression("314", new BicepValue<float>(314f));
        TestHelpers.AssertExpression("0", new BicepValue<float>(0f));
    }

    [Test]
    public async Task ValidateTimeSpanPropertyWithFormat()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var powershell = new AzurePowerShellScript("script", "2023-08-01")
                {
                    RetentionInterval = new TimeSpan(11, 22, 33),
                    AzPowerShellVersion = "10.0",
                    ScriptContent = "echo 'Hello, world!'",
                };
                infra.Add(powershell);
                return infra;
            })
            .Compare(
                """
                @description('The location for the resource(s) to be deployed.')
                param location string = resourceGroup().location

                resource script 'Microsoft.Resources/deploymentScripts@2023-08-01' = {
                  name: take('script${uniqueString(resourceGroup().id)}', 24)
                  location: location
                  kind: 'AzurePowerShell'
                  properties: {
                    azPowerShellVersion: '10.0'
                    retentionInterval: 'PT11H22M33S'
                    scriptContent: 'echo \'Hello, world!\''
                  }
                }
                """);
    }

    [Test]
    public async Task ValidateDateTimeListProperty()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var resource = new DateTimeCollectionResource("dateTimeCollection")
                {
                    Name = "date-time-collection",
                    DateTimes =
                    [
                        new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero),
                        new DateTimeOffset(2026, 7, 30, 10, 45, 0, TimeSpan.Zero)
                    ]
                };
                infra.Add(resource);
                return infra;
            })
            .Compare(
                """
                resource dateTimeCollection 'Test.Provider/dateTimeCollections@2024-01-01' = {
                  name: 'date-time-collection'
                  properties: {
                    dateTimes: [
                      '2026-07-29T09:30:00.0000000+00:00'
                      '2026-07-30T10:45:00.0000000+00:00'
                    ]
                  }
                }
                """);
    }

    [Test]
    public async Task ValidateRfc7231DateTimeListProperty()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var resource = new DateTimeCollectionResource("dateTimeCollection")
                {
                    Name = "date-time-collection",
                    Rfc7231DateTimes =
                    [
                        new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero)
                    ]
                };
                infra.Add(resource);
                return infra;
            })
            .Compare(
                """
                resource dateTimeCollection 'Test.Provider/dateTimeCollections@2024-01-01' = {
                  name: 'date-time-collection'
                  properties: {
                    rfc7231DateTimes: [
                      'Wed, 29 Jul 2026 09:30:00 GMT'
                    ]
                  }
                }
                """);
    }

    [Test]
    public async Task ValidateRfc7231DateTimeDictionaryProperty()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var resource = new DateTimeCollectionResource("dateTimeCollection")
                {
                    Name = "date-time-collection"
                };
                resource.Rfc7231DateTimeMap.Add("created", new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero));
                infra.Add(resource);
                return infra;
            })
            .Compare(
                """
                resource dateTimeCollection 'Test.Provider/dateTimeCollections@2024-01-01' = {
                  name: 'date-time-collection'
                  properties: {
                    rfc7231DateTimeMap: {
                      created: 'Wed, 29 Jul 2026 09:30:00 GMT'
                    }
                  }
                }
                """);
    }

    [Test]
    public async Task ValidateDurationListProperty()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var resource = new DateTimeCollectionResource("dateTimeCollection")
                {
                    Name = "date-time-collection",
                    Durations =
                    [
                        new TimeSpan(1, 2, 3, 4)
                    ]
                };
                infra.Add(resource);
                return infra;
            })
            .Compare(
                """
                resource dateTimeCollection 'Test.Provider/dateTimeCollections@2024-01-01' = {
                  name: 'date-time-collection'
                  properties: {
                    durations: [
                      'P1DT2H3M4S'
                    ]
                  }
                }
                """);
    }

    [Test]
    public async Task ValidateScalarFormatTokens()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var resource = new ScalarFormatResource("formatTokens")
                {
                    Name = "format-tokens",
                    RfcDateTime = new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero),
                    IsoDateTime = new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero),
                    UnixDateTime = new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero),
                    PlainDate = new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero),
                    PlainTime = new TimeSpan(0, 2, 3, 4, 5),
                    IsoDuration = new TimeSpan(1, 2, 3, 4),
                    ConstantDuration = new TimeSpan(1, 2, 3, 4),
                    SecondsDuration = new TimeSpan(0, 0, 0, 1, 500),
                    SecondsInt64Duration = new TimeSpan(0, 0, 0, 1, 500),
                    SecondsFloatDuration = new TimeSpan(0, 0, 0, 1, 500),
                    SecondsDoubleDuration = new TimeSpan(0, 0, 0, 1, 500),
                    MillisecondsDuration = new TimeSpan(0, 0, 0, 1, 500),
                    MillisecondsInt64Duration = new TimeSpan(0, 0, 0, 1, 500),
                    MillisecondsFloatDuration = new TimeSpan(0, 0, 0, 1, 500),
                    MillisecondsDoubleDuration = new TimeSpan(0, 0, 0, 1, 500),
                    Base64Bytes = new byte[] { 1, 2, 251, 255 },
                    Base64UrlBytes = new byte[] { 1, 2, 251, 255 },
                    StringInt = 42,
                    StringLong = 9007199254740991
                };
                infra.Add(resource);
                return infra;
            })
            .Compare(
                """
                resource formatTokens 'Test.Provider/formatTokens@2024-01-01' = {
                  name: 'format-tokens'
                  properties: {
                    rfcDateTime: 'Wed, 29 Jul 2026 09:30:00 GMT'
                    isoDateTime: '2026-07-29T09:30:00.0000000Z'
                    unixDateTime: 1785317400
                    plainDate: '2026-07-29'
                    plainTime: '02:03:04.005'
                    isoDuration: 'P1DT2H3M4S'
                    constantDuration: '1.02:03:04'
                    secondsDuration: 2
                    secondsInt64Duration: 2
                    secondsFloatDuration: json('1.5')
                    secondsDoubleDuration: json('1.5')
                    millisecondsDuration: 1500
                    millisecondsInt64Duration: 1500
                    millisecondsFloatDuration: 1500
                    millisecondsDoubleDuration: 1500
                    base64Bytes: 'AQL7/w=='
                    base64UrlBytes: 'AQL7_w'
                    stringInt: '42'
                    stringLong: '9007199254740991'
                  }
                }
                """);
    }

    [Test]
    public async Task ValidateUnsupportedFormatsAreIgnoredWhenTypeHasNoFormatContract()
    {
        await using Trycep test = new();
        test.Define(
            ctx =>
            {
                var infra = new Infrastructure();
                var resource = new IgnoredFormatResource("ignoredFormat")
                {
                    Name = "ignored-format",
                    Enabled = true,
                    Text = "not-a-date"
                };
                infra.Add(resource);
                return infra;
            })
            .Compare(
                """
                resource ignoredFormat 'Test.Provider/ignoredFormats@2024-01-01' = {
                  name: 'ignored-format'
                  properties: {
                    enabled: true
                    text: 'not-a-date'
                  }
                }
                """);
    }

    [Test]
    public async Task ValidateUnsupportedFormatTokenFailsForFormattedTypes()
    {
        await using Trycep test = new();
        Assert.Throws<InvalidOperationException>(
            () => test.Define(
                ctx =>
                {
                    var infra = new Infrastructure();
                    var resource = new InvalidFormatResource("invalidFormat")
                    {
                        Name = "invalid-format",
                        DateTime = new DateTimeOffset(2026, 7, 29, 9, 30, 0, TimeSpan.Zero)
                    };
                    infra.Add(resource);
                    return infra;
                })
                .Compare(""));
    }

    private class DateTimeCollectionResource : ProvisionableResource
    {
        public BicepValue<string> Name
        {
            get { Initialize(); return _name!; }
            set { Initialize(); _name!.Assign(value); }
        }
        private BicepValue<string>? _name;

        public BicepList<DateTimeOffset> DateTimes
        {
            get { Initialize(); return _dateTimes!; }
            set { Initialize(); _dateTimes!.Assign(value); }
        }
        private BicepList<DateTimeOffset>? _dateTimes;

        public BicepList<DateTimeOffset> Rfc7231DateTimes
        {
            get { Initialize(); return _rfc7231DateTimes!; }
            set { Initialize(); _rfc7231DateTimes!.Assign(value); }
        }
        private BicepList<DateTimeOffset>? _rfc7231DateTimes;

        public BicepDictionary<DateTimeOffset> Rfc7231DateTimeMap
        {
            get { Initialize(); return _rfc7231DateTimeMap!; }
            set { Initialize(); _rfc7231DateTimeMap!.Assign(value); }
        }
        private BicepDictionary<DateTimeOffset>? _rfc7231DateTimeMap;

        public BicepList<TimeSpan> Durations
        {
            get { Initialize(); return _durations!; }
            set { Initialize(); _durations!.Assign(value); }
        }
        private BicepList<TimeSpan>? _durations;

        public DateTimeCollectionResource(string bicepIdentifier)
            : base(bicepIdentifier, "Test.Provider/dateTimeCollections", "2024-01-01")
        {
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _name = DefineProperty<string>("Name", ["name"], isRequired: true);
            _dateTimes = DefineListProperty<DateTimeOffset>("DateTimes", ["properties", "dateTimes"]);
            _rfc7231DateTimes = DefineListProperty<DateTimeOffset>("Rfc7231DateTimes", ["properties", "rfc7231DateTimes"], isOutput: false, isRequired: false, format: "R");
            _rfc7231DateTimeMap = DefineDictionaryProperty<DateTimeOffset>("Rfc7231DateTimeMap", ["properties", "rfc7231DateTimeMap"], isOutput: false, isRequired: false, format: "R");
            _durations = DefineListProperty<TimeSpan>("Durations", ["properties", "durations"], isOutput: false, isRequired: false, format: "P");
        }
    }

    private class ScalarFormatResource : ProvisionableResource
    {
        public BicepValue<string> Name
        {
            get { Initialize(); return _name!; }
            set { Initialize(); _name!.Assign(value); }
        }
        private BicepValue<string>? _name;

        public BicepValue<DateTimeOffset> RfcDateTime { get { Initialize(); return _rfcDateTime!; } set { Initialize(); _rfcDateTime!.Assign(value); } }
        private BicepValue<DateTimeOffset>? _rfcDateTime;

        public BicepValue<DateTimeOffset> IsoDateTime { get { Initialize(); return _isoDateTime!; } set { Initialize(); _isoDateTime!.Assign(value); } }
        private BicepValue<DateTimeOffset>? _isoDateTime;

        public BicepValue<DateTimeOffset> UnixDateTime { get { Initialize(); return _unixDateTime!; } set { Initialize(); _unixDateTime!.Assign(value); } }
        private BicepValue<DateTimeOffset>? _unixDateTime;

        public BicepValue<DateTimeOffset> PlainDate { get { Initialize(); return _plainDate!; } set { Initialize(); _plainDate!.Assign(value); } }
        private BicepValue<DateTimeOffset>? _plainDate;

        public BicepValue<TimeSpan> PlainTime { get { Initialize(); return _plainTime!; } set { Initialize(); _plainTime!.Assign(value); } }
        private BicepValue<TimeSpan>? _plainTime;

        public BicepValue<TimeSpan> IsoDuration { get { Initialize(); return _isoDuration!; } set { Initialize(); _isoDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _isoDuration;

        public BicepValue<TimeSpan> ConstantDuration { get { Initialize(); return _constantDuration!; } set { Initialize(); _constantDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _constantDuration;

        public BicepValue<TimeSpan> SecondsDuration { get { Initialize(); return _secondsDuration!; } set { Initialize(); _secondsDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _secondsDuration;

        public BicepValue<TimeSpan> SecondsInt64Duration { get { Initialize(); return _secondsInt64Duration!; } set { Initialize(); _secondsInt64Duration!.Assign(value); } }
        private BicepValue<TimeSpan>? _secondsInt64Duration;

        public BicepValue<TimeSpan> SecondsFloatDuration { get { Initialize(); return _secondsFloatDuration!; } set { Initialize(); _secondsFloatDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _secondsFloatDuration;

        public BicepValue<TimeSpan> SecondsDoubleDuration { get { Initialize(); return _secondsDoubleDuration!; } set { Initialize(); _secondsDoubleDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _secondsDoubleDuration;

        public BicepValue<TimeSpan> MillisecondsDuration { get { Initialize(); return _millisecondsDuration!; } set { Initialize(); _millisecondsDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _millisecondsDuration;

        public BicepValue<TimeSpan> MillisecondsInt64Duration { get { Initialize(); return _millisecondsInt64Duration!; } set { Initialize(); _millisecondsInt64Duration!.Assign(value); } }
        private BicepValue<TimeSpan>? _millisecondsInt64Duration;

        public BicepValue<TimeSpan> MillisecondsFloatDuration { get { Initialize(); return _millisecondsFloatDuration!; } set { Initialize(); _millisecondsFloatDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _millisecondsFloatDuration;

        public BicepValue<TimeSpan> MillisecondsDoubleDuration { get { Initialize(); return _millisecondsDoubleDuration!; } set { Initialize(); _millisecondsDoubleDuration!.Assign(value); } }
        private BicepValue<TimeSpan>? _millisecondsDoubleDuration;

        public BicepValue<byte[]> Base64Bytes { get { Initialize(); return _base64Bytes!; } set { Initialize(); _base64Bytes!.Assign(value); } }
        private BicepValue<byte[]>? _base64Bytes;

        public BicepValue<byte[]> Base64UrlBytes { get { Initialize(); return _base64UrlBytes!; } set { Initialize(); _base64UrlBytes!.Assign(value); } }
        private BicepValue<byte[]>? _base64UrlBytes;

        public BicepValue<int> StringInt { get { Initialize(); return _stringInt!; } set { Initialize(); _stringInt!.Assign(value); } }
        private BicepValue<int>? _stringInt;

        public BicepValue<long> StringLong { get { Initialize(); return _stringLong!; } set { Initialize(); _stringLong!.Assign(value); } }
        private BicepValue<long>? _stringLong;

        public ScalarFormatResource(string bicepIdentifier)
            : base(bicepIdentifier, "Test.Provider/formatTokens", "2024-01-01")
        {
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _name = DefineProperty<string>("Name", ["name"], isRequired: true);
            _rfcDateTime = DefineProperty<DateTimeOffset>("RfcDateTime", ["properties", "rfcDateTime"], format: "R");
            _isoDateTime = DefineProperty<DateTimeOffset>("IsoDateTime", ["properties", "isoDateTime"], format: "O");
            _unixDateTime = DefineProperty<DateTimeOffset>("UnixDateTime", ["properties", "unixDateTime"], format: "U");
            _plainDate = DefineProperty<DateTimeOffset>("PlainDate", ["properties", "plainDate"], format: "D");
            _plainTime = DefineProperty<TimeSpan>("PlainTime", ["properties", "plainTime"], format: "T");
            _isoDuration = DefineProperty<TimeSpan>("IsoDuration", ["properties", "isoDuration"], format: "P");
            _constantDuration = DefineProperty<TimeSpan>("ConstantDuration", ["properties", "constantDuration"], format: "c");
            _secondsDuration = DefineProperty<TimeSpan>("SecondsDuration", ["properties", "secondsDuration"], format: "seconds");
            _secondsInt64Duration = DefineProperty<TimeSpan>("SecondsInt64Duration", ["properties", "secondsInt64Duration"], format: "seconds-int64");
            _secondsFloatDuration = DefineProperty<TimeSpan>("SecondsFloatDuration", ["properties", "secondsFloatDuration"], format: "seconds-float");
            _secondsDoubleDuration = DefineProperty<TimeSpan>("SecondsDoubleDuration", ["properties", "secondsDoubleDuration"], format: "seconds-double");
            _millisecondsDuration = DefineProperty<TimeSpan>("MillisecondsDuration", ["properties", "millisecondsDuration"], format: "milliseconds");
            _millisecondsInt64Duration = DefineProperty<TimeSpan>("MillisecondsInt64Duration", ["properties", "millisecondsInt64Duration"], format: "milliseconds-int64");
            _millisecondsFloatDuration = DefineProperty<TimeSpan>("MillisecondsFloatDuration", ["properties", "millisecondsFloatDuration"], format: "milliseconds-float");
            _millisecondsDoubleDuration = DefineProperty<TimeSpan>("MillisecondsDoubleDuration", ["properties", "millisecondsDoubleDuration"], format: "milliseconds-double");
            _base64Bytes = DefineProperty<byte[]>("Base64Bytes", ["properties", "base64Bytes"], format: "base64");
            _base64UrlBytes = DefineProperty<byte[]>("Base64UrlBytes", ["properties", "base64UrlBytes"], format: "base64url");
            _stringInt = DefineProperty<int>("StringInt", ["properties", "stringInt"], format: "string");
            _stringLong = DefineProperty<long>("StringLong", ["properties", "stringLong"], format: "string");
        }
    }

    private class IgnoredFormatResource : ProvisionableResource
    {
        public BicepValue<string> Name
        {
            get { Initialize(); return _name!; }
            set { Initialize(); _name!.Assign(value); }
        }
        private BicepValue<string>? _name;

        public BicepValue<bool> Enabled
        {
            get { Initialize(); return _enabled!; }
            set { Initialize(); _enabled!.Assign(value); }
        }
        private BicepValue<bool>? _enabled;

        public BicepValue<string> Text
        {
            get { Initialize(); return _text!; }
            set { Initialize(); _text!.Assign(value); }
        }
        private BicepValue<string>? _text;

        public IgnoredFormatResource(string bicepIdentifier)
            : base(bicepIdentifier, "Test.Provider/ignoredFormats", "2024-01-01")
        {
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _name = DefineProperty<string>("Name", ["name"], isRequired: true);
            _enabled = DefineProperty<bool>("Enabled", ["properties", "enabled"], format: "R");
            _text = DefineProperty<string>("Text", ["properties", "text"], format: "R");
        }
    }

    private class InvalidFormatResource : ProvisionableResource
    {
        public BicepValue<string> Name
        {
            get { Initialize(); return _name!; }
            set { Initialize(); _name!.Assign(value); }
        }
        private BicepValue<string>? _name;

        public BicepValue<DateTimeOffset> DateTime
        {
            get { Initialize(); return _dateTime!; }
            set { Initialize(); _dateTime!.Assign(value); }
        }
        private BicepValue<DateTimeOffset>? _dateTime;

        public InvalidFormatResource(string bicepIdentifier)
            : base(bicepIdentifier, "Test.Provider/invalidFormats", "2024-01-01")
        {
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _name = DefineProperty<string>("Name", ["name"], isRequired: true);
            _dateTime = DefineProperty<DateTimeOffset>("DateTime", ["properties", "dateTime"], format: "base64");
        }
    }
}
