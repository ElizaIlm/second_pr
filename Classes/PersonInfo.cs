using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second_pr.Classes
{
    public class PersonInfo
    {
        /// <summary> Наименование </summary>
        public string Name { get; set; }

        /// <summary> Жизненные показатели </summary>
        public int Health { get; set; }

        /// <summary> Броня </summary>
        public int Armor { get; set; }

        /// <summary> Уровень </summary>
        public int Level { get; set; }

        /// <summary> Опыт </summary>
        public int Glasses { get; set; }

        /// <summary> Денежные средства </summary>
        public int Money { get; set; }

        /// <summary> Урон </summary>
        public float Damage { get; set; }
        public PersonInfo(string Name, int Health, int Armor, int Level, int Glasses, int Money, float Damage)
        {
            this.Name = Name;
            this.Health = Health;
            this.Armor = Armor;
            this.Level = Level;
            this.Glasses = Glasses;
            this.Money = Money;
            this.Damage = Damage;
        }
        /// <summary>
        /// Множитель опыта  0.3 = +30% по базе 0 процентов максимум 30 
        /// </summary>
        public double chtoto { get; set; } = 0.0;
    }

}
