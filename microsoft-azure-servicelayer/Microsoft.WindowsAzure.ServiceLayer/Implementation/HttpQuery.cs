using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.Implementation
{
    /// <summary>
    /// Helper class for processing HTTP query strings.
    /// </summary>
    class HttpQuery
    {
        Dictionary<string, string> _values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="queryString">Query string</param>
        internal HttpQuery(string queryString)
        {
            string[] pairs = queryString.Split('&');

            foreach (string pair in pairs)
            {
                int pos = pair.IndexOf('=');
                string name = pair.Substring(0, pos);
                string value = pair.Substring(pos + 1);
                _values.Add(name, value);
            }
        }

        /// <summary>
        /// Gets parameter by name.
        /// </summary>
        /// <param name="parameterName">Parameter name</param>
        /// <returns>Parameter value</returns>
        internal string this[string parameterName] { get { return _values[parameterName]; } }
    }
}
