using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents;
using NJsonSchema.Validation;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using static WebJobs.Extensions.AuthenticationEvents.Tests.TestHelper;

namespace WebJobs.Extensions.AuthenticationEvents.Tests.Schema.OnTokenIssuanceStart.preview.preview_10_01_2021
{
    /// <summary>
    /// Test class for covering Request Schema Validation for OnTokenIssuanceStart custom extension.
    /// This is for API schema version: Preview_10_01_2021
    /// </summary>
    public class RequestSchemaValidationTests
        : BaseJsonSchemaValidationTest<RequestSchemaValidationTests>
    {
        /// <summary>
        /// Static constructor to register the test scenarios.
        /// </summary>
        static RequestSchemaValidationTests()
        {
            RegisterTestScenarios(TestScenarioData);
        }

        private const string ExtensionType = "onTokenIssuanceStartCustomExtension";
        private const string ApiSchemaVersion = "10-01-2021-preview";

        private const string EmptyJson = @"{}";
        private const string WrongExtensionTypeAndApiSchemaVersionJson = @"{""type"": ""SomeDummyEvent"", ""apiSchemaVersion"": ""SomeDummySchema""}";
        private const string EmptyContextDataJson = @"
        {
            ""type"": """ + ExtensionType + @""", 
            ""apiSchemaVersion"": """ + ApiSchemaVersion + @""",
            ""time"": ""2021-05-17T00:00:00.0000000Z"",
            ""eventListenerId"": ""10000000-0000-0000-0000-000000000001"",
            ""customExtensionId"": ""10000000-0000-0000-0000-000000000002"",
            ""context"": {
                ""roles"": null
            }
        }";
        private const string EmptySubContextsDataJson = @"
        {
            ""type"": """ + ExtensionType + @""", 
            ""apiSchemaVersion"": """ + ApiSchemaVersion + @""",
            ""time"": ""2021-05-17T00:00:00.0000000Z"",
            ""eventListenerId"": ""10000000-0000-0000-0000-000000000001"",
            ""customExtensionId"": ""10000000-0000-0000-0000-000000000002"",
            ""context"": {
                ""correlationId"": ""20000000-0000-0000-0000-000000000002"",
                ""client"": { },
                ""authProtocol"": { },
                ""clientServicePrincipal"": { },
                ""resourceServicePrincipal"": { },
                ""user"": { },
                ""roles"": []
            }
        }";
        private const string WrongServicePrincipalNameDataJson = @"
        {
            ""type"": """ + ExtensionType + @""", 
            ""apiSchemaVersion"": """ + ApiSchemaVersion + @""",
            ""time"": ""2021-05-17T00:00:00.0000000Z"",
            ""eventListenerId"": ""10000000-0000-0000-0000-000000000001"",
            ""customExtensionId"": ""10000000-0000-0000-0000-000000000002"",
            ""context"": {
                ""clientServicePrincipal"": {
                    ""servicePrincipalNames"": []
                },
                ""resourceServicePrincipal"": {
                    ""servicePrincipalNames"": null
                }
            }
        }";
        private const string WrongUserAppRoleDataJson = @"
        {
            ""type"": """ + ExtensionType + @""", 
            ""apiSchemaVersion"": """ + ApiSchemaVersion + @""",
            ""time"": ""2021-05-17T00:00:00.0000000Z"",
            ""eventListenerId"": ""10000000-0000-0000-0000-000000000001"",
            ""customExtensionId"": ""10000000-0000-0000-0000-000000000002"",
            ""context"": {
                ""roles"": [ {}, {} ] 
            }
        }";
        private const string MinRequiredDataJson = @"
        {
            ""type"": """ + ExtensionType + @""", 
            ""apiSchemaVersion"": """ + ApiSchemaVersion + @""",
            ""time"": ""2021-05-17T00:00:00.0000000Z"",
            ""eventListenerId"": ""10000000-0000-0000-0000-000000000001"",
            ""customExtensionId"": ""10000000-0000-0000-0000-000000000002"",
            ""context"": {
                ""correlationId"": ""20000000-0000-0000-0000-000000000002"",
                ""client"": {
                    ""ip"": ""127.0.0.1""
                },
                ""authProtocol"": {
                    ""type"": ""OAUTH2.0"",
                    ""tenantId"": ""30000000-0000-0000-0000-000000000003""
                },
                ""clientServicePrincipal"": {
                    ""id"": ""40000000-0000-0000-0000-000000000001"",
                    ""appId"": ""40000000-0000-0000-0000-000000000002"",
                    ""appDisplayName"": ""Test client app"",
                    ""displayName"": ""Test client application"",
                    ""servicePrincipalNames"": [""40000000-0000-0000-0000-000000000002""]
                },
                ""resourceServicePrincipal"": {
                    ""id"": ""40000000-0000-0000-0000-000000000003"",
                    ""appId"": ""40000000-0000-0000-0000-000000000004"",
                    ""appDisplayName"": ""Test resource app"",
                    ""displayName"": ""Test resource application"",
                    ""servicePrincipalNames"": [""https://example.com/resource2""]
                },
                ""user"": {
                    ""id"": ""60000000-0000-0000-0000-000000000006"",
                    ""userPrincipalName"": ""testadmin@example.com""
                }
            }
        }";
        private const string FullDataJson = @"
        {
            ""type"": """ + ExtensionType + @""", 
            ""apiSchemaVersion"": """ + ApiSchemaVersion + @""",
            ""time"": ""2021-05-17T00:00:00.0000000Z"",
            ""eventListenerId"": ""10000000-0000-0000-0000-000000000001"",
            ""customExtensionId"": ""10000000-0000-0000-0000-000000000002"",
            ""context"": {
                ""correlationId"": ""20000000-0000-0000-0000-000000000002"",
                ""client"": {
                    ""ip"": ""127.0.0.1"",
                    ""locale"": ""en-us"",
                    ""market"": ""en-au""
                },
                ""authProtocol"": {
                    ""type"": ""OAUTH2.0"",
                    ""tenantId"": ""30000000-0000-0000-0000-000000000003""
                },
                ""clientServicePrincipal"": {
                    ""id"": ""40000000-0000-0000-0000-000000000001"",
                    ""appId"": ""40000000-0000-0000-0000-000000000002"",
                    ""appDisplayName"": ""Test client app"",
                    ""displayName"": ""Test client application"",
                    ""servicePrincipalNames"": [""40000000-0000-0000-0000-000000000002"", ""http://example.com/client/app1""]
                },
                ""resourceServicePrincipal"": {
                    ""id"": ""40000000-0000-0000-0000-000000000003"",
                    ""appId"": ""40000000-0000-0000-0000-000000000004"",
                    ""appDisplayName"": ""Test resource app"",
                    ""displayName"": ""Test resource application"",
                    ""servicePrincipalNames"": [""40000000-0000-0000-0000-000000000004"", ""https://example.com/resource2""]
                },
                ""roles"": [
                    {
                        ""id"": ""50000000-0000-0000-0000-000000000005"",
                        ""value"": ""DummyRole""
                    }
                ],
                ""user"": {
                    ""ageGroup"": ""Adult"",
                    ""companyName"": ""Evo Sts Test"",
                    ""country"": ""USA"",
                    ""createdDateTime"": ""0001-01-01T00:00:00Z"",
                    ""creationType"": ""Invitation"",
                    ""department"": ""Dummy department"",
                    ""displayName"": ""Dummy display name"",
                    ""givenName"": ""Example"",
                    ""id"": ""60000000-0000-0000-0000-000000000006"",
                    ""lastPasswordChangeDateTime"": ""0001-01-01T00:00:00Z"",
                    ""mail"": ""test@example.com"",
                    ""onPremisesSamAccountName"": ""testadmin"",
                    ""onPremisesSecurityIdentifier"": ""DummySID"",
                    ""onPremiseUserPrincipalName"": ""Dummy Name"",
                    ""preferredDataLocation"": ""DummyDataLocation"",
                    ""preferredLanguage"": ""DummyLanguage"",
                    ""surname"": ""Test"",
                    ""userPrincipalName"": ""testadmin@example.com"",
                    ""userType"": ""UserTypeCloudManaged""
                }
            }
        }";

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
                    new ValidationErrorTestData("#/time", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/eventListenerId", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/customExtensionId", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context", ValidationErrorKind.PropertyRequired)
                },
                ValidateNumberOfErrors = true
            },

            // Empty Context Test: Checks the root required context fields
            new TestScenario
            {
                TestName = "Empty Json Test: Checks the root required context fields",
                JsonPayload = EmptyContextDataJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/context.correlationId", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.client", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.authProtocol", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.clientServicePrincipal", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.resourceServicePrincipal", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.user", ValidationErrorKind.PropertyRequired)
                },
                ValidateNumberOfErrors = true
            },

            // Empty Sub-Context Test: Checks the root required sub context fields
            new TestScenario
            {
                TestName = "Empty Sub-Context Test: Checks the root required sub context fields",
                JsonPayload = EmptySubContextsDataJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/context.client.ip", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.authProtocol.type", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.authProtocol.tenantId", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.clientServicePrincipal.id", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.clientServicePrincipal.appId", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.clientServicePrincipal.appDisplayName", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.clientServicePrincipal.displayName", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.clientServicePrincipal.servicePrincipalNames", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.resourceServicePrincipal.id", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.resourceServicePrincipal.appId", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.resourceServicePrincipal.appDisplayName", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.resourceServicePrincipal.displayName", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.resourceServicePrincipal.servicePrincipalNames", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.user.id", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.user.userPrincipalName", ValidationErrorKind.PropertyRequired)
                },
                ValidateNumberOfErrors = true
            },

            // Wrong Service Principal Name Test: Checks service principal name has to be an array with at least 1 item
            new TestScenario
            {
                TestName = "Wrong Service Principal Name Test: Checks service principal name has to be an array with at least 1 item",
                JsonPayload = WrongServicePrincipalNameDataJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/context.clientServicePrincipal.servicePrincipalNames", ValidationErrorKind.TooFewItems),
                    new ValidationErrorTestData("#/context.resourceServicePrincipal.servicePrincipalNames", ValidationErrorKind.ArrayExpected)
                }
            },

            // Wrong User App Role Test: Checks the required fields for user app role are correct
            new TestScenario
            {
                TestName = "Wrong User App Role Test: Checks the required fields for user app role are correct",
                JsonPayload = WrongUserAppRoleDataJson,
                ExpectedErrors = new List<ValidationErrorTestData>()
                {
                    new ValidationErrorTestData("#/context.roles[0].id", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.roles[1].id", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.roles[0].value", ValidationErrorKind.PropertyRequired),
                    new ValidationErrorTestData("#/context.roles[1].value", ValidationErrorKind.PropertyRequired)
                }
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

            // Validate minimum required example JSON
            new TestScenario
            {
                TestName = "Validate minimum required example JSON",
                JsonPayload = MinRequiredDataJson,
                ValidateNumberOfErrors = true
            },

            // Validate full example JSON
            new TestScenario
            {
                TestName = "Validate full example JSON",
                JsonPayload = FullDataJson,
                ValidateNumberOfErrors = true
            }
        };

        /// <summary>Initializes a new instance of the <see cref="RequestSchemaValidationTests" /> class.</summary>
        /// <param name="testOutputHelper">The test output helper.</param>
        public RequestSchemaValidationTests(ITestOutputHelper testOutputHelper)
            : base(EventDefinition.TokenIssuanceStartV20211001Preview, TestSchemaType.Request, testOutputHelper)
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
        //[MemberData(nameof(GetSpecificTestData), 4)]
        public void TestResponseSchema(TestScenario scenario)
        {
            base.ValidateTestData(scenario);
        }
    }
}
