namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day20
    {
        private const string ProblemInput = @"^NWWSESESENEESSW(N|WSEEEEESWSESWSSENEEENEEENESSENEENESSWSSSESSWWN(E|NWWNWSSEESSEEEEESSESSESSWNWSSSWNNWSSSWWWSESWWWWNNNESE(SWEN|)NEENNE(NENE(S|N(ESNW|)NWWN(WSWSES(ENEWSW|)SWSSWWWWWWSWNNNENNNNWWSESSWSSWNNWNE(NWNENNWNENWN(EEENEEEE(E(NWWEES|)EESENN|SWWSSSS(WNWNN(WSSSEWNNNE|)E(S|N)|EESEE(NWN(WWNNES|E)|SWWSEES(E|WWWSW(NNNNESS(NNWSSSNNNESS|)|S(W|EENEESW(ENWWSWENEESW|))))|E)))|WNNNNWN(WSSESSSSESWWWSSEEN(W|ES(E|SWSSE(SWSSSWNWSWNNEENNWNN(ESNW|)WNNNWWSWSWNNWWNNEEES(WW|S|ENESENESENNWN(NNNNWN(E|NWSSWWSSESWSS(WWNENNWSWNWWSESESWSSSSEESSWNWWWSSSSEENWNE(NWES|)EESSW(N|SSENEESSSWWWSWNWNWSWSESWWNNWSWWWWNENNWSWSSWWWWNENEE(SWEN|)NNNNEEESS(WW(NEWS|)S|ESSSENNEEE(SWWEEN|)EEE(SEEENSWWWN|)NWWWNWWW(SEEWWN|)WNENWNEENENNENNWSWWSS(ENSW|)WNWSS(EE|SWNWNENWWNNESEEENNNWSSWNWWWSSWNNWWNNWNNNNWWSESSSWWSEESWWSWWNNWNWWWSSENESESSWSWSWWNENEN(WWSWNNWWWWWNEENNNWSWWNENWNNWSWNNNEENEESSSEENEESWSWS(ESEEES(ENNEENWWNENWWSW(SESWWN|NNNNNWSWSESWWNW(NNNWWSWS(EENSWW|)WWS(E|WWNWNWNNNNEESSS(WNNSSE|)SE(ENNES(S|ENNWNNWW(WNNESEENWNNWSWNNEENNWWWNNNNNESSSENNNESSSS(ENNENENWW(S|NEENWNWWS(SWNNNWNNWNENWNWWNWWWSEESSSSENE(NNWSNESS|)SSSE(NN|SWWNNWWW(NENNNWSS(NNESSSNNNWSS|)|SEESWSEESSE(SSSSSE(EE|SWWNNWSWNW(SSSSSSESSESSSE(SSESWWSWW(SEESWSEESWSEESESESENNNN(WNNE(S|NNWW(N|S(SW(NW(NEWS|)S|SES(SESNWN|)W)|E)))|EESWSSSSWWWNWSWSSSWWNW(NNNNEN(EES(E|WS(E|WSSE(S|N)))|WNN(ESNW|)NN)|SSSESWSEESWWSSESWSSSESEESSWSWW(SSENESEESSWWWW(NEEEWWWS|)SSSSSESENNNEENN(ESEENNENWWS(WNNNWWNEENNNW(SS|NENWNNENNNESSSESSENNENWWNEENEESSSSW(SSW(WWW(NNWESS|)SSSENEN(W|EESWSESEENNW(S|NNESENESENESSSESSWWN(WNENWWSSSWSSSWNNNWWWN(WSW(SEEESSE(NN|SSWNWSSSEEN(ENESSENENWN(WW|EENWNN(WSSNNE|)(ESENESESSWSEENENNNW(SS|WNNENNW(NNNNNNNNEEESWWSEEEESSSEENESSWWSWNWWNNE(NWWWSESSS(WNNSSE|)SESSEEESESSEEEESENNNWNNNN(EESSW(SESENNNNESESWSSSSENENESSESENNWNENWWNENN(WW(S(SSWSNENN|)E|W)|ESSENESESSSENNESSSEESESSESESENEESWSSESESEESSSSSWNNNNWSWNWN(WWSESSWWN(NWSSSWSESESENNN(WSNE|)ESESSESWW(SWNWWSSE(EESWSWWS(WWNEN(WWSWS(WWNWNNWSWNWSSS(WWWNWNENWNENWNNEEENNWWS(WNNNWWSESSSSWWSESE(SSSS(E|WWWWWNWNNWNNNESES(SES(SEENWNE(ESSNNW|)NWNW(NNNWNEEE(NNNNESENNENNEENWNWSWWWNWWNWSSWNWNNN(WNN(ESNW|)NWW(SESSSESWW(WSSSESSSENEESWSWWWNNWN(E|NNNWWSESWWSEESWSWNWWWSWWSSSESSESWSSWNNWSWNNNNWNNNWWSESSWSSENESSSWNWWWWWNENEE(SWEN|)NWWNEE(NWNENEEENWN(WSWNWN(WSSESWSWS(E|SSWNW(SSE(SWSSE(EEESSSENNE(NWES|)SSENESSWSS(WWNWN(EESNWW|)WNWSSS(WNW(S|NNE(S|NEENWWWS(NEEESWENWWWS|)))|E(N|E))|ENESEENNENN(ENESSENESENNWWNW(W|NNESEENNW(NENN(WWNWSSW(WNEWSE|)SES(ENNEWSSW|)W|ESE(NNWESS|)ESWSEESWSSWNNW(SS(WW|SEEENEN(W|NNESS(SSWSESSWSS(WNWWNENWW(NEEES(E|S)|SSWNWWWSW(NN|S(WNSE|)EENESEEEE(WWWWNWESEEEE|)))|EE(N(N|W)|E))|EE(ESNW|)NNNNW(WS(ESS|WNWS)|NEEESE(SWWNSEEN|)NNNWWNN(WWNWNWS(WNSE|)SSE(N|EESSEE)|ESEN(NWES|)EES(EN|SWN))))))|NN))|S))|WWW(SSE(NEWS|)S|N(E|WW))))|N)|E)|NENN(W(N|S)|E)))|EEN(ESNW|)W)|EEESS(W(N|SSE(N|S(SSESWENWNN|)W))|ENE(S|N(WNSE|)ESEENWNENE(S|N(NNEWSS|)W))))|E))|NNN)|W(NN|W))|ES(S|EEE(NWWEES|)EEEEN(ESS(EES(W|ESSW(N|SEENNENENWW(S|N(EEEENE(ESE(N|ESSWWSSEEN(E(N|ESWSEEE(NWES|)S(E|WWSWWSWSS(ENSW|)WNNNNN(EES(WSNE|)E|WSSSSSWNNNNWWSESSSWSSEEEN(EESWSWSWWN(E|WWSSE(EESEES(ENNE(N(E|NWSWSW)|SS)|WSW(S|WN(NWWWNWSWW(SSE(SWEN|)N|NN(W|E(ENE(NNNW(WNWNEESEE(SSS|N(ESNW|)NW(S|WWN(WW(NEWS|)S(E|S(WN|SSE))|EEENEENE(S|ENNN(EE|WSW(N|S(WSWENE|)E)|N)))))|SS)|S)|S)))|E)))|N))|WW))))|W))|NWWNW(NNES|SSE))|W(WWNE(N|E)|S)))))|WWW(SEWN|)WW)|NW(NEWS|)S)))|SS(ENNSSW|)W(N|S))|S)|W)|W))|N)|E)|EE(NWES|)E)|E)|EE)|EEENESEEEEENWWWWNNW(NEENESENEEENWWN(NNENWNEEESENNNENNEENNWSWWWWNNEENWWWNENESENESSS(SWWEEN|)EENNESENEENWNENWWSWNWSW(S(EEE|SS)|NWSWWWNWSWNNWWSESSE(SWWSSENESESWWSESWS(EESENN(WNSE|)ES(ENSW|)SSWWWN|WNNNW(S(S|W)|NNWNNE(N(ESNW|)WNWSWSESSWWN(WNNWNENNWSWW(SEWN|)NENWWWN(N(EES(ENESSEENWNEENW(WWW|NE(ESSESSWW(NEWS|)SWSE(SWSSNNEN|)ENEE(S(W|S)|NENWNNEN(WWSNEE|)EESSW(W|SSES(ESEEE(SWEN|)ENNNE(SSENESES(WWW|ENN(ESSEESESSSSEEEENNNEEENNWSWWNNNNWNWWW(NEENNEESS(WNSE|)ENEENEESWSEEESWWWWW(NEWS|)SW(NWES|)SEES(WWSNEE|)ESEESSENENNNN(WSS(WNW(S|WN(W|EE))|S)|EEESSWW(NEWS|)SEEEESEEENNWNNNESEESW(SSSSWWWSWSEEESENEEENNWNENENENENWNNWSWSESWW(S(E|WS(E|SSS(E|WWW)))|NNWNW(S|NENNEENWNEESENEENNEE(NWWWWSS(ENSW|)WWWWNWNEESEENNW(S|WNWWNENNESES(W|SENNEEENESSE(SWS(WWNN(WSS|ES)|E)|NNNWNNNE(SS|NNNNWSWNWNEENE(NWNENWNNWNWSSWSWWSSWWNNWWNEEE(NENENE(SSWSWENENN|)NNNNENENESSWSWSSEEE(NN(WSWENE|)NNNNWWNWSWNWNNESENNEESS(WNSE|)SENNNNWWNNNENE(SSWSEWNENN|)NNWWNNNWWNEENWWNEEESE(SSSW(SEWN|)NN|NNNNNNWWNEENWNWNWNENWNEESSE(S(W|S)|NNNWNWNN(WWWWWSSWWWSEESESSESSWWWSWSESEENN(WSNE|)ESSEESE(ESSWS(EENNNSSSWW|)WNN(E|WNWSWNWSSSESWWNWNNE(NWNWSSWNWWWNWNWNEEENENEEE(ENWWWNEN(ESE(ESSEWNNW|)N|NNWWNN(ESENESEENW(ESWWNWESEENW|)|WWWWSESWWWWSWSESSEEEESE(SWWNWSSSWWNNN(ESSNNW|)WNWWSWSSSSSESSSWSESSWSSSENEENW(W|NNNEENWNENNWN(EEESWSEEE(NWNSES|)SWWSSSESSSWWSW(NNEN(ESNW|)N(WWSEWNEE|)NNN|SEEESSENESENNNWW(SEWN|)(WW|NNNNNEN(WWSNEE|)NNESE(N|ESE(SESWSESSWNWSSW(NWWNENWNENE(NWES|)ESSW(N|S)|SSSSSWWWSWWNN(NNWWSESSSWWSESSEEENEEEESESSENENNESSSENNEE(NNEE(SWEN|)NNNE(NEN(E|WWNNN(ESSNNW|)WNNNW(NENWN(W|E)|SSWSESSSE(S(E|SSSWWSSWNWWNNWNNNW(SSSSS(WWN(E|WSWWWSWN(SENEEEWWWSWN|))|SE(S|NN))|NEEN(ESSEE(SESWS(E|WSWNNN(ESNW|)W(S|N))|NNW(S|NNNN(ES|WSSS)))|W)))|NN)))|SSS)|SWSSWSESESSWSSE(SWWS(WWNENWWNWWNNENNWWWWWWSSSWWSSWNWNNE(NEE(SWEN|)NWNWNWWWNWWSWWSSEEESESSSE(NNNEN(E|WN(E|W(W(WW|N)|S)))|SWSWWSWWSWWNENENE(NWNWSWS(E|WS(WSSSWNNNWNENNWNEENNESEE(S(ENESE(ESW(SESWENWN|)W|N)|WSW(N|WS(E|S)))|NNNNNEE(SWEN|)ENWNNEENNWSWNNENWWSWNWSWWWWNWSSESWSWSWSEEEENN(WSWENE|)ESSSENE(SSWSES(WWWWNEENWWWN(EE|WWSESSSE(NN|EESWWWSWWNENNWSWNWWNENWWWNENESENENE(NNWWNNNNNWNNWSSWWSSENEESWSESWSESE(E|SWWWSWNNNNWSWWSEESSSWNNWWNNWNEENE(E(EESSSE|NNNNEENNWWWWNENWNNWNWNWNWNNWSWSSSWWNENWNENENWNNNEENEENWWWSWNNEENN(ESEEEN(EESSW(N|SWNW(SSSESESSSEESSSSENEEESSSENNENESEESWWSW(N|SSSW(SEEEESEESS(ENENNNNNENWWSWWN(WSSWN(WSSEEEES(W|E(NNWWEESS|)S)|N)|NE(S|NNESSENEES(W|SSEENEEE(SWWSSWNWSWW(NEWS|)SSSS(ENESENESENE(NWN(ENN(WSNE|)E|WWS(WNWSNESE|)E)|SSES(W|SENEE(SS(ENSW|)W(SWW(NEWS|)SEESWS(WWN(NWES|)E|EE(N|S(EES(SENEN(W|EESWS(EEE(EESSESWS(ESEE(NWNN(ESEWNW|)NNW(N|S)|S)|W)|NNW(NWWEES|)S)|W))|W)|WW)))|N)|NWN(NESNWS|)W(S|W))))|SW(W|N))|NN(ESNW|)WNNE(NWNWSWSSW(NWNNWNENESS(ENNNENENWNEESSS(ENNESE(NNNWNEE(S|EN(ESENSWNW|)WWWWSS(SEWN|)WWNENWWWSS(ENSW|)WSESWS(E|WNNWSWSSE(SWSWWWSSWWNNNNWSSWSWSEE(S(EEE(S(S|WW)|ENNESE(S(SE(NN|E)|W)|N))|WW(S|WWWNNESENNWNENEE(SWSNEN|)NNNNEESEEENEE(EENWWN(EEESNWWW|)WWS(E|WSWNWWWN(WWWSWNWSSEEESWSWNWW(WSW(SEESWSES(W|E(NE(S|NN(W(NWES|)S|E(S|ENE(NNNWESSS|)S)))|SSS))|W)|NNN)|EEEE))|SWSWSWSS(EEN(N|W)|W(NNN(E|WW(SEWN|)N)|SS)))))|N)|N|EE)))|E)|SS(WN(WSNE|)N|S))|S)|SS(S|EE(N(NN|W)|E)))|S)))))|WNWSSSSW(WWNEENNNNWW(SSE(SWEN|)N|W)|S(E|S)))|WNW(S|WNE(EESNWW|)NWN(NESNWS|)WSSSWNNWN(NWNWNWNE(ESE(N|S)|NNWW(S(E|S)|NE(E|NWNWSSW(NWS|SE))))|E))))|WW))|WW)|WWS(E|WSSSSSSWNNWNENNWSWSSSESWWWNENWWSSSWWSWSEESWSEESEESWSESWWSESWWWWSEEESEEN(EESSSSSWNWNEN(N|WWWSESWWWWNENN(ESSNNW|)WWWSWWWSSWNWWSSE(N|SSSEEESEEESENENENNEESEN(ESSWSESENNESEEENNESEE(ESSWNWSW(N|WWWSEESENESENESSSESSENNNEN(WNW(NEWS|)SS|ESSSESWW(SSSSESESSESWSWWNENNWWN(E|NWWSESSWWN(NWNWNEE(S|EEENWN(E|WWS(WNWSWNNEENNN(ESSESW|WWWSS(ENESNWSW|)SSSSWNWNWSWNNEEE(S|NNWNEN(E|WN(WSSWSES(WWNWNWWWNENN(NESE(NNWNSESS|)ESS(WWNE|EN|S)|WSWWSSWNWWNEN(ESNW|)WWWSESSSESWWNWNWSSWSSSENESSENEEEENEEENENE(ESESWSWN(N|WSSWWN(WSWWSEESESWWWN(WSWNWWWSEESWSWNWNWWNWNWSSESESWWNWSSEEEESEN(NWNSES|)ESSEEENWWNENENEESSW(W|SSESWWSSSEENESSWWWSSENESSES(ENNWNENENESESSS(WNW(NEWS|)S|ENEEE(SWWSEEESW(SSSE(NN|SWWSSWSESWWN(SEENWNSESWWN|))|WWWW(SE|NE))|NWWNW(NEEENNWSWNWNEEEESSEENWNENWNWWNWSS(WNWWS(WSWSS(EE(N(N|W)|E|S)|W(NNNENWW(NNESENN(WW|ENENEN(EESWSWSSE(EENEENWNNW(SSWSWENENN|)N(EESEESE(ESSWNWSSESWW(SESSSESWSSWS(WWN(WW|EN(E|W))|EENNENNE(E|SS|NWNW(S|NENNE(NN|EESENE(NEWS|)SS(WWWW(NEWS|)S|SSENESESEEESENENEEEENWNNWWNEENNE(NNWNE(E|N(WWWSWSSENE(S(SSWNWWWSW(SSESSE(NE(ES(ENSW|)W|NWN(ENWESW|)W)|SWWNNW(W(SESNWN|)WW|N))|NWNNNESES(W|ENNWNENWNE(ESSNNW|)NWWSSW(NNNN(ESNW|)W(S|NN)|S(WW(SES|NE)|E))))|E)|N)|N))|SE(SSS(WNNSSE|)ESSW(N|SWSSWSWS(WNNW(SSS(EE|WNNNW(SSSSEWNNNN|)WNWSWN)|NEE(ENWWEESW|)S)|EEESENENEEESSESESWWSSSSENEENWN(WSNE|)EESENNEENWWWW(SEWN|)NNW(WNENENNEEESEENNW(WNNNWNENWN(ENE(ESENEENEESWSWWSEESWWWNWW(SSSEN(N|EEEEENENN(WSNE|)NNE(NWWNEENN(E|WSWNWSSSWWS(NEENNNSSSWWS|))|SSESSW(N|SWSESWWNWWSESESENESSWSWSSEEENN(WSWENE|)ENEEEENN(WNWN(E|WWN(ENWNE(NNW(WNEWSE|)S|EEE)|WSSSS(EEN(NWS|ESE)|S)))|ESESESE(NNNNEN(WWSS(W|S)|NE(SSSWENNN|)N)|ESSE(NESNWS|)SWSSE(SWSWWNENWNENNWN(E|WSWWWSEESWSS(EE(N(NNEWSS|)W|S)|WNNWWWSSENESSWSE(ENSW|)SSWSSE(NEEWWS|)SSWNWWSESEEE(N|S(ENSW|)WSS(ENSW|)WSESWWNNWNN(ESENSWNW|)NWSWSESWWWWS(WNNNNWNNWSWSESS(WNWSWSWNWNENE(S|ENWNENNWSWWSESW(WNNNENE(S|N(EEN(EENWWNEENNESEENEESSW(WWWSESSENEN(ESENEE(ESS(SWSS(ENSW|)WWSS(ENSW|)WS(SWNNNWS(SSSEEWWNNN|)WNNWWNW(SS|N(EN(E(SEES(SEE(S|NENN(E(ENWESW|)SS|WSW(N|S)))|WW)|N)|W)|WW))|E)|E)|NWWNNEN(WWWWNENWNEN(NWWS(SSSWNWN(ENNNN(E(NW|SE)|WW)|WSSES(EESNWW|)WWWNNE(S|NWW(NEWS|)S(SS|W)))|E)|E)|E(SSWENN|)ENNESSENNEN(EE(SWEN|)(N|E)|WW)))|W)|N)|WW)|WWSW(WWNNNN(WSNE|)NN(NNWESS|)E|SS)))|S))|E(SS|N))|ESS(WNSE|)ENESENE(NWWWEEES|)SESWSS(WNNSSE|)E(SEWN|)N))))|N))))))|N)|N)|WSWSSE(N|SSE(SWWWSSWSWWWNNW(SSWW(NENSWS|)S(W|E)|NENWNEN(N(EEESE(SESWWNWNWSSSE(ESWSWN|N)|NN)|NN)|WW))|N)))|S)|S)))|N)))))))|WN(ENNNW|WS))|NN)|W(WW|N))|SWWN(WSSNNE|)N)|WW(S|W)))|W|SSSWWS)|S))|E)|EE)|S)))|WWNWW(SEWN|)NWNNNE(SS|NNWWS(WWWNENWWSSSW(NNW(NENN(ESE(EES(S|EEE)|N)|WSWWNENWW(SSSEEWWNNN|)NNWSWNNENWNNWSWNWNNENNNESSSES(ESENESSSW(NWES|)SEE(SSWNSENN|)ENWNENNW(S|NWWNNNNNENWNWSWWSEESW(WWNNWWW(SW(SEEE(NWES|)SWWSWSW(NN(N|E)|SEENE(NESNWS|)SSWWSESS(WNSE|)ESEES(WWWNSEEE|)E(SWS(E|S)|NNWWNWN(SESEESNWWNWN|)))|N)|NEENWNNEES(SSEENWNENEEEENWWNWWS(W(S|NWSWWNWNEE(NNNWNNWSSSESWWNNNWNWSSESSW(SEEWWN|)WN(NNNNNNESES(E(NNNW(S|WNNWSSWSWWNNNWNEENWNNESEEEEEENNWNNNWNENEESWSSEESW(W|SEEESWWWSSWWSESWS(ESSENNNNEESENESSWSSSSSSEESWSSWNNW(NWNENWWN(WSNE|)ENNE(NWNSES|)SS|SSSEEEEENWWNEEESESS(EEEEE(SESSSE(SSS(ESNW|)WNWWSSE(SWSWSWWS(EESS(WWNEWSEE|)E(EES(WW(SEWN|)W|EEENES)|NNN)|WNWNW(NEESENE(S|ENWWNEENWNNESENE(SEWN|)NNWSWWWW(NNEES(ENEWSW|)W|SESSWSW(NN(E|WNWN(WS|EES))|S(E|W))))|S))|N)|EE)|NNNNWWNENEENWNWNNESENNWNENENESESESENENE(NNWNEENEENNWNNESENNWWNEEEEN(ES(SWSSWNN(SSENNEWSSWNN|)|ENE(E|S))|WWWWWWWSWNWSWNWSWWWN(WWSESWWSSSSESWWNNNNWNNN(EESWSNENWW|)WWWWSEESSSSWNNWSWSESESEESE(SENEESSEE(SWSWWWWSSWNNNN(EEE(N|S(WW|E))|NWSWW(WWN(WWSEWNEE|)ENE(SENEWSWN|)NWNWNNNWNENWW(WN(EEEESS(EE|S)|WSWNWWWWWWWSSWWSW(SEENEENNEESSW(N|SSSWNW(NEWS|)SS(WNWSW(NNEEWWSS|)SSSENES(ENNWWEESSW|)SWSW(N|SEE(SSE(S(WWNW(NEWS|)S|EES(W|E(N|S)))|NN)|N))|EEENNEE(NNW(SWEN|)NEN(ESNW|)W|ESWWSEES(E|WWW))))|NNEENWW(EESWWSNEENWW|)))|SSS(ESSNNW|)W)|SEESSWSESESSESEE(SSWNWWNWNNWWW(SSENESSES(W|EESEEEESWWWSEEE(WWWNEEWWSEEE|))|NE(N(NNEWSS|)W|E))|NNE(NWW(WSESNWNE|)NEN(W|E(S|E))|S(S|E)))))|NNEEENEENES(EENWNWNWSWWWWSWNNN(NEEEES(ENESEEN(NESSSS(SE|WNW)|W)|WWWSEEE(WWWNEEWWSEEE|))|WWSES(W|SS(SS|EEENEE)))|SSS(W(SEWN|)NNWS(WWWSNEEE|)S|E)))|NNNW(SWEN|)N(E|NNN))|EE))|ESSW(WSESSS(SSWWNENWWNWWW(SEESESS(WNWW(NEWS|)W(SEESWW|W)|E)|NNESEN(NWNWSNESES|)EES(ESWENW|)W|W)|EEENWWNNENESS(ENSW|)W)|N)))|W(N|W)))|WNNNWWWS(SSW(N|S)|EE))))|S)|W)|E)|S))|E)|W))|SESWSES(NWNENWESWSES|)))|WW))|S)|SESWWWSEESE(SS|NEENWNN(SSESWWEENWNN|)))|E)))|N)|E)|E))|NWWW(S(E|SWWNN(ESNW|)W(NWES|)SSSWWWN(W(N|W)|EE))|NN)))|E)|N))))|E)))|E))|NN)))|NNNNENNESS(SWEN|)ENNE(SS|NN(WSWNNWNWWNENE(NWWN(E|W(SS(E|WNWWWNWW(SESWSESS(WWNEWSEE|)ENENE(NWWSNEES|)SEE(NWES|)SWSWSWSW(NNENEWSWSS|)SSSEES(EEE(S|NWWNWWNENENEEE(SSWSWN(NEWS|)W|N(ESNW|)W(NEWS|)W))|WS(WWNE|ESW))|NWWNNW(S|N(W|ENEEEEESWSWS(ESWENW|)WWNEN(E|W)))))|N(N|E)))|ES(S|W))|EE)))|NWWWWSWNWNWSSESS(ENEWSW|)WWN(E|NNNW(NEEENE|SSWW(NE|SEE))))))|W))))|S))|SSWSSE(N|E))))|S)|NWNNWN(WSNE|)EEEESSW(NWS|SESW)))|E))|S))|S)|E)|NE(NNNEN(WWN(N|E)|E)|S)))|E(S|EEE)))|N))))|NNNW(SSW(SESS(E|SS)|NN)|N)))|NE(NE(NN(ESNW|)WNNWSSWWWWSSEEN(EE(SWEN|)E|W)|S)|S))))|SWSSWW(NENSWS|)W(SEEWWN|)W)|S))|NNWNW(NNNNNE(SSSSESE(WNWNNNSSSESE|)|NNWW(NEEESSE(WNNWWWEEESSE|)|S(W|SS|E)))|S))|EES(W|S))))|SW(SESSNNWN|)WW)|SS)|S)))))|SWSESSSSSSWSW(SEE(N|SWWSW(N|WSSW(N|SESWSSWSWSSESENN(EEESWSESENNNNNWNNENE(NWWW(S(SSWSES(WW|E)|E)|NEENES)|SS(SSSSSSSWSWSESWSWSWSWSEESSSWSS(EEENW(NEE(SS|NNWSWNNN(W|EN(NE(SSSWENNN|)NNN|W)))|W)|WWNNE(NWWNNNWWSESSWWSWSWS(EEEENE(NWWSWENEES|)S|WWWNENWNENWWSWSWWNENENWWSWWNNWWWNNNWSSWWWSEEESESSESWSWS(WWNWSWNWWS(WNNENNNNNWNENNNNNWSWWSEESSWNWSWSSSSWSEEES(ENNNWNW(NE|SSE)|WSESSWWWNE(NNWSWNWSWSWS(EENESNWSWW|)WWWNNEE(SWEN|)ENWWN(EEE(S|NNNENEE(NNNE(NWNWSW(NNEEEES(W|ENENENWWNENWW(WWSSEE(NWES|)S(E|WW)|NEEE(NNW(N(N|E)|S)|SEEEESEEN(W|NNEEN(ENNESSEESWSESWSSWWSWWWSESENEESENN(ESSSWWSEESWSSS(WNWSWNNNWNEE(SSENSWNN|)N(WWWWSWSE(ENSW|)SWWWNNNW(SSSSSSSE(SWSSEEN(NEE(NWWEES|)SWSE(ENNSSW|)S|W)|NNNEEE)|NN(W|ENNW(S|N(W|EESSEE(SWWS(E(SWSSNNEN|)EE|W)|N(W|EEENWNNESENNESSSW(ENNNWSNESSSW|)))))))|N)|S(EENWNEENNW(SWEN|)NNENNENESENNNENN(ESSEEN(WNSE|)EE(SSSSWWWNEN(WWSW(N|SESWSWSSWSESWW(NNN(NE(S|N(W|E))|W)|SS(WNSE|)SEENN(WSNE|)ENNEENWWNENEES(W|SEESEESWS(E(SSSEES|ENENNE(NN(E|WN(WWSWN(N|WSW(NWWEES|)SEEEE(N|S(WW|S)|E))|NN|E))|S))|WNWW(NEWS|)WSW(N|SSSE(SWSW(S|NNNN)|E(NWNENE|E)))))))|E(N|S))|NE(S|E))|WSWNNENN(E|WWN(WSSE(SSWSW(NN(E|NN)|SS(WNSE|)E(SWSSNNEN|)EN(ESNW|)(N|W))|E)|EE)))|S))|W)|WW)))))|SSE(N|SWW(NNN|SWNWSS(SSENNSSWNN|)WWNENN)))|S)|SWS(SSWNNSSENN|)E))|WSW(N|SWNWSWN(SENESEWNWSWN|)))|E))|E)|EENENN(NWNEWSES|)EESWSS(ENESENESENN(SSWNWSNESENN|)|W)))|S))|W))|W))))|NWNEENWWWNEENN(ESSNNW|)WSWWSSWNWSSE(WNNESEWNWSSE|)))))|W))|SSS(ENE(NWES|)SE(SWW(W|SSENESSSWNWS(NESENNSSWNWS|))|N)|WNNW(NEWS|)SS))|W))|NWN(ENWESW|)WWSSE(SSWNW(WN(NE(S|NNW(S|N(E|WNNWSS)))|W)|S)|N))|WW)|N))|NNNW(SS|NENE(SEWN|)NWWWN(WSSSENE(WSWNNNSSSENE|)|EEN(N|W)))))|W)|N)|W)|E)|S)))|E))|WWW(SEEWWN|)NNW(SS|N(W(S|N)|E)))|S))|N)|NN)|E)|E))|N)|WSSWWW(N(WSWNW(NWES|)S|NESENNNE(NNNNNNWSSSWNNWNWWSS(WNNWNENENNN(ESESWSS(W|EE(S|EENWNW(SWEN|)NENN(WSWNSENE|)(ESE(N|SESSEN(N|ESSS(E(EE|N)|WWW(N(NNWNSESS|)EE|SSSS(ENE(NNWSNESS|)S|S)))))|NN)))|WSWS(WS(E|SWNWWSS(E(N|EE)|WWWSSEEE(NWWEES|)SWWSESS(E(SSS|NN)|WWN(E|NWN(E|NW(NENNEENNE(NWNNWSWNWSWWSWNWWWSEESWSWNWW(WW(SES(ES(WSESWW(SSE(NEWS|)SSW(SE|WNE)|W)|EN(NWES|)ESESENEEENE(NNW(SWNWSWS(EE|W)|NEESSENN(SSWNNWESSENN|))|S))|W)|W)|NENWNEEEEEE(E|NNN(W(N|SS)|EE)))|SS)|SSSESWW(EENWNNSSESWW|)))))))|E))|E(SE(S(WS|EES)|N)|N))|S))|SEEESS(WWNEWSEE|)E))|S)|S))|N))|W))|N)|N|E)|E)))|NN)|NNN))|S)|WWS(E|W(N|SS)))|NN(E(E|S)|N))))|NENENWNW(SS|NN(ESNW|)NN))|NNNNNENNN(WWSW(NNEWSS|)SE(ENSW|)SS|ESSSSW))|NNNENWN(NN|EESSESSWNWS(NESENNSSWNWS|))))|NNEENN)))|E))|WW)|SESWSS))|S))|SS))|WWSS(WNW(S|N(N|E))|E(N|S)))|WWN(WNN(N|WW)|E))|E))))|EEENW(NNE(NWWEES|)S|W)))|E))|N)))|EESSSS))|E)|EE))|SS)))$";
        private const string ProblemTestInput = @"^ENWWW(NEEE|SSE(EE|N))$";
        private const string ProblemTestInput2 = @"^ENNWSWW(NEWS|)SSSEEN(WNSE|)EE(SWEN|)NNN$";

        public static int SolveProblem1()
        {
            var input = ProblemInput;
            // var input = ProblemTestInput2;
            var mapWidth = 10000;
            var mapHeight = 10000;
            // var mapWidth = 20;
            // var mapHeight = 20;
            var map = new char[mapWidth, mapHeight];
            for (var x = 0; x < mapWidth; x++)
            {
                for (var y = 0; y < mapWidth; y++)
                {
                    map[x,y] = '#';
                }
            }
            var currentX = mapWidth/2;
            var currentY = mapHeight/2;
            map[currentX, currentY] = 'X';

            ParseRegex(input.Substring(1, input.Length - 2), map, new Tuple<int, List<Tuple<int, int>>>(0, new List<Tuple<int, int>>{ new Tuple<int, int>(currentX, currentY) }));

            //PrintMap(map);
            var trimmedMap = TrimMap(map);
            PrintMap(trimmedMap);

            return FindLongestShortestPath(trimmedMap);
        }

        private static int FindLongestShortestPath(char[,] map)
        {
            var posx = -1;
            var posy = -1;

            for (var y = 0; y < map.GetLength(1) && posx == -1; y++)
            {
                for (var x = 0; x < map.GetLength(0) && posx == -1; x++)
                {
                    if (map[x,y] == 'X')
                    {
                        posx = x;
                        posy = y;
                    }
                }
            }

            var distances = new int[map.GetLength(0), map.GetLength(1)];

            for (var y = 0; y < distances.GetLength(1); y++)
            {
                for (var x = 0; x < distances.GetLength(0); x++)
                {
                    distances[x,y] = -1;
                }
            }

            distances[posx, posy] = 0;
            FillInMinDistances(map, distances, posx, posy, 0);

            return distances.Cast<int>().Max();
        }

        private static void FillInMinDistances(char[,] map, int[,] distances, int posx, int posy, int distance)
        {
            var newDistance = distance + 1;
            if (map[posx + 1, posy] == '|' &&
                (distances[posx + 2, posy] == -1 || distances[posx + 2, posy] > newDistance))
            {
                distances[posx + 2, posy] = newDistance;
                FillInMinDistances(map, distances, posx + 2, posy, newDistance);
            }
            if (map[posx - 1, posy] == '|' &&
                (distances[posx - 2, posy] == -1 || distances[posx - 2, posy] > newDistance))
            {
                distances[posx - 2, posy] = newDistance;
                FillInMinDistances(map, distances, posx - 2, posy, newDistance);
            }
            if (map[posx, posy + 1] == '-' &&
                (distances[posx, posy + 2] == -1 || distances[posx, posy + 2] > newDistance))
            {
                distances[posx, posy + 2] = newDistance;
                FillInMinDistances(map, distances, posx, posy + 2, newDistance);
            }
            if (map[posx, posy - 1] == '-' &&
                (distances[posx, posy - 2] == -1 || distances[posx, posy - 2] > newDistance))
            {
                distances[posx, posy - 2] = newDistance;
                FillInMinDistances(map, distances, posx, posy - 2, newDistance);
            }
        }

        private static Tuple<int, List<Tuple<int, int>>> ParseRegex(string regex, char[,] map, Tuple<int, List<Tuple<int, int>>> positions)
        {
            var finalPositions = new List<Tuple<int, int>>();
            var currentPositions = positions.Item2;
            var index = positions.Item1;
            while (index < regex.Length)
            {
                if ("NSEW".Contains(regex[index]))
                {
                    var newPositions = new List<Tuple<int, int>>();
                    foreach (var position in currentPositions)
                    {
                        var currentX = position.Item1;
                        var currentY = position.Item2;
                        switch(regex[index])
                        {
                            case 'N':
                                map[currentX, currentY+1] = '-';
                                map[currentX+1, currentY+1] = '#';
                                map[currentX-1, currentY+1] = '#';
                                map[currentX, currentY+2] = '.';
                                newPositions.Add(new Tuple<int, int>(currentX, currentY+2));
                                break;
                            case 'S':
                                map[currentX, currentY-1] = '-';
                                map[currentX+1, currentY-1] = '#';
                                map[currentX-1, currentY-1] = '#';
                                map[currentX, currentY-2] = '.';
                                newPositions.Add(new Tuple<int, int>(currentX, currentY-2));
                                break;
                            case 'E':
                                map[currentX+1, currentY] = '|';
                                map[currentX+1, currentY+1] = '#';
                                map[currentX+1, currentY-1] = '#';
                                map[currentX+2, currentY] = '.';
                                newPositions.Add(new Tuple<int, int>(currentX+2, currentY));
                                break;
                            case 'W':
                                map[currentX-1, currentY] = '|';
                                map[currentX-1, currentY+1] = '#';
                                map[currentX-1, currentY-1] = '#';
                                map[currentX-2, currentY] = '.';
                                newPositions.Add(new Tuple<int, int>(currentX-2, currentY));
                                break;
                        }
                    }

                    index++;
                    currentPositions = newPositions;
                }
                else
                {
                    // control
                    switch(regex[index])
                    {
                        case '(':
                            var subResult = ParseRegex(
                                    regex,
                                    map,
                                    new Tuple<int, List<Tuple<int, int>>>(
                                        index+1,
                                        currentPositions
                                    )
                                );
                            currentPositions = subResult.Item2;
                            index = subResult.Item1;
                            break;
                        case ')':
                            finalPositions.AddRange(currentPositions);
                            finalPositions = finalPositions.Distinct().ToList();
                            return new Tuple<int, List<Tuple<int, int>>>(index+1, finalPositions);
                        case '|':
                            finalPositions.AddRange(currentPositions);
                            currentPositions = positions.Item2;
                            index++;
                            break;
                    }
                }
            }
            return new Tuple<int, List<Tuple<int, int>>>(index, finalPositions);
        }

        private static char[,] TrimMap(char[,] map)
        {
            var minX = int.MaxValue;
            var maxX = int.MinValue;
            var minY = int.MaxValue;
            var maxY = int.MinValue;

            for (var y = 0; y < map.GetLength(1); y++)
            {
                for (var x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x,y] != '#')
                    {
                        minX = Math.Min(minX, x);
                        maxX = Math.Max(maxX, x);
                        minY = Math.Min(minY, y);
                        maxY = Math.Max(maxY, y);
                    }
                }
            }

            var width = maxX - minX + 3;
            var height = maxY - minY + 3;

            var trimmed = new char[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    trimmed[x,y] = map[x + minX - 1, y + minY - 1];
                }
            }

            return trimmed;
        }

        private static void PrintMap(char[,] map)
        {
            Console.WriteLine();
            for (var y = map.GetLength(1) - 1; y >= 0; y--)
            {
                for (var x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x,y]);
                }
                Console.WriteLine();
            }
        }

        public static int SolveProblem2()
        {
            var input = ProblemInput;
            // var input = ProblemTestInput2;
            var mapWidth = 10000;
            var mapHeight = 10000;
            // var mapWidth = 20;
            // var mapHeight = 20;
            var map = new char[mapWidth, mapHeight];
            for (var x = 0; x < mapWidth; x++)
            {
                for (var y = 0; y < mapWidth; y++)
                {
                    map[x,y] = '#';
                }
            }
            var currentX = mapWidth/2;
            var currentY = mapHeight/2;
            map[currentX, currentY] = 'X';

            ParseRegex(input.Substring(1, input.Length - 2), map, new Tuple<int, List<Tuple<int, int>>>(0, new List<Tuple<int, int>>{ new Tuple<int, int>(currentX, currentY) }));

            //PrintMap(map);
            var trimmedMap = TrimMap(map);
            PrintMap(trimmedMap);

            return FindNumberOfPaths(map);
        }

        private static int FindNumberOfPaths(char[,] map)
        {
            var posx = -1;
            var posy = -1;

            for (var y = 0; y < map.GetLength(1) && posx == -1; y++)
            {
                for (var x = 0; x < map.GetLength(0) && posx == -1; x++)
                {
                    if (map[x,y] == 'X')
                    {
                        posx = x;
                        posy = y;
                    }
                }
            }

            var distances = new int[map.GetLength(0), map.GetLength(1)];

            for (var y = 0; y < distances.GetLength(1); y++)
            {
                for (var x = 0; x < distances.GetLength(0); x++)
                {
                    distances[x,y] = -1;
                }
            }

            distances[posx, posy] = 0;
            FillInMinDistances(map, distances, posx, posy, 0);

            return distances.Cast<int>().Count(d => d >= 1000);
        }
    }
}