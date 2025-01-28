// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace TestProjects.CadlRanch.Tests
{
    [SetUpFixture]
    public static class AssemblyCleanFixture
    {
        [OneTimeTearDown]
        public static void RunOnAssemblyCleanUp()
        {
            CadlRanchServerSession.Start().Server?.Dispose();
        }
    }
}
