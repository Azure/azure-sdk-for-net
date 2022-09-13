# Get secret

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md#getting-started) for details.

## Render Tiles, Imageries, and Images

### Render imagery tiles

```C# Snippet:RenderImagery
// Get imagery tile
var imageryTile = client.GetMapImageryTile(new TileIndex(10, 12, 12));
var imageryStream = new MemoryStream();
imageryTile.Value.CopyTo(imageryStream);
```

### Render static images

```C# Snippet:RenderStaticImages
// Get static image
var staticImageOptions = new RenderStaticImageOptions()
{
    TileLayer = StaticMapLayer.Basic,
    TileStyle = MapImageStyle.Dark,
    CenterCoordinate = new List<double>() { 0.0, 0.0 },
    RenderLanguage = "en",
    Height = 100,
    Width = 100,
};
var image = client.GetMapStaticImage(staticImageOptions);
var imageStream = new MemoryStream();
image.Value.CopyTo(imageStream);
```

### Render tiles

```C# Snippet:RenderMapTiles
// Fetch map tiles
var renderTileOptions = new RenderTileOptions()
{
    TileFormat = TileFormat.Png,
    TileLayer = MapTileLayer.Hybrid,
    TileStyle = MapTileStyle.Main,
    TileIndex = new TileIndex(10, 88, 88),
};
var mapTile = client.GetMapTile(renderTileOptions);
var tileStream = new MemoryStream();
mapTile.Value.CopyTo(tileStream);
```
