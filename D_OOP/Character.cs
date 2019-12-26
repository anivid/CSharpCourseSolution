using System;
using System.Collections.Generic;
using System.Text;

//класс содержит данные и методы

namespace D_OOP
{
    public class Character //по умолчанию internal
    {
        //свойства (оболочка над полем)
        //его можно заменить написанием методов(get и set) для определенного поля
        //св-во призвано сократить запись(вместо методов)
        //пример св-ва
        //public int Heath
        //{
        //    get // обеспечивает доступ на чтение
        //    {
        //        return healt;
        //    }

        //    private set //private используется для доступа только внутри класса
        //    {
        //        healt = value; //в методах можно будет работать сразу над св-вом Health -=damage
        //    }
        //}

        //при использовании рефакторинга можно использовать автосвойство, так же избавляет от полей
        //сокращенная запись св-ва
        public int Health { get; private set; } = 100;
        public int Armor { get; private set; }

        //const нельзя изменить ни откуда
        //для защиты от самих себя
        private const int speed = 10;
        //readonly необязательно инициализировать сразу
        //можно инициализировать из конструктора и больше ни откуда
        private readonly int manna = 0;        
        public void Hit(int damage)
        {
            if (damage > Health)
            {
                damage = Health;
            }
            //healt -= damage;
            Health -= damage;
        }
        public Race Race { get; private set; }

        //чтобы вызвать коструктор класса, используется сниппет ctor
        //конструктор по умолчанию не принимает никаких аргументов
        //конструктор вызывается при создании экземпляра класса Character ch1 = new Character();
        //можно добавить несколько конструкторов (в т.ч. конструктор по умолчанию)

        public Character()
        {
                
        }
        public Character(Race race)
        {
            //this используется для разделения переменных
            //в основном используется если имя поля экземпляра класса(переменной) в классе
            //такое же как и у передаваемого аргумента, например, this.race = race;
            this.Race = race;
            //пример использования ассоциированного значения из enum
            this.Armor = (int)race; 
        }
        public Character(Race race, int armor, int manna)
        {
            this.manna = manna; //инициализация readonly поля
            this.Armor = armor;
            this.Race = race;
        }
    }
}
