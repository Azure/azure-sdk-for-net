// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Storage.Sas;
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
                // SasQueryParametersInternals.DefaultSasVersionInternal = "2020-08-04";
            }
        }
    }
}
