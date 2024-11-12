// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.ResourceManager.TestFramework
{
    public partial class InheritanceCheckTests
    {
        [OneTimeSetUp]
        public void SetExceptionList()
        {
            ExceptionList = new string[] { "SignalRPrivateLinkResource" };
        }
    }
}
