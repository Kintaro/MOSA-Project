﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using System;

namespace Mosa.Compiler.Framework.CIL
{
	/// <summary>
	///
	/// </summary>
	public sealed class ArglistInstruction : BaseCILInstruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="ArglistInstruction"/> class.
		/// </summary>
		/// <param name="opcode">The opcode.</param>
		public ArglistInstruction(OpCode opcode)
			: base(opcode, 0)
		{
		}

		#endregion Construction

		#region Methods

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor.</param>
		/// <param name="context">The context.</param>
		public override void Visit(ICILVisitor visitor, Context context)
		{
			visitor.Arglist(context);
		}

		/// <summary>
		/// Decodes the specified instruction.
		/// </summary>
		/// <param name="ctx">The context.</param>
		/// <param name="decoder">The instruction decoder, which holds the code stream.</param>
		public override void Decode(InstructionNode ctx, IInstructionDecoder decoder)
		{
			// Decode base classes first
			base.Decode(ctx, decoder);

			throw new NotImplementedException();
		}

		#endregion Methods
	}
}
