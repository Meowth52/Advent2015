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
            int Sum = 1000000;
            int Sum2 = 0;
            Hero Boss = new Hero(Instructions);
            // initiate shop
            List<EquipmentItem> Weapons = new List<EquipmentItem>
            {
                new EquipmentItem("Weapon", "Dagger", 8, 4, 0),
                new EquipmentItem("Weapon", "Shortsword", 10, 5, 0),
                new EquipmentItem("Weapon", "Warhammer", 25, 6, 0),
                new EquipmentItem("Weapon", "Longsword", 40, 7, 0),
                new EquipmentItem("Weapon", "Greataxe", 74, 8, 0)
            };
            List<EquipmentItem> Armour = new List<EquipmentItem>
            {
                new EquipmentItem("Armour", "None", 0, 0, 0),
                new EquipmentItem("Armour", "Leather", 13, 0, 1),
                new EquipmentItem("Armour", "Chainmail", 31, 0, 2),
                new EquipmentItem("Armour", "Splintmail", 53, 0, 3),
                new EquipmentItem("Armour", "Bandedmail", 75, 0, 4),
                new EquipmentItem("Armour", "Platemail", 102, 0, 5)
            };
            List<EquipmentItem> Rings = new List<EquipmentItem>
            {
                new EquipmentItem("Ring", "None1", 0, 0, 0),
                new EquipmentItem("Ring", "None2", 0, 0, 0),
                new EquipmentItem("Ring", "Damage +1", 25, 1, 0),
                new EquipmentItem("Ring", "Damage +2", 50, 2, 0),
                new EquipmentItem("Ring", "Damage +3", 100, 3, 0),
                new EquipmentItem("Ring", "Defense +1", 20, 0, 1),
                new EquipmentItem("Ring", "Defense +2", 40, 0, 2),
                new EquipmentItem("Ring", "Defense +3", 80, 0, 3)
            };
            foreach (EquipmentItem w in Weapons)
            {
                foreach (EquipmentItem a in Armour)
                {
                    foreach (EquipmentItem rl in Rings)
                    {
                        foreach (EquipmentItem rr in Rings)
                        {
                            if (rl.ItemName != rr.ItemName)
                            {
                                //Part one
                                Hero Candidate = new Hero(w, a, rl, rr);
                                if (canHeroHasWin(Candidate, new Hero(Boss)))
                                {
                                    if (Candidate.getCost() < Sum)
                                        Sum = Candidate.getCost();
                                }
                                //Part two
                                else
                                    if (Candidate.getCost() > Sum2)
                                        Sum2 = Candidate.getCost();

                            }
                        }
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
        public bool canHeroHasWin(Hero TheOne, Hero Boss)
        {
            bool AreWeDoneYet = false;
            bool HeroWin = false;
            while (!AreWeDoneYet)
            {
                Boss.takeHit(TheOne.hit());
                if (Boss.isDead())
                {
                    HeroWin = true;
                    AreWeDoneYet = true;
                }
                else
                {
                    TheOne.takeHit(Boss.hit());
                    if (TheOne.isDead())
                        AreWeDoneYet = true;
                }
            }
            return HeroWin;
        }
    }
    class Hero
    {
        List<EquipmentItem> Items;
        int HeroHitpoints = 100;
        int HeroDamage = 0;
        int HeroArmour = 0;
        public Hero(EquipmentItem weapon, EquipmentItem armour, EquipmentItem ringLeft, EquipmentItem ringRight)
        {
            Items = new List<EquipmentItem> { weapon, armour, ringLeft, ringRight };
            foreach (EquipmentItem e in Items)
            {
                HeroDamage += e.Damage;
                HeroArmour += e.Armour;
            }
        }
        //not so hero after all
        public Hero(string[] Instructions)
        {
            string[] Splitted = Instructions[0].Split(' ');
            Int32.TryParse(Splitted.Last(), out HeroHitpoints);
            Splitted = Instructions[1].Split(' ');
            Int32.TryParse(Splitted.Last(), out HeroDamage);
            Splitted = Instructions[2].Split(' ');
            Int32.TryParse(Splitted.Last(), out HeroArmour);
        }
        public Hero(Hero h)
        {
            HeroHitpoints = h.HeroHitpoints;
            HeroDamage = h.HeroDamage;
            HeroArmour = h.HeroArmour;
        }
        public int hit()
        {
            return HeroDamage;
        }
        public void takeHit(int Damage)
        {
            int DamageTaken = Damage - HeroArmour;
            if (DamageTaken > 0)
                HeroHitpoints -= DamageTaken;
            else
                HeroHitpoints--;
        }
        public bool isDead()
        {
            return HeroHitpoints <= 0;
        }
        public int getCost()
        {
            int Cost = 0;
            foreach (EquipmentItem e in Items)
                Cost += e.Cost;
            return Cost;
        }
    }
    class EquipmentItem
    {
        String Type;
        public String ItemName { get; }
        public int Cost { get; }
        public int Damage { get; }
        public int Armour { get; }
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