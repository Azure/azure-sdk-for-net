// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Microsoft.Azure.KeyVault.WebKey
{
    /// <summary>
    /// A class that verifies instances of <see cref="JsonWebKey"/> according to key type. 
    /// </summary>
    public abstract class JsonWebKeyVerifier
    {
        /// <summary>
        /// Indicates which type of key this verifier applies to.
        /// </summary>
        /// This is typically a value of <see cref="JsonWebKeyType"/>, though other values are allowed if registered
        /// with the <see cref="Register"/> method.
        public string Kty { get; }

        /// <summary>
        /// Initializes a new instance setting the specified value in the <see cref="Kty"/> property.
        /// </summary>
        /// <param name="kty">Indicates which type of key this verifier applies to.</param>
        /// <exception cref="ArgumentNullException">If the specified value is <code>null</code>, empty or whitespace.</exception>
        /// <exception cref="ArgumentException">If the specified value contains invalid characters.</exception>
        protected JsonWebKeyVerifier( string kty )
        {
            if ( string.IsNullOrWhiteSpace( kty ) )
                throw new ArgumentNullException( nameof( kty ) );

            foreach ( var ch in kty )
            {
                if ( ch >= '0' && ch <= '9' )
                    continue;
                if ( ch >= 'A' && ch <= 'Z' )
                    continue;
                if ( ch >= 'a' && ch <= 'z' )
                    continue;
                if ( ch == '-' || ch == '.' || ch == '_' )
                    continue;

                throw new ArgumentException( "Value contains invalid characters.", nameof( kty ) );
            }

            Kty = kty;
        }

        /// <summary>
        /// Tells if the type of key verified by this object supports public key algorithms.
        /// </summary>
        /// Note to implementers: if this method returns <code>true</code>, the methods
        /// <see cref="IsPublicKeyComplete"/>, <see cref="IsPublicKeyValid"/>, <see cref="IsPrivateKeyComplete"/> and 
        /// <see cref="IsPrivateKeyValid"/> must be overriden.
        public abstract bool IsPublicKeyCrypto { get; }

        /// <summary>
        /// Tells if the type of key verified by this object supports symmetric key algorithms.
        /// </summary>
        /// Note to implementers: if this method returns <code>true</code>, the methods
        /// <see cref="IsSymmetricKeyComplete"/> and <see cref="IsSymmetricKeyValid"/> must be overriden.
        public abstract bool IsSymmetricKeyCrypto { get; }

        /// <summary>
        /// Tells if the type of key verified by this object contains a secret component, such as a hardware key token.
        /// </summary>
        /// Note to implementers: if this method returns <code>true</code>, the methods
        /// <see cref="IsSecretKeyComplete"/> and <see cref="IsSecretKeyValid"/> must be overriden.
        public abstract bool HasSecretKey { get; }

        /// <summary>
        /// Determines if the specified <see cref="JsonWebKey"/> instance contains values at properties that represent the public key. 
        /// </summary>
        /// <para>If all required public key properties (for the key type) are specified in the instance, the method must return
        /// <code>true</code> and not modify the <paramref name="missingProps"/> parameter.</para>
        /// <para>If some public key property is missing, the method must return <code>false</code> and set <paramref name="missingProps"/>
        /// with a value - typically a <see cref="List{T}"/> - containing all missing properties.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="missingProps">A reference to a variable that tells the list of missing properties. Callers must
        /// set the variable to <code>null</code>, and examine the value only if this method returns <code>false</code>.</param>
        public virtual bool IsPublicKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            throw ThrowDefaultForPublicKeyCrypto( nameof( IsPublicKeyComplete ) );
        }

        /// <summary>
        /// Determines if the specified <see cref="JsonWebKey"/> instance contains a possibly valid public key (see remarks). 
        /// </summary>
        /// <para>Because fully validating a key may require unfeasable amount of resources, this method only has to check
        /// for obvious issues. As a guideline, we say that the code only verifies obvious issues if it runs in constant time.
        /// It's perfectly valid for implementors to do nothing and simply return <code>true</code>.</para>
        /// <para>This method assumes that <see cref="IsPublicKeyComplete"/> was called and returned <code>true</code>. It
        /// doesn't test again for the presence of required properties. It may throw <see cref="NullReferenceException"/>
        /// if the caller doesn't see <see cref="IsPublicKeyComplete"/> returning <code>true</code> first.</para>
        /// <para>If the valiation code finds no issue, this method must return <code>true</code> without modifying the value of 
        /// <paramref name="errorMsg"/>.</para>
        /// <para>If some issue is found, this method must return <code>false</code> and tell more details in the
        /// <paramref name="errorMsg"/> parameter.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="errorMsg">A reference to a variable that will contain an error message. Callers must
        /// set the variable to <code>null</code>, and examine the value only if this method returns <code>false</code>.</param>
        public virtual bool IsPublicKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            throw ThrowDefaultForPublicKeyCrypto( nameof( IsPublicKeyValid ) );
        }

        /// <summary>
        /// Same as <see cref="IsPublicKeyComplete"/>, but for the private key.
        /// </summary>
        public virtual bool IsPrivateKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            throw ThrowDefaultForPublicKeyCrypto( nameof( IsPrivateKeyComplete ) );
        }

        /// <summary>
        /// Same as <see cref="IsPublicKeyValid"/>, but for the private key.
        /// </summary>
        public virtual bool IsPrivateKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            throw ThrowDefaultForPublicKeyCrypto( nameof( IsPrivateKeyValid ) );
        }

        /// <summary>
        /// Determines if the specified <see cref="JsonWebKey"/> instance contains values in one or more properties that
        /// represent the private key. 
        /// </summary>
        /// <para>This method is used to protect private key material from accidental leakage.</para>   
        /// <para>If no private key property (for the key type) is specified in the instance, the method must return
        /// <code>false</code> and not modify the <paramref name="specifiedProps"/> parameter.</para>
        /// <para>If one or more private key property is specified, the method must return <code>true</code> and optionally
        /// set <paramref name="specifiedProps"/> with a value - typically a <see cref="List{T}"/> - containing the specified properties.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="specifiedProps">A reference to a variable that tells the list of specified properties. Callers must
        /// set the variable to <code>null</code> and examine the value only if this method returns <code>true</code>.</param>
        /// <returns><code>true</code> if a value is found in at least one property that describe the private key;
        /// <code>false</code> otherwise.</returns>
        public virtual bool IsAnyPrivateKeyParamSpecified( JsonWebKey webKey, ref ICollection<string> specifiedProps )
        {
            throw ThrowDefaultForPublicKeyCrypto( nameof( IsAnyPrivateKeyParamSpecified ) );
        }

        private Exception ThrowDefaultForPublicKeyCrypto( string methodName )
        {
            if ( IsPublicKeyCrypto )
                throw new NotImplementedException( $"Type {GetType().Name} is a bad implementation. If {nameof( IsPublicKeyCrypto )} returns true, then {methodName} must be overriden and the base must not be called." );

            throw new InvalidOperationException( $"Type {GetType().Name} is not intended for public key cryptography." );
        }

        /// <summary>
        /// Determines if the specified <see cref="JsonWebKey"/> instance contains values at properties that represent the symmetric key. 
        /// </summary>
        /// <para>If all required symmetric key properties (for the key type) are specified in the instance, the method must return
        /// <code>true</code> and not modify the <paramref name="missingProps"/> parameter.</para>
        /// <para>If some property is missing, the method must return <code>false</code> and set <paramref name="missingProps"/>
        /// to a value - typically a <see cref="List{T}"/> - containing all missing properties.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="missingProps">A reference to a variable that tells the list of missing properties. Callers must
        /// set the variable to <code>null</code>, and examine the value only if this method returns <code>false</code>.</param>
        public virtual bool IsSymmetricKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            throw ThrowDefaultForSymmetricKeyCrypto( nameof( IsSymmetricKeyComplete ) );
        }

        /// <summary>
        /// Determines if the specified <see cref="JsonWebKey"/> instance contains a possibly valid symmetric key (see remarks). 
        /// </summary>
        /// <para>Because fully validating a key may require unfeasable amount of resources, this method only has to check
        /// for obvious issues. As a guideline, we say that the code only verifies obvious issues if it runs in constant time.
        /// It's perfectly valid for implementors to do nothing and simply return <code>true</code>.</para>
        /// <para>This method assumes that <see cref="IsSymmetricKeyComplete"/> was called and returned <code>true</code>. It
        /// doesn't test again for the presence of required properties. It may throw <see cref="NullReferenceException"/>
        /// if the caller doesn't see <see cref="IsSymmetricKeyComplete"/> returning <code>true</code> first.</para>
        /// <para>If the valiation code finds no issue, this method must return <code>true</code> without modifying the value of 
        /// <paramref name="errorMsg"/>.</para>
        /// <para>If some issue is found, this method must return <code>false</code> and tell more details in the
        /// <paramref name="errorMsg"/> parameter.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="errorMsg">A reference to a variable that will contain an error message. Callers must
        /// set the variable to <code>null</code>, and examine the value only if this method returns <code>false</code>.</param>
        public virtual bool IsSymmetricKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            throw ThrowDefaultForSymmetricKeyCrypto( nameof( IsSymmetricKeyValid ) );
        }

        private Exception ThrowDefaultForSymmetricKeyCrypto( string methodName )
        {
            if ( IsSymmetricKeyCrypto )
                throw new NotImplementedException( $"Type {GetType().Name} is a bad implementation. If {nameof( IsSymmetricKeyCrypto )} returns true, then {methodName} must be overriden and the base must not be called." );

            throw new InvalidOperationException( $"Type {GetType().Name} is not intended for symmetric key cryptography." );
        }

        /// <summary>
        /// Determines if the specified <see cref="JsonWebKey"/> instance contains values at properties that represent the secret key. 
        /// </summary>
        /// <para>If all required secret key properties (for the key type) are specified in the instance, the method must return
        /// <code>true</code> and not modify the <paramref name="missingProps"/> parameter.</para>
        /// <para>If some property is missing, the method must return <code>false</code> and set <paramref name="missingProps"/>
        /// to a value - typically a <see cref="List{T}"/> - containing all missing properties.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="missingProps">A reference to a variable that tells the list of missing properties. Callers must
        /// set the variable to <code>null</code>, and examine the value only if this method returns <code>false</code>.</param>
        public virtual bool IsSecretKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            throw ThrowDefaultForSecretKeyCrypto( nameof( IsSecretKeyComplete ) );
        }

        /// <summary>
        /// Determines if the specified <see cref="JsonWebKey"/> instance contains a possibly valid secret key (see remarks). 
        /// </summary>
        /// <para>Because fully validating a key may require unfeasable amount of resources, this method only has to check
        /// for obvious issues. As a guideline, we say that the code only verifies obvious issues if it runs in constant time.
        /// It's perfectly valid for implementors to do nothing and simply return <code>true</code>.</para>
        /// <para>This method assumes that <see cref="IsSecretKeyComplete"/> was called and returned <code>true</code>. It
        /// doesn't test again for the presence of required properties. It may throw <see cref="NullReferenceException"/>
        /// if the caller doesn't see <see cref="IsSecretKeyComplete"/> returning <code>true</code> first.</para>
        /// <para>If the valiation code finds no issue, this method must return <code>true</code> without modifying the value of 
        /// <paramref name="errorMsg"/>.</para>
        /// <para>If some issue is found, this method must return <code>false</code> and tell more details in the
        /// <paramref name="errorMsg"/> parameter.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="errorMsg">A reference to a variable that will contain an error message. Callers must
        /// set the variable to <code>null</code>, and examine the value only if this method returns <code>false</code>.</param>
        public virtual bool IsSecretKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            throw ThrowDefaultForSecretKeyCrypto( nameof( IsSecretKeyValid ) );
        }

        private Exception ThrowDefaultForSecretKeyCrypto( string methodName )
        {
            if ( HasSecretKey )
                throw new NotImplementedException( $"Type {GetType().Name} is a bad implementation. If {nameof( HasSecretKey )} returns true, then {methodName} must be overriden and the base must not be called." );

            throw new InvalidOperationException( $"Type {GetType().Name} is not intended to keys that have a secret component (for instance, HSM keys)." );
        }

        private static volatile SortedSet<string> _validOperations;

        public static bool IsOperationValid( string opName )
        {
            if ( _validOperations == null )
            {
                // No lock here; we accept multiple threads initializing.
                var validOperations = new SortedSet<string>();

                foreach ( var op in JsonWebKeyOperation.AllOperations )
                    validOperations.Add( op );

                _validOperations = validOperations;
            }

            // No lock here; collection is read-only at this time.
            return _validOperations.Contains( opName );
        }

        private volatile SortedSet<string> _compatibleOperations;

        public bool IsOperationCompatible( string opName )
        {
            if ( _compatibleOperations == null )
            {
                // No lock here; we accept multiple threads initializing.
                var compatibleOperations = new SortedSet<string>();

                AddCompatibleOperations( compatibleOperations );

                _compatibleOperations = compatibleOperations;
            }

            // No lock here; collection is read-only at this time.
            return _compatibleOperations.Contains( opName );
        }

        /// <summary>
        /// Adds to the specified collection all operations that can be performed with keys whose type is handled by
        /// this object.
        /// </summary>
        /// For instance, if keys can only be used for digital signatures, this method should add only 
        /// <see cref="JsonWebKeyOperation.Sign"/> and <see cref="JsonWebKeyOperation.Verify"/>. 
        protected abstract void AddCompatibleOperations( ICollection<string> compatibleOperations );

        private HashSet<string> _usedProperties;

        public bool IsPropertyUsed( string propName )
        {
            if ( _usedProperties == null )
            {
                // No lock here; we accept multiple threads initializing.
                var usedProperties = new HashSet<string>();

                AddUsedProperties( usedProperties );

                usedProperties.Add( JsonWebKey.Property_Kid );
                usedProperties.Add( JsonWebKey.Property_Kty );
                usedProperties.Add( JsonWebKey.Property_KeyOps );

                _usedProperties = usedProperties;
            }

            // No lock here; collection is read-only at this point.
            return _usedProperties.Contains( propName );
        }

        /// <summary>
        /// Adds to the specified collection all JsonWebKey properties that are useful to keys whose type is handled by
        /// this object.
        /// </summary>
        /// <para>This method must add JSON property names, such as <code>"crv"</code>, <code>"p"</code>, etc. It must not add
        /// C# property names.</para>
        /// <para>This method doesn't have to add <code>"kid"</code>, <code>"kty"</code> and <code>"key_ops"</code>.
        /// Thes properties are assumed to be useful to all keys.</para>. 
        protected abstract void AddUsedProperties( ICollection<string> usedProperties );

        [Flags]
        public enum Options
        {
            /// <summary>
            /// Use this value if you don't want to specify any other.
            /// </summary>
            None = 0,

            /// <summary>
            /// Fails if any private key material is present. Use this to defend against leakage. 
            /// </summary>
            /// This value is only used for keys that support public key cryptography. It's ignored in other key types.
            DenyPrivateKey /*********/ = 1 << 0,

            /// <summary>
            /// Fails if private key material is not fully present. Use this before storing or importing a JsonWebKey
            /// value into a subsystem that needs to keep the private key. 
            /// </summary>
            /// This value is only used for keys that support public key cryptography. It's ignored in other key types.
            RequirePrivateKey /******/ = 1 << 1,

            /// <summary>
            /// Fails if there the <code>"key_ops"</code> value of the verified key contains an incompatible operation.
            /// </summary>
            DenyIncompatibleOperations = 1 << 2,

            /// <summary>
            /// Fails if the JsonWebKey object describes values at properties that are not used by the corresponding key type.
            /// Use this to defend against properties incorrectly set, and also some forms of leakage.
            /// </summary>
            DenyExtraneousFields /***/ = 1 << 3,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            VerifyDecrypt /**********/ = 1 << 10,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            VerifySign /*************/ = 1 << 11,

            /// <summary>
            /// Do not return <code>false</code> if the verification fails; throws an exception instead.
            /// </summary>
            ThrowException /*********/ = 1 << 20
        }

        /// <summary>
        /// Verifies the specified JsonWebKey instance. 
        /// </summary>
        /// <para>Verification first examines the <see cref="JsonWebKey.Kty"/> property to select a verifier instance
        /// (for more information, see the <see cref="Register"/> method). If a verifier is found, it's used to check
        /// if the key conforms to the corresponding key type.</para>
        /// <param name="webKey">The instance to verify.</param>
        /// <param name="options">Tells how verification is to behave.</param>
        /// <param name="error">A reference to a variable that will tell the error message, if verification fails. This
        /// is only set if the method returns <code>false</code>. If the method returns <code>true</code> or throws
        /// an exception, the <paramref name="error"/> will not me modified.</param>
        /// <returns><code>true</code> if the JsonWebKey value is valid, <code>false otherwise</code>.</returns>
        /// <exception cref="ArgumentNullException">If the <paramref name="webKey"/> parameter is null.</exception>
        /// <exception cref="ArgumentException">If the <paramref name="options"/> parameter contains invalid options.</exception>
        /// <exception cref="JsonWebKeyVerificationException">If the JsonWebKey object is invalid and the option 
        ///     <see cref="Options.ThrowException"/> was specified.</exception>
        /// <seealso cref="Options"/>
        public bool Verify( JsonWebKey webKey, Options options, ref string error )
        {
            if ( webKey == null )
                throw new ArgumentNullException( nameof( webKey ) );

            if ( options.HasFlag( Options.DenyPrivateKey ) && options.HasFlag( Options.RequirePrivateKey ) )
                throw new ArgumentException( $"Cannot use {Options.DenyPrivateKey} and {Options.RequirePrivateKey} at same time.", nameof( options ) );

            if ( options.HasFlag( Options.VerifyDecrypt ) || options.HasFlag( Options.VerifySign ) )
                throw new NotImplementedException();

            if ( !VerifyNotNullOrWhiteSpace( webKey.Kty, JsonWebKey.Property_Kty, options, ref error ) )
                return false;

            if ( webKey.Kty != Kty )
                return SetError( options, ref error, $"Expected {JsonWebKey.Property_Kty} to be \"{Kty}\", but found something else." );

            if ( IsPublicKeyCrypto )
            {
                if ( !VerifyPublicKey( this, webKey, options, ref error ) )
                    return false;

                if ( options.HasFlag( Options.DenyPrivateKey ) && !VerifyNoPrivateKey( this, webKey, options, ref error ) )
                    return false;

                if ( options.HasFlag( Options.RequirePrivateKey ) && !VerifyPrivateKey( this, webKey, options, ref error ) )
                    return false;
            }

            if ( IsSymmetricKeyCrypto )
            {
                if ( !VerifySymmetricKey( this, webKey, options, ref error ) )
                    return false;
            }

            if ( HasSecretKey && !VerifySecretKey( this, webKey, options, ref error ) )
                return false;

            if ( options.HasFlag( Options.DenyIncompatibleOperations ) && !VerifyOperationsAreCompatible( this, webKey, options, ref error ) )
                return false;

            if ( !options.HasFlag( Options.DenyIncompatibleOperations ) && !VerifyOperationsAreValid( webKey, options, ref error ) )
                return false;

            if ( options.HasFlag( Options.DenyExtraneousFields ) && !VerifyNoExtraneousFields( this, webKey, options, ref error ) )
                return false;

            return true;
        }

        /// <summary>
        /// Verifies the specified JsonWebKey instance according to <see cref="JsonWebKey.Kty"/>.
        /// </summary>
        /// This method selects a verifier based on the value of <see cref="JsonWebKey.Kty"/>,
        /// then calls the verifier's <see cref="Verify"/> method.
        /// <param name="webKey"></param>
        /// <param name="options"></param>
        /// <param name="error"></param>
        /// <seealso cref="Verify"/>
        public static bool VerifyByKeyType( JsonWebKey webKey, Options options, ref string error )
        {
            if ( webKey == null )
                throw new ArgumentNullException( nameof( webKey ) );

            if ( !VerifyNotNullOrWhiteSpace( webKey.Kty, JsonWebKey.Property_Kty, options, ref error ) )
                return false;

            JsonWebKeyVerifier verifier;

            lock ( _verifiersLock )
            {
                InitVerifiers();
                if ( !VerifyEnum( webKey.Kty, JsonWebKey.Property_Kty, _verifiers, out verifier, options, ref error ) )
                    return false;
            }

            return verifier.Verify( webKey, options, ref error );
        }

        private static readonly object _verifiersLock = new object();

        private static volatile SortedDictionary<string, JsonWebKeyVerifier> _verifiers;

        private static void InitVerifiers()
        {
            if ( _verifiers != null )
                return;

            var verifiers = new SortedDictionary<string, JsonWebKeyVerifier>();

            RegisterAt( verifiers, OctetKeyVerifier.Instance );
            RegisterAt( verifiers, EllipticCurveKeyVerifier.Instance );
            RegisterAt( verifiers, EllipticCurveHsmKeyVerifier.Instance );
            RegisterAt( verifiers, RsaKeyVerifier.Instance );
            RegisterAt( verifiers, RsaHsmKeyVerifier.Instance );

            _verifiers = verifiers;
        }

        /// <summary>
        /// Registers a verifier for a <see cref="Kty"/> value.
        /// </summary>
        /// Throws exception is a previous verifier for same <see cref="Kty"/> value is already registered.
        /// There is no need to register verifiers for values described on <see cref="JsonWebKeyType"/>.
        /// <param name="verifier">The verifier to register.</param>
        /// <seealso cref="GetVerifier"/>
        public static void Register( JsonWebKeyVerifier verifier )
        {
            if ( verifier == null )
                throw new ArgumentNullException( nameof( verifier ) );

            lock ( _verifiersLock )
            {
                InitVerifiers();
                RegisterAt( _verifiers, verifier );
            }
        }

        private static void RegisterAt( IDictionary<string, JsonWebKeyVerifier> verifiers, JsonWebKeyVerifier verifier )
        {
            Debug.Assert( verifiers != null );

            if ( verifiers.TryGetValue( verifier.Kty, out JsonWebKeyVerifier _ ) )
                throw new InvalidOperationException( $"Value already registered for \"{verifier.Kty}\"." );

            verifiers[verifier.Kty] = verifier;
        }

        /// <summary>
        /// Returns the verifier registered for the specified kty value, or null if the kty value was not registered.
        /// </summary>
        /// This method never returns null for values described on <see cref="JsonWebKeyType"/>.
        /// <seealso cref="Register"/>
        public static JsonWebKeyVerifier GetVerifier( string kty )
        {
            if ( string.IsNullOrWhiteSpace( kty ) )
                throw new ArgumentNullException( nameof( kty ) );

            lock ( _verifiersLock )
            {
                InitVerifiers();
                _verifiers.TryGetValue( kty, out JsonWebKeyVerifier result );
                return result;
            }
        }

        private static bool VerifyPublicKey( JsonWebKeyVerifier verifier, JsonWebKey webKey, Options options, ref string error )
        {
            return VerifyKeyParameters(
                "public",
                verifier.IsPublicKeyComplete,
                verifier.IsPublicKeyValid,
                webKey,
                options,
                ref error );
        }

        private static bool VerifyNoPrivateKey( JsonWebKeyVerifier verifier, JsonWebKey webKey, Options options, ref string error )
        {
            ICollection<string> specifiedProps = null;
            if ( !verifier.IsAnyPrivateKeyParamSpecified( webKey, ref specifiedProps ) )
                return true;

            if ( specifiedProps == null || specifiedProps.Count == 0 )
                return SetError( options, ref error, "Private key parameters must not be specified." );

            return SetError( options, ref error, $"Private key parameters must not be specified: {SurroundWithQuotes( specifiedProps )}" );
        }

        private static bool VerifyPrivateKey( JsonWebKeyVerifier verifier, JsonWebKey webKey, Options options, ref string error )
        {
            return VerifyKeyParameters(
                "private",
                verifier.IsPrivateKeyComplete,
                verifier.IsPrivateKeyValid,
                webKey,
                options,
                ref error );
        }

        private static bool VerifySymmetricKey( JsonWebKeyVerifier verifier, JsonWebKey webKey, Options options, ref string error )
        {
            return VerifyKeyParameters(
                "symmetric",
                verifier.IsSymmetricKeyComplete,
                verifier.IsSymmetricKeyValid,
                webKey,
                options,
                ref error );
        }

        private static bool VerifySecretKey( JsonWebKeyVerifier verifier, JsonWebKey webKey, Options options, ref string error )
        {
            return VerifyKeyParameters(
                "secret",
                verifier.IsSecretKeyComplete,
                verifier.IsSecretKeyValid,
                webKey,
                options,
                ref error );
        }

        private delegate bool IsCompleteProc( JsonWebKey webKey, ref ICollection<string> missingProps );

        private delegate bool IsValidProc( JsonWebKey webKey, ref string errorMsg );

        private static bool VerifyKeyParameters( string name, IsCompleteProc isCompleteProc, IsValidProc isValidProc, JsonWebKey webKey, Options options, ref string error )
        {
            ICollection<string> missingParams = null;
            if ( !isCompleteProc( webKey, ref missingParams ) )
            {
                if ( missingParams == null || missingParams.Count == 0 )
                    return SetError( options, ref error, $"Missing {name} key parameters." );

                return SetError( options, ref error, $"Missing {name} key parameters: {SurroundWithQuotes( missingParams )}" );
            }

            string errorMsg = null;
            if ( !isValidProc( webKey, ref errorMsg ) )
            {
                if ( errorMsg != null )
                    errorMsg = $"Invalid {name} key parameters: {errorMsg}";
                else
                    errorMsg = $"Invalid {name} key parameters.";

                return SetError( options, ref error, errorMsg );
            }

            return true;
        }

        private static bool VerifyOperationsAreValid( JsonWebKey webKey, Options options, ref string error )
        {
            if ( webKey.KeyOps == null )
                return true;

            StringBuilder invalid = null;

            foreach ( var keyOp in webKey.KeyOps )
                if ( !IsOperationValid( keyOp ) )
                {
                    if ( invalid == null )
                        invalid = new StringBuilder();
                    else
                        invalid.Append( ", " );

                    invalid.Append( '"' ).Append( keyOp ).Append( '"' );
                }

            if ( invalid != null )
            {
                var validOps = SurroundWithQuotes( _validOperations );
                return SetError( options, ref error, $"Found invalid operations: {invalid}. Valid operations are: {validOps}." );
            }

            return true;
        }

        private static bool VerifyOperationsAreCompatible( JsonWebKeyVerifier verifier, JsonWebKey webKey, Options options, ref string error )
        {
            if ( webKey.KeyOps == null )
                return true;

            StringBuilder incompatible = null;

            foreach ( var keyOp in webKey.KeyOps )
                if ( !verifier.IsOperationCompatible( keyOp ) )
                {
                    if ( incompatible == null )
                        incompatible = new StringBuilder();
                    else
                        incompatible.Append( ", " );

                    incompatible.Append( '"' ).Append( keyOp ).Append( '"' );
                }

            if ( incompatible != null )
            {
                var compatibleOps = SurroundWithQuotes( verifier._compatibleOperations );
                return SetError( options, ref error, $"Found invalid or incompatible operations: {incompatible}. Valid and compatible operations are: {compatibleOps}." );
            }

            return true;
        }

        private static bool VerifyNoExtraneousFields( JsonWebKeyVerifier verifier, JsonWebKey webKey, Options options, ref string error )
        {
            StringBuilder extraneous = null;

            void VerifyProperty( string name, object value )
            {
                if ( value == null || verifier.IsPropertyUsed( name ) )
                    return;

                if ( extraneous == null )
                    extraneous = new StringBuilder();
                else
                    extraneous.Append( ", " );

                extraneous.Append( '"' ).Append( name ).Append( '"' );
            }

            webKey.VisitProperties( VerifyProperty );

            if ( extraneous != null )
                return SetError( options, ref error, $"Extraneous properties: {extraneous}" );

            return true;
        }

        private static bool VerifyEnum<T>( string value, string name, IDictionary<string, T> dictionary, out T item, Options options, ref string error )
        {
            if ( !dictionary.TryGetValue( value, out item ) )
                return SetError( options, ref error, $"Expected {name} to be one of {SurroundWithQuotes( dictionary.Keys )}, but found something else." );

            if ( item == null )
                throw new InvalidOperationException( $"Dictionary for {name} is returning null for \"{value}\"." );

            return true;
        }

        private static bool VerifyNotNullOrWhiteSpace( string value, string name, Options options, ref string error )
        {
            if ( string.IsNullOrWhiteSpace( value ) )
                return SetError( options, ref error, $"A value for {name} is mandatory." );

            return true;
        }

        private static bool SetError( Options options, ref string error, string message )
        {
            if ( options.HasFlag( Options.ThrowException ) )
                throw new JsonWebKeyVerificationException( message );
            error = message;
            return false;
        }

        /// <summary>
        /// Helper method that surrounds string values with double-quotes. 
        /// </summary>
        /// For instance, the strings Foo, Bar cause this method to return <code>"Foo", "Bar"</code>.
        protected static string SurroundWithQuotes( ICollection<string> items )
        {
            return "\"" + string.Join( "\", \"", items ) + "\"";
        }

        /// <summary>
        /// Helper method that joins the operation of creating a collection (if required) and adding an item to it.
        /// </summary>
        /// If the collection is null, this method creates one of type <see cref="List{T}"/>. Then it adds the specified item to the collection.
        protected static void AddItem<T>( ref ICollection<T> items, T newItem )
        {
            if ( items == null )
                items = new List<T>();
            items.Add( newItem );
        }

        /// <summary>
        /// Helper method that validates the size of a byte array.
        /// </summary>
        /// <para>A valid array meets the following criteria:</para>
        /// <list type="bullet">
        /// <item><description>is not <code>null</code>;</description></item>
        /// <item><description>the length is at least <paramref name="requiredSize"/>; and</description></item>
        /// <item><description>excess leading bytes are all zeros.</description></item>
        /// </list>
        /// <param name="value">The array to validate.</param>
        /// <param name="name">The array name, which may be used to build error messages.</param>
        /// <param name="requiredSize">The required size, in bytes.</param>
        /// <param name="errorMsg">A reference to a variable that will contain the error message. This is only set
        /// if the method returns <code>false</code>.</param>
        /// <returns><code>true</code> if the array has a valid size; <code>false otherwise</code>.</returns>
        protected static bool ValidateKeyParameterSize( byte[] value, string name, int requiredSize, ref string errorMsg )
        {
            if ( value == null || value.Length < requiredSize )
            {
                var sizeDesc = value == null ? "null" : value.Length.ToString();
                errorMsg = $"Expected {name} to have at least {requiredSize} bytes, but found {sizeDesc}.";
                return false;
            }

            var excess = value.Length - requiredSize;
            for ( var i = 0; i < excess; ++i )
            {
                if ( value[i] != 0 )
                    errorMsg = $"Expected {name} to have at most {requiredSize} bytes, but found {requiredSize + excess}.";
                --excess;
            }

            return true;
        }
    }

    internal sealed class OctetKeyVerifier : JsonWebKeyVerifier
    {
        public static JsonWebKeyVerifier Instance { get; } = new OctetKeyVerifier();

        private OctetKeyVerifier() : base( JsonWebKeyType.Octet )
        {
        }

        public override bool IsPublicKeyCrypto => false;
        public override bool IsSymmetricKeyCrypto => true;
        public override bool HasSecretKey => false;

        protected override void AddCompatibleOperations( ICollection<string> compatibleOperations )
        {
            compatibleOperations.Add( JsonWebKeyOperation.Encrypt );
            compatibleOperations.Add( JsonWebKeyOperation.Decrypt );
            compatibleOperations.Add( JsonWebKeyOperation.Wrap );
            compatibleOperations.Add( JsonWebKeyOperation.Unwrap );
        }

        protected override void AddUsedProperties( ICollection<string> usedProperties )
        {
            usedProperties.Add( JsonWebKey.Property_K );
        }

        public override bool IsSymmetricKeyComplete( JsonWebKey arg, ref ICollection<string> missingProps )
        {
            if ( arg.K == null || arg.K.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_K );
                return false;
            }

            return true;
        }

        public override bool IsSymmetricKeyValid( JsonWebKey arg, ref string errorMsg )
        {
            return true;
        }
    }

    internal abstract class EllipticCurveKeyVerifierBase : JsonWebKeyVerifier
    {
        protected EllipticCurveKeyVerifierBase( string kty ) : base( kty )
        {
        }

        public override bool IsPublicKeyCrypto => true;
        public override bool IsSymmetricKeyCrypto => false;

        protected override void AddCompatibleOperations( ICollection<string> compatibleOperations )
        {
            compatibleOperations.Add( JsonWebKeyOperation.Sign );
            compatibleOperations.Add( JsonWebKeyOperation.Verify );
        }

        protected override void AddUsedProperties( ICollection<string> usedProperties )
        {
            usedProperties.Add( JsonWebKey.Property_Crv );
            usedProperties.Add( JsonWebKey.Property_X );
            usedProperties.Add( JsonWebKey.Property_Y );
        }

        public override bool IsPublicKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            var result = true;

            if ( string.IsNullOrWhiteSpace( webKey.CurveName ) )
            {
                AddItem( ref missingProps, JsonWebKey.Property_Crv );
                result = false;
            }

            if ( webKey.X == null || webKey.X.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_X );
                result = false;
            }

            if ( webKey.Y == null || webKey.Y.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_Y );
                result = false;
            }

            return result;
        }

        public override bool IsPublicKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            var requiredSize = JsonWebKeyCurveName.GetKeyParameterSize( webKey.CurveName );

            if ( requiredSize < 0 )
            {
                errorMsg = $"Unsupported curve: \"{webKey.CurveName}\". Supported curves are: {SurroundWithQuotes( JsonWebKeyCurveName.AllCurves )}.";
                return false;
            }

            if ( !ValidateKeyParameterSize( webKey.X, nameof( webKey.X ), requiredSize, ref errorMsg ) )
                return false;

            if ( !ValidateKeyParameterSize( webKey.Y, nameof( webKey.Y ), requiredSize, ref errorMsg ) )
                return false;

            return true;
        }
    }

    internal sealed class EllipticCurveKeyVerifier : EllipticCurveKeyVerifierBase
    {
        public static JsonWebKeyVerifier Instance { get; } = new EllipticCurveKeyVerifier();

        private EllipticCurveKeyVerifier() : base( JsonWebKeyType.EllipticCurve )
        {
        }

        public override bool HasSecretKey => false;

        protected override void AddUsedProperties( ICollection<string> usedProperties )
        {
            base.AddUsedProperties( usedProperties );
            usedProperties.Add( JsonWebKey.Property_D );
        }

        public override bool IsPrivateKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            if ( webKey.D == null || webKey.D.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_D );
                return false;
            }

            return true;
        }

        public override bool IsPrivateKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            var requiredSize = JsonWebKeyCurveName.GetKeyParameterSize( webKey.CurveName );

            if ( requiredSize < 0 )
            {
                errorMsg = $"Unsupported curve: \"{webKey.CurveName}\". Supported curves are: {SurroundWithQuotes( JsonWebKeyCurveName.AllCurves )}.";
                return false;
            }

            if ( !ValidateKeyParameterSize( webKey.D, nameof( webKey.D ), requiredSize, ref errorMsg ) )
                return false;

            return true;
        }
    }

    internal sealed class EllipticCurveHsmKeyVerifier : EllipticCurveKeyVerifierBase
    {
        public static JsonWebKeyVerifier Instance { get; } = new EllipticCurveHsmKeyVerifier();

        private EllipticCurveHsmKeyVerifier() : base( JsonWebKeyType.EllipticCurveHsm )
        {
        }

        public override bool HasSecretKey => true;

        protected override void AddUsedProperties( ICollection<string> usedProperties )
        {
            base.AddUsedProperties( usedProperties );
            usedProperties.Add( JsonWebKey.Property_T );
        }

        public override bool IsPrivateKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            return true;
        }

        public override bool IsPrivateKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            return true;
        }

        public override bool IsSecretKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            if ( webKey.T == null || webKey.T.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_T );
                return false;
            }

            return true;
        }

        public override bool IsSecretKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            return true;
        }
    }

    internal abstract class RsaKeyVerifierBase : JsonWebKeyVerifier
    {
        protected RsaKeyVerifierBase( string kty ) : base( kty )
        {
        }

        public override bool IsPublicKeyCrypto => true;
        public override bool IsSymmetricKeyCrypto => false;

        protected override void AddCompatibleOperations( ICollection<string> compatibleOperations )
        {
            compatibleOperations.Add( JsonWebKeyOperation.Encrypt );
            compatibleOperations.Add( JsonWebKeyOperation.Decrypt );
            compatibleOperations.Add( JsonWebKeyOperation.Wrap );
            compatibleOperations.Add( JsonWebKeyOperation.Unwrap );
            compatibleOperations.Add( JsonWebKeyOperation.Sign );
            compatibleOperations.Add( JsonWebKeyOperation.Verify );
        }

        protected override void AddUsedProperties( ICollection<string> usedProperties )
        {
            usedProperties.Add( JsonWebKey.Property_E );
            usedProperties.Add( JsonWebKey.Property_N );
        }

        public override bool IsPublicKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            var result = true;

            if ( webKey.E == null || webKey.E.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_E );
                result = false;
            }

            if ( webKey.N == null || webKey.N.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_N );
                result = false;
            }

            return result;
        }

        public override bool IsPublicKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            return true;
        }
    }

    internal sealed class RsaKeyVerifier : RsaKeyVerifierBase
    {
        public static JsonWebKeyVerifier Instance { get; } = new RsaKeyVerifier();

        private RsaKeyVerifier() : base( JsonWebKeyType.Rsa )
        {
        }

        public override bool HasSecretKey => false;

        protected override void AddUsedProperties( ICollection<string> usedProperties )
        {
            base.AddUsedProperties( usedProperties );
            usedProperties.Add( JsonWebKey.Property_D );
            usedProperties.Add( JsonWebKey.Property_DP );
            usedProperties.Add( JsonWebKey.Property_DQ );
            usedProperties.Add( JsonWebKey.Property_P );
            usedProperties.Add( JsonWebKey.Property_Q );
            usedProperties.Add( JsonWebKey.Property_QI );
        }

        public override bool IsPrivateKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            var result = true;

            if ( webKey.D == null || webKey.D.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_D );
                result = false;
            }

            if ( webKey.DP == null || webKey.DP.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_DP );
                result = false;
            }

            if ( webKey.DQ == null || webKey.DQ.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_DQ );
                result = false;
            }

            if ( webKey.P == null || webKey.P.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_P );
                result = false;
            }

            if ( webKey.Q == null || webKey.Q.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_Q );
                result = false;
            }

            if ( webKey.QI == null || webKey.QI.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_QI );
                result = false;
            }

            return result;
        }

        public override bool IsPrivateKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            return true;
        }
    }

    internal sealed class RsaHsmKeyVerifier : RsaKeyVerifierBase
    {
        public static JsonWebKeyVerifier Instance { get; } = new RsaHsmKeyVerifier();

        private RsaHsmKeyVerifier() : base( JsonWebKeyType.RsaHsm )
        {
        }

        public override bool HasSecretKey => true;

        protected override void AddUsedProperties( ICollection<string> usedProperties )
        {
            base.AddUsedProperties( usedProperties );
            usedProperties.Add( JsonWebKey.Property_T );
        }

        public override bool IsPrivateKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            return true;
        }

        public override bool IsPrivateKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            return true;
        }

        public override bool IsSecretKeyComplete( JsonWebKey webKey, ref ICollection<string> missingProps )
        {
            if ( webKey.T == null || webKey.T.Length == 0 )
            {
                AddItem( ref missingProps, JsonWebKey.Property_T );
                return false;
            }

            return true;
        }

        public override bool IsSecretKeyValid( JsonWebKey webKey, ref string errorMsg )
        {
            return true;
        }
    }
}