// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Storage.Tests;

public class StorageResourceNameTests
{
    [TestCase(false)]
    [TestCase(true)]
    public void ResourceNameRequirementsMatchStorageDnsNames(bool fileShare)
    {
        ProvisionableResource resource = fileShare ? new FileShare("resource") : new BlobContainer("resource");
        ResourceNameRequirements requirements = resource.GetResourceNameRequirements();

        Assert.That(requirements.MinLength, Is.EqualTo(3));
        Assert.That(requirements.MaxLength, Is.EqualTo(63));
        Assert.That(requirements.ValidCharacters, Is.EqualTo(
            ResourceNameCharacters.LowercaseLetters | ResourceNameCharacters.Numbers | ResourceNameCharacters.Hyphen));
        Assert.That(NameSanitizer.Sanitize("My_Resource.123(Test)-name", requirements.ValidCharacters),
            Is.EqualTo("myresource123test-name"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public void DynamicNamesPreserveSanitizedStablePrefix(bool fileShare)
    {
        ProvisionableResource resource = fileShare ? new FileShare("My_Resource123") : new BlobContainer("My_Resource123");
        DynamicResourceNamePropertyResolver resolver = new();
        ProvisioningBuildOptions options = new();

        string Resolve()
        {
            BicepValue<string>? name = resolver.ResolveName(options, resource, resource.GetResourceNameRequirements());
            Assert.That(name, Is.Not.Null);
            return name!.Compile().ToString();
        }

        string first = Resolve();
        Assert.That(first, Is.EqualTo("take('myresource123-${uniqueString(resourceGroup().id)}', 63)"));
        Assert.That(Resolve(), Is.EqualTo(first));
        resource.BicepIdentifier = "myresource123";
        Assert.That(Resolve(), Is.EqualTo(first));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task GeneratedBicepSanitizesResourceNames(bool fileShare)
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                StorageAccount storage = new("storage")
                {
                    Kind = StorageKind.StorageV2,
                    Sku = { Name = StorageSkuName.StandardLrs }
                };
                infra.Add(storage);
                if (fileShare)
                {
                    FileService service = new("service") { Parent = storage };
                    infra.Add(service);
                    infra.Add(new FileShare("My_Resource123") { Parent = service });
                }
                else
                {
                    BlobService service = new("service") { Parent = storage };
                    infra.Add(service);
                    infra.Add(new BlobContainer("My_Resource123") { Parent = service });
                }
                return infra;
            });

        string serviceType = fileShare ? "fileServices" : "blobServices";
        string childType = fileShare ? "shares" : "containers";
        test.Compare(
            $$"""
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource storage 'Microsoft.Storage/storageAccounts@2026-06-01' = {
              name: take('storage${uniqueString(resourceGroup().id)}', 24)
              location: location
              kind: 'StorageV2'
              sku: {
                name: 'Standard_LRS'
              }
            }

            resource service 'Microsoft.Storage/storageAccounts/{{serviceType}}@2026-06-01' = {
              name: 'default'
              parent: storage
            }

            resource My_Resource123 'Microsoft.Storage/storageAccounts/{{serviceType}}/{{childType}}@2026-06-01' = {
              name: take('myresource123-${uniqueString(resourceGroup().id)}', 63)
              parent: service
            }
            """);
    }

    [TestCase("$root")]
    [TestCase("$web")]
    [TestCase("$logs")]
    public void ExplicitSpecialContainerNamesArePreserved(string name)
    {
        BlobContainer container = new("container") { Name = name };

        new DynamicResourceNamePropertyResolver().ResolveProperties(container, new ProvisioningBuildOptions());

        Assert.That(container.Name.Value, Is.EqualTo(name));
        Assert.That(container.Name.Compile().ToString(), Is.EqualTo($"'\\{name}'"));
    }

    private sealed class NameSanitizer : DynamicResourceNamePropertyResolver
    {
        public static string Sanitize(string text, ResourceNameCharacters characters) => SanitizeText(text, characters);
    }
}
