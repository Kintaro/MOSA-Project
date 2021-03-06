﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.CIL
{
	/// <summary>
	///
	/// </summary>
	public sealed class LdstrInstruction : BaseCILInstruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="LdstrInstruction"/> class.
		/// </summary>
		/// <param name="opCode">The op code.</param>
		public LdstrInstruction(OpCode opCode)
			: base(opCode, 1, 1)
		{
			return;
		}

		#endregion Construction

		#region Methods

		/// <summary>
		/// Decodes the specified instruction.
		/// </summary>
		/// <param name="ctx">The context.</param>
		/// <param name="decoder">The instruction decoder, which holds the code stream.</param>
		public override void Decode(InstructionNode ctx, IInstructionDecoder decoder)
		{
			// Decode base classes first
			base.Decode(ctx, decoder);

			var token = (uint)decoder.Instruction.Operand;

			string symbolName = @"$ldstr$" + decoder.Method.Module.Name + "$" + token;

			string name = decoder.TypeSystem.LookupUserString(decoder.Method.Module, token);

			ctx.Operand1 = Operand.CreateStringSymbol(decoder.TypeSystem, symbolName, name);

			ctx.Result = decoder.Compiler.CreateVirtualRegister(decoder.TypeSystem.BuiltIn.String);
		}

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor.</param>
		/// <param name="context">The context.</param>
		public override void Visit(ICILVisitor visitor, Context context)
		{
			visitor.Ldstr(context);
		}

		#endregion Methods
	}
}
