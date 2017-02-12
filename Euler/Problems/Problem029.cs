﻿using System;
using System.Numerics;

namespace Euler.Problems
{
    /// <summary>
    /// 
    ///     Consider all integer combinations of a^b for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:
    ///     
    ///     2^2=4,  2^3=8,   2^4=16,  2^5=32
    ///     3^2=9,  3^3=27,  3^4=81,  3^5=243
    ///     4^2=16, 4^3=64,  4^4=256, 4^5=1024
    ///     5^2=25, 5^3=125, 5^4=625, 5^5=3125
    /// 
    ///     If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:
    ///     
    ///     4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125
    ///     
    ///     How many distinct terms are in the sequence generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?
    ///     
    /// </summary>
    public class Problem029 : Problem
    {
        public override void Calculate()
        {
            int maxValue = 100;
            int minValue = 2;
            BinarySearchTree bst = new BinarySearchTree();
            for (int a = minValue; a <= maxValue; a++)
            {
                for(int b = minValue; b <= maxValue; b++)
                {
                    bst.Add(BigInteger.Pow(new BigInteger(a), b));
                }
            }
            //bst.Print();//Uhhh, this doesnt really work with those huge bigintegers xD Can be used to test if the code works on smaller examples, like maxvalue = 5;
            Print(string.Format("Result = {0}",bst.Count()));
        }
    }

    /// <summary>
    /// Binary Search Tree, with a BigInteger as value in the nodes
    /// </summary>
    public class BinarySearchTree
    {
        public BSTNode root { private set; get; }
        public bool Add(BigInteger value)
        {
            if (root == null)
            {
                root = new BSTNode(value);
                return true;
            }
            else
                return root.Add(value);
        }
        public void Print()
        {
            root.Print();
        }

        public int Count()
        {
            return root.Count();
        }
    }

    /// <summary>
    /// BST Node, with a single BigInteger value
    /// </summary>
    public class BSTNode
    {
        private BigInteger value { set; get; }
        private BSTNode left;
        private BSTNode right;

        public BSTNode(BigInteger value)
        {
            this.value = value;
        }

        public bool Add(BigInteger value)
        {
            if (value == this.value) { 
                return false; //This line makes sure we wont get duplicates!
            }
            else if (value < this.value)
            {
                if (left == null)
                {
                    left = new BSTNode(value);
                    return true;
                }
                else
                    return left.Add(value);
            }
            else if (value > this.value)
            {
                if (right == null)
                {
                    right = new BSTNode(value);
                    return true;
                }
                else
                    return right.Add(value);
            }
            return false;
        }

        /// <summary>
        /// Method to easily count the value of this node and its children
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            int result = 1;
            if (left != null) result += left.Count();
            if (right != null) result += right.Count();
            return result;
        }

        internal void Print()
        {
            if (left != null) left.Print();
            Console.WriteLine(string.Format("{0} ", value.ToString()));
            if (right != null) right.Print();
        }
    }
}