using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Used to de-serialize the Visual Studio token provider file. 
    /// </summary>
    [DataContract]
    internal class VisualStudioTokenProvider
    {
        [DataMember(Name = "Path", IsRequired = true)]
        public string Path;

        [DataMember(Name = "Arguments", IsRequired = false)]
        public List<string> Arguments;

        [DataMember(Name = "Preference", IsRequired = true)]
        public int Preference;
    }
}
