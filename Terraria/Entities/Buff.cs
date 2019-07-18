using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Terraria.Entities
{
    public abstract class BuffEffectFollower : BuffEffect
    {
        public virtual int ProjectileID
        {
            protected set;
            get;
        }

        protected abstract void ApplyOverridable(Player target);
        public override void Apply(ref int buffTime, Player target)
        {
            buffTime = 18000;
            ApplyOverridable(target);
            for (int i = 0; i < 1000; i++)
            {
                if (Main.projectile[i].active
                    && Main.projectile[i].owner == target.whoAmi
                    && Main.projectile[i].type == ProjectileID)
                    return;
            }
            Projectile.NewProjectile(target.position.X + (float)(target.width / 2), target.position.Y + (float)(target.height / 2), 0f, 0f, ProjectileID, 0, 0f, target.whoAmi, 0f, 0f);
        }
    }
    public abstract class BuffEffect
    {
        public abstract int TypeID
        {
            get;
        } 
        public abstract void Apply(ref int buffTime, Player target);
    }
    public class Buff : EntityBase
    {
        //Static Stuff
        private static Dictionary<int, BuffEffect> buffs = new Dictionary<int, BuffEffect>();
        public static void Register(BuffEffect buff)
        {
            buffs.Add(buff.TypeID, buff);
        }

        public static BuffEffect Get(int type)
        {
            buffs.TryGetValue(type, out BuffEffect temp);
            return temp ?? buffs[-1];
        }

        //Inst Stuff
        public BuffEffect type;
        public int time;

        public override void save(System.IO.BinaryWriter Data)
        {
            Data.Write(type.TypeID);
            Data.Write(time);
        }

        public override void load(System.IO.BinaryReader Data)
        {
            this.type = Get(Data.ReadInt32());
            this.time = Data.ReadInt32();
        }

        //Data Registry
        static Buff()
        {
            Register(new NullBuffEffect());

            Register(new FireImmunityBuffEffect());
            Register(new IncreaseLifeRegenBuffEffect());
            Register(new IncreaseMoveSpeedBuffEffect());
            Register(new GillsBuffEffect());
            Register(new IncreaseDefenseBuffEffect());
            Register(new ManaRegenBuffEffect());
            Register(new IncreaseMagicDamageBuffEffect());
            Register(new SlowFallBuffEffect());
            Register(new FindTreasureBuffEffect());
            Register(new InvisibilityBuffEffect());
            Register(new AddLightBuffEffect());
            Register(new NightVisionBuffEffect());
        }
    }

    class NullBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return -1; }
        }
        public override void Apply(ref int buffTime, Player target){}
    }

    class FireImmunityBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 1; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.lavaImmune = true;
            target.fireWalk = true;
        }

    }

    class IncreaseLifeRegenBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 2; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.lifeRegen += 2;
        }
    }

    class IncreaseMoveSpeedBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 3; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.moveSpeed += 0.25f;
        }

    }

    class GillsBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 4; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.gills = true;
        }
    }

    class IncreaseDefenseBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 5; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.statDefense += 8;
        }
    }

    class ManaRegenBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 6; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.manaRegenBuff = true;
        }
    }

    class IncreaseMagicDamageBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 7; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.magicDamage += 0.2f;
        }
    }

    class SlowFallBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 8; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.slowFall = true;
        }
    }

    class FindTreasureBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 9; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.findTreasure = true;
        }
    }

    class InvisibilityBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 10; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.invis = true;
        }
    }

    class AddLightBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 11; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            Lighting.addLight((int)(target.position.X + (float)(target.width / 2)) / 16, (int)(target.position.Y + (float)(target.height / 2)) / 16, 0.8f, 0.95f, 1f);
        }
    }

    class NightVisionBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 12; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.nightVision = true;
        }
    }

    class EnemySpawnsBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 13; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.enemySpawns = true;
        }
    }
    
    class ThornsBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 14; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.thorns = true;
        }
    }
    
    class WaterWalkBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 15; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.waterWalk = true;
        }
    }
    
    class ArcheryBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 16; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.archery = true;
        }
    }
   
    class DetectCreaturesBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 17; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.detectCreature = true;
        }
    }

    class GravityBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 18; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.gravControl = true;
        }
    }
    
    class LightOrbBuffEffect : BuffEffectFollower
    {
        public override int TypeID{ get { return 19; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 18; target.lightOrb = true; }
    }
   
    class PoisonedBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 20; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.poisoned = true;
        }
    }
    
    class UsePotionDelayBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 21; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.potionDelay = buffTime;
        }
    }
   
    class BlindBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 22; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.blind = true;
        }
    }
    
    class NoItemBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 23; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.noItems = true;
        }
    }
    
    class FiredBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 24; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.onFire = true;
        }
    }
    
    class AleBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 25; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.statDefense -= 4;
            target.meleeCrit += 2;
            target.meleeDamage += 0.1f;
            target.meleeSpeed += 0.1f;
        }
    }

    class WellFedBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 26; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.statDefense += 2;
            target.meleeCrit += 2;
            target.meleeDamage += 0.05f;
            target.meleeSpeed += 0.05f;
            target.magicCrit += 2;
            target.magicDamage += 0.05f;
            target.rangedCrit += 2;
            target.magicDamage += 0.05f;
            target.minionDamage += 0.05f;
            target.minionKB += 0.5f;
            target.moveSpeed += 0.2f;
        }
    }

    class BlueFairyBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 27; } }
        public override int ProjectileID { get { return 72; } }
        protected override void ApplyOverridable(Player target) { target.blueFairy = true; }
        
    }

    class RedFairyBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 101; } }
        protected override void ApplyOverridable(Player target) { 
            target.redFairy = true;
            ProjectileID = 86;
            if (target.head == 45 && target.body == 26 && target.legs == 25) ProjectileID = 72;
        }
    }

    class GreenFairyBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 102; } }
        protected override void ApplyOverridable(Player target)
        {
            target.greenFairy = true;
            ProjectileID = 87;
            if (target.head == 45 && target.body == 26 && target.legs == 25) ProjectileID = 72;
        }
    }

    class WereWolfBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 28; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            if (!Main.dayTime && target.wolfAcc && !target.merman)
            {
                target.lifeRegen++;
                target.wereWolf = true;
                target.meleeCrit += 2;
                target.meleeDamage += 0.051f;
                target.meleeSpeed += 0.051f;
                target.statDefense += 3;
                target.moveSpeed += 0.05f;
            }
            else buffTime = 0;
        }
    }

    class ClairvoyanceBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 29; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.magicCrit += 2;
            target.magicDamage += 0.05f;
            target.statManaMax2 += 20;
            target.manaCost -= 0.02f;
        }
    }

    class BleedingBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 30; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.bleed = true;
        }
    }

    class ConfusedBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 31; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.confused = true;
        }
    }

    class SlowBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 32; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.slow = true;
        }
    }

    class WeakBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 33; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.meleeDamage -= 0.051f;
            target.meleeSpeed -= 0.051f;
            target.statDefense -= 4;
            target.moveSpeed -= 0.1f;
        }
    }

    class MermanBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 34; }
        }

        public override void Apply(ref int buffTime, Player target){ }
    }

    class SilenceBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 35; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.silence = true;
        }
    }

    class BrokenArmorBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 36; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.brokenArmor = true;
        }
    }

    class GrossBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 37; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
            {
                target.gross = true;
                buffTime = 10;
            }
            else buffTime = 0;
        }
    }

    class TongueBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 38; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            buffTime = 10;
            target.tongued = true;
        }
    }

    class HardFiredBuffEffect : BuffEffect
    {
        public override int TypeID
        {
            get { return 39; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.onFire2 = true;
        }
    }

    class BunnyBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 40; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 111; target.bunny = true; }
    }

    class PenguinBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 41; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 112; target.penguin = true; }
    }
    
    class PaladinBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 43; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.paladinBuff = true;
        }
    }

    class FrostBurnBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 44; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.onFrostBurn = true;
        }
    }

    class EaterBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 45; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 175; target.eater = true; }
    }

    class ChillBuffEffect : BuffEffect
    {
        public override int TypeID {  get { return 46; } }
        public override void Apply(ref int buffTime, Player target) { target.chilled = true; }
    }

    class FrozenBuffEffect : BuffEffect
    {
        public override int TypeID {  get { return 47; } }
        public override void Apply(ref int buffTime, Player target) { target.frozen = true; }
    }

    class IchorBuffEffect : BuffEffect
    {

        public override int TypeID
        {
            get { return 48; }
        }

        public override void Apply(ref int buffTime, Player target)
        {
            target.ichor = true;
            target.statDefense -= 20;
        }
    }

    class PygmyBuffEffect : BuffEffect
    {

        public override int TypeID { get { return 49; } }

        public override void Apply(ref int buffTime, Player target)
        {
            if (Main.myPlayer == target.whoAmi)
            {
                for (int m = 0; m < 1000; m++)
                {
                    if (Main.projectile[m].active 
                        && Main.projectile[m].owner == target.whoAmi 
                        && Main.projectile[m].type >= 191 
                        && Main.projectile[m].type <= 194)
                    {
                        target.pygmy = true;
                        break;
                    }
                }
                if (!target.pygmy) buffTime = 0;
                else buffTime = 18000;
            }
        }
    }

    class SkeletronBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 50; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 197; target.skeletron = true; }
    }

    class BabyHornetBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 51; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 198; target.hornet = true; }
    }

    class SikiSpiritBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 52; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 199; target.tiki = true; }
    }

    class LizardBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 53; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 200; target.lizard = true; }
    }

    class ParrotBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 54; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 208; target.parrot = true; }
    }

    class TruffleBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 55; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 209; target.truffle = true; }
    }

    class SaplingBuffEffect : BuffEffectFollower
    {
        public override int TypeID { get { return 56; } }
        protected override void ApplyOverridable(Player target) { ProjectileID = 210; target.sapling = true; }
    }




}
