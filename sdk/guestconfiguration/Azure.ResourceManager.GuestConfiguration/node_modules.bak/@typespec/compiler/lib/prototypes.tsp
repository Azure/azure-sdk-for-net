namespace TypeSpec.Prototypes;

extern dec getter(target: unknown);

namespace Types {
  interface ModelProperty {
    @getter type(): unknown;
  }

  interface Operation {
    @getter returnType(): unknown;
    @getter parameters(): unknown;
  }

  interface Array<TElementType> {
    @getter elementType(): TElementType;
  }
}
