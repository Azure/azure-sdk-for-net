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
                "Azure.Storage.Queues");
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
    }
}
