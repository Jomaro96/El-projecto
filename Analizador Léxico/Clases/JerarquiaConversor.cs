using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizador_Léxico.Clases
{
    class JerarquiaConversor
    {

        public enum Simbolo { OPERANDO, PIZQ, PDER, SUMARES, MULTDIV, POW };
        public StringBuilder convertir_pos(string Ei)
        {
            char[] Epos = new char[Ei.Length];
            int tam = Ei.Length;
            Stack<int> stack = new Stack<int>(tam);

            int i, pos = 0;
            for (i = 0; i < Epos.Length; i++)
            {
                char car = Ei[i];
                Simbolo actual = Tipo_y_Presendecia(car);
                switch (actual)
                {
                    case Simbolo.OPERANDO: Epos[pos++] = car; break;
                    case Simbolo.SUMARES:
                        {
                            while (!stack.Empty && Tipo_y_Presendecia((char)stack.Tope()) >= actual)
                            {
                                Epos[pos++] = (char)stack.Pop();
                            }
                            stack.Push(car);
                        }
                        break;
                    case Simbolo.MULTDIV:
                        {
                            while (!stack.Empty && Tipo_y_Presendecia((char)stack.Tope()) >= actual)
                            {
                                Epos[pos++] = (char)stack.Pop();
                            }
                            stack.Push(car);
                        }
                        break;
                    case Simbolo.POW:
                        {
                            while (!stack.Empty && Tipo_y_Presendecia((char)stack.Tope()) >= actual)
                            {
                                Epos[pos++] = (char)stack.Pop();
                            }
                            stack.Push(car);
                        }
                        break;
                    case Simbolo.PIZQ: stack.Push(car); break;
                    case Simbolo.PDER:
                        {
                            char x = (char)stack.Pop();
                            while (Tipo_y_Presendecia(x) != Simbolo.PIZQ)
                            {
                                Epos[pos++] = x;
                                x = (char)stack.Pop();
                            }
                        }
                        break;
                }
            }
            while (!stack.Empty)
            {
                if (pos < Epos.Length)
                    Epos[pos++] = (char)stack.Pop();
                else
                    break;
            }
            StringBuilder regresa = new StringBuilder(Ei);

            for (int r = 0; r < Epos.Length; r++)
                regresa[r] = Epos[r];
            return regresa;
        }
        public Simbolo Tipo_y_Presendecia(char s)
        {
            Simbolo simbolo;
            switch (s)
            {
                case '+': simbolo = Simbolo.SUMARES; break;
                case '-': simbolo = Simbolo.SUMARES; break;
                case '*': simbolo = Simbolo.MULTDIV; break;
                case '/': simbolo = Simbolo.MULTDIV; break;
                case '(': simbolo = Simbolo.PIZQ; break;
                case ')': simbolo = Simbolo.PDER; break;
                case '^': simbolo = Simbolo.POW; break;
                default: simbolo = Simbolo.OPERANDO; break;
            }
            return simbolo;
        }
    }
}

