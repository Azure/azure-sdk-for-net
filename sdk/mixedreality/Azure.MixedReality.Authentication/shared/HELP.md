# Shared authentication source for Azure Mixed Reality client libraries

This folder contains source to be shared internally with Azure Mixed Reality client libraries. The source should be
consumed using something like the following in a Mixed Reality client library:

```xml
<ItemGroup>
  <Compile Include="$(AzureMixedRealityAuthenticationSharedSources)\*.cs" Link="Shared\%(RecursiveDir)\%(Filename)%(Extension)" />
</ItemGroup>
```

The `AzureMixedRealityAuthenticationSharedSources` property is defined in the Directory.Build.props above.
