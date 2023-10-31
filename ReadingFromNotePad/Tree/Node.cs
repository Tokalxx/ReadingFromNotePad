using System.Collections.Generic;

namespace ReadingFromNotePad.Tree
{
    public class Node
    {
        public string Num { get; set; }
        public string Des { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }

        public Node(string num, string des, Node parent)
        {
            Num = num;
            Des = des;
            Children = new List<Node>();
            Parent = parent;
        }

        public void addNode(string data1, string data2)
        {
            Node newNode = new Node(data1, data2, this);
            this.Children.Add(newNode);
        }
        public Node()
        {

        }

        public override string ToString()
        {
            return $"Data: ({Num + Des}), Parent: ({Parent.Num})";
        }
    }
}