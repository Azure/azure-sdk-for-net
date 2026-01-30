// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace TestProjects.Spector.Tests
{
    [SetUpFixture]
    public static class AssemblyCleanFixture
    {
        [OneTimeTearDown]
        public static void RunOnAssemblyCleanUp()
        {
            SpectorServerSession.Start().Server?.Dispose();
        }
    }
}
