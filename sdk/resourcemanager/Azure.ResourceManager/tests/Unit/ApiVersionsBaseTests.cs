using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ApiVersionsBaseTests
    {
        [TestCase]
        public void VersionToString()
        {
            ArmClientOptions options = new ArmClientOptions();
            Assert.AreEqual("2020-06-01", options.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperator()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            ArmClientOptions options2 = new ArmClientOptions();

            Assert.IsTrue(options1.FakeRestApiVersions().FakeResourceVersion == options2.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperatorString()
        {
            ArmClientOptions options = new ArmClientOptions();

            Assert.IsTrue(FakeResourceApiVersions.Default == options.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperatorStringFirstNull()
        {
            ArmClientOptions options = new ArmClientOptions();

            Assert.IsFalse(null == options.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperatorStringSecondNull()
        {
            ArmClientOptions options = new ArmClientOptions();

            Assert.IsFalse(options.FakeRestApiVersions().FakeResourceVersion == null);
        }

        [TestCase]
        public void EqualsOperatorStringBothNull()
        {
            FakeResourceApiVersions v1 = null;

            Assert.IsTrue(v1 == null);
        }

        [TestCase]
        public void NotEqualsOperator()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            ArmClientOptions options2 = new ArmClientOptions();

            Assert.IsFalse(options1.FakeRestApiVersions().FakeResourceVersion != options2.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void NotEqualsOperatorStringFirstNull()
        {
            ArmClientOptions options = new ArmClientOptions();

            Assert.IsTrue(null != options.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void NotEqualsOperatorStringSecondNull()
        {
            ArmClientOptions options = new ArmClientOptions();

            Assert.IsTrue(options.FakeRestApiVersions().FakeResourceVersion != null);
        }

        [TestCase]
        public void NotEqualsOperatorStringBothNull()
        {
            FakeResourceApiVersions v1 = null;

            Assert.IsFalse(v1 != null);
        }

        [TestCase]
        public void EqualsMethod()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            ArmClientOptions options2 = new ArmClientOptions();

            Assert.IsTrue(options1.FakeRestApiVersions().FakeResourceVersion.Equals(options2.FakeRestApiVersions().FakeResourceVersion));
        }

        [TestCase]
        public void EqualsMethodVersionNull()
        {
            ArmClientOptions options = new ArmClientOptions();
            FakeResourceApiVersions version = null;
            Assert.IsFalse(options.FakeRestApiVersions().FakeResourceVersion.Equals(version));
        }

        [TestCase]
        public void EqualsMethodStringNull()
        {
            ArmClientOptions options = new ArmClientOptions();
            string version = null;
            Assert.IsFalse(options.FakeRestApiVersions().FakeResourceVersion.Equals(version));
        }

        [TestCase]
        public void EqualsMethodAsObject()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            ArmClientOptions options2 = new ArmClientOptions();

            object obj = options2.FakeRestApiVersions().FakeResourceVersion;
            Assert.IsTrue(options1.FakeRestApiVersions().FakeResourceVersion.Equals(obj));
        }

        [TestCase]
        public void EqualsMethodAsObjectThatIsString()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            ArmClientOptions options2 = new ArmClientOptions();

            object obj = options2.FakeRestApiVersions().FakeResourceVersion.ToString();
            Assert.IsTrue(options1.FakeRestApiVersions().FakeResourceVersion.Equals(obj));
        }

        [TestCase]
        public void EqualsMethodAsObjectThatIsInt()
        {
            ArmClientOptions options = new ArmClientOptions();

            object obj = 1;
            Assert.IsFalse(options.FakeRestApiVersions().FakeResourceVersion.Equals(obj));
        }

        [TestCase]
        public void ImplicitToString()
        {
            string version = FakeResourceApiVersions.V2019_12_01;
            Assert.IsTrue(version == "2019-12-01");
        }

        [TestCase(-1, "2019-12-01", "2020-06-01")]
        [TestCase(0, "2019-12-01", "2019-12-01")]
        [TestCase(1, "2020-06-01", "2019-12-01")]
        [TestCase(1, "2020-06-01", null)]
        public void CompareToMethodString(int expected, string version1, string version2)
        {
            FakeResourceApiVersions v1 = version1 == "2019-12-01" ? FakeResourceApiVersions.V2019_12_01 : FakeResourceApiVersions.V2020_06_01;
            Assert.AreEqual(expected, v1.CompareTo(version2));
        }

        private FakeResourceApiVersions ConvertFromString(string version)
        {
            switch(version)
            {
                case "2019-12-01":
                    return FakeResourceApiVersions.V2019_12_01;
                case "2020-06-01":
                    return FakeResourceApiVersions.V2020_06_01;
                case "2019-12-01-preview":
                    return FakeResourceApiVersions.V2019_12_01_preview;
                case "2019-12-01-preview-1":
                    return FakeResourceApiVersions.V2019_12_01_preview_1;
                case "2019-12-01-foobar":
                    return FakeResourceApiVersions.V2019_12_01_foobar;
                case null:
                    return null;
                default:
                    throw new ArgumentException($"Version ({version}) was not valid");
            }
        }

        [TestCase(-1, "2019-12-01", "2020-06-01")]
        [TestCase(-1, "2019-12-01-preview", "2020-06-01")]
        [TestCase(1, "2020-06-01", "2019-12-01-preview")]
        [TestCase(0, "2019-12-01", "2019-12-01")]
        [TestCase(-1, "2019-12-01-foobar", "2019-12-01-preview")]
        [TestCase(1, "2019-12-01-preview", "2019-12-01-foobar")]
        [TestCase(1, "2019-12-01-preview-1", "2019-12-01-preview")]
        [TestCase(-1, "2019-12-01-preview", "2019-12-01-preview-1")]
        [TestCase(0, "2019-12-01-preview", "2019-12-01-preview")]
        [TestCase(-1, "2019-12-01-preview", "2019-12-01")]
        [TestCase(1, "2019-12-01", "2019-12-01-preview")]
        [TestCase(1, "2020-06-01", "2019-12-01")]
        [TestCase(1, "2020-06-01", null)]
        public void CompareToMethodVersionObject(int expected, string version1, string version2)
        {
            FakeResourceApiVersions v1 = ConvertFromString(version1);
            FakeResourceApiVersions v2 = null;
            if (version2 != null)
                v2 = ConvertFromString(version2);
            Assert.AreEqual(expected, v1.CompareTo(v2));
        }

        [TestCase]
        public void ToStringTest()
        {
            Assert.AreEqual("2020-06-01", FakeResourceApiVersions.Default.ToString());
        }

        [TestCase]
        public void GetHashCodeTest()
        {
            FakeResourceApiVersions version = FakeResourceApiVersions.Default;
            Assert.AreEqual(version.ToString().GetHashCode(), version.GetHashCode());
        }

        [TestCase("2019-12-01", null)]
        [TestCase("2020-06-01", "2019-12-01")]
        public void TestGreaterThanTrue(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsTrue(left > right);
        }

        [TestCase("2019-12-01", null)]
        [TestCase("2020-06-01", "2019-12-01")]
        [TestCase("2020-06-01", "2020-06-01")]
        public void TestGreaterThanOrEqualTrue(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsTrue(left >= right);
        }

        [TestCase(null, "2019-12-01")]
        [TestCase("2019-12-01", "2020-06-01")]
        [TestCase(null, null)]
        [TestCase("2020-06-01", "2020-06-01")]
        public void TestGreaterThanFalse(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsFalse(left > right);
        }

        [TestCase(null, "2019-12-01")]
        [TestCase("2019-12-01", "2020-06-01")]
        public void TestGreaterThanOrEqualFalse(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsFalse(left >= right);
        }

        [TestCase(null, "2019-12-01")]
        [TestCase("2019-12-01-foobar", "2019-12-01-preview-1")]
        public void TestLessThanTrue(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsTrue(left < right);
        }

        [TestCase(null, "2019-12-01")]
        [TestCase("2019-12-01-foobar", "2019-12-01-preview-1")]
        [TestCase("2020-06-01", "2020-06-01")]
        public void TestLessThanOrEqualTrue(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsTrue(left <= right);
        }

        [TestCase("2019-12-01", null)]
        [TestCase("2020-06-01", "2019-12-01-foobar")]
        [TestCase(null, null)]
        [TestCase("2020-06-01", "2020-06-01")]
        public void TestLessThanFalse(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsFalse(left < right);
        }

        [TestCase("2019-12-01", null)]
        [TestCase("2020-06-01", "2019-12-01-foobar")]
        public void TestLessThanOrEqualFalse(string leftString, string rightString)
        {
            FakeResourceApiVersions left = ConvertFromString(leftString);
            FakeResourceApiVersions right = ConvertFromString(rightString);
            Assert.IsFalse(left <= right);
        }
    }
}
