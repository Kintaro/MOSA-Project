﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Framework;
using System;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// Representations the x86 shift right instruction.
	/// </summary>
	public sealed class Shr : X86Instruction
	{
		#region Data Members

		private static readonly OpCode C = new OpCode(new byte[] { 0xC1 }, 5);
		private static readonly OpCode C1 = new OpCode(new byte[] { 0xD1 }, 5);
		private static readonly OpCode RM = new OpCode(new byte[] { 0xD3 }, 5);

		#endregion Data Members

		#region Construction

		/// <summary>
		/// Initializes a new instance of <see cref="Shr"/>.
		/// </summary>
		public Shr() :
			base(1, 2)
		{
		}

		#endregion Construction

		#region Methods

		/// <summary>
		/// Computes the opcode.
		/// </summary>
		/// <param name="destination">The destination operand.</param>
		/// <param name="source">The source operand.</param>
		/// <param name="third">The third operand.</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentException"></exception>
		protected override OpCode ComputeOpCode(Operand destination, Operand source, Operand third)
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// Emits the specified platform instruction.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="emitter">The emitter.</param>
		protected override void Emit(InstructionNode node, MachineCodeEmitter emitter)
		{
			if (node.Operand2.IsConstant)
			{
				if (node.Operand2.IsConstantOne)
				{
					emitter.Emit(C1, node.Result, null);
				}
				else
				{
					emitter.Emit(C, node.Result, node.Operand2);
				}
			}
			else
			{
				emitter.Emit(RM, node.Operand1, null);
			}
		}

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor object.</param>
		/// <param name="context">The context.</param>
		public override void Visit(IX86Visitor visitor, Context context)
		{
			visitor.Shr(context);
		}

		#endregion Methods
	}
}
