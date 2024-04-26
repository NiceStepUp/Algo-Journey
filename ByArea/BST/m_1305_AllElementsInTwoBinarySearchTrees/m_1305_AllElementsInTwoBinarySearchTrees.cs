namespace ByArea.BST.m_1305_AllElementsInTwoBinarySearchTrees;

/*
https://leetcode.com/problems/all-elements-in-two-binary-search-trees/description/

Given two binary search trees root1 and root2, return a list containing all the integers from both trees sorted in ascending order.

 

Example 1:
                        2
                      /   \
                     1     4

                        1
                      /   \
                     0     3                   


Input: root1 = [2,1,4], root2 = [1,0,3]
Output: [0,1,1,2,3,4]


Example 2:

    1
     \
      8                   

       8
      /
     1

Input: root1 = [1,null,8], root2 = [8,1]
Output: [1,1,8,8]
 

Constraints:

The number of nodes in each tree is in the range [0, 5000].
-105 <= Node.val <= 105


I solved this medium task by myself
Runtime 349 msBeats 6.00% of users with C#
Memory 87.93 MB Beats 50.00% of users with C# 
 */
internal class m_1305_AllElementsInTwoBinarySearchTrees
{
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        List<int> numbers = new List<int>();
        TraverseTreeByInOrder(root1, numbers);
        TraverseTreeByInOrder(root2, numbers);

        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(new IntComparator());
        foreach (int i in numbers) 
        {
            priorityQueue.Enqueue(i, i);
        }

        numbers.Clear();
        while (priorityQueue.Count > 0)
        {
            numbers.Add(priorityQueue.Dequeue());
        }

        return numbers;
        
    }

    private void TraverseTreeByInOrder(TreeNode root, List<int> numbers)
    {
        if (root == null)
        {  
            return; 
        }

        if (root.left != null)
        {
            TraverseTreeByInOrder(root.left, numbers);
        }

        numbers.Add(root.val);

        if (root.right != null)
        {
            TraverseTreeByInOrder(root.right, numbers);
        }
    }

    // IComparer<TPriority>
    class IntComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x == y) 
                return 0;
            if (x > y)
                return 1;
            return -1;
        }
    }
}


public class m_1305_AllElementsInTwoBinarySearchTrees_Bootstrapper
{
    public void Run()
    {
        TreeNode tree_4 = new TreeNode() { val = 4 };
        TreeNode tree_1 = new TreeNode() { val = 1 };        
        TreeNode tree_2 = new TreeNode() { val = 2, left = tree_1, right = tree_4 };

        TreeNode tree_0 = new TreeNode() { val = 0 };        
        TreeNode tree_3 = new TreeNode() { val = 3 };
        TreeNode tree_One = new TreeNode() { val = 1, left = tree_0, right = tree_3 };


        new m_1305_AllElementsInTwoBinarySearchTrees().GetAllElements(tree_2, tree_One);
    }
}