# Render Tiles, Imageries, and Images

## Get correct tile index

Rendering map tiles requires the knowledge about [zoom levels and tile grid system](https://docs.microsoft.com/azure/azure-maps/zoom-levels-and-tile-grid). We provide very convenient APIs for user to find out the correct tile index and zoom level they need.

For example, if a user wants to render a tile in Germany with a specific bounding box range, one can use utility function `PositionToTileXY` method from `TileMath`. With the desired coordinate, zoom level and tile size, one can get tile X and Y index:

```C# Snippet:GetTileXY
int zoom = 10, tileSize = 300;

// Get tile X, Y index by coordinate, zoom and tile size information
var tileIndex = MapsRenderClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);
```

## Render imagery tiles

From previous section, we get the tile X, Y index we want, we amy continue to get the satellite imagery we need. First, import `System.IO` to use `File` class so we can save image to file:

```C# Snippet:SaveToFile
using System.IO;
```

Call get Map imagery tile API and save the result to file by previously calculated tile X, Y index:

```C# Snippet:RenderImagery
// Get imagery tile
var imageryTile = client.GetMapImageryTile(new MapTileIndex(tileIndex.X, tileIndex.Y, zoom));
Assert.IsNotNull(imageryTile);

// Prepare a file stream to save the imagery
using (var fileStream = File.Create(".\\BerlinImagery.png"))
{
    imageryTile.Value.CopyTo(fileStream);
    Assert.IsTrue(fileStream.Length > 0);
}
```

The imagery will look like:

![BerlinImagery](../tests/BerlinImagery.png)

## Render static images

To get static image, one can assign bounding box and zoom level or coordinate and image width and height with `RenderStaticImageOptions`:

```C# Snippet:RenderStaticImages
// Prepare static image options
var staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228,52.4559,13.5794,52.629))
{
    ImageLayer = MapImageLayer.Basic,
    ImageStyle = MapImageStyle.Dark,
    ZoomLevel = 10,
    RenderLanguage = "en",
};

// Get static image
var image = client.GetMapStaticImage(staticImageOptions);

// Prepare a file stream to save the imagery
using (var fileStream = File.Create(".\\BerlinStaticImage.png"))
{
    image.Value.CopyTo(fileStream);
    Assert.IsTrue(fileStream.Length > 0);
}
```

The image will look like:

![BerlinStaticImage](../tests/BerlinStaticImage.png)

In a more complex scenario, we can also add pushpins and paths on the map to make it more vivid:

```C# Snippet:RenderStaticImagesWithPinsAndPaths
// Prepare pushpin styles
var pushpinSet1 = new ImagePushpinStyle(
    new List<PushpinPosition>() {
        new PushpinPosition(13.35, 52.577, "Label start"),
        new PushpinPosition(13.2988, 52.6, "Label end"),
})
{
    PinScale = 0.9,
    PinColor = Color.Red,
    LabelColor = Color.Blue,
    LabelScale = 18
};
var pushpinSet2 = new ImagePushpinStyle(
    new List<PushpinPosition>() {new PushpinPosition(13.495, 52.497, "Label 3")}
)
{
    PinScale = 1.2,
    PinColor = Color.Beige,
    LabelColor = Color.White,
    LabelScale = 18
};

// Prepare path styles
var path1 = new ImagePathStyle(
    new List<GeoPosition>() {
        new GeoPosition(13.35, 52.577),
        new GeoPosition(13.2988, 52.6)
})
{
    LineColor = Color.Beige,
    LineWidthInPixels = 5
};

// Prepare static image options
var staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228, 52.4559, 13.5794, 52.629))
{
    ImageLayer = MapImageLayer.Basic,
    ImageStyle = MapImageStyle.Dark,
    ZoomLevel = 10,
    RenderLanguage = "en",
    ImagePushpinStyles = new List<ImagePushpinStyle>() { pushpinSet1, pushpinSet2 },
    ImagePathStyles = new List<ImagePathStyle>() { path1 },
};

// Get static image
var image = client.GetMapStaticImage(staticImageOptions);

// Prepare a file stream to save the imagery
using (var fileStream = File.Create(".\\BerlinStaticImageWithPinsAndPaths.png"))
{
    image.Value.CopyTo(fileStream);
    Assert.IsTrue(fileStream.Length > 0);
}
```

The rendered image will look like:

![RenderStaticImagesWithPinsAndPaths](../tests/BerlinStaticImageWithPinsAndPaths.png)

## Render tiles

To render map tiles, one can decide map tile X, Y index and zoom level and then decide the tile style in `RenderTileOptions`:

```C# Snippet:RenderMapTiles
int zoom = 10, tileSize = 300;

// Get tile X, Y index by coordinate, zoom and tile size information
var tileIndex = MapsRenderClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);

// Fetch map tiles
var GetMapTileOptions = new GetMapTileOptions()
{
    MapTileFormat = MapTileFormat.Png,
    MapTileLayer = MapTileLayer.Hybrid,
    MapTileStyle = MapTileStyle.Main,
    MapTileIndex = new MapTileIndex(tileIndex.X, tileIndex.Y, zoom),
};
var mapTile = client.GetMapTile(GetMapTileOptions);

// Prepare a file stream to save the imagery
using (var fileStream = File.Create(".\\BerlinMapTile.png"))
{
    mapTile.Value.CopyTo(fileStream);
    Assert.IsTrue(fileStream.Length > 0);
}
```

The image will look like:

![BerlinMapTile](../tests/BerlinMapTile.png)
