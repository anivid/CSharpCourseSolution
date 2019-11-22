using System;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    //интерфейс - контракт на реализацию методов классов наследников
    //с помощью интерфейсов можно работать с классами наследниками унифицировано
    //в отличии от abstract, классы насленики могут унаследовать несколько 
    //интерфейсов и должны будут их все реализовать. Используя abstract, класс
    //наследник наследует только один abstract(+ может наследовать интерфейсы)
    //abstract - выражает отношение is a (я являюсь продолжением). 
    //interface - can do (я могу это сделать)
    public interface IBaseCollection
    {
        void Add(object obj);
        void Remove(object obj);
    }

    public class BaseList : IBaseCollection
    {
        private object[] _items;
        private int _count;
                
        public BaseList (int initialCapacity)
        {
            _items = new object[initialCapacity];
        }

        public void Add(object obj)
        {
            _items[_count++] = obj;
        }

        public void Remove(object obj)
        {
            _items[--_count] = null;
        }
    }
}
