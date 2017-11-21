using System;
using System.Collections.Generic;

namespace Heap
{
    public class Heap<T> where T : IComparable
    {
        readonly List<T> list = new List<T>();

        public void Push(T val){
            Push(val, Count());
        }

        private void Push(T val, int index){
			int lastIndex = index - 1;
            if (index == 0){
                list.Insert(index,val);
            }else{            
				if (list[lastIndex].CompareTo(val) <= 0){//if val is bigger
                    list.Insert(index,val);
                }else if (list[lastIndex].CompareTo(val) > 0){
                    Push(val, index - 1);
				}
            }
        }

        public int Count(){
            return list.Count;
        }

        public T Peek(){
            return list[list.Count - 1];
        }

        public T Pop(){
            var temp = list[Count() - 1];
            list.RemoveAt(Count() - 1);
            return temp;
        }

    }
}
