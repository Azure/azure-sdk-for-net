using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.Payloads
{
    internal class PayloadHelper
    {
        public static string GetPayload(string name)
        {
            var defaultNS = typeof(PayloadHelper).Namespace;
            return ReadResource(Assembly.GetExecutingAssembly(), string.Join(".", defaultNS, name));
        }

        private static string ReadResource(Assembly assembly, string resource, string defaultBody = null)
        {
            Stream stream = null;
            StreamReader reader = null;
            try
            {

                if (!assembly.GetManifestResourceNames().Any(x => x == resource))
                {
                    return defaultBody != null ? defaultBody : throw new Exception($"Payload {resource} not found");
                }
                stream = assembly.GetManifestResourceStream(resource);

                reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
                if (stream != null)
                {
                    stream.Close();
                    stream = null;
                }
            }
        }
    }
}
