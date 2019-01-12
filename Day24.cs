namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day24
    {
        private const string ProblemInput = @"Immune System:
84 units each with 9798 hit points (immune to bludgeoning) with an attack that does 1151 fire damage at initiative 9
255 units each with 9756 hit points (weak to cold, radiation) with an attack that does 382 slashing damage at initiative 17
4943 units each with 6022 hit points (weak to bludgeoning) with an attack that does 11 bludgeoning damage at initiative 4
305 units each with 3683 hit points (weak to bludgeoning, slashing) with an attack that does 107 cold damage at initiative 5
1724 units each with 6584 hit points (weak to radiation) with an attack that does 30 cold damage at initiative 6
2758 units each with 5199 hit points (immune to slashing, bludgeoning, cold; weak to fire) with an attack that does 18 bludgeoning damage at initiative 15
643 units each with 9928 hit points (immune to fire; weak to slashing, bludgeoning) with an attack that does 149 fire damage at initiative 14
219 units each with 8810 hit points with an attack that does 368 cold damage at initiative 3
9826 units each with 10288 hit points (weak to bludgeoning; immune to cold) with an attack that does 8 cold damage at initiative 18
2417 units each with 9613 hit points (weak to fire, cold) with an attack that does 36 cold damage at initiative 19

Infection:
1379 units each with 46709 hit points with an attack that does 66 slashing damage at initiative 16
1766 units each with 15378 hit points (weak to bludgeoning) with an attack that does 12 radiation damage at initiative 10
7691 units each with 33066 hit points (weak to bludgeoning) with an attack that does 7 slashing damage at initiative 12
6941 units each with 43373 hit points (weak to cold) with an attack that does 12 fire damage at initiative 7
5526 units each with 28081 hit points (weak to fire, slashing) with an attack that does 7 bludgeoning damage at initiative 11
5844 units each with 41829 hit points with an attack that does 11 bludgeoning damage at initiative 20
370 units each with 25050 hit points (immune to radiation; weak to fire) with an attack that does 120 radiation damage at initiative 2
164 units each with 42669 hit points with an attack that does 481 fire damage at initiative 13
3956 units each with 30426 hit points (weak to radiation) with an attack that does 13 cold damage at initiative 8
2816 units each with 35467 hit points (immune to slashing, radiation, fire; weak to cold) with an attack that does 24 slashing damage at initiative 1";
        private const string ProblemTestInput = @"";

        private class Group
        {
            public int NoOfUnits;
            public int UnitHealth;
            public DamageType AttackType;
            public int AttackStrength;
            public int Initiative;
            public HashSet<DamageType> Imunities = new HashSet<DamageType>();
            public HashSet<DamageType> Weaknesses = new HashSet<DamageType>();
            public Group Attacking;
            public Group Attacker;
            public bool IsInfection;

            public int EffectivePower => NoOfUnits * AttackStrength;
        }

        private static List<Group> GetImmuneSystem()
        {
            // return new List<Group> {
            //     new Group {IsInfection = false, NoOfUnits = 17, UnitHealth = 5390, AttackType = DamageType.fire, Initiative = 2, AttackStrength = 4507, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning, DamageType.radiation }},
            //     new Group {IsInfection = false, NoOfUnits = 989, UnitHealth = 1274, AttackType = DamageType.slashing, Initiative = 3, AttackStrength = 25, Imunities = new HashSet<DamageType> { DamageType.fire }, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning, DamageType.slashing }}
            // };
            return new List<Group> {
                new Group {IsInfection = false, NoOfUnits = 84, UnitHealth = 9798, AttackType = DamageType.fire, Initiative = 9, AttackStrength = 1151, Imunities = new HashSet<DamageType> { DamageType.bludgeoning }},
                new Group {IsInfection = false, NoOfUnits = 255, UnitHealth = 9756, AttackType = DamageType.slashing, Initiative = 17, AttackStrength = 382, Weaknesses = new HashSet<DamageType> { DamageType.cold, DamageType.radiation }},
                new Group {IsInfection = false, NoOfUnits = 4943, UnitHealth = 6022, AttackType = DamageType.bludgeoning, Initiative = 4, AttackStrength = 11, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning }},
                new Group {IsInfection = false, NoOfUnits = 305, UnitHealth = 3683, AttackType = DamageType.cold, Initiative = 5, AttackStrength = 107, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning, DamageType.slashing }},
                new Group {IsInfection = false, NoOfUnits = 1724, UnitHealth = 6584, AttackType = DamageType.cold, Initiative = 6, AttackStrength = 30, Weaknesses = new HashSet<DamageType> { DamageType.radiation }},
                new Group {IsInfection = false, NoOfUnits = 2758, UnitHealth = 5199, AttackType = DamageType.bludgeoning, Initiative = 15, AttackStrength = 18, Imunities = new HashSet<DamageType> { DamageType.bludgeoning, DamageType.slashing, DamageType.cold }, Weaknesses = new HashSet<DamageType> { DamageType.fire }},
                new Group {IsInfection = false, NoOfUnits = 643, UnitHealth = 9928, AttackType = DamageType.fire, Initiative = 14, AttackStrength = 149, Imunities = new HashSet<DamageType> { DamageType.fire }, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning, DamageType.slashing }},
                new Group {IsInfection = false, NoOfUnits = 219, UnitHealth = 8810, AttackType = DamageType.cold, Initiative = 3, AttackStrength = 368 },
                new Group {IsInfection = false, NoOfUnits = 9826, UnitHealth = 10288, AttackType = DamageType.cold, Initiative = 18, AttackStrength = 8, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning }, Imunities = new HashSet<DamageType> { DamageType.cold }},
                new Group {IsInfection = false, NoOfUnits = 2417, UnitHealth = 9613, AttackType = DamageType.cold, Initiative = 19, AttackStrength = 36, Weaknesses = new HashSet<DamageType> { DamageType.fire, DamageType.cold }},
            };
        }

        private static List<Group> GetInfection()
        {
            // return new List<Group> {
            //     new Group {IsInfection = true, NoOfUnits = 801, UnitHealth = 4706, AttackType = DamageType.bludgeoning, Initiative = 1, AttackStrength = 116, Weaknesses = new HashSet<DamageType> { DamageType.radiation } },
            //     new Group {IsInfection = true, NoOfUnits = 4485, UnitHealth = 2961, AttackType = DamageType.slashing, Initiative = 4, AttackStrength = 12, Imunities = new HashSet<DamageType> { DamageType.radiation}, Weaknesses = new HashSet<DamageType> { DamageType.fire, DamageType.cold }},
            // };
            return new List<Group> {
                new Group {IsInfection = true, NoOfUnits = 1379, UnitHealth = 46709, AttackType = DamageType.slashing, Initiative = 16, AttackStrength = 66 },
                new Group {IsInfection = true, NoOfUnits = 1766, UnitHealth = 15378, AttackType = DamageType.radiation, Initiative = 10, AttackStrength = 12, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning }},
                new Group {IsInfection = true, NoOfUnits = 7691, UnitHealth = 33066, AttackType = DamageType.slashing, Initiative = 12, AttackStrength = 7, Weaknesses = new HashSet<DamageType> { DamageType.bludgeoning }},
                new Group {IsInfection = true, NoOfUnits = 6941, UnitHealth = 43373, AttackType = DamageType.fire, Initiative = 7, AttackStrength = 12, Weaknesses = new HashSet<DamageType> { DamageType.cold }},
                new Group {IsInfection = true, NoOfUnits = 5526, UnitHealth = 28081, AttackType = DamageType.bludgeoning, Initiative = 11, AttackStrength = 7, Weaknesses = new HashSet<DamageType> { DamageType.fire, DamageType.slashing }},
                new Group {IsInfection = true, NoOfUnits = 5844, UnitHealth = 41829, AttackType = DamageType.bludgeoning, Initiative = 20, AttackStrength = 11 },
                new Group {IsInfection = true, NoOfUnits = 370, UnitHealth = 25050, AttackType = DamageType.radiation, Initiative = 2, AttackStrength = 120, Imunities = new HashSet<DamageType> { DamageType.radiation }, Weaknesses = new HashSet<DamageType> { DamageType.fire }},
                new Group {IsInfection = true, NoOfUnits = 164, UnitHealth = 42669, AttackType = DamageType.fire, Initiative = 13, AttackStrength = 481 },
                new Group {IsInfection = true, NoOfUnits = 3956, UnitHealth = 30426, AttackType = DamageType.cold, Initiative = 8, AttackStrength = 13, Weaknesses = new HashSet<DamageType> { DamageType.radiation }},
                new Group {IsInfection = true, NoOfUnits = 2816, UnitHealth = 35467, AttackType = DamageType.slashing, Initiative = 1, AttackStrength = 24, Imunities = new HashSet<DamageType> { DamageType.slashing, DamageType.fire, DamageType.radiation }, Weaknesses = new HashSet<DamageType> { DamageType.cold }},
            };
        }

        private enum DamageType
        {
            slashing,
            bludgeoning,
            radiation,
            cold,
            fire,
        }

        public static int SolveProblem1()
        {
            var ImmuneSystem = GetImmuneSystem();
            var Infection = GetInfection();

            while (ImmuneSystem.Count() > 0 && Infection.Count() > 0)
            {
                var AllGroups = ImmuneSystem.Concat(Infection).ToList();
                AllGroups = AllGroups.OrderByDescending(g => g.EffectivePower).ThenByDescending(g => g.Initiative).ToList();
                foreach(var group in AllGroups)
                {
                    group.Attacker = null;
                    group.Attacking = null;
                }

                foreach(var group in AllGroups)
                {
                    group.Attacking = SelectTarget(group, group.IsInfection ? ImmuneSystem : Infection);
                    if (group.Attacking != null)
                        group.Attacking.Attacker = group;
                }

                AllGroups = AllGroups.OrderByDescending(g => g.Initiative).ToList();
                foreach (var group in AllGroups)
                {
                    Attack(group);
                }

                ImmuneSystem.RemoveAll(g => g.NoOfUnits == 0);
                Infection.RemoveAll(g => g.NoOfUnits == 0);
            }

            var winner = ImmuneSystem.Count() > 0 ? ImmuneSystem : Infection;

            return winner.Sum(g => g.NoOfUnits);
        }

        private static void Attack(Group attacker)
        {
            if (attacker.Attacking == null || attacker.NoOfUnits <= 0)
                return;
            var target = attacker.Attacking;
            var damage = attacker.EffectivePower;
            if (target.Weaknesses.Contains(attacker.AttackType))
                damage *= 2;

            int unitsKilled = damage / target.UnitHealth;
            target.NoOfUnits = Math.Max(0, target.NoOfUnits - unitsKilled);
        }

        private static Group SelectTarget(Group attacker, List<Group> possibleTargets)
        {
            return possibleTargets
                .Where(pt => pt.Attacker == null && !pt.Imunities.Contains(attacker.AttackType))
                .OrderByDescending(ft => {
                    var damage = attacker.EffectivePower;
                    if (ft.Weaknesses.Contains(attacker.AttackType))
                        damage *= 2;
                    return damage;
                })
                .ThenByDescending(ft => ft.EffectivePower)
                .ThenByDescending(ft => ft.Initiative)
                .FirstOrDefault();
                // .Select(ft => {
                //     var damage = attacker.EffectivePower;
                //     if (ft.Weaknesses.Contains(attacker.AttackType))
                //         damage *= 2;
                //     return new Tuple<int, Group>((damage / ft.UnitHealth) * ft.UnitHealth, ft);
                // })
                // .Where(t => t.Item1 > 0)
                // .OrderByDescending(t => t.Item1)
                // .ThenByDescending(ft => ft.Item2.EffectivePower)
                // .ThenByDescending(ft => ft.Item2.Initiative)
                // .Select(t => t.Item2)
                // .FirstOrDefault();
        }

        // public static int SolveProblem2()
        // {
        //     var maxBoost = 100;
        //     var minBoost = 1;

        //     while (!Fight(maxBoost).Item1)
        //     {
        //         minBoost = maxBoost;
        //         maxBoost *= 10;
        //     }

        //     Tuple<bool, int> result = new Tuple<bool, int>(false, -1);
        //     while (maxBoost != minBoost)
        //     {
        //         var boost = minBoost + ((maxBoost - minBoost) / 2);
        //         result = Fight(boost);
        //         if (result.Item1)
        //             maxBoost = boost;
        //         else
        //             minBoost = boost;
        //     }

        //     // Not 75, 76, 77, 78
        //     return result.Item2;
        // }
        public static int SolveProblem2()
        {
            var result = new Tuple<bool, int>(false, -1);
            var boost = 0;
            while (!result.Item1)
            {
                result = Fight(boost);
                boost++;
            }

            // Not 75, 76, 77, 78
            return result.Item2;
        }

        private static Tuple<bool, int> Fight(int boost)
        {
            var ImmuneSystem = GetImmuneSystem();
            foreach (var group in ImmuneSystem)
            {
                group.AttackStrength += boost;
            }
            var Infection = GetInfection();
            var previousImmuneUnits = int.MaxValue;
            var previousInfectionUnits = int.MaxValue;

            while (ImmuneSystem.Count() > 0 && Infection.Count() > 0)
            {
                var AllGroups = ImmuneSystem.Concat(Infection).ToList();
                AllGroups = AllGroups.OrderByDescending(g => g.EffectivePower).ThenByDescending(g => g.Initiative).ToList();
                foreach(var group in AllGroups)
                {
                    group.Attacker = null;
                    group.Attacking = null;
                }

                foreach(var group in AllGroups)
                {
                    group.Attacking = SelectTarget(group, group.IsInfection ? ImmuneSystem : Infection);
                    if (group.Attacking != null)
                        group.Attacking.Attacker = group;
                }

                AllGroups = AllGroups.OrderByDescending(g => g.Initiative).ToList();
                foreach (var group in AllGroups)
                {
                    Attack(group);
                }

                ImmuneSystem.RemoveAll(g => g.NoOfUnits == 0);
                Infection.RemoveAll(g => g.NoOfUnits == 0);

                var immuneUnits = ImmuneSystem.Sum(g => g.NoOfUnits);
                var infectionUnits =  Infection.Sum(g => g.NoOfUnits);
                if (immuneUnits == previousImmuneUnits && infectionUnits == previousInfectionUnits)
                    return new Tuple<bool, int>(false, -1);
                previousImmuneUnits = immuneUnits;
                previousInfectionUnits = infectionUnits;
            }

            return new Tuple<bool, int>(ImmuneSystem.Count > 0, ImmuneSystem.Sum(g => g.NoOfUnits));
        }
    }
}