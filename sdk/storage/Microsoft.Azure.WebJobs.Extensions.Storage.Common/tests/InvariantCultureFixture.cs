// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
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
            GC.SuppressFinalize(this);
        }
    }
}
