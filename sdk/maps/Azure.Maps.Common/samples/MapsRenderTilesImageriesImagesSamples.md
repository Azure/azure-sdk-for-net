# Render Tiles, Imageries, and Images

## Get correct tile index

Rendering map tiles requires the knowledge about [zoom levels and tile grid system](https://docs.microsoft.com/azure/azure-maps/zoom-levels-and-tile-grid). We provide very convenient APIs for user to find out the correct tile index and zoom level they need.

For example, if a user wants to render a tile in Germany with a specific bounding box range, one can use `PositionToTileXY` method from `TileMath`. With the desired coordinate, zoom level and tile size, one can get tile X and Y index:

```C# Snippet:GetTileXY
int zoom = 10, tileSize = 300;

// Get tile X, Y index by coordinate, zoom and tile size information
TileMath.PositionToTileXY(
    new GeoPosition(13.3854, 52.517), zoom, tileSize,
    out var tileX, out var tileY
);
```

And then we can use the tile X, Y index to render the images we want. Please refer the the following sections.

## Render imagery tiles

From previous section, we get the tile X, Y index we want, we amy continue to get the satellite imagery we need. First, import `System.IO` to use `File` class so we can save image to file:

```C# Snippet:SaveToFile
using System.IO;
```

Call get Map imagery tile API and save the result to file by previously calculated tile X, Y index:

```C# Snippet:RenderImagery
// Get imagery tile
var imageryTile = client.GetMapImageryTile(new TileIndex(tileX, tileY, zoom));
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
var staticImageOptions = new RenderStaticImageOptions(new GeoBoundingBox(13.228,52.4559,13.5794,52.629))
{
    TileLayer = MapImageLayer.Basic,
    TileStyle = MapImageStyle.Dark,
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
var pushpinSet1 = new PushpinStyle(
    new List<PinPosition>() {
        new PinPosition(13.35, 52.577, "Label start"),
        new PinPosition(13.2988, 52.6, "Label end"),
})
{
    PinScale = 0.9,
    PinColor = Color.Red,
    LabelColor = Color.Blue,
    LabelScale = 18
};
var pushpinSet2 = new PushpinStyle(
    new List<PinPosition>() {new PinPosition(13.495, 52.497, "Label 3")}
)
{
    PinScale = 1.2,
    PinColor = Color.Beige,
    LabelColor = Color.White,
    LabelScale = 18
};

// Prepare path styles
var path1 = new PathStyle(
    new List<GeoPosition>() {
        new GeoPosition(13.35, 52.577),
        new GeoPosition(13.2988, 52.6)
})
{
    LineColor = Color.Beige,
    LineWidthInPixels = 5
};

// Prepare static image options
var staticImageOptions = new RenderStaticImageOptions(new GeoBoundingBox(13.228, 52.4559, 13.5794, 52.629))
{
    TileLayer = MapImageLayer.Basic,
    TileStyle = MapImageStyle.Dark,
    ZoomLevel = 10,
    RenderLanguage = "en",
    Pins = new List<PushpinStyle>() { pushpinSet1, pushpinSet2 },
    Paths = new List<PathStyle>() { path1 },
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
TileMath.PositionToTileXY(
    new GeoPosition(13.3854, 52.517), zoom, tileSize,
    out var tileX, out var tileY
);

// Fetch map tiles
var renderTileOptions = new RenderTileOptions()
{
    TileFormat = TileFormat.Png,
    TileLayer = MapTileLayer.Hybrid,
    TileStyle = MapTileStyle.Main,
    TileIndex = new TileIndex(tileX, tileY, zoom),
};
var mapTile = client.GetMapTile(renderTileOptions);

// Prepare a file stream to save the imagery
using (var fileStream = File.Create(".\\BerlinMapTile.png"))
{
    mapTile.Value.CopyTo(fileStream);
    Assert.IsTrue(fileStream.Length > 0);
}
```

The image will look like:

![BerlinMapTile](../tests/BerlinMapTile.png)

## Get Best Map View

`TileMath` also provides `GetBestView` method in case user wants to render an image but not sure about which tile index and zoom level to use. One can get these information via a bounding box, expected map width and height, and tile size:

```C# Snippet:BestMapViewUsage
var boundingBox = new GeoBoundingBox(4.84228, 52.41064, 4.84923, 52.41762);
double mapWidth = 300.0, mapHeight = 300.0;
int padding = 10, tileSize = 512;

TileMath.BestMapView(boundingBox, mapWidth, mapHeight, padding, tileSize,
    out var centerLat, out var centerLon, out var zoom);

// Use center latitude, longitute and zoom level for follow up operations
```
