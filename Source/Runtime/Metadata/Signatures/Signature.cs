/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Michael Ruck (grover) <sharpos@michaelruck.de>
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mosa.Runtime.Metadata.Signatures
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class Signature
	{
		/// <summary>
		/// 
		/// </summary>
		private TokenTypes token;

		/// <summary>
		/// Gets the token.
		/// </summary>
		/// <value>The token.</value>
		public TokenTypes Token
		{
			get { return token; }
		}

		/// <summary>
		/// Loads the signature.
		/// </summary>
		/// <param name="provider">The provider.</param>
		/// <param name="token">The token.</param>
		public void LoadSignature(IMetadataProvider provider, TokenTypes token)
		{
			SignatureReader reader = new SignatureReader(provider.ReadBlob(token), token);

			this.ParseSignature(reader);
			Debug.Assert(reader.Index == reader.Length, @"Signature parser didn't complete.");

			this.token = token;
		}

		/// <summary>
		/// Parses the signature.
		/// </summary>
		/// <param name="reader">The reader.</param>
		protected abstract void ParseSignature(SignatureReader reader);

		/// <summary>
		/// Froms the member ref signature token.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="provider">The provider.</param>
		/// <param name="token">The token.</param>
		/// <returns></returns>
		public static Signature FromMemberRefSignatureToken(ISignatureContext context, IMetadataProvider provider, TokenTypes token)
		{
			SignatureReader reader = new SignatureReader(provider.ReadBlob(token), token);

			Signature result;

			if (reader[0] == 0x06)
			{
				result = new FieldSignature();
			}
			else
			{
				result = new MethodSignature();
			}

			result.ParseSignature(reader);

			Debug.Assert(reader.Index == reader.Length, @"Not all signature bytes read.");

			return result;
		}
	}
}
