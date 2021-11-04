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
                MessageBox.Show("Resultado: " + Pila.Pop());
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

        //<expresion> -> <factor><expresionPrima>
        private void Expresion(int nivel)
        {
            FormarEntrada(nivel, "<Expresion>");
            Factor(nivel+1);
            ExpresionPrima(nivel+1);
            FormarSalida(nivel, "<Expresion>");
        }
        //<expresionPrima> -> <Entradas><Expresion>|<Salidas><Expresion>|Epsilon
        private void ExpresionPrima(int nivel)
        {
            FormarEntrada(nivel, "<ExpresionPrima>");
            String pop = Pila.Pop();
            if (Categoria.IN.Equals(pop))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                Entradas(nivel + 1);
                Expresion(nivel + 1);

               

            }
            else if (Categoria.OUT.Equals(pop))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                Salidas(nivel + 1);
                Expresion(nivel + 1);

               
            }
 
            FormarSalida(nivel, "<ExpresionPrima>");
        }
        //<factor> -> IN | OUT | Epsilon
        private void Factor(int nivel)
        {
            FormarEntrada(nivel, "<Factor>");
            if (Categoria.IN.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                

            }
            else if (Categoria.OUT.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                

            }
            else
            {
                string Falla = "Componente no válido: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerCategoria() + " ...";
                string Solucion = "Asegúrese de que el componente inicial sea IN o OUT...";


                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, ManejadorErrores.TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);

                throw new Exception("Error tipo stopper durante el análisis sintáctico. Por favor verifique la consola de errores...");
            }
            FormarSalida(nivel, "<Factor>");
        }
        //<Entradas> -> <valor> <unidad_de_medida> <Orden> | GET_TEMPERATURE <unidad_de_medida> | -11- SHUTDOWN | -00- INIT
        private void Entradas(int nivel)
        {
            FormarEntrada(nivel, "<Entradas>");
            
            if (Categoria.VALOR.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                Valor(nivel + 1);
                UnidadMedida(nivel + 1);
                Orden(nivel + 1);

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
                   Avanzar();
                }
                else
                {
                    string Falla = "Componente no valido: " + Componente.ObtenerLexema();
                    string Causa = "Recibí " + Componente.ObtenerCategoria() + " y esperaba SHUTDOWN";
                    string Solucion = "Asegurese de que luego de -11- ingrese SHUTDOWN";

                    Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                }
                


            }
            else if (Categoria.APAGADO.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                if (Categoria.INIT.Equals(Componente.ObtenerCategoria()))
                {
                    Avanzar();
                }
                else
                {
                    string Falla = "Componente no valido: " + Componente.ObtenerLexema();
                    string Causa = "Recibí " + Componente.ObtenerCategoria() + " y esperaba INIT";
                    string Solucion = "Asegurese de que luego de -00- ingrese INIT";

                    Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                }


            }

            FormarSalida(nivel, "<Entradas>");
        }
        //<Salidas> -> <valor> <unidad_de_medida> | -11- ON | -00- OFF
        private void Salidas(int nivel)
        {
            FormarEntrada(nivel, "<Salidas>");

            if (Categoria.VALOR.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                Valor(nivel + 1);
                UnidadMedida(nivel + 1);
               

            }
            else if (Categoria.ENCENDIDO.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                if (Categoria.ON.Equals(Componente.ObtenerCategoria()))
                {
                    Avanzar();
                }
                else
                {
                    string Falla = "Componente no valido: " + Componente.ObtenerLexema();
                    string Causa = "Recibí " + Componente.ObtenerCategoria() + " y esperaba ON";
                    string Solucion = "Asegurese de que luego de -11- ingrese ON";

                    Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                }



            }
            else if (Categoria.APAGADO.Equals(Componente.ObtenerCategoria()))
            {
                Pila.Push(Componente.ObtenerLexema());
                Avanzar();
                if (Categoria.OFF.Equals(Componente.ObtenerCategoria()))
                {
                    Avanzar();
                }
                else
                {
                    string Falla = "Componente no valido: " + Componente.ObtenerLexema();
                    string Causa = "Recibí " + Componente.ObtenerCategoria() + " y esperaba OFF";
                    string Solucion = "Asegurese de que luego de -00- ingrese OFF";

                    Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                    GestorErrores.ObtenerInstancia().Agregar(Error);
                }


            }

            FormarSalida(nivel, "<Salidas>");
        }

        //<unidad_de_medida> -> C|F|K|R
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
        //<Orden> -> Incrementar | Decrementar
        private void Orden(int nivel)
        {
            FormarEntrada(nivel, "<Orden>");
            if (Categoria.INCREMENTAR.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
            }
            else if (Categoria.DECREMENTAR.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
            }
            else
            {
                string Falla = "Orden no valida: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerLexema() + "...";
                string Solucion = "Asegurese de ingresar una orden valida (INCREMENTAR, DECREMENTAR)";

                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);
            }
            FormarSalida(nivel, "<Orden>");
        }
        //<valor>->VALOR
        private void Valor(int nivel)
        {
            FormarEntrada(nivel, "<Valor>");
            if (Categoria.VALOR.Equals(Componente.ObtenerCategoria()))
            {
                Avanzar();
            }
            else
            {
                string Falla = "VAlor no valido: " + Componente.ObtenerLexema();
                string Causa = "Recibí " + Componente.ObtenerLexema() + "...";
                string Solucion = "Asegurese de ingresar un valor valido";

                Error Error = ManejadorErrores.Error.Crear(Componente.ObtenerNumeroLinea(), Componente.ObtenerPosicionInicial(), Componente.ObtenerPosicionFinal(), Falla, Causa, Solucion, TipoError.SINTACTICO);
                GestorErrores.ObtenerInstancia().Agregar(Error);
            }
            FormarSalida(nivel, "<Valor>");
        }




    }
}
