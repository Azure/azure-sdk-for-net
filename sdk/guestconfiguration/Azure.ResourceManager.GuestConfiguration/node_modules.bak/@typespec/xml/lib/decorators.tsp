import "../dist/src/decorators.js";

using TypeSpec.Reflection;

namespace TypeSpec.Xml;

/**
 * Provide the name of the XML element or attribute. This means the same thing as
 `@encodedName("application/xml", value)`
 *
 * @param name The name of the XML element or attribute
 *
 * @example
 *
 * ```tsp
 * @name("XmlBook")
 * model Book {
 *   @name("XmlId") id: string;
 *   @encodedName("application/xml", "XmlName") name: string;
 *   content: string;
 * }
 * ```
 *
 * ```xml
 * <XmlBook>
 *   <XmlId>string</XmlId>
 *   <XmlName>string</XmlName>
 *   <content>string</content>
 * </XmlBook>
 * ```
 */
extern dec name(target: unknown, name: valueof string);

/**
 * Specify that the target property should be encoded as an XML attribute instead of node.
 *
 * @example Default
 *
 * ```tsp
 * model Blob {
 *   id: string;
 * }
 * ```
 *
 * ```xml
 * <Blob>
 *   <id>abcdef</id>
 * </Blob>
 * ```
 *
 * @example With `@attribute`
 *
 * ```tsp
 * model Blob {
 *   @attribute id: string;
 * }
 * ```
 *
 * ```xml
 * <Blob id="abcdef">
 * </Blob>
 * ```
 */
extern dec attribute(target: ModelProperty);

/**
 * Specify that the target property shouldn't create a wrapper node. This can be used to flatten list nodes into the model node or to include raw text in the model node.
 * It cannot be used with `@attribute`.
 *
 * @example Array property default
 *
 * ```tsp
 * model Pet {
 *   tags: Tag[];
 * }
 * ```
 *
 * ```xml
 * <XmlPet>
 *   <ItemsTags>
 *     <XmlTag>
 *       <name>string</name>
 *     </XmlTag>
 *   </ItemsTags>
 * </XmlPet>
 * ```
 *
 * @example Array property with `@unwrapped`
 *
 * ```tsp
 * model Pet {
 *   @unwrapped tags: Tag[];
 * }
 * ```
 *
 * ```xml
 * <XmlPet>
 *   <XmlTag>
 *     <name>string</name>
 *   </XmlTag>
 * </XmlPet>
 * ```
 *
 * @example String property default
 *
 * ```tsp
 * model BlobName {
 *   content: string;
 * }
 * ```
 *
 * ```xml
 * <BlobName>
 *   <content>
 *     abcdef
 *   </content>
 * </BlobName>
 * ```
 *
 * @example Array property with `@unwrapped`
 *
 * ```tsp
 * model BlobName {
 *   @unwrapped content: string;
 * }
 * ```
 *
 * ```xml
 * <BlobName>
 *   abcdef
 * </BlobName>
 * ```
 */
extern dec unwrapped(target: ModelProperty);

/**
 * Specify the XML namespace for this element. It can be used in 2 different ways:
 * 1. `@ns("http://www.example.com/namespace", "ns1")` - specify both namespace and prefix
 * 2. `@Xml.ns(Namespaces.ns1)` - pass a member of an enum decorated with `@nsDeclaration`
 *
 * @param ns The namespace URI or a member of an enum decorated with `@nsDeclaration`.
 * @param prefix The namespace prefix. Required if the namespace parameter was passed as a string.
 *
 * @example With strings
 *
 * ```tsp
 * @ns( "https://example.com/ns1", "ns1")
 * model Foo {
 *   @ns("https://example.com/ns1", "ns1")
 *   bar: string
 *   @ns("https://example.com/ns2", "ns2")
 *   bar: string
 * }
 * ```
 *
 * @example With enum
 *
 * ```tsp
 * @Xml.nsDeclarations
 * enum Namespaces {
 *   ns1: "https://example.com/ns1",
 *   ns2: "https://example.com/ns2"
 * }
 *
 * @Xml.ns(Namespaces.ns1)
 * model Foo {
 *   @Xml.ns(Namespaces.ns1)
 *   bar: string
 *   @Xml.ns(Namespaces.ns2)
 *   bar: string
 * }
 * ```
 *
 */
extern dec ns(target: unknown, ns: string | EnumMember, prefix?: valueof string);

/**
 * Mark an enum as declaring XML namespaces. See `@ns`
 */
extern dec nsDeclarations(target: Enum);
