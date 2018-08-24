using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day21
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day21(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 0;
            int Sum2 = 0;
            int BossHitpoints = 0;
            int BossDamage = 0;
            int BossArmour = 0;
            int HeroHitpoints = 100;
            int HeroDamage = 0;
            int HeroArmour = 0;
            string[] Splitted = Instructions[0].Split(' ');
            Int32.TryParse(Splitted.Last(), out BossHitpoints);
            Splitted = Instructions[0].Split(' ');
            Int32.TryParse(Splitted.Last(), out BossDamage);
            Splitted = Instructions[0].Split(' ');
            Int32.TryParse(Splitted.Last(), out BossArmour);
            // initiate shop
            List<EquipmentItem> Weapons = new List<EquipmentItem>();
            List<EquipmentItem> Armour = new List<EquipmentItem>();
            List<EquipmentItem> Rings = new List<EquipmentItem>();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
    class EquipmentItem
    {
        String Type;
        String ItemName;
        int Cost;
        int Damage;
        int Armour;
        public EquipmentItem(string type, string itemName, int cost, int damage, int armour)
        {
            Type = type;
            ItemName = itemName;
            Cost = cost;
            Damage = damage;
            Armour = armour;
        }
    }
}