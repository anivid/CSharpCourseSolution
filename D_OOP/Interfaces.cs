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

    //объяаляем метод расширения интерфейса
    public static class BaseCollectionExtension
    {
        //первым аргументом указывается расширяемый интерфейс, остальные на наше усмотрение
        //здесь это IEnumerable - те классы что его имплементируют могут итерироваться 
        //foreach. Cюда может быть передана любая коллекция, напр. объект List, Stack, Queue и пр.
        //потому что все они реализуют IEnumerable
        public static void AddRange(this IBaseCollection collection, IEnumerable<object> objects)
        {
            foreach (var item in objects)
            {
                collection.Add(item);
            }
        }
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
