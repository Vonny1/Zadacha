using System;
using System.Collections.Generic;
using System.Linq;

namespace zadacha
{
    class Program
    {
        public struct Diap // Структура диапазона с первой и последней цифрой 
        {
            public double First;
            public double Last;
            public Diap(double a, double b) { this.First = a; this.Last = b; }
        }

        public static List<Diap> ConvertArray(string[] strMasInput) // Преобразование входного массива строк в список  Diap
        {
            List<Diap> diapListOut = new List<Diap>();
            double first;
            double last;
            string element;
            // Создаем список объектов Diap из входного массива строк
            for (int i = 0; i < strMasInput.Length; i++) 
            {

                element = strMasInput[i];
                List<string> stringList = new List<string>();
                string stringBuff="";
                foreach (var j in element)
                {
                    if (j != '-')
                    {
                        stringBuff += j;
                    }
                    else
                    {
                        stringList.Add(stringBuff);
                        stringBuff = "";
                    }
                }
                stringList.Add(stringBuff);
                first = int.Parse(stringList[0].ToString());
                last = int.Parse(stringList[1].ToString());
                Diap diap = new Diap(first, last);
                diapListOut.Add(diap);
            }
            // Сортировка Diap списка 
            Diap temp = new Diap();
            for (int i = 0; i < diapListOut.Count - 1; i++)
            {
                for (int j = i + 1; j < diapListOut.Count; j++)
                {
                    if (diapListOut[i].First > diapListOut[j].First)
                    {
                        temp = diapListOut[i];
                        diapListOut[i] = diapListOut[j];
                        diapListOut[j] = temp;
                    }
                }
            }
            // Сортировка Diap списка 
            for (int x = 0; x < diapListOut.Count - 1; x++)
            {
                for (int z = x + 1; z < diapListOut.Count; z++)
                {
                    if (diapListOut[x].First == diapListOut[z].First & diapListOut[x].Last > diapListOut[z].Last)
                    {
                        temp = diapListOut[x];
                        diapListOut[x] = diapListOut[z];
                        diapListOut[z] = temp;
                    }
                }
            }
            return diapListOut;
        }




        public static List<Diap> Zadacha(List<Diap> diaps)
        {
            List <Diap> listOut = new List<Diap>();
            Diap elem = diaps[0];
            Diap elemBuff = new Diap();
            bool flag;
            for (int i=1; i<diaps.Count;i++)
            {
                elemBuff = DiapMerge(elem, diaps[i], out flag);
                if (flag == false) // Уперлись
                {
                    listOut.Add(elem);
                    elem = diaps[i];
                }
                else // Едем дальше
                {
                    elem = elemBuff;
                }
            }
            listOut.Add(elem);
            return listOut;

        }

        public static Diap DiapMerge(Diap diap1, Diap diap2, out bool flag) // Слияние двух элементов Diap. Если слияние возможно - возвращает новый элемент и true. Если нет - возвращает элемент (0, 0) и false
        {
            Diap diapOut = new Diap();
            if (diap1.Last >= diap2.First)
            {
                List<Double> compareLast = new List<double>() { diap1.Last, diap2.Last };
                double biggestLast = compareLast.Max();
                diapOut = new Diap(diap1.First, biggestLast);
                flag = true;
                return diapOut;
            }
            else
            {
                diapOut = new Diap(0.0, 0.0);
                flag = false;
                return diapOut;

            }
        }


        static void Main(string[] args)
        {
            string[] mas = new string[] {"2-4", "17-49", "2-8", "26-32", "14-21", "8-10", "1-3", "32-35"};

            var a = ConvertArray(mas);
            Console.WriteLine("---SORTED--");
            foreach (var i in a)
            {
                Console.WriteLine(i.First + "-" + i.Last);
            }
            Console.WriteLine("---RESULT--");

            List<Diap> diaps = Zadacha(a);
            foreach(var j in diaps)
            {
                Console.WriteLine(j.First + "-" + j.Last);

            }



        }
    }
}
