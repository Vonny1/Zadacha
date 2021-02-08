using System;
using System.Collections.Generic;
using System.Linq;

namespace zadacha
{
    class Program
    {
        public struct Diap
        {
            public double First;
            public double Last;
            public Diap(double a, double b) { this.First = a; this.Last = b; }
        }

        public static List<Diap> ConvertArray(string[] strMas)
        {
            List<Diap> diapList = new List<Diap>();
            double first;
            double last;
            string elem;
            for (int i = 0; i < strMas.Length; i++)
            {

                elem = strMas[i];
                string numElem = new String(elem.Where(Char.IsDigit).ToArray());
                
                char a = numElem[0];
                char b = numElem[1];
                first = int.Parse(a.ToString());
                last = int.Parse(b.ToString());
                Diap diap = new Diap(first, last);
                diapList.Add(diap);
            }
            Diap temp = new Diap();
            for (int i = 0; i < diapList.Count - 1; i++)
            {
                for (int j = i + 1; j < diapList.Count; j++)
                {
                    if (diapList[i].First > diapList[j].First)
                    {
                        temp = diapList[i];
                        diapList[i] = diapList[j];
                        diapList[j] = temp;
                    }
                }
            }
            for (int x = 0; x < diapList.Count - 1; x++)
            {
                for (int z = x + 1; z < diapList.Count; z++)
                {
                    if (diapList[x].First == diapList[z].First & diapList[x].Last > diapList[z].Last)
                    {
                        temp = diapList[x];
                        diapList[x] = diapList[z];
                        diapList[z] = temp;
                    }
                }
            }
            return diapList;
        }

        //public static List<Diap> ConvertArray(string[] strMas)       //////STABLE
        //{
        //    List<Diap> diapList = new List<Diap>();
        //    double first;
        //    double last;
        //    string elem;
        //    for (int i = 0; i < strMas.Length; i++)
        //    {
        //        elem = strMas[i];
        //        char a = elem[0];
        //        char b = elem[2];
        //        first = int.Parse(a.ToString());
        //        last = int.Parse(b.ToString());
        //        Diap diap = new Diap(first, last);
        //        diapList.Add(diap);
        //    }
        //    Diap temp =new Diap();
        //    for (int i = 0; i < diapList.Count - 1; i++)
        //    {
        //        for (int j = i + 1; j < diapList.Count; j++)
        //        {
        //            if (diapList[i].First > diapList[j].First)
        //            {
        //                temp = diapList[i];
        //                diapList[i] = diapList[j];
        //                diapList[j] = temp;
        //            }
        //        }
        //    }
        //    for (int x = 0; x < diapList.Count - 1;x++)
        //    {
        //        for (int z = x + 1; z < diapList.Count; z++)
        //        {
        //            if (diapList[x].First == diapList[z].First & diapList[x].Last > diapList[z].Last)
        //            {
        //                temp = diapList[x];
        //                diapList[x] = diapList[z];
        //                diapList[z] = temp;
        //            }
        //        }
        //    }
        //    return diapList;
        //}

        public static List<double> GetList(Diap diap)
        {
            List<double> list = new List<double>();
            double buff;
            for(double i = diap.First; i<= diap.Last; i++)
            {
                buff = i;
                list.Add(buff);
            }
            return list;
        }

        public static List<Diap> Zadacha(List<Diap> diaps)
        {
            List <Diap> listOut = new List<Diap>();
            Diap elem = diaps[0];
            Diap elemBuff = new Diap();
            for (int i=1; i<diaps.Count;i++)
            {
                elemBuff = DiapMerge(elem, diaps[i]);
                if (elemBuff.First == 1.2 & elemBuff.Last == 3.4) // Уперлись
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
        public static Diap DiapMerge(Diap diap1, Diap diap2)
        {
            Diap diapOut;
            if (diap1.Last >= diap2.First)
            {
                List<Double> compareLast = new List<double>() { diap1.Last, diap2.Last };
                double biggestLast = compareLast.Max();
                diapOut = new Diap(diap1.First, biggestLast);
            }
            else
            {
                diapOut = new Diap(1.2, 3.4);
            }
            return diapOut;
        }
        
        static void Main(string[] args)
        {
            string[] mas = new string[] { "1-6", "2-10" , "3-8", "4-15", "3-20", "5-6", "10-20" };
            //string[] mas = new string[] {"1-9", "3-3", "1-4"};
            //string[] mas = new string[] { "1-9", "1-8", "1-2", "1-3", "2-6", "3-4", "5-7", "2-4" };
            //int[] test = TestFunc(mas);


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
