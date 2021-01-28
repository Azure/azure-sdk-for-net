// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
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
        Instance = InitializeAzuriteWithRetry(2);
    }

    private AzuriteFixture InitializeAzuriteWithRetry(int numberOfTries)
    {
        List<Exception> exceptions = null;
        for (int i = 0; i<numberOfTries; i++)
        {
            try
            {
                return new AzuriteFixture();
            } catch (Exception e)
            {
                exceptions ??= new List<Exception>();
                exceptions.Add(e);
            }
        }
        throw new AggregateException(exceptions);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Instance?.Dispose();
    }
}
