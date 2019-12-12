using System;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyClient keyClient = new KeyClient(new Uri("https://javatestpre.vault.azure.net/"), new DefaultAzureCredential());
            var key = keyClient.CreateKey($"key-{Guid.NewGuid()}", KeyType.Rsa);
            Console.WriteLine(key.Value.Name);
        }
    }
}
