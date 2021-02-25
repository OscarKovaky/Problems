using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    class Program
    {
        
        public float []list;


        public void Cargar()
        {
            list = new float[5];
            string linea;

            for (int f=0;f < list.Length;f++)
            {
                Console.Write("Ingrese numero:");
                linea = Console.ReadLine();
      
                list[f] = float.Parse(linea);
            }


        }

        

        


        public void Ordenar() 
        {
            for (int k = 0; k < 4; k++)
            {
                for (int f = 0; f < 4 - k; f++)
                {
                    if (list[f] > list[f + 1])
                    {
                        float aux;
                        aux = list[f];
                        list[f] = list[f + 1];
                        list[f + 1] = aux;
                    }
                }
            }

        }

        public void Imprimir()
        {
            Console.WriteLine();
            for (int f = 0; f < list.Length; f++) {
                Console.WriteLine(list[f]);
             
            }
            Console.ReadKey();

        }


        public void Prueba()
        {
            double dato1 = 5.9;
            double dato2 = 5.60;
            double dato3 = 5.89;
       
            
            Console.WriteLine(Math.Max(dato1, dato2));
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.Prueba();






        }
    }
}
