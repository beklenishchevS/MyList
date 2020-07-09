using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList
{
    public class MyList<T> : IList<T>
    {

        private T[] ts = new T[2];
      
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return ts[index];
            }
            set
            {
                if (index < 0 || index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                ts[index] = value;
            }
        }

        public int Count = 0;

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        int ICollection<T>.Count => ((ICollection<T>)ts).Count;

        public void Add(T item)
        {
            if (ts.Length == Count)
            {
                DoubleSize();
            }
            ts[Count] = item;
            Count++;

        }

        public void Clear()
        {
            ts = new T[Count];
            Count = 0;
        }

        public bool Contains(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (ts[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (var i = 0; i < Count; i++)
            {
                array[i + arrayIndex] = ts[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var index = 0;
            while (index < Count)
            {
                yield return ts[index];
                index++;
            }
        }

        public int IndexOf(T item)
        {
            for (var i=0; i < Count; i++)
            {
                if (ts[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (Count == ts.Length)
            {
                DoubleSize();
            }
            for (var i = Count; i > index; i--)
            {
                ts[i] = ts[i - 1];
            }
            ts[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            for (var i = index; i < Count; i++)
            {
                ts[i] = ts[i + 1];
            }
            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void DoubleSize()
        {
            var tempArray = ts;
            ts = new T[tempArray.Length * 2];
            for (var i = 0; i < tempArray.Length; i++)
            {
                ts[i] = tempArray[i];
            }
        }
    }
}
