using System;
namespace Heap
{
    class HeapV2
    {
        int[] arr;
        int size;//Our visual of the BST's size
        int capacity;//The real capacity of the array

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Heap.HeapV2"/> class.
        /// </summary>
        public HeapV2(int cap = 10)
        {
            if (cap <= 0) throw new Exception("Cannot initialize heap with cap 0 or less");
            arr = new int[cap];
            size = 0;
            capacity = cap;
        }

        /// <summary>
        /// Peek the highest value in the heap, the root.
        /// </summary>
        public int Peek(){
            if (size == 0) throw new Exception("Size of array equal to 0. Capacity is not 0. Check variable 'size'. Cannot peek from empty.");
            return arr[0];
        }

        /// <summary>
        /// Pops the max, and adjust heap to maintain Max-Heap property.
        /// </summary>
        public int Pop(){
            if (size == 0) throw new Exception("Size of array equal to 0. Capacity is not 0. Check variable 'size'. Cannot pop from empty.");
            var max = arr[0];
            Swap(0, size);//Swap last element with first
            size--;//To ignore the past-largest element
            var index = 0;
            while (GotLeftChild(index)){
                var biggestValIndex = GetLeftChildIndex(index);
                if (GotRightChild(index) && GetRightChildValue(index) > GetLeftChildValue(index)) {
                    biggestValIndex = GetRightChildIndex(index);
                }
                if (arr[index] < arr[biggestValIndex])
                {
                    Swap(index, biggestValIndex);
                    index = biggestValIndex;
                }
                else break;
            }
            return max;
        }

        /// <summary>
        /// Swap the specified index1 and index2.
        /// </summary>
        public void Swap(int index1, int index2){
            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        /// <summary>
        /// Multiplies the capacity of an array by a multiplier, default to 2.
        /// </summary>
        public void Expand(int multiplier = 2){
            if (size == capacity){
                Array.Resize(ref arr, capacity * multiplier);
                capacity *= multiplier;
            }
        }

        //For testing only
        public int Length(){
            return arr.Length;
        }

        /// <summary>
        /// Push the specified val, and adjust heap to maintain Max-Heap property.
        /// </summary>
        public void Push(int val){
            var index = size;
            if (size == 0){
                arr[0] = val;
                size++;
            } 
            else{
                Expand();
                arr[index] = val;
                while(GotParent(index) && GetParentValue(index) < val){
                    Swap(GetParentIndex(index), index);
                    index = GetParentIndex(index);
                }
                size++;
            }
        }



        /// <summary>
        /// Check if got parent.
        /// </summary>
        public bool GotParent(int childIndex){
            return (GetParentIndex(childIndex) >= 0 && childIndex != 0);
        }

        /// <summary>
        /// Check if got child by finding if left-child exists
        /// </summary>
        public bool GotLeftChild(int parentIndex)
        {
            return (GetLeftChildIndex(parentIndex) < size);
        }

        /// <summary>
        /// Check if got child by finding if right-child exists
        /// </summary>
        public bool GotRightChild(int parentIndex)
        {
            return (GetRightChildIndex(parentIndex) <= size);
        }



        /// <summary>
        /// Gets the index of the parent from a given child index.
        /// </summary>
        public int GetParentIndex(int childIndex){
            if (childIndex % 2 == 0)// is right-tree
            { 
                return (childIndex - 2) / 2;
            }
            else return (childIndex - 1) / 2;
        }

        /// <summary>
        /// Gets the index of the left-child from a given parent index.
        /// </summary>
        public int GetLeftChildIndex(int parentIndex)
        {
            return (parentIndex * 2 + 1);
        }

        /// <summary>
        /// Gets the index of the right-child from a given parent index.
        /// </summary>
        public int GetRightChildIndex(int parentIndex)
        {
            return (parentIndex * 2 + 2);
        }



        /// <summary>
        /// Gets the parent value from a given child index.
        /// </summary>
        public int GetParentValue(int childIndex){
            return arr[GetParentIndex(childIndex)];
        }

        /// <summary>
        /// Gets the left-child value from a given parent index.
        /// </summary>
        public int GetLeftChildValue(int parentIndex)
        {
            return arr[GetLeftChildIndex(parentIndex)];
        }

        /// <summary>
        /// Gets the right-child value from a given child index.
        /// </summary>
        public int GetRightChildValue(int parentIndex)
        {
            return arr[GetRightChildIndex(parentIndex)];
        }



        //For testing only
        public int[] GetAr(){
            return arr;
        }
    }
}
