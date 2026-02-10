namespace TypeSpec.Xml;

/**
 * Known Xml encodings
 */
enum Encoding {
  /** Corresponds to a field of schema 	xs:dateTime */
  xmlDateTime,

  /** Corespond to a field of schema 	xs:date */
  xmlDate,

  /** Corespond to a field of schema 	xs:time */
  xmlTime,

  /** Corespond to a field of schema 	xs:duration */
  xmlDuration,

  /** Corespond to a field of schema 	xs:base64Binary */
  xmlBase64Binary,
}
