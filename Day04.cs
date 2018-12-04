namespace advent_of_code_2018
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day04
    {
        private const string Problem1Input = @"[1518-05-08 00:12] falls asleep
[1518-09-09 00:04] Guard #1543 begins shift
[1518-04-05 00:00] Guard #131 begins shift
[1518-09-12 00:54] falls asleep
[1518-08-28 00:12] falls asleep
[1518-06-06 00:25] wakes up
[1518-06-30 00:35] falls asleep
[1518-09-29 00:30] falls asleep
[1518-03-28 00:56] wakes up
[1518-06-03 00:19] wakes up
[1518-05-08 00:44] wakes up
[1518-08-01 00:27] falls asleep
[1518-09-06 00:11] wakes up
[1518-07-08 23:58] Guard #1997 begins shift
[1518-09-10 00:02] falls asleep
[1518-09-12 00:01] falls asleep
[1518-10-13 00:59] wakes up
[1518-06-10 00:41] wakes up
[1518-08-14 00:47] falls asleep
[1518-04-06 00:27] wakes up
[1518-08-21 00:22] wakes up
[1518-06-03 00:18] falls asleep
[1518-07-08 00:03] falls asleep
[1518-08-27 00:00] falls asleep
[1518-06-16 23:49] Guard #353 begins shift
[1518-09-24 23:59] Guard #449 begins shift
[1518-07-04 00:14] falls asleep
[1518-07-14 00:46] falls asleep
[1518-07-16 00:44] wakes up
[1518-05-16 23:58] Guard #2539 begins shift
[1518-11-17 00:44] falls asleep
[1518-08-10 00:41] wakes up
[1518-06-15 00:59] wakes up
[1518-03-20 00:58] wakes up
[1518-11-23 00:52] wakes up
[1518-10-08 00:35] falls asleep
[1518-04-16 00:37] wakes up
[1518-08-07 00:52] wakes up
[1518-03-15 00:35] wakes up
[1518-08-18 00:52] wakes up
[1518-07-08 00:38] falls asleep
[1518-11-17 00:09] falls asleep
[1518-08-09 00:33] falls asleep
[1518-11-21 00:04] falls asleep
[1518-10-29 00:36] wakes up
[1518-10-22 00:41] wakes up
[1518-04-16 00:43] wakes up
[1518-08-21 00:49] falls asleep
[1518-04-22 00:26] wakes up
[1518-05-07 00:54] falls asleep
[1518-05-02 00:21] falls asleep
[1518-04-18 00:51] falls asleep
[1518-09-30 00:22] wakes up
[1518-08-30 00:18] falls asleep
[1518-11-08 23:48] Guard #2053 begins shift
[1518-08-03 00:45] falls asleep
[1518-07-30 00:53] wakes up
[1518-09-10 00:13] wakes up
[1518-08-18 23:48] Guard #1063 begins shift
[1518-10-11 00:46] wakes up
[1518-05-30 00:03] Guard #1153 begins shift
[1518-03-30 23:58] Guard #2539 begins shift
[1518-05-02 00:46] falls asleep
[1518-05-19 00:02] falls asleep
[1518-08-15 00:29] wakes up
[1518-05-09 00:16] falls asleep
[1518-08-27 00:44] wakes up
[1518-07-05 00:19] wakes up
[1518-06-17 00:37] falls asleep
[1518-04-17 00:36] falls asleep
[1518-06-04 00:59] wakes up
[1518-10-23 00:53] wakes up
[1518-04-22 00:15] falls asleep
[1518-10-15 00:00] Guard #2351 begins shift
[1518-05-23 00:28] falls asleep
[1518-08-06 00:34] wakes up
[1518-10-27 00:03] falls asleep
[1518-09-26 00:04] Guard #2539 begins shift
[1518-10-06 00:52] wakes up
[1518-08-16 00:00] Guard #3271 begins shift
[1518-08-03 00:03] Guard #2671 begins shift
[1518-03-21 00:38] wakes up
[1518-05-18 23:46] Guard #1997 begins shift
[1518-05-18 00:02] Guard #2411 begins shift
[1518-03-19 00:00] Guard #2539 begins shift
[1518-06-11 00:04] falls asleep
[1518-07-29 00:31] falls asleep
[1518-03-18 00:57] falls asleep
[1518-07-12 00:42] wakes up
[1518-05-02 00:00] Guard #1543 begins shift
[1518-09-09 00:53] wakes up
[1518-08-23 00:00] Guard #1543 begins shift
[1518-08-13 00:19] falls asleep
[1518-08-14 23:57] Guard #2539 begins shift
[1518-05-08 00:04] Guard #569 begins shift
[1518-10-02 00:27] falls asleep
[1518-07-09 00:58] wakes up
[1518-11-04 00:00] Guard #2053 begins shift
[1518-03-27 23:53] Guard #1543 begins shift
[1518-08-25 00:46] falls asleep
[1518-10-02 00:41] wakes up
[1518-04-23 00:11] wakes up
[1518-10-11 00:20] falls asleep
[1518-08-28 00:47] wakes up
[1518-11-22 00:00] Guard #1489 begins shift
[1518-04-17 00:58] wakes up
[1518-08-31 00:41] wakes up
[1518-06-12 00:25] falls asleep
[1518-11-09 00:02] falls asleep
[1518-09-27 00:01] Guard #449 begins shift
[1518-07-14 00:33] falls asleep
[1518-04-24 00:20] falls asleep
[1518-05-07 00:49] wakes up
[1518-05-29 00:56] wakes up
[1518-09-05 23:54] Guard #1063 begins shift
[1518-09-14 00:51] falls asleep
[1518-09-20 00:01] Guard #1153 begins shift
[1518-11-03 00:40] falls asleep
[1518-04-21 00:24] wakes up
[1518-08-06 00:45] falls asleep
[1518-10-27 00:40] wakes up
[1518-06-29 00:57] falls asleep
[1518-04-12 00:41] wakes up
[1518-05-04 00:17] falls asleep
[1518-10-04 00:02] falls asleep
[1518-05-20 00:02] Guard #2411 begins shift
[1518-11-11 00:22] wakes up
[1518-07-28 00:59] wakes up
[1518-03-17 00:58] wakes up
[1518-09-04 00:01] falls asleep
[1518-04-19 00:35] falls asleep
[1518-09-09 23:49] Guard #2671 begins shift
[1518-07-15 00:02] Guard #2351 begins shift
[1518-03-28 00:48] falls asleep
[1518-11-12 00:46] wakes up
[1518-06-09 23:57] Guard #2311 begins shift
[1518-08-30 00:03] Guard #131 begins shift
[1518-09-25 00:35] wakes up
[1518-06-03 00:47] wakes up
[1518-07-10 00:50] wakes up
[1518-05-22 00:15] wakes up
[1518-03-29 00:11] falls asleep
[1518-10-20 00:16] falls asleep
[1518-10-10 00:53] wakes up
[1518-11-16 00:06] falls asleep
[1518-10-26 00:48] falls asleep
[1518-05-05 00:02] falls asleep
[1518-08-25 00:20] wakes up
[1518-08-18 00:01] falls asleep
[1518-09-15 00:32] wakes up
[1518-10-25 00:09] wakes up
[1518-06-04 00:55] falls asleep
[1518-07-27 00:52] wakes up
[1518-04-12 00:01] Guard #2351 begins shift
[1518-04-27 00:01] Guard #2053 begins shift
[1518-08-22 00:57] falls asleep
[1518-08-22 00:58] wakes up
[1518-11-20 23:46] Guard #1879 begins shift
[1518-10-29 00:53] wakes up
[1518-06-14 00:54] falls asleep
[1518-10-15 23:59] Guard #2351 begins shift
[1518-06-18 00:58] wakes up
[1518-11-14 00:31] falls asleep
[1518-03-19 00:07] falls asleep
[1518-09-10 23:58] Guard #2539 begins shift
[1518-10-13 00:15] falls asleep
[1518-06-16 00:24] falls asleep
[1518-11-23 00:37] falls asleep
[1518-04-26 00:15] wakes up
[1518-03-22 00:29] falls asleep
[1518-11-13 00:01] Guard #1063 begins shift
[1518-07-24 23:59] Guard #1153 begins shift
[1518-03-16 00:21] wakes up
[1518-07-14 00:56] wakes up
[1518-05-18 00:57] wakes up
[1518-06-01 00:57] wakes up
[1518-07-15 00:17] falls asleep
[1518-07-17 00:57] falls asleep
[1518-10-16 00:36] wakes up
[1518-11-11 00:02] falls asleep
[1518-05-26 00:05] falls asleep
[1518-10-09 00:04] Guard #449 begins shift
[1518-09-05 00:32] falls asleep
[1518-07-10 00:37] falls asleep
[1518-09-28 00:48] falls asleep
[1518-06-07 00:28] falls asleep
[1518-06-03 00:00] Guard #2311 begins shift
[1518-05-28 23:58] Guard #1031 begins shift
[1518-05-04 23:51] Guard #353 begins shift
[1518-10-16 23:57] Guard #2539 begins shift
[1518-07-30 23:57] Guard #3371 begins shift
[1518-04-09 00:44] falls asleep
[1518-03-21 00:46] wakes up
[1518-10-21 00:40] wakes up
[1518-10-28 00:02] falls asleep
[1518-04-06 00:11] falls asleep
[1518-05-10 00:55] wakes up
[1518-10-18 00:57] wakes up
[1518-05-14 00:25] falls asleep
[1518-09-05 00:54] falls asleep
[1518-09-06 00:49] wakes up
[1518-06-07 00:04] Guard #1879 begins shift
[1518-11-10 23:51] Guard #569 begins shift
[1518-10-05 00:30] falls asleep
[1518-06-26 00:30] falls asleep
[1518-07-06 00:50] falls asleep
[1518-05-24 00:36] falls asleep
[1518-08-26 23:54] Guard #353 begins shift
[1518-09-21 00:02] Guard #3371 begins shift
[1518-04-22 00:52] falls asleep
[1518-08-10 00:03] falls asleep
[1518-11-19 23:53] Guard #353 begins shift
[1518-04-26 00:36] falls asleep
[1518-08-04 00:40] wakes up
[1518-06-05 23:46] Guard #1063 begins shift
[1518-07-09 00:20] falls asleep
[1518-05-13 00:45] wakes up
[1518-05-14 00:26] wakes up
[1518-08-11 00:21] wakes up
[1518-06-15 23:50] Guard #1063 begins shift
[1518-11-19 00:15] falls asleep
[1518-04-07 00:04] Guard #1619 begins shift
[1518-07-31 00:24] falls asleep
[1518-10-25 00:14] falls asleep
[1518-10-06 00:46] falls asleep
[1518-05-17 00:35] falls asleep
[1518-07-30 00:57] falls asleep
[1518-04-29 00:04] Guard #1879 begins shift
[1518-04-11 00:24] falls asleep
[1518-11-14 23:56] Guard #2671 begins shift
[1518-06-14 00:04] falls asleep
[1518-05-23 00:00] Guard #2671 begins shift
[1518-08-01 00:48] wakes up
[1518-08-07 00:45] falls asleep
[1518-10-22 23:59] Guard #307 begins shift
[1518-05-25 00:21] wakes up
[1518-11-19 00:22] wakes up
[1518-10-12 00:10] falls asleep
[1518-03-17 00:43] falls asleep
[1518-09-13 00:07] falls asleep
[1518-06-25 00:54] wakes up
[1518-04-02 00:50] wakes up
[1518-05-25 00:30] falls asleep
[1518-04-01 23:46] Guard #1997 begins shift
[1518-10-21 00:24] falls asleep
[1518-10-26 00:03] Guard #1153 begins shift
[1518-04-09 00:55] wakes up
[1518-05-06 00:56] wakes up
[1518-03-17 00:47] wakes up
[1518-09-28 00:04] Guard #1997 begins shift
[1518-04-25 00:14] falls asleep
[1518-08-17 00:03] falls asleep
[1518-09-03 23:49] Guard #2351 begins shift
[1518-06-10 23:50] Guard #2411 begins shift
[1518-05-02 00:38] wakes up
[1518-04-08 00:59] wakes up
[1518-07-17 00:30] falls asleep
[1518-10-29 00:00] Guard #2671 begins shift
[1518-06-17 00:04] falls asleep
[1518-08-02 00:55] falls asleep
[1518-10-27 00:46] falls asleep
[1518-05-24 23:49] Guard #1543 begins shift
[1518-09-11 00:42] wakes up
[1518-05-10 00:25] wakes up
[1518-04-27 00:49] wakes up
[1518-07-28 00:04] Guard #3371 begins shift
[1518-07-29 00:46] wakes up
[1518-10-10 00:45] wakes up
[1518-04-11 00:33] wakes up
[1518-07-04 00:21] falls asleep
[1518-04-05 00:08] falls asleep
[1518-04-15 00:48] wakes up
[1518-11-10 00:03] Guard #293 begins shift
[1518-04-26 00:02] Guard #353 begins shift
[1518-08-04 00:20] falls asleep
[1518-03-15 00:56] wakes up
[1518-10-07 00:16] falls asleep
[1518-04-09 00:02] falls asleep
[1518-06-03 00:34] falls asleep
[1518-08-08 00:27] falls asleep
[1518-08-16 23:51] Guard #2539 begins shift
[1518-06-24 00:00] Guard #353 begins shift
[1518-03-31 00:43] wakes up
[1518-10-30 00:37] falls asleep
[1518-05-10 00:04] falls asleep
[1518-07-08 00:43] wakes up
[1518-11-01 00:38] wakes up
[1518-09-10 00:29] falls asleep
[1518-07-30 00:04] Guard #1879 begins shift
[1518-04-17 00:06] falls asleep
[1518-07-07 00:38] wakes up
[1518-07-31 00:33] wakes up
[1518-09-20 00:55] wakes up
[1518-10-22 00:23] falls asleep
[1518-05-30 00:46] wakes up
[1518-11-15 00:31] falls asleep
[1518-04-05 00:21] wakes up
[1518-08-25 00:33] wakes up
[1518-07-22 00:41] wakes up
[1518-11-18 00:13] wakes up
[1518-07-05 00:42] falls asleep
[1518-06-23 00:00] Guard #131 begins shift
[1518-11-12 00:02] Guard #131 begins shift
[1518-07-29 00:57] wakes up
[1518-04-20 00:02] Guard #1543 begins shift
[1518-06-07 00:52] falls asleep
[1518-05-04 00:54] falls asleep
[1518-06-17 00:32] wakes up
[1518-06-09 00:00] Guard #1063 begins shift
[1518-10-17 00:34] falls asleep
[1518-06-16 00:02] falls asleep
[1518-09-05 00:48] wakes up
[1518-06-08 00:59] wakes up
[1518-10-04 00:21] wakes up
[1518-07-02 00:36] falls asleep
[1518-08-03 00:58] wakes up
[1518-07-01 00:03] Guard #569 begins shift
[1518-10-03 00:31] wakes up
[1518-08-22 00:42] wakes up
[1518-09-02 00:27] falls asleep
[1518-11-03 00:30] wakes up
[1518-04-28 00:10] falls asleep
[1518-04-27 00:57] wakes up
[1518-06-13 00:45] wakes up
[1518-07-02 00:50] wakes up
[1518-08-29 00:11] falls asleep
[1518-05-20 00:47] wakes up
[1518-09-21 00:35] wakes up
[1518-06-02 00:54] wakes up
[1518-08-08 00:54] wakes up
[1518-07-18 00:42] wakes up
[1518-07-29 00:01] Guard #2053 begins shift
[1518-10-08 00:47] wakes up
[1518-05-16 00:32] falls asleep
[1518-09-07 23:57] Guard #1031 begins shift
[1518-04-04 00:00] Guard #2539 begins shift
[1518-04-28 00:42] wakes up
[1518-08-13 00:00] Guard #1031 begins shift
[1518-03-25 00:09] falls asleep
[1518-05-13 00:18] falls asleep
[1518-04-03 00:21] wakes up
[1518-05-31 23:58] Guard #2053 begins shift
[1518-07-14 00:03] Guard #1879 begins shift
[1518-10-24 23:57] Guard #307 begins shift
[1518-09-21 00:49] wakes up
[1518-09-19 00:37] wakes up
[1518-09-08 00:15] falls asleep
[1518-05-03 00:59] wakes up
[1518-09-08 00:45] wakes up
[1518-05-25 00:56] wakes up
[1518-07-01 00:43] wakes up
[1518-06-02 00:41] falls asleep
[1518-06-07 23:57] Guard #2351 begins shift
[1518-04-15 00:28] falls asleep
[1518-10-28 00:47] wakes up
[1518-04-21 00:52] wakes up
[1518-07-12 00:08] falls asleep
[1518-06-09 00:55] wakes up
[1518-07-13 00:57] wakes up
[1518-09-15 00:56] wakes up
[1518-06-19 00:43] wakes up
[1518-04-18 23:57] Guard #2411 begins shift
[1518-10-06 00:02] Guard #449 begins shift
[1518-05-23 00:46] wakes up
[1518-04-16 00:03] Guard #353 begins shift
[1518-08-08 00:08] falls asleep
[1518-06-30 00:02] Guard #1997 begins shift
[1518-09-13 00:45] wakes up
[1518-08-24 00:40] wakes up
[1518-11-05 00:55] wakes up
[1518-03-14 23:57] Guard #1063 begins shift
[1518-07-20 23:59] Guard #1063 begins shift
[1518-05-11 00:38] wakes up
[1518-08-25 00:26] falls asleep
[1518-10-30 00:15] falls asleep
[1518-09-29 00:45] falls asleep
[1518-09-05 00:03] Guard #2539 begins shift
[1518-07-25 00:49] wakes up
[1518-05-12 00:14] wakes up
[1518-06-21 00:29] wakes up
[1518-03-16 00:19] falls asleep
[1518-04-17 00:57] falls asleep
[1518-04-29 00:58] wakes up
[1518-09-21 00:22] falls asleep
[1518-07-22 23:57] Guard #1153 begins shift
[1518-08-15 00:43] falls asleep
[1518-10-02 23:54] Guard #1879 begins shift
[1518-09-29 23:58] Guard #2351 begins shift
[1518-06-28 00:53] wakes up
[1518-04-11 00:38] falls asleep
[1518-07-17 00:19] wakes up
[1518-05-09 23:51] Guard #131 begins shift
[1518-10-03 00:00] falls asleep
[1518-09-21 00:45] falls asleep
[1518-09-08 00:58] wakes up
[1518-05-17 00:46] wakes up
[1518-04-01 00:01] falls asleep
[1518-11-10 00:10] wakes up
[1518-10-27 00:48] wakes up
[1518-06-30 00:18] falls asleep
[1518-07-16 00:04] Guard #2351 begins shift
[1518-08-06 23:56] Guard #1997 begins shift
[1518-05-23 00:49] falls asleep
[1518-08-15 00:44] wakes up
[1518-06-24 00:51] wakes up
[1518-03-17 00:53] falls asleep
[1518-04-12 00:56] falls asleep
[1518-06-18 23:56] Guard #2351 begins shift
[1518-11-15 00:43] wakes up
[1518-10-12 00:51] wakes up
[1518-11-14 00:56] falls asleep
[1518-08-14 00:02] Guard #3371 begins shift
[1518-09-25 00:56] wakes up
[1518-10-06 00:24] falls asleep
[1518-05-09 00:48] falls asleep
[1518-10-30 00:18] wakes up
[1518-04-03 00:49] wakes up
[1518-05-04 00:22] wakes up
[1518-08-31 00:00] Guard #1031 begins shift
[1518-09-02 00:00] Guard #353 begins shift
[1518-06-30 00:54] falls asleep
[1518-06-14 00:51] wakes up
[1518-05-13 00:32] falls asleep
[1518-08-21 00:54] wakes up
[1518-03-23 00:00] Guard #1153 begins shift
[1518-05-30 00:33] falls asleep
[1518-06-21 00:04] falls asleep
[1518-04-06 00:03] Guard #1619 begins shift
[1518-06-30 00:59] wakes up
[1518-05-04 00:59] wakes up
[1518-08-11 00:30] falls asleep
[1518-06-19 00:14] falls asleep
[1518-07-18 00:15] falls asleep
[1518-06-25 00:02] Guard #353 begins shift
[1518-07-22 00:25] falls asleep
[1518-05-10 00:36] falls asleep
[1518-08-29 00:36] wakes up
[1518-11-20 00:06] wakes up
[1518-09-16 23:56] Guard #331 begins shift
[1518-07-09 00:25] wakes up
[1518-09-14 00:39] wakes up
[1518-05-12 00:28] falls asleep
[1518-03-19 23:56] Guard #1031 begins shift
[1518-08-27 00:55] falls asleep
[1518-11-05 00:41] falls asleep
[1518-06-27 00:57] wakes up
[1518-06-26 00:04] Guard #2053 begins shift
[1518-07-11 00:00] Guard #449 begins shift
[1518-09-01 00:04] Guard #2671 begins shift
[1518-07-09 00:55] falls asleep
[1518-06-05 00:09] falls asleep
[1518-07-06 00:59] wakes up
[1518-05-07 00:01] falls asleep
[1518-04-30 00:46] falls asleep
[1518-03-26 23:53] Guard #2539 begins shift
[1518-09-24 00:22] falls asleep
[1518-09-30 00:13] falls asleep
[1518-09-29 00:48] wakes up
[1518-07-21 23:56] Guard #449 begins shift
[1518-08-08 00:33] wakes up
[1518-07-23 00:14] wakes up
[1518-06-14 00:38] falls asleep
[1518-10-25 00:30] wakes up
[1518-09-11 00:45] falls asleep
[1518-06-13 00:40] wakes up
[1518-11-07 23:57] Guard #1543 begins shift
[1518-03-23 00:22] falls asleep
[1518-04-12 00:58] wakes up
[1518-05-10 00:40] wakes up
[1518-11-16 00:52] wakes up
[1518-08-02 00:51] wakes up
[1518-06-04 23:59] Guard #2311 begins shift
[1518-11-20 00:00] falls asleep
[1518-04-14 00:28] wakes up
[1518-07-12 00:54] falls asleep
[1518-05-10 00:22] falls asleep
[1518-05-27 00:02] falls asleep
[1518-04-19 00:52] wakes up
[1518-04-20 00:23] wakes up
[1518-11-01 00:01] Guard #1063 begins shift
[1518-08-09 00:50] falls asleep
[1518-10-23 00:37] falls asleep
[1518-06-18 00:37] falls asleep
[1518-07-23 23:58] Guard #2351 begins shift
[1518-06-22 00:52] wakes up
[1518-10-12 00:28] wakes up
[1518-11-06 00:35] falls asleep
[1518-09-28 00:22] wakes up
[1518-07-25 00:06] falls asleep
[1518-05-04 00:00] Guard #449 begins shift
[1518-04-06 00:42] wakes up
[1518-09-22 00:15] falls asleep
[1518-11-23 00:12] falls asleep
[1518-07-27 00:03] Guard #1619 begins shift
[1518-08-11 23:51] Guard #569 begins shift
[1518-06-13 23:53] Guard #131 begins shift
[1518-11-18 00:02] falls asleep
[1518-08-11 00:56] wakes up
[1518-09-07 00:00] Guard #449 begins shift
[1518-06-20 23:53] Guard #1619 begins shift
[1518-05-21 00:04] Guard #2411 begins shift
[1518-06-12 00:51] falls asleep
[1518-05-02 00:35] falls asleep
[1518-05-05 00:52] wakes up
[1518-04-30 00:58] wakes up
[1518-07-03 00:52] wakes up
[1518-08-05 00:50] falls asleep
[1518-07-23 00:33] falls asleep
[1518-03-21 23:57] Guard #1153 begins shift
[1518-04-11 00:48] wakes up
[1518-08-26 00:01] Guard #331 begins shift
[1518-05-09 00:55] wakes up
[1518-10-03 23:48] Guard #2351 begins shift
[1518-09-20 00:54] falls asleep
[1518-05-10 00:13] wakes up
[1518-05-13 00:27] wakes up
[1518-10-10 23:56] Guard #449 begins shift
[1518-06-14 23:57] Guard #2351 begins shift
[1518-07-06 00:53] wakes up
[1518-09-29 00:00] Guard #2411 begins shift
[1518-11-06 00:01] Guard #2671 begins shift
[1518-04-29 00:29] falls asleep
[1518-09-11 00:24] falls asleep
[1518-04-08 23:50] Guard #293 begins shift
[1518-11-04 00:25] falls asleep
[1518-03-14 00:55] wakes up
[1518-04-07 23:59] Guard #1879 begins shift
[1518-03-31 00:46] falls asleep
[1518-06-22 00:05] falls asleep
[1518-06-29 00:43] falls asleep
[1518-04-07 00:45] wakes up
[1518-05-14 00:44] wakes up
[1518-09-06 00:31] falls asleep
[1518-11-19 00:00] Guard #1153 begins shift
[1518-05-07 00:25] wakes up
[1518-09-03 00:46] wakes up
[1518-09-14 23:46] Guard #1997 begins shift
[1518-08-07 00:37] wakes up
[1518-11-16 23:59] Guard #2539 begins shift
[1518-09-02 00:59] wakes up
[1518-10-26 00:58] wakes up
[1518-03-20 00:18] falls asleep
[1518-11-06 00:49] wakes up
[1518-05-14 00:36] falls asleep
[1518-04-24 00:54] wakes up
[1518-09-28 00:55] wakes up
[1518-03-17 00:06] falls asleep
[1518-10-30 23:58] Guard #2053 begins shift
[1518-06-30 00:23] wakes up
[1518-06-12 00:47] wakes up
[1518-09-08 00:50] falls asleep
[1518-04-17 00:41] wakes up
[1518-04-29 00:47] wakes up
[1518-11-03 00:51] wakes up
[1518-03-30 00:09] wakes up
[1518-08-31 00:16] falls asleep
[1518-11-15 23:59] Guard #353 begins shift
[1518-10-08 00:07] falls asleep
[1518-04-16 00:42] falls asleep
[1518-09-02 00:37] falls asleep
[1518-07-28 00:11] falls asleep
[1518-07-18 00:04] Guard #1997 begins shift
[1518-08-14 00:48] wakes up
[1518-04-10 00:57] wakes up
[1518-11-22 23:57] Guard #2053 begins shift
[1518-05-18 00:56] falls asleep
[1518-05-14 00:47] falls asleep
[1518-04-14 23:58] Guard #2671 begins shift
[1518-05-09 00:26] wakes up
[1518-05-23 00:53] wakes up
[1518-04-04 00:26] falls asleep
[1518-11-16 00:18] wakes up
[1518-07-09 00:29] falls asleep
[1518-04-27 23:53] Guard #1153 begins shift
[1518-08-21 00:03] Guard #1619 begins shift
[1518-06-21 00:58] wakes up
[1518-10-20 00:01] Guard #1997 begins shift
[1518-10-02 00:55] wakes up
[1518-09-12 00:10] wakes up
[1518-05-03 00:01] Guard #2311 begins shift
[1518-10-04 00:45] falls asleep
[1518-05-06 00:14] falls asleep
[1518-05-15 00:53] falls asleep
[1518-08-11 00:18] falls asleep
[1518-10-05 00:01] Guard #2351 begins shift
[1518-06-14 00:12] wakes up
[1518-03-27 00:21] wakes up
[1518-07-03 00:28] falls asleep
[1518-10-10 00:38] wakes up
[1518-11-14 00:59] wakes up
[1518-04-27 00:15] falls asleep
[1518-06-17 23:59] Guard #3371 begins shift
[1518-08-12 00:01] wakes up
[1518-06-06 00:32] falls asleep
[1518-09-10 00:42] wakes up
[1518-04-20 00:29] falls asleep
[1518-08-01 00:51] falls asleep
[1518-10-01 00:55] wakes up
[1518-08-24 23:53] Guard #1543 begins shift
[1518-05-14 00:03] Guard #307 begins shift
[1518-03-23 00:55] wakes up
[1518-10-24 00:26] wakes up
[1518-04-21 00:19] falls asleep
[1518-10-24 00:31] falls asleep
[1518-09-26 00:21] falls asleep
[1518-10-10 00:31] falls asleep
[1518-04-10 23:57] Guard #1063 begins shift
[1518-09-09 00:08] falls asleep
[1518-07-30 00:20] falls asleep
[1518-08-19 00:44] falls asleep
[1518-11-13 00:41] wakes up
[1518-05-15 23:56] Guard #3371 begins shift
[1518-10-14 00:03] Guard #353 begins shift
[1518-10-10 00:03] Guard #3371 begins shift
[1518-06-12 00:09] wakes up
[1518-06-04 00:51] wakes up
[1518-07-12 23:57] Guard #1619 begins shift
[1518-03-17 00:00] Guard #2311 begins shift
[1518-05-12 00:40] falls asleep
[1518-08-19 23:58] Guard #1489 begins shift
[1518-04-29 23:56] Guard #1153 begins shift
[1518-11-07 00:00] Guard #2411 begins shift
[1518-11-23 00:29] wakes up
[1518-05-31 00:32] falls asleep
[1518-06-24 00:46] falls asleep
[1518-07-04 23:56] Guard #2411 begins shift
[1518-08-02 00:57] wakes up
[1518-10-10 00:57] falls asleep
[1518-09-16 00:02] Guard #2539 begins shift
[1518-10-06 00:30] wakes up
[1518-06-24 00:20] falls asleep
[1518-07-07 23:50] Guard #2411 begins shift
[1518-03-31 00:48] wakes up
[1518-09-26 00:47] wakes up
[1518-07-31 23:58] Guard #2671 begins shift
[1518-05-28 00:31] falls asleep
[1518-08-19 00:03] falls asleep
[1518-07-21 00:21] falls asleep
[1518-06-16 00:44] wakes up
[1518-10-22 00:00] Guard #1153 begins shift
[1518-05-16 00:56] wakes up
[1518-08-22 00:33] falls asleep
[1518-11-08 00:08] falls asleep
[1518-10-19 00:33] wakes up
[1518-05-14 00:49] wakes up
[1518-07-19 00:25] falls asleep
[1518-04-12 23:57] Guard #2351 begins shift
[1518-09-04 00:55] wakes up
[1518-06-13 00:49] falls asleep
[1518-04-15 00:47] falls asleep
[1518-08-03 00:55] falls asleep
[1518-07-19 23:56] Guard #2351 begins shift
[1518-04-01 00:48] wakes up
[1518-07-19 00:04] Guard #353 begins shift
[1518-03-27 00:42] falls asleep
[1518-07-11 00:20] falls asleep
[1518-10-16 00:17] falls asleep
[1518-09-01 00:34] falls asleep
[1518-03-13 23:56] Guard #2539 begins shift
[1518-04-23 00:06] falls asleep
[1518-10-04 00:59] wakes up
[1518-11-02 00:50] wakes up
[1518-09-06 00:03] falls asleep
[1518-09-01 00:17] wakes up
[1518-04-27 00:54] falls asleep
[1518-04-14 00:53] falls asleep
[1518-10-18 00:04] Guard #1031 begins shift
[1518-04-28 00:03] wakes up
[1518-03-15 23:56] Guard #2539 begins shift
[1518-07-26 00:54] wakes up
[1518-07-07 00:12] falls asleep
[1518-07-07 00:03] Guard #2311 begins shift
[1518-08-09 23:50] Guard #131 begins shift
[1518-06-05 00:57] wakes up
[1518-07-23 00:13] falls asleep
[1518-03-22 00:52] wakes up
[1518-04-08 00:54] falls asleep
[1518-10-15 00:58] wakes up
[1518-05-20 00:14] falls asleep
[1518-10-30 00:41] wakes up
[1518-08-31 00:58] wakes up
[1518-03-28 00:01] falls asleep
[1518-08-31 00:23] wakes up
[1518-04-17 00:03] Guard #293 begins shift
[1518-09-02 00:30] wakes up
[1518-08-10 00:52] falls asleep
[1518-09-17 23:57] Guard #2411 begins shift
[1518-06-07 00:58] wakes up
[1518-10-06 23:57] Guard #1543 begins shift
[1518-08-23 00:22] falls asleep
[1518-10-24 00:19] falls asleep
[1518-05-07 00:55] wakes up
[1518-06-20 00:20] falls asleep
[1518-11-21 00:52] wakes up
[1518-11-04 00:49] wakes up
[1518-08-09 00:00] Guard #2053 begins shift
[1518-07-24 00:52] wakes up
[1518-10-10 00:44] falls asleep
[1518-10-26 00:41] wakes up
[1518-06-23 00:47] falls asleep
[1518-07-15 00:50] wakes up
[1518-08-04 00:25] wakes up
[1518-10-20 23:57] Guard #2411 begins shift
[1518-06-28 00:03] Guard #293 begins shift
[1518-08-01 00:55] wakes up
[1518-07-19 00:39] wakes up
[1518-08-21 00:11] falls asleep
[1518-08-27 00:58] wakes up
[1518-04-14 00:57] wakes up
[1518-06-14 00:59] wakes up
[1518-04-07 00:16] falls asleep
[1518-10-03 00:55] wakes up
[1518-04-20 00:16] falls asleep
[1518-10-31 00:30] wakes up
[1518-05-07 00:41] falls asleep
[1518-08-08 00:21] wakes up
[1518-11-07 00:41] falls asleep
[1518-06-28 00:48] falls asleep
[1518-07-03 00:00] Guard #449 begins shift
[1518-06-29 00:58] wakes up
[1518-10-19 00:00] Guard #449 begins shift
[1518-06-12 00:03] Guard #131 begins shift
[1518-08-10 00:56] wakes up
[1518-03-15 00:49] falls asleep
[1518-06-19 00:50] wakes up
[1518-04-04 00:58] wakes up
[1518-05-11 00:00] Guard #1063 begins shift
[1518-05-29 00:18] falls asleep
[1518-04-18 00:48] wakes up
[1518-08-09 00:56] wakes up
[1518-10-18 00:13] falls asleep
[1518-04-23 00:01] Guard #1997 begins shift
[1518-04-03 00:40] falls asleep
[1518-10-29 00:48] falls asleep
[1518-03-15 00:07] falls asleep
[1518-08-10 23:58] Guard #1031 begins shift
[1518-10-10 00:58] wakes up
[1518-04-03 00:16] falls asleep
[1518-07-04 00:52] wakes up
[1518-05-01 00:20] falls asleep
[1518-08-04 00:02] Guard #1997 begins shift
[1518-10-18 00:33] wakes up
[1518-11-20 00:36] falls asleep
[1518-10-13 00:45] wakes up
[1518-06-07 00:34] wakes up
[1518-06-25 00:11] falls asleep
[1518-04-22 00:58] wakes up
[1518-08-17 23:53] Guard #131 begins shift
[1518-10-21 00:43] falls asleep
[1518-08-19 00:48] wakes up
[1518-09-16 00:54] wakes up
[1518-08-07 00:15] falls asleep
[1518-06-21 00:39] falls asleep
[1518-07-20 00:34] wakes up
[1518-10-25 00:07] falls asleep
[1518-06-20 00:43] wakes up
[1518-05-02 00:51] wakes up
[1518-06-16 00:09] wakes up
[1518-06-13 00:03] Guard #353 begins shift
[1518-11-07 00:50] wakes up
[1518-07-26 00:36] falls asleep
[1518-09-22 00:01] Guard #293 begins shift
[1518-07-01 00:40] falls asleep
[1518-09-18 00:41] falls asleep
[1518-05-06 00:02] Guard #307 begins shift
[1518-08-28 00:01] Guard #307 begins shift
[1518-07-05 23:56] Guard #1031 begins shift
[1518-04-02 00:04] falls asleep
[1518-10-19 00:10] falls asleep
[1518-03-30 00:06] falls asleep
[1518-04-13 00:34] wakes up
[1518-06-21 23:50] Guard #1031 begins shift
[1518-11-20 00:58] wakes up
[1518-09-29 00:41] wakes up
[1518-11-03 00:03] Guard #293 begins shift
[1518-06-01 00:08] falls asleep
[1518-03-27 00:03] falls asleep
[1518-08-19 00:39] wakes up
[1518-06-09 00:42] falls asleep
[1518-05-18 00:40] wakes up
[1518-06-28 23:56] Guard #131 begins shift
[1518-03-18 00:58] wakes up
[1518-10-09 00:58] wakes up
[1518-06-19 00:47] falls asleep
[1518-10-26 00:24] falls asleep
[1518-10-05 00:49] wakes up
[1518-10-03 00:46] falls asleep
[1518-05-01 00:57] wakes up
[1518-08-30 00:52] wakes up
[1518-06-04 00:44] falls asleep
[1518-10-18 00:49] falls asleep
[1518-03-24 00:03] Guard #1879 begins shift
[1518-11-17 23:46] Guard #569 begins shift
[1518-04-09 00:11] wakes up
[1518-08-06 00:18] falls asleep
[1518-07-05 00:51] wakes up
[1518-11-02 00:00] Guard #1543 begins shift
[1518-10-31 00:38] falls asleep
[1518-11-02 00:35] falls asleep
[1518-06-06 00:56] wakes up
[1518-04-12 00:46] falls asleep
[1518-04-24 00:33] wakes up
[1518-08-06 00:01] Guard #293 begins shift
[1518-04-18 00:03] falls asleep
[1518-09-22 00:54] falls asleep
[1518-10-15 00:55] falls asleep
[1518-09-07 00:07] falls asleep
[1518-07-17 00:01] falls asleep
[1518-08-31 00:54] falls asleep
[1518-06-27 00:04] Guard #2053 begins shift
[1518-06-10 00:56] wakes up
[1518-05-31 00:57] wakes up
[1518-03-24 00:54] wakes up
[1518-07-08 00:17] wakes up
[1518-08-28 23:58] Guard #449 begins shift
[1518-10-12 00:33] falls asleep
[1518-08-24 00:02] Guard #2539 begins shift
[1518-08-02 00:42] falls asleep
[1518-07-19 00:55] wakes up
[1518-07-02 00:55] wakes up
[1518-05-09 00:04] Guard #449 begins shift
[1518-11-13 00:27] falls asleep
[1518-11-19 00:46] wakes up
[1518-03-27 00:56] wakes up
[1518-05-12 00:58] wakes up
[1518-04-10 00:44] wakes up
[1518-07-12 00:57] wakes up
[1518-11-17 00:52] wakes up
[1518-10-02 00:44] falls asleep
[1518-08-17 00:40] falls asleep
[1518-06-11 00:52] wakes up
[1518-11-05 00:03] Guard #449 begins shift
[1518-06-15 00:19] falls asleep
[1518-05-26 23:46] Guard #353 begins shift
[1518-03-29 00:00] Guard #1997 begins shift
[1518-09-23 00:34] wakes up
[1518-06-12 00:58] wakes up
[1518-10-30 00:30] falls asleep
[1518-09-25 00:46] falls asleep
[1518-10-06 00:42] wakes up
[1518-04-06 00:35] falls asleep
[1518-09-27 00:55] wakes up
[1518-04-10 00:10] falls asleep
[1518-10-12 00:00] Guard #449 begins shift
[1518-07-28 00:39] wakes up
[1518-04-25 00:02] Guard #1031 begins shift
[1518-10-07 00:59] wakes up
[1518-06-09 00:38] wakes up
[1518-06-23 00:50] wakes up
[1518-05-28 00:19] wakes up
[1518-08-17 00:50] wakes up
[1518-08-04 00:30] falls asleep
[1518-10-20 00:34] wakes up
[1518-04-17 23:50] Guard #2053 begins shift
[1518-05-25 00:04] falls asleep
[1518-07-06 00:57] falls asleep
[1518-06-28 00:37] wakes up
[1518-10-10 00:51] falls asleep
[1518-08-23 00:44] wakes up
[1518-04-10 00:48] falls asleep
[1518-04-29 00:56] falls asleep
[1518-05-26 00:46] wakes up
[1518-08-08 00:45] falls asleep
[1518-10-08 00:31] wakes up
[1518-09-03 00:01] falls asleep
[1518-11-09 00:33] wakes up
[1518-09-16 00:15] falls asleep
[1518-11-14 00:43] wakes up
[1518-10-09 00:53] falls asleep
[1518-04-13 00:54] wakes up
[1518-09-25 00:21] falls asleep
[1518-03-19 00:45] wakes up
[1518-10-01 00:16] falls asleep
[1518-09-18 00:56] wakes up
[1518-03-31 00:39] falls asleep
[1518-04-16 00:25] falls asleep
[1518-08-05 00:59] wakes up
[1518-05-12 00:00] Guard #1543 begins shift
[1518-10-21 00:49] wakes up
[1518-09-23 23:56] Guard #307 begins shift
[1518-03-25 00:00] Guard #1879 begins shift
[1518-07-30 00:58] wakes up
[1518-06-12 00:07] falls asleep
[1518-07-18 00:23] wakes up
[1518-04-14 00:00] Guard #2411 begins shift
[1518-09-19 00:16] falls asleep
[1518-07-19 00:43] falls asleep
[1518-08-12 00:00] falls asleep
[1518-08-29 00:53] falls asleep
[1518-08-15 00:28] falls asleep
[1518-04-12 00:47] wakes up
[1518-06-26 00:44] wakes up
[1518-08-22 00:01] Guard #2311 begins shift
[1518-10-31 00:19] falls asleep
[1518-09-14 00:57] wakes up
[1518-07-03 23:59] Guard #1619 begins shift
[1518-04-28 00:02] falls asleep
[1518-09-18 00:27] wakes up
[1518-07-10 00:04] falls asleep
[1518-08-28 00:51] falls asleep
[1518-07-20 00:06] falls asleep
[1518-10-24 00:34] wakes up
[1518-07-12 00:01] Guard #1879 begins shift
[1518-05-15 00:00] Guard #2411 begins shift
[1518-04-26 00:50] wakes up
[1518-05-18 00:53] wakes up
[1518-05-21 00:57] falls asleep
[1518-08-24 00:08] falls asleep
[1518-09-01 00:59] wakes up
[1518-08-02 00:04] Guard #2053 begins shift
[1518-07-02 00:53] falls asleep
[1518-09-09 00:26] wakes up
[1518-06-13 00:43] falls asleep
[1518-10-13 00:51] falls asleep
[1518-10-14 00:57] wakes up
[1518-04-02 23:57] Guard #1997 begins shift
[1518-11-01 00:35] falls asleep
[1518-08-03 00:37] wakes up
[1518-09-01 00:06] falls asleep
[1518-09-05 00:57] wakes up
[1518-05-28 00:02] Guard #2053 begins shift
[1518-09-28 00:17] falls asleep
[1518-08-07 23:58] Guard #2671 begins shift
[1518-04-19 00:59] wakes up
[1518-10-08 00:01] Guard #1063 begins shift
[1518-06-27 00:12] falls asleep
[1518-08-25 00:43] wakes up
[1518-05-09 00:44] wakes up
[1518-06-24 00:41] wakes up
[1518-04-14 00:20] falls asleep
[1518-05-25 23:52] Guard #2311 begins shift
[1518-09-22 00:55] wakes up
[1518-07-10 00:31] wakes up
[1518-06-02 00:02] Guard #2053 begins shift
[1518-05-19 00:25] wakes up
[1518-05-12 00:08] falls asleep
[1518-07-29 00:51] falls asleep
[1518-03-28 00:42] wakes up
[1518-11-03 00:10] falls asleep
[1518-10-31 00:43] wakes up
[1518-10-01 00:47] falls asleep
[1518-10-29 00:09] falls asleep
[1518-09-19 00:02] Guard #569 begins shift
[1518-09-09 00:52] falls asleep
[1518-10-13 00:21] wakes up
[1518-09-14 00:31] falls asleep
[1518-07-14 00:43] wakes up
[1518-10-27 23:50] Guard #1997 begins shift
[1518-06-12 00:38] falls asleep
[1518-07-09 00:52] wakes up
[1518-04-10 00:00] Guard #1879 begins shift
[1518-10-17 00:48] wakes up
[1518-06-28 00:06] falls asleep
[1518-07-09 23:50] Guard #2351 begins shift
[1518-09-30 23:59] Guard #1153 begins shift
[1518-05-23 23:57] Guard #1153 begins shift
[1518-03-24 00:26] falls asleep
[1518-04-21 00:01] Guard #1997 begins shift
[1518-08-25 00:42] falls asleep
[1518-05-28 00:47] wakes up
[1518-09-15 00:49] falls asleep
[1518-11-12 00:21] falls asleep
[1518-05-15 00:56] wakes up
[1518-11-08 00:50] wakes up
[1518-08-28 00:58] wakes up
[1518-10-01 23:59] Guard #2053 begins shift
[1518-06-09 00:23] falls asleep
[1518-05-21 00:59] wakes up
[1518-04-13 00:40] falls asleep
[1518-04-13 00:26] falls asleep
[1518-09-15 00:03] falls asleep
[1518-10-14 00:56] falls asleep
[1518-06-06 00:00] falls asleep
[1518-07-13 00:40] falls asleep
[1518-06-13 00:55] wakes up
[1518-03-21 00:03] Guard #1543 begins shift
[1518-04-21 00:37] falls asleep
[1518-05-03 00:27] falls asleep
[1518-09-18 00:15] falls asleep
[1518-04-15 00:44] wakes up
[1518-05-24 00:59] wakes up
[1518-04-21 23:59] Guard #1879 begins shift
[1518-08-04 23:58] Guard #1879 begins shift
[1518-05-18 00:35] falls asleep
[1518-11-14 00:03] Guard #2053 begins shift
[1518-08-29 00:58] wakes up
[1518-07-17 00:58] wakes up
[1518-07-28 00:47] falls asleep
[1518-06-30 00:48] wakes up
[1518-10-29 23:58] Guard #569 begins shift
[1518-06-20 00:04] Guard #131 begins shift
[1518-07-24 00:39] falls asleep
[1518-04-15 00:40] falls asleep
[1518-08-06 00:49] wakes up
[1518-09-11 00:54] wakes up
[1518-04-12 00:38] falls asleep
[1518-03-29 23:57] Guard #1997 begins shift
[1518-05-13 00:02] Guard #1063 begins shift
[1518-11-17 00:39] wakes up
[1518-09-13 00:00] Guard #2671 begins shift
[1518-05-10 00:51] falls asleep
[1518-04-18 00:53] wakes up
[1518-06-10 00:35] falls asleep
[1518-05-22 00:02] Guard #1997 begins shift
[1518-05-12 00:31] wakes up
[1518-04-15 00:31] wakes up
[1518-07-11 00:43] wakes up
[1518-07-02 00:00] Guard #131 begins shift
[1518-07-16 00:18] falls asleep
[1518-03-25 23:57] Guard #331 begins shift
[1518-05-18 00:46] falls asleep
[1518-09-23 00:08] falls asleep
[1518-06-03 23:57] Guard #307 begins shift
[1518-03-29 00:58] wakes up
[1518-07-27 00:12] falls asleep
[1518-07-21 00:33] wakes up
[1518-07-23 00:54] wakes up
[1518-08-03 00:33] falls asleep
[1518-11-19 00:41] falls asleep
[1518-03-17 23:58] Guard #293 begins shift
[1518-04-19 00:56] falls asleep
[1518-08-31 00:36] falls asleep
[1518-07-17 00:47] wakes up
[1518-08-25 00:02] falls asleep
[1518-03-17 00:38] wakes up
[1518-03-21 00:10] falls asleep
[1518-09-12 00:55] wakes up
[1518-09-24 00:52] wakes up
[1518-05-27 00:59] wakes up
[1518-10-13 00:25] falls asleep
[1518-10-06 00:38] falls asleep
[1518-10-24 00:00] Guard #1031 begins shift
[1518-09-11 23:50] Guard #293 begins shift
[1518-09-22 00:18] wakes up
[1518-11-16 00:39] falls asleep
[1518-10-30 00:34] wakes up
[1518-05-28 00:18] falls asleep
[1518-05-22 00:11] falls asleep
[1518-07-09 00:43] falls asleep
[1518-05-30 23:59] Guard #2671 begins shift
[1518-03-31 23:49] Guard #1063 begins shift
[1518-05-09 00:31] falls asleep
[1518-04-26 00:13] falls asleep
[1518-06-13 00:20] falls asleep
[1518-04-24 00:02] Guard #1997 begins shift
[1518-07-16 23:52] Guard #1031 begins shift
[1518-03-21 00:41] falls asleep
[1518-07-09 00:40] wakes up
[1518-05-06 23:54] Guard #1031 begins shift
[1518-06-02 00:57] falls asleep
[1518-09-14 00:00] Guard #131 begins shift
[1518-07-18 00:34] falls asleep
[1518-09-27 00:30] falls asleep
[1518-08-13 00:42] wakes up
[1518-06-10 00:51] falls asleep
[1518-08-12 00:49] wakes up
[1518-06-29 00:54] wakes up
[1518-04-30 23:58] Guard #2351 begins shift
[1518-03-14 00:43] falls asleep
[1518-04-20 00:49] wakes up
[1518-07-04 00:18] wakes up
[1518-11-10 00:09] falls asleep
[1518-10-26 23:52] Guard #293 begins shift
[1518-08-03 00:50] wakes up
[1518-04-17 00:27] wakes up
[1518-04-24 00:41] falls asleep
[1518-04-25 00:29] wakes up
[1518-06-12 00:33] wakes up
[1518-10-01 00:39] wakes up
[1518-08-25 00:54] wakes up
[1518-09-02 23:51] Guard #1619 begins shift
[1518-08-09 00:36] wakes up
[1518-07-25 23:58] Guard #2351 begins shift
[1518-03-25 00:55] wakes up
[1518-09-22 23:56] Guard #307 begins shift
[1518-06-17 00:42] wakes up
[1518-08-17 00:20] wakes up
[1518-09-07 00:32] wakes up
[1518-05-11 00:13] falls asleep
[1518-08-12 00:31] falls asleep
[1518-10-13 00:03] Guard #2539 begins shift
[1518-05-02 00:29] wakes up
[1518-06-02 00:59] wakes up
[1518-07-05 00:07] falls asleep
[1518-06-08 00:40] falls asleep";

        public static int SolveProblem1()
        {
            var lines = Problem1Input.SplitToLines().OrderBy(l => l);

            var totalSleepTime = new Dictionary<int, int>();
            var sleepMinutesByGuard = new Dictionary<int, Dictionary<int, int>>();

            var currentGuardId = -1;
            var fellAsleepMinute = 0;
            foreach (var line in lines)
            {
                if (line[19] == 'G')
                {
                    currentGuardId = Int32.Parse(line.Split(' ')[3].Substring(1));
                }
                if (line[19] == 'f')
                {
                    fellAsleepMinute = Int32.Parse(line.Substring(15,2));
                }
                if (line[19] == 'w')
                {
                    var wakeMinute = Int32.Parse(line.Substring(15,2));
                    var minutesAsleep = wakeMinute - fellAsleepMinute;
                    if (!totalSleepTime.ContainsKey(currentGuardId))
                    {
                        totalSleepTime[currentGuardId] = 0;
                        sleepMinutesByGuard[currentGuardId] = new Dictionary<int, int>();
                    }
                    totalSleepTime[currentGuardId] += minutesAsleep;
                    var guardMinutes = sleepMinutesByGuard[currentGuardId];
                    for (int i = fellAsleepMinute; i < wakeMinute; i++)
                    {
                        if (!guardMinutes.ContainsKey(i))
                        {
                            guardMinutes[i] = 0;
                        }
                        guardMinutes[i]++;
                    }
                }
            }

            var sleepyGuard = totalSleepTime.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var sleepyMinute = sleepMinutesByGuard[sleepyGuard].Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            return sleepyGuard * sleepyMinute;
        }

        public static int SolveProblem2()
        {
            var lines = Problem1Input.SplitToLines().OrderBy(l => l);

            var totalSleepTime = new Dictionary<int, int>();
            var sleepMinutesByGuard = new Dictionary<int, Dictionary<int, int>>();

            var currentGuardId = -1;
            var fellAsleepMinute = 0;
            foreach (var line in lines)
            {
                if (line[19] == 'G')
                {
                    currentGuardId = Int32.Parse(line.Split(' ')[3].Substring(1));
                }
                if (line[19] == 'f')
                {
                    fellAsleepMinute = Int32.Parse(line.Substring(15,2));
                }
                if (line[19] == 'w')
                {
                    var wakeMinute = Int32.Parse(line.Substring(15,2));
                    var minutesAsleep = wakeMinute - fellAsleepMinute;
                    if (!totalSleepTime.ContainsKey(currentGuardId))
                    {
                        totalSleepTime[currentGuardId] = 0;
                        sleepMinutesByGuard[currentGuardId] = new Dictionary<int, int>();
                    }
                    totalSleepTime[currentGuardId] += minutesAsleep;
                    var guardMinutes = sleepMinutesByGuard[currentGuardId];
                    for (int i = fellAsleepMinute; i < wakeMinute; i++)
                    {
                        if (!guardMinutes.ContainsKey(i))
                        {
                            guardMinutes[i] = 0;
                        }
                        guardMinutes[i]++;
                    }
                }
            }

            var guardId = -1;
            var minute = -1;
            var timesAsleep = 0;

            foreach(var guard in totalSleepTime.Keys)
            {
                var sleepyMinute = sleepMinutesByGuard[guard].Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                var maxTimesAsleep = sleepMinutesByGuard[guard][sleepyMinute];
                if (maxTimesAsleep > timesAsleep)
                {
                    timesAsleep = maxTimesAsleep;
                    guardId = guard;
                    minute = sleepyMinute;
                }
            }

            return guardId * minute;
        }
    }
}