﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

namespace Mosa.TinyCPUSimulator.x86.Opcodes
{
	public class Comisd : BaseX86Opcode
	{
		public override void Execute(CPUx86 cpu, SimInstruction instruction)
		{
			var a = LoadFloatValue(cpu, instruction.Operand1, instruction.Size).Low;
			var b = LoadFloatValue(cpu, instruction.Operand2, instruction.Size).Low;
			int size = instruction.Size;

			if (double.IsNaN(a) || double.IsNaN(b))
			{
				cpu.EFLAGS.Zero = true;
				cpu.EFLAGS.Parity = true;
				cpu.EFLAGS.Carry = true;
			}
			else if (a == b)
			{
				cpu.EFLAGS.Zero = true;
				cpu.EFLAGS.Parity = false;
				cpu.EFLAGS.Carry = false;
			}
			else if (a > b)
			{
				cpu.EFLAGS.Zero = false;
				cpu.EFLAGS.Parity = false;
				cpu.EFLAGS.Carry = false;
			}
			else
			{
				cpu.EFLAGS.Zero = false;
				cpu.EFLAGS.Parity = false;
				cpu.EFLAGS.Carry = true;
			}

			cpu.EFLAGS.Overflow = false;
			cpu.EFLAGS.Adjust = false;
			cpu.EFLAGS.Sign = false;
		}
	}
}
