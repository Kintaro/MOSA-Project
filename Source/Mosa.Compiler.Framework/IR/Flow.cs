﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// An abstract intermediate representation of flow instruction.
	/// </summary>
	public sealed class Flow : BaseIRInstruction
	{
		#region Construction

		/// <summary>
		/// Initializes a new instance of <see cref="Flow"/>.
		/// </summary>
		public Flow() :
			base(0, 0)
		{
		}

		#endregion Construction

		#region Properties

		/// <summary>
		/// Gets a value indicating whether to [ignore during code generation].
		/// </summary>
		/// <value>
		/// <c>true</c> if [ignore during code generation]; otherwise, <c>false</c>.
		/// </value>
		public override bool IgnoreDuringCodeGeneration { get { return true; } }

		#endregion Properties

		#region Instruction Overrides

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor object.</param>
		/// <param name="context">The context.</param>
		public override void Visit(IIRVisitor visitor, Context context)
		{
			visitor.Flow(context);
		}

		#endregion Instruction Overrides
	}
}
