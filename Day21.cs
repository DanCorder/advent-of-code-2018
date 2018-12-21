namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day21
    {
        private const string Day21Input = @"ip 3
seti 123 0 4
bani 4 456 4
eqri 4 72 4
addr 4 3 3
seti 0 0 3
seti 0 9 4
bori 4 65536 2
seti 6152285 4 4
bani 2 255 1
addr 4 1 4
bani 4 16777215 4
muli 4 65899 4
bani 4 16777215 4
gtir 256 2 1
addr 1 3 3
addi 3 1 3
seti 27 4 3
seti 0 3 1
addi 1 1 5
muli 5 256 5
gtrr 5 2 5
addr 5 3 3
addi 3 1 3
seti 25 9 3
addi 1 1 1
seti 17 4 3
setr 1 9 2
seti 7 4 3
eqrr 4 0 1
addr 1 3 3
seti 5 6 3";

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

        public static int SolveProblem1()
        {
            var registers = new int[6];
            registers[0] = 3982;
            var ip = 0;
            var ipRegister = 3;

            var instructions = Day21Input.SplitToLines().Select(l => {
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

                if (t % 100 == 0)
                {
                    Console.WriteLine("ticks: " + t);
                }

                var instruction = instructions[ip+1];
                registers[ipRegister] = ip;
                var instructionString = $"{instruction.Item1} {instruction.Item2} {instruction.Item3} {instruction.Item4} ";

                if (ip == 18)
                {
                    registers = divideBy256(registers);
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

                // if (ip == 16)
                // {
                //     Console.WriteLine(before + instructionString + after);
                //     Console.WriteLine("end of loop");
                // }
            }

            return registers[0];
        }

        private static int[] divideBy256(int[] registers)
        {
            var ret = (int[])(registers.Clone());
            var target = registers[2];
            var answer = target / 256;

            ret[1] = answer;
            ret[2] = target;
            ret[3] = 25;
            ret[5] = 1;

            return ret;
        }

        public static int SolveProblem2()
        {
            var r4 = 0;
            var lastr4 = 0;
            var values = new HashSet<int>();

            while(true)
            {
                var r2 = r4 | 65536;
                r4 = 6152285;

                while (true)
                {
                    r4 = ((((r2 & 255) + r4) & 16777215) * 65899) & 16777215;
                    if (r2 < 256)
                    {
                        break;
                    }

                    r2 = r2 / 256;
                }

                if (values.Contains(r4))
                    break;

                values.Add(r4);
                lastr4 = r4;
            }

            return lastr4;
        }
    }
}