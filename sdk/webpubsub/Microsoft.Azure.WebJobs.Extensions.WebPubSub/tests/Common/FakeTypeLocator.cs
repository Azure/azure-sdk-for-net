using System;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    internal class FakeTypeLocator
    {
        private Type type;

        public FakeTypeLocator(Type type)
        {
            this.type = type;
        }
    }
}