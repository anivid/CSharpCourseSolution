using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    //Enum неявно наследуется от int.
    //с каждым объектом enum есть ассоц. с ним чило
    //числа указаны неявно, их можно менять
    //здесь так же действуют модификаторы доступа
    public enum TrafficLights : int
    {
        //нумерация по умолчанию
        Red = 0,
        Yellow = 1,
        Green = 2
    }

    public enum Race
    {
        //пример использования ассоциированных значений
        //предположим, что от рассы зависит параметр брони
        Elf = 30,
        Ork = 40,
        Terrain = 10
    }
}
