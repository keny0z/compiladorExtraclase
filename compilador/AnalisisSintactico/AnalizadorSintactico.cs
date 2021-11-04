using compilador.AnalisisLexico;
using compilador.ManejadorErrores;
using compilador.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilador.AnalisisSintactico
{
    public class AnalizadorSintactico
    {
        private AnalizadorLexico AnaLex = new AnalizadorLexico();
        private ComponenteLexico Componente;
        private StringBuilder Traza;
        private Stack<double> Pila = new Stack<double>();

        public void Analizar(bool Depurar)
        {
            Avanzar();
            Traza = new StringBuilder();
            Expresion(1);

            if (Depurar)
            {
                MessageBox.Show(Traza.ToString());
            }
            if (GestorErrores.ObtenerInstancia().HayErrores())
            {
                MessageBox.Show("La compilacion ha finalizado, pero hay errores en el programa de entrada. Por favor verifique la consola de errores...");
            }
            else if (Categoria.FIN_ARCHIVO.Equals(Componente.ObtenerCategoria()))
            {
                if (Pila.Count == 1)
                {
                    MessageBox.Show("La compilacion ha finalizado exitosamente...");
                    MessageBox.Show("Resultado: " + Pila.Pop());
                }
                else
                {
                    MessageBox.Show("Aunque la compilacion ha finalizado exitosamente, faltaron componentes por evaluar.");
                }

            }
            else
            {
                MessageBox.Show("Aunque la compilacion ha finalizado exitosamente, faltaron componentes por evaluar.");
            }
        }

        private void Avanzar()
        {
            Componente = AnaLex.DevolverComponenteLexico();
        }

        private void FormarEntrada(int Nivel, String Regla)
        {

            for (int Contador = 1; Contador <= Nivel * 5; Contador++)
            {
                Traza.Append("-");
            }
            Traza.Append(">");
            Traza.Append("INICIO ").Append(Regla);
            Traza.Append("\n");

            FormarComponente(Nivel);


        }
        private void FormarSalida(int Nivel, String Regla)
        {
            Traza.Append("<");
            for (int Contador = 1; Contador <= Nivel * 5; Contador++)
            {
                Traza.Append("-");
            }

            Traza.Append("FIN ").Append(Regla);
            Traza.Append("\n");


        }
        private void FormarComponente(int Nivel)
        {
            Traza.Append("-");
            for (int Contador = 1; Contador <= (Nivel + 1) * 5; Contador++)
            {
                Traza.Append("-");
            }

            Traza.Append("Componente actual: ").Append(this.Componente.ObtenerLexema()).Append("/").Append(this.Componente.ObtenerCategoria());
            Traza.Append("\n");

        }
        private void FormarOperacion(int Nivel, String operacion)
        {
            Traza.Append("-");
            for (int Contador = 1; Contador <= (Nivel + 1) * 5; Contador++)
            {
                Traza.Append("-");
            }

            Traza.Append("Operando: ").Append(operacion).Append("\n");


        }

        //<expresion> -> <entrada> | <salida> | <entrada><expresion> | <salida><expresion>
        private void Expresion(int nivel)
        {
            FormarEntrada(nivel, "<Expresion>");
            if (Categoria.IN.Equals(Componente.ObtenerCategoria()))
            {

            }
            else if (Categoria.OUT.Equals(Componente.ObtenerCategoria()))
            {

            }
            else if (Categoria.OUT.Equals(Componente.ObtenerCategoria()))
            {

            }
            FormarSalida(nivel, "<Expresion>");
        }



    }
}
