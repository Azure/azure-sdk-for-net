using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.TestHelpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework.Validators
{
    [TestFixture]
    /// <summary>
    /// This class will test OneOrMoreRequiredAttribute
    /// </summary>
    public class EnumberableItemsNotNullAttributeTests
    {
        [Test]
        [TestCaseSource(nameof(TestScenarios))]
        [Description("Tests the cases for IsValid enumerables of objects")]
        public void EnumberableItemsNotNullIsValidWithTestCase(object testObject, string message, bool success)
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
            [EnumberableItemsNotNull]
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
                Test = new List<object>() { null },
                Message = "Testing object list with null item",
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new List<object>() { new(), null, new() },
                Message = "Testing object list with multiple items with one null",
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new object[1],
                Message = "Testing single null item array",
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
                Test = new List<object>(),
                Message = "Testing initialized object",
                Success = true,
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new object[0],
                Message = "Testing empty array",
                Success = true,
            }.ToArray;
#endregion
        }
    }
}
