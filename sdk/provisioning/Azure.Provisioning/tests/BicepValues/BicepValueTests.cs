// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.BicepValues;

public class BicepValueTests
{
    [TestCaseSource(nameof(LiteralBicepValueTestCases))]
    public string ValidateLiteralBicepValue(BicepValue bicepValue)
    {
        return bicepValue.ToString();
    }

    private static IEnumerable<TestCaseData> LiteralBicepValueTestCases()
    {
        yield return new TestCaseData(new BicepValue<string>("test")).Returns("'test'");

        yield return new TestCaseData(new BicepValue<int>(42)).Returns("42");
        yield return new TestCaseData(new BicepValue<int>(-42)).Returns("-42");

        yield return new TestCaseData(new BicepValue<bool>(true)).Returns("true");
        yield return new TestCaseData(new BicepValue<bool>(false)).Returns("false");

        yield return new TestCaseData(new BicepValue<double>(3.14)).Returns("json('3.14')");
        yield return new TestCaseData(new BicepValue<double>(-3.14)).Returns("json('-3.14')");
    }
}
