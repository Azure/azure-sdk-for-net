import "./customer-managed-keys.tsp";

using Azure.ResourceManager.CommonTypes.Private;

namespace Azure.ResourceManager.CommonTypes;

@@armCommonDefinition(Encryption,
  "encryption",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v4, isDefault: true },
  "customermanagedkeys.json"
);
@@armCommonDefinition(Encryption,
  "encryption",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "customermanagedkeys.json"
);
@@armCommonDefinition(Encryption,
  "encryption",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "customermanagedkeys.json"
);

@@armCommonDefinition(CustomerManagedKeyEncryption,
  "customerManagedKeyEncryption",
  #{ version: Azure.ResourceManager.CommonTypes.Versions.v4, isDefault: true },
  "customermanagedkeys.json"
);
@@armCommonDefinition(CustomerManagedKeyEncryption,
  "customerManagedKeyEncryption",
  Azure.ResourceManager.CommonTypes.Versions.v5,
  "customermanagedkeys.json"
);
@@armCommonDefinition(CustomerManagedKeyEncryption,
  "customerManagedKeyEncryption",
  Azure.ResourceManager.CommonTypes.Versions.v6,
  "customermanagedkeys.json"
);
