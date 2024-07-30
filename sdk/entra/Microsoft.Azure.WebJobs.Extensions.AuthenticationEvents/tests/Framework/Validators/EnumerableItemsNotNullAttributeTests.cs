// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework.Validators
{
    [TestFixture]
    /// <summary>
    /// This class will test OneOrMoreRequiredAttribute
    /// </summary>
    public class EnumerableItemsNotNullAttributeTests
    {
        [Test]
        [TestCaseSource(nameof(TestScenarios))]
        public void EnumberableItemsNotNullIsValidWithTestCase(object testObject, string message, bool success, string exceptionMessage)
        {
            DummyClass dummyObj = new() { Obj = testObject };

            if (success == false)
            {
                var ex = Assert.Throws<ValidationException>(() => Validator.ValidateObject(dummyObj, new ValidationContext(dummyObj), true));
                Assert.AreEqual(exceptionMessage, ex.Message);
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
            [EnumerableItemsNotNull]
            public object Obj { get; set; }
        }

        private static IEnumerable<object[]> TestScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = null,
                Message = "Testing null",
                ExceptionMessage = AuthenticationEventResource.Ex_Null_Action_Items,
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new object(),
                Message = "Testing object",
                ExceptionMessage = AuthenticationEventResource.Ex_Null_Action_Items,
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new List<object>() { null },
                Message = "Testing object list with null item",
                ExceptionMessage = AuthenticationEventResource.Ex_Null_Action_Items,
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new List<object>() { new(), null, new() },
                Message = "Testing object list with multiple items with one null",
                ExceptionMessage = AuthenticationEventResource.Ex_Null_Action_Items,
            }.ToArray;
            yield return new TestCaseStructure()
            {
                Test = new object[1],
                Message = "Testing single null item array",
                ExceptionMessage = AuthenticationEventResource.Ex_Null_Action_Items,
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
