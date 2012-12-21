using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Storage
{
    public interface ICancellableAsyncResult : IAsyncResult
    {
        void Cancel();
    }
}
