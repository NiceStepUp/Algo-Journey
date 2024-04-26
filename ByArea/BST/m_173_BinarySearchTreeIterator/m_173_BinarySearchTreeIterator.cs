using ByArea.BST.m_230_KthSmallestElementInABST;

namespace ByArea.BST.m_173_BinarySearchTreeIterator;

/*
 https://leetcode.com/problems/binary-search-tree-iterator/
173. Binary Search Tree Iterator
Implement the BSTIterator class that represents an iterator over the in-order traversal of a binary search tree (BST):

BSTIterator(TreeNode root) Initializes an object of the BSTIterator class. The root of the BST is given as part of the constructor. The pointer should be initialized to a non-existent number smaller than any element in the BST.
boolean hasNext() Returns true if there exists a number in the traversal to the right of the pointer, otherwise returns false.
int next() Moves the pointer to the right, then returns the number at the pointer.
Notice that by initializing the pointer to a non-existent smallest number, the first call to next() will return the smallest element in the BST.

You may assume that next() calls will always be valid. That is, there will be at least a next number in the in-order traversal when next() is called.

Example 1:

                    7
                   / \
                  3   15
                     /  \
                    9   20

Input
["BSTIterator", "next", "next", "hasNext", "next", "hasNext", "next", "hasNext", "next", "hasNext"]
[[[7, 3, 15, null, null, 9, 20]], [], [], [], [], [], [], [], [], []]
Output
[null, 3, 7, true, 9, true, 15, true, 20, false]

Explanation
BSTIterator bSTIterator = new BSTIterator([7, 3, 15, null, null, 9, 20]);
bSTIterator.next();    // return 3
bSTIterator.next();    // return 7
bSTIterator.hasNext(); // return True
bSTIterator.next();    // return 9
bSTIterator.hasNext(); // return True
bSTIterator.next();    // return 15
bSTIterator.hasNext(); // return True
bSTIterator.next();    // return 20
bSTIterator.hasNext(); // return False
 

Constraints:

The number of nodes in the tree is in the range [1, 105].
0 <= Node.val <= 106
At most 105 calls will be made to hasNext, and next.
 

Follow up:

Could you implement next() and hasNext() to run in average O(1) time and use O(h) memory, where h is the height of the tree?
 */
internal class m_173_BinarySearchTreeIterator
{
    
}


/*
I solved this task by myseelf! :)
Runtime 143 ms Beats 65.81% of users with C#
Memory 62.32 MB Beats 66.58% of users with C#
 */
public class BSTIterator
{
    List<int> _bstValues;
    int _iteratorIndex = 0;

    public BSTIterator(TreeNode root)
    {
        _bstValues = new List<int>();
        TraverseByInOrder(root);
    }

    public int Next()
    {
        if (_bstValues != null
            && _bstValues.Count > 0) 
        {
            int number = _bstValues[_iteratorIndex];
            _iteratorIndex++;
            return number;
        }

        if (_bstValues != null
            && _iteratorIndex < _bstValues.Count) 
        {
            int number = _bstValues[_iteratorIndex];
            _iteratorIndex++;
            return number;
        }

        return int.MinValue;
    }

    public bool HasNext()
    {
        if (_bstValues != null
             && _iteratorIndex < _bstValues.Count)
        {
            return true;
        }

        return false;
    }

    private void TraverseByInOrder(TreeNode root)
    {
        if (root == null)
            return;

        if (root.left != null) 
        {
            TraverseByInOrder(root.left);
        }

        _bstValues.Add(root.val);

        if (root.right != null)
        {
            TraverseByInOrder(root.right);
        }
    }
}


public class m_173_BinarySearchTreeIterator_BootStrapper
{
    public void Run()
    {
        TreeNode tree_9 = new TreeNode { val = 9 };
        TreeNode tree_20 = new TreeNode { val = 20 };
        TreeNode tree_15 = new TreeNode { val = 15, left = tree_9, right = tree_20 };
                
        TreeNode tree_3 = new TreeNode { val = 3 };
        TreeNode tree_7 = new TreeNode { val = 7, left = tree_3, right = tree_15 };

        BSTIterator bstIterator = new BSTIterator(tree_7);
        Console.WriteLine(bstIterator.Next());    // return 3
        Console.WriteLine(bstIterator.Next());    // return 7
        Console.WriteLine(bstIterator.HasNext()); // return True
        Console.WriteLine(bstIterator.Next());    // return 9
        Console.WriteLine(bstIterator.HasNext()); // return True
        Console.WriteLine(bstIterator.Next());    // return 15
        Console.WriteLine(bstIterator.HasNext()); // return True
        Console.WriteLine(bstIterator.Next());    // return 20
        Console.WriteLine(bstIterator.HasNext()); // return False

    }
}

