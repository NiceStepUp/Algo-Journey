using System.Text;

namespace ByArea.BST;

/*
 A Binary Search Tree is a data structure used in computer science for organizing and storing data in a sorted manner. 
Each node in a Binary Search Tree has at most two children, a left child and a right child, with the left child containing values less than 
the parent node and the right child containing values greater than the parent node. 
This hierarchical structure allows for efficient searching, insertion, and deletion operations on the data stored in the tree.

                4
               / \
              3   10
             /\     \
            1  6     14
              / \    /
             4   7  13 


 */


public class TreeNode<T>
{
    public T val { get; set; }

    public TreeNode<T> left { get; set; }

    public TreeNode<T> right { get; set; }

    public override string ToString() =>
        @$"Value is: {val?.ToString()}, Left: {(left == null ? "" : left.val)}, Right: {(right == null ? "" : right.val)}";
}

public class TreeNode
{
    public int val { get; set; }

    public TreeNode left { get; set; }

    public TreeNode right { get; set; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(@$"Value is: {val}");

        if (left != null)
        {
            stringBuilder.Append(@$", Left is: {left.val}");
        }

        if (right != null)
        {
            stringBuilder.Append(@$", Right is: {right.val}");
        }

        return stringBuilder.ToString();
    }
        

    public TreeNode()
    {
        
    }

    public TreeNode(int value)
    {
        val = value;
    }
}
