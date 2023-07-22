using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Validators;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Framework.Validators
{
    [TestFixture]
    public class NotNullAttributeTests
    {
        [Test]
        [TestCaseSource(nameof(TestScenarios))]
        public void NotNullIsValidWithTestCase(object testObject, string message, bool success)
        {
            DummyClass dummyObj = new() { Obj = testObject };

            if (success == false)
            {
                Assert.Throws<ValidationException>(() => Validator.ValidateObject(dummyObj, new ValidationContext(dummyObj), true), AuthenticationEventResource.Val_Non_Default);
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
            [NotNull]
            public object Obj { get; set; }
        }

        private static IEnumerable<object> TestScenarios()
        {
#region Invalid
            yield return new TestCaseStructure()
            {
                Test = null,
                Message = "Testing null",
            }.ToArray;
#endregion

#region Valid
            yield return new TestCaseStructure()
            {
                Test = string.Empty,
                Message = "Testing string empty",
                Success = true,
            }.ToArray;
#endregion
        }
    }
}
