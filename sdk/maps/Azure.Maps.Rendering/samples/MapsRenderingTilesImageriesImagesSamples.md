# Render Tiles, Imageries, and Images

## Import the namespaces

```C# Snippet:RenderImportNamespaces
using Azure.Maps.Rendering;
```

## Create Render Client

Before rendering any images or tiles, create a `MapsRenderingClient` first. Either use subscription key or AAD.

Instantiate render client with subscription key:

```C# Snippet:InstantiateRenderClientViaSubscriptionKey
// Create a MapsRenderingClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsRenderingClient client = new MapsRenderingClient(credential);
```

Instantiate render client via AAD authentication:

```C# #region Snippet:InstantiateRenderClientViaAAD
var client = new MapsRouteClient(credential, clientId);
```

## Get correct tile index

Rendering map tiles requires the knowledge about [zoom levels and tile grid system](https://learn.microsoft.com/azure/azure-maps/zoom-levels-and-tile-grid). We provide APIs for you to find out the correct tile index and zoom level they need.

For example, if you wants to render a tile in Germany with a specific bounding box range, one can use utility function `PositionToTileXY` method from `TileMath`. With the desired coordinate, zoom level and tile size, one can get tile X and Y index:

```C# Snippet:GetTileXY
int zoom = 10, tileSize = 256;

// Get tile X, Y index by coordinate, zoom and tile size information
MapTileIndex tileIndex = MapsRenderingClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);
```

## Get Tile Set ID Metadata

We can get Tile set metadata by assigning Tile set ID and utilize the tile information when needed:

```C# Snippet:GetMapTileSet
Response<MapTileSet> tileSetMetadata = client.GetMapTileSet(MapTileSetId.MicrosoftBaseRoad);

Console.WriteLine("TileSet ID: {0}", tileSetMetadata.Value.TileSetName);
Console.WriteLine("Tile scheme: {0}", tileSetMetadata.Value.TileScheme);
foreach (string endpoint in tileSetMetadata.Value.TileEndpoints)
{
    Console.WriteLine("TileSet endpoint: {0}", endpoint);
}
```

## Render imagery tiles

From previous section, we get the tile X, Y index we want, we amy continue to get the satellite imagery we need. First, import `System.IO` to use `File` class so we can save image to file:

```C# Snippet:SaveToFile
using System.IO;
```

Call get Map imagery tile API and save the result to file by previously calculated tile X, Y index:

```C# Snippet:GetImageryMapTiles
int zoom = 10, tileSize = 256;

// Get tile X, Y index by coordinate, zoom and tile size information
MapTileIndex tileIndex = MapsRenderingClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);

// Fetch imagery map tiles
GetMapTileOptions GetMapTileOptions = new GetMapTileOptions(
    MapTileSetId.MicrosoftImagery,
    new MapTileIndex(tileIndex.X, tileIndex.Y, zoom)
);
Response<Stream> mapTile = client.GetMapTile(GetMapTileOptions);

// Prepare a file stream to save the imagery
using (FileStream fileStream = File.Create(".\\BerlinImagery.png"))
{
    mapTile.Value.CopyTo(fileStream);
}
```

The imagery will look like:

![BerlinImagery](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Rendering/tests/BerlinImagery.png?raw=true "Berlin satellite image")

## Render static images

To a get static image, one can assign bounding box and zoom level or coordinate and image width and height with `RenderStaticImageOptions`:

```C# Snippet:RenderStaticImages
// Prepare static image options
GetMapStaticImageOptions staticImageOptions = new GetMapStaticImageOptions(new GeoBoundingBox(13.228,52.4559,13.5794,52.629))
{
    ZoomLevel = 10,
    Language = RenderingLanguage.EnglishUsa,
};

// Get static image
Response<Stream> image = client.GetMapStaticImage(staticImageOptions);

// Prepare a file stream to save the imagery
using (FileStream fileStream = File.Create(".\\BerlinStaticImage.png"))
{
    image.Value.CopyTo(fileStream);
}
```

The image will look like:

![BerlinStaticImage](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Rendering/tests/BerlinStaticImage.png?raw=true "Berlin static map image")

In a more complex scenario, we can also add pushpins and paths on the map to make it more vivid:

```C# Snippet:RenderStaticImagesWithPinsAndPaths
// Prepare pushpin styles
ImagePushpinStyle pushpinSet1 = new ImagePushpinStyle(
    new List<PushpinPosition>()
    {
        new PushpinPosition(13.35, 52.577, "Label start"),
        new PushpinPosition(13.2988, 52.6, "Label end"),
    }
)
{
    PushpinScaleRatio = 0.9,
    PushpinColor = Color.Red,
    LabelColor = Color.Blue,
    LabelScaleRatio = 18
};
ImagePushpinStyle pushpinSet2 = new ImagePushpinStyle(
    new List<PushpinPosition>() {new PushpinPosition(13.495, 52.497, "Label 3")}
)
{
    PushpinScaleRatio = 1.2,
    PushpinColor = Color.Beige,
    LabelColor = Color.White,
    LabelScaleRatio = 18
};

// Prepare path styles
ImagePathStyle path1 = new ImagePathStyle(
    new List<GeoPosition>() {
        new GeoPosition(13.35, 52.577),
        new GeoPosition(13.2988, 52.6)
    }
)
{
    LineColor = Color.Beige,
    LineWidthInPixels = 5
};

// Prepare static image options
GetMapStaticImageOptions staticImageOptions = new GetMapStaticImageOptions(
    new GeoBoundingBox(13.228, 52.4559, 13.5794, 52.629),
    new List<ImagePushpinStyle>() { pushpinSet1, pushpinSet2 },
    new List<ImagePathStyle>() { path1 }
)
{
    ZoomLevel = 10,
    Language = RenderingLanguage.EnglishUsa
};

// Get static image
Response<Stream> image = client.GetMapStaticImage(staticImageOptions);

// Prepare a file stream to save the imagery
using (FileStream fileStream = File.Create(".\\BerlinStaticImageWithPinsAndPaths.png"))
{
    image.Value.CopyTo(fileStream);
}
```

The rendered image will look like:

![RenderStaticImagesWithPinsAndPaths](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Rendering/tests/BerlinStaticImageWithPinsAndPaths.png?raw=true "Static map image with pushpin and path")

## Render tiles

To render map tiles, one can decide map tile X, Y index and zoom level and then decide the tile style in `RenderTileOptions`:

```C# Snippet:RenderMapTiles
int zoom = 10, tileSize = 256;

// Get tile X, Y index by coordinate, zoom and tile size information
MapTileIndex tileIndex = MapsRenderingClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);

// Fetch map tiles
GetMapTileOptions GetMapTileOptions = new GetMapTileOptions(
    MapTileSetId.MicrosoftBaseRoad,
    new MapTileIndex(tileIndex.X, tileIndex.Y, zoom)
);
Response<Stream> mapTile = client.GetMapTile(GetMapTileOptions);

// Prepare a file stream to save the imagery
using (FileStream fileStream = File.Create(".\\BerlinMapTile.png"))
{
    mapTile.Value.CopyTo(fileStream);
}
```

The image will look like:

![BerlinMapTile](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Rendering/tests/BerlinMapTile.png?raw=true "Berlin map tile image")
