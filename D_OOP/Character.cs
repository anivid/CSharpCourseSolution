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
        public int Heath { get; private set; } = 100;
        public void Hit(int damage)
        {
            if (damage > Heath)
            {
                damage = Heath;
            }
            //healt -= damage;
            Heath -= damage;
        }


    }
}
