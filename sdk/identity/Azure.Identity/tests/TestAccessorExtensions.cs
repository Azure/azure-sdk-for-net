// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using System.Text;

namespace Azure.Identity.Tests
{
    internal static class TestAccessorExtensions
    {
        public static string _client(this ClientSecretCredential credential)
        {
            return typeof(ClientSecretCredential).GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(credential) as string;
        }
        public static void _client(this ClientSecretCredential credential, AadIdentityClient client)
        {
            typeof(ClientSecretCredential).GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(credential, client);
        }

        public static ManagedIdentityClient _client(this ManagedIdentityCredential credential)
        {
            return typeof(ManagedIdentityCredential).GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(credential) as ManagedIdentityClient;
        }
        public static void _client(this ManagedIdentityCredential credential, ManagedIdentityClient client)
        {
            typeof(ManagedIdentityCredential).GetField("_client", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(credential, client);
        }
        public static SecureString ToSecureString(this string plainString)
        {
            if (plainString == null)
                return null;

            SecureString secureString = new SecureString();
            foreach (char c in plainString.ToCharArray())
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }
    }
}
