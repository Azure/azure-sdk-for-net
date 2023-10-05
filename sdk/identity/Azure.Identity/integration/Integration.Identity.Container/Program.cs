// See https://aka.ms/new-console-template for more information
using System;
using Azure.Core;
using Azure.Identity;

public class Program
{
    public static async global::System.Threading.Tasks.Task Main(string[] args)
    {
        try
        {
            var cred = new WorkloadIdentityCredential();
            var token = await cred.GetTokenAsync(new TokenRequestContext(new string[] { "https://management.azure.com//.default" }));
            if (token.Token != null)
                Console.WriteLine("Passed!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
