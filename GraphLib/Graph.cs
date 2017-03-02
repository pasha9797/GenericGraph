using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public delegate void ReDrawDelegate();
    public delegate int Evaluator<E>(E e);

    public partial class Graph<V, E> : IEnumerable
    {
        private List<Vertex> vList = new List<Vertex>();

        public class Vertex
        {
            public V Inf { get; set; }
            public bool Visit { get; set; }
            public List<Edge> Edges { get; set; }
            public int Distance { get; set; }
            public List<int> Path { get; set; }
            public bool InTree { get; set; }

            public Vertex(V inf)
            {
                Inf = inf;
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
            public bool InTree { get; set; }

            public Edge(E inf)
            {
                Inf = inf;
                InTree = false;
            }
        }

        public void AddVertex(V v)
        {
            if (vList.Find(a => a.Inf.Equals(v)) != null)
                throw new ApplicationException("Vertex already exists in graph");

            vList.Add(new Vertex(v));
        }
        public void AddEdge(E e, V v1, V v2)
        {
            Edge edge = new Edge(e);
            Vertex vertex1 = vList.Find(a => a.Inf.Equals(v1));
            Vertex vertex2 = vList.Find(a => a.Inf.Equals(v2));

            if (vertex1.Edges.Find(a => { return (a.Start == vertex2) || (a.End == vertex2); }) != null)
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
                vList[NumNode(vertex, edge)].Edges.Remove(edge);
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
        public void ResetInTree()
        {
            foreach (Vertex ver in vList)
            {
                ver.InTree = false;
                foreach (Edge edge in ver.Edges)
                    edge.InTree = false;
            }
        }
        public int NumNode(Vertex vertex, Edge edge)
        {
            if (vertex == edge.Start)
                return vList.IndexOf(edge.End);
            else if (vertex == edge.End)
                return vList.IndexOf(edge.Start);
            else
                throw new ApplicationException("This edge is nor related to this vertex");
        }
        public bool IsVertexVisit(V v)
        {
            if (vList.Find(a => a.Inf.Equals(v)) == null)
                throw new ApplicationException("Vertex is not in graph");
            return vList.Find(a => a.Inf.Equals(v)).Visit;
        }
        public bool IsVertexInTree(V v)
        {
            if (vList.Find(a => a.Inf.Equals(v)) == null)
                throw new ApplicationException("Vertex is not in graph");
            return vList.Find(a => a.Inf.Equals(v)).InTree;
        }
        public bool IsEdgeInTree(E e)
        {
            if (GetAllEdges().Find(a => a.Inf.Equals(e)) == null)
                throw new ApplicationException("Edge is not in graph");
            return GetAllEdges().Find(a => a.Inf.Equals(e)).InTree;
        }
        public List<E> GetEdgesOf(V v)
        {
            Vertex vertex = vList.Find(a => a.Inf.Equals(v));
            if (vertex == null)
                throw new ApplicationException("Vertex is not in graph");

            List<E> eList = new List<E>();
            foreach (Edge edge in vertex.Edges)
                eList.Add(edge.Inf);
            return eList;
        }
        private List<Edge> GetAllEdges()
        {
            List<Edge> list = new List<Edge>();
            foreach (Vertex node in vList)
            {
                foreach (Edge edge in node.Edges)
                {
                    if (list.IndexOf(edge) == -1)
                        list.Add(edge);
                }
            }
            return list;
        }
        public int Count()
        {
            return vList.Count;
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
            foreach (Vertex vertex in vList)
            {
                newVList.Add(vertex.Inf);
            }
            return newVList.GetEnumerator();
        }
    }
}
