using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Azure.Services.AppAuthentication
{
    [DataContract]
    internal class VisualStudioTokenProviderFile
    {
        internal const string FormatExceptionMessage = "Visual Studio token provider file is not in the expected format.";

        public string FilePath;

        [DataMember(Name = "TokenProviders")]
        public List<VisualStudioTokenProvider> TokenProviders;

        public static VisualStudioTokenProviderFile Load(string filePath)
        {
            try
            {
                var fileContents = File.ReadAllText(filePath);
                var visualStudioTokenProviderFile = JsonHelper.Deserialize<VisualStudioTokenProviderFile>(Encoding.UTF8.GetBytes(fileContents));

                visualStudioTokenProviderFile.FilePath = filePath;

                // Order the providers, so that the latest one is tried first (lowest to highest values for preference)
                visualStudioTokenProviderFile.TokenProviders =
                    visualStudioTokenProviderFile.TokenProviders.OrderBy(p => p.Preference).ToList();

                return visualStudioTokenProviderFile;
            }
            catch (Exception exp)
            {
                throw new FormatException($"{FormatExceptionMessage} Exception Message: {exp.Message}");
            }
        }
    }
}
