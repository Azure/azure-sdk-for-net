using System.Runtime.InteropServices;
using Xunit;

namespace Microsoft.Azure.Services.AppAuthentication.IntegrationTests
{
    internal sealed class RunOnWindowsFactAttribute : FactAttribute
    {
        public RunOnWindowsFactAttribute()
        {
#if netstandard14
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Skip = "Ignored if not run on Windows";
            }
#endif
        }
    }
}
