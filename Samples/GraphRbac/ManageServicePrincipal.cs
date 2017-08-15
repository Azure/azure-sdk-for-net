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

namespace ManageServicePrincipal
{
    public class Program
    {
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

                RunSample(authenticated);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }

        /**
         * Azure Service Principal sample for managing Service Principal -
         *  - Create an Active Directory application
         *  - Create a Service Principal for the application and assign a role
         *  - Export the Service Principal to an authentication file
         *  - Use the file to list subcription virtual machines
         *  - Update the application
         *  - Update the service principal to revoke the password credential and the role
         *  - Delete the Service Principal.
         */
        public static void RunSample(Azure.IAuthenticated authenticated)
        {
            string subscriptionId = authenticated.Subscriptions.List().First<ISubscription>().SubscriptionId;
            Utilities.Log("Selected subscription: " + subscriptionId);
            IActiveDirectoryApplication activeDirectoryApplication = null;
            string authFilePath = Path.Combine(Utilities.ProjectPath, "Asset", "mySamplAuthdFile.azureauth").ToString();
            try
            {
                activeDirectoryApplication = CreateActiveDirectoryApplication(authenticated);
                IServicePrincipal servicePrincipal = CreateServicePrincipalWithRoleForApplicationAndExportToFile(authenticated, activeDirectoryApplication, BuiltInRole.Contributor, subscriptionId, authFilePath);
                // Wait until Service Principal is ready
                SdkContext.DelayProvider.Delay(15);
                UseAuthFile(authFilePath);
                UpdateApplication(authenticated, activeDirectoryApplication);
                UpdateServicePrincipal(authenticated, servicePrincipal);
            }
            finally
            {
                Utilities.Log("Deleting Active Directory application and Service Principal...");
                if (activeDirectoryApplication != null)
                {
                    // this will delete Service Principal as well
                    authenticated.ActiveDirectoryApplications.DeleteById(activeDirectoryApplication.Id);
                }
            }
        }

        private static IActiveDirectoryApplication CreateActiveDirectoryApplication(Azure.IAuthenticated authenticated)
        {
            Utilities.Log("Creating Active Directory application...");
            var name = SdkContext.RandomResourceName("adapp-sample", 20);
            //create a self-sighed certificate
            var domainName = name + ".com";
            var certPassword = "StrongPass!12";
            Certificate certificate = Certificate.CreateSelfSigned(domainName, certPassword);

            // create Active Directory application
            var activeDirectoryApplication = authenticated.ActiveDirectoryApplications
                .Define(name)
                    .WithSignOnUrl("https://github.com/Azure/azure-sdk-for-java/" + name)
                    // password credentials definition
                    .DefinePasswordCredential("password")
                        .WithPasswordValue("P@ssw0rd")
                        .WithDuration(TimeSpan.FromDays(700))
                        .Attach()
                    // certificate credentials definition
                    .DefineCertificateCredential("cert")
                        .WithAsymmetricX509Certificate()
                        .WithPublicKey(File.ReadAllBytes(certificate.CerPath))
                        .WithDuration(TimeSpan.FromDays(100))
                        .Attach()
                    .Create();
            Utilities.Log(activeDirectoryApplication.Id + " - " + activeDirectoryApplication.ApplicationId);
            return activeDirectoryApplication;
        }

        private static IServicePrincipal CreateServicePrincipalWithRoleForApplicationAndExportToFile (
            Azure.IAuthenticated authenticated,
            IActiveDirectoryApplication activeDirectoryApplication,
            BuiltInRole role,
            string subscriptionId,
            string authFilePath)
        {
            Utilities.Log("Creating Service Principal...");
            string name = SdkContext.RandomResourceName("sp-sample", 20);
            //create a self-sighed certificate
            string domainName = name + ".com";
            string certPassword = "StrongPass!12";
            Certificate certificate = Certificate.CreateSelfSigned(domainName, certPassword);

            // create  a Service Principal and assign it to a subscription with the role Contributor
            return authenticated.ServicePrincipals
                    .Define("name")
                        .WithExistingApplication(activeDirectoryApplication)
                        // password credentials definition
                        .DefinePasswordCredential("ServicePrincipalAzureSample")
                            .WithPasswordValue("StrongPass!12")
                            .Attach()
                        // certificate credentials definition
                        .DefineCertificateCredential("spcert")
                            .WithAsymmetricX509Certificate()
                            .WithPublicKey(File.ReadAllBytes(certificate.CerPath))
                            .WithDuration(TimeSpan.FromDays(7))
                            // export the credentials to the file
                            .WithAuthFileToExport(new StreamWriter(new FileStream(authFilePath, FileMode.OpenOrCreate)))
                            .WithPrivateKeyFile(certificate.PfxPath)
                            .WithPrivateKeyPassword(certPassword)
                            .Attach()
                    .WithNewRoleInSubscription(role, subscriptionId)
                    .Create();
        }

        private static void UseAuthFile(string authFilePath)
        {
            Utilities.Log("Using auth file to list virtual machines...");
            // use just created auth file to sign in.
            var azure = Azure.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                .Authenticate(SdkContext.AzureCredentialsFactory.FromFile(authFilePath))
                .WithDefaultSubscription();
            // list virtualMachines, if any.
            var vmList = azure.VirtualMachines.List();
            foreach (var vm in vmList)
            {
                Utilities.PrintVirtualMachine(vm);
            }
        }

        private static void UpdateApplication(Azure.IAuthenticated authenticated, IActiveDirectoryApplication activeDirectoryApplication)
        {
            Utilities.Log("Updating Active Directory application...");
            activeDirectoryApplication.Update()
                    // add another password credentials
                    .DefinePasswordCredential("password-1")
                        .WithPasswordValue("P@ssw0rd-1")
                        .WithDuration(TimeSpan.FromDays(700))
                        .Attach()
                    // add a reply url
                    .WithReplyUrl("http://localhost:8080")
                    .Apply();
        }

        private static void UpdateServicePrincipal(Azure.IAuthenticated authenticated, IServicePrincipal servicePrincipal)
        {
            Utilities.Log("Updating Service Principal...");
            servicePrincipal.Update()
                    // add another password credentials
                    .WithoutCredential("ServicePrincipalAzureSample")
                    .WithoutRole(servicePrincipal.RoleAssignments.First())
                    .Apply();
        }

        private class Certificate
        {
            public string PfxPath
            {
                get;
                private set;
            }
            public string CerPath
            {
                get;
                private set;
            }

            public static Certificate CreateSelfSigned(string domainName, string password)
            {
                return new Certificate(domainName, password);
            }

            private Certificate(string domainName, string password)
            {
                string pfxName = domainName + ".pfx";
                string cerName = domainName + ".cer";

                PfxPath = Path.Combine(Utilities.ProjectPath, "Asset", pfxName);
                CerPath = Path.Combine(Utilities.ProjectPath, "Asset", cerName);

                Utilities.Log("Creating a self-signed certificate " + pfxName + " ...");
                Utilities.CreateCertificate(domainName, pfxName, cerName, password);
            }
        }
    }
}
