using Microsoft.Win32;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Terraria.Terraria.Constants;
namespace Terraria
{
    public partial class Main
    {
        public static void LoadWorlds()
        {
            Directory.CreateDirectory(Main.WorldPath);
            string[] files = Directory.GetFiles(Main.WorldPath, "*.wld");
            int num = files.Length;
            if (!Main.dedServ && num > Main.maxLoadWorld)
            {
                num = Main.maxLoadWorld;
            }
            for (int i = 0; i < num; i++)
            {
                Main.loadWorldPath[i] = files[i];
                Main.loadWorld[i] = WorldFile.GetWorldName(Main.loadWorldPath[i]);
            }
            Main.numLoadWorlds = num;
        }
        private static void LoadPlayers()
        {
            Directory.CreateDirectory(Main.PlayerPath);
            string[] files = Directory.GetFiles(Main.PlayerPath, "*.plr");
            string[] files2 = Directory.GetFiles(Main.PlayerPath, "*.plr.dat");
            int num = files.Length + files2.Length;
            string[] array = new string[num];
            bool[] array2 = new bool[num];
            int num2 = 0;
            int num3 = 0;
            for (int i = 0; i < num; i++)
            {
                if (num2 == files.Length)
                {
                    array[i] = files2[num3];
                    num3++;
                    array2[i] = true;
                }
                else
                {
                    if (num3 == files2.Length)
                    {
                        array[i] = files[num2];
                        num2++;
                        array2[i] = false;
                    }
                    else
                    {
                        if (string.CompareOrdinal(files[num2], files2[num3]) > 0)
                        {
                            array[i] = files2[num3];
                            num3++;
                            array2[i] = true;
                        }
                        else
                        {
                            array[i] = files[num2];
                            num2++;
                            array2[i] = false;
                        }
                    }
                }
            }
            if (num > 0)
            {
                string[] array3 = array[0].Split(new char[]
				{
					Path.DirectorySeparatorChar
				});
                string text = array3[array3.Length - 1].Split(new char[]
				{
					'.'
				})[0];
                for (int j = 1; j < num; j++)
                {
                    string text2 = text;
                    array3 = array[j].Split(new char[]
					{
						Path.DirectorySeparatorChar
					});
                    text = array3[array3.Length - 1].Split(new char[]
					{
						'.'
					})[0];
                    if (text2 == text)
                    {
                        DateTime lastWriteTime = File.GetLastWriteTime(array[j - 1]);
                        DateTime lastWriteTime2 = File.GetLastWriteTime(array[j]);
                        if (lastWriteTime < lastWriteTime2)
                        {
                            array[j - 1] = null;
                        }
                        else
                        {
                            array[j] = null;
                        }
                    }
                }
            }
            for (int k = 0; k < num; k++)
            {
                if (array2[k] && array[k] != null)
                {
                    array[k] = array[k].Substring(0, array[k].Length - 4);
                }
            }
            int num4 = 0;
            int num5 = 0;
            while (num5 < array.Length && num4 < Main.maxLoadPlayer)
            {
                if (array[num5] != null)
                {
                    Main.loadPlayerPath[num4] = array[num5];
                    Player player;
                    if (array2[num5])
                    {
                        player = Player.LoadPlayer(Main.loadPlayerPath[num4], true);
                    }
                    else
                    {
                        player = Player.LoadPlayer(Main.loadPlayerPath[num4], false);
                    }
                    if (player.loadStatus != 0 && player.loadStatus != 1)
                    {
                        string text3 = Main.loadPlayerPath[num4] + ".bak";
                        if (File.Exists(text3))
                        {
                            string text4 = Main.loadPlayerPath[num4] + ".bad";
                            if (File.Exists(text4))
                            {
                                File.Delete(text4);
                            }
                            File.Move(Main.loadPlayerPath[num4], text4);
                            File.Delete(Main.loadPlayerPath[num4]);
                            File.Move(text3, Main.loadPlayerPath[num4]);
                            player = Player.LoadPlayer(Main.loadPlayerPath[num4], false);
                        }
                    }
                    Main.loadPlayer[num4] = player;
                    num4++;
                }
                num5++;
            }
            Main.numLoadPlayers = num4;
        }

        private static void ErasePlayer(int i)
        {
            try
            {
                File.Delete(Main.loadPlayerPath[i]);
                File.Delete(Main.loadPlayerPath[i] + ".bak");
            }
            catch
            {
            }
            try
            {
                string path = Main.loadPlayerPath[i].Substring(0, Main.loadPlayerPath[i].Length - 4);
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
                Main.LoadPlayers();
            }
            catch
            {
            }
        }
        private static void EraseWorld(int i)
        {
            try
            {
                File.Delete(Main.loadWorldPath[i]);
                File.Delete(Main.loadWorldPath[i] + ".bak");
                Main.LoadWorlds();
            }
            catch
            {
            }
        }

        private static void StopRain()
        {
            Main.rainTime = 0;
            Main.raining = false;
            Main.maxRaining = 0f;
        }
        private static void StartRain()
        {
            int num = 86400;
            int num2 = num / 24;
            Main.rainTime = Main.rand.Next(num2 * 8, num);
            if (Main.rand.Next(3) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2);
            }
            if (Main.rand.Next(4) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.Next(5) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 2);
            }
            if (Main.rand.Next(6) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 3);
            }
            if (Main.rand.Next(7) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 4);
            }
            if (Main.rand.Next(8) == 0)
            {
                Main.rainTime += Main.rand.Next(0, num2 * 5);
            }
            float num3 = 1f;
            if (Main.rand.Next(2) == 0)
            {
                num3 += 0.05f;
            }
            if (Main.rand.Next(3) == 0)
            {
                num3 += 0.1f;
            }
            if (Main.rand.Next(4) == 0)
            {
                num3 += 0.15f;
            }
            if (Main.rand.Next(5) == 0)
            {
                num3 += 0.2f;
            }
            Main.rainTime = (int)((float)Main.rainTime * num3);
            Main.ChangeRain();
            Main.raining = true;
        }
        private static void ChangeRain()
        {
            if (Main.cloudBGActive >= 1f || (double)Main.numClouds > 150.0)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.maxRaining = (float)Main.rand.Next(20, 90) * 0.01f;
                    return;
                }
                Main.maxRaining = (float)Main.rand.Next(40, 90) * 0.01f;
                return;
            }
            else
            {
                if ((double)Main.numClouds > 100.0)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Main.maxRaining = (float)Main.rand.Next(10, 70) * 0.01f;
                        return;
                    }
                    Main.maxRaining = (float)Main.rand.Next(20, 60) * 0.01f;
                    return;
                }
                else
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        Main.maxRaining = (float)Main.rand.Next(5, 40) * 0.01f;
                        return;
                    }
                    Main.maxRaining = (float)Main.rand.Next(5, 30) * 0.01f;
                    return;
                }
            }
        }
        private static void UpdateTime()
        {
            if (Main.pumpkinMoon)
            {
                Main.bloodMoon = false;
                Main.snowMoon = false;
            }
            if (Main.snowMoon)
            {
                Main.bloodMoon = false;
            }
            if ((Main.netMode != 1 && !Main.gameMenu) || Main.netMode == 2)
            {
                if (Main.raining)
                {
                    Main.rainTime -= Main.dayRate;
                    int num = 86400;
                    num /= Main.dayRate;
                    int num2 = num / 24;
                    if (Main.rainTime <= 0)
                    {
                        Main.StopRain();
                    }
                    else
                    {
                        if (Main.rand.Next(num2 * 2) == 0)
                        {
                            Main.ChangeRain();
                        }
                    }
                }
                else
                {
                    int num3 = 86400;
                    num3 /= Main.dayRate;
                    if (Main.rand.Next((int)((double)num3 * 5.5)) == 0)
                    {
                        Main.StartRain();
                    }
                    else
                    {
                        if (Main.cloudBGActive >= 1f && Main.rand.Next(num3 * 4) == 0)
                        {
                            Main.StartRain();
                        }
                    }
                }
            }
            if (Main.maxRaining != Main.oldMaxRaining)
            {
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                }
                Main.oldMaxRaining = Main.maxRaining;
            }
            Main.time += (double)Main.dayRate;
            if (Main.netMode != 1)
            {
                if (NPC.travelNPC)
                {
                    if (!Main.dayTime || Main.time > 48600.0)
                    {
                        WorldGen.UnspawnTravelNPC();
                    }
                }
                else
                {
                    if (Main.dayTime && Main.time < 27000.0)
                    {
                        int num4 = (int)(27000.0 / (double)Main.dayRate);
                        num4 *= 4;
                        if (Main.rand.Next(num4) == 0)
                        {
                            int num5 = 0;
                            for (int i = 0; i < 200; i++)
                            {
                                if (Main.npc[i].active && Main.npc[i].townNPC && Main.npc[i].type != 37)
                                {
                                    num5++;
                                }
                            }
                            if (num5 >= 2)
                            {
                                WorldGen.SpawnTravelNPC();
                            }
                        }
                    }
                }
                NPC.travelNPC = false;
            }
            if (!Main.dayTime)
            {
                Main.eclipse = false;
                if (WorldGen.spawnEye && Main.netMode != 1 && Main.time > 4860.0)
                {
                    for (int j = 0; j < 255; j++)
                    {
                        if (Main.player[j].active && !Main.player[j].dead && (double)Main.player[j].position.Y < Main.worldSurface * 16.0)
                        {
                            NPC.SpawnOnPlayer(j, 4);
                            WorldGen.spawnEye = false;
                            break;
                        }
                    }
                }
                if (WorldGen.spawnHardBoss > 0 && Main.netMode != 1 && Main.time > 4860.0)
                {
                    bool flag = false;
                    for (int k = 0; k < 200; k++)
                    {
                        if (Main.npc[k].active && Main.npc[k].boss)
                        {
                            flag = true;
                        }
                    }
                    if (!flag)
                    {
                        int l = 0;
                        while (l < 255)
                        {
                            if (Main.player[l].active && !Main.player[l].dead && (double)Main.player[l].position.Y < Main.worldSurface * 16.0)
                            {
                                if (WorldGen.spawnHardBoss == 1)
                                {
                                    NPC.SpawnOnPlayer(l, 134);
                                    break;
                                }
                                if (WorldGen.spawnHardBoss == 2)
                                {
                                    NPC.SpawnOnPlayer(l, 125);
                                    NPC.SpawnOnPlayer(l, 126);
                                    break;
                                }
                                if (WorldGen.spawnHardBoss == 3)
                                {
                                    NPC.SpawnOnPlayer(l, 127);
                                    break;
                                }
                                break;
                            }
                            else
                            {
                                l++;
                            }
                        }
                    }
                    WorldGen.spawnHardBoss = 0;
                }
                if (Main.time > 32400.0)
                {
                    Main.checkXMas();
                    Main.checkHalloween();
                    if (Main.invasionDelay > 0)
                    {
                        Main.invasionDelay--;
                    }
                    WorldGen.spawnNPC = 0;
                    Main.checkForSpawns = 0;
                    Main.time = 0.0;
                    Main.bloodMoon = false;
                    Main.stopMoonEvent();
                    Main.dayTime = true;
                    Main.moonPhase++;
                    if (Main.moonPhase >= 8)
                    {
                        Main.moonPhase = 0;
                    }
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        WorldGen.saveAndPlay();
                    }
                    if (Main.netMode != 1 && WorldGen.shadowOrbSmashed)
                    {
                        if (!NPC.downedGoblins)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                Main.StartInvasion(1);
                            }
                        }
                        else
                        {
                            if ((Main.hardMode && Main.rand.Next(60) == 0) || (!Main.hardMode && Main.rand.Next(30) == 0))
                            {
                                Main.StartInvasion(1);
                            }
                        }
                        if (Main.invasionType == 0 && Main.hardMode && ((NPC.downedPirates && Main.rand.Next(50) == 0) || (!NPC.downedPirates && Main.rand.Next(30) == 0)))
                        {
                            Main.StartInvasion(3);
                        }
                    }
                    if (Main.hardMode && NPC.downedMechBossAny && Main.rand.Next(25) == 0 && Main.netMode != 1)
                    {
                        Main.eclipse = true;
                        if (Main.eclipse)
                        {
                            if (Main.netMode == 0)
                            {
                                Main.NewText(Lang.misc[20], 50, 255, 130, false);
                            }
                            else
                            {
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(25, -1, -1, Lang.misc[20], 255, 50f, 255f, 130f, 0);
                                }
                            }
                        }
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        }
                    }
                }
                if (Main.time > 16200.0 && WorldGen.spawnMeteor)
                {
                    WorldGen.spawnMeteor = false;
                    WorldGen.dropMeteor();
                    return;
                }
            }
            else
            {
                Main.bloodMoon = false;
                Main.stopMoonEvent();
                if (Main.time > 54000.0)
                {
                    NPC.setFireFlyChance();
                    WorldGen.spawnNPC = 0;
                    Main.checkForSpawns = 0;
                    if (Main.rand.Next(50) == 0 && Main.netMode != 1 && WorldGen.shadowOrbSmashed)
                    {
                        WorldGen.spawnMeteor = true;
                    }
                    Main.eclipse = false;
                    if (!NPC.downedBoss1 && Main.netMode != 1)
                    {
                        bool flag2 = false;
                        for (int m = 0; m < 255; m++)
                        {
                            if (Main.player[m].active && Main.player[m].statLifeMax >= 200 && Main.player[m].statDefense > 10)
                            {
                                flag2 = true;
                                break;
                            }
                        }
                        if (flag2 && Main.rand.Next(3) == 0)
                        {
                            int num6 = 0;
                            for (int n = 0; n < 200; n++)
                            {
                                if (Main.npc[n].active && Main.npc[n].townNPC)
                                {
                                    num6++;
                                }
                            }
                            if (num6 >= 4)
                            {
                                WorldGen.spawnEye = true;
                                if (Main.netMode == 0)
                                {
                                    Main.NewText(Lang.misc[9], 50, 255, 130, false);
                                }
                                else
                                {
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(25, -1, -1, Lang.misc[9], 255, 50f, 255f, 130f, 0);
                                    }
                                }
                            }
                        }
                    }
                    if (Main.netMode != 1 && !Main.pumpkinMoon && !Main.snowMoon && WorldGen.altarCount > 0 && Main.hardMode && !WorldGen.spawnEye && Main.rand.Next(10) == 0)
                    {
                        bool flag3 = false;
                        for (int num7 = 0; num7 < 200; num7++)
                        {
                            if (Main.npc[num7].active && Main.npc[num7].boss)
                            {
                                flag3 = true;
                            }
                        }
                        if (!flag3 && (!NPC.downedMechBoss1 || !NPC.downedMechBoss2 || !NPC.downedMechBoss3))
                        {
                            int num8 = 0;
                            while (num8 < 1000)
                            {
                                int num9 = Main.rand.Next(3) + 1;
                                if (num9 == 1 && !NPC.downedMechBoss1)
                                {
                                    WorldGen.spawnHardBoss = num9;
                                    if (Main.netMode == 0)
                                    {
                                        Main.NewText(Lang.misc[28], 50, 255, 130, false);
                                        break;
                                    }
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(25, -1, -1, Lang.misc[28], 255, 50f, 255f, 130f, 0);
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    if (num9 == 2 && !NPC.downedMechBoss2)
                                    {
                                        WorldGen.spawnHardBoss = num9;
                                        if (Main.netMode == 0)
                                        {
                                            Main.NewText(Lang.misc[29], 50, 255, 130, false);
                                            break;
                                        }
                                        if (Main.netMode == 2)
                                        {
                                            NetMessage.SendData(25, -1, -1, Lang.misc[29], 255, 50f, 255f, 130f, 0);
                                            break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        if (num9 == 3 && !NPC.downedMechBoss3)
                                        {
                                            WorldGen.spawnHardBoss = num9;
                                            if (Main.netMode == 0)
                                            {
                                                Main.NewText(Lang.misc[30], 50, 255, 130, false);
                                                break;
                                            }
                                            if (Main.netMode == 2)
                                            {
                                                NetMessage.SendData(25, -1, -1, Lang.misc[30], 255, 50f, 255f, 130f, 0);
                                                break;
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            num8++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!WorldGen.spawnEye && Main.moonPhase != 4 && Main.rand.Next(9) == 0 && Main.netMode != 1)
                    {
                        for (int num10 = 0; num10 < 255; num10++)
                        {
                            if (Main.player[num10].active && Main.player[num10].statLifeMax > 120)
                            {
                                Main.bloodMoon = true;
                                break;
                            }
                        }
                        if (Main.bloodMoon)
                        {
                            if (Main.netMode == 0)
                            {
                                Main.NewText(Lang.misc[8], 50, 255, 130, false);
                            }
                            else
                            {
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(25, -1, -1, Lang.misc[8], 255, 50f, 255f, 130f, 0);
                                }
                            }
                        }
                    }
                    Main.time = 0.0;
                    Main.dayTime = false;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                    }
                }
                if (Main.netMode != 1 && Main.worldRate > 0)
                {
                    Main.checkForSpawns++;
                    if (Main.checkForSpawns >= 7200 / Main.worldRate)
                    {
                        int num11 = 0;
                        for (int num12 = 0; num12 < 255; num12++)
                        {
                            if (Main.player[num12].active)
                            {
                                num11++;
                            }
                        }
                        for (int num13 = 0; num13 < 369; num13++)
                        {
                            Main.nextNPC[num13] = false;
                        }
                        Main.checkForSpawns = 0;
                        WorldGen.spawnNPC = 0;
                        int num14 = 0;
                        int num15 = 0;
                        int num16 = 0;
                        int num17 = 0;
                        int num18 = 0;
                        int num19 = 0;
                        int num20 = 0;
                        int num21 = 0;
                        int num22 = 0;
                        int num23 = 0;
                        int num24 = 0;
                        int num25 = 0;
                        int num26 = 0;
                        int num27 = 0;
                        int num28 = 0;
                        int num29 = 0;
                        int num30 = 0;
                        int num31 = 0;
                        int num32 = 0;
                        int num33 = 0;
                        int num34 = 0;
                        int num35 = 0;
                        for (int num36 = 0; num36 < 200; num36++)
                        {
                            if (Main.npc[num36].active && Main.npc[num36].townNPC)
                            {
                                if (Main.npc[num36].type != 368 && Main.npc[num36].type != 37 && !Main.npc[num36].homeless)
                                {
                                    WorldGen.QuickFindHome(num36);
                                }
                                if (Main.npc[num36].type == 37)
                                {
                                    num19++;
                                }
                                if (Main.npc[num36].type == 17)
                                {
                                    num14++;
                                }
                                if (Main.npc[num36].type == 18)
                                {
                                    num15++;
                                }
                                if (Main.npc[num36].type == 19)
                                {
                                    num17++;
                                }
                                if (Main.npc[num36].type == 20)
                                {
                                    num16++;
                                }
                                if (Main.npc[num36].type == 22)
                                {
                                    num18++;
                                }
                                if (Main.npc[num36].type == 38)
                                {
                                    num20++;
                                }
                                if (Main.npc[num36].type == 54)
                                {
                                    num21++;
                                }
                                if (Main.npc[num36].type == 107)
                                {
                                    num23++;
                                }
                                if (Main.npc[num36].type == 108)
                                {
                                    num22++;
                                }
                                if (Main.npc[num36].type == 124)
                                {
                                    num24++;
                                }
                                if (Main.npc[num36].type == 142)
                                {
                                    num25++;
                                }
                                if (Main.npc[num36].type == 160)
                                {
                                    num26++;
                                }
                                if (Main.npc[num36].type == 178)
                                {
                                    num27++;
                                }
                                if (Main.npc[num36].type == 207)
                                {
                                    num28++;
                                }
                                if (Main.npc[num36].type == 208)
                                {
                                    num29++;
                                }
                                if (Main.npc[num36].type == 209)
                                {
                                    num30++;
                                }
                                if (Main.npc[num36].type == 227)
                                {
                                    num31++;
                                }
                                if (Main.npc[num36].type == 228)
                                {
                                    num32++;
                                }
                                if (Main.npc[num36].type == 229)
                                {
                                    num33++;
                                }
                                if (Main.npc[num36].type == 353)
                                {
                                    num34++;
                                }
                                num35++;
                            }
                        }
                        if (WorldGen.spawnNPC == 0)
                        {
                            int num37 = 0;
                            bool flag4 = false;
                            int num38 = 0;
                            bool flag5 = false;
                            bool flag6 = false;
                            bool flag7 = false;
                            for (int num39 = 0; num39 < 255; num39++)
                            {
                                if (Main.player[num39].active)
                                {
                                    for (int num40 = 0; num40 < 58; num40++)
                                    {
                                        if (Main.player[num39].inventory[num40] != null & Main.player[num39].inventory[num40].stack > 0)
                                        {
                                            if (num37 < 2000000000)
                                            {
                                                if (Main.player[num39].inventory[num40].type == 71)
                                                {
                                                    num37 += Main.player[num39].inventory[num40].stack;
                                                }
                                                if (Main.player[num39].inventory[num40].type == 72)
                                                {
                                                    num37 += Main.player[num39].inventory[num40].stack * 100;
                                                }
                                                if (Main.player[num39].inventory[num40].type == 73)
                                                {
                                                    num37 += Main.player[num39].inventory[num40].stack * 10000;
                                                }
                                                if (Main.player[num39].inventory[num40].type == 74)
                                                {
                                                    num37 += Main.player[num39].inventory[num40].stack * 1000000;
                                                }
                                            }
                                            if (Main.player[num39].inventory[num40].ammo == 14 || Main.player[num39].inventory[num40].useAmmo == 14)
                                            {
                                                flag5 = true;
                                            }
                                            if (Main.player[num39].inventory[num40].type == 166 || Main.player[num39].inventory[num40].type == 167 || Main.player[num39].inventory[num40].type == 168 || Main.player[num39].inventory[num40].type == 235)
                                            {
                                                flag6 = true;
                                            }
                                            if (Main.player[num39].inventory[num40].dye > 0 || (Main.player[num39].inventory[num40].type >= 1107 && Main.player[num39].inventory[num40].type <= 1120))
                                            {
                                                flag7 = true;
                                            }
                                        }
                                    }
                                    int num41 = Main.player[num39].statLifeMax / 20;
                                    if (num41 > 5)
                                    {
                                        flag4 = true;
                                    }
                                    num38 += num41;
                                    if (!flag7)
                                    {
                                        for (int num42 = 0; num42 < 3; num42++)
                                        {
                                            if (Main.player[num39].dye[num42] != null && Main.player[num39].dye[num42].stack > 0 && Main.player[num39].dye[num42].dye > 0)
                                            {
                                                flag7 = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (!NPC.downedBoss3 && num19 == 0)
                            {
                                int num43 = NPC.NewNPC(Main.dungeonX * 16 + 8, Main.dungeonY * 16, 37, 0);
                                Main.npc[num43].homeless = false;
                                Main.npc[num43].homeTileX = Main.dungeonX;
                                Main.npc[num43].homeTileY = Main.dungeonY;
                            }
                            bool flag8 = false;
                            if (Main.rand.Next(50) == 0)
                            {
                                flag8 = true;
                            }
                            if (num18 < 1)
                            {
                                Main.nextNPC[22] = true;
                            }
                            if ((double)num37 > 5000.0 && num14 < 1)
                            {
                                Main.nextNPC[17] = true;
                            }
                            if (flag4 && num15 < 1 && num14 > 0)
                            {
                                Main.nextNPC[18] = true;
                            }
                            if (flag5 && num17 < 1)
                            {
                                Main.nextNPC[19] = true;
                            }
                            if ((NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num16 < 1)
                            {
                                Main.nextNPC[20] = true;
                            }
                            if (flag6 && num14 > 0 && num20 < 1)
                            {
                                Main.nextNPC[38] = true;
                            }
                            if (NPC.savedStylist && num34 < 1)
                            {
                                Main.nextNPC[353] = true;
                            }
                            if (NPC.downedBoss3 && num21 < 1)
                            {
                                Main.nextNPC[54] = true;
                            }
                            if (NPC.savedGoblin && num23 < 1)
                            {
                                Main.nextNPC[107] = true;
                            }
                            if (NPC.savedWizard && num22 < 1)
                            {
                                Main.nextNPC[108] = true;
                            }
                            if (NPC.savedMech && num24 < 1)
                            {
                                Main.nextNPC[124] = true;
                            }
                            if (NPC.downedFrost && num25 < 1 && Main.xMas)
                            {
                                Main.nextNPC[142] = true;
                            }
                            if (NPC.downedMechBossAny && num27 < 1)
                            {
                                Main.nextNPC[178] = true;
                            }
                            if (flag7 && num28 < 1)
                            {
                                Main.nextNPC[207] = true;
                            }
                            if (NPC.downedQueenBee && num32 < 1)
                            {
                                Main.nextNPC[228] = true;
                            }
                            if (NPC.downedPirates && num33 < 1)
                            {
                                Main.nextNPC[229] = true;
                            }
                            if (num26 < 1 && Main.hardMode)
                            {
                                Main.nextNPC[160] = true;
                            }
                            if (Main.hardMode && NPC.downedPlantBoss && num30 < 1)
                            {
                                Main.nextNPC[209] = true;
                            }
                            if (num35 >= 4 && num31 < 1)
                            {
                                Main.nextNPC[227] = true;
                            }
                            if (flag8 && num29 < 1 && num35 >= 8)
                            {
                                Main.nextNPC[208] = true;
                            }
                            if (WorldGen.spawnNPC == 0 && num18 < 1)
                            {
                                WorldGen.spawnNPC = 22;
                            }
                            if (WorldGen.spawnNPC == 0 && (double)num37 > 5000.0 && num14 < 1)
                            {
                                WorldGen.spawnNPC = 17;
                            }
                            if (WorldGen.spawnNPC == 0 && flag4 && num15 < 1 && num14 > 0)
                            {
                                WorldGen.spawnNPC = 18;
                            }
                            if (WorldGen.spawnNPC == 0 && flag5 && num17 < 1)
                            {
                                WorldGen.spawnNPC = 19;
                            }
                            if (WorldGen.spawnNPC == 0 && (NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3) && num16 < 1)
                            {
                                WorldGen.spawnNPC = 20;
                            }
                            if (WorldGen.spawnNPC == 0 && flag6 && num14 > 0 && num20 < 1)
                            {
                                WorldGen.spawnNPC = 38;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.savedStylist && num34 < 1)
                            {
                                WorldGen.spawnNPC = 353;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.downedBoss3 && num21 < 1)
                            {
                                WorldGen.spawnNPC = 54;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.savedGoblin && num23 < 1)
                            {
                                WorldGen.spawnNPC = 107;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.savedWizard && num22 < 1)
                            {
                                WorldGen.spawnNPC = 108;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.savedMech && num24 < 1)
                            {
                                WorldGen.spawnNPC = 124;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.downedFrost && num25 < 1 && Main.xMas)
                            {
                                WorldGen.spawnNPC = 142;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.downedMechBossAny && num27 < 1)
                            {
                                WorldGen.spawnNPC = 178;
                            }
                            if (WorldGen.spawnNPC == 0 && flag7 && num28 < 1)
                            {
                                WorldGen.spawnNPC = 207;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.downedQueenBee && num32 < 1)
                            {
                                WorldGen.spawnNPC = 228;
                            }
                            if (WorldGen.spawnNPC == 0 && NPC.downedPirates && num33 < 1)
                            {
                                WorldGen.spawnNPC = 229;
                            }
                            if (WorldGen.spawnNPC == 0 && Main.hardMode && num26 < 1)
                            {
                                WorldGen.spawnNPC = 160;
                            }
                            if (WorldGen.spawnNPC == 0 && Main.hardMode && NPC.downedPlantBoss && num30 < 1)
                            {
                                WorldGen.spawnNPC = 209;
                            }
                            if (WorldGen.spawnNPC == 0 && num35 >= 4 && num31 < 1)
                            {
                                WorldGen.spawnNPC = 227;
                            }
                            if (WorldGen.spawnNPC == 0 && flag8 && num35 >= 8 && num29 < 1)
                            {
                                WorldGen.spawnNPC = 208;
                            }
                        }
                    }
                }
            }
        }

        public static void stopMoonEvent()
        {
            if (Main.pumpkinMoon)
            {
                Main.pumpkinMoon = false;
                if (Main.netMode != 1)
                {
                    NPC.waveKills = 0f;
                    NPC.waveCount = 0;
                }
            }
            if (Main.snowMoon)
            {
                Main.snowMoon = false;
                if (Main.netMode != 1)
                {
                    NPC.waveKills = 0f;
                    NPC.waveCount = 0;
                }
            }
        }
        public static void startPumpkinMoon()
        {
            Main.pumpkinMoon = true;
            Main.snowMoon = false;
            Main.bloodMoon = false;
            if (Main.netMode != 1)
            {
                NPC.waveKills = 0f;
                NPC.waveCount = 1;
                string text = "First Wave: " + Main.npcName[305];
                if (Main.netMode == 0)
                {
                    Main.NewText(text, 175, 75, 255, false);
                    return;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
                }
            }
        }
        public static void startSnowMoon()
        {
            Main.snowMoon = true;
            Main.pumpkinMoon = false;
            Main.bloodMoon = false;
            if (Main.netMode != 1)
            {
                NPC.waveKills = 0f;
                NPC.waveCount = 1;
                string text = "First Wave: Zombie Elf and Gingerbread Man";
                if (Main.netMode == 0)
                {
                    Main.NewText(text, 175, 75, 255, false);
                    return;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
                }
            }
        }

        public static void snowing()
        {
            if (Main.gamePaused)
            {
                return;
            }
            if (Main.snowTiles > 0 && (double)Main.player[Main.myPlayer].position.Y < Main.worldSurface * 16.0)
            {
                int maxValue = 800 / Main.snowTiles;
                float num = (float)Main.screenWidth / 1920f;
                int num2 = (int)(500f * num);
                num2 = (int)((float)num2 * (1f + 2f * Main.cloudAlpha));
                float num3 = 1f + 50f * Main.cloudAlpha;
                int num4 = 0;
                while ((float)num4 < num3)
                {
                    try
                    {
                        if ((float)Main.snowDust >= (float)num2 * (Main.gfxQuality / 2f + 0.5f) + (float)num2 * 0.1f)
                        {
                            break;
                        }
                        if (Main.rand.Next(maxValue) == 0)
                        {
                            int num5 = Main.rand.Next(Main.screenWidth + 1000) - 500;
                            int num6 = (int)Main.screenPosition.Y - Main.rand.Next(50);
                            if (Main.player[Main.myPlayer].velocity.Y > 0f)
                            {
                                num6 -= (int)Main.player[Main.myPlayer].velocity.Y;
                            }
                            if (Main.rand.Next(5) == 0)
                            {
                                num5 = Main.rand.Next(500) - 500;
                            }
                            else
                            {
                                if (Main.rand.Next(5) == 0)
                                {
                                    num5 = Main.rand.Next(500) + Main.screenWidth;
                                }
                            }
                            if (num5 < 0 || num5 > Main.screenWidth)
                            {
                                num6 += Main.rand.Next((int)((double)Main.screenHeight * 0.5)) + (int)((double)Main.screenHeight * 0.1);
                            }
                            num5 += (int)Main.screenPosition.X;
                            int num7 = num5 / 16;
                            int num8 = num6 / 16;
                            if (Main.tile[num7, num8] != null && Main.tile[num7, num8].wall == 0)
                            {
                                int num9 = Dust.NewDust(new Vector2((float)num5, (float)num6), 10, 10, 76, 0f, 0f, 0, default(Color), 1f);
                                Main.dust[num9].scale += Main.cloudAlpha * 0.2f;
                                Main.dust[num9].velocity.Y = 3f + (float)Main.rand.Next(30) * 0.1f;
                                Dust expr_291_cp_0 = Main.dust[num9];
                                expr_291_cp_0.velocity.Y = expr_291_cp_0.velocity.Y * Main.dust[num9].scale;
                                Main.dust[num9].velocity.X = Main.windSpeed + (float)Main.rand.Next(-10, 10) * 0.1f;
                                Dust expr_2E4_cp_0 = Main.dust[num9];
                                expr_2E4_cp_0.velocity.X = expr_2E4_cp_0.velocity.X + Main.windSpeed * Main.cloudAlpha * 10f;
                                Dust expr_30E_cp_0 = Main.dust[num9];
                                expr_30E_cp_0.velocity.Y = expr_30E_cp_0.velocity.Y * (1f + 0.3f * Main.cloudAlpha);
                                Main.dust[num9].scale += Main.cloudAlpha * 0.2f;
                                Main.dust[num9].velocity *= 1f + Main.cloudAlpha * 0.5f;
                            }
                        }
                    }
                    catch
                    {
                    }
                    num4++;
                }
            }
        }


        private static void UpdateClient()
        {
            if (Main.myPlayer == 255)
            {
                Netplay.disconnect = true;
            }
            Main.netPlayCounter++;
            if (Main.netPlayCounter > 3600)
            {
                Main.netPlayCounter = 0;
            }
            if (Math.IEEERemainder((double)Main.netPlayCounter, 420.0) == 0.0)
            {
                NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
            }
            if (Math.IEEERemainder((double)Main.netPlayCounter, 900.0) == 0.0)
            {
                NetMessage.SendData(36, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                NetMessage.SendData(40, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
            }
            if (Netplay.clientSock.active)
            {
                Netplay.clientSock.timeOut++;
                if (!Main.stopTimeOuts && Netplay.clientSock.timeOut > 60 * Main.timeOut)
                {
                    Main.statusText = Lang.inter[43];
                    Netplay.disconnect = true;
                }
            }
            for (int i = 0; i < Main.itemLimit; i++)
            {
                if (Main.item[i].active && Main.item[i].owner == Main.myPlayer)
                {
                    Main.item[i].FindOwner(i);
                }
            }
        }
        private static void UpdateServer()
        {
            Main.netPlayCounter++;
            if (Main.netPlayCounter > 3600)
            {
                NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                NetMessage.syncPlayers();
                Main.netPlayCounter = 0;
            }
            for (int i = 0; i < Main.maxNetPlayers; i++)
            {
                if (Main.player[i].active && Netplay.serverSock[i].active)
                {
                    Netplay.serverSock[i].SpamUpdate();
                }
            }
            if (Math.IEEERemainder((double)Main.netPlayCounter, 900.0) == 0.0)
            {
                bool flag = true;
                int num = Main.lastItemUpdate;
                int num2 = 0;
                while (flag)
                {
                    num++;
                    if (num >= 400)
                    {
                        num = 0;
                    }
                    num2++;
                    if (!Main.item[num].active || Main.item[num].owner == 255)
                    {
                        NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
                    }
                    if (num2 >= Main.maxItemUpdates || num == Main.lastItemUpdate)
                    {
                        flag = false;
                    }
                }
                Main.lastItemUpdate = num;
            }
            for (int j = 0; j < Main.itemLimit; j++)
            {
                if (Main.item[j].active && (Main.item[j].owner == 255 || !Main.player[Main.item[j].owner].active))
                {
                    Main.item[j].FindOwner(j);
                }
            }
            for (int k = 0; k < 255; k++)
            {
                if (Netplay.serverSock[k].active)
                {
                    Netplay.serverSock[k].timeOut++;
                    if (!Main.stopTimeOuts && Netplay.serverSock[k].timeOut > 60 * Main.timeOut)
                    {
                        Netplay.serverSock[k].kill = true;
                    }
                }
                if (Main.player[k].active)
                {
                    ServerSock.CheckSection(k, Main.player[k].position);
                }
            }
        }

       
        private static void UpdateInvasion()
        {
            if (Main.invasionType > 0)
            {
                if (Main.invasionSize <= 0)
                {
                    if (Main.invasionType == 1)
                    {
                        NPC.downedGoblins = true;
                        if (Main.netMode == 2)
                        {
                            NetMessage.SendData(7, -1, -1, "", 0, 0f, 0f, 0f, 0);
                        }
                    }
                    else
                    {
                        if (Main.invasionType == 2)
                        {
                            NPC.downedFrost = true;
                        }
                        else
                        {
                            if (Main.invasionType == 3)
                            {
                                NPC.downedPirates = true;
                            }
                        }
                    }
                    Main.InvasionWarning();
                    Main.invasionType = 0;
                    Main.invasionDelay = 7;
                }
                if (Main.invasionX == (double)Main.spawnTileX)
                {
                    return;
                }
                float num = (float)Main.dayRate;
                if (Main.invasionX > (double)Main.spawnTileX)
                {
                    Main.invasionX -= (double)num;
                    if (Main.invasionX <= (double)Main.spawnTileX)
                    {
                        Main.invasionX = (double)Main.spawnTileX;
                        Main.InvasionWarning();
                    }
                    else
                    {
                        Main.invasionWarn--;
                    }
                }
                else
                {
                    if (Main.invasionX < (double)Main.spawnTileX)
                    {
                        Main.invasionX += (double)num;
                        if (Main.invasionX >= (double)Main.spawnTileX)
                        {
                            Main.invasionX = (double)Main.spawnTileX;
                            Main.InvasionWarning();
                        }
                        else
                        {
                            Main.invasionWarn--;
                        }
                    }
                }
                if (Main.invasionWarn <= 0)
                {
                    Main.invasionWarn = 3600;
                    Main.InvasionWarning();
                }
            }
        }
        private static void InvasionWarning()
        {
            string text;
            if (Main.invasionSize <= 0)
            {
                if (Main.invasionType == 2)
                {
                    text = Lang.misc[4];
                }
                else
                {
                    if (Main.invasionType == 3)
                    {
                        text = Lang.misc[24];
                    }
                    else
                    {
                        text = Lang.misc[0];
                    }
                }
            }
            else
            {
                if (Main.invasionX < (double)Main.spawnTileX)
                {
                    if (Main.invasionType == 2)
                    {
                        text = Lang.misc[5];
                    }
                    else
                    {
                        if (Main.invasionType == 3)
                        {
                            text = Lang.misc[25];
                        }
                        else
                        {
                            text = Lang.misc[1];
                        }
                    }
                }
                else
                {
                    if (Main.invasionX > (double)Main.spawnTileX)
                    {
                        if (Main.invasionType == 2)
                        {
                            text = Lang.misc[6];
                        }
                        else
                        {
                            if (Main.invasionType == 3)
                            {
                                text = Lang.misc[26];
                            }
                            else
                            {
                                text = Lang.misc[2];
                            }
                        }
                    }
                    else
                    {
                        if (Main.invasionType == 2)
                        {
                            text = Lang.misc[7];
                        }
                        else
                        {
                            if (Main.invasionType == 3)
                            {
                                text = Lang.misc[27];
                            }
                            else
                            {
                                text = Lang.misc[3];
                            }
                        }
                    }
                }
            }
            if (Main.netMode == 0)
            {
                Main.NewText(text, 175, 75, 255, false);
                return;
            }
            if (Main.netMode == 2)
            {
                NetMessage.SendData(25, -1, -1, text, 255, 175f, 75f, 255f, 0);
            }
        }
        public static void StartInvasion(int type = 1)
        {
            if (Main.invasionType == 0 && Main.invasionDelay == 0)
            {
                int num = 0;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active && Main.player[i].statLifeMax >= 200)
                    {
                        num++;
                    }
                }
                if (num > 0)
                {
                    Main.invasionType = type;
                    Main.invasionSize = 80 + 40 * num;
                    if (type == 3)
                    {
                        Main.invasionSize += 40 + 20 * num;
                    }
                    Main.invasionWarn = 0;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.invasionX = 0.0;
                        return;
                    }
                    Main.invasionX = (double)Main.maxTilesX;
                }
            }
        }

        private static void UpdateMenu()
        {
            Main.playerInventory = false;
            Main.exitScale = 0.8f;
            if (Main.netMode == 0)
            {
                Main.maxRaining = 0f;
                Main.raining = false;
                if (!Main.grabSky)
                {
                    Main.time += 86.4;
                    if (!Main.dayTime)
                    {
                        if (Main.time > 32400.0)
                        {
                            Main.bloodMoon = false;
                            Main.time = 0.0;
                            Main.dayTime = true;
                            Main.moonPhase++;
                            if (Main.moonPhase >= 8)
                            {
                                Main.moonPhase = 0;
                                return;
                            }
                        }
                    }
                    else
                    {
                        if (Main.time > 54000.0)
                        {
                            Main.time = 0.0;
                            Main.dayTime = false;
                            return;
                        }
                    }
                }
            }
            else
            {
                if (Main.netMode == 1)
                {
                    Main.UpdateTime();
                }
            }
        }
    }
}
