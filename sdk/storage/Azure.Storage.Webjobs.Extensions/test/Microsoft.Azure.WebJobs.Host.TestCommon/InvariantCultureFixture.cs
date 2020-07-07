// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Host.TestCommon
{
    public class InvariantCultureFixture : IDisposable
    {
        private readonly CultureInfo _originalCultureInfo;

        public InvariantCultureFixture()
        {
            _originalCultureInfo = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _originalCultureInfo;
        }
    }
}
