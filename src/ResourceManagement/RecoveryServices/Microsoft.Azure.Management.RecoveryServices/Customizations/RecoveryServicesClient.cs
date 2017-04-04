using System.Linq;
using System.Net.Http;
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Management.RecoveryServices
{
    public partial class RecoveryServicesClient
    {
        partial void CustomInitialize()
        {
            var iso8601TimeSpanConverter = DeserializationSettings.Converters.First(conv => conv is Iso8601TimeSpanConverter);
            if (iso8601TimeSpanConverter != null)
            {
                DeserializationSettings.Converters.Remove(iso8601TimeSpanConverter);
            }
        }
    }
}