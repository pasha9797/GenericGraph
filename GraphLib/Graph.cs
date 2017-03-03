using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public partial class Graph<V, E> : IEnumerable<V> //класс графа и главные методы
    {
        private List<Vertex> vList = new List<Vertex>(); //список вершин

        public class Vertex //класс вершины
        {
            public V Inf { get; set; } //соответствующий объект типа V
            public List<Edge> Edges { get; set; } //список рёбер

            public bool Visit { get; set; } //метка посещённости для алгоритмов на графе           
            public int Distance { get; set; } //метка дистанции для алгоритма дейкстры
            public List<int> Path { get; set; } //путь к вершина для алгоритма дейкстры
            public bool InTree { get; set; } //метка для построения остовного дерева

            public Vertex(V inf)
            {
                Inf = inf;
                Visit = false;
                Edges = new List<Edge>();
                InTree = false;
            }
        }

        public class Edge //класс ребра
        {
            public E Inf { get; set; } //соответствующий объект типа E
            public Vertex Start { get; set; } //начальная вершина
            public Vertex End { get; set; } //конечная вершина

            public bool InTree { get; set; } //метка для построения остовного дерева

            public Edge(E inf)
            {
                Inf = inf;
                InTree = false;
            }
        }

        public void AddVertex(V v) //добавление новой вершины
        {
            if (vList.Find(a => a.Inf.Equals(v)) != null)
                throw new ApplicationException("Vertex already exists in graph");

            vList.Add(new Vertex(v));
        }

        public void AddEdge(E e, V v1, V v2) //добавление нового ребра связывающего v1 и v2
        {
            Edge edge = new Edge(e);
            Vertex vertex1 = vList.Find(a => a.Inf.Equals(v1));
            Vertex vertex2 = vList.Find(a => a.Inf.Equals(v2));

            if (vertex1 == null || vertex2 == null)
                throw new ApplicationException("One of vertexes is not in graph");
            else if (vertex1.Edges.Find(a => { return (a.Start == vertex2) || (a.End == vertex2); }) != null)
                    throw new ApplicationException("Connection between these two vertexes already exists");

            vertex1.Edges.Add(edge);
            vertex2.Edges.Add(edge);
            edge.Start = vertex1;
            edge.End = vertex2;
        }

        public void RemoveVertex(V v) //удаление вершины
        {
            Vertex vertex = vList.Find(a => a.Inf.Equals(v));
            if (vertex == null)
            {
                throw new ApplicationException("Vertex is not in graph");
            }
            foreach (Edge edge in vertex.Edges)
            {
                vList[NumNode(vertex, edge)].Edges.Remove(edge);
            }
            vList.Remove(vertex);
        }

        public void RemoveEdge(E e) //удаление ребра
        {
            if(GetAllEdges().Find(a=>a.Inf.Equals(e))==null)
                throw new ApplicationException("Edge is not in graph");

            foreach (Vertex ver in vList)
            {
                if (ver.Edges.Find(a => a.Inf.Equals(e)) != null)
                    ver.Edges.Remove(ver.Edges.Find(a => a.Inf.Equals(e)));
            }
        }

        public void ResetVisit() //очистить метки посещения
        {
            foreach (Vertex ver in vList)
                ver.Visit = false;
        }

        public void ResetInTree() //очистить метки нахождения в остовном дереве
        {
            foreach (Vertex ver in vList)
            {
                ver.InTree = false;
                foreach (Edge edge in ver.Edges)
                    edge.InTree = false;
            }
        }

        public int NumNode(Vertex vertex, Edge edge) //По данной вершине и примыкающему ребру найти вторую вершину
        {
            if (vertex == edge.Start)
                return vList.IndexOf(edge.End);
            else if (vertex == edge.End)
                return vList.IndexOf(edge.Start);
            else
                throw new ApplicationException("This edge is nor related to this vertex");
        }

        public bool IsVertexVisit(V v) //проверка на посещенность
        {
            if (vList.Find(a => a.Inf.Equals(v)) == null)
                throw new ApplicationException("Vertex is not in graph");
            return vList.Find(a => a.Inf.Equals(v)).Visit;
        }

        public bool IsVertexInTree(V v) //проверка на нахождение вершины в остовном дереве
        {
            if (vList.Find(a => a.Inf.Equals(v)) == null)
                throw new ApplicationException("Vertex is not in graph");
            return vList.Find(a => a.Inf.Equals(v)).InTree;
        }
        public bool IsEdgeInTree(E e) //проверка на нахождение ребра в остовном дереве
        {
            if (GetAllEdges().Find(a => a.Inf.Equals(e)) == null)
                throw new ApplicationException("Edge is not in graph");
            return GetAllEdges().Find(a => a.Inf.Equals(e)).InTree;
        }
        public List<E> GetEdgesOf(V v) //получить все примыкающие к вершине ребра
        {
            Vertex vertex = vList.Find(a => a.Inf.Equals(v));
            if (vertex == null)
                throw new ApplicationException("Vertex is not in graph");

            List<E> eList = new List<E>();
            foreach (Edge edge in vertex.Edges)
                eList.Add(edge.Inf);
            return eList;
        }
        private List<Edge> GetAllEdges() //получить список всех рёбер графа
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
        public int Count() //количество вершин графа
        {
            return vList.Count;
        }

        /*Индексатор*/
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

        /*Реализация IEnumerable*/
        public IEnumerator<V> GetEnumerator()
        {
            foreach (Vertex vertex in vList)
                yield return vertex.Inf;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
