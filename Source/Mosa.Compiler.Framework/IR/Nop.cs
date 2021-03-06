// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	///
	/// </summary>
	public sealed class Nop : BaseIRInstruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="Nop"/>.
		/// </summary>
		public Nop() :
			base(0, 0)
		{
		}

		#endregion Construction

		#region Instruction

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor object.</param>
		/// <param name="context">The context.</param>
		public override void Visit(IIRVisitor visitor, Context context)
		{
			visitor.Nop(context);
		}

		#endregion Instruction
	}
}
