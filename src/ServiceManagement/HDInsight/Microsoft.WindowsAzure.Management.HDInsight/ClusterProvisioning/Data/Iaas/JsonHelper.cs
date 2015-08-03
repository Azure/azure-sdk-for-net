namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data
{
    using Newtonsoft.Json;

    internal static class JsonHelper
    {
        /// <summary>
        /// Encodes the input string so that it can be used in a Json string literal. This method will handle escaping special characters such as " to become \", etc.
        /// </summary>
        public static string EncodeStringForJson(string input)
        {
            // Use Json.Net to serialize the input string to Json, this essentially performs the necessary escaping and then add surrounding quotes.
            // e.g:
            //   abc => "abc"
            //   ab"c => "ab\"c"
            //   \abc\ => "\\abc\\"
            string output = JsonConvert.SerializeObject(input);

            output = output.Trim(new char[] { '"' });

            return output;
        }

        /// <summary>
        /// Encodes the input byte array as a Json string.
        /// </summary>
        public static string EncodeByteArrayForJson(byte[] data)
        {
            string output = JsonConvert.SerializeObject(data);
            
            output = output.Trim(new char[] { '"' });

            return output;
        }
    }
}
