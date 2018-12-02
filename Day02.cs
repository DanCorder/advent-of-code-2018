namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day02
    {
        private const string Problem1Input = @"luojygedpvsthptkxiwnaorzmq
lucjqgedppsbhftkxiwnaorlmq
lucjmgefpvsbhftkxiwnaorziq
lucjvgedpvsbxftkxiwpaorzmq
lrcjygedjvmbhftkxiwnaorzmq
lucjygedpvsbhftkxiwnootzmu
eucjygedpvsbhftbxiwnaorzfq
lulnygedpvsbhftkxrwnaorzmq
lucsygedpvsohftkxqwnaorzmq
lucjyaedpvsnhftkxiwnaorzyq
lunjygedpvsohftkxiwnaorzmb
lucjxgedpvsbhrtkxiwnamrzmq
lucjygevpvsbhftkxcwnaorzma
lucjbgedpvsbhftrxiwnaoazmq
llcjygkdpvhbhftkxiwnaorzmq
lmcjygxdpvsbhftkxswnaorzmq
lucpygedpvsbhftkxiwraorzmc
lucjbgrdpvsblftkxiwnaorzmq
lucjfgedpvsbhftkxiwnaurzmv
lucjygenpvsbhytkxiwnaorgmq
luqjyredsvsbhftkxiwnaorzmq
lucjygedpvavhftkxiwnaorumq
gucjygedpvsbhkxkxiwnaorzmq
lucjygedpvsbhftkxlwnaordcq
lucjygedpvibhfqkxiwnaorzmm
lucjegedpvsbaftkxewnaorzmq
kucjygeqpvsbhfokxiwnaorzmq
lugjygedwvsbhftkxiwnatrzmq
lucjygedqvsbhftdxiwnayrzmq
lucjygekpvsbuftkxiwnaqrzmq
lucjygedpvsbhfbkxiwnaoozdq
lscjygedpvzchftkxiwnaorzmq
luckygedpvsbxftkxiwnaorvmq
luyjygedgvsbhptkxiwnaorzmq
lmcjygedpvsbhfckxiwnaodzmq
lucmygedwvybhftkxiwnaorzmq
lgcjhgedavsbhftkxiwnaorzmq
lucjugedpvsbhftkxiwmaoozmq
lucjygedpvybhftkxkwnaorumq
lucjygedpvzbhfakxiwnaorzpq
lucjygedpvsbhftyxzwnajrzmq
lucjygedpvsdhfakxiwnoorzmq
luyjygeopvhbhftkxiwnaorzmq
lucjygadpvsbhntkxiwnaorzmx
lucjygedzvsbhftkiiwuaorzmq
sucjygodpvsbhftkxiwuaorzmq
euijygydpvsbhftkxiwnaorzmq
lucjlgeduvsbhftkxicnaorzmq
lucjdgedpvsbhfgkxiwnhorzmq
lucjymedpvsbhotkxiqnaorzmq
lucjygmdpvsbhftkxywnairzmq
lucjggedpvsbhfxkxiqnaorzmq
sucjygedpvsbhftkxiwnaorjmv
lucjlgedpvsbhftkxiwnairzmg
lucjygedppubhftkxijnaorzmq
lucjyxedpvsvhftkxlwnaorzmq
lucjygedpvxbhftkfiwyaorzmq
lucjygedposbhftkniwnaorzmw
lucjygewpvsbhftgxiwnavrzmq
lucjynedpvsbmftkaiwnaorzmq
lucjyhedpvzbhftkxiwncorzmq
lucjygedpvsbhfikpiwnaoezmq
lupjypedpvsbhftkjiwnaorzmq
lucjygudpvsbhfwkxivnaorzmq
lucjygrdpvsbhatkxzwnaorzmq
lucjbgmdpvsbhftkxihnaorzmq
lucjmgedpvpbhftkxiwnaorcmq
lucjygedpvskhfukmiwnaorzmq
lucjygedgvsbhftkxiwnvprzmq
lucjzgedppsbhytkxiwnaorzmq
lfcjypedpvsbhftrxiwnaorzmq
lucjyqldphsbhftkxiwnaorzmq
lucjygedpvsbhftzxewnaorzqq
lucjygeapvsbhftkxiinoorzmq
lucjygedpvszhftguiwnaorzmq
luojygedpvsbhftkxawnaornmq
lucjygedpcsboetkxiwnaorzmq
lufjygedpvfbhftaxiwnaorzmq
luciygedpvsbhftkxhwaaorzmq
lucjygedpvnbhftkaiwnaorzmc
lucjygedpvsbhftkxiwcaorbdq
lucjygelpvsbhftaxiwsaorzmq
lujjygedpssbhftkxiwnaorzmr
ludjygedpvsbhftkxiynaorzmj
lukjygeedvsbhftkxiwnaorzmq
lucjqpedpvsbhftkxiwnaozzmq
jucjygedpvsbhftkxgwnaorqmq
llwjygedpvsbhetkxiwnaorzmq
rucjygedpvsbhftkxiwndorymq
lucjygedpvsbhftvxswnaorwmq
lucjygerpvsbhfykxiwnaormmq
lucjynedpvsbhftkxijnaorziq
ljcjygedpvrbhftkeiwnaorzmq
lucjygedpnsbhftkxiwhaornmq
lucjygadpvsbhftkxibnaorzqq
lucjqgedpvsihftkxiwnaorzdq
lucjygedpvsqhfttjiwnaorzmq
llcjygedsvsbhftkxiwwaorzmq
lfckygedpvsbhftkxiunaorzmq
lucjyeedpdsbhftkxiwnaotzmq
lucjygedpvsbhftkoiwnaoqzcq
huwjvgedpvsbhftkxiwnaorzmq
lucjygldpvsbdhtkxiwnaorzmq
lycxygedpvsbhftmxiwnaorzmq
lucjygedpvsbhftyxianvorzmq
lucuygedpdsbhqtkxiwnaorzmq
lucjyggdpvsbhftkxiwnavremq
lucjyggdpvsbkftkxiwnaorbmq
luchyqedpvsbhftixiwnaorzmq
lpcnygedpvsbhftkxzwnaorzmq
lucjygedpvsihftkxiwfaortmq
lucjygvdpvsbhgtkxiwnamrzmq
lucjygodpvrbhqtkxiwnaorzmq
lucjygedpfsbhftkxipnaorzma
lucjygedpvsbhftkxpcjaorzmq
lucjygodbmsbhftkxiwnaorzmq
lucjygedpvsbhftkxipnaogzmb
luxjygjdpvsbhltkxiwnaorzmq
lucxygedpvsbhftkxzwnaorjmq
luajygedpvsbhftzxiwaaorzmq
lhcjygedpvsqhftfxiwnaorzmq
lucjygecphsbhftkxiwnaprzmq
lucjygedpvsbhptkxifnaorqmq
lucjygedpvichftkpiwnaorzmq
lucjygedpcsbhstkxswnaorzmq
kucjygedpvsbhftkxiwbyorzmq
lfpjxgedpvsbhftkxiwnaorzmq
lucjytldpvsbhftkxiwdaorzmq
lufjygedpvfbhftbxiwnaorzmq
lucjygebpvgbhftkxipnaorzmq
luujygedpvdbhftkxiwnaorzmd
lucjygedpvsbhfbyxwwnaorzmq
lucjygedpvsbhftkxiwnaoqpmw
qucgygedpvsbhftkxiwnaortmq
ludjtgedpvsbhftkxiunaorzmq
lucjyiedovsbhftkxiwjaorzmq
lucjygedpysbjftoxiwnaorzmq
lumjygedpvsbuftkxiknaorzmq
lucjygedpvsbhfokxgonaorzmq
lucjygeqpvsbhftkfiwnaorzeq
lucjygedpvskhftkxiwntorkmq
luujygedpvsbhftkxiwraorzmt
lucwygedpvsbjftkxiwnaorzmj
jucjyfedcvsbhftkxiwnaorzmq
luujygedpnsehftkxiwnaorzmq
lucjygedpvszhfckxiwnaorzmi
lucjyredpvsbzftkpiwnaorzmq
lucjygedpvsbwfgkxiwnaorzoq
lucjygedpvgbhftkpiwnaorzms
lucjygedpvjbhftkxzwnaoizmq
vucjycedpvsbhftkxiwfaorzmq
luawygeapvsbhftkxiwnaorzmq
lucjygetpvsbhftkxiwnaafzmq
lucjvgedpvsbhftkxywnavrzmq
luolygedpvsbgftkxiwnaorzmq
likjygedpvsbhftkxiwnabrzmq
lucjygedovsbhftkxirpaorzmq
lucjygedphsshftkxqwnaorzmq
uuqjygewpvsbhftkxiwnaorzmq
lucjygedcvsbhftkxiwoarrzmq
lucnygedpvsbhfakxiwnaorzms
lucjygedpvsbhntkxiwnawrzmb
lucjygedpvsblfxkxivnaorzmq
lucjygedpvsghftkxiwnaawzmq
yucjygedpgsbhftkxiwnaorzbq
lucjyweapvsbhftkxiwnaoezmq
lucjygevpvsbyftcxiwnaorzmq
luejygedovsbhftkxiwnqorzmq
lucjyqedpvsbhfbkxiwnaorzms
lucjypedpvsbhftwxiwnhorzmq
lucjygedpvsbhmtkviwxaorzmq
lucjogedpvpbhftkxiwnaorqmq
lucjygedpvsbhztkxkwnaoazmq
lucjyaedpvsbcftkxiwnaorzhq
lucjygbdpvkbhftkxiznaorzmq
lucpygedpvzbhftkxfwnaorzmq
lucjmgedpcsbhftkxiwnaoezmq
lucjygedyvsbbftkxiwnnorzmq
lucjyyedpvsbhftuxiwnaonzmq
lucjygfdpvsbhutkxiwnaorzmt
uccjygedpvschftkxiwnaorzmq
lusjygedpvbbhqtkxiwnaorzmq
ducuygedpvsbhftkxiwnaorzyq
lucjygkdvwsbhftkxiwnaorzmq
cucjyyedpvsbhftkxiwnaerzmq
lucjygedavsbhftkxiwnkorzbq
lucjygedmvsyhftkxiwiaorzmq
lucjygeipvsbhfpkxiwnaorzpq
vucjugedvvsbhftkxiwnaorzmq
lucjyzedpvsbhftkxpwnaoozmq
lucjygedpvgbhftkxiwtaorzqq
lecjygedpvcwhftkxiwnaorzmq
lucjyghdpvsbhfcyxiwnaorzmq
lucjygedpvesqftkxiwnaorzmq
lucjyjehpvsbhftbxiwnaorzmq
lucjygedpvtbhdtkxignaorzmq
lucjygxdpgsbhftkxivnaorzmq
lucjygvdpvsbhftkpiwnaorzqq
lucjysedpvsbhftkxiwnalrzmc
lucjygedpvkbhjtkxiwnaorsmq
lucjygedpvsbvfgkxiwnaerzmq
lucjygedpvsihftkxilnaorzmu
lvcvygndpvsbhftkxiwnaorzmq
lucjysedpqsbhftkxiwnaordmq
lucsygeypvsbhftkwiwnaorzmq
lucjygewpotbhftkxiwnaorzmq
lucjysedpvsbhftkxiwnanrzmv
lucjygedpvsbhutkxiwnaoplmq
wucjygedpvsqbftkxiwnaorzmq
lacjygeepvsbhftkxiwnjorzmq
lucjygedpusyhftkxicnaorzmq
qucjyredpvsbhftkxiwnworzmq
lucjygedevsbhftkgiwnayrzmq
lucjygedpksbrftkliwnaorzmq
lucjygedpvsbhfgkxisnaorzeq
lucjygedpvhdhftkeiwnaorzmq
lucjsgedpvsboftkxiwnaorumq
luctygedpvsbhftouiwnaorzmq
lucjygedpvsjhfukjiwnaorzmq
lucjagrepvsbhftkxiwnaorzmq
lucjkgerpvsbhftkxiwnairzmq
turjygedpvsbnftkxiwnaorzmq
lbcjygedpvsbhftkdpwnaorzmq
lucpygedpvsbhftkxnwnoorzmq
jucjygedpvsbhbtkxicnaorzmq
lecjygedpvsbhftkriwnaogzmq
licjyvcdpvsbhftkxiwnaorzmq
lrcjygewpnsbhftkxiwnaorzmq
ltcxygedpvlbhftkxiwnaorzmq
luctygedpvhbhztkxiwnaorzmq
lucwygedplsbhfakxiwnaorzmq
lucjygedpnsbhftkxiwjaoezmq
lucpygedptsbhftkxiwnaorzmo
lucjygedpvibhqtkxiknaorzmq
lucjwgqdpvrbhftkxiwnaorzmq
lucjmgkdpvsbhftkxiwraorzmq
lucjygwupvsbhftkxiznaorzmq
lucjhgedpvobhftkxiwncorzmq
lucjygedpvsbhftkxiwnaohtmj
lucjygedpvsbeftkfiwnaorzyq
lucjygcdpvsbpftkhiwnaorzmq
lucjygedpmsbhftkxiwnkouzmq
oucjygedpvsbyftkximnaorzmq
lucjcgedpvsbhftkxywnforzmq
lfcjygedfvsbdftkxiwnaorzmq
ducjygedevsbhfttxiwnaorzmq
ldcjdgedpvsbhftkxiwnavrzmq
lucjymedmvsbhqtkxiwnaorzmq
lucjygedpvabhftkxiwnasrlmq
lucjygefpvsbhftkxmwnaorkmq";

        public static int SolveProblem1()
        {
            var ids = Problem1Input.SplitToLines();
            var twoCount = 0;
            var threeCount = 0;

            foreach(var id in ids)
            {
                var counts = id.GroupBy(c => c);
                if (counts.Any(count => count.Count() == 2))
                {
                    twoCount++;
                }
                if (counts.Any(count => count.Count() == 3))
                {
                    threeCount++;
                }
            }


            return twoCount * threeCount;
        }

        public static string SolveProblem2()
        {
            var ids = Problem1Input.SplitToLines().ToList();

            for (var i=0; i<ids.Count-1; i++)
            {
                for (var j=i+1; j<ids.Count; j++)
                {
                    var matchingLetters = CheckMatch(ids[i], ids[j]);
                    if (matchingLetters != null)
                    {
                        return matchingLetters;
                    }
                }
            }

            return "No match found!";
        }

        private static string CheckMatch(string s1, string s2)
        {
            var differencePosition = -1;
            for (int i=0; i<s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (differencePosition != -1)
                    {
                        return null;
                    }
                    differencePosition = i;
                }
            }
            if (differencePosition == -1)
            {
                return null;
            }

            return s1.Substring(0, differencePosition) + s1.Substring(differencePosition + 1);
        }
    }
}