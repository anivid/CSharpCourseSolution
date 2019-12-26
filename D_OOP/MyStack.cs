using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace D_OOP
{
    //обощненный класс
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] _items;
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
        }
        public MyStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }
        public MyStack(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if (Count == Capacity)
            {
                T[] largerArray = new T[Capacity * 2];
                Array.Copy(_items, largerArray, Count);
                _items = largerArray;
            }

            _items[Count++] = item;
        }

        public void Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            _items[--Count] = default(T); //значение по умолчанию для типа Т
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _items[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(_items, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _array;
        //private readonly int _counter;
        private int _position;
        public StackEnumerator(T[] array, int count)
        {
            //this._counter = counter;
            this._array = array;
            _position = count;
        }
        public T Current => _array[_position]; //текущий элемент

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext() //есть ли следующий элемент и двигаться дальше
        {
            _position--;
            return _position >=0;
        }

        public void Reset() //изначальная позиция
        {
            _position = -1;
        }
    }
}
