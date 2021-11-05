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
        private Stack<string> Pila = new Stack<string>();

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
                MessageBox.Show("La compilacion ha finalizado exitosamente...");
                //MessageBox.Show("Resultado: " + Pila.Pop());
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

        //<expresion> -> IN <entrada> <preexpresion> | OUT <salida> <preexpresion>
        private void Expresion(int nivel)
        {
            FormarEntrada(nivel, "<Expresion>");
            if (Categoria.IN.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                Entradas(nivel + 1);
                Preexpresion(nivel + 1);


            }
            else if (Categoria.OUT.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                Salidas(nivel + 1);
                Preexpresion(nivel + 1);

            }
            else 
            {
                string Falla = "Componente no válido: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerCategoria() + " ...";
                string Solucion = "Asegúrese de que el componente sea IN o OUT...";


                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, ManejadorErrores.TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);

                throw new Exception("Error tipo stopper durante el análisis sintáctico. Por favor verifique la consola de errores...");

            }

            FormarSalida(nivel, "<Expresion>");
        }
        //<preexpresion> -> Epsilon | <expresion>
        private void Preexpresion(int nivel)
        {
            FormarEntrada(nivel, "<Preexpresion>");
            if (Categoria.IN.Equals(Componente.ObtenerCategoria()) || Categoria.OUT.Equals(Componente.ObtenerCategoria()))
            {
                
                Expresion(nivel + 1);
            }
            else
            {
                Avanzar();
            }

            
            FormarSalida(nivel, "<Preexpresion>");
        }
        //<entrada> -> VALOR <unidad_de_medida><accion> | GET_TEMPERATURE <unidad_de_medida> | -11- SHUTDOWN  | -00- INIT 
        private void Entradas(int nivel)
        {
            FormarEntrada(nivel, "<Entradas>");
            if (Categoria.VALOR.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                UnidadMedida(nivel + 1);
                Accion(nivel + 1);


            }
            else if (Categoria.GET_TEMPERATURE.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                UnidadMedida(nivel + 1);

            }
            else if (Categoria.ENCENDIDO.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                if (Categoria.SHUTDOWN.Equals(Componente.ObtenerCategoria()))
                {
                    FormarEntrada(nivel, "<Entradas>");
                    Pila.Push(Componente.ObtenerLexema());
                    Avanzar();
                    FormarSalida(nivel, "<Entradas>");


                }
                

            }
            else if (Categoria.APAGADO.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                if (Categoria.INIT.Equals(Componente.ObtenerCategoria()))
                {
                    FormarEntrada(nivel, "<Entradas>");
                    Pila.Push(Componente.ObtenerLexema());
                    Avanzar();
                    FormarSalida(nivel, "<Entradas>");
                }

            }
            else
            {
                string Falla = "Componente no válido: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerCategoria() + " ...";
                string Solucion = "Asegúrese de que el componente sea VALOR, GET_TEMPERATURE, -11-, -00-...";


                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, ManejadorErrores.TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);

                throw new Exception("Error tipo stopper durante el análisis sintáctico. Por favor verifique la consola de errores...");
            }
            FormarSalida(nivel, "<Entradas>");
        }

        //<salida> -> VALOR <unidad_de_medida> | -11- ON  | -00- OFF 

        private void Salidas(int nivel)
        {
            FormarEntrada(nivel, "<Salidas>");
            if (Categoria.VALOR.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                UnidadMedida(nivel + 1);
                


            }
            else if (Categoria.ENCENDIDO.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                if (Categoria.ON.Equals(Componente.ObtenerCategoria()))
                {
                    FormarEntrada(nivel, "<Salidas>");
                    Pila.Push(Componente.ObtenerLexema());
                    Avanzar();
                    FormarSalida(nivel, "<Salidas>");
                }


            }
            else if (Categoria.APAGADO.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                if (Categoria.OFF.Equals(Componente.ObtenerCategoria()))
                {
                    FormarEntrada(nivel, "<Salidas>");
                    Pila.Push(Componente.ObtenerLexema());
                    Avanzar();
                    FormarSalida(nivel, "<Salidas>");
                }

            }
            else
            {
                string Falla = "Componente no válido: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerCategoria() + " ...";
                string Solucion = "Asegúrese de que el componente sea VALOR, -11-, -00-...";


                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, ManejadorErrores.TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);

                throw new Exception("Error tipo stopper durante el análisis sintáctico. Por favor verifique la consola de errores...");
            }
            FormarSalida(nivel, "<Salidas>");
        }
        //<accion> -> INCREMENTAR  |DECREMENTAR 
        private void Accion(int nivel)
        {
            FormarEntrada(nivel, "<Accion>");
            if (Categoria.INCREMENTAR.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                

            }
            else if (Categoria.DECREMENTAR.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();

            }
            else
            {
                string Falla = "Componente no válido: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerCategoria() + " ...";
                string Solucion = "Asegúrese de que el componente sea INCREMENTAR o DECREMENTAR...";


                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, ManejadorErrores.TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);

                throw new Exception("Error tipo stopper durante el análisis sintáctico. Por favor verifique la consola de errores...");
            }
            FormarSalida(nivel, "<Accion>");
        }



        //<unidad_de_medida> -> C |F |K |R 
        private void UnidadMedida(int nivel)
        {
            FormarEntrada(nivel, "<UnidadMedida>");
            if (Categoria.CENTIGRADOS.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
            }
            else if (Categoria.FAHRENHEIT.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
            }
            else if (Categoria.KELVIN.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
            }
            else if (Categoria.RANKINE.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
            }
            else
            {
                string Falla = "Unidad de medida no valida: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerLexema() + "...";
                string Solucion = "Asegurese de ingresar una unidad de memida valida (C, F, K, R)";

                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);
            }
            FormarSalida(nivel, "<UnidadMedida>");
        }





    }
}
