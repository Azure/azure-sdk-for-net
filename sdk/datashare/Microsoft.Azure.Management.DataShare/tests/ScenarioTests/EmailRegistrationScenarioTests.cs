namespace DataShare.Tests.ScenarioTests
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.DataShare.Models;
    using Microsoft.Rest.Azure;
    using Xunit;
    using System.Collections.Generic;

    public class EmailRegistrationScenarioTests : ScenarioTestBase<EmailRegistrationScenarioTests>
    {
        internal static async Task<EmailRegistration> RegisterEmailAsync(
            DataShareManagementClient client,
            string location)
        {
            AzureOperationResponse<EmailRegistration> createResponse =
                await client.EmailRegistrations.RegisterEmailWithHttpMessagesAsync(location);

            EmailRegistrationScenarioTests.ValidateEmailRegistration(createResponse.Body, "john.smith@contoso.com", "ActivationPending", "15ee7153fe0df5a3a449a897d6cec836", "f686d426-8d16-42db-81b7-ab578e110ccd");
            Assert.Equal(HttpStatusCode.OK, createResponse.Response.StatusCode);

            return createResponse.Body;
        }

        private static void ValidateEmailRegistration(EmailRegistration actualEmailRegistration, string expectedEmail, string expectedRegistrationStatus, string expectedActivationCode, string expectedTenantId)
        {
            Assert.Equal(expectedEmail, actualEmailRegistration.Email);
            Assert.Equal(expectedRegistrationStatus, actualEmailRegistration.RegistrationStatus);
            Assert.Equal(expectedActivationCode, actualEmailRegistration.ActivationCode);
            Assert.Equal(expectedTenantId, actualEmailRegistration.TenantId);
        }

        internal static async Task ActivateEmailAsync(
            DataShareManagementClient client,
            string location,
            EmailRegistration emailRegistration)
        {
            AzureOperationResponse<EmailRegistration> activateResponse =
                await client.EmailRegistrations.ActivateEmailWithHttpMessagesAsync(
                    location,
                    emailRegistration,
                    null);

            EmailRegistrationScenarioTests.ValidateEmailRegistration(activateResponse.Body, "john.smith@contoso.com",
                "Activated", "15ee7153fe0df5a3a449a897d6cec836", "f686d426-8d16-42db-81b7-ab578e110ccd");

            Assert.Equal(HttpStatusCode.OK, activateResponse.Response.StatusCode);
        }
    }
}
