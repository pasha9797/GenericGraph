using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphLib
{
    public partial class Graph<V, E>
    {
        public void WalkDeep(int n, ReDrawDelegate reDrawMethod) //Обход в глубину
        {
            if (n < 0 || n >= Count())
                throw new ApplicationException("Start vertex index is out of range");

            ResetVisit();
            ResetInTree();
            Stack<int> stack = new Stack<int>();
            stack.Push(n);
            vList[n].Visit = true;
            UpdateWithSleep(reDrawMethod);
            while (stack.Count > 0)
            {
                n = stack.First();
                int i = 0;
                int m = -1;
                while (i < vList[n].Edges.Count())
                {
                    m = NumNode(vList[n], vList[n].Edges[i]);
                    if (!vList[m].Visit)
                    {
                        stack.Push(m);
                        vList[m].Visit = true;
                        UpdateWithSleep(reDrawMethod);
                        break;
                    }
                    i++;
                }
                if (i == vList[n].Edges.Count())
                {
                    stack.Pop();
                    UpdateWithSleep(reDrawMethod);
                }
            }
            UpdateWithSleep(reDrawMethod);
        }
        public void WalkWide(int n, ReDrawDelegate reDrawMethod) //Обход в ширину
        {
            if (n < 0 || n >= Count())
                throw new ApplicationException("Start vertex index is out of range");

            ResetVisit();
            ResetInTree();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            vList[n].Visit = true;
            UpdateWithSleep(reDrawMethod);
            while (queue.Count > 0)
            {
                n = queue.Dequeue();
                UpdateWithSleep(reDrawMethod);
                for (int i = 0; i < vList[n].Edges.Count; i++)
                {
                    int m = NumNode(vList[n], vList[n].Edges[i]);
                    if (!vList[m].Visit)
                    {
                        queue.Enqueue(m);
                        vList[m].Visit = true;
                        UpdateWithSleep(reDrawMethod);
                    }
                }
            }
            UpdateWithSleep(reDrawMethod);
        }
        private void UpdateWithSleep(ReDrawDelegate reDrawMethod)
        {
            Thread.Sleep(600);
            reDrawMethod?.Invoke();
        }
        public int Dijkstr(int beg, int end, Evaluator<E> weight, ref List<int> path)
        {
            if (beg < 0)
                throw new ApplicationException("Start vertex index is out of range");
            else if (end >= Count())
                throw new ApplicationException("End vertex index is out of range");

            ResetVisit();
            ResetInTree();
            vList[beg].Distance = 0;
            vList[beg].Path = new List<int> { beg };
            for (int i = 0; i < Count(); i++)
                if(i!=beg) vList[i].Distance = Int32.MaxValue;

            List<Vertex> sortedList=new List<Vertex>();
            foreach(Vertex ver in vList)
                sortedList.Add(ver);

            while(vList.Find(a=>a.Visit==false) != null)
            {
                sortedList.Sort((a, b) => a.Distance - b.Distance);
                Vertex minVer = sortedList.Find(a => a.Visit == false);
                foreach(Edge edge in minVer.Edges)
                {
                    Vertex neibour = vList[NumNode(minVer, edge)];
                    if (neibour.Visit == false && neibour.Distance > minVer.Distance + weight(edge.Inf))
                    {
                        neibour.Distance = minVer.Distance + weight(edge.Inf);
                        neibour.Path = new List<int>(minVer.Path);
                        neibour.Path.Add(vList.IndexOf(neibour));
                    }
                }
                minVer.Visit = true;
            }

            path = vList[end].Path;
            VisualizePath(path);
            return vList[end].Distance;
        }
        private void VisualizePath(List<int> path)
        {
            for(int i=0;i<vList.Count;i++)
            {
                if (i<0 || i>=Count())
                    throw new ApplicationException("Vertex index is out of range");

                if (path.IndexOf(i) == -1)
                    vList[i].Visit = false;
                else vList[i].Visit = true;
            }
        }
        public void Kruscall(Evaluator<E> weight)
        {
            ResetVisit();
            ResetInTree();
            List<Edge> MST = new List<Edge>();
            List<Edge> MyEdges = GetAllEdges();
            List<HashSet<Vertex>> SetList = new List<HashSet<Vertex>>();
            MyEdges.Sort((a, b) => { return weight(a.Inf) - weight(b.Inf); });
            for (int i = 0; i < vList.Count; i++)
            {
                SetList.Add(new HashSet<Vertex>());
                SetList[i].Add(vList[i]);
            }
            foreach (Edge edge in MyEdges)
            {
                int component1 = GetComponent(edge.Start, SetList);
                int component2 = GetComponent(edge.End, SetList);
                if (component1 != component2)
                {
                    MST.Add(edge);
                    edge.InTree = true;
                    edge.Start.InTree = true;
                    edge.End.InTree = true;
                    SetList[component1].UnionWith(SetList[component2]);
                    SetList[component2].Clear();
                }
            }
        }
        public int GetComponent(Vertex ver, List<HashSet<Vertex>> setList)
        {
            for (int i = 0; i < setList.Count; i++)
            {
                if (setList[i].Contains(ver))
                    return i;
            }
            return -1;
        }
    }
}
