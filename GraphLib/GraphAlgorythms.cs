using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLib
{
    public partial class Graph<V, E>
    {
        public void WalkDeep(int n) //Обход в глубину
        {
            //SelectNode = null;
            Stack<int> stack = new Stack<int>();
            stack.Push(n);
            vList[n].Visit = true;
            //UpdateWithSleep(stack);
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
                        //UpdateWithSleep(stack);
                        break;
                    }
                    i++;
                }
                if (i == vList[n].Edges.Count())
                {
                    stack.Pop();
                    //UpdateWithSleep(stack);
                }
            }
            //UpdateWithSleep(stack);
        }
        public void WalkWide(int n) //Обход в ширину
        {
            //SelectNode = null;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            vList[n].Visit = true;
            //UpdateWithSleep(queue);
            while (queue.Count > 0)
            {
                n = queue.Dequeue();
                //UpdateWithSleep(queue);
                for (int i = 0; i < vList[n].Edges.Count; i++)
                {
                    int m = NumNode(vList[n], vList[n].Edges[i]);
                    if (!vList[m].Visit)
                    {
                        queue.Enqueue(m);
                        vList[m].Visit = true;
                        //UpdateWithSleep(queue);
                    }
                }
            }
            //UpdateWithSleep(queue);
        }
        public int Dijkst(int s, int t)
        {
            int result;
            ResetVisit();
            SetMatr();
            // Инициализация
            int N = vList.Count;
            for (int i = 0; i <= N - 1; i++)
                vList[i].Dist = 0xFFFFF;
            vList[s].Dist = 0;
            VisitTrue(s);
            int p = s;
            do
            {
                p = FindMinDist(p);
                // обновление и найти
                VisitTrue(p);       // пометка = false
            }
            while (p != t);
            result = vList[p].Dist;
            PathToStack(s, p);

            return result;
        }
        void SetMatr()
        {
            int N = vList.Count;
            aMatrix = new int[N, N];
            for (int i = 0; i <= N - 1; i++)
                for (int j = 0; j <= N - 1; j++)
                    aMatrix[i, j] = 0xFFFFF; // int.MaxValue; 
            for (int i = 0; i <= N - 1; i++)
            {
                aMatrix[i, i] = 0;
                int LL = 0;
                if (vList[i].Edges != null)
                {
                    LL = vList[i].Edges.Count;
                    for (int j = 0; j <= LL - 1; j++)
                        aMatrix[i, NumNode(vList[i], vList[i].Edges[j])] = vList[i].Edges[j].Weight;
                }
            }
        }
        int FindMinDist(int p)
        {
            int MinDist = 0xFFFFF; // int.MaxValue;
            int result = 0;
            int N = vList.Count;
            for (int i = 0; i <= N - 1; i++)
            {
                if (!vList[i].Visit && (i != p))
                {
                    vList[i].Dist = Math.Min(vList[i].Dist, vList[p].Dist + aMatrix[p, i]);
                    if (vList[i].Dist < MinDist)
                    {
                        MinDist = vList[i].Dist;
                        result = i;
                    }
                }
            }
            return result;
        }
        void VisitTrue(int n)  // отметить посещенный
        {
            vList[n].Visit = true;
            numCounter++;
            vList[n].NumVisit = numCounter;
        }
        void PathToStack(int s, int p)
        {
            pathStack = new Stack<int>();
            int N = vList.Count;
            while (p != s)
            {
                pathStack.Push(p); // положить в стек
                int i = -1; bool Ok = false;
                while ((i < N - 1) & !Ok)
                    Ok = (++i != p) && (vList[p].Dist == vList[i].Dist + aMatrix[i, p]);
                p = i;
            }
        }
        public void Kruscall()
        {
            //DrawTree = true;
            List<Edge> MST = new List<Edge>();
            List<Edge> MyEdges = GetAllEdges();
            List<HashSet<Vertex>> SetList = new List<HashSet<Vertex>>();
            MyEdges.Sort((a, b) => { return a.Weight - b.Weight; });
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
                    //UpdateWithSleep();
                    SetList[component1].UnionWith(SetList[component2]);
                    SetList[component2].Clear();
                }
            }
        }
        public List<Edge> GetAllEdges()
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
        public int GetComponent(Vertex node, List<HashSet<Vertex>> setList)
        {
            for (int i = 0; i < setList.Count; i++)
            {
                if (setList[i].Contains(node))
                    return i;
            }
            return -1;
        }
    }
}
