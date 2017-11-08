using System;
using System.Collections.Generic;

namespace Heap
{
    public class Heap<T> where T : IComparable
    {
        readonly List<T> list = new List<T>();

        public void Add(T val){
			int lastIndex = list.Count - 1;
            if (lastIndex == -1){
                list.Add(val);
            }else{            
				if (list[lastIndex].CompareTo(val) <= 0){//num is bigger
                    list.Add(val);
                }else if (list[lastIndex].CompareTo(val) > 0){
					var temp = list[lastIndex];
					list[lastIndex] = val;
                    list.Add(temp);
				}
            }
        }

        public T Peek(){
            return list[list.Count - 1];
        }

        public T Pop(){
            var temp = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return temp;
        }

    }
}
