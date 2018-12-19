namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day19
    {
        private const string ProblemInput = @"ip 5
addi 5 16 5
seti 1 1 2
seti 1 8 1
mulr 2 1 3
eqrr 3 4 3
addr 3 5 5
addi 5 1 5
addr 2 0 0
addi 1 1 1
gtrr 1 4 3
addr 5 3 5
seti 2 6 5
addi 2 1 2
gtrr 2 4 3
addr 3 5 5
seti 1 2 5
mulr 5 5 5
addi 4 2 4
mulr 4 4 4
mulr 5 4 4
muli 4 11 4
addi 3 2 3
mulr 3 5 3
addi 3 13 3
addr 4 3 4
addr 5 0 5
seti 0 8 5
setr 5 5 3
mulr 3 5 3
addr 5 3 3
mulr 5 3 3
muli 3 14 3
mulr 3 5 3
addr 4 3 4
seti 0 9 0
seti 0 9 5";
        private const string ProblemTestInput = @"ip 0
seti 5 0 1
seti 6 0 2
addi 0 1 0
addr 1 2 3
setr 1 0 0
seti 8 0 4
seti 9 0 5";

        private enum OpCode
        {
            ip,
            addr,
            addi,
            mulr,
            muli,
            banr,
            bani,
            borr,
            bori,
            setr,
            seti,
            gtir,
            gtri,
            gtrr,
            eqri,
            eqir,
            eqrr
        }

        public static int SolveProblem1()
        {
            var registers = new int[6];
            var ip = 0;
            var ipRegister = 5;

            var instructions = ProblemInput.SplitToLines().Select(l => {
                var parts = l.Split(' ');
                if (!Enum.TryParse(parts[0], out OpCode opCode))
                    throw new Exception(parts[0]);
                if (opCode == OpCode.ip)
                    return new Tuple<OpCode, int, int, int>(opCode, Int32.Parse(parts[1]), -1, -1);

                return new Tuple<OpCode, int, int, int>(
                    opCode,
                    Int32.Parse(parts[1]),
                    Int32.Parse(parts[2]),
                    Int32.Parse(parts[3]));
            }).ToList();

            while (ip >= 0 && ip < instructions.Count - 1)
            {
                var instruction = instructions[ip+1];
                registers[ipRegister] = ip;
                switch (instruction.Item1)
                {
                    case OpCode.addi:
                        registers = addi(instruction, registers);
                        break;
                    case OpCode.addr:
                        registers = addr(instruction, registers);
                        break;
                    case OpCode.muli:
                        registers = muli(instruction, registers);
                        break;
                    case OpCode.mulr:
                        registers = mulr(instruction, registers);
                        break;
                    case OpCode.bani:
                        registers = bani(instruction, registers);
                        break;
                    case OpCode.banr:
                        registers = banr(instruction, registers);
                        break;
                    case OpCode.bori:
                        registers = bori(instruction, registers);
                        break;
                    case OpCode.borr:
                        registers = borr(instruction, registers);
                        break;
                    case OpCode.seti:
                        registers = seti(instruction, registers);
                        break;
                    case OpCode.setr:
                        registers = setr(instruction, registers);
                        break;
                    case OpCode.gtir:
                        registers = gtir(instruction, registers);
                        break;
                    case OpCode.gtrr:
                        registers = gtrr(instruction, registers);
                        break;
                    case OpCode.gtri:
                        registers = gtri(instruction, registers);
                        break;
                    case OpCode.eqir:
                        registers = eqir(instruction, registers);
                        break;
                    case OpCode.eqri:
                        registers = eqri(instruction, registers);
                        break;
                    case OpCode.eqrr:
                        registers = eqrr(instruction, registers);
                        break;
                }

                ip = registers[ipRegister];
                ip++;
            }

            return registers[0];
        }

        private static int[] addr(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] + beforeRegisters[instruction.Item3];
            return ret;
        }

        private static int[] addi(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] + instruction.Item3;
            return ret;
        }

        private static int[] mulr(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] * beforeRegisters[instruction.Item3];
            return ret;
        }

        private static int[] muli(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] * instruction.Item3;
            return ret;
        }

        private static int[] banr(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] & beforeRegisters[instruction.Item3];
            return ret;
        }

        private static int[] bani(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] & instruction.Item3;
            return ret;
        }

        private static int[] borr(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] | beforeRegisters[instruction.Item3];
            return ret;
        }

        private static int[] bori(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] | instruction.Item3;
            return ret;
        }

        private static int[] setr(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2];
            return ret;
        }

        private static int[] seti(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = instruction.Item2;
            return ret;
        }

        private static int[] gtir(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = instruction.Item2 > beforeRegisters[instruction.Item3] ? 1 : 0;
            return ret;
        }

        private static int[] gtri(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] > instruction.Item3 ? 1 : 0;
            return ret;
        }

        private static int[] gtrr(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] > beforeRegisters[instruction.Item3] ? 1 : 0;
            return ret;
        }

        private static int[] eqir(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = instruction.Item2 == beforeRegisters[instruction.Item3] ? 1 : 0;
            return ret;
        }

        private static int[] eqri(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] == instruction.Item3 ? 1 : 0;
            return ret;
        }

        private static int[] eqrr(Tuple<OpCode, int, int, int> instruction, int[] beforeRegisters)
        {
            var ret = (int[])(beforeRegisters.Clone());
            ret[instruction.Item4] = beforeRegisters[instruction.Item2] == beforeRegisters[instruction.Item3] ? 1 : 0;
            return ret;
        }

        public static int SolveProblem2()
        {
            var registers = new int[6];
            registers[0] = 1;
            var ip = 0;
            var ipRegister = 5;

            var instructions = ProblemInput.SplitToLines().Select(l => {
                var parts = l.Split(' ');
                if (!Enum.TryParse(parts[0], out OpCode opCode))
                    throw new Exception(parts[0]);
                if (opCode == OpCode.ip)
                    return new Tuple<OpCode, int, int, int>(opCode, Int32.Parse(parts[1]), -1, -1);

                return new Tuple<OpCode, int, int, int>(
                    opCode,
                    Int32.Parse(parts[1]),
                    Int32.Parse(parts[2]),
                    Int32.Parse(parts[3]));
            }).ToList();

            var t = 0;

            while (ip >= 0 && ip < instructions.Count - 1)
            {
                var before = $"ip={ip} [{registers[0]}, {registers[1]}, {registers[2]}, {registers[3]}, {registers[4]}, {registers[5]}] ";

                if (t % 100000 == 0)
                {
                    Console.WriteLine("ticks: " + t);
                }

                var instruction = instructions[ip+1];
                registers[ipRegister] = ip;
                var instructionString = $"{instruction.Item1} {instruction.Item2} {instruction.Item3} {instruction.Item4} ";

                if (ip == 1)
                {
                    registers = tryFactorise(registers);
                }
                else
                {
                    switch (instruction.Item1)
                    {
                        case OpCode.addi:
                            registers = addi(instruction, registers);
                            break;
                        case OpCode.addr:
                            registers = addr(instruction, registers);
                            break;
                        case OpCode.muli:
                            registers = muli(instruction, registers);
                            break;
                        case OpCode.mulr:
                            registers = mulr(instruction, registers);
                            break;
                        case OpCode.bani:
                            registers = bani(instruction, registers);
                            break;
                        case OpCode.banr:
                            registers = banr(instruction, registers);
                            break;
                        case OpCode.bori:
                            registers = bori(instruction, registers);
                            break;
                        case OpCode.borr:
                            registers = borr(instruction, registers);
                            break;
                        case OpCode.seti:
                            registers = seti(instruction, registers);
                            break;
                        case OpCode.setr:
                            registers = setr(instruction, registers);
                            break;
                        case OpCode.gtir:
                            registers = gtir(instruction, registers);
                            break;
                        case OpCode.gtrr:
                            registers = gtrr(instruction, registers);
                            break;
                        case OpCode.gtri:
                            registers = gtri(instruction, registers);
                            break;
                        case OpCode.eqir:
                            registers = eqir(instruction, registers);
                            break;
                        case OpCode.eqri:
                            registers = eqri(instruction, registers);
                            break;
                        case OpCode.eqrr:
                            registers = eqrr(instruction, registers);
                            break;
                    }
                }

                var after = $"[{registers[0]}, {registers[1]}, {registers[2]}, {registers[3]}, {registers[4]}, {registers[5]}]";
                //Console.WriteLine(before + instructionString + after);

                ip = registers[ipRegister];
                ip++;
                t++;

                if (ip == 16)
                {
                    Console.WriteLine(before + instructionString + after);
                    Console.WriteLine("end of loop");
                }
            }

            return registers[0];
        }

        private static int[] tryFactorise(int[] registers)
        {
            var ret = (int[])(registers.Clone());
            var target = registers[4];
            for (var i = 1; i <= Math.Sqrt(target); i++)
            {
                if (target % i == 0)
                {
                    ret[0] += i;
                    ret[0] += (target / i);
                }
            }

            //  ip=14 [960, 894, 894, 1, 893, 13] addr 3 5 5 [960, 894, 894, 1, 893, 15]
            ret[1] = target+1;
            ret[2] = target+1;
            ret[3] = 1;
            ret[4] = target;
            ret[5] = 15;

            return ret;
        }
    }
}