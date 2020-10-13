// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.WebJobs.Extensions.Storage.Common.Tests;
using NUnit.Framework;

// This class is without namespace on purpose, to make sure it runs once per test assembly regardless of how tests are packaged.
// It must be compiled into test assembly in order to work. Therefore using shared sources or making a copy is necessary.
[SetUpFixture]
public class AzuriteNUnitFixture
{
    public static AzuriteFixture Instance { get; private set; }

    [OneTimeSetUp]
    public void SetUp()
    {
        Instance = new AzuriteFixture();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Instance.Dispose();
    }
}
