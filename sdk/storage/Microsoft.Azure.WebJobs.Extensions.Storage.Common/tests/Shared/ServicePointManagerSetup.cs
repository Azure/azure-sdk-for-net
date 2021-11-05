// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading;
using NUnit.Framework;

// This class is without namespace on purpose, to make sure it runs once per test assembly regardless of how tests are packaged.
// It must be compiled into test assembly in order to work. Therefore using shared sources or making a copy is necessary.
[SetUpFixture]
public class ServicePointManagerSetup
{
    [OneTimeSetUp]
    public void SetUp()
    {
#if !NETCOREAPP
        ServicePointManager.DefaultConnectionLimit = 50;
#endif
    }
}
