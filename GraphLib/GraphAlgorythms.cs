using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphLib
{
    public partial class Graph<V, E> //все алгоритмы на графе
    {
        public void WalkDeep(int n, ReDrawDelegate reDrawMethod) //обход в глубину
        {
            if (n < 0 || n >= Count())
                throw new ApplicationException("Start vertex index is out of range");

            ResetVisit();
            ResetInTree();
            Stack<int> stack = new Stack<int>();
            stack.Push(n); //Создается стек и кладется начальная вершина
            vList[n].Visit = true; //Начальная вершина делается посещенной
            UpdateWithSleep(reDrawMethod);
            while (stack.Count > 0) //пока стек не пуст
            {
                n = stack.First(); //смотрим вершину в начале стека и записываем ее номер в n
                int i = 0;
                int m = -1;
                while (i < vList[n].Edges.Count()) //перебираем все рёбра вершины n
                {
                    m = NumNode(vList[n], vList[n].Edges[i]); //в m записываем номер вершину, в которую ведёт данное ребро
                    if (!vList[m].Visit) //если m не посещена
                    {
                        stack.Push(m); //кладём m в стек
                        vList[m].Visit = true; //и делаем ее посещенной
                        UpdateWithSleep(reDrawMethod);
                        break;
                    }
                    i++;
                }
                if (i == vList[n].Edges.Count()) //если не оказалось непосещенных соседей вершины n
                {
                    stack.Pop(); //забираем верхний элемент стека (там вершина n)
                    UpdateWithSleep(reDrawMethod);
                }
            }
            UpdateWithSleep(reDrawMethod);
        }
        public void WalkWide(int n, ReDrawDelegate reDrawMethod) //обход в ширину
        {
            if (n < 0 || n >= Count())
                throw new ApplicationException("Start vertex index is out of range");

            ResetVisit();
            ResetInTree();
            Queue<int> queue = new Queue<int>(); //создаем очередь и кладем в нее начальную вершину
            queue.Enqueue(n);
            vList[n].Visit = true; //делаем ее посещенной
            UpdateWithSleep(reDrawMethod);
            while (queue.Count > 0) //пока очередь не пуста
            {
                n = queue.Dequeue(); //забираем первый элемент очереди и его номер записываем в n
                UpdateWithSleep(reDrawMethod);
                for (int i = 0; i < vList[n].Edges.Count; i++)//перебираем все ребра этого элемента
                {
                    int m = NumNode(vList[n], vList[n].Edges[i]); //в m записываем номер вершину, в которую ведёт данное ребро
                    if (!vList[m].Visit)//если вершина m не посещена
                    {
                        queue.Enqueue(m);//кладём её в очередь
                        vList[m].Visit = true;//делаем ее посещенной
                        UpdateWithSleep(reDrawMethod);
                    }
                }
            }
            UpdateWithSleep(reDrawMethod);
        }
        private void UpdateWithSleep(ReDrawDelegate reDrawMethod) //перерисовка экрана с задержкой через делегат
        {
            Thread.Sleep(500); //задержка
            reDrawMethod?.Invoke(); //вызов перерисовки
        }
        public int Dijkstr(int beg, int end, Evaluator<E> weight, ref List<int> path) //дейкстры - минимальный путь
        {
            if (beg < 0 || beg>=Count())
                throw new ApplicationException("Start vertex index is out of range");
            else if (end<0 || end >= Count())
                throw new ApplicationException("End vertex index is out of range");

            ResetVisit();
            ResetInTree();
            vList[beg].Distance = 0; //начальной вершине метка Distance присваивается = 0
            //Path для каждой вершины будет хранить путь до неё от начальной вершины, найденный в ходе алгоритма
            vList[beg].Path = new List<int> { beg };
            for (int i = 0; i < Count(); i++) //для остальных вершин Distance будет присвоено максимальное значение
            {
                if (i != beg)
                {
                    vList[i].Distance = Int32.MaxValue;
                    vList[i].Path = null;
                }
            }

            List<Vertex> sortedList=new List<Vertex>(); //копируем vList в sortedList 
            foreach(Vertex ver in vList)
                sortedList.Add(ver);

            while(vList.Find(a=>a.Visit==false) != null) //пока остались непосещённые вершины
            {
                sortedList.Sort((a, b) => a.Distance - b.Distance); //сортируем sortedList по возрастанию метки Distance
                //берем из него первый непосещённый элемент (его метка Distance будет минимальной)
                Vertex minVer = sortedList.Find(a => a.Visit == false);
                if (minVer.Path != null) //если до minVer был уже построен путь
                {
                    foreach (Edge edge in minVer.Edges) //для каждого ребра вершины minVer
                    {
                        Vertex neibour = vList[NumNode(minVer, edge)]; //получаем вершину, куда ведёт данное ребро
                                                                       //если эта вершина не посещена и новый маршрут меньше ранее найденного
                        if (neibour.Visit == false && neibour.Distance > minVer.Distance + weight(edge.Inf))
                        {
                            neibour.Distance = minVer.Distance + weight(edge.Inf); //перезаписываем дистанцию
                                                                                   //перезаписываем путь
                            neibour.Path = new List<int>(minVer.Path);
                            neibour.Path.Add(vList.IndexOf(neibour));
                        }
                    }
                }
                minVer.Visit = true; //делаем minVer посещённой
            }

            if (vList[end].Path != null) //если начальная и конечная вершины связаны маршрутом, путь будет найден
            {
                path = vList[end].Path; //запишем его в path
                VisualizePath(path); //закрасим вершины входящие в путь
                return vList[end].Distance; //вернем расстояние маршрута
            }
            else return -1; //если маршрут не найден, вернем -1
        }
        private void VisualizePath(List<int> path) //закрасить вершины входящие в маршрут
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
        public void Kruscall(Evaluator<E> weight) //краскал - построение остовного дерева
        {
            ResetVisit();
            ResetInTree();
            List<Edge> MyEdges = GetAllEdges(); //список всех рёбер
            List<HashSet<Vertex>> SetList = new List<HashSet<Vertex>>(); //список множеств компонент связности
            MyEdges.Sort((a, b) => { return weight(a.Inf) - weight(b.Inf); }); //сортируем ребра по возрастанию веса
            for (int i = 0; i < vList.Count; i++)
            {
                SetList.Add(new HashSet<Vertex>());
                SetList[i].Add(vList[i]); //каждая вершина сначала имеет компоненту связности равную своему номеру
            }
            foreach (Edge edge in MyEdges) //проходим по всем рёбрам
            {
                int component1 = GetComponent(edge.Start, SetList); //компонента начальной вершины
                int component2 = GetComponent(edge.End, SetList); //компонента конечной вершины
                if (component1 != component2) //если они разные, то можно добавить эти вершины в дерево
                {
                    edge.InTree = true; 
                    edge.Start.InTree = true;
                    edge.End.InTree = true;
                    SetList[component1].UnionWith(SetList[component2]);
                    SetList[component2].Clear();
                }
            }
        }
        public int GetComponent(Vertex ver, List<HashSet<Vertex>> setList) //узнать компоненту связности для вершины
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
