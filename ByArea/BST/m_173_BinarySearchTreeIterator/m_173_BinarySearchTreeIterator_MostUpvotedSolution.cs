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

/*
https://leetcode.com/problems/binary-search-tree-iterator/solutions/52525/my-solutions-in-3-languages-with-stack/

                My solutions in 3 languages with Stack

I use Stack to store directed left children from root.
When next() be called, I just pop one element and process its right child as new root.
The code is pretty straightforward.

So this can satisfy O(h) memory, hasNext() in O(1) time,
But next() is O(h) time.

I can't find a solution that can satisfy both next() in O(1) time, space in O(h).

Java:
 */
public class BSTIterator_MostUpvotedSolution
{
    private Stack<TreeNode> stack = new Stack<TreeNode>();

    public BSTIterator_MostUpvotedSolution(TreeNode root)
    {
        pushAll(root);
    }

    /** @return whether we have a next smallest number */
    public bool HasNext()
    {
        // return !stack.IsEmpty();
        return !(stack.Count == 0);
    }

    /** @return the next smallest number */
    public int Next()
    {
        TreeNode tmpNode = stack.Pop();
        pushAll(tmpNode.right);
        return tmpNode.val;
    }

    private void pushAll(TreeNode node)
    {
        for (; node != null; stack.Push(node), node = node.left) ;
    }
}


public class m_173_BSTIterator_MostUpvotedSolution_BootStrapper
{
    public void Run()
    {
        TreeNode tree_9 = new TreeNode { val = 9 };
        TreeNode tree_20 = new TreeNode { val = 20 };
        TreeNode tree_15 = new TreeNode { val = 15, left = tree_9, right = tree_20 };
                
        TreeNode tree_3 = new TreeNode { val = 3 };
        TreeNode tree_7 = new TreeNode { val = 7, left = tree_3, right = tree_15 };

        BSTIterator_MostUpvotedSolution bstIterator = new (tree_7);
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

