using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework.Validators
{
    [TestFixture]
    /// <summary>
    /// This class will test OneOrMoreRequiredAttribute
    /// </summary>
    public class OneOrMoreRequiredAttributeTests
    {
        [Test]
        [TestCaseSource(nameof(MyTestCases))]
        [Description("Tests the cases for IsValid enumerables of objects")]
        public void OneOrMoreRequiredIsValidWithTestCase(object testObject, string message, bool success)
        {
            DummyClass dummyObj = new() { Obj = testObject };

            if (success == false)
            {
                Assert.Throws<ValidationException>(() => Validator.ValidateObject(dummyObj, new ValidationContext(dummyObj), true), AuthenticationEventResource.Ex_No_Action);
            }
            else
            {
                Assert.DoesNotThrow(() => Validator.ValidateObject(dummyObj, new ValidationContext(dummyObj), true));
            }
        }

        private class DummyClass
        {
            [OneOrMoreRequired]
            public object Obj { get; set; }
        }

        private static IEnumerable<object[]> MyTestCases()
        {
#region Invalid
            yield return new TestCases()
            {
                Test = null,
                Message = "Testing null",
            }.ToArray;
            yield return new TestCases()
            {
                Test = new object(),
                Message = "Testing object",
            }.ToArray;
            yield return new TestCases()
            {
                Test = new List<object> (),
                Message = "Testing initiallized object",
            }.ToArray;
            yield return new TestCases()
            {
                Test = new object[0],
                Message = "Testing empty array",
            }.ToArray;
#endregion

#region Valid
            yield return new TestCases()
            {
                Test = new List<object>() { new(), new() },
                Message = "Testing list of objects",
                Success = true,
            }.ToArray;
            yield return new TestCases()
            {
                Test = new object[1],
                Message = "Testing single item array",
                Success = true,
            }.ToArray;
#endregion
        }

        private class TestCases
        {
            public object Test { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }

            public object[] ToArray => new object[] { Test, Message, Success };
        }
    }
}
