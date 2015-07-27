// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public class CredManCache : IDictionary<string, string>
    {
        public CredManCache(string appName)
        {
            UniqueApplicationString = appName;
        }

        const int oneKB = 1024;
        public static string UniqueApplicationString;

        public void Add(string key, string value)
        {
            // Split the value into 1K bytes length pieces into order to comply with the CredMan size limit on the (Credential Blob) size.
            List<string> splitValues = Split(value);

            int count = 0;

            // Add an entry it CredMan for each 1K byte length string.
            foreach (string val in splitValues)
            {
                // Key each string with the key ending with "-0", "-1" and so on...
                AddCacheEntry(key + "-" + count, val);
                count++;
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        public bool ContainsKey(string key)
        {
            string value;
            return TryGetValue(key, out value);
        }

        public void Clear()
        {
            int count;
            IntPtr list;

            // Get the count and a pointer to the list of entries in CredMan.
            if (NativeMethods.CredEnumerate(null, 0, out count, out list))
            {
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        IntPtr pCredential = Marshal.ReadIntPtr(list, i * Marshal.SizeOf(typeof(IntPtr)));
                        NativeMethods.Credential cred = (NativeMethods.Credential)Marshal.PtrToStructure(pCredential, typeof(NativeMethods.Credential));
                        IntPtr credential;

                        // check if the entry was created by this application by checking the userName and making sure that this application can Read the entry
                        if (cred.userName == UniqueApplicationString && NativeMethods.CredRead(cred.targetName, CredentialType.Generic, 0, out credential))
                        {
                            try
                            {
                                // Call CredDelete to delete the entry in CredMan. 
                                NativeMethods.CredDelete(cred.targetName, CredentialType.Generic, 0);
                            }
                            finally
                            {
                                NativeMethods.CredFree(credential);
                            }
                        }

                    }
                }
                finally
                {
                    NativeMethods.CredFree(list);
                }
            }
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            string value;

            TryGetValue(item.Key, out value);

            if (value != null)
            {
                return (value.Equals(item.Value));
            }
            return false;
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return Keys.Count; }
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (string key in Keys)
            {
                yield return new KeyValuePair<string, string>(key, this[key]);
            }
        }

        public ICollection<string> Keys
        {
            get
            {
                int count;
                IntPtr list;
                HashSet<string> keysSet = new HashSet<string>();

                // Get the count and a pointer to the list of entries in CredMan.
                if (NativeMethods.CredEnumerate(null, 0, out count, out list))
                {
                    try
                    {
                        for (int i = 0; i < count; i++)
                        {
                            IntPtr pCredential = Marshal.ReadIntPtr(list, i * Marshal.SizeOf(typeof(IntPtr)));
                            NativeMethods.Credential credential = (NativeMethods.Credential)Marshal.PtrToStructure(pCredential, typeof(NativeMethods.Credential));

                            IntPtr cred;

                            // check if the credential was created by this application.
                            if (credential.userName == UniqueApplicationString && NativeMethods.CredRead(credential.targetName, CredentialType.Generic, 0, out cred))
                            {
                                try
                                {
                                    // add the key (removing the suffix of -count, ex: -0, -1 etc. that were added in Add()) to the set of keys.
                                    keysSet.Add(credential.targetName.Substring(0, credential.targetName.Length - 2));
                                }

                                finally
                                {
                                    NativeMethods.CredFree(cred);
                                }
                            }
                        }
                    }
                    finally
                    {
                        NativeMethods.CredFree(list);
                    }
                }

                return keysSet.ToList();
            }
        }

        public bool Remove(string key)
        {
            int count;
            IntPtr list;

            // Get the count and a pointer to the list of entries whose targetName starts with "key" in CredMan.
            if (NativeMethods.CredEnumerate(key + "*", 0, out count, out list))
            {
                try
                {
                    for (int i = 0; i < count; i++)
                    {
                        IntPtr pCredential = Marshal.ReadIntPtr(list, i * Marshal.SizeOf(typeof(IntPtr)));
                        NativeMethods.Credential credential = (NativeMethods.Credential)Marshal.PtrToStructure(pCredential, typeof(NativeMethods.Credential));

                        // Delete the entry.
                        NativeMethods.CredDelete(credential.targetName, CredentialType.Generic, 0);
                    }
                }
                finally
                {
                    NativeMethods.CredFree(list);
                }
                return true;
            }

            return false;
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            if (Contains(item))
            {
                Remove(item.Key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(string key, out string value)
        {
            value = null;

            int count;
            IntPtr list;
            IntPtr pCredential;

            // Get the count and a pointer to the list of entries whose targetName (key) begins with "key"

            if (NativeMethods.CredEnumerate(key + '*', 0, out count, out list))
            {
                try
                {
                    Dictionary<string, string> values = new Dictionary<string, string>();

                    for (int i = 0; i < count; i++)
                    {
                        // Read the Credential, only get the entries created by CredMan.
                        if (NativeMethods.CredRead(key + "-" + i, CredentialType.Generic, 0, out pCredential))
                        {
                            try
                            {
                                NativeMethods.Credential cred = (NativeMethods.Credential)Marshal.PtrToStructure(pCredential, typeof(NativeMethods.Credential));

                                // Add the value to the list of values.
                                values.Add(cred.targetName, Marshal.PtrToStringUni(cred.credentialBlob, (int)(cred.credentialBlobSize - 1) / 2));
                            }
                            finally
                            {
                                NativeMethods.CredFree(pCredential);
                            }
                        }
                    }

                    // Stitch together the values to get the value, since they were split up during Add()
                    value = Merge(values);

                    if (!string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
                finally
                {
                    NativeMethods.CredFree(list);
                }
            }

            return false;
        }

        public ICollection<string> Values
        {
            get
            {
                List<string> values = new List<string>();

                foreach (string key in Keys)
                {
                    values.Add(this[key]);
                }

                return values;
            }
        }

        public string this[string key]
        {
            get
            {
                string value;
                TryGetValue(key, out value);
                return value;
            }
            set
            {
                Add(key, value);
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        private void AddCacheEntry(string key, string value)
        {
            // Create a Credential to represent an entry in CredMan
            NativeMethods.Credential credential = new NativeMethods.Credential(key, value);

            int size = Marshal.SizeOf(credential);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(credential, ptr, false);
                if (!NativeMethods.CredWrite(ptr, 0))
                {
                    throw new Exception("Exception occurred while writing to cache. Error Code : " + Marshal.GetLastWin32Error());
                }
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Splits a given string into substrings of 1KB length each, except the last substring which could be lesser than 1KB length
        /// </summary>        
        List<string> Split(string s)
        {
            List<string> list = new List<string>();

            int length = s.Length;
            int index = 0;

            while (length > oneKB)
            {
                // Get a 1 KB length substring and add it to the list
                list.Add(s.Substring(index, oneKB));
                index += oneKB;
                length -= oneKB;
            }

            // Add the remaining substring to the list.
            list.Add(s.Substring(index));

            return list;
        }

        /// <summary>
        /// Takes in a list of key, value pairs and stitches the values together and returns the stitched together value.
        /// </summary>        
        string Merge(Dictionary<string, string> items)
        {
            string combinedValue = string.Empty;
            string value;

            int count = items.Count;
            string key;

            key = items.Keys.First();

            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            // prune off the -digit suffix in the end.
            key = key.Substring(0, key.Length - 2);

            // combine the values
            for (int i = 0; i < count; i++)
            {
                // get the keys in the order of increasing suffix digits in the end.
                if (items.TryGetValue(key + "-" + i, out value))
                {
                    combinedValue += value;
                }
            }

            return combinedValue;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    enum CredentialType
    {
        Generic = 1,
    }

    class NativeMethods
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal extern static bool CredRead(
            string targetName,
            CredentialType type,
            int flags,
            [Out] out IntPtr pCredential
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal extern static bool CredEnumerate(
            string targetName,
            int flags,
            [Out] out int count,
            [Out] out IntPtr pCredential
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal extern static bool CredDelete(
            string targetName,
            CredentialType type,
            int flags
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal extern static bool CredWrite(
            IntPtr pCredential,
            int flags
            );

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal extern static bool CredFree(
            IntPtr pCredential
            );

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct Credential
        {
            public Credential(string key, string value)
            {
                this.flags = 0;
                this.type = CredentialType.Generic;

                // set the key in the targetName
                this.targetName = key;

                this.targetAlias = null;
                this.comment = null;
                this.lastWritten.dwHighDateTime = 0;
                this.lastWritten.dwLowDateTime = 0;

                // set the value in credentialBlob.
                this.credentialBlob = Marshal.StringToHGlobalUni(value);
                this.credentialBlobSize = (uint)((value.Length + 1) * 2);

                this.persist = 1;
                this.attibuteCount = 0;
                this.attributes = IntPtr.Zero;
                this.userName = CredManCache.UniqueApplicationString;
            }

            internal uint flags;
            internal CredentialType type;
            internal string targetName;
            internal string comment;
            internal System.Runtime.InteropServices.ComTypes.FILETIME lastWritten;
            internal uint credentialBlobSize;
            internal IntPtr credentialBlob;
            internal uint persist;
            internal uint attibuteCount;
            internal IntPtr attributes;
            internal string targetAlias;
            internal string userName;
        }
    }
}
