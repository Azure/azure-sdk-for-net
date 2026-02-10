namespace Azure.ResourceManager.CommonTypes;
/** The complex type of the extended location. */
model ExtendedLocation {
  /** The name of the extended location. */
  name: string;

  /** The type of the extended location. */
  type: ExtendedLocationType;
}

/** The supported ExtendedLocation types. */
union ExtendedLocationType {
  /** Azure Edge Zones location type */
  EdgeZone: "EdgeZone",

  /** Azure Custom Locations type */
  CustomLocation: "CustomLocation",

  string,
}
