// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Microsoft.Azure.KeyVault.Cryptography.Tests
{
    public class TestFixture : IDisposable
    {
        private bool _initialized = false;

        public TestFixture()
        { }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            // Clean up managed resources if Dispose was called
            if ( disposing )
            {
                if ( _initialized )
                {
                }
            }
        }
    }
}
