// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.IO;
using System.Linq;

namespace ManageServicePrincipalCredentials
{
    public class Program
    {
        /**
         * Azure Service Principal sample for managing Service Principal -
         *  - Create an Active Directory application
         *  - Create a Service Principal for the application and assign a role
         *  - Export the Service Principal to an authentication file
         *  - Use the file to list subcription virtual machines
         *  - Update the application 
         *  - Delete the application and Service Principal.
         */
        public static void RunSample(Azure.IAuthenticated authenticated, AzureEnvironment environment)
        {
            string spName = Utilities.CreateRandomName("sp");
            string appName = SdkContext.RandomResourceName("app", 20);
            string appUrl = "https://" + appName;
            string passwordName1 = SdkContext.RandomResourceName("password", 20);
            string password1 = "P@ssw0rd";
            string passwordName2 = SdkContext.RandomResourceName("password", 20);
            string password2 = "StrongP@ss!12";
            string certName1 = SdkContext.RandomResourceName("cert", 20);
            string raName = SdkContext.RandomGuid();
            string servicePrincipalId = "";
            try
            {

                // ============================================================
                // Create application

                Utilities.Log("Creating a service principal " + spName + "...");

                IServicePrincipal servicePrincipal = authenticated.ServicePrincipals
                        .Define(appName)
                        .WithNewApplication(appUrl)
                        .DefinePasswordCredential(passwordName1)
                            .WithPasswordValue(password1)
                            .Attach()
                        .DefinePasswordCredential(passwordName2)
                            .WithPasswordValue(password2)
                            .Attach()
                        .DefineCertificateCredential(certName1)
                            .WithAsymmetricX509Certificate()
                            .WithPublicKey(File.ReadAllBytes(Path.Combine(Utilities.ProjectPath, "Asset", "NetworkTestCertificate1.cer")))
                            .WithDuration(TimeSpan.FromDays(1))
                            .Attach()
                        .Create();

                Utilities.Log("Created service principal " + spName + ".");
                Utilities.Print(servicePrincipal);

                servicePrincipalId = servicePrincipal.Id;
                
                // ============================================================
                // Create role assignment

                Utilities.Log("Creating a Contributor role assignment " + raName + " for the service principal...");

                SdkContext.DelayProvider.Delay(15000);

                IRoleAssignment roleAssignment = authenticated.RoleAssignments
                        .Define(raName)
                        .ForServicePrincipal(servicePrincipal)
                        .WithBuiltInRole(BuiltInRole.Contributor)
                        .WithSubscriptionScope(authenticated.Subscriptions.List().First<ISubscription>().SubscriptionId)
                        .Create();

                Utilities.Log("Created role assignment " + raName + ".");
                Utilities.Print(roleAssignment);

                // ============================================================
                // Verify the credentials are valid

                Utilities.Log("Verifying password credential " + passwordName1 + " is valid...");

                AzureCredentials testCredential = new AzureCredentialsFactory().FromServicePrincipal(
                        servicePrincipal.ApplicationId, password1, authenticated.TenantId, environment);
                try
                {
                    Azure.Authenticate(testCredential).WithDefaultSubscription();

                    Utilities.Log("Verified " + passwordName1 + " is valid.");
                }
                catch (Exception e)
                {
                    Utilities.Log("Failed to verify " + passwordName1 + " is valid. Exception: " + e.Message);
                }

                Utilities.Log("Verifying password credential " + passwordName2 + " is valid...");

                testCredential = new AzureCredentialsFactory().FromServicePrincipal(
                        servicePrincipal.ApplicationId, password2, authenticated.TenantId, environment);
                try
                {
                    Azure.Authenticate(testCredential).WithDefaultSubscription();

                    Utilities.Log("Verified " + passwordName2 + " is valid.");
                }
                catch (Exception e)
                {
                    Utilities.Log("Failed to verify " + passwordName2 + " is valid. Exception: " + e.Message);
                }

                Utilities.Log("Verifying certificate credential " + certName1 + " is valid...");

                testCredential = new AzureCredentialsFactory().FromServicePrincipal(
                        servicePrincipal.ApplicationId,
                        Path.Combine(Utilities.ProjectPath, "Asset", "NetworkTestCertificate1.pfx"),
                        "Abc123",
                        authenticated.TenantId,
                        environment);
                try
                {
                    Azure.Authenticate(testCredential).WithDefaultSubscription();

                    Utilities.Log("Verified " + certName1 + " is valid.");
                }
                catch (Exception e)
                {
                    Utilities.Log("Failed to verify " + certName1 + " is valid. Exception: " + e.Message);
                }

                // ============================================================
                // Revoke access of the 1st password credential
                Utilities.Log("Revoking access for password credential " + passwordName1 + "...");

                servicePrincipal.Update()
                        .WithoutCredential(passwordName1)
                        .Apply();

                SdkContext.DelayProvider.Delay(15000);

                Utilities.Log("Credential revoked.");

                // ============================================================
                // Verify the revoked password credential is no longer valid

                Utilities.Log("Verifying password credential " + passwordName1 + " is revoked...");

                testCredential = new AzureCredentialsFactory().FromServicePrincipal(
                        servicePrincipal.ApplicationId, password1, authenticated.TenantId, environment);
                try
                {
                    Azure.Authenticate(testCredential).WithDefaultSubscription();

                    Utilities.Log("Failed to verify " + passwordName1 + " is revoked.");
                }
                catch (Exception e)
                {
                    Utilities.Log("Verified " + passwordName1 + " is revoked. Exception: " + e.Message);
                }

                // ============================================================
                // Revoke the role assignment

                Utilities.Log("Revoking role assignment " + raName + "...");

                authenticated.RoleAssignments.DeleteById(roleAssignment.Id);

                SdkContext.DelayProvider.Delay(5000);

                // ============================================================
                // Verify the revoked password credential is no longer valid

                Utilities.Log("Verifying password credential " + passwordName2 + " has no access to subscription...");

                testCredential = new AzureCredentialsFactory().FromServicePrincipal(
                        servicePrincipal.ApplicationId, password2, authenticated.TenantId, environment);
                try
                {
                    Azure.Authenticate(testCredential).WithDefaultSubscription()
                            .ResourceGroups.List();

                    Utilities.Log("Failed to verify " + passwordName2 + " has no access to subscription.");
                }
                catch (Exception e)
                {
                    Utilities.Log("Verified " + passwordName2 + " has no access to subscription. Exception: " + e.Message);
                }

            }
            catch (Exception f)
            {
                Utilities.Log(f.Message);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting application: " + appName);
                    authenticated.ServicePrincipals.DeleteById(servicePrincipalId);
                    Utilities.Log("Deleted application: " + appName);
                }
                catch (Exception e)
                {
                    Utilities.Log("Did not create applications in Azure. No clean up is necessary. Exception: " + e.Message);
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var authenticated = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials);

                RunSample(authenticated, credentials.Environment);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
