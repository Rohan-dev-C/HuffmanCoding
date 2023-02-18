namespace HuffmanCoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Huffman huffman = new Huffman("happy");
            huffman.Encodetree("happy");

            var x = huffman.binaryValues;
        }
    }
}