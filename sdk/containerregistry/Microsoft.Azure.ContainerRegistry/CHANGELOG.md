# Release History

## 1.0.0-preview.2 (Unreleased)


## 1.0.0-preview.1 (2020-04-06)

- Update package version to follow standard Azure-SDK-for-Net versioning guidelines
- Require `System.IdentityModel.Tokens.Jwt >= 5.1.2` instead of `System.IdentityModel.Tokens.Jwt == 5.1.2`.

## 0.10.0-preview

- Support operations on Container Registry repositories, tags, manifests, blobs, access tokens and refresh tokens.
- Autogenerate operations and models from [2019-08-15 containerregistry.json swagger spec](https://github.com/Azure/azure-rest-api-specs/blob/master/specification/containerregistry/data-plane/Microsoft.ContainerRegistry/preview/2019-08-15/containerregistry.json).
- Support different manifest types to allow for operations on [OCI](https://www.opencontainers.org) images.
- Oauth2 Support.
- Supports V2 container runtime operations. See [Docker Registry HTTP API V2 specs](https://docs.docker.com/registry/spec/api/) for more information.
- Add customized classes (e.g. ContainerRegistryCredentials) to simplify authentication.

## 0.9.0-preview.1.20190603.2

- Preview release for Azure Container Registry Data plane operations
- Support for basic container runtime operations, such as get, delete and update of manifest, repository, tags and their attributes.
- Autogenerate operations and models from [2018-08-10 containerregistry.json swagger spec](https://github.com/Azure/azure-rest-api-specs/blob/master/specification/containerregistry/data-plane/Microsoft.ContainerRegistry/preview/2018-08-10/containerregistry.json).

