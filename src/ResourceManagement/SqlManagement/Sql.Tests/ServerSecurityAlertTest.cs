using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Server security alert policy
    /// </summary>
    public class ServerSecurityAlertTest
    {
        [Fact]
        public void TestServerSecurityAlertApis()
        {
            string testPrefix = "server-security-alert-test-";
            string testName = this.GetType().FullName;
            const int retriesCount = 5;
            const int databasesCount = 12;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestServerSecurityAlert", testPrefix,
                 (resClient, sqlClient, resourceGroup, server) =>
                 {
                     //create server with a lot of databases
                     for (int i = 0; i < databasesCount; i++)
                     {
                         string dbName = string.Format("db{0}", i);
                         sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                         {
                             Location = server.Location,
                         });
                     }

                     ServerSecurityAlertPolicy defaultServerPolicyResponse = sqlClient.ServerThreatDetectionPolicies.Get(resourceGroup.Name, server.Name);

                     // Verify that the initial Get request contains the default policy.
                     VerifySecurityAlertPolicyInformation(GetDefaultSecurityAlertProperties(), defaultServerPolicyResponse);

                     // Modify the policy properties, send and receive and see it its still ok
                     ServerSecurityAlertPolicy updatedServerPolicy = new ServerSecurityAlertPolicy
                     {
                         State = SecurityAlertPolicyState.Enabled,
                         EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled,
                         EmailAddresses = "testSecurityAlert@microsoft.com;testServerPolicy@microsoft.com",
                         DisabledAlerts = "Sql_Injection",
                         RetentionDays = 3,
                         StorageAccountAccessKey = "sdlfkjabc+sdlfkjsdlkfsjdfLDKFTERLKFDFKLjsdfksjdflsdkfD2342309432849328476458/3RSD==",
                         StorageEndpoint = "https://MyAccount.blob.core.windows.net/",
                     };

                     //Set security alert policy for server
                     sqlClient.ServerThreatDetectionPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, updatedServerPolicy);
                     //Waiting for the operation to start
                     Task.Delay(TimeSpan.FromSeconds(2));

                     SecurityAlertOperationListResult operationResults = sqlClient.ServerThreatDetectionPolicies.ListOperationResults(resourceGroup.Name, server.Name);
                     if (operationResults != null && operationResults.Value.Any())
                     {
                         //The set policy operation has not finished yet
                         SecurityAlertOperationResult operationStatusResponse = operationResults.Value.First();
                         string operationId = operationStatusResponse.OperationId;
                         for (int i = 0; i < retriesCount; i++)
                         {
                             operationStatusResponse = sqlClient.ServerThreatDetectionPolicies.GetOperationResult(
                                     resourceGroup.Name, server.Name, operationId);
                             if (operationStatusResponse != null && operationStatusResponse.State == SecurityConstants.c_SucceededOperationStatus)
                             {
                                 //set operation has finished
                                 break;
                             }
                             Task.Delay(TimeSpan.FromSeconds(5));
                         }
                     }

                     //Get security alert server policy
                     var getUpdatedPolicyResponse = sqlClient.ServerThreatDetectionPolicies.Get(resourceGroup.Name, server.Name);
                     // Verify that the Get request contains the updated policy.
                     VerifySecurityAlertPolicyInformation(updatedServerPolicy, getUpdatedPolicyResponse);
                 });
        }


        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private void VerifySecurityAlertPolicyInformation(ServerSecurityAlertPolicy expected, ServerSecurityAlertPolicy actual)
        {
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.EmailAccountAdmins, actual.EmailAccountAdmins);
            Assert.Equal(expected.DisabledAlerts, actual.DisabledAlerts);
            Assert.Equal(expected.EmailAddresses, actual.EmailAddresses);
            Assert.Equal(expected.StorageEndpoint, actual.StorageEndpoint);
            Assert.Equal(string.Empty, actual.StorageAccountAccessKey);
            Assert.Equal(expected.RetentionDays, actual.RetentionDays);
        }

        /// <summary>
        /// Returns a ServerSecurityAlertPolicy object that holds the default settings for a server security alert policy
        /// </summary>
        /// <returns>A ServerSecurityAlertPolicy object with the default server security alert policy settings</returns>
        private ServerSecurityAlertPolicy GetDefaultSecurityAlertProperties()
        {
            ServerSecurityAlertPolicy properties = new ServerSecurityAlertPolicy
            {
                State = SecurityAlertPolicyState.New,
                EmailAccountAdmins = SecurityAlertPolicyEmailAccountAdmins.Enabled,
                DisabledAlerts = SecurityAlert.Preview,
                EmailAddresses = string.Empty,
                StorageEndpoint = string.Empty,
                StorageAccountAccessKey = string.Empty,
                RetentionDays = 0,
            };

            return properties;
        }
    }
}
