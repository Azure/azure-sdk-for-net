using System;
using System.Text;

namespace Microsoft.Azure.ContainerRegistry
{
    /// <summary>
    ///  Helper methods for the Microsoft.Azure.ContainerRegistry Package
    /// </summary>
    internal class Helpers
    {
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            string returnValue = Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
}
