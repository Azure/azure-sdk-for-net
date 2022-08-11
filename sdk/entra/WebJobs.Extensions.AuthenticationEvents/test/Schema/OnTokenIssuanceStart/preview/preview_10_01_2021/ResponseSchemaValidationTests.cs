using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using NJsonSchema.Validation;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using static WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;

namespace WebJobs.Extensions.AuthenticationEvents.Tests.Schema
{
    /// <summary>
    /// Test class for covering Response Schema Validation for OnTokenIssuanceStart custom extension.
    /// This is for API schema version: Preview_10_01_2021
    /// </summary>
    public class ResponseSchemaValidationTests
        : BaseJsonSchemaValidationTest<ResponseSchemaValidationTests>
    {
        /// <summary>
        /// Static constructor to register the test scenarios.
        /// </summary>
        static ResponseSchemaValidationTests()
        {
            RegisterTestScenarios(TestScenarioData);
        }

        private const string ExtensionType = "onTokenIssuanceStartCustomExtension";
        private const string ApiSchemaVersion = "10-01-2021-preview";
        private const string ProvideClaimsForTokenActionType = "ProvideClaimsForToken";

        private const string EmptyJson = @"{}";
        private const string WrongExtensionTypeAndApiSchemaVersionJson = @"{""type"": ""SomeDummyEvent"", ""apiSchemaVersion"": ""SomeDummySchema""}";
        private const string NoActionsJson = @"{""actions"": []}";
        private const string TooManyActionsJson = @"{""actions"": [{}, {}]}";
        private const string WrongActionTypeJson = @"{""actions"": [{""type"": ""SomeDummyAction""}]}";
        private const string MissingClaimsInActionJson = @"{""actions"": [{""type"": """ + ProvideClaimsForTokenActionType + @"""}]}";
        private const string NoClaimsReturnedInActionJson = @"{""actions"": [{""type"": """ + ProvideClaimsForTokenActionType + @""", ""claims"": []}]}";
        private const string ClaimIdAndValueAreMissingJson = @"{""actions"": [{""type"": """ + ProvideClaimsForTokenActionType + @""", ""claims"": [{}]}]}";
        private const string ClaimValueCanBeStringOrArrayJson = @"{""actions"": [{""type"": """ + ProvideClaimsForTokenActionType + @""", ""claims"": [{""id"": ""key1"", ""value"": ""val""}, {""id"": ""key2"", ""value"": []}, {""id"": ""key3"", ""value"": [""val"", ""val2""]}]}]}]}";
        private const string ValidJson = @"{""type"": """ + ExtensionType + @""", ""apiSchemaVersion"": """ + ApiSchemaVersion + @""", ""actions"": [{""type"": """ + ProvideClaimsForTokenActionType + @""", ""claims"": [{""id"": ""key1"", ""value"": ""val""}, {""id"": ""key2"", ""value"": [""val"", ""val2""]}]}]}]}";


        /// <summary>The test scenario data,</summary>
        private static readonly TheoryData TestScenarioData = new TheoryData<TestScenario>
        {
            // Empty Json Test: Checks the root required fields
            new TestScenario
            {
                TestName = "Empty Json Test: Checks the root required fields",
                JsonPayload = EmptyJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/type", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/apiSchemaVersion", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/actions", ValidationErrorKind.PropertyRequired)
                },
                ValidateNumberOfErrors = true
            },

            // Incorrect Extension Type and Api Schema Version Test
            new TestScenario
            {
                TestName = "Incorrect Extension Type and Api Schema Version Test",
                JsonPayload = WrongExtensionTypeAndApiSchemaVersionJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/type", ValidationErrorKind.NotInEnumeration),
                    new ValidationErrorTestData("#/apiSchemaVersion", ValidationErrorKind.NotInEnumeration),
                }
            },

            // Check that no actions are not allowed
            new TestScenario
            {
                TestName = "Check that no actions are not allowed",
                JsonPayload = NoActionsJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/actions", ValidationErrorKind.TooFewItems),
                }
            },

            // Check that more than 1 action is not allowed
            new TestScenario
            {
                TestName = "Check that more than 1 action is not allowed",
                JsonPayload = TooManyActionsJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/actions", ValidationErrorKind.TooManyItems),
                }
            },

            // Check that incorrect action types are not allowed
            new TestScenario
            {
                TestName = "Check that incorrect action types are not allowed",
                JsonPayload = WrongActionTypeJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/actions[0].type", ValidationErrorKind.NotInEnumeration),
                }
            },

            // Check that for ProvideClaimsForToken action, claims are required
            new TestScenario
            {
                TestName = "Check that for ProvideClaimsForToken action, claims are required",
                JsonPayload = MissingClaimsInActionJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/actions[0].claims", ValidationErrorKind.PropertyRequired),
                }
            },

            // Check that for ProvideClaimsForToken action, empty array for claims is allowed
            new TestScenario
            {
                TestName = "Check that for ProvideClaimsForToken action, empty array for claims is allowed",
                JsonPayload = NoClaimsReturnedInActionJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/actions", allowPathPartialMatch: true, isExcludeMode: true),
                }
            },

            // Check that for ProvideClaimsForToken action, claim id and value are required
            new TestScenario
            {
                TestName = "Check that for ProvideClaimsForToken action, claim id and value are required",
                JsonPayload = ClaimIdAndValueAreMissingJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/actions[0].claims[0].id", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/actions[0].claims[0].value", ValidationErrorKind.PropertyRequired),
                }
            },

            // Check that for ProvideClaimsForToken action, claim value can be string or array of strings
            new TestScenario
            {
                TestName = "Check that for ProvideClaimsForToken action, claim value can be string or array of strings",
                JsonPayload = ClaimValueCanBeStringOrArrayJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/actions", allowPathPartialMatch: true, isExcludeMode: true),
                }
            },

            // Validate full example JSON
            new TestScenario
            {
                TestName = "Validate full example JSON",
                JsonPayload = ValidJson,
                ValidateNumberOfErrors = true
            }
        };

        /// <summary>Initializes a new instance of the <see cref="ResponseSchemaValidationTests" /> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public ResponseSchemaValidationTests(ITestOutputHelper testOutputHelper)
            : base(EventDefinition.TokenIssuanceStartV20211001Preview, TestSchemaType.Response, testOutputHelper)
        {
        }

        /// <summary>Gets the specific test scenario data by test index.</summary>
        /// <param name="testScenarioIndex">Index of the test scenario.</param>
        /// <returns>A list with a single element of specific test scenario data.</returns>
        public static TheoryData GetSpecificTestData(int testScenarioIndex) => GetTestData(testScenarioIndex);

        /// <summary>Gets all test data.</summary>
        /// <returns>List of all test scenario data</returns>
        public static TheoryData GetAllTestData() => GetTestData();

        /// <summary>Tests the response schema.</summary>
        /// <param name="scenario">The test scenario data.</param>
        [Theory]
        [MemberData(nameof(GetAllTestData))]
        public void TestResponseSchema(TestScenario scenario)
        {
            base.ValidateTestData(scenario);
        }
    }
}
