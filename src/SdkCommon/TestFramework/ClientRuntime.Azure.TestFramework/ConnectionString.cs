// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
        private Dictionary<string, string> _keyValuePairs;
        private string _connString;
        private StringBuilder _parseErrorSb;
        private string DEFAULT_TENANTID = "72f988bf-86f1-41af-91ab-2d7cd011db47";

        #endregion

        #region Properties

        private bool CheckViolation { get; set; }

        /// <summary>
        /// Represents key values pairs for the parsed connection string
        /// </summary>
        public Dictionary<string,string> KeyValuePairs
        {
            get
            {
                if(_keyValuePairs == null)
                {
                    _keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
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
                return _parseErrorSb.ToString();
            }

            private set
            {
                _parseErrorSb.AppendLine(value);
            }
        }

        #endregion

        #region Constructor/Init
        /// <summary>
        /// Initialize data
        /// </summary>
        void Init()
        {
            List<string> connectionKeyNames = new List<string>();
            connectionKeyNames = (from fi in typeof(ConnectionStringKeys)
                                               .GetFields(BindingFlags.Public | BindingFlags.Static)
                                               select fi.GetRawConstantValue().ToString()).ToList<string>();

            
            connectionKeyNames.ForEach((li) => KeyValuePairs.Add(li, string.Empty));
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ConnectionString()
        {
            Init();
            _parseErrorSb = new StringBuilder();
        }

        /// <summary>
        /// Initialize Connection string object using provided connectionString
        /// </summary>
        /// <param name="connString">Semicolon separated KeyValue pair connection string</param>
        public ConnectionString(string connString) : this()
        {
            _connString = connString;
            Parse(_connString); //Keyvalue pairs are normalized and is called from Parse(string) function
            NormalizeKeyValuePairs();
        }
#endregion

#region private
        /// <summary>
        /// Update values to either default values or normalize values across key/value pairs
        /// For e.g. If ServicePrincipal is provided and password is provided, we assume password is ServicePrincipalSecret
        /// </summary>
        private void NormalizeKeyValuePairs()
        {
            string clientId, spn, password, spnSecret, userId, aadTenantId;
            KeyValuePairs.TryGetValue(ConnectionStringKeys.AADClientIdKey, out clientId);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalKey, out spn);

            KeyValuePairs.TryGetValue(ConnectionStringKeys.UserIdKey, out userId);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.PasswordKey, out password);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalSecretKey, out spnSecret);
            KeyValuePairs.TryGetValue(ConnectionStringKeys.AADTenantKey, out aadTenantId);

            //ClientId was provided and servicePrincipal was empty, we want ServicePrincipal to be initialized
            //At some point we will deprecate ClientId keyName
            if (!string.IsNullOrEmpty(clientId) && (string.IsNullOrEmpty(spn)))
            {
                KeyValuePairs[ConnectionStringKeys.ServicePrincipalKey] = clientId;
            }

            //Set the value of PasswordKey to ServicePrincipalSecret ONLY if userId is empty
            //If UserId is not empty, we are not sure if it's a password for inter active login or ServicePrincipal SecretKey
            if (!string.IsNullOrEmpty(password) && (string.IsNullOrEmpty(spnSecret)) && (string.IsNullOrEmpty(userId)))
            {
                KeyValuePairs[ConnectionStringKeys.ServicePrincipalSecretKey] = password;
            }
            
            //Initialize default value for AADTenent
            if(string.IsNullOrEmpty(aadTenantId))
            {
                KeyValuePairs[ConnectionStringKeys.AADTenantKey] = DEFAULT_TENANTID;
            }
        }

        /// <summary>
        /// Detect any connection string violations
        /// </summary>
        private void DetectViolations()
        {
            //So far only 1 violation is being checked
            //We should also check if a supported Environment is provided in connection string (but seems we do not throw exception for unsupported environment)
            bool envSet = IsEnvironmentSet();
            string nonEmptyUriKey = FirstNonNullUriInConnectionString();

            if(envSet)
            {
                if(!string.IsNullOrEmpty(nonEmptyUriKey))
                {
                    string envName = KeyValuePairs[ConnectionStringKeys.EnvironmentKey];
                    string uriKeyValue = KeyValuePairs[nonEmptyUriKey];
                    string envAndUriConflictError = string.Format("Connection string contains Environment "+
                        "'{0}' and '{1}={2}'. Any Uri and environment cannot co-exist. "+
                        "Either set any environment or provide Uris", envName, nonEmptyUriKey, uriKeyValue);
                    throw new ArgumentException(envAndUriConflictError);
                }
            }
        }

        /// <summary>
        /// Find if any of the URI values has been set in the connection string
        /// </summary>
        /// <returns>First non empty URI value</returns>
        private string FirstNonNullUriInConnectionString()
        {
            string nonEmptyUriKeyName = string.Empty;
            var nonEmptyUriList = KeyValuePairs.Where(item =>
            {
                return ((item.Key.Contains("uri") || 
                        (item.Key.Equals(ConnectionStringKeys.AADAuthUriKey))) && (!string.IsNullOrEmpty(item.Value)));
            });
            
            if(nonEmptyUriList.IsAny<KeyValuePair<string,string>>())
            {
                nonEmptyUriKeyName = nonEmptyUriList.FirstOrDefault().Key;
            }

            return nonEmptyUriKeyName;
        }

        /// <summary>
        /// Detects if Environment was set in the connection string
        /// </summary>
        /// <returns>True: If valid environment was set. False:If environment was empty or invalid</returns>
        private bool IsEnvironmentSet()
        {
            bool envSet = false;            
            string envNameString = KeyValuePairs[ConnectionStringKeys.EnvironmentKey];
            if (!string.IsNullOrEmpty(envNameString))
            {
                EnvironmentNames envName;
                if (!Enum.TryParse<EnvironmentNames>(envNameString, out envName))
                {
                    string envError = string.Format("Environment '{0}' is not valid. Possible values:'{1}'", envNameString, envName.ListValues());
                    ParseErrors = envError;
                    throw new ArgumentException(envError);
                }

                envSet = !string.IsNullOrEmpty(envName.ToString());
            }

            return envSet;
        }
        
        internal bool HasNonEmptyValue(string connStrKey)
        {
            string keyValue = string.Empty;
            KeyValuePairs.TryGetValue(connStrKey, out keyValue);

            if (string.IsNullOrEmpty(keyValue)) return false;

            return true;
        }

#endregion

#region Public Functions
        /// <summary>
        /// Parses connection string
        /// </summary>
        /// <param name="connString">Semicolon delimented KeyValue pair(e.g. KeyName1=value1;KeyName2=value2;KeyName3=value3)</param>
        public void Parse(string connString)
        {
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

                KeyValuePairs.Clear(clearValuesOnly: true);
                foreach (string pair in pairs)
                {
                    Match m = Regex.Match(pair, parseRegEx);

                    if (m.Groups.Count > 2)
                    {
                        string keyName = m.Groups["KeyName"].Value;
                        string newValue = m.Groups["KeyValue"].Value;

                        if (KeyValuePairs.ContainsKey(keyName))
                        {
                            string existingValue = KeyValuePairs[keyName];
                            // Replace if the existing value do not match.
                            // We allow existing key values to be overwritten (this is especially true for endpoints)
                            if (!existingValue.Equals(newValue, StringComparison.OrdinalIgnoreCase))
                            {
                                KeyValuePairs[keyName] = newValue;
                            }
                        }
                        else
                        {
                            KeyValuePairs[keyName] = newValue;
                        }
                    }
                    else
                    {
                        ParseErrors = string.Format("Incorrect '{0}' keyValue pair format", pair);
                    }
                }

                //Adjust key-value pairs and normalize values across multiple keys
                //We need to do this here because Connection string can be parsed multiple time within same instance
                NormalizeKeyValuePairs();
            }
        }

        /// <summary>
        /// Returns value for the key set in the connection string
        /// </summary>
        /// <param name="keyName">KeyName set in connection string</param>
        /// <returns>Value for the key provided</returns>
        internal string GetValue(string keyName)
        {
            return KeyValuePairs[keyName];
        }

        /// <summary>
        /// Return value for the key set in the connection string
        /// </summary>
        /// <typeparam name="T">Datatype of the value that you want it to be returned. Will return default value of data type if exception occurs</typeparam>
        /// <param name="keyName">KeyName</param>
        /// <returns></returns>
        public T GetValue<T>(string keyName)
        {
            Type tType = typeof(T);
            T returnValue = default(T);
            object changedValue = null;
            try
            {
                string keyValue = GetValue(keyName);
                changedValue = Convert.ChangeType(keyValue, tType);
                returnValue = (T)changedValue;
            }
            catch { }

            return returnValue;
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
}
