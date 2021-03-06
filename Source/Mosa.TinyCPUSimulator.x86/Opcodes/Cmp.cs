﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.TinyCPUSimulator.x86.Opcodes
{
	public class Cmp : BaseX86Opcode
	{
		public override void Execute(CPUx86 cpu, SimInstruction instruction)
		{
			// Same as SUB instruction, except store
			uint a = LoadValue(cpu, instruction.Operand1);
			uint b = LoadValue(cpu, instruction.Operand2);
			int size = instruction.Operand2.Size;

			long s = (long)(int)a - (long)(int)b;
			ulong u = (ulong)a - (ulong)b;

			if (size == 32)
				UpdateFlags(cpu, size, s, u, true, true, true, true, true);

			cpu.EFLAGS.Adjust = IsAdjustAfterSub(a, b);
		}
	}
}
