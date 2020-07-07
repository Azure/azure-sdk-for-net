// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class NullInstanceFactory<TReflected> : IJobInstanceFactory<TReflected>
    {
        private NullInstanceFactory()
        {
        }

        public static NullInstanceFactory<TReflected> Instance { get; } = new NullInstanceFactory<TReflected>();

        public TReflected Create(IFunctionInstanceEx functionInstance)
        {
            return default(TReflected);
        }
    }
}
