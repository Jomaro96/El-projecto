using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    class Stack<T>
    {
        //ATRIBUTOS
        T[] vec;
        int tam;
        int tope;
        bool vacia;
        bool llena;

        //METODOS
        public Stack(int n)
        {
            tam = n;
            vec = new T[tam];
            tope = 0;
            vacia = true;
            llena = false;
        }

        public void Push(T valor)
        {
            vacia = false;
            vec[tope++] = valor;
            if (tope == tam)
                llena = true;
        }

        public T Pop()
        {
            llena = false;
            if (--tope == 0)
            {
                vacia = true;
            }
            return vec[tope];
        }

        public bool esta_Vacia()
        {
            return vacia;
        }

        public bool esta_Llena()
        {
            return llena;
        }

        public T Tope()
        {
            return vec[tope - 1];
        }
        public bool Full
        {
            //Si tope == pila.Length - 1, la pila esta llena
            get { return tope == vec.Length; }
        }

        public bool Empty
        {
            //Si tope == 0, la pila esta vacia
            get { return tope == 0; }
        }
        public int Length
        {
            //Regrersamos el tamaño del arreglo
            get { return vec.Length; }
        }
    }
}
