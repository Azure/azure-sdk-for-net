using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using NJsonSchema;
using NJsonSchema.Validation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;
using static WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;

namespace WebJobs.Extensions.AuthenticationEvents.Tests.Schema
{
    /// <summary>The abstract base class that sets up a framework for schema validation.</summary>
    public abstract class BaseJsonSchemaValidationTest<T> : IAsyncLifetime
        where T : BaseJsonSchemaValidationTest<T>
    {
        // holds the test scenarios for all validation tests based on tests class
        private static readonly ConcurrentDictionary<Type, TheoryData> TestBank =
            new ConcurrentDictionary<Type, TheoryData>();

        private readonly string schemaString;

        /// <summary>Gets the JSON schema.</summary>
        /// <value>The JSON schema.</value>
        protected JsonSchema JsonSchema { get; private set; }

        /// <summary>Gets the test output helper for logging.</summary>
        /// <value>The test output helper.</value>
        protected ITestOutputHelper TestOutputHelper { get; }

        /// <summary>Registers the test data.</summary>
        /// <param name="testData">The test data.</param>
        protected static void RegisterTestScenarios(TheoryData testData)
        {
            TestBank.TryAdd(typeof(T), testData);
        }

        /// <summary>Gets the test data.</summary>
        /// <param name="testIndex">The optional index of the test scenario.</param>
        /// <returns>Test theory data</returns>
        public static TheoryData GetTestData(int? testIndex = null)
        {
            if (TestBank.TryGetValue(typeof(T), out var testData))
            {
                // get the specific test scenario if index exists
                if (testIndex.HasValue)
                {
                    return new TheoryData<object>
                    {
                        testData.ElementAt(testIndex.Value)[0]
                    };
                }

                return testData;
            }

            return null;
        }

        /// <summary>Initializes a new instance of the <see cref="BaseJsonSchemaValidationTest{T}" /> class.</summary>
        /// <param name="eventSchema">The schema version.</param>
        /// <param name="schemaType">Type of the schema.</param>
        /// <param name="testOutputHelper">The test output helper.</param>
        protected BaseJsonSchemaValidationTest(
            EventDefinition eventSchema,
            TestSchemaType schemaType,
            ITestOutputHelper testOutputHelper)
        {
            this.schemaString = GetJsonValidationSchema(schemaType, eventSchema);
            this.TestOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Called immediately after the class has been created, before it is used.
        /// This method loads the JSON Schema from specified schema location. 
        /// </summary>
        public async Task InitializeAsync()
        {
            this.JsonSchema = await JsonSchema.FromJsonAsync(this.schemaString);
        }

        /// <summary>Helper method that validates the test data.</summary>
        /// <param name="scenario">The test scenario data.</param>
        protected void ValidateTestData(TestScenario scenario)
        {
            // log the executing test name
            this.TestOutputHelper.WriteLine($"Executing Test: {scenario.TestName}");

            // run JSON validation on the test payload based on json validation schema
            var schemaErrors = this.JsonSchema.Validate(scenario.JsonPayload);

            // if we are indicated to validate the number of errors,
            // ensure that we get the exactly expected number of errors
            if (scenario.ValidateNumberOfErrors)
            {
                try
                {
                    Assert.Equal(scenario.ExpectedErrors.Count, schemaErrors.Count);
                }
                catch (AssertActualExpectedException)
                {
                    this.TestOutputHelper.WriteLine($"All validation errors:\n{string.Join(",\n", schemaErrors)}");
                    throw;
                }
            }

            // for each expected error make sure that an actual error
            // with the specified parameters exist
            foreach (var expectedError in scenario.ExpectedErrors)
            {
                // check if there is an error match with the specified parameters
                bool hasExpectedError = this.TryMatchValidationError(
                    schemaErrors,
                    expectedError.Path,
                    expectedError.Kind,
                    expectedError.AllowPartialPathMatch);

                // XoR the hasExpectedError and isExcludeMode to understand if
                // test has failed or succeeded.
                // The test should only succeed if there is an error match and exclude mode is off,
                // or, there was no error match and exclude mode is on
                Assert.True(
                    hasExpectedError ^ expectedError.IsExcludeMode,
                    $"Expected error did not match. " +
                    $"Kind: {expectedError.Kind?.ToString() ?? "Any"}, " +
                    $"Path: {expectedError.Path}, " +
                    $"AllowPartialMatch: {expectedError.AllowPartialPathMatch}, " +
                    $"IsExcludeMode: {expectedError.IsExcludeMode}.\n" +
                    $"All validation errors:\n{string.Join(",\n", schemaErrors)}");
            }
        }

        /// <summary>Tries to recursively find a validation error match in the error tree.</summary>
        /// <param name="schemaErrors">The actual schema errors.</param>
        /// <param name="path">The path of expected error.</param>
        /// <param name="kind">The kind of expected error.</param>
        /// <param name="allowPartialMatch">
        /// Indicates whether we want to allow partial match.
        /// For example, if partial match is on, if the expected exception match
        /// has 
        /// </param>
        /// <returns>True, if there was a match given the parameters.</returns>
        private bool TryMatchValidationError(
            IEnumerable<ValidationError> schemaErrors,
            string path,
            ValidationErrorKind? kind,
            bool allowPartialMatch)
        {
            // if we allow partial match, check if there are any validation errors that
            // contain the partial match path and the optional kind, and if so, return true
            // Note: in this case we want to check that actual validation exception path starts with
            // the provided expected partial path.
            if (allowPartialMatch && schemaErrors
                .Any(x => x.Path.StartsWith(path) && (!kind.HasValue || x.Kind == kind)))
            {
                return true;
            }

            // for each expected validation error check if there is a match.
            // If there is no match, for all the actual errors such that their paths are part 
            // of the expected error, traverse the child errors recursively
            foreach (var error in schemaErrors.Where(x => path.StartsWith(x.Path)))
            {
                // check if full match
                if (path == error.Path && (!kind.HasValue || kind == error.Kind))
                {
                    // if no kind was provided, we will match Validation Kinds
                    return true;
                }

                var childErrors =
                    (error as ChildSchemaValidationError)?.Errors.Values
                    ?? (error as MultiTypeValidationError)?.Errors.Values;

                // check if the validation error has nested errors
                if (childErrors?.Count() > 0)
                {
                    // get a flattened list of all errors within the parent error
                    var flattenedValidationErrorList =
                        from errorList in childErrors
                        from validationError in errorList
                        select validationError;

                    // we want to check all the nested errors recursively for match 
                    if (TryMatchValidationError(flattenedValidationErrorList, path, kind, allowPartialMatch))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Called when an object is no longer needed. Called just before <see cref="M:System.IDisposable.Dispose">Dispose</see>
        /// if the class also implements that.
        /// Note: There is no tear down needed.
        /// </summary>
        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
