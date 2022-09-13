# Get secret

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md#getting-started) for details.

## Import the namespaces

```C# Snippet:RenderImportNamespace
using Azure.Maps.Render.Models;
```

## Create Render Client

Before rendering any images or tiles, create a `MapsRenderClient` first:

```C# Snippet:InstantiateRenderClient
var client = new MapsRenderClient(credential, endpoint, clientId);
```

## Render Tiles, Imageries, and Images

You can create a client and render imagery tiles:

```C# Snippet:RenderImagery
// Get imagery tile
var imageryTile = client.GetMapImageryTile(new TileIndex(10, 12, 12));
var imageryStream = new MemoryStream();
imageryTile.Value.CopyTo(imageryStream);
```

Or to render static images:

```C# Snippet:RenderStaticImages
// Get static image
var staticImageOptions = new RenderStaticImageOptions()
{
    Layer = StaticMapLayer.Basic,
    Style = MapImageStyle.Dark,
    Center = new List<double>() { 0.0, 0.0 },
    Language = "en",
    Height = 100,
    Width = 100,
};
var image = client.GetMapStaticImage(staticImageOptions);
var imageStream = new MemoryStream();
image.Value.CopyTo(imageStream);
```

Or to render tiles:

```C# Snippet:RenderMapTiles
// Fetch map tiles
var renderTileOptions = new RenderTileOptions()
{
    Format = TileFormat.Png,
    Layer = MapTileLayer.Hybrid,
    Style = MapTileStyle.Main,
    TileIndex = new TileIndex(10, 88, 88),
};
var mapTile = client.GetMapTile(renderTileOptions);
var tileStream = new MemoryStream();
mapTile.Value.CopyTo(tileStream);
```

To see the full example source files, see:

* [Rendering examples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Render/tests/Samples/)
