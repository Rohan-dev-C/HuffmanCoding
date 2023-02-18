using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace HuffmanCoding
{
    public class Node
    {
        public Node leftChild;
        public Node rightChild;
        public Node() { }
        public Node(char x) { letter = x; }
        public char letter;

    }

    public class Huffman
    {
        public Node root;
        public Dictionary<char, string> binaryValues = new Dictionary<char, string>();
        public Dictionary<string, char> reverseMap = new Dictionary<string, char>();
        public Huffman(string text)
        {
            CreateTree(text);
        }
        public string Encodetree(string text)
        {
            string binary = "";
            charBinary(root, "");
            foreach (char c in text)
            {
                binary += binaryValues[c]; //A -> 1101

            }
            return binary;
        }
        public void CreateTree(string text)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            PriorityQueue<Node, int> queue = new PriorityQueue<Node, int>();

            foreach (char c in text)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }
            foreach (var item in dict)
            {
                queue.Enqueue(new Node(item.Key), item.Value);
            }
            while (queue.Count > 1)
            {
                Node temp1 = queue.Dequeue();
                Node temp2 = queue.Dequeue();

                Node node = new Node('\0');
                node.rightChild = temp2;
                node.leftChild = temp1;
                queue.Enqueue(node, node.letter);
            }
            root = queue.Dequeue();
        }
        public void charBinary(Node node, string sequence)
        {
            if (node.rightChild == null && node.leftChild == null)
            {
                binaryValues.Add(node.letter, sequence);
            }
            else
            {
                charBinary(node.leftChild, sequence + "0");
                charBinary(node.rightChild, sequence + "1");
            }
        }

        public List<byte> binaryToByte(string binary)
        {
            List<int> temp = new List<int>() { 1, 2, 3, 4, 5 };
            foreach (var item in binaryValues)
            {
                reverseMap.Add(item.Value, item.Key);
            }

            List<byte> list = new List<byte>();




            return list; 
        }
    }
}
