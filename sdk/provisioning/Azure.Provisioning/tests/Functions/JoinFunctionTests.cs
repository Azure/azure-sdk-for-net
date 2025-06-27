// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Functions
{
    public class JoinFunctionTests
    {
        [TestCase(new string[0], ",", ExpectedResult = "join([], ',')")]
        [TestCase(new string[] { "a" }, ",", ExpectedResult = "join([\r\n  'a'\r\n], ',')")]
        [TestCase(new string[] { "a", "b" }, ",", ExpectedResult = "join([\r\n  'a'\r\n  'b'\r\n], ',')")]
        public string JoinFunction_WithBothLiterals(string[] inputArray, string delimiter)
        {
            BicepList<string> array = [.. inputArray];
            return BicepFunction.Join(array, delimiter).ToString();
        }

        [TestCase("test", ",", ExpectedResult = "join(test.array, ',')")]
        public string JoinFunction_WithLiteralDelimiter(string resourceName, string delimiter)
        {
            var resource = new TestResource(resourceName);
            return BicepFunction.Join(resource.Array, delimiter).ToString();
        }

        [TestCase("test", ExpectedResult = "join(test.array, test.delimiter)")]
        public string JoinFunction_WithBothExpressions(string resourceName)
        {
            var resource = new TestResource(resourceName);
            return BicepFunction.Join(resource.Array, resource.Delimiter).ToString();
        }

        private class TestResource : ProvisionableResource
        {
            public TestResource(string bicepIdentifier, string? resourceVersion = null) : base(bicepIdentifier, "Microsoft.Provisioning/tests", resourceVersion ?? "2025-06-20")
            {
            }

            public BicepList<string> Array
            {
                get { Initialize(); return _array!; }
            }
            private BicepList<string>? _array;

            public BicepValue<string> Delimiter
            {
                get { Initialize(); return _delimiter!; }
                set { Initialize(); _delimiter!.Assign(value); }
            }
            private BicepValue<string>? _delimiter;

            protected override void DefineProvisionableProperties()
            {
                _array = DefineListProperty<string>("array", ["array"], isOutput: true);
                _delimiter = DefineProperty<string>("delimiter", ["delimiter"], isOutput: true);
            }
        }
    }
}
