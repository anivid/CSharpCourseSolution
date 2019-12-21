using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace D_OOP
{
    public class BankTerminal
    {
        //protected закрыт от внешнего мира, но виден в наследниках
        protected string id;

        
        public BankTerminal(string id)
        {
            this.id = id;
        }

        //чтобы часть наследников могла воспользоваться этим методом
        //а другая переопределить, объявляем метод как virtual
        public virtual void Connect()
        {
            Console.WriteLine("Conencting...\n");            
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine(6-i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Connection OK");
        }        
    }


    //объявление наследника
    public class ModelXTerminal : BankTerminal
    {
        //можно передавать значение id в конструкторе
        //public ModelXTerminal(string id)
        //{
        //    base.id = id;
        //}
        //чтобы не определять конструктор в каждом наследнике
        //это можно сделать в базовом классе
        public ModelXTerminal(string id) : base(id)
        {
        }

        //переопределяем метод
        public override void Connect()
        {            
            //вызов базовой реализации
            base.Connect();
            Console.WriteLine("Add actions on Model X Terminal...\n");
        }
    }
    public class ModelYTerminal : BankTerminal
    {        
        public ModelYTerminal(string id) : base(id)
        {
        }

        //переопределяем метод
        public override void Connect()
        {
            Console.WriteLine("Model Y Terminal witout base class");
        }
    }
    public class ModelGTerminal : BankTerminal
    {
        public ModelGTerminal(string id) : base(id)
        {
        }
    }


}
