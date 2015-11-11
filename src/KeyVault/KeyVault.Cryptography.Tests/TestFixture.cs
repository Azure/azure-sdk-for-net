
using System;

namespace KeyVault.Cryptography.Tests
{
    public class TestFixture : IDisposable
    {
        private bool initialized = false;

        public TestFixture()
        { }

        public void Initialize( string className )
        {
            if ( initialized )
                return;

            initialized = true;
        }

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
                if ( initialized )
                {
                }

                initialized = false;
            }
        }
    }
}
