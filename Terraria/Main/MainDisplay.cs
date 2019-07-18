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
using Terraria.Terraria.ID;
namespace Terraria
{
    public partial class Main
    {
        protected void LoadBackground(int i)
        {
            if (i >= 0 && !Main.backgroundLoaded[i])
            {
                Main.backgroundTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Background_",
					i
				}));
                Main.backgroundWidth[i] = Main.backgroundTexture[i].Width;
                Main.backgroundHeight[i] = Main.backgroundTexture[i].Height;
                Main.backgroundLoaded[i] = true;
                if (Main.backgroundWidth[i] == 0)
                {
                    Debugger.Break();
                }
            }
        }
        protected void LoadNPC(int i)
        {
            if (!Main.NPCLoaded[i] || Main.npcTexture[i] == null)
            {
                Main.npcTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"NPC_",
					i
				}));
                Main.NPCLoaded[i] = true;
            }
        }
        protected void LoadProjectile(int i)
        {
            if (!Main.projectileLoaded[i])
            {
                Main.projectileTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Projectile_",
					i
				}));
                Main.projectileLoaded[i] = true;
            }
        }
        protected void LoadGore(int i)
        {
            if (!Main.goreLoaded[i])
            {
                Main.goreTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Gore_",
					i
				}));
                Main.goreLoaded[i] = true;
            }
        }
        protected void LoadWall(int i)
        {
            if (!Main.wallLoaded[i])
            {
                Main.wallTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Wall_",
					i
				}));
                Main.wallLoaded[i] = true;
            }
        }
        protected void LoadTiles(int i)
        {
            if (!Main.tileSetsLoaded[i])
            {
                Main.tileTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Tiles_",
					i
				}));
                Main.tileSetsLoaded[i] = true;
            }
        }
        protected void LoadItemFlames(int i)
        {
            if (!Main.itemFlameLoaded[i])
            {
                try
                {
                    Main.itemFlameTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
					{
						"Images",
						Path.DirectorySeparatorChar,
						"ItemFlame_",
						i
					}));
                }
                catch
                {
                }
                Main.itemFlameLoaded[i] = true;
            }
        }
        protected void LoadWings(int i)
        {
            if (!Main.wingsLoaded[i])
            {
                Main.wingsTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Wings_",
					i
				}));
                Main.wingsLoaded[i] = true;
            }
        }
        protected void LoadHair(int i)
        {
            if (!Main.hairLoaded[i])
            {
                Main.playerHairTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Player_Hair_",
					i + 1
				}));
                Main.playerHairAltTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Player_HairAlt_",
					i + 1
				}));
                Main.hairLoaded[i] = true;
            }
        }
        protected void LoadArmorHead(int i)
        {
            if (!Main.armorHeadLoaded[i])
            {
                Main.armorHeadTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Head_",
					i
				}));
                Main.armorHeadLoaded[i] = true;
            }
        }
        protected void LoadArmorBody(int i)
        {
            if (!Main.armorBodyLoaded[i])
            {
                Main.femaleBodyTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Female_Body_",
					i
				}));
                Main.armorBodyTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Body_",
					i
				}));
                Main.armorArmTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Arm_",
					i
				}));
                Main.armorBodyLoaded[i] = true;
            }
        }
        protected void LoadArmorLegs(int i)
        {
            if (!Main.armorLegsLoaded[i])
            {
                Main.armorLegTexture[i] = base.Content.Load<Texture2D>(string.Concat(new object[]
				{
					"Images",
					Path.DirectorySeparatorChar,
					"Armor_Legs_",
					i
				}));
                Main.armorLegsLoaded[i] = true;
            }
        }
        protected void LoadAccHandsOn(int i)
        {
            if (!Main.accHandsOnLoaded[i])
            {
                Main.accHandsOnTexture[i] = base.Content.Load<Texture2D>("Images/Acc_HandsOn_" + i);
                Main.accHandsOnLoaded[i] = true;
            }
        }
        protected void LoadAccHandsOff(int i)
        {
            if (!Main.accHandsOffLoaded[i])
            {
                Main.accHandsOffTexture[i] = base.Content.Load<Texture2D>("Images/Acc_HandsOff_" + i);
                Main.accHandsOffLoaded[i] = true;
            }
        }
        protected void LoadAccBack(int i)
        {
            if (!Main.accBackLoaded[i])
            {
                Main.accBackTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Back_" + i);
                Main.accBackLoaded[i] = true;
            }
        }
        protected void LoadAccFront(int i)
        {
            if (!Main.accFrontLoaded[i])
            {
                Main.accFrontTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Front_" + i);
                Main.accFrontLoaded[i] = true;
            }
        }
        protected void LoadAccShoes(int i)
        {
            if (!Main.accShoesLoaded[i])
            {
                Main.accShoesTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Shoes_" + i);
                Main.accShoesLoaded[i] = true;
            }
        }
        protected void LoadAccWaist(int i)
        {
            if (!Main.accWaistLoaded[i])
            {
                Main.accWaistTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Waist_" + i);
                Main.accWaistLoaded[i] = true;
            }
        }
        protected void LoadAccShield(int i)
        {
            if (!Main.accShieldLoaded[i])
            {
                Main.accShieldTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Shield_" + i);
                Main.accShieldLoaded[i] = true;
            }
        }
        protected void LoadAccNeck(int i)
        {
            if (!Main.accNeckLoaded[i])
            {
                Main.accNeckTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Neck_" + i);
                Main.accNeckLoaded[i] = true;
            }
        }
        protected void LoadAccFace(int i)
        {
            if (!Main.accFaceLoaded[i])
            {
                Main.accFaceTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Face_" + i);
                Main.accFaceLoaded[i] = true;
            }
        }
        protected void LoadAccBalloon(int i)
        {
            if (!Main.accballoonLoaded[i])
            {
                Main.accBalloonTexture[i] = base.Content.Load<Texture2D>("Images/Acc_Balloon_" + i);
                Main.accballoonLoaded[i] = true;
            }
        }
        protected void DrawSurfaceBG()
        {
            if (!Main.mapFullscreen && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.cloud[i].active && Main.cloud[i].scale < 1f)
                    {
                        Color color = Main.cloud[i].cloudColor(Main.bgColor);
                        float num = Main.cloud[i].scale * 0.8f;
                        float num2 = (Main.cloud[i].scale + 1f) / 2f * 0.9f;
                        color.R = (byte)((float)color.R * num);
                        color.G = (byte)((float)color.G * num2);
                        Main.atmo = 1f;
                        if (Main.atmo < 1f)
                        {
                            color.R = (byte)((float)color.R * Main.atmo);
                            color.G = (byte)((float)color.G * Main.atmo);
                            color.B = (byte)((float)color.B * Main.atmo);
                            color.A = (byte)((float)color.A * Main.atmo);
                        }
                        float num3 = Main.cloud[i].position.Y * ((float)Main.screenHeight / 600f);
                        num3 = Main.cloud[i].position.Y + (float)((int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 750.0 + 830.0)) + (float)((int)this.scAdj);
                        Main.spriteBatch.Draw(Main.cloudTexture[Main.cloud[i].type], new Vector2(Main.cloud[i].position.X + (float)Main.cloudTexture[Main.cloud[i].type].Width * 0.5f, num3 + (float)Main.cloudTexture[Main.cloud[i].type].Height * 0.5f), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[i].type].Width, Main.cloudTexture[Main.cloud[i].type].Height)), color, Main.cloud[i].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[i].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[i].type].Height * 0.5f), Main.cloud[i].scale, Main.cloud[i].spriteDir, 0f);
                    }
                }
            }
            Main.atmo = 1f;
            Main.bgScale *= 2f;
            this.bgParrallax = 0.15;
            if (Main.atmo < 1f)
            {
                Main.backColor.R = (byte)((float)Main.backColor.R * Main.atmo);
                Main.backColor.G = (byte)((float)Main.backColor.G * Main.atmo);
                Main.backColor.B = (byte)((float)Main.backColor.B * Main.atmo);
                Main.backColor.A = (byte)((float)Main.backColor.A * Main.atmo);
            }
            if (!Main.mapFullscreen && (double)(Main.screenPosition.Y / 16f) <= Main.worldSurface + 10.0)
            {
                if (Main.owBack)
                {
                    if (Main.cloudBGActive > 0f)
                    {
                        Main.cloudBGAlpha += 0.0005f * (float)Main.dayRate;
                        if (Main.cloudBGAlpha > 1f)
                        {
                            Main.cloudBGAlpha = 1f;
                        }
                    }
                    else
                    {
                        Main.cloudBGAlpha -= 0.0005f * (float)Main.dayRate;
                        if (Main.cloudBGAlpha < 0f)
                        {
                            Main.cloudBGAlpha = 0f;
                        }
                    }
                    if (Main.cloudBGAlpha > 0f)
                    {
                        this.LoadBackground(Main.cloudBG[0]);
                        this.LoadBackground(Main.cloudBG[1]);
                        Main.bgScale *= 2f;
                        this.bgParrallax = 0.15;
                        float num4 = Main.cloudBGAlpha;
                        if (num4 > 1f)
                        {
                            num4 = 1f;
                        }
                        Main.bgScale = 1.65f;
                        this.bgParrallax = 0.090000003576278687;
                        if (base.IsActive)
                        {
                            Main.cloudBGX[0] += Main.windSpeed * (float)this.bgParrallax * 5f * (float)Main.dayRate;
                        }
                        if (Main.cloudBGX[0] > (float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale)
                        {
                            Main.cloudBGX[0] -= (float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale;
                        }
                        if (Main.cloudBGX[0] < (float)(-(float)Main.backgroundWidth[Main.cloudBG[0]]) * Main.bgScale)
                        {
                            Main.cloudBGX[0] += (float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale;
                        }
                        Main.bgW = (int)((float)Main.backgroundWidth[Main.cloudBG[0]] * Main.bgScale);
                        this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 900.0 + 600.0) + (int)this.scAdj;
                        if (Main.gameMenu)
                        {
                            this.bgTop = -150;
                        }
                        this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2) - (double)Main.bgW);
                        this.bgStart += (int)Main.cloudBGX[0];
                        this.bgLoops = Main.screenWidth / Main.bgW + 2 + 2;
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * num4);
                        Main.backColor.G = (byte)((float)Main.backColor.G * num4);
                        Main.backColor.B = (byte)((float)Main.backColor.B * num4);
                        Main.backColor.A = (byte)((float)Main.backColor.A * num4);
                        for (int j = 0; j < this.bgLoops; j++)
                        {
                            Main.spriteBatch.Draw(Main.backgroundTexture[Main.cloudBG[0]], new Vector2((float)(this.bgStart + Main.bgW * j), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.cloudBG[0]], Main.backgroundHeight[Main.cloudBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                        }
                        num4 = Main.cloudBGAlpha * 1.5f;
                        if (num4 > 1f)
                        {
                            num4 = 1f;
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * num4);
                        Main.backColor.G = (byte)((float)Main.backColor.G * num4);
                        Main.backColor.B = (byte)((float)Main.backColor.B * num4);
                        Main.backColor.A = (byte)((float)Main.backColor.A * num4);
                        Main.bgScale = 1.85f;
                        this.bgParrallax = 0.12;
                        if (base.IsActive)
                        {
                            Main.cloudBGX[1] += Main.windSpeed * (float)this.bgParrallax * 5f * (float)Main.dayRate;
                        }
                        if (Main.cloudBGX[1] > (float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale)
                        {
                            Main.cloudBGX[1] -= (float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale;
                        }
                        if (Main.cloudBGX[1] < (float)(-(float)Main.backgroundWidth[Main.cloudBG[1]]) * Main.bgScale)
                        {
                            Main.cloudBGX[1] += (float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale;
                        }
                        Main.bgW = (int)((float)Main.backgroundWidth[Main.cloudBG[1]] * Main.bgScale);
                        this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1100.0 + 750.0) + (int)this.scAdj;
                        if (Main.gameMenu)
                        {
                            this.bgTop = -50;
                        }
                        this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2) - (double)Main.bgW);
                        this.bgStart += (int)Main.cloudBGX[1];
                        this.bgLoops = Main.screenWidth / Main.bgW + 2 + 2;
                        for (int k = 0; k < this.bgLoops; k++)
                        {
                            Main.spriteBatch.Draw(Main.backgroundTexture[Main.cloudBG[1]], new Vector2((float)(this.bgStart + Main.bgW * k), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.cloudBG[1]], Main.backgroundHeight[Main.cloudBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                        }
                    }
                    this.LoadBackground(Main.treeMntBG[0]);
                    this.LoadBackground(Main.treeMntBG[1]);
                    Main.bgScale = 1f;
                    this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1300.0 + 1090.0) + (int)this.scAdj;
                    Main.bgScale *= 2f;
                    this.bgParrallax = 0.15;
                    Main.bgW = (int)((float)Main.backgroundWidth[Main.treeMntBG[0]] * Main.bgScale);
                    this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                    this.bgLoops = Main.screenWidth / Main.bgW + 2;
                    if (Main.gameMenu)
                    {
                        this.bgTop = 100;
                    }
                    if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                    {
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[0]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[0]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[0]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[0]);
                        if (Main.bgAlpha2[0] > 0f)
                        {
                            if (Main.treeMntBG[0] == 93 || (Main.treeMntBG[0] >= 168 && Main.treeMntBG[0] <= 170))
                            {
                                this.bgTop -= 50;
                            }
                            if (Main.treeMntBG[0] == 171)
                            {
                                this.bgTop -= 100;
                            }
                            if (Main.treeMntBG[0] == 176)
                            {
                                this.bgTop += 250;
                            }
                            if (Main.treeMntBG[0] == 179)
                            {
                                this.bgTop -= 100;
                            }
                            for (int l = 0; l < this.bgLoops; l++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[Main.treeMntBG[0]], new Vector2((float)(this.bgStart + Main.bgW * l), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeMntBG[0]], Main.backgroundHeight[Main.treeMntBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                            if (Main.treeMntBG[0] == 93 || (Main.treeMntBG[0] >= 168 && Main.treeMntBG[0] <= 170))
                            {
                                this.bgTop += 50;
                            }
                            if (Main.treeMntBG[0] == 171)
                            {
                                this.bgTop += 100;
                            }
                            if (Main.treeMntBG[0] == 176)
                            {
                                this.bgTop -= 250;
                            }
                            if (Main.treeMntBG[0] == 179)
                            {
                                this.bgTop += 100;
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[1]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[1]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[1]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[1]);
                        if (Main.bgAlpha2[1] > 0f)
                        {
                            this.LoadBackground(23);
                            for (int m = 0; m < this.bgLoops; m++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[23], new Vector2((float)(this.bgStart + Main.bgW * m), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[23], Main.backgroundHeight[23])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[2]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[2]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[2]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[2]);
                        if (Main.bgAlpha2[2] > 0f)
                        {
                            this.LoadBackground(24);
                            for (int n = 0; n < this.bgLoops; n++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[24], new Vector2((float)(this.bgStart + Main.bgW * n), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[24], Main.backgroundHeight[24])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[4]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[4]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[4]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[4]);
                        if (Main.bgAlpha2[4] > 0f)
                        {
                            this.LoadBackground(Main.snowMntBG[0]);
                            for (int num5 = 0; num5 < this.bgLoops; num5++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[Main.snowMntBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num5), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowMntBG[0]], Main.backgroundHeight[Main.snowMntBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[5]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[5]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[5]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[5]);
                        if (Main.bgAlpha2[5] > 0f)
                        {
                            this.LoadBackground(24);
                            for (int num6 = 0; num6 < this.bgLoops; num6++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[24], new Vector2((float)(this.bgStart + Main.bgW * num6), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[24], Main.backgroundHeight[24])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                this.cTop = (float)(this.bgTop - 50);
                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                {
                    for (int num7 = 0; num7 < 200; num7++)
                    {
                        if (Main.cloud[num7].active && (double)Main.cloud[num7].scale < 1.15 && Main.cloud[num7].scale >= 1f)
                        {
                            Color color2 = Main.cloud[num7].cloudColor(Main.bgColor);
                            if (Main.atmo < 1f)
                            {
                                color2.R = (byte)((float)color2.R * Main.atmo);
                                color2.G = (byte)((float)color2.G * Main.atmo);
                                color2.B = (byte)((float)color2.B * Main.atmo);
                                color2.A = (byte)((float)color2.A * Main.atmo);
                            }
                            float num8 = Main.cloud[num7].position.Y * ((float)Main.screenHeight / 600f);
                            float num9 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
                            if (num9 < 0f)
                            {
                                num9 = 0f;
                            }
                            if (num9 > 1f)
                            {
                            }
                            if (Main.gameMenu)
                            {
                            }
                            Main.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num7].type], new Vector2(Main.cloud[num7].position.X + (float)Main.cloudTexture[Main.cloud[num7].type].Width * 0.5f, num8 + (float)Main.cloudTexture[Main.cloud[num7].type].Height * 0.5f + this.cTop + 200f), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[num7].type].Width, Main.cloudTexture[Main.cloud[num7].type].Height)), color2, Main.cloud[num7].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num7].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num7].type].Height * 0.5f), Main.cloud[num7].scale, Main.cloud[num7].spriteDir, 0f);
                        }
                    }
                }
                if (Main.holyTiles > 0 && Main.owBack)
                {
                    this.bgParrallax = 0.17;
                    Main.bgScale = 1.1f;
                    Main.bgScale *= 2f;
                    Main.bgW = (int)((double)(3500f * Main.bgScale) * 1.05);
                    this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                    this.bgLoops = Main.screenWidth / Main.bgW + 2;
                    this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1400.0 + 900.0) + (int)this.scAdj;
                    if (Main.gameMenu)
                    {
                        this.bgTop = 230;
                        this.bgStart -= 500;
                    }
                    Color color3 = Main.trueBackColor;
                    float num10 = (float)Main.holyTiles / 400f;
                    if (num10 > 0.5f)
                    {
                        num10 = 0.5f;
                    }
                    color3.R = (byte)((float)color3.R * num10);
                    color3.G = (byte)((float)color3.G * num10);
                    color3.B = (byte)((float)color3.B * num10);
                    color3.A = (byte)((float)color3.A * num10 * 0.8f);
                    if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                    {
                        this.LoadBackground(18);
                        this.LoadBackground(19);
                        for (int num11 = 0; num11 < this.bgLoops; num11++)
                        {
                            Main.spriteBatch.Draw(Main.backgroundTexture[18], new Vector2((float)(this.bgStart + Main.bgW * num11), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[18], Main.backgroundHeight[18])), color3, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            Main.spriteBatch.Draw(Main.backgroundTexture[19], new Vector2((float)(this.bgStart + Main.bgW * num11 + 1700), (float)(this.bgTop + 100)), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[19], Main.backgroundHeight[19])), color3, 0f, default(Vector2), Main.bgScale * 0.9f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (Main.treeMntBG[1] > -1)
                {
                    this.LoadBackground(Main.treeMntBG[1]);
                    this.bgParrallax = 0.2;
                    Main.bgScale = 1.15f;
                    Main.bgScale *= 2f;
                    Main.bgW = (int)((float)Main.backgroundWidth[Main.treeMntBG[1]] * Main.bgScale);
                    this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                    this.bgLoops = Main.screenWidth / Main.bgW + 2;
                    this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1400.0 + 1260.0) + (int)this.scAdj;
                }
                if (Main.owBack)
                {
                    if (Main.gameMenu)
                    {
                        this.bgTop = 230;
                        this.bgStart -= 500;
                    }
                    if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                    {
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[0]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[0]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[0]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[0]);
                        if (Main.bgAlpha2[0] > 0f && Main.treeMntBG[1] > -1)
                        {
                            if (Main.treeMntBG[1] == 172)
                            {
                                this.bgTop += 130;
                            }
                            if (Main.treeMntBG[1] == 177)
                            {
                                this.bgTop += 200;
                            }
                            if (Main.treeMntBG[1] >= 180 && Main.treeMntBG[1] <= 183)
                            {
                                this.bgTop -= 350;
                            }
                            for (int num12 = 0; num12 < this.bgLoops; num12++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[Main.treeMntBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num12), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeMntBG[1]], Main.backgroundHeight[Main.treeMntBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                            if (Main.treeMntBG[1] == 172)
                            {
                                this.bgTop -= 130;
                            }
                            if (Main.treeMntBG[1] == 177)
                            {
                                this.bgTop -= 200;
                            }
                            if (Main.treeMntBG[1] >= 180 && Main.treeMntBG[1] <= 183)
                            {
                                this.bgTop += 350;
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[1]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[1]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[1]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[1]);
                        if (Main.bgAlpha2[1] > 0f)
                        {
                            this.LoadBackground(22);
                            for (int num13 = 0; num13 < this.bgLoops; num13++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[22], new Vector2((float)(this.bgStart + Main.bgW * num13), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[22], Main.backgroundHeight[22])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[2]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[2]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[2]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[2]);
                        if (Main.bgAlpha2[2] > 0f)
                        {
                            this.LoadBackground(25);
                            for (int num14 = 0; num14 < this.bgLoops; num14++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[25], new Vector2((float)(this.bgStart + Main.bgW * num14), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[25], Main.backgroundHeight[25])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[3]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[3]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[3]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[3]);
                        if (Main.bgAlpha2[3] > 0f)
                        {
                            this.LoadBackground(Main.oceanBG);
                            for (int num15 = 0; num15 < this.bgLoops; num15++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[Main.oceanBG], new Vector2((float)(this.bgStart + Main.bgW * num15), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.oceanBG], Main.backgroundHeight[Main.oceanBG])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[4]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[4]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[4]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[4]);
                        if (Main.bgAlpha2[4] > 0f)
                        {
                            this.LoadBackground(Main.snowMntBG[1]);
                            for (int num16 = 0; num16 < this.bgLoops; num16++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[Main.snowMntBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num16), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowMntBG[1]], Main.backgroundHeight[Main.snowMntBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha2[5]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha2[5]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha2[5]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha2[5]);
                        if (Main.bgAlpha2[5] > 0f)
                        {
                            this.LoadBackground(42);
                            for (int num17 = 0; num17 < this.bgLoops; num17++)
                            {
                                Main.spriteBatch.Draw(Main.backgroundTexture[42], new Vector2((float)(this.bgStart + Main.bgW * num17), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[42], Main.backgroundHeight[42])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                this.cTop = (float)this.bgTop * 1.01f - 150f;
                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                {
                    for (int num18 = 0; num18 < 200; num18++)
                    {
                        if (Main.cloud[num18].active && Main.cloud[num18].scale >= 1.15f)
                        {
                            Color color4 = Main.cloud[num18].cloudColor(Main.bgColor);
                            if (Main.atmo < 1f)
                            {
                                color4.R = (byte)((float)color4.R * Main.atmo);
                                color4.G = (byte)((float)color4.G * Main.atmo);
                                color4.B = (byte)((float)color4.B * Main.atmo);
                                color4.A = (byte)((float)color4.A * Main.atmo);
                            }
                            float num19 = Main.cloud[num18].position.Y * ((float)Main.screenHeight / 600f) - 100f;
                            float num20 = (float)((double)(Main.screenPosition.Y / 16f - 24f) / Main.worldSurface);
                            if (num20 < 0f)
                            {
                                num20 = 0f;
                            }
                            if (num20 > 1f)
                            {
                            }
                            if (Main.gameMenu)
                            {
                            }
                            Main.spriteBatch.Draw(Main.cloudTexture[Main.cloud[num18].type], new Vector2(Main.cloud[num18].position.X + (float)Main.cloudTexture[Main.cloud[num18].type].Width * 0.5f, num19 + (float)Main.cloudTexture[Main.cloud[num18].type].Height * 0.5f + this.cTop), new Rectangle?(new Rectangle(0, 0, Main.cloudTexture[Main.cloud[num18].type].Width, Main.cloudTexture[Main.cloud[num18].type].Height)), color4, Main.cloud[num18].rotation, new Vector2((float)Main.cloudTexture[Main.cloud[num18].type].Width * 0.5f, (float)Main.cloudTexture[Main.cloud[num18].type].Height * 0.5f), Main.cloud[num18].scale, Main.cloud[num18].spriteDir, 0f);
                        }
                    }
                }
            }
            if (!Main.mapFullscreen)
            {
                for (int num21 = 0; num21 < 10; num21++)
                {
                    if (Main.bgStyle == num21)
                    {
                        Main.bgAlpha[num21] += Main.tranSpeed;
                        if (Main.bgAlpha[num21] > 1f)
                        {
                            Main.bgAlpha[num21] = 1f;
                        }
                    }
                    else
                    {
                        Main.bgAlpha[num21] -= Main.tranSpeed;
                        if (Main.bgAlpha[num21] < 0f)
                        {
                            Main.bgAlpha[num21] = 0f;
                        }
                    }
                    if (Main.owBack)
                    {
                        Main.backColor = Main.trueBackColor;
                        Main.backColor.R = (byte)((float)Main.backColor.R * Main.bgAlpha[num21]);
                        Main.backColor.G = (byte)((float)Main.backColor.G * Main.bgAlpha[num21]);
                        Main.backColor.B = (byte)((float)Main.backColor.B * Main.bgAlpha[num21]);
                        Main.backColor.A = (byte)((float)Main.backColor.A * Main.bgAlpha[num21]);
                        if (Main.bgAlpha[num21] > 0f && num21 == 3)
                        {
                            this.LoadBackground(Main.jungleBG[0]);
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.jungleBG[0]] * Main.bgScale);
                            this.bgParrallax = 0.4;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1660.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 320;
                            }
                            if (Main.jungleBG[0] == 59)
                            {
                                this.bgTop -= 200;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num22 = 0; num22 < this.bgLoops; num22++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.jungleBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num22), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.jungleBG[0]], Main.backgroundHeight[Main.jungleBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            this.LoadBackground(Main.jungleBG[1]);
                            Main.bgScale = 1.31f;
                            Main.bgScale *= 2f;
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.jungleBG[1]] * Main.bgScale);
                            this.bgParrallax = 0.43;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1840.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 400;
                                this.bgStart -= 80;
                            }
                            if (Main.jungleBG[1] == 60)
                            {
                                this.bgTop -= 175;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num23 = 0; num23 < this.bgLoops; num23++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.jungleBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num23), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.jungleBG[1]], Main.backgroundHeight[Main.jungleBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.FlipHorizontally, 0f);
                                }
                            }
                            Main.bgScale = 1.34f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.jungleBG[2]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.jungleBG[2]] * Main.bgScale);
                            this.bgParrallax = 0.49;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2060.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 480;
                                this.bgStart -= 120;
                            }
                            if (Main.jungleBG[2] == 61)
                            {
                                this.bgTop -= 150;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num24 = 0; num24 < this.bgLoops; num24++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.jungleBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num24), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.jungleBG[2]], Main.backgroundHeight[Main.jungleBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 2)
                        {
                            this.LoadBackground(Main.desertBG[0]);
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.desertBG[0]] * Main.bgScale);
                            this.bgParrallax = 0.37;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 320;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num25 = 0; num25 < this.bgLoops; num25++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.desertBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num25), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.desertBG[0]], Main.backgroundHeight[Main.desertBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            Main.bgScale = 1.34f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.desertBG[1]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.desertBG[1]] * Main.bgScale);
                            this.bgParrallax = 0.49;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 480;
                                this.bgStart -= 120;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num26 = 0; num26 < this.bgLoops; num26++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.desertBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num26), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.desertBG[1]], Main.backgroundHeight[Main.desertBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 5)
                        {
                            this.LoadBackground(26);
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            Main.bgW = (int)((float)Main.backgroundWidth[26] * Main.bgScale);
                            this.bgParrallax = 0.37;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1750.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 320;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num27 = 0; num27 < this.bgLoops; num27++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[26], new Vector2((float)(this.bgStart + Main.bgW * num27), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[26], Main.backgroundHeight[26])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            Main.bgScale = 1.34f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(27);
                            Main.bgW = (int)((float)Main.backgroundWidth[27] * Main.bgScale);
                            this.bgParrallax = 0.49;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2150.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 480;
                                this.bgStart -= 120;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num28 = 0; num28 < this.bgLoops; num28++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[27], new Vector2((float)(this.bgStart + Main.bgW * num28), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[27], Main.backgroundHeight[27])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 1)
                        {
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.corruptBG[0]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.corruptBG[0]] * Main.bgScale);
                            this.bgParrallax = 0.4;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 320;
                            }
                            if (Main.corruptBG[0] == 56)
                            {
                                this.bgTop -= 100;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num29 = 0; num29 < this.bgLoops; num29++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.corruptBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num29), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.corruptBG[0]], Main.backgroundHeight[Main.corruptBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            Main.bgScale = 1.31f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.corruptBG[1]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.corruptBG[1]] * Main.bgScale);
                            this.bgParrallax = 0.43;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 400;
                                this.bgStart -= 80;
                            }
                            if (Main.corruptBG[0] == 56)
                            {
                                this.bgTop -= 100;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                try
                                {
                                    for (int num30 = 0; num30 < this.bgLoops; num30++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.corruptBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num30), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.corruptBG[1]], Main.backgroundHeight[Main.corruptBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.FlipHorizontally, 0f);
                                    }
                                }
                                catch
                                {
                                    this.LoadBackground(Main.corruptBG[1]);
                                }
                            }
                            Main.bgScale = 1.34f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.corruptBG[2]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.corruptBG[2]] * Main.bgScale);
                            this.bgParrallax = 0.49;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 480;
                                this.bgStart -= 120;
                            }
                            if (Main.corruptBG[0] == 56)
                            {
                                this.bgTop -= 100;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num31 = 0; num31 < this.bgLoops; num31++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.corruptBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num31), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.corruptBG[2]], Main.backgroundHeight[Main.corruptBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 6)
                        {
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.hallowBG[0]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.hallowBG[0]] * Main.bgScale);
                            this.bgParrallax = 0.4;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 320;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num32 = 0; num32 < this.bgLoops; num32++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.hallowBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num32), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.hallowBG[0]], Main.backgroundHeight[Main.hallowBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            Main.bgScale = 1.31f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.hallowBG[1]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.hallowBG[1]] * Main.bgScale);
                            this.bgParrallax = 0.43;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 400;
                                this.bgStart -= 80;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num33 = 0; num33 < this.bgLoops; num33++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.hallowBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num33), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.hallowBG[1]], Main.backgroundHeight[Main.hallowBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            Main.bgScale = 1.34f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.hallowBG[2]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.hallowBG[2]] * Main.bgScale);
                            this.bgParrallax = 0.49;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 480;
                                this.bgStart -= 120;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num34 = 0; num34 < this.bgLoops; num34++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.hallowBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num34), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.hallowBG[2]], Main.backgroundHeight[Main.hallowBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 0)
                        {
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            this.bgParrallax = 0.4;
                            if (Main.treeBG[0] == 91)
                            {
                                this.bgParrallax = 0.27000001072883606;
                                Main.bgScale = 1.2f;
                                Main.bgScale *= 2f;
                            }
                            if (Main.treeBG[0] == 173)
                            {
                                this.bgParrallax = 0.25;
                                Main.bgScale = 1.3f;
                                Main.bgScale *= 2f;
                            }
                            if (Main.treeBG[0] == 178)
                            {
                                this.bgParrallax = 0.30000001192092896;
                                Main.bgScale = 1.2f;
                                Main.bgScale *= 2f;
                            }
                            if (Main.treeBG[0] == 184)
                            {
                                this.bgParrallax = 0.25;
                                Main.bgScale = 1.2f;
                                Main.bgScale *= 2f;
                            }
                            if (Main.treeBG[0] >= 0)
                            {
                                this.LoadBackground(Main.treeBG[0]);
                                Main.bgW = (int)((float)Main.backgroundWidth[Main.treeBG[0]] * Main.bgScale);
                                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
                                if (Main.treeBG[0] == 91)
                                {
                                    this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1600.0 + 1400.0) + (int)this.scAdj;
                                }
                                if (Main.treeBG[0] == 173)
                                {
                                    this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1600.0 + 1400.0) + (int)this.scAdj;
                                }
                                if (Main.treeBG[0] == 184)
                                {
                                    this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1600.0 + 1400.0) + (int)this.scAdj;
                                }
                                if (Main.gameMenu)
                                {
                                    this.bgTop = 320;
                                }
                                if (Main.treeBG[0] == 50)
                                {
                                    this.bgTop -= 50;
                                }
                                if (Main.treeBG[0] == 53)
                                {
                                    this.bgTop -= 100;
                                }
                                if (Main.treeBG[0] == 91)
                                {
                                    this.bgTop += 200;
                                }
                                if (Main.treeBG[0] == 173)
                                {
                                    this.bgTop += 200;
                                }
                                if (Main.treeBG[0] == 178)
                                {
                                    this.bgTop += 75;
                                }
                                this.bgLoops = Main.screenWidth / Main.bgW + 2;
                                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                                {
                                    for (int num35 = 0; num35 < this.bgLoops; num35++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.treeBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num35), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeBG[0]], Main.backgroundHeight[Main.treeBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                            if (Main.treeBG[1] >= 0)
                            {
                                this.LoadBackground(Main.treeBG[1]);
                                Main.bgScale = 1.31f;
                                Main.bgScale *= 2f;
                                Main.bgW = (int)((float)Main.backgroundWidth[Main.treeBG[1]] * Main.bgScale);
                                this.bgParrallax = 0.43;
                                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
                                if (Main.gameMenu)
                                {
                                    this.bgTop = 400;
                                    this.bgStart -= 80;
                                }
                                if (Main.treeBG[1] == 51)
                                {
                                    this.bgTop -= 50;
                                }
                                if (Main.treeBG[1] == 54)
                                {
                                    this.bgTop -= 100;
                                }
                                this.bgLoops = Main.screenWidth / Main.bgW + 2;
                                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                                {
                                    for (int num36 = 0; num36 < this.bgLoops; num36++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.treeBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num36), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeBG[1]], Main.backgroundHeight[Main.treeBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.FlipHorizontally, 0f);
                                    }
                                }
                            }
                            if (Main.treeBG[2] >= 0)
                            {
                                this.LoadBackground(Main.treeBG[2]);
                                Main.bgScale = 1.34f;
                                Main.bgScale *= 2f;
                                this.bgParrallax = 0.49;
                                if (Main.treeBG[0] == 91)
                                {
                                    Main.bgScale = 1.3f;
                                    Main.bgScale *= 2f;
                                    this.bgParrallax = 0.42;
                                }
                                Main.bgW = (int)((float)Main.backgroundWidth[Main.treeBG[2]] * Main.bgScale);
                                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
                                if (Main.gameMenu)
                                {
                                    this.bgTop = 480;
                                    this.bgStart -= 120;
                                }
                                if (Main.treeBG[2] == 52)
                                {
                                    this.bgTop -= 50;
                                }
                                if (Main.treeBG[2] == 55)
                                {
                                    this.bgTop -= 100;
                                }
                                if (Main.treeBG[2] == 92)
                                {
                                    this.bgTop += 150;
                                }
                                this.bgLoops = Main.screenWidth / Main.bgW + 2;
                                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                                {
                                    for (int num37 = 0; num37 < this.bgLoops; num37++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.treeBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num37), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.treeBG[2]], Main.backgroundHeight[Main.treeBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 7)
                        {
                            if (Main.snowBG[0] >= 0)
                            {
                                Main.bgScale = 1.25f;
                                Main.bgScale *= 2f;
                                this.LoadBackground(Main.snowBG[0]);
                                Main.bgW = (int)((float)Main.backgroundWidth[Main.snowBG[0]] * Main.bgScale);
                                this.bgParrallax = 0.4;
                                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
                                if (Main.gameMenu)
                                {
                                    this.bgTop = 320;
                                }
                                this.bgLoops = Main.screenWidth / Main.bgW + 2;
                                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                                {
                                    for (int num38 = 0; num38 < this.bgLoops; num38++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.snowBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num38), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowBG[0]], Main.backgroundHeight[Main.snowBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                            if (Main.snowBG[1] >= 0)
                            {
                                Main.bgScale = 1.31f;
                                Main.bgScale *= 2f;
                                this.LoadBackground(Main.snowBG[1]);
                                Main.bgW = (int)((float)Main.backgroundWidth[Main.snowBG[1]] * Main.bgScale);
                                this.bgParrallax = 0.43;
                                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
                                if (Main.gameMenu)
                                {
                                    this.bgTop = 400;
                                    this.bgStart -= 80;
                                }
                                this.bgLoops = Main.screenWidth / Main.bgW + 2;
                                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                                {
                                    for (int num39 = 0; num39 < this.bgLoops; num39++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.snowBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num39), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowBG[1]], Main.backgroundHeight[Main.snowBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                            if (Main.snowBG[2] >= 0)
                            {
                                Main.bgScale = 1.34f;
                                Main.bgScale *= 2f;
                                this.LoadBackground(Main.snowBG[2]);
                                Main.bgW = (int)((float)Main.backgroundWidth[Main.snowBG[2]] * Main.bgScale);
                                this.bgParrallax = 0.49;
                                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
                                if (Main.gameMenu)
                                {
                                    this.bgTop = 480;
                                    this.bgStart -= 120;
                                }
                                this.bgLoops = Main.screenWidth / Main.bgW + 2;
                                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                                {
                                    for (int num40 = 0; num40 < this.bgLoops; num40++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.snowBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num40), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.snowBG[2]], Main.backgroundHeight[Main.snowBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 8)
                        {
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.crimsonBG[0]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.crimsonBG[0]] * Main.bgScale);
                            this.bgParrallax = 0.4;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1500.0) + (int)this.scAdj;
                            if (Main.crimsonBG[0] == 105)
                            {
                                this.bgTop += 50;
                            }
                            if (Main.crimsonBG[0] == 174)
                            {
                                this.bgTop -= 350;
                            }
                            if (Main.gameMenu)
                            {
                                this.bgTop = 320;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num41 = 0; num41 < this.bgLoops; num41++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.crimsonBG[0]], new Vector2((float)(this.bgStart + Main.bgW * num41), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.crimsonBG[0]], Main.backgroundHeight[Main.crimsonBG[0]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            Main.bgScale = 1.31f;
                            Main.bgScale *= 2f;
                            if (Main.crimsonBG[1] > -1)
                            {
                                this.LoadBackground(Main.crimsonBG[1]);
                                Main.bgW = (int)((float)Main.backgroundWidth[Main.crimsonBG[1]] * Main.bgScale);
                                this.bgParrallax = 0.43;
                                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1750.0) + (int)this.scAdj;
                                if (Main.gameMenu)
                                {
                                    this.bgTop = 400;
                                    this.bgStart -= 80;
                                }
                                this.bgLoops = Main.screenWidth / Main.bgW + 2;
                                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                                {
                                    for (int num42 = 0; num42 < this.bgLoops; num42++)
                                    {
                                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.crimsonBG[1]], new Vector2((float)(this.bgStart + Main.bgW * num42), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.crimsonBG[1]], Main.backgroundHeight[Main.crimsonBG[1]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                    }
                                }
                            }
                            Main.bgScale = 1.34f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(Main.crimsonBG[2]);
                            Main.bgW = (int)((float)Main.backgroundWidth[Main.crimsonBG[2]] * Main.bgScale);
                            this.bgParrallax = 0.49;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 2000.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 480;
                                this.bgStart -= 120;
                            }
                            if (Main.crimsonBG[2] == 175)
                            {
                                this.bgStart -= 1000;
                                this.bgTop -= 400;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num43 = 0; num43 < this.bgLoops; num43++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[Main.crimsonBG[2]], new Vector2((float)(this.bgStart + Main.bgW * num43), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[Main.crimsonBG[2]], Main.backgroundHeight[Main.crimsonBG[2]])), Main.backColor, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        if (Main.bgAlpha[num21] > 0f && num21 == 9)
                        {
                            float num44 = (float)Main.backColor.A / 255f;
                            Color color5 = Main.backColor;
                            float num45 = (float)Main.rand.Next(28, 42) * 0.001f;
                            num45 += (float)(270 - (int)Main.mouseTextColor) / 5000f;
                            float num46 = 0.1f;
                            float num47 = 0.15f + num45 / 2f;
                            float num48 = 0.3f + num45;
                            num46 *= 255f;
                            num47 *= 255f;
                            num48 *= 255f;
                            num46 *= 0.33f * num44;
                            num47 *= 0.33f * num44;
                            num48 *= 0.33f * num44;
                            if (num46 > 255f)
                            {
                                num46 = 255f;
                            }
                            if (num47 > 255f)
                            {
                                num47 = 255f;
                            }
                            if (num48 > 255f)
                            {
                                num48 = 255f;
                            }
                            if (num46 > (float)color5.R)
                            {
                                color5.R = (byte)num46;
                            }
                            if (num47 > (float)color5.G)
                            {
                                color5.G = (byte)num47;
                            }
                            if (num48 > (float)color5.B)
                            {
                                color5.B = (byte)num48;
                            }
                            Main.bgScale = 1.25f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(46);
                            Main.bgW = (int)((float)Main.backgroundWidth[46] * Main.bgScale);
                            this.bgParrallax = 0.4;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1800.0 + 1400.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 320;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num49 = 0; num49 < this.bgLoops; num49++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[46], new Vector2((float)(this.bgStart + Main.bgW * num49), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[46], Main.backgroundHeight[46])), color5, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            color5 = Main.backColor;
                            num45 = (float)Main.rand.Next(28, 42) * 0.001f;
                            num45 += (float)(270 - (int)Main.mouseTextColor) / 5000f;
                            num46 = 0.1f;
                            num47 = 0.175f + num45 / 2f;
                            num48 = 0.3f + num45;
                            num46 *= 255f;
                            num47 *= 255f;
                            num48 *= 255f;
                            num46 *= 0.5f * num44;
                            num47 *= 0.5f * num44;
                            num48 *= 0.5f * num44;
                            if (num46 > 255f)
                            {
                                num46 = 255f;
                            }
                            if (num47 > 255f)
                            {
                                num47 = 255f;
                            }
                            if (num48 > 255f)
                            {
                                num48 = 255f;
                            }
                            if (num46 > (float)color5.R)
                            {
                                color5.R = (byte)num46;
                            }
                            if (num47 > (float)color5.G)
                            {
                                color5.G = (byte)num47;
                            }
                            if (num48 > (float)color5.B)
                            {
                                color5.B = (byte)num48;
                            }
                            Main.bgScale = 1.32f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(47);
                            Main.bgW = (int)((float)Main.backgroundWidth[47] * Main.bgScale);
                            this.bgParrallax = 0.43;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1950.0 + 1675.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 400;
                                this.bgStart -= 80;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num50 = 0; num50 < this.bgLoops; num50++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[47], new Vector2((float)(this.bgStart + Main.bgW * num50), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[47], Main.backgroundHeight[47])), color5, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                            color5 = Main.backColor;
                            num45 = (float)Main.rand.Next(28, 42) * 0.001f;
                            num45 += (float)(270 - (int)Main.mouseTextColor) / 3000f;
                            num46 = 0.125f;
                            num47 = 0.2f + num45 / 2f;
                            num48 = 0.3f + num45;
                            num46 *= 255f * num44 * 0.75f;
                            num47 *= 255f * num44 * 0.75f;
                            num48 *= 255f * num44 * 0.75f;
                            if (num46 > 255f)
                            {
                                num46 = 255f;
                            }
                            if (num47 > 255f)
                            {
                                num47 = 255f;
                            }
                            if (num48 > 255f)
                            {
                                num48 = 255f;
                            }
                            if (num46 > (float)color5.R)
                            {
                                color5.R = (byte)num46;
                            }
                            if (num47 > (float)color5.G)
                            {
                                color5.G = (byte)num47;
                            }
                            if (num48 > (float)color5.B)
                            {
                                color5.B = (byte)num48;
                            }
                            Main.bgScale = 1.36f;
                            Main.bgScale *= 2f;
                            this.LoadBackground(48);
                            Main.bgW = (int)((float)Main.backgroundWidth[48] * Main.bgScale);
                            this.bgParrallax = 0.49;
                            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.bgW) - (double)(Main.bgW / 2));
                            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 2100.0 + 1950.0) + (int)this.scAdj;
                            if (Main.gameMenu)
                            {
                                this.bgTop = 480;
                                this.bgStart -= 120;
                            }
                            this.bgLoops = Main.screenWidth / Main.bgW + 2;
                            if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                            {
                                for (int num51 = 0; num51 < this.bgLoops; num51++)
                                {
                                    Main.spriteBatch.Draw(Main.backgroundTexture[48], new Vector2((float)(this.bgStart + Main.bgW * num51), (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.backgroundWidth[48], Main.backgroundHeight[48])), color5, 0f, default(Vector2), Main.bgScale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                    }
                }
            }
            if (!Main.mapFullscreen && Main.cloudAlpha > 0f && (double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
            {
                this.bgParrallax = 0.1;
                this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.backgroundWidth[Main.background]) - (double)(Main.backgroundWidth[Main.background] / 2));
                this.bgLoops = Main.screenWidth / Main.backgroundWidth[Main.background] + 2;
                this.bgStartY = 0;
                this.bgLoopsY = 0;
                this.bgTop = (int)((double)(-(double)Main.screenPosition.Y) / (Main.worldSurface * 16.0 - 600.0) * 200.0);
                for (int num52 = 0; num52 < this.bgLoops; num52++)
                {
                    Color color6 = Main.bgColor;
                    this.bgStart = 0;
                    float num53 = Main.cloudAlpha;
                    color6.R = (byte)((float)color6.R * num53);
                    color6.G = (byte)((float)color6.G * num53);
                    color6.B = (byte)((float)color6.B * num53);
                    color6.A = (byte)((float)color6.A * num53);
                    Main.spriteBatch.Draw(Main.backgroundTexture[49], new Rectangle(this.bgStart + Main.backgroundWidth[49] * num52, this.bgTop, Main.backgroundWidth[49], Main.backgroundHeight[49]), color6);
                }
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            if (!Main.gameMenu)
            {
                this.lookForColorTiles();
            }
            if (Main.loadMap)
            {
                Main.refreshMap = false;
                this.DrawToMap();
            }
            if (Lighting.lightMode >= 2)
            {
                Main.drawToScreen = true;
            }
            else
            {
                Main.drawToScreen = false;
            }
            if (Main.drawToScreen && Main.targetSet)
            {
                this.ReleaseTargets();
            }
            if (!Main.drawToScreen && !Main.targetSet)
            {
                this.InitTargets();
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Main.fpsCount++;
            if (!base.IsActive)
            {
                Main.maxQ = true;
            }
            if (!Main.dedServ)
            {
                bool flag = false;
                if (Main.screenWidth != base.GraphicsDevice.Viewport.Width || Main.screenHeight != base.GraphicsDevice.Viewport.Height)
                {
                    flag = true;
                    Main.mapTime = 0;
                    if (Main.gamePaused)
                    {
                        Main.renderNow = true;
                    }
                }
                Main.screenWidth = base.GraphicsDevice.Viewport.Width;
                Main.screenHeight = base.GraphicsDevice.Viewport.Height;
                Main.screenMaximized = (((Form)Control.FromHandle(base.Window.Handle)).WindowState == FormWindowState.Maximized);
                if (Main.screenWidth % 2 != 0)
                {
                    Main.screenWidth++;
                    flag = true;
                }
                if (Main.screenHeight % 2 != 0)
                {
                    Main.screenHeight++;
                    flag = true;
                }
                if (Main.screenWidth > Main.maxScreenW)
                {
                    Main.screenWidth = Main.maxScreenW;
                    flag = true;
                }
                if (Main.screenHeight > Main.maxScreenH)
                {
                    Main.screenHeight = Main.maxScreenH;
                    flag = true;
                }
                if (Main.screenWidth < Main.minScreenW)
                {
                    Main.screenWidth = Main.minScreenW;
                    flag = true;
                }
                if (Main.screenHeight < Main.minScreenH)
                {
                    Main.screenHeight = Main.minScreenH;
                    flag = true;
                }
                if (flag)
                {
                    Main.graphics.PreferredBackBufferWidth = Main.screenWidth;
                    Main.graphics.PreferredBackBufferHeight = Main.screenHeight;
                    Main.graphics.ApplyChanges();
                    if (!Main.drawToScreen)
                    {
                        this.InitTargets();
                    }
                }
            }
            Main.CursorColor();
            Main.drawTime++;
            Main.screenLastPosition = Main.screenPosition;
            if (Main.stackSplit == 0)
            {
                Main.stackCounter = 0;
                Main.stackDelay = 7;
                Main.superFastStack = 0;
            }
            else
            {
                Main.stackCounter++;
                int num = 30;
                if (num == 7)
                {
                    num = 30;
                }
                else
                {
                    if (Main.stackDelay == 6)
                    {
                        num = 25;
                    }
                    else
                    {
                        if (Main.stackDelay == 5)
                        {
                            num = 20;
                        }
                        else
                        {
                            if (Main.stackDelay == 4)
                            {
                                num = 15;
                            }
                            else
                            {
                                if (Main.stackDelay == 3)
                                {
                                    num = 10;
                                }
                                else
                                {
                                    num = 5;
                                }
                            }
                        }
                    }
                }
                if (Main.stackCounter >= num)
                {
                    Main.stackDelay--;
                    if (Main.stackDelay < 2)
                    {
                        Main.stackDelay = 2;
                        Main.superFastStack++;
                    }
                    Main.stackCounter = 0;
                }
            }
            Main.mouseTextColor += (byte)Main.mouseTextColorChange;
            if (Main.mouseTextColor >= 250)
            {
                Main.mouseTextColorChange = -4;
            }
            if (Main.mouseTextColor <= 175)
            {
                Main.mouseTextColorChange = 4;
            }
            if (Main.myPlayer >= 0)
            {
                Main.player[Main.myPlayer].lastMouseInterface = Main.player[Main.myPlayer].mouseInterface;
                Main.player[Main.myPlayer].mouseInterface = false;
            }
            if (Main.mapTime > 0)
            {
                Main.mapTime--;
            }
            if (Main.gameMenu)
            {
                Main.mapTime = Main.mapTimeMax;
            }
            Main.toolTip = new Item();
            if (!Main.gameMenu && Main.netMode != 2)
            {
                int num2 = 21;
                if (Main.cameraX != 0f && !Main.player[Main.myPlayer].pulley)
                {
                    Main.cameraX = 0f;
                }
                if (Main.cameraX > 0f)
                {
                    Main.cameraX -= 1f;
                    if (Main.cameraX < 0f)
                    {
                        Main.cameraX = 0f;
                    }
                }
                if (Main.cameraX < 0f)
                {
                    Main.cameraX += 1f;
                    if (Main.cameraX > 0f)
                    {
                        Main.cameraX = 0f;
                    }
                }
                Main.screenPosition.X = Main.player[Main.myPlayer].position.X + (float)Main.player[Main.myPlayer].width * 0.5f - (float)Main.screenWidth * 0.5f + Main.cameraX;
                Main.screenPosition.Y = Main.player[Main.myPlayer].position.Y + (float)Main.player[Main.myPlayer].height - (float)num2 - (float)Main.screenHeight * 0.5f + Main.player[Main.myPlayer].gfxOffY;
                float num3 = 0f;
                float num4 = 0f;
                if ((Main.player[Main.myPlayer].noThrow <= 0 && !Main.player[Main.myPlayer].lastMouseInterface) || Main.zoomX != 0f || Main.zoomY != 0f)
                {
                    if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == 1254 && Main.player[Main.myPlayer].scope && Main.mouseRight)
                    {
                        int num5 = Main.mouseX;
                        int num6 = Main.mouseY;
                        if (num5 > Main.screenWidth)
                        {
                            num5 = Main.screenWidth;
                        }
                        if (num5 < 0)
                        {
                            num5 = 0;
                        }
                        if (num6 > Main.screenHeight)
                        {
                            num6 = Main.screenHeight;
                        }
                        if (num6 < 0)
                        {
                            num6 = 0;
                        }
                        num3 = (float)(num5 - Main.screenWidth / 2) / 1.25f;
                        num4 += (float)(num6 - Main.screenHeight / 2) / 1.25f;
                    }
                    else
                    {
                        if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == 1254 && Main.mouseRight)
                        {
                            int num7 = Main.mouseX;
                            int num8 = Main.mouseY;
                            if (num7 > Main.screenWidth)
                            {
                                num7 = Main.screenWidth;
                            }
                            if (num7 < 0)
                            {
                                num7 = 0;
                            }
                            if (num8 > Main.screenHeight)
                            {
                                num8 = Main.screenHeight;
                            }
                            if (num8 < 0)
                            {
                                num8 = 0;
                            }
                            num3 = (float)(num7 - Main.screenWidth / 2) / 1.5f;
                            num4 += (float)(num8 - Main.screenHeight / 2) / 1.5f;
                        }
                        else
                        {
                            if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].type == 1299)
                            {
                                int num9 = Main.mouseX;
                                int num10 = Main.mouseY;
                                if (num9 > Main.screenWidth)
                                {
                                    num9 = Main.screenWidth;
                                }
                                if (num9 < 0)
                                {
                                    num9 = 0;
                                }
                                if (num10 > Main.screenHeight)
                                {
                                    num10 = Main.screenHeight;
                                }
                                if (num10 < 0)
                                {
                                    num10 = 0;
                                }
                                num3 = (float)(num9 - Main.screenWidth / 2) / 1.5f;
                                num4 += (float)(num10 - Main.screenHeight / 2) / 1.5f;
                            }
                            else
                            {
                                if (Main.player[Main.myPlayer].scope && Main.mouseRight)
                                {
                                    int num11 = Main.mouseX;
                                    int num12 = Main.mouseY;
                                    if (num11 > Main.screenWidth)
                                    {
                                        num11 = Main.screenWidth;
                                    }
                                    if (num11 < 0)
                                    {
                                        num11 = 0;
                                    }
                                    if (num12 > Main.screenHeight)
                                    {
                                        num12 = Main.screenHeight;
                                    }
                                    if (num12 < 0)
                                    {
                                        num12 = 0;
                                    }
                                    num3 = (float)(num11 - Main.screenWidth / 2) / 2f;
                                    num4 += (float)(num12 - Main.screenHeight / 2) / 2f;
                                }
                            }
                        }
                    }
                }
                float num13 = 24f;
                float num14 = num3 - Main.zoomX;
                float num15 = num4 - Main.zoomY;
                float num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
                num16 = (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
                if (num16 < num13)
                {
                    Main.zoomX = num3;
                    Main.zoomY = num4;
                }
                else
                {
                    num16 = num13 / num16;
                    num14 *= num16;
                    num15 *= num16;
                    Main.zoomX += num14;
                    Main.zoomY += num15;
                }
                Main.screenPosition.X = Main.screenPosition.X + Main.zoomX;
                Main.screenPosition.Y = Main.screenPosition.Y + Main.zoomY * Main.player[Main.myPlayer].gravDir;
                Main.screenPosition.X = (float)((int)Main.screenPosition.X);
                Main.screenPosition.Y = (float)((int)Main.screenPosition.Y);
            }
            if (!Main.gameMenu && Main.netMode != 2)
            {
                if (Main.screenPosition.X < Main.leftWorld + 640f + 16f)
                {
                    Main.screenPosition.X = Main.leftWorld + 640f + 16f;
                }
                else
                {
                    if (Main.screenPosition.X + (float)Main.screenWidth > Main.rightWorld - 640f - 32f)
                    {
                        Main.screenPosition.X = Main.rightWorld - (float)Main.screenWidth - 640f - 32f;
                    }
                }
                if (Main.screenPosition.Y < Main.topWorld + 640f + 16f)
                {
                    Main.screenPosition.Y = Main.topWorld + 640f + 16f;
                }
                else
                {
                    if (Main.screenPosition.Y + (float)Main.screenHeight > Main.bottomWorld - 640f - 32f)
                    {
                        Main.screenPosition.Y = Main.bottomWorld - (float)Main.screenHeight - 640f - 32f;
                    }
                }
            }
            if (Main.showSplash)
            {
                this.DrawSplash(gameTime);
                return;
            }
            Main.sunCircle += 0.01f;
            if ((double)Main.sunCircle > 6.285)
            {
                Main.sunCircle -= 6.285f;
            }
            if (!Main.gameMenu)
            {
                this.waterfallManager.FindWaterfalls();
                if (Main.renderNow)
                {
                    Main.screenLastPosition = Main.screenPosition;
                    Main.renderNow = false;
                    Main.renderCount = 99;
                    int tempLightCount = Lighting.tempLightCount;
                    this.Draw(gameTime);
                    Lighting.tempLightCount = tempLightCount;
                    Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
                    Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
                    this.RenderTiles();
                    Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                    Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    this.RenderBackground();
                    Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                    Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    this.RenderWalls();
                    Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                    Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    this.RenderTiles2();
                    Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                    Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    this.RenderWater();
                    Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                    Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    Main.renderCount = 99;
                }
                else
                {
                    if (Main.renderCount == 3)
                    {
                        this.RenderTiles();
                        Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Main.renderCount == 2)
                    {
                        this.RenderBackground();
                        Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Main.renderCount == 2)
                    {
                        this.RenderWalls();
                        Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Main.renderCount == 3)
                    {
                        this.RenderTiles2();
                        Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Main.renderCount == 1)
                    {
                        this.RenderWater();
                        Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                }
                if (Main.render && !Main.gameMenu)
                {
                    if (Math.Abs(Main.sceneTilePos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneTilePos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
                    {
                        this.RenderTiles();
                        Main.sceneTilePos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneTilePos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Math.Abs(Main.sceneTile2Pos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneTile2Pos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
                    {
                        this.RenderTiles2();
                        Main.sceneTile2Pos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneTile2Pos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Math.Abs(Main.sceneBackgroundPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneBackgroundPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
                    {
                        this.RenderBackground();
                        Main.sceneBackgroundPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneBackgroundPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Math.Abs(Main.sceneWallPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneWallPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
                    {
                        this.RenderWalls();
                        Main.sceneWallPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneWallPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                    if (Math.Abs(Main.sceneWaterPos.X - (Main.screenPosition.X - (float)Main.offScreenRange)) > (float)Main.offScreenRange || Math.Abs(Main.sceneWaterPos.Y - (Main.screenPosition.Y - (float)Main.offScreenRange)) > (float)Main.offScreenRange)
                    {
                        this.RenderWater();
                        Main.sceneWaterPos.X = Main.screenPosition.X - (float)Main.offScreenRange;
                        Main.sceneWaterPos.Y = Main.screenPosition.Y - (float)Main.offScreenRange;
                    }
                }
            }
            if (!Main.loadMap)
            {
                if (!Main.gameMenu)
                {
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch2.Start();
                    int num17 = 0;
                    int secX;
                    int secY;
                    while (stopwatch2.ElapsedMilliseconds < 5L && Main.sectionManager.GetNextMapDraw(Main.player[Main.myPlayer].position, out secX, out secY))
                    {
                        this.DrawToMap_Section(secX, secY);
                        num17++;
                    }
                }
                if (Main.updateMap)
                {
                    if (base.IsActive || Main.netMode == 1)
                    {
                        if (Main.refreshMap)
                        {
                            Main.refreshMap = false;
                            Main.sectionManager.ClearMapDraw();
                        }
                        this.DrawToMap();
                        Main.updateMap = false;
                    }
                    else
                    {
                        if (Map.numUpdateTile > 0)
                        {
                            this.DrawToMap();
                        }
                    }
                }
            }
            this.bgParrallax = 0.1;
            this.bgStart = (int)(-Math.IEEERemainder((double)Main.screenPosition.X * this.bgParrallax, (double)Main.backgroundWidth[Main.background]) - (double)(Main.backgroundWidth[Main.background] / 2));
            this.bgLoops = Main.screenWidth / Main.backgroundWidth[Main.background] + 2;
            this.bgStartY = 0;
            this.bgLoopsY = 0;
            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y) / (Main.worldSurface * 16.0 - 600.0) * 200.0);
            Main.bgColor = Color.White;
            if (Main.gameMenu || Main.netMode == 2)
            {
                this.bgTop = -200;
            }
            int num18 = (int)(Main.time / 54000.0 * (double)(Main.screenWidth + Main.sunTexture.Width * 2)) - Main.sunTexture.Width;
            int num19 = 0;
            Color white = Color.White;
            float num20 = 1f;
            float rotation = (float)(Main.time / 54000.0) * 2f - 7.3f;
            int num21 = (int)(Main.time / 32400.0 * (double)(Main.screenWidth + Main.moonTexture[Main.moonType].Width * 2)) - Main.moonTexture[Main.moonType].Width;
            int num22 = 0;
            Color white2 = Color.White;
            float num23 = 1f;
            float rotation2 = (float)(Main.time / 32400.0) * 2f - 7.3f;
            if (Main.dayTime)
            {
                double num24;
                if (Main.time < 27000.0)
                {
                    num24 = Math.Pow(1.0 - Main.time / 54000.0 * 2.0, 2.0);
                    num19 = (int)((double)this.bgTop + num24 * 250.0 + 180.0);
                }
                else
                {
                    num24 = Math.Pow((Main.time / 54000.0 - 0.5) * 2.0, 2.0);
                    num19 = (int)((double)this.bgTop + num24 * 250.0 + 180.0);
                }
                num20 = (float)(1.2 - num24 * 0.4);
            }
            else
            {
                double num25;
                if (Main.time < 16200.0)
                {
                    num25 = Math.Pow(1.0 - Main.time / 32400.0 * 2.0, 2.0);
                    num22 = (int)((double)this.bgTop + num25 * 250.0 + 180.0);
                }
                else
                {
                    num25 = Math.Pow((Main.time / 32400.0 - 0.5) * 2.0, 2.0);
                    num22 = (int)((double)this.bgTop + num25 * 250.0 + 180.0);
                }
                num23 = (float)(1.2 - num25 * 0.4);
            }
            if (Main.dayTime)
            {
                if (Main.time < 13500.0)
                {
                    float num26 = (float)(Main.time / 13500.0);
                    white.R = (byte)(num26 * 200f + 55f);
                    white.G = (byte)(num26 * 180f + 75f);
                    white.B = (byte)(num26 * 250f + 5f);
                    Main.bgColor.R = (byte)(num26 * 230f + 25f);
                    Main.bgColor.G = (byte)(num26 * 220f + 35f);
                    Main.bgColor.B = (byte)(num26 * 220f + 35f);
                }
                if (Main.time > 45900.0)
                {
                    float num26 = (float)(1.0 - (Main.time / 54000.0 - 0.85) * 6.666666666666667);
                    white.R = (byte)(num26 * 120f + 55f);
                    white.G = (byte)(num26 * 100f + 25f);
                    white.B = (byte)(num26 * 120f + 55f);
                    Main.bgColor.R = (byte)(num26 * 200f + 35f);
                    Main.bgColor.G = (byte)(num26 * 85f + 35f);
                    Main.bgColor.B = (byte)(num26 * 135f + 35f);
                }
                else
                {
                    if (Main.time > 37800.0)
                    {
                        float num26 = (float)(1.0 - (Main.time / 54000.0 - 0.7) * 6.666666666666667);
                        white.R = (byte)(num26 * 80f + 175f);
                        white.G = (byte)(num26 * 130f + 125f);
                        white.B = (byte)(num26 * 100f + 155f);
                        Main.bgColor.R = (byte)(num26 * 20f + 235f);
                        Main.bgColor.G = (byte)(num26 * 135f + 120f);
                        Main.bgColor.B = (byte)(num26 * 85f + 170f);
                    }
                }
            }
            if (!Main.dayTime)
            {
                if (Main.bloodMoon)
                {
                    if (Main.time < 16200.0)
                    {
                        float num26 = (float)(1.0 - Main.time / 16200.0);
                        white2.R = (byte)(num26 * 10f + 205f);
                        white2.G = (byte)(num26 * 170f + 55f);
                        white2.B = (byte)(num26 * 200f + 55f);
                        Main.bgColor.R = (byte)(40f - num26 * 40f + 35f);
                        Main.bgColor.G = (byte)(num26 * 20f + 15f);
                        Main.bgColor.B = (byte)(num26 * 20f + 15f);
                    }
                    else
                    {
                        if (Main.time >= 16200.0)
                        {
                            float num26 = (float)((Main.time / 32400.0 - 0.5) * 2.0);
                            white2.R = (byte)(num26 * 50f + 205f);
                            white2.G = (byte)(num26 * 100f + 155f);
                            white2.B = (byte)(num26 * 100f + 155f);
                            white2.R = (byte)(num26 * 10f + 205f);
                            white2.G = (byte)(num26 * 170f + 55f);
                            white2.B = (byte)(num26 * 200f + 55f);
                            Main.bgColor.R = (byte)(40f - num26 * 40f + 35f);
                            Main.bgColor.G = (byte)(num26 * 20f + 15f);
                            Main.bgColor.B = (byte)(num26 * 20f + 15f);
                        }
                    }
                }
                else
                {
                    if (Main.time < 16200.0)
                    {
                        float num26 = (float)(1.0 - Main.time / 16200.0);
                        white2.R = (byte)(num26 * 10f + 205f);
                        white2.G = (byte)(num26 * 70f + 155f);
                        white2.B = (byte)(num26 * 100f + 155f);
                        Main.bgColor.R = (byte)(num26 * 30f + 5f);
                        Main.bgColor.G = (byte)(num26 * 30f + 5f);
                        Main.bgColor.B = (byte)(num26 * 30f + 5f);
                    }
                    else
                    {
                        if (Main.time >= 16200.0)
                        {
                            float num26 = (float)((Main.time / 32400.0 - 0.5) * 2.0);
                            white2.R = (byte)(num26 * 50f + 205f);
                            white2.G = (byte)(num26 * 100f + 155f);
                            white2.B = (byte)(num26 * 100f + 155f);
                            Main.bgColor.R = (byte)(num26 * 20f + 5f);
                            Main.bgColor.G = (byte)(num26 * 30f + 5f);
                            Main.bgColor.B = (byte)(num26 * 30f + 5f);
                        }
                    }
                }
            }
            float num27 = 0.0005f * (float)Main.dayRate;
            if (Main.gameMenu)
            {
                num27 *= 20f;
            }
            if (Main.raining)
            {
                if (Main.cloudAlpha > Main.maxRaining)
                {
                    Main.cloudAlpha -= num27;
                    if (Main.cloudAlpha < Main.maxRaining)
                    {
                        Main.cloudAlpha = Main.maxRaining;
                    }
                }
                else
                {
                    if (Main.cloudAlpha < Main.maxRaining)
                    {
                        Main.cloudAlpha += num27;
                        if (Main.cloudAlpha > Main.maxRaining)
                        {
                            Main.cloudAlpha = Main.maxRaining;
                        }
                    }
                }
            }
            else
            {
                Main.cloudAlpha -= num27;
                if (Main.cloudAlpha < 0f)
                {
                    Main.cloudAlpha = 0f;
                }
            }
            if (Main.cloudAlpha > 0f)
            {
                float num28 = 1f - Main.cloudAlpha * 0.9f;
                Main.bgColor.R = (byte)((float)Main.bgColor.R * num28);
                Main.bgColor.G = (byte)((float)Main.bgColor.G * num28);
                Main.bgColor.B = (byte)((float)Main.bgColor.B * num28);
            }
            if (Main.gameMenu || Main.netMode == 2)
            {
                this.bgTop = 0;
                if (!Main.dayTime)
                {
                    Main.bgColor.R = 35;
                    Main.bgColor.G = 35;
                    Main.bgColor.B = 35;
                }
            }
            if (Main.gameMenu)
            {
                Main.bgDelay = 1000;
                Main.evilTiles = (int)(Main.bgAlpha[1] * 500f);
            }
            if (Main.evilTiles > 0)
            {
                float num29 = (float)Main.evilTiles / 500f;
                if (num29 > 1f)
                {
                    num29 = 1f;
                }
                int num30 = (int)Main.bgColor.R;
                int num31 = (int)Main.bgColor.G;
                int num32 = (int)Main.bgColor.B;
                num30 -= (int)(100f * num29 * ((float)Main.bgColor.R / 255f));
                num31 -= (int)(140f * num29 * ((float)Main.bgColor.G / 255f));
                num32 -= (int)(80f * num29 * ((float)Main.bgColor.B / 255f));
                if (num30 < 15)
                {
                    num30 = 15;
                }
                if (num31 < 15)
                {
                    num31 = 15;
                }
                if (num32 < 15)
                {
                    num32 = 15;
                }
                Main.bgColor.R = (byte)num30;
                Main.bgColor.G = (byte)num31;
                Main.bgColor.B = (byte)num32;
                num30 = (int)white.R;
                num31 = (int)white.G;
                num32 = (int)white.B;
                num30 -= (int)(100f * num29 * ((float)white.R / 255f));
                num31 -= (int)(100f * num29 * ((float)white.G / 255f));
                num32 -= (int)(0f * num29 * ((float)white.B / 255f));
                if (num30 < 15)
                {
                    num30 = 15;
                }
                if (num31 < 15)
                {
                    num31 = 15;
                }
                if (num32 < 15)
                {
                    num32 = 15;
                }
                white.R = (byte)num30;
                white.G = (byte)num31;
                white.B = (byte)num32;
                num30 = (int)white2.R;
                num31 = (int)white2.G;
                num32 = (int)white2.B;
                num30 -= (int)(140f * num29 * ((float)white2.R / 255f));
                num31 -= (int)(190f * num29 * ((float)white2.G / 255f));
                num32 -= (int)(170f * num29 * ((float)white2.B / 255f));
                if (num30 < 15)
                {
                    num30 = 15;
                }
                if (num31 < 15)
                {
                    num31 = 15;
                }
                if (num32 < 15)
                {
                    num32 = 15;
                }
                white2.R = (byte)num30;
                white2.G = (byte)num31;
                white2.B = (byte)num32;
            }
            if (Main.bloodTiles > 0)
            {
                float num33 = (float)Main.bloodTiles / 400f;
                if (num33 > 1f)
                {
                    num33 = 1f;
                }
                int num34 = (int)Main.bgColor.R;
                int num35 = (int)Main.bgColor.G;
                int num36 = (int)Main.bgColor.B;
                num34 -= (int)(70f * num33 * ((float)Main.bgColor.G / 255f));
                num35 -= (int)(110f * num33 * ((float)Main.bgColor.G / 255f));
                num36 -= (int)(150f * num33 * ((float)Main.bgColor.B / 255f));
                if (num34 < 15)
                {
                    num34 = 15;
                }
                if (num35 < 15)
                {
                    num35 = 15;
                }
                if (num36 < 15)
                {
                    num36 = 15;
                }
                Main.bgColor.R = (byte)num34;
                Main.bgColor.G = (byte)num35;
                Main.bgColor.B = (byte)num36;
                num34 = (int)white.R;
                num35 = (int)white.G;
                num36 = (int)white.B;
                num35 -= (int)(90f * num33 * ((float)white.G / 255f));
                num36 -= (int)(110f * num33 * ((float)white.B / 255f));
                if (num34 < 15)
                {
                    num34 = 15;
                }
                if (num35 < 15)
                {
                    num35 = 15;
                }
                if (num36 < 15)
                {
                    num36 = 15;
                }
                white.R = (byte)num34;
                white.G = (byte)num35;
                white.B = (byte)num36;
                num34 = (int)white2.R;
                num35 = (int)white2.G;
                num36 = (int)white2.B;
                num34 -= (int)(100f * num33 * ((float)white2.R / 255f));
                num35 -= (int)(120f * num33 * ((float)white2.G / 255f));
                num36 -= (int)(180f * num33 * ((float)white2.B / 255f));
                if (num34 < 15)
                {
                    num34 = 15;
                }
                if (num35 < 15)
                {
                    num35 = 15;
                }
                if (num36 < 15)
                {
                    num36 = 15;
                }
                white2.R = (byte)num34;
                white2.G = (byte)num35;
                white2.B = (byte)num36;
            }
            if (Main.jungleTiles > 0)
            {
                float num37 = (float)Main.jungleTiles / 200f;
                if (num37 > 1f)
                {
                    num37 = 1f;
                }
                int num38 = (int)Main.bgColor.R;
                int num39 = (int)Main.bgColor.G;
                int num40 = (int)Main.bgColor.B;
                num38 -= (int)(40f * num37 * ((float)Main.bgColor.R / 255f));
                num40 -= (int)(70f * num37 * ((float)Main.bgColor.B / 255f));
                if (num39 > 255)
                {
                    num39 = 255;
                }
                if (num39 < 15)
                {
                    num39 = 15;
                }
                if (num38 > 255)
                {
                    num38 = 255;
                }
                if (num38 < 15)
                {
                    num38 = 15;
                }
                if (num40 < 15)
                {
                    num40 = 15;
                }
                Main.bgColor.R = (byte)num38;
                Main.bgColor.G = (byte)num39;
                Main.bgColor.B = (byte)num40;
                num38 = (int)white.R;
                num39 = (int)white.G;
                num40 = (int)white.B;
                num38 -= (int)(30f * num37 * ((float)white.R / 255f));
                num40 -= (int)(10f * num37 * ((float)white.B / 255f));
                if (num38 < 15)
                {
                    num38 = 15;
                }
                if (num39 < 15)
                {
                    num39 = 15;
                }
                if (num40 < 15)
                {
                    num40 = 15;
                }
                white.R = (byte)num38;
                white.G = (byte)num39;
                white.B = (byte)num40;
                num38 = (int)white2.R;
                num39 = (int)white2.G;
                num40 = (int)white2.B;
                num39 -= (int)(140f * num37 * ((float)white2.R / 255f));
                num38 -= (int)(170f * num37 * ((float)white2.G / 255f));
                num40 -= (int)(190f * num37 * ((float)white2.B / 255f));
                if (num38 < 15)
                {
                    num38 = 15;
                }
                if (num39 < 15)
                {
                    num39 = 15;
                }
                if (num40 < 15)
                {
                    num40 = 15;
                }
                white2.R = (byte)num38;
                white2.G = (byte)num39;
                white2.B = (byte)num40;
            }
            if (Main.shroomTiles > 0)
            {
                float num41 = (float)Main.shroomTiles / 160f;
                if (num41 > Main.shroomLight)
                {
                    Main.shroomLight += 0.01f;
                }
                if (num41 < Main.shroomLight)
                {
                    Main.shroomLight -= 0.01f;
                }
            }
            else
            {
                Main.shroomLight -= 0.02f;
            }
            if (Main.shroomLight < 0f)
            {
                Main.shroomLight = 0f;
            }
            if (Main.shroomLight > 1f)
            {
                Main.shroomLight = 1f;
            }
            if (Main.shroomLight > 0f)
            {
                float num42 = Main.shroomLight;
                int num43 = (int)Main.bgColor.R;
                int num44 = (int)Main.bgColor.G;
                int num45 = (int)Main.bgColor.B;
                num44 -= (int)(250f * num42 * ((float)Main.bgColor.G / 255f));
                num43 -= (int)(250f * num42 * ((float)Main.bgColor.R / 255f));
                num45 -= (int)(250f * num42 * ((float)Main.bgColor.B / 255f));
                if (num44 < 15)
                {
                    num44 = 15;
                }
                if (num43 < 15)
                {
                    num43 = 15;
                }
                if (num45 < 15)
                {
                    num45 = 15;
                }
                Main.bgColor.R = (byte)num43;
                Main.bgColor.G = (byte)num44;
                Main.bgColor.B = (byte)num45;
                num43 = (int)white.R;
                num44 = (int)white.G;
                num45 = (int)white.B;
                num44 -= (int)(10f * num42 * ((float)white.G / 255f));
                num43 -= (int)(30f * num42 * ((float)white.R / 255f));
                num45 -= (int)(10f * num42 * ((float)white.B / 255f));
                if (num43 < 15)
                {
                    num43 = 15;
                }
                if (num44 < 15)
                {
                    num44 = 15;
                }
                if (num45 < 15)
                {
                    num45 = 15;
                }
                white.R = (byte)num43;
                white.G = (byte)num44;
                white.B = (byte)num45;
                num43 = (int)white2.R;
                num44 = (int)white2.G;
                num45 = (int)white2.B;
                num44 -= (int)(140f * num42 * ((float)white2.R / 255f));
                num43 -= (int)(170f * num42 * ((float)white2.G / 255f));
                num45 -= (int)(190f * num42 * ((float)white2.B / 255f));
                if (num43 < 15)
                {
                    num43 = 15;
                }
                if (num44 < 15)
                {
                    num44 = 15;
                }
                if (num45 < 15)
                {
                    num45 = 15;
                }
                white2.R = (byte)num43;
                white2.G = (byte)num44;
                white2.B = (byte)num45;
            }
            if (Lighting.lightMode < 2)
            {
                if (Main.bgColor.R < 10)
                {
                    Main.bgColor.R = 10;
                }
                if (Main.bgColor.G < 10)
                {
                    Main.bgColor.G = 10;
                }
                if (Main.bgColor.B < 10)
                {
                    Main.bgColor.B = 10;
                }
            }
            else
            {
                if (Main.bgColor.R < 15)
                {
                    Main.bgColor.R = 15;
                }
                if (Main.bgColor.G < 15)
                {
                    Main.bgColor.G = 15;
                }
                if (Main.bgColor.B < 15)
                {
                    Main.bgColor.B = 15;
                }
            }
            if (Main.bloodMoon)
            {
                if (Main.bgColor.R < 25)
                {
                    Main.bgColor.R = 25;
                }
                if (Main.bgColor.G < 25)
                {
                    Main.bgColor.G = 25;
                }
                if (Main.bgColor.B < 25)
                {
                    Main.bgColor.B = 25;
                }
            }
            if (Main.eclipse && Main.dayTime)
            {
                float num46 = 1242f;
                Main.eclipseLight = (float)(Main.time / (double)num46);
                if (Main.eclipseLight > 1f)
                {
                    Main.eclipseLight = 1f;
                }
            }
            else
            {
                if (Main.eclipseLight > 0f)
                {
                    Main.eclipseLight -= 0.01f;
                    if (Main.eclipseLight < 0f)
                    {
                        Main.eclipseLight = 0f;
                    }
                }
            }
            if (Main.eclipseLight > 0f)
            {
                float num47 = 1f - 0.925f * Main.eclipseLight;
                float num48 = 1f - 0.96f * Main.eclipseLight;
                float num49 = 1f - 1f * Main.eclipseLight;
                int num50 = (int)((float)Main.bgColor.R * num47);
                int num51 = (int)((float)Main.bgColor.G * num48);
                int num52 = (int)((float)Main.bgColor.B * num49);
                Main.bgColor.R = (byte)num50;
                Main.bgColor.G = (byte)num51;
                Main.bgColor.B = (byte)num52;
                white.R = 255;
                white.G = 127;
                white.B = 67;
                if (Main.bgColor.R < 20)
                {
                    Main.bgColor.R = 20;
                }
                if (Main.bgColor.G < 10)
                {
                    Main.bgColor.G = 10;
                }
                if (Lighting.lightMode >= 2)
                {
                    if (Main.bgColor.R < 20)
                    {
                        Main.bgColor.R = 20;
                    }
                    if (Main.bgColor.G < 14)
                    {
                        Main.bgColor.G = 14;
                    }
                    if (Main.bgColor.B < 6)
                    {
                        Main.bgColor.B = 6;
                    }
                }
            }
            Main.tileColor.A = 255;
            Main.tileColor.R = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
            Main.tileColor.G = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
            Main.tileColor.B = (byte)((Main.bgColor.R + Main.bgColor.B + Main.bgColor.G) / 3);
            Main.tileColor.R = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.R * 7) / 10);
            Main.tileColor.G = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.G * 7) / 10);
            Main.tileColor.B = (byte)((Main.bgColor.R + Main.bgColor.G + Main.bgColor.B + Main.bgColor.B * 7) / 10);
            float num53 = (float)(Main.maxTilesX / 4200);
            num53 *= num53;
            Main.atmo = (float)((double)((Main.screenPosition.Y + (float)(Main.screenHeight / 2)) / 16f - (65f + 10f * num53)) / (Main.worldSurface / 5.0));
            if (Main.atmo < 0f)
            {
                Main.atmo = 0f;
            }
            if (Main.atmo > 1f)
            {
                Main.atmo = 1f;
            }
            if (Main.gameMenu)
            {
                Main.atmo = 1f;
            }
            Main.bgColor.R = (byte)((float)Main.bgColor.R * Main.atmo);
            Main.bgColor.G = (byte)((float)Main.bgColor.G * Main.atmo);
            Main.bgColor.B = (byte)((float)Main.bgColor.B * Main.atmo);
            if ((double)Main.atmo <= 0.05)
            {
                Main.bgColor.R = 0;
                Main.bgColor.G = 0;
                Main.bgColor.B = 0;
                Main.bgColor.A = 0;
            }
            base.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
            if (Main.gameMenu || Main.player[Main.myPlayer].gravDir == 1f)
            {
                this.Transform = Matrix.CreateScale(1f, 1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, 0f, 0f));
                this.Rasterizer = RasterizerState.CullCounterClockwise;
            }
            else
            {
                this.Transform = Matrix.CreateScale(1f, -1f, 1f) * Matrix.CreateRotationZ(0f) * Matrix.CreateTranslation(new Vector3(0f, (float)Main.screenHeight, 0f));
                this.Rasterizer = RasterizerState.CullClockwise;
            }
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, this.Rasterizer, null, this.Transform);
            if (!Main.mapFullscreen)
            {
                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0)
                {
                    for (int i = 0; i < this.bgLoops; i++)
                    {
                        Main.spriteBatch.Draw(Main.backgroundTexture[Main.background], new Rectangle(this.bgStart + Main.backgroundWidth[Main.background] * i, this.bgTop, Main.backgroundWidth[Main.background], Main.backgroundHeight[Main.background]), Main.bgColor);
                    }
                }
                if ((double)Main.screenPosition.Y < Main.worldSurface * 16.0 + 16.0 && 255f * (1f - Main.cloudAlpha) - (float)Main.bgColor.R - 25f > 0f && Main.netMode != 2)
                {
                    for (int j = 0; j < Main.numStars; j++)
                    {
                        Color color = default(Color);
                        float num54 = (float)Main.evilTiles / 500f;
                        if (num54 > 1f)
                        {
                            num54 = 1f;
                        }
                        num54 = 1f - num54 * 0.5f;
                        if (Main.evilTiles <= 0)
                        {
                            num54 = 1f;
                        }
                        int num55 = (int)((float)(255 - Main.bgColor.R - 100) * Main.star[j].twinkle * num54);
                        int num56 = (int)((float)(255 - Main.bgColor.G - 100) * Main.star[j].twinkle * num54);
                        int num57 = (int)((float)(255 - Main.bgColor.B - 100) * Main.star[j].twinkle * num54);
                        if (num55 < 0)
                        {
                            num55 = 0;
                        }
                        if (num56 < 0)
                        {
                            num56 = 0;
                        }
                        if (num57 < 0)
                        {
                            num57 = 0;
                        }
                        color.R = (byte)num55;
                        color.G = (byte)((float)num56 * num54);
                        color.B = (byte)((float)num57 * num54);
                        float num58 = Main.star[j].position.X * ((float)Main.screenWidth / 800f);
                        float num59 = Main.star[j].position.Y * ((float)Main.screenHeight / 600f);
                        Main.spriteBatch.Draw(Main.starTexture[Main.star[j].type], new Vector2(num58 + (float)Main.starTexture[Main.star[j].type].Width * 0.5f, num59 + (float)Main.starTexture[Main.star[j].type].Height * 0.5f + (float)this.bgTop), new Rectangle?(new Rectangle(0, 0, Main.starTexture[Main.star[j].type].Width, Main.starTexture[Main.star[j].type].Height)), color, Main.star[j].rotation, new Vector2((float)Main.starTexture[Main.star[j].type].Width * 0.5f, (float)Main.starTexture[Main.star[j].type].Height * 0.5f), Main.star[j].scale * Main.star[j].twinkle, SpriteEffects.None, 0f);
                    }
                }
                if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 2.0)
                {
                    if (Main.dayTime)
                    {
                        num20 *= 1.1f;
                        if (Main.eclipse)
                        {
                            float num60 = 1f - Main.shroomLight;
                            num60 -= Main.cloudAlpha * 1.5f;
                            if (num60 < 0f)
                            {
                                num60 = 0f;
                            }
                            Color color2 = new Color((int)((byte)(255f * num60)), (int)((byte)((float)white.G * num60)), (int)((byte)((float)white.B * num60)), (int)((byte)(255f * num60)));
                            Color color3 = new Color((int)((byte)((float)white.R * num60)), (int)((byte)((float)white.G * num60)), (int)((byte)((float)white.B * num60)), (int)((byte)((float)(white.B - 60) * num60)));
                            Main.spriteBatch.Draw(Main.sun3Texture, new Vector2((float)num18, (float)(num19 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sun3Texture.Width, Main.sun3Texture.Height)), color2, rotation, new Vector2((float)(Main.sun3Texture.Width / 2), (float)(Main.sun3Texture.Height / 2)), num20, SpriteEffects.None, 0f);
                            Main.spriteBatch.Draw(Main.sun3Texture, new Vector2((float)num18, (float)(num19 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sun3Texture.Width, Main.sun3Texture.Height)), color3, rotation, new Vector2((float)(Main.sun3Texture.Width / 2), (float)(Main.sun3Texture.Height / 2)), num20, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            if (!Main.gameMenu && Main.player[Main.myPlayer].head == 12)
                            {
                                float num61 = 1f - Main.shroomLight;
                                num61 -= Main.cloudAlpha * 1.5f;
                                if (num61 < 0f)
                                {
                                    num61 = 0f;
                                }
                                Color color4 = new Color((int)((byte)(255f * num61)), (int)((byte)((float)white.G * num61)), (int)((byte)((float)white.B * num61)), (int)((byte)(255f * num61)));
                                Color color5 = new Color((int)((byte)((float)white.R * num61)), (int)((byte)((float)white.G * num61)), (int)((byte)((float)white.B * num61)), (int)((byte)((float)(white.B - 60) * num61)));
                                Main.spriteBatch.Draw(Main.sun2Texture, new Vector2((float)num18, (float)(num19 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sun2Texture.Width, Main.sun2Texture.Height)), color4, rotation, new Vector2((float)(Main.sun2Texture.Width / 2), (float)(Main.sun2Texture.Height / 2)), num20, SpriteEffects.None, 0f);
                                Main.spriteBatch.Draw(Main.sun2Texture, new Vector2((float)num18, (float)(num19 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sun2Texture.Width, Main.sun2Texture.Height)), color5, rotation, new Vector2((float)(Main.sun2Texture.Width / 2), (float)(Main.sun2Texture.Height / 2)), num20, SpriteEffects.None, 0f);
                            }
                            else
                            {
                                float num62 = 1f - Main.shroomLight;
                                num62 -= Main.cloudAlpha * 1.5f;
                                if (num62 < 0f)
                                {
                                    num62 = 0f;
                                }
                                Color color6 = new Color((int)((byte)(255f * num62)), (int)((byte)((float)white.G * num62)), (int)((byte)((float)white.B * num62)), (int)((byte)(255f * num62)));
                                Color color7 = new Color((int)((byte)((float)white.R * num62)), (int)((byte)((float)white.G * num62)), (int)((byte)((float)white.B * num62)), (int)((byte)((float)white.B * num62)));
                                Main.spriteBatch.Draw(Main.sunTexture, new Vector2((float)num18, (float)(num19 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), color6, rotation, new Vector2((float)(Main.sunTexture.Width / 2), (float)(Main.sunTexture.Height / 2)), num20, SpriteEffects.None, 0f);
                                Main.spriteBatch.Draw(Main.sunTexture, new Vector2((float)num18, (float)(num19 + (int)Main.sunModY)), new Rectangle?(new Rectangle(0, 0, Main.sunTexture.Width, Main.sunTexture.Height)), color7, rotation, new Vector2((float)(Main.sunTexture.Width / 2), (float)(Main.sunTexture.Height / 2)), num20, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    if (!Main.dayTime)
                    {
                        float num63 = 1f - Main.cloudAlpha * 1.5f;
                        if (num63 < 0f)
                        {
                            num63 = 0f;
                        }
                        white2.R = (byte)((float)white2.R * num63);
                        white2.G = (byte)((float)white2.G * num63);
                        white2.B = (byte)((float)white2.B * num63);
                        white2.A = (byte)((float)white2.A * num63);
                        if (Main.pumpkinMoon)
                        {
                            Main.spriteBatch.Draw(Main.pumpkinMoonTexture, new Vector2((float)num21, (float)(num22 + (int)Main.moonModY)), new Rectangle?(new Rectangle(0, Main.pumpkinMoonTexture.Width * Main.moonPhase, Main.pumpkinMoonTexture.Width, Main.pumpkinMoonTexture.Width)), white2, rotation2, new Vector2((float)(Main.pumpkinMoonTexture.Width / 2), (float)(Main.pumpkinMoonTexture.Width / 2)), num23, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            if (Main.snowMoon)
                            {
                                Main.spriteBatch.Draw(Main.snowMoonTexture, new Vector2((float)num21, (float)(num22 + (int)Main.moonModY)), new Rectangle?(new Rectangle(0, Main.snowMoonTexture.Width * Main.moonPhase, Main.snowMoonTexture.Width, Main.snowMoonTexture.Width)), white2, rotation2, new Vector2((float)(Main.snowMoonTexture.Width / 2), (float)(Main.snowMoonTexture.Width / 2)), num23, SpriteEffects.None, 0f);
                            }
                            else
                            {
                                Main.spriteBatch.Draw(Main.moonTexture[Main.moonType], new Vector2((float)num21, (float)(num22 + (int)Main.moonModY)), new Rectangle?(new Rectangle(0, Main.moonTexture[Main.moonType].Width * Main.moonPhase, Main.moonTexture[Main.moonType].Width, Main.moonTexture[Main.moonType].Width)), white2, rotation2, new Vector2((float)(Main.moonTexture[Main.moonType].Width / 2), (float)(Main.moonTexture[Main.moonType].Width / 2)), num23, SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                Rectangle value;
                if (Main.dayTime)
                {
                    value = new Rectangle((int)((double)num18 - (double)Main.sunTexture.Width * 0.5 * (double)num20), (int)((double)num19 - (double)Main.sunTexture.Height * 0.5 * (double)num20 + (double)Main.sunModY), (int)((float)Main.sunTexture.Width * num20), (int)((float)Main.sunTexture.Width * num20));
                }
                else
                {
                    value = new Rectangle((int)((double)num21 - (double)Main.moonTexture[Main.moonType].Width * 0.5 * (double)num23), (int)((double)num22 - (double)Main.moonTexture[Main.moonType].Width * 0.5 * (double)num23 + (double)Main.moonModY), (int)((float)Main.moonTexture[Main.moonType].Width * num23), (int)((float)Main.moonTexture[Main.moonType].Width * num23));
                }
                Rectangle rectangle = new Rectangle(Main.mouseX, Main.mouseY, 1, 1);
                Main.sunModY = (short)((double)Main.sunModY * 0.999);
                Main.moonModY = (short)((double)Main.moonModY * 0.999);
                if (Main.gameMenu && Main.netMode != 1)
                {
                    if (Main.mouseLeft && Main.hasFocus)
                    {
                        if (rectangle.Intersects(value) || Main.grabSky)
                        {
                            if (Main.dayTime)
                            {
                                Main.time = 54000.0 * (double)((float)(Main.mouseX + Main.sunTexture.Width) / ((float)Main.screenWidth + (float)(Main.sunTexture.Width * 2)));
                                Main.sunModY = (short)(Main.mouseY - num19);
                                if (Main.time > 53990.0)
                                {
                                    Main.time = 53990.0;
                                }
                            }
                            else
                            {
                                Main.time = 32400.0 * (double)((float)(Main.mouseX + Main.moonTexture[Main.moonType].Width) / ((float)Main.screenWidth + (float)(Main.moonTexture[Main.moonType].Width * 2)));
                                Main.moonModY = (short)(Main.mouseY - num22);
                                if (Main.time > 32390.0)
                                {
                                    Main.time = 32390.0;
                                }
                            }
                            if (Main.time < 10.0)
                            {
                                Main.time = 10.0;
                            }
                            if (Main.netMode != 0)
                            {
                                NetMessage.SendData(18, -1, -1, "", 0, 0f, 0f, 0f, 0);
                            }
                            Main.grabSky = true;
                        }
                    }
                    else
                    {
                        Main.grabSky = false;
                    }
                }
            }
            this.scAdj = 1f - (float)((double)(Main.screenPosition.Y + (float)Main.screenHeight) / (Main.worldSurface * 16.0));
            this.scAdj = (float)(Main.worldSurface * 16.0) / (Main.screenPosition.Y + (float)Main.screenHeight);
            float num64 = (float)Main.maxTilesY * 0.15f * 16f;
            num64 -= Main.screenPosition.Y;
            if (num64 < 0f)
            {
                num64 = 0f;
            }
            num64 *= 0.00025f;
            float num65 = num64 * num64;
            this.scAdj *= 0.45f - num65;
            if ((double)Main.maxTilesY <= 1200.0)
            {
                this.scAdj *= -500f;
            }
            else
            {
                if ((double)Main.maxTilesY <= 1800.0)
                {
                    this.scAdj *= -300f;
                }
                else
                {
                    this.scAdj *= -150f;
                }
            }
            this.screenOff = (float)(Main.screenHeight - 600);
            this.bgTop = (int)((double)(-(double)Main.screenPosition.Y + this.screenOff / 2f) / (Main.worldSurface * 16.0) * 1200.0 + 1190.0) + (int)this.scAdj;
            this.cTop = (float)(this.bgTop - 50);
            if (Main.resetClouds)
            {
                Cloud.resetClouds();
                Main.resetClouds = false;
            }
            Main.bgScale = 1f;
            Main.bgW = (int)((float)Main.backgroundWidth[Main.treeMntBG[0]] * Main.bgScale);
            Main.backColor = Main.bgColor;
            Main.trueBackColor = Main.backColor;
            int num66 = Main.bgStyle;
            int num67 = (int)((Main.screenPosition.X + (float)(Main.screenWidth / 2)) / 16f);
            if ((double)(Main.screenPosition.Y / 16f) < Main.worldSurface + 10.0 && (num67 < 380 || num67 > Main.maxTilesX - 380))
            {
                num66 = 4;
            }
            else
            {
                if (Main.shroomTiles > 100)
                {
                    num66 = 9;
                }
                else
                {
                    if (Main.sandTiles > 1000)
                    {
                        if (Main.player[Main.myPlayer].zoneEvil)
                        {
                            num66 = 5;
                        }
                        else
                        {
                            if (Main.player[Main.myPlayer].zoneBlood)
                            {
                                num66 = 5;
                            }
                            else
                            {
                                if (Main.player[Main.myPlayer].zoneHoly)
                                {
                                    num66 = 5;
                                }
                                else
                                {
                                    num66 = 2;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Main.player[Main.myPlayer].zoneHoly)
                        {
                            num66 = 6;
                        }
                        else
                        {
                            if (Main.player[Main.myPlayer].zoneEvil)
                            {
                                num66 = 1;
                            }
                            else
                            {
                                if (Main.player[Main.myPlayer].zoneBlood)
                                {
                                    num66 = 8;
                                }
                                else
                                {
                                    if (Main.player[Main.myPlayer].zoneJungle)
                                    {
                                        num66 = 3;
                                    }
                                    else
                                    {
                                        if (Main.player[Main.myPlayer].zoneSnow)
                                        {
                                            num66 = 7;
                                        }
                                        else
                                        {
                                            num66 = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            int num68 = 30;
            Main.tranSpeed = 0.05f;
            if (num66 == 0)
            {
                num68 = 60;
            }
            if (Main.bgDelay < 0)
            {
                Main.bgDelay++;
            }
            else
            {
                if (num66 != Main.bgStyle)
                {
                    Main.bgDelay++;
                    if (Main.bgDelay > num68)
                    {
                        Main.bgDelay = -60;
                        Main.bgStyle = num66;
                        if (num66 == 0)
                        {
                            Main.bgDelay = 0;
                        }
                    }
                }
                else
                {
                    if (Main.bgDelay > 0)
                    {
                        Main.bgDelay--;
                    }
                }
            }
            if (Main.gameMenu)
            {
                Main.tranSpeed = 0.02f;
                if (!Main.dayTime)
                {
                    Main.bgStyle = 1;
                }
                else
                {
                    Main.bgStyle = 0;
                }
                num66 = Main.bgStyle;
            }
            if (Main.quickBG > 0)
            {
                Main.quickBG--;
                Main.bgStyle = num66;
                Main.tranSpeed = 1f;
            }
            if (Main.bgStyle == 2)
            {
                Main.bgAlpha2[0] -= Main.tranSpeed;
                if (Main.bgAlpha2[0] < 0f)
                {
                    Main.bgAlpha2[0] = 0f;
                }
                Main.bgAlpha2[1] += Main.tranSpeed;
                if (Main.bgAlpha2[1] > 1f)
                {
                    Main.bgAlpha2[1] = 1f;
                }
                Main.bgAlpha2[2] -= Main.tranSpeed;
                if (Main.bgAlpha2[2] < 0f)
                {
                    Main.bgAlpha2[2] = 0f;
                }
                Main.bgAlpha2[3] -= Main.tranSpeed;
                if (Main.bgAlpha2[3] < 0f)
                {
                    Main.bgAlpha2[3] = 0f;
                }
                Main.bgAlpha2[4] -= Main.tranSpeed;
                if (Main.bgAlpha2[4] < 0f)
                {
                    Main.bgAlpha2[4] = 0f;
                }
                Main.bgAlpha2[5] -= Main.tranSpeed;
                if (Main.bgAlpha2[5] < 0f)
                {
                    Main.bgAlpha2[5] = 0f;
                }
                Main.bgAlpha2[6] -= Main.tranSpeed;
                if (Main.bgAlpha2[6] < 0f)
                {
                    Main.bgAlpha2[6] = 0f;
                }
            }
            else
            {
                if (Main.bgStyle == 5 || Main.bgStyle == 1 || Main.bgStyle == 6)
                {
                    Main.bgAlpha2[0] -= Main.tranSpeed;
                    if (Main.bgAlpha2[0] < 0f)
                    {
                        Main.bgAlpha2[0] = 0f;
                    }
                    Main.bgAlpha2[1] -= Main.tranSpeed;
                    if (Main.bgAlpha2[1] < 0f)
                    {
                        Main.bgAlpha2[1] = 0f;
                    }
                    Main.bgAlpha2[2] += Main.tranSpeed;
                    if (Main.bgAlpha2[2] > 1f)
                    {
                        Main.bgAlpha2[2] = 1f;
                    }
                    Main.bgAlpha2[3] -= Main.tranSpeed;
                    if (Main.bgAlpha2[3] < 0f)
                    {
                        Main.bgAlpha2[3] = 0f;
                    }
                    Main.bgAlpha2[4] -= Main.tranSpeed;
                    if (Main.bgAlpha2[4] < 0f)
                    {
                        Main.bgAlpha2[4] = 0f;
                    }
                    Main.bgAlpha2[5] -= Main.tranSpeed;
                    if (Main.bgAlpha2[5] < 0f)
                    {
                        Main.bgAlpha2[5] = 0f;
                    }
                    Main.bgAlpha2[6] -= Main.tranSpeed;
                    if (Main.bgAlpha2[6] < 0f)
                    {
                        Main.bgAlpha2[6] = 0f;
                    }
                }
                else
                {
                    if (Main.bgStyle == 4)
                    {
                        Main.bgAlpha2[0] -= Main.tranSpeed;
                        if (Main.bgAlpha2[0] < 0f)
                        {
                            Main.bgAlpha2[0] = 0f;
                        }
                        Main.bgAlpha2[1] -= Main.tranSpeed;
                        if (Main.bgAlpha2[1] < 0f)
                        {
                            Main.bgAlpha2[1] = 0f;
                        }
                        Main.bgAlpha2[2] -= Main.tranSpeed;
                        if (Main.bgAlpha2[2] < 0f)
                        {
                            Main.bgAlpha2[2] = 0f;
                        }
                        Main.bgAlpha2[3] += Main.tranSpeed;
                        if (Main.bgAlpha2[3] > 1f)
                        {
                            Main.bgAlpha2[3] = 1f;
                        }
                        Main.bgAlpha2[4] -= Main.tranSpeed;
                        if (Main.bgAlpha2[4] < 0f)
                        {
                            Main.bgAlpha2[4] = 0f;
                        }
                        Main.bgAlpha2[5] -= Main.tranSpeed;
                        if (Main.bgAlpha2[5] < 0f)
                        {
                            Main.bgAlpha2[5] = 0f;
                        }
                        Main.bgAlpha2[6] -= Main.tranSpeed;
                        if (Main.bgAlpha2[6] < 0f)
                        {
                            Main.bgAlpha2[6] = 0f;
                        }
                    }
                    else
                    {
                        if (Main.bgStyle == 7)
                        {
                            Main.bgAlpha2[0] -= Main.tranSpeed;
                            if (Main.bgAlpha2[0] < 0f)
                            {
                                Main.bgAlpha2[0] = 0f;
                            }
                            Main.bgAlpha2[1] -= Main.tranSpeed;
                            if (Main.bgAlpha2[1] < 0f)
                            {
                                Main.bgAlpha2[1] = 0f;
                            }
                            Main.bgAlpha2[2] -= Main.tranSpeed;
                            if (Main.bgAlpha2[2] < 0f)
                            {
                                Main.bgAlpha2[2] = 0f;
                            }
                            Main.bgAlpha2[3] -= Main.tranSpeed;
                            if (Main.bgAlpha2[3] < 0f)
                            {
                                Main.bgAlpha2[3] = 0f;
                            }
                            Main.bgAlpha2[4] += Main.tranSpeed;
                            if (Main.bgAlpha2[4] > 1f)
                            {
                                Main.bgAlpha2[4] = 1f;
                            }
                            Main.bgAlpha2[5] -= Main.tranSpeed;
                            if (Main.bgAlpha2[5] < 0f)
                            {
                                Main.bgAlpha2[5] = 0f;
                            }
                            Main.bgAlpha2[6] -= Main.tranSpeed;
                            if (Main.bgAlpha2[6] < 0f)
                            {
                                Main.bgAlpha2[6] = 0f;
                            }
                        }
                        else
                        {
                            if (Main.bgStyle == 8)
                            {
                                Main.bgAlpha2[0] -= Main.tranSpeed;
                                if (Main.bgAlpha2[0] < 0f)
                                {
                                    Main.bgAlpha2[0] = 0f;
                                }
                                Main.bgAlpha2[1] -= Main.tranSpeed;
                                if (Main.bgAlpha2[1] < 0f)
                                {
                                    Main.bgAlpha2[1] = 0f;
                                }
                                Main.bgAlpha2[2] -= Main.tranSpeed;
                                if (Main.bgAlpha2[2] < 0f)
                                {
                                    Main.bgAlpha2[2] = 0f;
                                }
                                Main.bgAlpha2[3] -= Main.tranSpeed;
                                if (Main.bgAlpha2[3] < 0f)
                                {
                                    Main.bgAlpha2[3] = 0f;
                                }
                                Main.bgAlpha2[4] -= Main.tranSpeed;
                                if (Main.bgAlpha2[4] < 0f)
                                {
                                    Main.bgAlpha2[4] = 0f;
                                }
                                Main.bgAlpha2[5] += Main.tranSpeed;
                                if (Main.bgAlpha2[5] > 1f)
                                {
                                    Main.bgAlpha2[5] = 1f;
                                }
                                Main.bgAlpha2[6] -= Main.tranSpeed;
                                if (Main.bgAlpha2[6] < 0f)
                                {
                                    Main.bgAlpha2[6] = 0f;
                                }
                            }
                            else
                            {
                                if (Main.bgStyle == 9)
                                {
                                    Main.bgAlpha2[0] += Main.tranSpeed;
                                    if (Main.bgAlpha2[0] > 1f)
                                    {
                                        Main.bgAlpha2[0] = 1f;
                                    }
                                    Main.bgAlpha2[1] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[1] < 0f)
                                    {
                                        Main.bgAlpha2[1] = 0f;
                                    }
                                    Main.bgAlpha2[2] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[2] < 0f)
                                    {
                                        Main.bgAlpha2[2] = 0f;
                                    }
                                    Main.bgAlpha2[3] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[3] < 0f)
                                    {
                                        Main.bgAlpha2[3] = 0f;
                                    }
                                    Main.bgAlpha2[4] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[4] < 0f)
                                    {
                                        Main.bgAlpha2[4] = 0f;
                                    }
                                    Main.bgAlpha2[5] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[5] < 0f)
                                    {
                                        Main.bgAlpha2[5] = 0f;
                                    }
                                    Main.bgAlpha2[6] += Main.tranSpeed;
                                    if (Main.bgAlpha2[6] > 1f)
                                    {
                                        Main.bgAlpha2[6] = 1f;
                                    }
                                }
                                else
                                {
                                    Main.bgAlpha2[0] += Main.tranSpeed;
                                    if (Main.bgAlpha2[0] > 1f)
                                    {
                                        Main.bgAlpha2[0] = 1f;
                                    }
                                    Main.bgAlpha2[1] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[1] < 0f)
                                    {
                                        Main.bgAlpha2[1] = 0f;
                                    }
                                    Main.bgAlpha2[2] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[2] < 0f)
                                    {
                                        Main.bgAlpha2[2] = 0f;
                                    }
                                    Main.bgAlpha2[3] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[3] < 0f)
                                    {
                                        Main.bgAlpha2[3] = 0f;
                                    }
                                    Main.bgAlpha2[4] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[4] < 0f)
                                    {
                                        Main.bgAlpha2[4] = 0f;
                                    }
                                    Main.bgAlpha2[5] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[5] < 0f)
                                    {
                                        Main.bgAlpha2[5] = 0f;
                                    }
                                    Main.bgAlpha2[6] -= Main.tranSpeed;
                                    if (Main.bgAlpha2[6] < 0f)
                                    {
                                        Main.bgAlpha2[6] = 0f;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (Main.ignoreErrors)
            {
                try
                {
                    this.DrawSurfaceBG();
                    goto IL_45FC;
                }
                catch
                {
                    goto IL_45FC;
                }
            }
            this.DrawSurfaceBG();
        IL_45FC:
            if (Main.gameMenu || Main.netMode == 2)
            {
                for (int k = 0; k < Main.maxRain; k++)
                {
                    if (Main.rain[k].active)
                    {
                        Main.spriteBatch.Draw(Main.rainTexture[(int)Main.rain[k].type], Main.rain[k].position - Main.screenPosition, new Rectangle?(new Rectangle(0, 0, Main.rainTexture[(int)Main.rain[k].type].Width, Main.rainTexture[(int)Main.rain[k].type].Height)), Main.bgColor * 0.85f, Main.rain[k].rotation, default(Vector2), Main.rain[k].scale, SpriteEffects.None, 0f);
                        if (base.IsActive)
                        {
                            Main.rain[k].Update();
                        }
                    }
                }
                this.DrawMenu();
                return;
            }
            this.firstTileX = (int)(Main.screenPosition.X / 16f - 1f);
            this.lastTileX = (int)((Main.screenPosition.X + (float)Main.screenWidth) / 16f) + 2;
            this.firstTileY = (int)(Main.screenPosition.Y / 16f - 1f);
            this.lastTileY = (int)((Main.screenPosition.Y + (float)Main.screenHeight) / 16f) + 2;
            if (this.firstTileX < 0)
            {
                this.firstTileX = 0;
            }
            if (this.lastTileX > Main.maxTilesX)
            {
                this.lastTileX = Main.maxTilesX;
            }
            if (this.firstTileY < 0)
            {
                this.firstTileY = 0;
            }
            if (this.lastTileY > Main.maxTilesY)
            {
                this.lastTileY = Main.maxTilesY;
            }
            if (!Main.drawSkip)
            {
                Lighting.LightTiles(this.firstTileX, this.lastTileX, this.firstTileY, this.lastTileY);
            }
            if (!Main.mapFullscreen)
            {
                Color arg_4867_0 = Color.White;
                if (Main.drawToScreen)
                {
                    this.drawWaters(true);
                }
                else
                {
                    Main.spriteBatch.Draw(this.backWaterTarget, Main.sceneBackgroundPos - Main.screenPosition, Color.White);
                }
                float x = (Main.sceneBackgroundPos.X - Main.screenPosition.X + (float)Main.offScreenRange) * Main.caveParrallax - (float)Main.offScreenRange;
                if (Main.drawToScreen)
                {
                    this.DrawBackground();
                }
                else
                {
                    Main.spriteBatch.Draw(this.backgroundTarget, new Vector2(x, Main.sceneBackgroundPos.Y - Main.screenPosition.Y), Color.White);
                }
                Main.magmaBGFrameCounter++;
                if (Main.magmaBGFrameCounter >= 8)
                {
                    Main.magmaBGFrameCounter = 0;
                    Main.magmaBGFrame++;
                    if (Main.magmaBGFrame >= 3)
                    {
                        Main.magmaBGFrame = 0;
                    }
                }
                try
                {
                    if (Main.drawToScreen)
                    {
                        this.DrawBlack();
                        this.DrawWalls();
                    }
                    else
                    {
                        Main.spriteBatch.Draw(this.blackTarget, Main.sceneTilePos - Main.screenPosition, Color.White);
                        Main.spriteBatch.Draw(this.wallTarget, Main.sceneWallPos - Main.screenPosition, Color.White);
                    }
                    this.DrawWoF();
                    if (Main.player[Main.myPlayer].detectCreature)
                    {
                        if (Main.drawToScreen)
                        {
                            this.DrawTiles(false);
                            this.waterfallManager.Draw(Main.spriteBatch);
                            this.DrawTiles(true);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Color.White);
                            this.waterfallManager.Draw(Main.spriteBatch);
                            Main.spriteBatch.Draw(this.tileTarget, Main.sceneTilePos - Main.screenPosition, Color.White);
                        }
                        this.DrawNPCs(true);
                        this.DrawNPCs(false);
                    }
                    else
                    {
                        if (Main.drawToScreen)
                        {
                            this.DrawTiles(false);
                            this.waterfallManager.Draw(Main.spriteBatch);
                            this.DrawNPCs(true);
                            this.DrawTiles(true);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(this.tile2Target, Main.sceneTile2Pos - Main.screenPosition, Color.White);
                            this.waterfallManager.Draw(Main.spriteBatch);
                            this.DrawNPCs(true);
                            Main.spriteBatch.Draw(this.tileTarget, Main.sceneTilePos - Main.screenPosition, Color.White);
                        }
                        this.DrawNPCs(false);
                    }
                }
                catch
                {
                }
                if (Main.ignoreErrors)
                {
                    for (int l = 0; l < 1000; l++)
                    {
                        if (Main.projectile[l].active && Main.projectile[l].type > 0 && !Main.projectile[l].hide)
                        {
                            try
                            {
                                this.DrawProj(l);
                            }
                            catch
                            {
                                Main.projectile[l].active = false;
                            }
                        }
                    }
                }
                else
                {
                    for (int m = 0; m < 1000; m++)
                    {
                        if (Main.projectile[m].active && Main.projectile[m].type > 0 && !Main.projectile[m].hide)
                        {
                            this.DrawProj(m);
                        }
                    }
                }
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, this.Rasterizer, null, this.Transform);
                for (int n = 0; n < 255; n++)
                {
                    if (Main.player[n].active && !Main.player[n].outOfRange)
                    {
                        if (Main.gamePaused)
                        {
                            Main.player[n].PlayerFrame();
                        }
                        if (Main.player[n].ghost)
                        {
                            Vector2 position = Main.player[n].position;
                            Main.player[n].position = Main.player[n].shadowPos[0];
                            Main.player[n].shadow = 0.5f;
                            this.DrawGhost(Main.player[n]);
                            Main.player[n].position = Main.player[n].shadowPos[1];
                            Main.player[n].shadow = 0.7f;
                            this.DrawGhost(Main.player[n]);
                            Main.player[n].position = Main.player[n].shadowPos[2];
                            Main.player[n].shadow = 0.9f;
                            this.DrawGhost(Main.player[n]);
                            Main.player[n].position = position;
                            Main.player[n].shadow = 0f;
                            this.DrawGhost(Main.player[n]);
                        }
                        else
                        {
                            if (Main.player[n].inventory[Main.player[n].selectedItem].flame || Main.player[n].head == 137 || Main.player[n].wings == 22)
                            {
                                Main.player[n].itemFlameCount--;
                                if (Main.player[n].itemFlameCount <= 0)
                                {
                                    Main.player[n].itemFlameCount = 5;
                                    for (int num69 = 0; num69 < 7; num69++)
                                    {
                                        Main.player[n].itemFlamePos[num69].X = (float)Main.rand.Next(-10, 11) * 0.15f;
                                        Main.player[n].itemFlamePos[num69].Y = (float)Main.rand.Next(-10, 1) * 0.35f;
                                    }
                                }
                            }
                            bool flag2 = false;
                            bool flag3 = false;
                            bool flag4 = false;
                            if (Main.player[n].head == 111 && Main.player[n].body == 73 && Main.player[n].legs == 62)
                            {
                                flag3 = true;
                                flag4 = true;
                            }
                            if (Main.player[n].head == 134 && Main.player[n].body == 95 && Main.player[n].legs == 79)
                            {
                                flag3 = true;
                                flag4 = true;
                            }
                            if (Main.player[n].head == 107 && Main.player[n].body == 69 && Main.player[n].legs == 58)
                            {
                                flag3 = true;
                                flag2 = true;
                            }
                            if (Main.player[n].head == 108 && Main.player[n].body == 70 && Main.player[n].legs == 59)
                            {
                                flag3 = true;
                                flag2 = true;
                            }
                            if (Main.player[n].head == 109 && Main.player[n].body == 71 && Main.player[n].legs == 60)
                            {
                                flag3 = true;
                                flag2 = true;
                            }
                            if (Main.player[n].head == 110 && Main.player[n].body == 72 && Main.player[n].legs == 61)
                            {
                                flag3 = true;
                                flag2 = true;
                            }
                            if (Main.player[n].body == 67 && Main.player[n].legs == 56 && Main.player[n].head >= 103 && Main.player[n].head <= 105)
                            {
                                flag2 = true;
                            }
                            if ((Main.player[n].head == 78 || Main.player[n].head == 79 || Main.player[n].head == 80) && Main.player[n].body == 51 && Main.player[n].legs == 47)
                            {
                                flag3 = true;
                            }
                            if (Main.player[n].dashDelay < 0)
                            {
                                flag2 = true;
                            }
                            if (Main.player[n].head == 5 && Main.player[n].body == 5 && Main.player[n].legs == 5)
                            {
                                flag2 = true;
                            }
                            if (Main.player[n].head == 74 && Main.player[n].body == 48 && Main.player[n].legs == 44)
                            {
                                flag2 = true;
                            }
                            if (Main.player[n].head == 76 && Main.player[n].body == 49 && Main.player[n].legs == 45)
                            {
                                flag2 = true;
                            }
                            if (Main.player[n].head == 7 && Main.player[n].body == 7 && Main.player[n].legs == 7)
                            {
                                flag2 = true;
                            }
                            if (Main.player[n].head == 22 && Main.player[n].body == 14 && Main.player[n].legs == 14)
                            {
                                flag2 = true;
                            }
                            if (Main.player[n].dye[0].dye == 30 && Main.player[n].dye[1].dye == 30 && Main.player[n].dye[2].dye == 30 && Main.player[n].head == 4 && Main.player[n].body == 27 && Main.player[n].legs == 26)
                            {
                                flag2 = true;
                                flag4 = true;
                            }
                            if (Main.player[n].body == 17 && Main.player[n].legs == 16 && (Main.player[n].head == 29 || Main.player[n].head == 30 || Main.player[n].head == 31))
                            {
                                flag2 = true;
                            }
                            if (Main.player[n].body == 19 && Main.player[n].legs == 18 && (Main.player[n].head == 35 || Main.player[n].head == 36 || Main.player[n].head == 37))
                            {
                                flag4 = true;
                            }
                            if (Main.myPlayer == n)
                            {
                                bool flag5 = false;
                                if (Main.player[n].wings == 3 || (Main.player[n].wings >= 16 && Main.player[n].wings <= 19))
                                {
                                    flag5 = true;
                                }
                                else
                                {
                                    if (Main.player[n].head == 45 || (Main.player[n].head >= 106 && Main.player[n].head <= 110))
                                    {
                                        flag5 = true;
                                    }
                                    else
                                    {
                                        if (Main.player[n].body == 26 || (Main.player[n].body >= 68 && Main.player[n].body <= 74))
                                        {
                                            flag5 = true;
                                        }
                                        else
                                        {
                                            if (Main.player[n].legs == 25 || (Main.player[n].legs >= 57 && Main.player[n].legs <= 63))
                                            {
                                                flag5 = true;
                                            }
                                        }
                                    }
                                }
                                if (flag5)
                                {
                                    Player expr_535A_cp_0 = Main.player[n];
                                    expr_535A_cp_0.velocity.X = expr_535A_cp_0.velocity.X * 0.9f;
                                    if (Main.player[n].velocity.Y < 0f)
                                    {
                                        Player expr_5391_cp_0 = Main.player[n];
                                        expr_5391_cp_0.velocity.Y = expr_5391_cp_0.velocity.Y + 0.2f;
                                    }
                                    Main.player[n].jump = 0;
                                    Main.player[n].statDefense = -1000;
                                    Main.player[n].AddBuff(23, 2, false);
                                    Main.player[n].AddBuff(80, 2, false);
                                    Main.player[n].AddBuff(67, 2, false);
                                    Main.player[n].AddBuff(32, 2, false);
                                    Main.player[n].AddBuff(31, 2, false);
                                    Main.player[n].AddBuff(33, 2, false);
                                }
                            }
                            if (Main.player[n].body == 26 && Main.player[n].legs == 25 && Main.player[n].head == 45)
                            {
                                flag4 = true;
                                flag2 = true;
                            }
                            if (Main.player[n].body == 26 && Main.player[n].legs == 25 && Main.player[n].head == 63)
                            {
                                flag4 = true;
                                flag2 = true;
                            }
                            if (Main.player[n].body == 24 && Main.player[n].legs == 23 && (Main.player[n].head == 41 || Main.player[n].head == 42 || Main.player[n].head == 43))
                            {
                                flag4 = true;
                                flag2 = true;
                            }
                            if (Main.player[n].head == 157 && Main.player[n].legs == 98 && Main.player[n].body != 105)
                            {
                                int arg_553B_0 = Main.player[n].body;
                            }
                            if (Main.player[n].body == 36 && Main.player[n].head == 56)
                            {
                                flag4 = true;
                            }
                            if (flag4)
                            {
                                Vector2 position2 = Main.player[n].position;
                                if (!Main.gamePaused)
                                {
                                    Main.player[n].ghostFade += Main.player[n].ghostDir * 0.075f;
                                }
                                if ((double)Main.player[n].ghostFade < 0.1)
                                {
                                    Main.player[n].ghostDir = 1f;
                                    Main.player[n].ghostFade = 0.1f;
                                }
                                if ((double)Main.player[n].ghostFade > 0.9)
                                {
                                    Main.player[n].ghostDir = -1f;
                                    Main.player[n].ghostFade = 0.9f;
                                }
                                Main.player[n].position.X = position2.X - Main.player[n].ghostFade * 5f;
                                Player expr_5659_cp_0 = Main.player[n];
                                expr_5659_cp_0.position.Y = expr_5659_cp_0.position.Y + Main.player[n].gfxOffY;
                                Main.player[n].shadow = Main.player[n].ghostFade;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].position.X = position2.X + Main.player[n].ghostFade * 5f;
                                Main.player[n].shadow = Main.player[n].ghostFade;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].position = position2;
                                Main.player[n].position.Y = position2.Y - Main.player[n].ghostFade * 5f;
                                Player expr_5738_cp_0 = Main.player[n];
                                expr_5738_cp_0.position.Y = expr_5738_cp_0.position.Y + Main.player[n].gfxOffY;
                                Main.player[n].shadow = Main.player[n].ghostFade;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].position.Y = position2.Y + Main.player[n].ghostFade * 5f;
                                Player expr_57B3_cp_0 = Main.player[n];
                                expr_57B3_cp_0.position.Y = expr_57B3_cp_0.position.Y + Main.player[n].gfxOffY;
                                Main.player[n].shadow = Main.player[n].ghostFade;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].position = position2;
                                Main.player[n].shadow = 0f;
                            }
                            if (flag2)
                            {
                                Vector2 position3 = Main.player[n].position;
                                Main.player[n].position = Main.player[n].shadowPos[0];
                                Main.player[n].shadow = 0.5f;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].position = Main.player[n].shadowPos[1];
                                Main.player[n].shadow = 0.7f;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].position = Main.player[n].shadowPos[2];
                                Main.player[n].shadow = 0.9f;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].position = position3;
                                Main.player[n].shadow = 0f;
                            }
                            if (flag3)
                            {
                                for (int num70 = 0; num70 < 4; num70++)
                                {
                                    Vector2 position4 = Main.player[n].position;
                                    Player expr_5946_cp_0 = Main.player[n];
                                    expr_5946_cp_0.position.X = expr_5946_cp_0.position.X + (float)Main.rand.Next(-20, 21) * 0.1f;
                                    Player expr_5974_cp_0 = Main.player[n];
                                    expr_5974_cp_0.position.Y = expr_5974_cp_0.position.Y + (float)Main.rand.Next(-20, 21) * 0.1f;
                                    Player expr_59A2_cp_0 = Main.player[n];
                                    expr_59A2_cp_0.position.Y = expr_59A2_cp_0.position.Y + Main.player[n].gfxOffY;
                                    Main.player[n].shadow = 0.9f;
                                    this.DrawPlayer(Main.player[n]);
                                    Main.player[n].position = position4;
                                    Main.player[n].shadow = 0f;
                                }
                            }
                            if (Main.player[n].shadowDodge)
                            {
                                Main.player[n].shadowDodgeCount += 1f;
                                if (Main.player[n].shadowDodgeCount > 30f)
                                {
                                    Main.player[n].shadowDodgeCount = 30f;
                                }
                            }
                            else
                            {
                                Main.player[n].shadowDodgeCount -= 1f;
                                if (Main.player[n].shadowDodgeCount < 0f)
                                {
                                    Main.player[n].shadowDodgeCount = 0f;
                                }
                            }
                            if (Main.player[n].shadowDodgeCount > 0f)
                            {
                                Vector2 position5 = Main.player[n].position;
                                Player expr_5ACC_cp_0 = Main.player[n];
                                expr_5ACC_cp_0.position.Y = expr_5ACC_cp_0.position.Y + Main.player[n].gfxOffY;
                                Player expr_5AF2_cp_0 = Main.player[n];
                                expr_5AF2_cp_0.position.X = expr_5AF2_cp_0.position.X + Main.player[n].shadowDodgeCount;
                                Main.player[n].shadow = 0.5f + (float)Main.rand.Next(-10, 11) * 0.005f;
                                this.DrawPlayer(Main.player[n]);
                                Player expr_5B4E_cp_0 = Main.player[n];
                                expr_5B4E_cp_0.position.X = expr_5B4E_cp_0.position.X - Main.player[n].shadowDodgeCount * 2f;
                                Main.player[n].shadow = 0.5f + (float)Main.rand.Next(-10, 11) * 0.005f;
                                this.DrawPlayer(Main.player[n]);
                                Main.player[n].shadow = 0f;
                                Main.player[n].position = position5;
                            }
                            this.DrawPlayer(Main.player[n]);
                        }
                    }
                }
                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, this.Rasterizer, null, this.Transform);
                if (!Main.gamePaused)
                {
                    Main.essScale += (float)Main.essDir * 0.01f;
                    if (Main.essScale > 1f)
                    {
                        Main.essDir = -1;
                        Main.essScale = 1f;
                    }
                    if ((double)Main.essScale < 0.7)
                    {
                        Main.essDir = 1;
                        Main.essScale = 0.7f;
                    }
                }
                for (int num71 = 0; num71 < Main.itemLimit; num71++)
                {
                    if (Main.item[num71].active && Main.item[num71].type > 0)
                    {
                        int arg_5CCD_0 = (int)((double)Main.item[num71].position.X + (double)Main.item[num71].width * 0.5) / 16;
                        int arg_5CD3_0 = Lighting.offScreenTiles;
                        int arg_5D04_0 = (int)((double)Main.item[num71].position.Y + (double)Main.item[num71].height * 0.5) / 16;
                        int arg_5D0A_0 = Lighting.offScreenTiles;
                        Color color8 = Lighting.GetColor((int)((double)Main.item[num71].position.X + (double)Main.item[num71].width * 0.5) / 16, (int)((double)Main.item[num71].position.Y + (double)Main.item[num71].height * 0.5) / 16);
                        if (!Main.gamePaused && base.IsActive && ((Main.item[num71].type >= 71 && Main.item[num71].type <= 74) || Main.item[num71].type == 58 || Main.item[num71].type == 109) && color8.R > 60)
                        {
                            float num72 = (float)Main.rand.Next(500) - (Math.Abs(Main.item[num71].velocity.X) + Math.Abs(Main.item[num71].velocity.Y)) * 10f;
                            if (num72 < (float)(color8.R / 50))
                            {
                                int num73 = Dust.NewDust(Main.item[num71].position, Main.item[num71].width, Main.item[num71].height, 43, 0f, 0f, 254, default(Color), 0.5f);
                                Main.dust[num73].velocity *= 0f;
                            }
                        }
                        float rotation3 = Main.item[num71].velocity.X * 0.2f;
                        float num74 = 1f;
                        Color alpha = Main.item[num71].GetAlpha(color8);
                        if (Main.item[num71].type == 662 || Main.item[num71].type == 663)
                        {
                            alpha.R = (byte)Main.DiscoR;
                            alpha.G = (byte)Main.DiscoG;
                            alpha.B = (byte)Main.DiscoB;
                            alpha.A = 255;
                        }
                        if (Main.item[num71].type == 520 || Main.item[num71].type == 521 || Main.item[num71].type == 547 || Main.item[num71].type == 548 || Main.item[num71].type == 549)
                        {
                            num74 = Main.essScale;
                            alpha.R = (byte)((float)alpha.R * num74);
                            alpha.G = (byte)((float)alpha.G * num74);
                            alpha.B = (byte)((float)alpha.B * num74);
                            alpha.A = (byte)((float)alpha.A * num74);
                        }
                        else
                        {
                            if (Main.item[num71].type == 58 || Main.item[num71].type == 184)
                            {
                                num74 = Main.essScale * 0.25f + 0.75f;
                                alpha.R = (byte)((float)alpha.R * num74);
                                alpha.G = (byte)((float)alpha.G * num74);
                                alpha.B = (byte)((float)alpha.B * num74);
                                alpha.A = (byte)((float)alpha.A * num74);
                            }
                        }
                        float num75 = (float)(Main.item[num71].height - Main.itemTexture[Main.item[num71].type].Height);
                        float num76 = (float)(Main.item[num71].width / 2 - Main.itemTexture[Main.item[num71].type].Width / 2);
                        if (Main.item[num71].type >= 1522 && Main.item[num71].type <= 1527)
                        {
                            Main.spriteBatch.Draw(Main.itemTexture[Main.item[num71].type], new Vector2(Main.item[num71].position.X - Main.screenPosition.X + (float)(Main.itemTexture[Main.item[num71].type].Width / 2) + num76, Main.item[num71].position.Y - Main.screenPosition.Y + (float)(Main.itemTexture[Main.item[num71].type].Height / 2) + num75 + 2f), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[num71].type].Width, Main.itemTexture[Main.item[num71].type].Height)), new Color(250, 250, 250, (int)(Main.mouseTextColor / 2)), rotation3, new Vector2((float)(Main.itemTexture[Main.item[num71].type].Width / 2), (float)(Main.itemTexture[Main.item[num71].type].Height / 2)), (float)Main.mouseTextColor / 1000f + 0.8f, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(Main.itemTexture[Main.item[num71].type], new Vector2(Main.item[num71].position.X - Main.screenPosition.X + (float)(Main.itemTexture[Main.item[num71].type].Width / 2) + num76, Main.item[num71].position.Y - Main.screenPosition.Y + (float)(Main.itemTexture[Main.item[num71].type].Height / 2) + num75 + 2f), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[num71].type].Width, Main.itemTexture[Main.item[num71].type].Height)), alpha, rotation3, new Vector2((float)(Main.itemTexture[Main.item[num71].type].Width / 2), (float)(Main.itemTexture[Main.item[num71].type].Height / 2)), num74, SpriteEffects.None, 0f);
                            if (Main.item[num71].color != default(Color))
                            {
                                Main.spriteBatch.Draw(Main.itemTexture[Main.item[num71].type], new Vector2(Main.item[num71].position.X - Main.screenPosition.X + (float)(Main.itemTexture[Main.item[num71].type].Width / 2) + num76, Main.item[num71].position.Y - Main.screenPosition.Y + (float)(Main.itemTexture[Main.item[num71].type].Height / 2) + num75 + 2f), new Rectangle?(new Rectangle(0, 0, Main.itemTexture[Main.item[num71].type].Width, Main.itemTexture[Main.item[num71].type].Height)), Main.item[num71].GetColor(color8), rotation3, new Vector2((float)(Main.itemTexture[Main.item[num71].type].Width / 2), (float)(Main.itemTexture[Main.item[num71].type].Height / 2)), num74, SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                for (int num77 = 0; num77 < Main.maxRain; num77++)
                {
                    Rain rain = Main.rain[num77];
                    if (rain.active)
                    {
                        Main.spriteBatch.Draw(Main.rainTexture[(int)rain.type], rain.position - Main.screenPosition, null, Lighting.GetColor((int)((double)rain.position.X + 4.0) / 16, (int)((double)rain.position.Y + 4.0) / 16) * 0.85f, rain.rotation, default(Vector2), rain.scale, SpriteEffects.None, 0f);
                        if (base.IsActive)
                        {
                            rain.Update();
                        }
                    }
                }
                if (Main.ignoreErrors)
                {
                    try
                    {
                        this.DrawGore();
                        goto IL_65B2;
                    }
                    catch
                    {
                        goto IL_65B2;
                    }
                }
                this.DrawGore();
            IL_65B2:
                Rectangle value2 = new Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 50, Main.screenWidth + 1000, Main.screenHeight + 100);
                for (int num78 = 0; num78 < Main.numDust; num78++)
                {
                    if (Main.dust[num78].active)
                    {
                        if (Main.dust[num78].type >= 130 && Main.dust[num78].type <= 134)
                        {
                            value2.X -= 500;
                            value2.Y -= 500;
                            value2.Width += 1000;
                            value2.Height += 1000;
                        }
                        if (new Rectangle((int)Main.dust[num78].position.X, (int)Main.dust[num78].position.Y, 4, 4).Intersects(value2))
                        {
                            if (Main.dust[num78].type >= 130 && Main.dust[num78].type <= 134)
                            {
                                float num79 = Math.Abs(Main.dust[num78].velocity.X) + Math.Abs(Main.dust[num78].velocity.Y);
                                num79 *= 0.3f;
                                num79 *= 10f;
                                if (num79 > 10f)
                                {
                                    num79 = 10f;
                                }
                                int num80 = 0;
                                while ((float)num80 < num79)
                                {
                                    Vector2 velocity = Main.dust[num78].velocity;
                                    Vector2 value3 = Main.dust[num78].position - velocity * (float)num80;
                                    float scale = Main.dust[num78].scale * (1f - (float)num80 / 10f);
                                    Color color9 = Lighting.GetColor((int)((double)Main.dust[num78].position.X + 4.0) / 16, (int)((double)Main.dust[num78].position.Y + 4.0) / 16);
                                    color9 = Main.dust[num78].GetAlpha(color9);
                                    Main.spriteBatch.Draw(Main.dustTexture, value3 - Main.screenPosition, new Rectangle?(Main.dust[num78].frame), color9, Main.dust[num78].rotation, new Vector2(4f, 4f), scale, SpriteEffects.None, 0f);
                                    num80++;
                                }
                            }
                            Color color10 = Lighting.GetColor((int)((double)Main.dust[num78].position.X + 4.0) / 16, (int)((double)Main.dust[num78].position.Y + 4.0) / 16);
                            if (Main.dust[num78].type == 6 || Main.dust[num78].type == 15 || (Main.dust[num78].noLight && Main.dust[num78].type < 86 && Main.dust[num78].type > 91) || (Main.dust[num78].type >= 59 && Main.dust[num78].type <= 64))
                            {
                                color10 = Color.White;
                            }
                            color10 = Main.dust[num78].GetAlpha(color10);
                            Main.spriteBatch.Draw(Main.dustTexture, Main.dust[num78].position - Main.screenPosition, new Rectangle?(Main.dust[num78].frame), color10, Main.dust[num78].rotation, new Vector2(4f, 4f), Main.dust[num78].scale, SpriteEffects.None, 0f);
                            if (Main.dust[num78].color != default(Color))
                            {
                                Main.spriteBatch.Draw(Main.dustTexture, Main.dust[num78].position - Main.screenPosition, new Rectangle?(Main.dust[num78].frame), Main.dust[num78].GetColor(color10), Main.dust[num78].rotation, new Vector2(4f, 4f), Main.dust[num78].scale, SpriteEffects.None, 0f);
                            }
                            if (color10 == Color.Black)
                            {
                                Main.dust[num78].active = false;
                            }
                        }
                        else
                        {
                            Main.dust[num78].active = false;
                        }
                    }
                }
                if (Main.drawToScreen)
                {
                    this.drawWaters(false);
                    if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].mech)
                    {
                        this.DrawWires();
                    }
                }
                else
                {
                    Main.spriteBatch.Draw(this.waterTarget, Main.sceneWaterPos - Main.screenPosition, Color.White);
                }
                if (!Main.mapFullscreen && Main.mapStyle == 2)
                {
                    if (Main.ignoreErrors)
                    {
                        try
                        {
                            this.DrawMap();
                            goto IL_6AE3;
                        }
                        catch
                        {
                            goto IL_6AE3;
                        }
                    }
                    this.DrawMap();
                }
            IL_6AE3:
                Main.spriteBatch.End();
                Main.spriteBatch.Begin();
                if (!Main.hideUI)
                {
                    for (int num81 = 0; num81 < 255; num81++)
                    {
                        if (Main.player[num81].active && Main.player[num81].chatShowTime > 0 && num81 != Main.myPlayer && !Main.player[num81].dead)
                        {
                            Vector2 vector = Main.fontMouseText.MeasureString(Main.player[num81].chatText);
                            Vector2 vector2;
                            vector2.X = Main.player[num81].position.X + (float)(Main.player[num81].width / 2) - vector.X / 2f;
                            vector2.Y = Main.player[num81].position.Y - vector.Y - 2f;
                            if (Main.player[Main.myPlayer].gravDir == -1f)
                            {
                                vector2.Y -= Main.screenPosition.Y;
                                vector2.Y = Main.screenPosition.Y + (float)Main.screenHeight - vector2.Y;
                            }
                            for (int num82 = 0; num82 < 5; num82++)
                            {
                                int num83 = 0;
                                int num84 = 0;
                                Color black = Color.Black;
                                if (num82 == 0)
                                {
                                    num83 = -2;
                                }
                                if (num82 == 1)
                                {
                                    num83 = 2;
                                }
                                if (num82 == 2)
                                {
                                    num84 = -2;
                                }
                                if (num82 == 3)
                                {
                                    num84 = 2;
                                }
                                if (num82 == 4)
                                {
                                    black = new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor);
                                }
                                Main.spriteBatch.DrawString(Main.fontMouseText, Main.player[num81].chatText, new Vector2(vector2.X + (float)num83 - Main.screenPosition.X, vector2.Y + (float)num84 - Main.screenPosition.Y), black, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    for (int num85 = 0; num85 < 100; num85++)
                    {
                        if (Main.combatText[num85].active)
                        {
                            int num86 = 0;
                            if (Main.combatText[num85].crit)
                            {
                                num86 = 1;
                            }
                            Vector2 vector3 = Main.fontCombatText[num86].MeasureString(Main.combatText[num85].text);
                            Vector2 origin = new Vector2(vector3.X * 0.5f, vector3.Y * 0.5f);
                            float arg_6D6C_0 = Main.combatText[num85].scale;
                            float num87 = (float)Main.combatText[num85].color.R;
                            float num88 = (float)Main.combatText[num85].color.G;
                            float num89 = (float)Main.combatText[num85].color.B;
                            float num90 = (float)Main.combatText[num85].color.A;
                            num87 *= Main.combatText[num85].scale * Main.combatText[num85].alpha * 0.3f;
                            num89 *= Main.combatText[num85].scale * Main.combatText[num85].alpha * 0.3f;
                            num88 *= Main.combatText[num85].scale * Main.combatText[num85].alpha * 0.3f;
                            num90 *= Main.combatText[num85].scale * Main.combatText[num85].alpha;
                            Color color11 = new Color((int)num87, (int)num88, (int)num89, (int)num90);
                            for (int num91 = 0; num91 < 5; num91++)
                            {
                                int num92 = 0;
                                int num93 = 0;
                                if (num91 == 0)
                                {
                                    num92--;
                                }
                                else
                                {
                                    if (num91 == 1)
                                    {
                                        num92++;
                                    }
                                    else
                                    {
                                        if (num91 == 2)
                                        {
                                            num93--;
                                        }
                                        else
                                        {
                                            if (num91 == 3)
                                            {
                                                num93++;
                                            }
                                            else
                                            {
                                                num87 = (float)Main.combatText[num85].color.R * Main.combatText[num85].scale * Main.combatText[num85].alpha;
                                                num89 = (float)Main.combatText[num85].color.B * Main.combatText[num85].scale * Main.combatText[num85].alpha;
                                                num88 = (float)Main.combatText[num85].color.G * Main.combatText[num85].scale * Main.combatText[num85].alpha;
                                                num90 = (float)Main.combatText[num85].color.A * Main.combatText[num85].scale * Main.combatText[num85].alpha;
                                                color11 = new Color((int)num87, (int)num88, (int)num89, (int)num90);
                                            }
                                        }
                                    }
                                }
                                if (Main.player[Main.myPlayer].gravDir == -1f)
                                {
                                    float num94 = Main.combatText[num85].position.Y - Main.screenPosition.Y;
                                    num94 = (float)Main.screenHeight - num94;
                                    Main.spriteBatch.DrawString(Main.fontCombatText[num86], Main.combatText[num85].text, new Vector2(Main.combatText[num85].position.X - Main.screenPosition.X + (float)num92 + origin.X, num94 + (float)num93 + origin.Y), color11, Main.combatText[num85].rotation, origin, Main.combatText[num85].scale, SpriteEffects.None, 0f);
                                }
                                else
                                {
                                    Main.spriteBatch.DrawString(Main.fontCombatText[num86], Main.combatText[num85].text, new Vector2(Main.combatText[num85].position.X - Main.screenPosition.X + (float)num92 + origin.X, Main.combatText[num85].position.Y - Main.screenPosition.Y + (float)num93 + origin.Y), color11, Main.combatText[num85].rotation, origin, Main.combatText[num85].scale, SpriteEffects.None, 0f);
                                }
                            }
                        }
                    }
                    for (int num95 = 0; num95 < 20; num95++)
                    {
                        if (Main.itemText[num95].active)
                        {
                            string text = Main.itemText[num95].name;
                            if (Main.itemText[num95].stack > 1)
                            {
                                text = string.Concat(new object[]
								{
									text,
									" (",
									Main.itemText[num95].stack,
									")"
								});
                            }
                            Vector2 vector4 = Main.fontMouseText.MeasureString(text);
                            Vector2 origin2 = new Vector2(vector4.X * 0.5f, vector4.Y * 0.5f);
                            float arg_71BD_0 = Main.itemText[num95].scale;
                            float num96 = (float)Main.itemText[num95].color.R;
                            float num97 = (float)Main.itemText[num95].color.G;
                            float num98 = (float)Main.itemText[num95].color.B;
                            float num99 = (float)Main.itemText[num95].color.A;
                            num96 *= Main.itemText[num95].scale * Main.itemText[num95].alpha * 0.3f;
                            num98 *= Main.itemText[num95].scale * Main.itemText[num95].alpha * 0.3f;
                            num97 *= Main.itemText[num95].scale * Main.itemText[num95].alpha * 0.3f;
                            num99 *= Main.itemText[num95].scale * Main.itemText[num95].alpha;
                            Color color12 = new Color((int)num96, (int)num97, (int)num98, (int)num99);
                            for (int num100 = 0; num100 < 5; num100++)
                            {
                                int num101 = 0;
                                int num102 = 0;
                                if (num100 == 0)
                                {
                                    num101 -= 2;
                                }
                                else
                                {
                                    if (num100 == 1)
                                    {
                                        num101 += 2;
                                    }
                                    else
                                    {
                                        if (num100 == 2)
                                        {
                                            num102 -= 2;
                                        }
                                        else
                                        {
                                            if (num100 == 3)
                                            {
                                                num102 += 2;
                                            }
                                            else
                                            {
                                                num96 = (float)Main.itemText[num95].color.R * Main.itemText[num95].scale * Main.itemText[num95].alpha;
                                                num98 = (float)Main.itemText[num95].color.B * Main.itemText[num95].scale * Main.itemText[num95].alpha;
                                                num97 = (float)Main.itemText[num95].color.G * Main.itemText[num95].scale * Main.itemText[num95].alpha;
                                                num99 = (float)Main.itemText[num95].color.A * Main.itemText[num95].scale * Main.itemText[num95].alpha;
                                                color12 = new Color((int)num96, (int)num97, (int)num98, (int)num99);
                                            }
                                        }
                                    }
                                }
                                if (num100 < 4)
                                {
                                    num99 = (float)Main.itemText[num95].color.A * Main.itemText[num95].scale * Main.itemText[num95].alpha;
                                    color12 = new Color(0, 0, 0, (int)num99);
                                }
                                float num103 = Main.itemText[num95].position.Y - Main.screenPosition.Y + (float)num102;
                                if (Main.player[Main.myPlayer].gravDir == -1f)
                                {
                                    num103 = (float)Main.screenHeight - num103;
                                }
                                Main.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2(Main.itemText[num95].position.X - Main.screenPosition.X + (float)num101 + origin2.X, num103 + origin2.Y), color12, Main.itemText[num95].rotation, origin2, Main.itemText[num95].scale, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    if (Main.netMode == 1 && Netplay.clientSock.statusText != "" && Netplay.clientSock.statusText != null)
                    {
                        string text2 = string.Concat(new object[]
						{
							Netplay.clientSock.statusText,
							": ",
							(int)((float)Netplay.clientSock.statusCount / (float)Netplay.clientSock.statusMax * 100f),
							"%"
						});
                        Main.spriteBatch.DrawString(Main.fontMouseText, text2, new Vector2(628f - Main.fontMouseText.MeasureString(text2).X * 0.5f + (float)(Main.screenWidth - 800), 84f), new Color((int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor, (int)Main.mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
                    }
                    if (Main.BlackFadeIn > 0)
                    {
                        if (Main.BlackFadeIn < 0)
                        {
                            Main.BlackFadeIn = 0;
                        }
                        int num104 = Main.BlackFadeIn;
                        if (num104 > 255)
                        {
                            num104 = 255;
                        }
                        Main.BlackFadeIn -= 25;
                        Main.spriteBatch.Draw(Main.loTexture, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(0, 0, 0, num104));
                    }
                    this.DrawFPS();
                    if (!Main.mapFullscreen)
                    {
                        if (Main.ignoreErrors)
                        {
                            try
                            {
                                this.DrawInterface();
                                goto IL_7681;
                            }
                            catch
                            {
                                goto IL_7681;
                            }
                        }
                        this.DrawInterface();
                    }
                }
                else
                {
                    Main.maxQ = true;
                }
            IL_7681:
                Main.spriteBatch.End();
                if (Main.mouseLeft)
                {
                    Main.mouseLeftRelease = false;
                }
                else
                {
                    Main.mouseLeftRelease = true;
                }
                if (Main.mouseRight)
                {
                    Main.mouseRightRelease = false;
                }
                else
                {
                    Main.mouseRightRelease = true;
                }
                if (Main.mouseState.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    Main.stackSplit = 0;
                }
                if (Main.stackSplit > 0)
                {
                    Main.stackSplit--;
                }
                if (Main.renderCount < 10)
                {
                    Main.drawTimer[Main.renderCount] = (float)stopwatch.Elapsed.TotalMilliseconds;
                    if (Main.drawTimerMaxDelay[Main.renderCount] > 0f)
                    {
                        Main.drawTimerMaxDelay[Main.renderCount] -= 1f;
                    }
                    else
                    {
                        Main.drawTimerMax[Main.renderCount] = 0f;
                    }
                    if (Main.drawTimer[Main.renderCount] > Main.drawTimerMax[Main.renderCount])
                    {
                        Main.drawTimerMax[Main.renderCount] = Main.drawTimer[Main.renderCount];
                        Main.drawTimerMaxDelay[Main.renderCount] = 100f;
                    }
                }
                return;
            }
            if (Main.player[Main.myPlayer].talkNPC >= 0 || Main.player[Main.myPlayer].sign >= 0 || Main.playerInventory)
            {
                Main.player[Main.myPlayer].toggleInv();
            }
            this.DrawMap();
            this.DrawFPS();
            this.DrawPlayerChat();
            Main.spriteBatch.End();
            if (Main.mouseLeft)
            {
                Main.mouseLeftRelease = false;
                return;
            }
            Main.mouseLeftRelease = true;
        }
    }
}
