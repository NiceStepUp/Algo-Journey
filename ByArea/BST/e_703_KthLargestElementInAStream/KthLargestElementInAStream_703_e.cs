namespace ByArea.BST.KthLargestElementInAStream_703_e;

/*
https://leetcode.com/problems/kth-largest-element-in-a-stream/description/

Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.

Implement KthLargest class:

KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.
 

Example 1:

Input
["KthLargest", "add", "add", "add", "add", "add"]
[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
Output
[null, 4, 5, 5, 8, 8]

Explanation
KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
kthLargest.add(3);   // return 4
kthLargest.add(5);   // return 5
kthLargest.add(10);  // return 5
kthLargest.add(9);   // return 8
kthLargest.add(4);   // return 8
 

Constraints:

1 <= k <= 104
0 <= nums.length <= 104
-104 <= nums[i] <= 104
-104 <= val <= 104
At most 104 calls will be made to add.
It is guaranteed that there will be at least k elements in the array when you search for the kth element.


Runtime 145 ms Beats 61.95% of users with C#
Memory 65.25 MB Beats 31.55% of users with C#
 */

/*                              Task explanation
 TLDR
Find a way to receive a large amount of numbers, and at any point you receive another, return the Kth largest number you have received so far. (Kth - as in 1st, 2nd, 3rd, 4th.. Kth).

In Depth
Design a class that can receive a large amount of numbers and, at any given time, receive a new number and return the Kth largest number. (Kth - as in 1st, 2nd, 3rd, 4th, 5th, 6th ... Kth). Notice that K is constant and does not change during the problem.

The class you design will be constructed using a K and initial array of numbers. Lets analyze the problem's example:

Input
["KthLargest", "add", "add", "add", "add", "add"]
[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]

A bit confusing, but all it means is the class is constructed with
K = 3
Initial Input = [4, 5, 8 ,2]
And the add method is called 5 times with the numbers: 3, 5, 10, 9, 4

At each time the add method is called, it is required to return the Kth (by the example the 3rd cause K = 3) largest number the class has received until now (including the newly received number).

Finally, lets go through one add example:
The class is constructed with K = 3 , and initial numbers [4, 5, 8, 2].
At this point (even though we're not asked) the Kth (3rd) largest number is 4.
After the calling add(3) the numbers received so far are [4, 5, 8, 2, 3] and the Kth (3rd) largest number is still 4. Thus, 4 should be returned.

Afterwards, it just repeats itself on consecutive add calls.
 */
internal class KthLargestElementInAStream_703_e
{
    public void Run()
    {
        int kth = 3;
        int[] nums = [4, 5, 8, 2];
        KthLargest kthLargest = new KthLargest(kth, nums);

        int kthLargestElement = int.MinValue;
        kthLargestElement = kthLargest.Add(3);
        kthLargestElement = kthLargest.Add(5);   // return 5
        kthLargestElement = kthLargest.Add(10);  // return 5
        kthLargestElement = kthLargest.Add(9);   // return 8
        kthLargestElement = kthLargest.Add(4);   // return 8
    }
}

public class KthLargest
{
    PriorityQueue<int, int> _priorityQueue = new (new Comparer());
    private int _k;

    public KthLargest(int k, int[] nums)
    {
        _k = k;

        for (int i = 0; i < nums.Length; i++) 
        {
            _priorityQueue.Enqueue(nums[i], nums[i]);
        }

        while(_priorityQueue.Count > _k)
        {
            _priorityQueue.Dequeue();
        }
    }

    public int Add(int val)
    {
        _priorityQueue.Enqueue(val, val);
        if (_priorityQueue.Count > _k)
        {
            _priorityQueue.Dequeue();
        }

        return _priorityQueue.Peek();
    }

    public class Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y)
                return 0;
            else if (x > y)
                return 1;
            else
                return -1;
        }
    }
}

public class KthLargestElementInAStream_703_e_Bootstrapper
{
    public void Run()
    {
        new KthLargestElementInAStream_703_e().Run();
    }
}
