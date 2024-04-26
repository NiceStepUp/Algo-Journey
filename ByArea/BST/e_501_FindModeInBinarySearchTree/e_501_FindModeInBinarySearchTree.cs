namespace ByArea.BST.e_501_FindModeInBinarySearchTree;

/*
Given the root of a binary search tree (BST) with duplicates, return all the mode(s) (i.e., the most frequently occurred element) in it.

If the tree has more than one mode, return them in any order.

Assume a BST is defined as follows:

The left subtree of a node contains only nodes with keys less than or equal to the node's key.
The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
Both the left and right subtrees must also be binary search trees.
 

Example 1:


Input: root = [1,null,2,2]
Output: [2]
Example 2:

Input: root = [0]
Output: [0]
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
-105 <= Node.val <= 105




                                                Explanation
Q:
    Can any one explain the question please?
    
A:
    You have to return maximum occurrence number in the tree, if there are more than one numbers which have same 
    maximum occurrence than you have to return all those numbers in form vector.
 
Runtime 118ms Beats 75.84% of users with C#
Memory 51.35 MB Beats 30.20% of users with C#
 */
internal class e_501_FindModeInBinarySearchTree
{
    public int[] FindMode(TreeNode root)
    {
        Dictionary<int, int> countByKey = new Dictionary<int, int>();
        TraverseTree(root, countByKey);

        int mode = 0;
        foreach (var i in countByKey)
        {
            if (countByKey[i.Key] >= mode)
                mode = countByKey[i.Key];
        }

        IOrderedEnumerable<KeyValuePair<int, int>> result = countByKey.OrderByDescending(x => x.Value);
        mode = result.First().Value;
        List<int> modes = new List<int>();
        foreach (KeyValuePair<int, int> i in countByKey)
        {
            if (i.Value == mode)
            {
                modes.Add(i.Key);
            }
        }

        return modes.ToArray();
    }

    private void TraverseTree(TreeNode root, Dictionary<int, int> countByKey)
    {
        if (root == null)
            return;

        if (root.left != null)
        {
            TraverseTree(root.left, countByKey);
        }

        if (countByKey.ContainsKey(root.val))
        {
            countByKey[root.val]++;
        }
        else
        {
            countByKey.Add(root.val, 1);
        }

        if (root.right != null)
        {
            TraverseTree(root.right, countByKey);
        }
    }
}
