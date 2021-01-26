// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.Rest.Azure;
using Xunit;

namespace Sql.Tests
{
    public class UploadTdeCertificateScenarioTests
    {
        private static readonly TdeCertificate TdeCertificate = new TdeCertificate()
        {
            PrivateBlob = RandomValidPrivateBlob,
            CertPassword = String.Empty
        };

        private static readonly TdeCertificate TdeCertificateWithInvalidBlob = new TdeCertificate()
        {
            PrivateBlob = InvalidPrivateBlob,
            CertPassword = String.Empty
        };

        private static readonly TdeCertificate TdeCertificateWithInvalidPassword = new TdeCertificate()
        {
            PrivateBlob = RandomValidPrivateBlob,
            CertPassword = InvalidPassword
        };

        private const string RandomValidPrivateBlob = @"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";
        private const string InvalidPrivateBlob = @"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";
        private const string ManagedInstanceResourceGroup = "MlAndzic_RG";
        private const string ManagedInstanceName = "midemoinstance";
        private const string InvalidPassword = "asdsadsad";
        private const string InvalidPrivateBlobOrPasswordMessage = "Invalid private blob or password";

        [Fact]
        public void TestCreateTdeCertificate()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                sqlClient.TdeCertificates.Create(resourceGroup.Name, server.Name, TdeCertificate);
            }
        }

        [Fact]
        public void TestCreateTdeCertificate_InvalidBlob()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                var exception = Assert.Throws<CloudException>(() => sqlClient.TdeCertificates.Create(resourceGroup.Name, server.Name, TdeCertificateWithInvalidBlob));

                Assert.Contains(InvalidPrivateBlobOrPasswordMessage, exception.Message);
            }
        }


        [Fact]
        public void TestCreateTdeCertificate_InvalidPassword()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                var exception = Assert.Throws<CloudException>(() => sqlClient.TdeCertificates.Create(resourceGroup.Name, server.Name, TdeCertificateWithInvalidPassword));

                Assert.Contains(InvalidPrivateBlobOrPasswordMessage, exception.Message);
            }
        }

        [Fact(Skip = "Manual test due to long setup time required")]
        public void TestCreateManagedInstanceTdeCertificate()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Update with values from a current MI on the region
                //
                string resourceGroup = ManagedInstanceResourceGroup;
                string managedInstanceName = ManagedInstanceName;

                sqlClient.ManagedInstanceTdeCertificates.Create(resourceGroup, managedInstanceName, TdeCertificate);
            }
        }


        [Fact(Skip = "Manual test due to long setup time required")]
        public void TestCreateManagedInstanceTdeCertificate_InvalidBlob()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Update with values from a current MI on the region
                //
                string resourceGroup = ManagedInstanceResourceGroup;
                string managedInstanceName = ManagedInstanceName;


                var exception = Assert.Throws<CloudException>(() => sqlClient.ManagedInstanceTdeCertificates.Create(resourceGroup, managedInstanceName, TdeCertificateWithInvalidBlob));

                Assert.Contains(InvalidPrivateBlobOrPasswordMessage, exception.Message);
            }
        }

        [Fact(Skip = "Manual test due to long setup time required")]
        public void TestCreateManagedInstanceTdeCertificate_InvalidPassword()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Update with values from a current MI on the region
                //
                string resourceGroup = ManagedInstanceResourceGroup;
                string managedInstanceName = ManagedInstanceName;


                var exception = Assert.Throws<CloudException>(() => sqlClient.ManagedInstanceTdeCertificates.Create(resourceGroup, managedInstanceName, TdeCertificateWithInvalidPassword));

                Assert.Contains(InvalidPrivateBlobOrPasswordMessage, exception.Message);
            }
        }

    }
}
