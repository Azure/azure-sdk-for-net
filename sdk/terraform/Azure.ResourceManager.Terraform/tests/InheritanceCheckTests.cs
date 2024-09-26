// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.ResourceManager.TestFramework
{
    public partial class InheritanceCheckTests
    {
        [OneTimeSetUp]
        public void SetExceptionList()
        {
            ExceptionList = new string[] { "ExportResource" };
        }
    }
}
