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

        private int Gyerekek(int szülő, out int gyerek1, out int gyerek2)
        {
            // emlékeztető
            /*
            int b;
            bool lehete = int.TryParse("5", out b);
            */

            gyerek1 = 0;
            gyerek2 = 0;
            int gyerekszám = 0;
            if (2 * szülő <= lista.Count)
            {
                gyerek1 = 2 * szülő;
                gyerekszám = 1;
                if (2 * szülő + 1 <= lista.Count)
                {
                    gyerek2 = 2 * szülő + 1;
                    gyerekszám = 2;
                }
            }
            return gyerekszám;
        }

        private bool Idősebbgyerek(int szülő, out int idősebb_gyerek)
        {
            int gyerek1;
            int gyerek2;
            int gyerekszám = Gyerekek(szülő, out gyerek1, out gyerek2);

            switch (gyerekszám)
            {
                case 0:
                    idősebb_gyerek = 0;
                    return false;
                case 1:
                    idősebb_gyerek = gyerek1;
                    return true;
                case 2:
                    idősebb_gyerek = relacio(lista[gyerek1], lista[gyerek2]) == -1 ? gyerek2 : gyerek1;
                    return true;
                default: // ide sose fog befutni a program
                    idősebb_gyerek = 0;
                    return true;
            }
        }

        private void Süllyesztés()
        {
            int szülő = 1;
            int idősebb_gyerek;
            bool vanegyerek = Idősebbgyerek(szülő, out idősebb_gyerek);
            while (vanegyerek && relacio(lista[szülő], lista[idősebb_gyerek])==-1)
            {
                Csere(szülő, idősebb_gyerek);
                szülő = idősebb_gyerek;
                vanegyerek = Idősebbgyerek(szülő, out idősebb_gyerek);
            }
        }

        public void Push(T elem)
        {
            lista.Add(elem);
            Bugyborékolj(lista.Count);
        }

        public T Pop() 
        {
            Csere(1, lista.Count);
            T result = lista[lista.Count];
            lista.RemoveLast();
            Süllyesztés();
            return result;
        }

        public bool Empty() => lista.Count == 0;
        public override string ToString() => lista.ToString();

    }
}
