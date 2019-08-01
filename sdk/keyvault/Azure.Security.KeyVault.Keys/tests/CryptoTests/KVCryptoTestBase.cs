// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Security.KeyVault.Cryptography.Tests
{
    using Azure.Core.Testing;
    using Azure.Identity;
    using Azure.Security.KeyVault.Cryptography.Client;
    using Azure.Security.KeyVault.Cryptography.Tests.Utilities;
    using Azure.Security.KeyVault.Keys;
    using Azure.Security.KeyVault.Keys.Tests;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CryptoTestBase : KeysTestBase
    {
        #region const
        protected const string KV_DNS_URI_ENV_VARIABLE = "AZURE_KEYVAULT_URL";
        protected const string TEST_MODE_ENV_VARIABLE = "AZURE_TEST_MODE";
        #endregion

        #region fields
        Uri _kvVaultUri;
        //KeyClient _kvKeyClient;
        //CryptographyClient _kvCryptoClient;
        Core.TokenCredential _creds;
        #endregion

        #region Properties
        Queue<(KeyBase Key, bool DeleteKey)> TestcaseKeysQueue { get; set; }

        Core.TokenCredential Creds
        {
            get
            {
                if(_creds == null)
                {
                    _creds = Recording.GetCredential(new DefaultAzureCredential());
                }

                return _creds;
            }
        }

        public KeyClient KVKeyClient
        {
            get
            {
                return Client;
            }
        }

        //public KeyClient KVKeyClient
        //{
        //    get
        //    {
        //        if(_kvKeyClient == null)
        //        {
        //            //Creds = Recording.GetCredential(new DefaultAzureCredential());
        //            KeyClientOptions opts = Recording.InstrumentClientOptions<KeyClientOptions>(new KeyClientOptions());
        //            var kc = new KeyClient(KVVaultUri, Creds, opts);
        //            _kvKeyClient = InstrumentClient<KeyClient>(kc);
        //            //CheckUtility.NotNull(_kvKeyClient, nameof(_kvKeyClient));
        //            Assert.IsNotNull(_kvKeyClient);
        //        }

        //        return _kvKeyClient;
        //    }
        //}

        public CryptographyClient KVCryptoClient { get; set; }
        

        public Uri KVVaultUri
        {
            get
            {
                if(_kvVaultUri == null)
                {
                    string vaultUri = Recording.GetVariableFromEnvironment(KV_DNS_URI_ENV_VARIABLE);
                    CheckUtility.NotEmptyNotNull(vaultUri, nameof(vaultUri));
                    _kvVaultUri = new Uri(vaultUri);
                }

                return _kvVaultUri;
            }
        }
        #endregion

        #region Constructor
        public CryptoTestBase(bool isAsync) : base(isAsync)
        {
            TestcaseKeysQueue = new Queue<(KeyBase key, bool deleteKey)>();
        }
        #endregion

        #region Public Functions

        protected void InitCryptoClient(Key kvKey)
        {
            KVCryptoClient = new CryptographyClient(kvKey, Creds);
        }

        protected virtual void TestInit()
        {

        }

        public override void StartTestRecording()
        {
            TestInit();
            base.StartTestRecording();
        }

        #region Verify
        protected void VerifyKeysEqual(Key exp, Key act)
        {
            VerifyKeyMaterialEqual(exp.KeyMaterial, act.KeyMaterial);
            VerifyKeysEqual((KeyBase)exp, (KeyBase)act);
        }

        protected void VerifyKeysEqual(KeyBase exp, KeyBase act)
        {
            Assert.AreEqual(exp.Managed, act.Managed);
            Assert.AreEqual(exp.RecoveryLevel, act.RecoveryLevel);
            Assert.AreEqual(exp.Expires, act.Expires);
            Assert.AreEqual(exp.NotBefore, act.NotBefore);
            Assert.IsTrue(VerifyAreEqual(exp.Tags, act.Tags));
        }

        private void VerifyKeyMaterialEqual(JsonWebKey exp, JsonWebKey act)
        {
            Assert.AreEqual(exp.KeyId, act.KeyId);
            Assert.AreEqual(exp.KeyType, act.KeyType);
            Assert.IsTrue(VerifyAreEqual(exp.KeyOps, act.KeyOps));
            Assert.AreEqual(exp.CurveName, act.CurveName);
            Assert.AreEqual(exp.K, act.K);
            Assert.AreEqual(exp.N, act.N);
            Assert.AreEqual(exp.E, act.E);
            Assert.AreEqual(exp.X, act.X);
            Assert.AreEqual(exp.Y, act.Y);
            Assert.AreEqual(exp.D, act.D);
            Assert.AreEqual(exp.DP, act.DP);
            Assert.AreEqual(exp.DQ, act.DQ);
            Assert.AreEqual(exp.QI, act.QI);
            Assert.AreEqual(exp.P, act.P);
            Assert.AreEqual(exp.Q, act.Q);
            Assert.AreEqual(exp.T, act.T);
        }

        private static bool VerifyAreEqual(IDictionary<string, string> exp, IDictionary<string, string> act)
        {
            if (exp == null && act == null)
                return true;

            if (exp?.Count != act?.Count)
                return false;

            foreach (var pair in exp)
            {
                if (!act.TryGetValue(pair.Key, out string value)) return false;
                if (!string.Equals(value, pair.Value)) return false;
            }
            return true;
        }

        private static bool VerifyAreEqual(IList<KeyOperations> exp, IList<KeyOperations> act)
        {
            if (exp == null && act == null)
                return true;

            if (exp.Count != act.Count)
                return false;

            for (var i = 0; i < exp.Count; ++i)
                if (exp[i] != act[i])
                    return false;

            return true;
        }

        #endregion

        #region Cleanup
        //[TearDown]
        //public async Task Cleanup()
        //{
        //    try
        //    {
        //        foreach (var cleanupItem in TestcaseKeysQueue)
        //        {
        //            if (cleanupItem.DeleteKey)
        //            {
        //                await KVKeyClient.DeleteKeyAsync(cleanupItem.Key.Name);
        //            }
        //        }

        //        foreach (var cleanupItem in TestcaseKeysQueue)
        //        {
        //            await WaitForDeletedKey(cleanupItem.Key.Name);
        //        }

        //        foreach (var cleanupItem in TestcaseKeysQueue)
        //        {
        //            await KVKeyClient.PurgeDeletedKeyAsync(cleanupItem.Key.Name);
        //        }

        //        foreach (var cleanupItem in TestcaseKeysQueue)
        //        {
        //            await WaitForPurgedKey(cleanupItem.Key.Name);
        //        }
        //    }
        //    finally
        //    {
        //        TestcaseKeysQueue.Clear();
        //    }
        //}

        //protected Task WaitForPurgedKey(string name)
        //{
        //    if (Mode == RecordedTestMode.Playback)
        //    {
        //        return Task.CompletedTask;
        //    }

        //    using (Recording.DisableRecording())
        //    {
        //        return TestRetryHelper.RetryAsync(async () => {
        //            try
        //            {
        //                await KVKeyClient.GetDeletedKeyAsync(name);
        //                throw new InvalidOperationException("Key still exists");
        //            }
        //            catch
        //            {
        //                return (Response)null;
        //            }
        //        });
        //    }
        //}

        //protected Task WaitForDeletedKey(string name)
        //{
        //    if (Mode == RecordedTestMode.Playback)
        //    {
        //        return Task.CompletedTask;
        //    }

        //    using (Recording.DisableRecording())
        //    {
        //        return TestRetryHelper.RetryAsync(async () => await KVKeyClient.GetDeletedKeyAsync(name));
        //    }
        //}

        //protected void RegisterForCleanup(KeyBase key, bool deleteKey = true)
        //{
        //    TestcaseKeysQueue.Enqueue((key, deleteKey));
        //}
        #endregion

        #endregion
    }
}
