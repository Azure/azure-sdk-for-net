// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Test.Shared
{
    public abstract partial class StorageTestBase<TEnvironment> : RecordedTestBase<TEnvironment> where TEnvironment : StorageTestEnvironment, new()
    {
        [OneTimeSetUp]
        public void SetSasVersion()
        {
            if (Mode != RecordedTestMode.Live)
            {
                // WARN! Never ever override SAS version in Live mode. We should test the default there.

                // TODO Uncomment this to record/playback with different sas version
                SetSasVersion(StorageVersionExtensions.MaxVersion.ToString().Replace("V", "").Replace("_", "-"));
            }
        }

        private void SetSasVersion(string version)
        {
            // The SasQueryParametersInternals is shared source and compiled also into many assemblies which is technically separate class.
            // We're using reflection to set it everywhere.
            // The alternative of making it all open to all test packages isn't great because it would lead to name clash.
            SetSasVersionInAssemblies(version,
                "Azure.Storage.Common",
                "Azure.Storage.Blobs",
                "Azure.Storage.Files.DataLake",
                "Azure.Storage.Files.Shares",
                "Azure.Storage.Queues",
                "Azure.Storage.Blobs.DataMovmement");
        }

        private void SetSasVersionInAssemblies(string version, params string[] assemblyNames)
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => assemblyNames.Contains(a.GetName().Name));
            foreach (Assembly assembly in assemblies)
            {
                Type sasQueryParametersInternals = assembly.GetType("Azure.Storage.Sas.SasQueryParametersInternals");
                PropertyInfo defaultSasVersionInternal = sasQueryParametersInternals.GetProperty(
                    "DefaultSasVersionInternal", BindingFlags.NonPublic | BindingFlags.Static);
                defaultSasVersionInternal.SetValue(null, version);
            }
        }

        /// <summary>
        /// Gets a custom account SAS where the permissions, services and resourceType
        /// comes back in the string character order that the user inputs it as.
        ///
        /// e.g. If someone has the services (srt) value as "ocs", then in the
        /// sas token returned by this method will have the srt=osc and the
        /// string-to-sign will be signed with the services value as osc.
        ///
        /// This is custom because using the regular AccountSasBuilder does not accept
        /// a raw string services or resourceTypes, it accepts services and resourceTypes
        /// (e.g. see AccountSasPermissions, AccountSasServices, AccountSasResourceType).
        /// The order is fixed respective to what values is set.
        /// </summary>
        /// <param name="permissions"></param>
        /// <param name="services"></param>
        /// <param name="resourceType"></param>
        /// <param name="sharedKeyCredential"></param>
        /// <returns></returns>
        public virtual string GetCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default,
            StorageSharedKeyCredential sharedKeyCredential = default)
        {
            sharedKeyCredential ??= Tenants.GetNewSharedKeyCredentials();
            // We do not include 'i' in the default permissions due to immutability policy permissions
            // not being supported by HNS accounts
            permissions ??= "racwdlxyuptf";
            services ??= "bqtf";
            resourceType ??= "sco";

            // Generate a SAS that would set the srt / ResourceTypes in a different order than
            // the .NET SDK would normally create the SAS
            TestAccountSasBuilder accountSasBuilder = new TestAccountSasBuilder(
                permissions: permissions,
                expiresOn: Recording.UtcNow.AddDays(1),
                services: services,
                resourceTypes: resourceType);

            return accountSasBuilder.ToTestSasQueryParameters(sharedKeyCredential).ToString();
        }
    }
}
