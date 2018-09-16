using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Advent2015
{
    class Day22
    {
        Stopwatch stopWatch = new Stopwatch();
        private string Input;
        private string[] Instructions;
        public Day22(string input)
        {
            stopWatch.Start();
            Input = input.Replace("\r\n", "_");
            Instructions = Input.Split('_');
        }
        public string Result()
        {
            int Sum = 1000000;
            int Sum2 = 0;
            int IterationX = 0;
            Hero Boss = new Hero(Instructions);
            // initiate spells
            // (string itemName, int cost, int damage, int armour, int hp, int mana, int duration)
            List<Spell> Spells = new List<Spell>
            {
                new Spell("Magic Missile", 53, 4, 0, 0, 0, 1),
                new Spell("Drain", 73, 2, 0, 2, 0, 1),
                new Spell("Shield", 113, 0, 7, 0, 0, 6),
                new Spell("Poison", 173, 3, 0, 0, 0, 6),
                new Spell("Recharge", 229, 0, 0, 0, 101, 5)
            };
            List<Wizard> Wizards = new List<Wizard>();
            foreach (Spell s in Spells)
            {
                Wizards.Add(new Wizard(Boss, s));
            }            
            while (Wizards.Count > 0)
            {
                IterationX++;
                Wizard w = new Wizard(Wizards.Last());
                Wizards.RemoveAt(Wizards.Count - 1);
                foreach (Spell s in Spells)
                {
                    Wizard TestWizard = new Wizard(w);
                    if (TestWizard.trolla())
                        if (TestWizard.ManaSpent < Sum)
                        {
                            Sum = TestWizard.ManaSpent;
                        }
                        else;
                    else
                    {
                        if (!TestWizard.isDead() && TestWizard.ManaSpent < Sum)
                        {
                            if (TestWizard.Mana >= s.Cost & !TestWizard.hasSpell(s))
                                Wizards.Add(new Wizard(TestWizard, s));
                            else
                                //Wizards.Add(new Wizard(TestWizard));
                            ;
                        }
                    }
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return "Del 1: " + Sum.ToString() + " och del 2: " + Sum2.ToString() + " Executed in " + ts.TotalMilliseconds.ToString() + " ms";
        }
    }
    class Wizard
    {
        List<Spell> Spells = new List<Spell>();
        List<Spell> NextSpells = new List<Spell>();
        Hero Opponent;
        int Hitpoints;
        int Damage;
        int Armour;
        public int Mana { get; set; }
        public int ManaSpent { get; }
        public Wizard(Hero opponent, Spell newSpell)
        {
            Opponent = new Hero(opponent);
            Hitpoints = 50;
            Damage = 0;
            Armour = 0;
            Mana = 500;
            ManaSpent = 0;
            Spells.Add(new Spell(newSpell));
        }
        public Wizard(Wizard lastIteration)
        {
            Opponent = new Hero(lastIteration.Opponent);
            Hitpoints = lastIteration.Hitpoints;
            Damage = 0;
            Armour = 0;
            Mana = lastIteration.Mana;
            ManaSpent = lastIteration.ManaSpent;
            Spells = new List<Spell>();
            foreach (Spell s in lastIteration.Spells)
                Spells.Add(new Spell(s));
        }
        public Wizard(Wizard lastIteration, Spell newSpell)
        {
            Opponent = new Hero(lastIteration.Opponent);
            Hitpoints = lastIteration.Hitpoints;
            Damage = 0;
            Armour = 0;
            Mana = lastIteration.Mana - newSpell.Cost;
            ManaSpent = lastIteration.ManaSpent + newSpell.Cost;
            Spells = new List<Spell>();
            foreach (Spell s in lastIteration.Spells)
                Spells.Add(new Spell(s));
            Spells.Add(new Spell(newSpell));
        }
        public bool trolla()
        {
            if (Spells.Count == 0 && Mana < 53)
                Hitpoints = 0;
            foreach (Spell s in Spells)
            {
                Hitpoints += s.Hp;
                Damage += s.Damage;
                Armour += s.Armour;
                Mana += s.Mana;
                s.Duration--;
                if (s.Duration > 0)
                    NextSpells.Add(new Spell(s));
            }
            Opponent.takeHit(Damage);
            Spells = new List<Spell>(NextSpells);
            NextSpells.Clear();
            Damage = 0;
            Armour = 0;
            foreach (Spell s in Spells)
            {
                if (s.ItemName == "Poison")
                    Damage += s.Damage;
                Armour += s.Armour;
                Mana += s.Mana;
                s.Duration--;
                if (s.Duration > 0)
                    NextSpells.Add(new Spell(s));
            }
            Opponent.takeHit(Damage);
            this.takeHit();
            Spells = new List<Spell>(NextSpells);
            NextSpells.Clear();
            return Opponent.isDead();
        }
        public void takeHit()
        {
            int Damage = Opponent.hit();
            int DamageTaken = Damage - Armour;
            if (DamageTaken > 0)
                Hitpoints -= DamageTaken;
            else
                Hitpoints--;
        }
        public bool isDead()
        {
            return Hitpoints <= 0;
        }
        public bool hasSpell(Spell spell)
        {
            bool ReturnValue = false;
            foreach (Spell s in Spells)
                if (s.ItemName == spell.ItemName)
                    ReturnValue = true;
            return ReturnValue;
        }
    }
    class Spell
    {
        public String ItemName { get; }
        public int Cost { get; }
        public int Damage { get; }
        public int Armour { get; }
        public int Hp { get; }
        public int Mana { get; }
        public int Duration { get; set; }
        public Spell(string itemName, int cost, int damage, int armour, int hp, int mana, int duration)
        {
            ItemName = itemName;
            Cost = cost;
            Damage = damage;
            Armour = armour;
            Hp = hp;
            Mana = mana;
            Duration = duration;
        }
        public Spell(Spell s)
        {
            ItemName = s.ItemName;
            Cost = s.Cost;
            Damage = s.Damage;
            Armour = s.Armour;
            Hp = s.Hp;
            Mana = s.Mana;
            Duration = s.Duration;
        }
        public void tickDuration()
        {
            Duration--;
        }
    }
}