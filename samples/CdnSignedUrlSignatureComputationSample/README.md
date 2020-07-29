SIGNEDURLUTILITIES: 
This is .Net Console App which is used to generate signature for Signed Urls.

Signature generation algorithm:
StringToHash = ResourcePath + 
               "?" +
               expiresParamName + 
               "=" +
               expiresValue +
               "&" +
               keyIdParamName +
               "=" +
               keyIdValue

// ConvertToUrlSafeBase64String  will replace + with - and / with _. 
ComputedHash = ConvertToUrlSafeBase64String((new HMACSHA256(Encoding.ASCII.GetBytes(secret))).ComputeHash(Encoding.UTF8.GetBytes(StringToHash)));

How to use?
Provide the parameters used to compute the signature in the below order:

./SignatureComputationApp <ResourcePath> <ExpiresParamName> <ExpiresParamValue> <KeyIdParamName> <KeyIdParamValue> <Secret>

The computed signature is written to the console.
