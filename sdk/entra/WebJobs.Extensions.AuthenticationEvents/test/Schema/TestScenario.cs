using System.Collections.Generic;

namespace WebJobs.Extensions.AuthenticationEvents.Tests.Schema
{
    /// <summary>Describes the test scenario.</summary>
    public class TestScenario
    {
        /// <summary>Gets or sets the name of the test.</summary>
        /// <value>The name of the test.</value>
        public string TestName { get; set; }

        /// <summary>Gets or sets the stringified JSON payload.</summary>
        /// <value>The stringified JSON payload.</value>
        public string JsonPayload { get; set; }

        /// <summary>Gets or sets the expected errors.</summary>
        /// <value>The expected errors.</value>
        public IList<ValidationErrorTestData> ExpectedErrors { get; set; } = new List<ValidationErrorTestData>();

        /// <summary>Gets or sets a value indicating whether to validate number of errors.</summary>
        /// <value> If true, validate the number of expected errors to the actual number of validation errors</value>
        public bool ValidateNumberOfErrors { get; set; }
    }
}
