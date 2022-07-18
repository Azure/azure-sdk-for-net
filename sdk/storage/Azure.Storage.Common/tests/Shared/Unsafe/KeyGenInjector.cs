// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Azure.Core.TestFramework;
using Azure.Storage.Cryptography;

namespace Azure.Storage.Test.Shared
{
    public static class KeyGenInjector
    {
        private static RecordedTestBase _testBase = default;

        public static void InjectGenerators(RecordedTestBase testBase)
        {
            _testBase = testBase;
            InjectRecordedKeygen();
            InjectIvGen();
        }

        private static void InjectRecordedKeygen()
        {
            MethodInfo oldMethod = typeof(ClientSideEncryptionValueGenerator).GetMethod("CreateKey", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            MethodInfo newMethod = typeof(KeyGenInjector).GetMethod("GenerateKeyRecordable", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            ReplaceMethods(oldMethod, newMethod);
        }

        private static void InjectIvGen()
        {
            MethodInfo oldMethod = typeof(ClientSideEncryptionValueGenerator).GetMethod("GetAesProvider", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            MethodInfo newMethod = typeof(KeyGenInjector).GetMethod("GetAesProviderRecordable", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            ReplaceMethods(oldMethod, newMethod);
        }

        private static void ReplaceMethods(MethodInfo oldMethod, MethodInfo newMethod)
        {
            RuntimeHelpers.PrepareMethod(oldMethod.MethodHandle);
            RuntimeHelpers.PrepareMethod(newMethod.MethodHandle);

            unsafe
            {
                // x86
                if (IntPtr.Size == 4)
                {
                    int* inj = (int*)newMethod.MethodHandle.Value.ToPointer() + 2;
                    int* tar = (int*)oldMethod.MethodHandle.Value.ToPointer() + 2;
#if DEBUG
                    //Console.WriteLine("\nVersion x86 Debug\n");

                    byte* injInst = (byte*)*inj;
                    byte* tarInst = (byte*)*tar;

                    int* injSrc = (int*)(injInst + 1);
                    int* tarSrc = (int*)(tarInst + 1);

                    *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    //Console.WriteLine("\nVersion x86 Release\n");
                    *tar = *inj;
#endif
                }
                // x64
                else
                {
                    long* inj = (long*)newMethod.MethodHandle.Value.ToPointer() + 1;
                    long* tar = (long*)oldMethod.MethodHandle.Value.ToPointer() + 1;
#if DEBUG
                    //Console.WriteLine("\nVersion x64 Debug\n");
                    byte* injInst = (byte*)*inj;
                    byte* tarInst = (byte*)*tar;

                    int* injSrc = (int*)(injInst + 1);
                    int* tarSrc = (int*)(tarInst + 1);

                    *tarSrc = (((int)injInst + 5) + *injSrc) - ((int)tarInst + 5);
#else
                    //Console.WriteLine("\nVersion x64 Release\n");
                    *tar = *inj;
#endif
                }
            }
        }

#pragma warning disable CS8321 // method isn't called at compile time but will be at runtime
        private static byte[] GenerateKeyRecordable(int numBits)
        {
            var buff = new byte[numBits / 8];
            _testBase.Recording.Random.NextBytes(buff);
            return buff;
        }

#pragma warning disable SYSLIB0021 // replicating the way code is done in main library
        private static AesCryptoServiceProvider GetAesProviderRecordable(byte[] contentEncryptionKey)
        {
            byte[] iv = new byte[16];
            _testBase.Recording.Random.NextBytes(iv);
            return new AesCryptoServiceProvider()
            {
                Key = contentEncryptionKey,
                IV = iv
            };
        }
#pragma warning restore SYSLIB0021
#pragma warning restore CS8321
    }
}
