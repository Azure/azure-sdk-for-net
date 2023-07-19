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
        [TestCaseSource(nameof(TestScenarios))]
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

        /// <summary>
        /// Class that holds the attribute we want to test
        /// </summary>
        private class DummyClass
        {
            [OneOrMoreRequired]
            public object Obj { get; set; }
        }

        private static IEnumerable<object[]> TestScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = null,
                Message = "Testing null",
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new object(),
                Message = "Testing object",
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new List<object>(),
                Message = "Testing initialized object",
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new object[0],
                Message = "Testing empty array",
            }.ToArray;
#endregion

#region Valid
            yield return new TestCaseStructure()
            {
                Test = new List<object>() { new(), new() },
                Message = "Testing list of objects",
                Success = true,
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new object[1],
                Message = "Testing single item array",
                Success = true,
            }.ToArray;
#endregion
        }
    }
}
