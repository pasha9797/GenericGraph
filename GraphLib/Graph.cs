using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public partial class Graph<V, E>:IEnumerable
    {
        private List<Vertex> vList=new List<Vertex>();
        private int[,] aMatrix;  // матрица смежности
        private int numCounter = 0;
        private Stack<int> pathStack;

        public class Vertex
        {
            public V Inf { get; set; }
            public string Name { get; set; }
            public bool Visit { get; set; }
            public List<Edge> Edges { get; set; }
            public int NumVisit { get; set; }
            public int Dist { get; set; }
            public int OldDist { get; set; }
            public bool InTree { get; set; }

            public Vertex(V inf, string name)
            {
                Inf = inf;
                Name = name;
                Visit = false;
                Edges = new List<Edge>();
                InTree = false;
            }
        }
        public class Edge
        {
            public E Inf { get; set; }
            public Vertex Start { get; set; }
            public Vertex End { get; set; }
            public int Weight { get; set; }
            public bool InTree { get; set; }

            public Edge(E inf, int Weight)
            {
                Inf = inf;
                InTree = false;
            }
        }

        public void AddVertex(V v, string name)
        {
            if (vList.Find(a => a.Inf.Equals(v)) != null)
                throw new ApplicationException("Vertex already exists in graph");

            vList.Add(new Vertex(v, name));
        }
        public void AddEdge(E e, int weight, V v1, V v2)
        {
            Edge edge = new Edge(e, weight);
            Vertex vertex1 = vList.Find(a => a.Inf.Equals(v1));
            Vertex vertex2 = vList.Find(a => a.Inf.Equals(v2));

            if(vertex1.Edges.Find(a=> { return (a.Start == vertex2) || (a.End == vertex2); })!=null)
                throw new ApplicationException("Connection between these two vertexes already exists");

            vertex1.Edges.Add(edge);
            vertex2.Edges.Add(edge);
            edge.Start = vertex1;
            edge.End = vertex2;
        }
        public void RemoveVertex(V v)
        {
            Vertex vertex = vList.Find(a => a.Inf.Equals(v));
            foreach (Edge edge in vertex.Edges)
            {
                vList[NumNode(vertex, edge)].Edges.Remove(edge);
            }
            vList.Remove(vertex);
        }
        public void RemoveEdge(E e)
        {
            foreach (Vertex ver in vList)
            {
                if (ver.Edges.Find(a => a.Inf.Equals(e)) != null)
                    ver.Edges.Remove(ver.Edges.Find(a => a.Inf.Equals(e)));
            }
        }
        public void ResetVisit()
        {
            foreach (Vertex ver in vList)
            {
                ver.Visit = false;
            }
        }
        public int NumNode(Vertex vertex, Edge edge)
        {
            if (vertex == edge.Start)
                return vList.IndexOf(edge.End);
            else if (vertex == edge.End)
                return vList.IndexOf(edge.Start);
            return -1;
        }
        public List<E> GetEdgesOf(V v)
        {
            Vertex vertex = vList.Find(a => a.Inf.Equals(v));
            List<E> eList = new List<E>();
            foreach (Edge edge in vertex.Edges)
                eList.Add(edge.Inf);
            return eList;
        }

        public V this[int index]
        {
            get
            {
                return vList[index].Inf;
            }
            set
            {
                vList[index].Inf = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            List<V> newVList = new List<V>();
            foreach(Vertex vertex in vList)
            {
                newVList.Add(vertex.Inf);
            }
            return newVList.GetEnumerator();
        }
    }
}
