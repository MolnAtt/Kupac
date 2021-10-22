using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kupac
{
    class Kupac<T>
    {
        class Lista<R>
        {
            List<R> list = new List<R>();

            public void Add(R elem) => list.Add(elem);
            public void RemoveLast() => list.RemoveAt(list.Count - 1);
            public R this[int i]
            {
                get => list[i - 1];
                set => list[i - 1] = value;
            }
            public override string ToString()
            {
                string sum = "[ ";
                foreach (R item in list)
                {
                    sum += item + " ";
                }
                return sum + "]";
            }
            public int Count { get => list.Count; }
        }

        Lista<T> lista = new Lista<T>();
        Func<T, T, int> relacio;

        public Kupac(Func<T, T, int> r)
        {
            this.relacio = r;
        }


        private int Szülő(int i) => i / 2;

        private void Csere(int i, int j) => (lista[i], lista[j]) = (lista[j], lista[i]);

        private bool Gyökér(int i) => i == 1;

        private void Bugyborékolj(int gyerek)
        {
            while (!Gyökér(gyerek) && relacio(lista[gyerek], lista[Szülő(gyerek)]) == 1)
            {
                Csere(gyerek, Szülő(gyerek));
                gyerek = Szülő(gyerek);
            }
        }


        public void Push(T elem)
        {
            lista.Add(elem);
            Bugyborékolj(lista.Count);
        }

        public override string ToString() => lista.ToString();

    }
}
