﻿/*
 * (c) 2011 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Simon Wollwage (rootnode) <rootnode@mosa-project.org>
 */

//TODO: Remove this class - replaced by SSAOptimizations

using Mosa.Compiler.Framework.IR;
using Mosa.Compiler.Framework.Operands;

namespace Mosa.Compiler.Framework.Stages
{
	public sealed class ConstantFoldingStage : BaseMethodCompilerStage, IMethodCompilerStage, IPipelineStage
	{

		/// <summary>
		/// Performs stage specific processing on the compiler context.
		/// </summary>
		void IMethodCompilerStage.Run()
		{
			foreach (var block in basicBlocks)
			{
				for (var context = new Context(instructionSet, block); !context.EndOfInstruction; context.GotoNext())
				{
					if (!IsFoldableInstruction(context))
						continue;
					if (!HasFoldableArguments(context))
						continue;
					FoldInstruction(context);
				}
			}
		}

		/// <summary>
		/// Folds the instruction.
		/// </summary>
		/// <param name="context">The context.</param>
		private void FoldInstruction(Context context)
		{
			if (context.Instruction is AddSigned)
				FoldAddSInstruction(context);
			else if (context.Instruction is MulSigned)
				FoldMulSInstruction(context);
		}

		/// <summary>
		/// Folds the addition instruction.
		/// </summary>
		/// <param name="context">The context.</param>
		private void FoldAddSInstruction(Context context)
		{
			var cA = LoadSignedInteger(context.Operand1);
			var cB = LoadSignedInteger(context.Operand2);

			context.SetInstruction(IRInstruction.Move, context.Result, Operand.CreateConstant(context.Result.Type, cA + cB));
		}

		/// <summary>
		/// Folds the multiply instruction.
		/// </summary>
		/// <param name="context">The context.</param>
		private void FoldMulSInstruction(Context context)
		{
			var cA = LoadSignedInteger(context.Operand1);
			var cB = LoadSignedInteger(context.Operand2);

			context.SetInstruction(IRInstruction.Move, context.Result, Operand.CreateConstant(context.Result.Type, cA * cB));
		}

		/// <summary>
		/// Determines whether [has foldable arguments] [the specified context].
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns>
		///   <c>true</c> if [has foldable arguments] [the specified context]; otherwise, <c>false</c>.
		/// </returns>
		private bool HasFoldableArguments(Context context)
		{
			return context.Operand1.IsConstant && context.Operand2.IsConstant;
		}

		/// <summary>
		/// Determines whether [is foldable instruction] [the specified context].
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns>
		///   <c>true</c> if [is foldable instruction] [the specified context]; otherwise, <c>false</c>.
		/// </returns>
		private bool IsFoldableInstruction(Context context)
		{
			var instruction = context.Instruction;
			return instruction is AddSigned ||
				instruction is AddUnsigned ||
				instruction is MulSigned ||
				instruction is MulUnsigned;
		}

		/// <summary>
		/// Loads the signed integer.
		/// </summary>
		/// <param name="operand">The operand.</param>
		/// <returns></returns>
		private int LoadSignedInteger(Operand operand)
		{
			if (operand.Value is int)
				return (int)(operand.Value);
			if (operand.Value is short)
				return (int)(short)(operand.Value);
			if (operand.Value is sbyte)
				return (int)(sbyte)(operand.Value);
			return 0;
		}

	}
}