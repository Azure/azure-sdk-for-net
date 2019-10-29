// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace TestFramework.Tests.TestEnvironment
{
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Xunit;

    /// <summary>
    /// Tests for ConnectionString parsing
    /// </summary>
    public class ConnectionStringParseTests
    {
        ConnectionString connStr;
        public ConnectionStringParseTests()
        {
            connStr = new ConnectionString();
        }

        [Fact]
        public void AllPossibleValueString()
        {
            //Legal Connection string
            string legalStr = CreateConnStrWithAllPossibleValues();
            ConnectionString cs = new ConnectionString(legalStr);
            cs.Parse(legalStr);
            foreach(KeyValuePair<string, string> kv in cs.KeyValuePairs)
            {
                Assert.NotEmpty(kv.Value);
            }

            Assert.True(string.IsNullOrEmpty(cs.ParseErrors));
        }

        [Fact]
        public void EmptyString()
        {
            // empty Connection string
            string emptyStr = @"";
            connStr.Parse(emptyStr);
            Assert.False(string.IsNullOrEmpty(connStr.ParseErrors));
        }

        [Fact]
        public void OptimizeRecordedFileKVPair()
        {
            string emptyStr = CreateConnStrWithAllPossibleValues();
            ConnectionString cs = new ConnectionString();
            cs.Parse(emptyStr);
            Assert.False(cs.GetValue<bool>(ConnectionStringKeys.OptimizeRecordedFileKey));

            cs.KeyValuePairs[ConnectionStringKeys.OptimizeRecordedFileKey] = "true";
            Assert.True(cs.GetValue<bool>(ConnectionStringKeys.OptimizeRecordedFileKey));
        }


        [Fact]
        public void NullString()
        {
            // null Connection string            
            connStr.Parse(null);
            Assert.False(string.IsNullOrEmpty(connStr.ParseErrors));
        }

        [Fact]
        public void NoKeyValueString()
        {
            // missingKeyValue Connection string
            string missingKeyValue = @";;;;;;;;;;;";
            connStr.Parse(missingKeyValue);            
            Assert.True(string.IsNullOrEmpty(connStr.ParseErrors));
        }
        
        [Fact]
        public void MalformedString()
        {
            // malformed Connection string
            string malformedStr = @"ServicePrincipal=helloworld;AADTenant=;=;userid=foo@foo.com";
            connStr.Parse(malformedStr);
            Assert.False(string.IsNullOrEmpty(connStr.ParseErrors));
        }

        [Fact]
        public void KeyValueWithEqualSignString()
        {
            //[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            string keyValWithEqualSign = @"ServicePrincipal=Hello;ServicePrincipalSecret=234ghyu=;Password=He====;UserId===========";
            ConnectionString cs = new ConnectionString(keyValWithEqualSign);
            Assert.Equal(string.Empty, connStr.ParseErrors);

            //We parse and store all keys lowercase to avoid casing issues
            Assert.NotEqual(string.Empty, cs.KeyValuePairs["ServicePrincipal".ToLower()]);
            Assert.NotEqual(string.Empty, cs.KeyValuePairs["ServicePrincipalSecret".ToLower()]);
            Assert.NotEqual(string.Empty, cs.KeyValuePairs["Password".ToLower()]);
            Assert.NotEqual(string.Empty, cs.KeyValuePairs["UserId".ToLower()]);
        }

        [Fact]
        public void ClientIdButNotSPN()
        {
            //[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            string clientIdButNoSPN = @"AADClientId=alsdkfjalakdsjflasdj;AADTenant=asdlkfjalsdkjflaksdj;Password=laksdjlfsd00980980=";
            connStr.Parse(clientIdButNoSPN);
            Assert.Equal(string.Empty, connStr.ParseErrors);

            Assert.NotEqual(string.Empty, connStr.KeyValuePairs["ServicePrincipal".ToLower()]);
            Assert.NotEqual(string.Empty, connStr.KeyValuePairs["ServicePrincipalSecret".ToLower()]);
        }

        [Fact]
        public void UserIdAndPasswordButNoSPNSecret()
        {
            //[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
            string clientIdButNoSPN = @"AADClientId=alsdkfjalakdsjflasdj;UserId=Hello@world.com;Password=laksdjlfsd00980980=";
            connStr.Parse(clientIdButNoSPN);
            Assert.Equal(string.Empty, connStr.ParseErrors);

            //ServicePrincipal will be updated with AADClientId
            Assert.NotEqual(string.Empty, connStr.KeyValuePairs["ServicePrincipal".ToLower()]);

            //As userId is non-empty, we cannot assume password is ServicePrincipalSecretKey and so will not be updated
            Assert.Equal(string.Empty, connStr.KeyValuePairs["ServicePrincipalSecret".ToLower()]);
        }

        [Fact]
        public void CustomKeyValuesInConnStr()
        {
            // This test will test if custome Key-Value pairs are honored.
            // Also if there are duplicate keys, it will pick the last occurance of the key, 
            // and will overwrite earlier instances of the same key

            string clientIdButNoSPN = @"MyKey=MyValue;MyKey=NewValue;CustomKey=CustomValue;AADClientId=alsdkfjalakdsjflasdj;UserId=Hello@world.com";
            connStr.Parse(clientIdButNoSPN);
            Assert.Equal(string.Empty, connStr.ParseErrors);

            //ServicePrincipal will be updated with AADClientId
            Assert.NotEqual(string.Empty, connStr.KeyValuePairs["ServicePrincipal"]);

            // Earlier instance of the same key will be overwritten
            Assert.NotEqual("MyValue", connStr.KeyValuePairs["MyKey"]);

            // last instance of the same key is retained
            Assert.Equal("NewValue", connStr.KeyValuePairs["MyKey"]);
            
            Assert.Equal("CustomValue", connStr.KeyValuePairs["CustomKey"]);
        }

        private string CreateConnStrWithAllPossibleValues()
        {
            string sampleUrl = "http://www.somefoo.com";
            string sampleStrValue = "34rghytukbnju7HelloWorld!!lkjdfuhgghj";
            string sampleNumericValue = "3476834rghh9876";

            ConnectionString cnnStr = new ConnectionString("");
            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<string, string> kv in cnnStr.KeyValuePairs)
            {
                if (kv.Key.ToLower().EndsWith("uri"))
                {
                    sb.AppendFormat("{0}={1};", kv.Key, sampleUrl);
                }
                else if (kv.Key.ToLower().EndsWith("id"))
                {
                    sb.AppendFormat("{0}={1};", kv.Key, sampleNumericValue);
                }
                else
                {
                    sb.AppendFormat("{0}={1};", kv.Key, sampleStrValue);
                }
            }

            return sb.ToString();
        }
    }
}
