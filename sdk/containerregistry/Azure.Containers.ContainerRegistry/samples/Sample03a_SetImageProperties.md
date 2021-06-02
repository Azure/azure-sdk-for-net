# Azure.Containers.ContainerRegistry Samples - Set Image Properties (sync)

A common use case for Azure Container Registries is to set an image's properties so it can't be overwritten during a lengthy deployment.

The following sample assumes the registry `myacr.azurecr.io` has a repository `hello-world` where one image has two tags: `v1` and `latest`.

```C# Snippet:ContainerRegistry_Tests_Samples_SetArtifactProperties
// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("REGISTRY_ENDPOINT"));

// Create a new ContainerRegistryClient and RegistryArtifact to access image operations
ContainerRegistryClient client = new ContainerRegistryClient(endpoint, new DefaultAzureCredential());
RegistryArtifact image = client.GetArtifact("library/hello-world", "v1");

// Set permissions on the v1 image's "latest" tag
image.UpdateTagProperties("latest", new ArtifactTagProperties()
{
    CanWrite = false,
    CanDelete = false
});
```

If someone were to push an update to `myacr.azurecr.io\hello-world:v1`, it would fail.

```
C:\> docker push myacr.azurecr.io/hello-world:v1
The push refers to repository [myacr.azurecr.io/hello-world]
9c27e219663c: Layer already exists
unknown: The operation is disallowed on this registry, repository or image. View troubleshooting steps at https://aka.ms/acr/faq/#why-does-my-pull-or-push-request-fail-with-disallowed-operation
```

But be cautious!  If the images has other tags, such as `latest`, it could still be overwritten.  If someone were to push an update to `myacr.azurecr.io\hello-world:latest` (which references the same image), it would succeed.
```
C:\> docker push myacr.azurecr.io/hello-world:latest
The push refers to repository [myacr.azurecr.io/hello-world]
9c27e219663c: Layer already exists
latest: digest: sha256:90659bf80b44ce6be8234e6ff90a1ac34acbeb826903b02cfa0da11c82cbc042 size: 525
```
