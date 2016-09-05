namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This class represents the connection string being set by the user
    /// e.g. TEST_CSM_ORGID_AUTHENTICATION="AADTenant=72f98AAD-86f1-2d7cd011db47;ServicePrincipal=72f98AAD-86f1-2d7cd011db47;Password=tzT2+LJBRkSAursui7/Qgo+hyQQ=;SubscriptionId=5562fbd2-HHHH-WWWW-a55d-lkjsldkjf;BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/;GraphUri=https://graph.windows.net/"
    /// </summary>
    public class ConnectionString
    {
        #region fields
        Dictionary<string, string> _keyValuePairs;
        string _connString;
        StringBuilder _parseErrorSb;
        #endregion

        #region Properties

        /// <summary>
        /// Represents key values pairs for the parsed connection string
        /// </summary>
        public Dictionary<string,string> KeyValuePairs
        {
            get
            {
                if(_keyValuePairs == null)
                {
                    _keyValuePairs = new Dictionary<string, string>();
                }
                return _keyValuePairs;
            }
            private set
            {
                _keyValuePairs = value;
            }
        }
        
        /// <summary>
        /// Returns all the parse errors while parsing connection string
        /// </summary>
        public string ParseErrors
        {
            get
            {
                if(_parseErrorSb == null)
                {
                    _parseErrorSb = new StringBuilder();                    
                }
                return _parseErrorSb.ToString();
            }

            private set
            {
                if (_parseErrorSb == null)
                {
                    _parseErrorSb = new StringBuilder();
                    _parseErrorSb.AppendLine(value);
                }
                else
                    _parseErrorSb.AppendLine(value);
            }
        }

        #endregion

        #region Constructor/Init
        void Init()
        {
            List<string> connectionKeyNames = (from fi in typeof(ConnectionStringKeys).GetFields(BindingFlags.Public | BindingFlags.Static) select fi.GetRawConstantValue().ToString()).ToList<string>();
            connectionKeyNames.ForEach((li) => KeyValuePairs.Add(li.ToLower(), string.Empty));
        }
        
        /// <summary>
        /// 
        /// </summary>
        public ConnectionString()
        {
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString">Semicolon separated KeyValue pair connection string</param>
        public ConnectionString(string connString) : this()
        {
            _connString = connString;
            Parse();
        }
        #endregion

        #region private
        /// <summary>
        /// Update values for ServicePrincipal/ServicePrincipalSecret values
        /// </summary>
        private void NormalizeKeyValuePairs()
        {
            string clientId, spn, password, spnSecret, userId;
            KeyValuePairs.TryGetValue(ConnectionStringKeys.AADClientIdKey.ToLower(), out clientId);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalKey.ToLower(), out spn);

            KeyValuePairs.TryGetValue(ConnectionStringKeys.UserIdKey.ToLower(), out userId);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.PasswordKey.ToLower(), out password);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalSecretKey.ToLower(), out spnSecret);            

            //ClientId was provided and servicePrincipal was empty, we want ServicePrincipal to be initialized
            //At some point we will deprecate ClientId keyName
            if (!string.IsNullOrEmpty(clientId) && (string.IsNullOrEmpty(spn)))
            {
                KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey.ToLower()] = clientId;
            }

            //Set the value of PasswordKey to ServicePrincipalSecret ONLY if userId is empty
            //If UserId is not empty, we are not sure if it's a password for inter active login or ServicePrincipal SecretKey
            if (!string.IsNullOrEmpty(password) && (string.IsNullOrEmpty(spnSecret)) && (string.IsNullOrEmpty(userId)))
            {
                KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey.ToLower()] = password;
            }
            
        }

        /// <summary>
        /// Parse connection string provided to constructor
        /// </summary>
        private void Parse()
        {
            Parse(_connString);
        }
        #endregion

        #region Public Functions
        /// <summary>
        /// Parses connection string
        /// </summary>
        /// <param name="connString">Semicolon delimented KeyValue pair(e.g. KeyName1=value1;KeyName2=value2;KeyName3=value3)</param>
        public void Parse(string connString)
        {
            string keyName;
            string parseRegEx = @"(?<KeyName>[^=]+)=(?<KeyValue>.+)";

            if (_parseErrorSb != null) _parseErrorSb.Clear();

            if (string.IsNullOrEmpty(connString))
            {
                ParseErrors = "Empty connection string";
            }
            else
            {
                string[] pairs = connString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (pairs == null) ParseErrors = string.Format("'{0}' unable to parse string", connString);

                //TODO: Shall we clear keyValue dictionary?
                //What if parsed gets called on the same instance multiple times
                //the connectionString is either malformed/invalid
                //For now clearing keyValue dictionary, we assume the caller wants to parse new connection string
                //and wants to discard old values (even if they are valid)

                KeyValuePairs.Clear(true);
                foreach (string pair in pairs)
                {
                    Match m = Regex.Match(pair, parseRegEx);

                    if (m.Groups.Count > 2)
                    {
                        keyName = m.Groups["KeyName"].Value.ToLower();
                        if (KeyValuePairs.ContainsKey(keyName))
                        {
                            KeyValuePairs[keyName] = m.Groups["KeyValue"].Value;
                        }
                        else
                        {
                            ParseErrors = string.Format("'{0}' invalid keyname", keyName);
                        }
                    }
                    else
                    {
                        ParseErrors = string.Format("Incorrect '{0}' keyValue pair format", pair);
                    }
                }

                //Normalize AADClientId/ServicePrincipal AND Password/ServicePrincipalSecret
                NormalizeKeyValuePairs();
            }
        }
        
        /// <summary>
        /// Returns conneciton string
        /// </summary>
        /// <returns>ConnectionString</returns>
        public override string ToString()
        {
            return _connString;
        }

        #endregion
    }

    /// <summary>
    /// Extension method class
    /// </summary>
    public static class ExtMethods
    {
        /// <summary>
        /// Allows you to clear only values or key/value both
        /// </summary>
        /// <param name="dictionary">Dictionary<string,string> that to be cleared</param>
        /// <param name="clearValuesOnly">True: Clears only values, False: Clear keys and values</param>
        public static void Clear(this Dictionary<string, string> dictionary, bool clearValuesOnly)
        {
            //TODO: can be implemented for generic dictionary, but currently there is no requirement, else the overload
            //will be reflected for the entire solution for any kind of Dictionary, so currently only scoping to Dictionary<string,string>
            if (clearValuesOnly)
            {
                foreach (string key in dictionary.Keys.ToList<string>())
                {
                    dictionary[key] = string.Empty;
                }
            }
            else
            {
                dictionary.Clear();
            }
        }
    }
}
