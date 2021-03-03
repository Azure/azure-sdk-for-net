using NUnit.Framework;
using System;

namespace Azure.ResourceManager.Core.Tests
{
    public class ApiVersionsBaseTests
    {
        [TestCase]
        public void VersionToString()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            Assert.AreEqual("2020-06-01", options.FakeRpApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperator()
        {
            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();

            Assert.IsTrue(options1.FakeRpApiVersions().FakeResourceVersion == options2.FakeRpApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperatorString()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();

            Assert.IsTrue(FakeResourceApiVersions.Default == options.FakeRpApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperatorStringFirstNull()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();

            Assert.IsFalse(null == options.FakeRpApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void EqualsOperatorStringSecondNull()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();

            Assert.IsFalse(options.FakeRpApiVersions().FakeResourceVersion == null);
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
            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();

            Assert.IsFalse(options1.FakeRpApiVersions().FakeResourceVersion != options2.FakeRpApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void NotEqualsOperatorStringFirstNull()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();

            Assert.IsTrue(null != options.FakeRpApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void NotEqualsOperatorStringSecondNull()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();

            Assert.IsTrue(options.FakeRpApiVersions().FakeResourceVersion != null);
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
            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();

            Assert.IsTrue(options1.FakeRpApiVersions().FakeResourceVersion.Equals(options2.FakeRpApiVersions().FakeResourceVersion));
        }

        [TestCase]
        public void EqualsMethodVersionNull()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            FakeResourceApiVersions version = null;
            Assert.IsFalse(options.FakeRpApiVersions().FakeResourceVersion.Equals(version));
        }

        [TestCase]
        public void EqualsMethodStringNull()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            string version = null;
            Assert.IsFalse(options.FakeRpApiVersions().FakeResourceVersion.Equals(version));
        }

        [TestCase]
        public void EqualsMethodAsObject()
        {
            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();

            object obj = options2.FakeRpApiVersions().FakeResourceVersion;
            Assert.IsTrue(options1.FakeRpApiVersions().FakeResourceVersion.Equals(obj));
        }

        [TestCase]
        public void EqualsMethodAsObjectThatIsString()
        {
            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();

            object obj = options2.FakeRpApiVersions().FakeResourceVersion.ToString();
            Assert.IsTrue(options1.FakeRpApiVersions().FakeResourceVersion.Equals(obj));
        }

        [TestCase]
        public void EqualsMethodAsObjectThatIsInt()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();

            object obj = 1;
            Assert.IsFalse(options.FakeRpApiVersions().FakeResourceVersion.Equals(obj));
        }

        [TestCase]
        public void ImplicitToString()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            options.FakeRpApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            string version = options.FakeRpApiVersions().FakeResourceVersion;
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
    }
}
