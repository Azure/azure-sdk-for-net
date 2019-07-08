﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Azure.Identity.Tests
{
    internal static class TestAccessorExtensions
    {
        public static string _clientId(this ClientSecretCredential credential)
        {
            return typeof(ClientSecretCredential).GetField("_clientId", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(credential) as string;
        }

        public static string _tenantId(this ClientSecretCredential credential)
        {
            return typeof(ClientSecretCredential).GetField("_tenantId", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(credential) as string;
        }

        public static string _clientSecret(this ClientSecretCredential credential)
        {
            return typeof(ClientSecretCredential).GetField("_clientSecret", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(credential) as string;
        }

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
    }
}
