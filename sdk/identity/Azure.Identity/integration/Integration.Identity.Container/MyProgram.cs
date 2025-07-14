// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;

/// <summary>
/// Program is a console application that demonstrates the use of Workload Identity Credential.
/// </summary>
public class MyProgram
{
    /// <summary>
    /// Main is the entry point of the console application.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static async global::System.Threading.Tasks.Task Main(string[] args)
    {
        try
        {
            var cred = new WorkloadIdentityCredential();
            var token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://management.azure.com//.default" })).ConfigureAwait(false);
            if (token.Token != null)
                Console.WriteLine("Passed!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}