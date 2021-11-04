using compilador.ManejadorErrores;
using compilador.TablaSimbolos;
using compilador.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compilador.AnalisisLexico
{
    class AnalizadorLexico
    {
        private int Puntero;
        private int NumeroLineaActual;
        private Linea LineaActual;
        private String CaracterActual;
        private String Lexema;
        private String ResultadoAnaLex;
        private int EstadoActual;
        private bool ContinuarAnalisis;
        private ComponenteLexico Componente;

        public AnalizadorLexico()
        {
            CargarNuevaLinea();
        }

        private void CargarNuevaLinea()
        {
            NumeroLineaActual = NumeroLineaActual + 1;
            LineaActual = Cache.ObtenerCache().ObtenerLinea(NumeroLineaActual);
            NumeroLineaActual = LineaActual.ObtenerNumero(); //Asegura que se quede en el fin de archivo
            Puntero = 0;
        }

        private void DevolverPuntero()
        {
            if (Puntero > 1)
            {
                Puntero = Puntero - 1;
            }
        }

        private void AvanzarPuntero()
        {
            Puntero = Puntero + 1;
        }

        private void FormarComponente(string Lexema, Categoria Categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal, Tipo Tipo)
        {

            Componente = ComponenteLexico.Crear(Lexema, Categoria, NumeroLinea, PosicionInicial, PosicionFinal, Tipo);
            Tabla.ObtenerInstancia().Agregar(Componente);

        }

        private void LeerSiguienteCaracter()
        {
            if (LineaActual.esFinArchivo())
            {
                CaracterActual = LineaActual.ObtenerContenido();
            }
            else if (Puntero > LineaActual.ObtenerLongitud()-1)
            {
                Puntero = LineaActual.ObtenerLongitud() + 1;
                CaracterActual = "@FL@";
            }
            else
            {
                CaracterActual = LineaActual.ObtenerContenido().Substring(Puntero, 1); //oBTIENE LA PARTE DE LA CADENA DEL PUNTERO Y OBTIENE UN CARACTER
                AvanzarPuntero();
            }
        }

        public String DevolverResultado()
        {
            return ResultadoAnaLex; 
        }

        public void Reiniciar()
        {
            Lexema = "";
            CaracterActual = "";
            EstadoActual = 0;
            ContinuarAnalisis = true;
        }

        private string DevolverFaltante(string esperado, string lleva)
        {
            int largolleva = lleva.Length;
            string resultado = esperado.Substring(largolleva);
            return resultado;
        }

        public ComponenteLexico DevolverComponenteLexico()
        {
            Reiniciar();
            while (ContinuarAnalisis)
            {
                switch (EstadoActual)
                {
                    case 0:
                        ProcesarEstado0();
                        break;
                    case 1:
                        ProcesarEstado1();
                        break;
                    case 2:
                        ProcesarEstado2();
                        break;
                    case 3:
                        ProcesarEstado3();
                        break;
                    case 4:
                        ProcesarEstado4();
                        break;
                    case 5:
                        ProcesarEstado5();
                        break;
                    case 6:
                        ProcesarEstado6();
                        break;
                    case 7:
                        ProcesarEstado7();
                        break;
                    case 8:
                        ProcesarEstado8();
                        break;
                    case 9:
                        ProcesarEstado9();
                        break;
                    case 10:
                        ProcesarEstado10();
                        break;
                    case 11:
                        ProcesarEstado11();
                        break;
                    case 12:
                        ProcesarEstado12();
                        break;
                    case 13:
                        ProcesarEstado13();
                        break;
                    case 14:
                        ProcesarEstado14();
                        break;
                    case 15:
                        ProcesarEstado15();
                        break;
                    case 16:
                        ProcesarEstado16();
                        break;
                    case 17:
                        ProcesarEstado17();
                        break;
                    case 18:
                        ProcesarEstado18();
                        break;
                    case 19:
                        ProcesarEstado19();
                        break;
                    case 20:
                        ProcesarEstado20();
                        break;
                    case 21:
                        ProcesarEstado21();
                        break;
                    case 22:
                        ProcesarEstado22();
                        break;
                    case 23:
                        ProcesarEstado23();
                        break;
                    case 24:
                        ProcesarEstado24();
                        break;
                    case 25:
                        ProcesarEstado25();
                        break;
                    case 26:
                        ProcesarEstado26();
                        break;
                    case 27:
                        ProcesarEstado27();
                        break;
                    case 28:
                        ProcesarEstado28();
                        break;
                    case 29:
                        ProcesarEstado29();
                        break;
                    case 30:
                        ProcesarEstado30();
                        break;
                    case 31:
                        ProcesarEstado31();
                        break;
                    case 32:
                        ProcesarEstado32();
                        break;
                    case 33:
                        ProcesarEstado33();
                        break;
                    case 34:
                        ProcesarEstado34();
                        break;
                    case 35:
                        ProcesarEstado35();
                        break;
                    case 36:
                        ProcesarEstado36();
                        break;
                    case 37:
                        ProcesarEstado37();
                        break;
                    case 38:
                        ProcesarEstado38();
                        break;
                    case 39:
                        ProcesarEstado39();
                        break;
                    case 40:
                        ProcesarEstado40();
                        break;
                    case 41:
                        ProcesarEstado41();
                        break;
                    case 42:
                        ProcesarEstado42();
                        break;
                    case 43:
                        ProcesarEstado43();
                        break;
                    case 44:
                        ProcesarEstado44();
                        break;
                    case 45:
                        ProcesarEstado45();
                        break;
                    case 46:
                        ProcesarEstado46();
                        break;
                    case 47:
                        ProcesarEstado47();
                        break;
                    case 48:
                        ProcesarEstado48();
                        break;
                    case 49:
                        ProcesarEstado49();
                        break;
                    case 50:
                        ProcesarEstado50();
                        break;
                    case 51:
                        ProcesarEstado51();
                        break;
                    case 52:
                        ProcesarEstado52();
                        break;
                    case 53:
                        ProcesarEstado53();
                        break;
                    case 54:
                        ProcesarEstado54();
                        break;
                    case 55:
                        ProcesarEstado55();
                        break;
                    case 56:
                        ProcesarEstado56();
                        break;
                    case 57:
                        ProcesarEstado57();
                        break;
                    case 58:
                        ProcesarEstado58();
                        break;
                    case 59:
                        ProcesarEstado59();
                        break;
                    case 60:
                        ProcesarEstado60();
                        break;
                    case 61:
                        ProcesarEstado61();
                        break;
                    case 62:
                        ProcesarEstado62();
                        break;
                    case 63:
                        ProcesarEstado63();
                        break;
                    case 64:
                        ProcesarEstado64();
                        break;
                    case 65:
                        ProcesarEstado65();
                        break;
                    case 66:
                        ProcesarEstado66();
                        break;
                    case 67:
                        ProcesarEstado67();
                        break;
                    case 68:
                        ProcesarEstado68();
                        break;
                    case 69:
                        ProcesarEstado69();
                        break;
                    case 70:
                        ProcesarEstado70();
                        break;
                    case 71:
                        ProcesarEstado71();
                        break;
                    case 72:
                        ProcesarEstado72();
                        break;
                    case 73:
                        ProcesarEstado73();
                        break;
                    case 75:
                        ProcesarEstado75();
                        break;
                    case 76:
                        ProcesarEstado76();
                        break;
                    case 77:
                        ProcesarEstado77();
                        break;
                    case 78:
                        ProcesarEstado78();
                        break;
                    case 80:
                        ProcesarEstado80();
                        break;
                    case 81:
                        ProcesarEstado81();
                        break;
                    case 82:
                        ProcesarEstado82();
                        break;
                    case 84:
                        ProcesarEstado84();
                        break;
                    case 85:
                        ProcesarEstado85();
                        break;
                    case 86:
                        ProcesarEstado86();
                        break;
                    case 87:
                        ProcesarEstado87();
                        break;
                    case 90:
                        ProcesarEstado90();
                        break;
                    case 92:
                        ProcesarEstado92();
                        break;
                    
                }

            }
            return Componente;
        }


        private void ProcesarEstado0()
        {
            LeerSiguienteCaracter();
            DevorarEspacioBlanco();

            if (EsCero() || EsUno())
            {
                EstadoActual = 1;
                FormarLexema();
            }
            else if (EsLetraD())
            {
                EstadoActual = 48;
                FormarLexema();
            } 
            else if (EsLetraG())
            {
                EstadoActual = 33;
                FormarLexema();
            }
            else if (EsLetraI())
            {
                EstadoActual = 59;
                FormarLexema();
            }
            else if (EsLetraO())
            {
                EstadoActual = 29;
                FormarLexema();
            }
            else if (EsLetraS())
            {
                EstadoActual = 19;
                FormarLexema();
            }
            else if (EsLetraK())
            {
                EstadoActual = 15;
                FormarLexema();
            }
            else if (EsLetraF())
            {
                EstadoActual = 16;
                FormarLexema();
            }
            else if (EsLetraC())
            {
                EstadoActual = 17;
                FormarLexema();
            }
            else if (EsLetraR())
            {
                EstadoActual = 18;
                FormarLexema();
            }
            else if (EsSignoMenos())
            {
                EstadoActual = 5;
                FormarLexema();
            }
            else if (LineaActual.esFinArchivo())
            {
                EstadoActual = 11;
                FormarLexema();
            }
            else if (EsFinLinea())
            {
                EstadoActual = 14;
            }
            else
            {
                EstadoActual = 13;
            }
        }

        private void ProcesarEstado1()
        {
            LeerSiguienteCaracter();

            if (EsCero() || EsUno())
            {
                EstadoActual = 2;
                FormarLexema();
            }
            else
            {
                EstadoActual = 77;
            }
        }

        private void ProcesarEstado2()
        {
            LeerSiguienteCaracter();

            if (EsCero() || EsUno())
            {
                EstadoActual = 3;
                FormarLexema();
            }
            else
            {
                EstadoActual = 77;
            }

        }

        private void ProcesarEstado3()
        {
            LeerSiguienteCaracter();

            if (EsCero() || EsUno())
            {
                EstadoActual = 4;
                FormarLexema();
            }
            else
            {
                EstadoActual = 77;
            }

        }

        private void ProcesarEstado4()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.VALOR, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.LITERAL);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado5()
        {
            LeerSiguienteCaracter();

            if (EsUno())
            {
                EstadoActual = 6;
                FormarLexema();
            }
            else if (EsCero())
            {
                EstadoActual = 9;
                FormarLexema();
            }
            else
            {
                EstadoActual = 75;
            }
        }

        private void ProcesarEstado6()
        {
            LeerSiguienteCaracter();

            if (EsUno())
            {
                EstadoActual = 7;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }   

        private void ProcesarEstado7()
        {

            LeerSiguienteCaracter();
            if (EsSignoMenos())
            {
                EstadoActual = 8;
                FormarLexema();
            }
            else
            {
                EstadoActual = 76;
            }
        }
        private void ProcesarEstado8()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.ENCENDIDO, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado9()
        {
            LeerSiguienteCaracter();

            if (EsCero())
            {
                EstadoActual = 10;
                FormarLexema();
            }
            else
            {
                EstadoActual = 73;
            }
        }

        private void ProcesarEstado10()
        {
            LeerSiguienteCaracter();
            if (EsSignoMenos())
            {
                EstadoActual = 12;
                FormarLexema();
            }
            else
            {
                EstadoActual = 73;
            }
        }

        private void ProcesarEstado11()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.FIN_ARCHIVO, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.SIMBOLO);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado12()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.APAGADO, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado13()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;
            string Falla = "Simbolo no valido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba el caracter E";
            string Solucion = "Asegurese de que escribió correctamente";
            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;

        }

        private void ProcesarEstado14()
        {
            CargarNuevaLinea();
            Reiniciar();
        }

        private void ProcesarEstado15()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.KELVIN, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado16()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.FAHRENHEIT, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado17()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.CENTIGRADOS, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado18()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.RANKINE, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }


        private void ProcesarEstado19()
        {
            LeerSiguienteCaracter();

            if (EsLetraH())
            {
                EstadoActual = 20;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado20()
        {
            LeerSiguienteCaracter();

            if (EsLetraU())
            {
                EstadoActual = 21;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado21()
        {
            LeerSiguienteCaracter();

            if (EsLetraT())
            {
                EstadoActual = 22;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado22()
        {
            LeerSiguienteCaracter();

            if (EsLetraD())
            {
                EstadoActual = 23;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado23()
        {
            LeerSiguienteCaracter();

            if (EsLetraO())
            {
                EstadoActual = 24;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado24()
        {
            LeerSiguienteCaracter();

            if (EsLetraW())
            {
                EstadoActual = 25;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado25()
        {
            LeerSiguienteCaracter();

            if (EsLetraN())
            {
                EstadoActual = 26;
                FormarLexema();
            }
            else
            {
                EstadoActual = 78;
            }
        }

        private void ProcesarEstado26()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.SHUTDOWN, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado27()
        {
            LeerSiguienteCaracter();

            if (EsLetraT())
            {
                EstadoActual = 28;
                FormarLexema();
            }
            else
            {
                EstadoActual = 800;
            }
        }

        private void ProcesarEstado28()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.OUT, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }


        private void ProcesarEstado29()
        {
            LeerSiguienteCaracter();

            if (EsLetraU())
            {
                EstadoActual = 27;
                FormarLexema();
            }
            else if (EsLetraF())
            {
                EstadoActual = 30;
                FormarLexema();
            }
            else if (EsLetraN())
            {
                EstadoActual = 32;
                FormarLexema();
            }
            else
            {
                EstadoActual = 85;
            }
        }

        private void ProcesarEstado30()
        {
            LeerSiguienteCaracter();


            if (EsLetraF())
            {
                EstadoActual = 31;
                FormarLexema();
            }
            else
            {
                EstadoActual = 86;
            }
        }

        private void ProcesarEstado31()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.OFF, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado32()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.ON, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado33()
        {
            LeerSiguienteCaracter();



            if (EsLetraE())
            {
                EstadoActual = 34;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado34()
        {
            LeerSiguienteCaracter();



            if (EsLetraT())
            {
                EstadoActual = 35;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado35()
        {
            LeerSiguienteCaracter();

            if (EsGuionBajo())
            {
                EstadoActual = 36;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado36()
        {
            LeerSiguienteCaracter();

            if (EsLetraT())
            {
                EstadoActual = 37;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado37()
        {
            LeerSiguienteCaracter();

            if (EsLetraE())
            {
                EstadoActual = 38;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado38()
        {
            LeerSiguienteCaracter();


            if (EsLetraM())
            {
                EstadoActual = 39;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado39()
        {
            LeerSiguienteCaracter();

            if (EsLetraP())
            {
                EstadoActual = 40;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado40()
        {
            LeerSiguienteCaracter();

            if (EsLetraE())
            {
                EstadoActual = 41;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado41()
        {
            LeerSiguienteCaracter();

            if (EsLetraR())
            {
                EstadoActual = 42;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado42()
        {
            LeerSiguienteCaracter();

            if (EsLetraA())
            {
                EstadoActual = 43;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado43()
        {
            LeerSiguienteCaracter();

            if (EsLetraT())
            {
                EstadoActual = 44;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado44()
        {
            LeerSiguienteCaracter();

            if (EsLetraU())
            {
                EstadoActual = 45;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado45()
        {
            LeerSiguienteCaracter();

            if (EsLetraR())
            {
                EstadoActual = 46;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado46()
        {
            LeerSiguienteCaracter();

            if (EsLetraE())
            {
                EstadoActual = 47;
                FormarLexema();
            }
            else
            {
                EstadoActual = 87;
            }
        }

        private void ProcesarEstado47()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.GET_TEMPERATURE, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado48()
        {
            LeerSiguienteCaracter();

            if (EsLetraE())
            {
                EstadoActual = 49;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado49()
        {
            LeerSiguienteCaracter();

            if (EsLetraC())
            {
                EstadoActual = 50;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado50()
        {
            LeerSiguienteCaracter();

            if (EsLetraR())
            {
                EstadoActual = 51;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado51()
        {
            LeerSiguienteCaracter();

            if (EsLetraE())
            {
                EstadoActual = 52;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado52()
        {
            LeerSiguienteCaracter();

            if (EsLetraM())
            {
                EstadoActual = 53;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado53()
        {
            LeerSiguienteCaracter();

            if (EsLetraE())
            {
                EstadoActual = 54;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado54()
        {
            LeerSiguienteCaracter();

            if (EsLetraN())
            {
                EstadoActual = 55;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado55()
        {
            LeerSiguienteCaracter();

            if (EsLetraT())
            {
                EstadoActual = 56;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado56()
        {
            LeerSiguienteCaracter();

            if (EsLetraA())
            {
                EstadoActual = 57;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado57()
        {
            LeerSiguienteCaracter();

            if (EsLetraR())
            {
                EstadoActual = 58;
                FormarLexema();
            }
            else
            {
                EstadoActual = 81;
            }
        }

        private void ProcesarEstado58()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.DECREMENTAR, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }



        private void ProcesarEstado59()
        {
            LeerSiguienteCaracter();


            if (EsLetraN())
            {
                EstadoActual = 60;
                FormarLexema();
            }
            else
            {
                EstadoActual = 84;
            }
        }

        private void ProcesarEstado60()
        {
            LeerSiguienteCaracter();


            if (EsLetraI())
            {
                EstadoActual = 61;
                FormarLexema();
            }
            else if (EsLetraC())
            {
                EstadoActual = 64;
                FormarLexema();
            }
            else if (EsEspacio())
            {
                EstadoActual = 63;
            }
            else
            {
                EstadoActual = 92;
            }
        }


        private void ProcesarEstado61()
        {
            LeerSiguienteCaracter();


            if (EsLetraT())
            {
                EstadoActual = 62;
                FormarLexema();
            }
            else
            {
                EstadoActual = 82;
            }
        }

        private void ProcesarEstado62()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.INIT, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado63()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;

            ResultadoAnaLex = ResultadoAnaLex + "(" + Tipo.PALABRA_RESERVADA + "," + Categoria.IN + "," + Lexema + ")";
            FormarComponente(Lexema, Categoria.IN, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);

            ContinuarAnalisis = false;
        }

        private void ProcesarEstado64()
        {
            LeerSiguienteCaracter();


            if (EsLetraR())
            {
                EstadoActual = 65;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado65()
        {
            LeerSiguienteCaracter();


            if (EsLetraE())
            {
                EstadoActual = 66;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado66()
        {
            LeerSiguienteCaracter();


            if (EsLetraM())
            {
                EstadoActual = 67;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado67()
        {
            LeerSiguienteCaracter();


            if (EsLetraE())
            {
                EstadoActual = 68;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado68()
        {
            LeerSiguienteCaracter();


            if (EsLetraN())
            {
                EstadoActual = 69;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado69()
        {
            LeerSiguienteCaracter();


            if (EsLetraT())
            {
                EstadoActual = 70;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado70()
        {
            LeerSiguienteCaracter();


            if (EsLetraA())
            {
                EstadoActual = 71;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado71()
        {
            LeerSiguienteCaracter();


            if (EsLetraR())
            {
                EstadoActual = 72;
                FormarLexema();
            }
            else
            {
                EstadoActual = 90;
            }
        }

        private void ProcesarEstado72()
        {
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            FormarComponente(Lexema, Categoria.INCREMENTAR, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.PALABRA_RESERVADA);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado73()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("-00-", Categoria.APAGADO, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("-00-", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("-00-", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        
        private void ProcesarEstado75()
        {

            DevolverPuntero();
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            MessageBox.Show("Error en linea " + NumeroLinea + ": Símbolo inesperado '" + CaracterActual + "'  . Se esperaba '0' o '1'");
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado76()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("-11-", Categoria.ENCENDIDO, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("-11-", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("-11-", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;

        }

        private void ProcesarEstado77()
        {
            DevolverPuntero();
            int NumeroLinea = NumeroLineaActual;
            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero - 1;
            MessageBox.Show("Error en linea " + NumeroLinea + ": Símbolo inesperado  '" + CaracterActual + "'  . Se esperaba un valor de 4 bits");
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado78()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("SHUTDOWN", Categoria.SHUTDOWN, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("SHUTDOWN", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("SHUTDOWN", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado80()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("OUT", Categoria.OUT, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("OUT", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("OUT", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }

        private void ProcesarEstado81()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("DECREMENTAR", Categoria.DECREMENTAR, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("DECREMENTAR", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("DECREMENTAR", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;

        }
        private void ProcesarEstado82()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("INIT", Categoria.INIT, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("INIT", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("INIT", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        
        private void ProcesarEstado84()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            string Falla = "Simbolo no valido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba el caracter E";
            string Solucion = "Asegurese de que escribió correctamente";

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado85()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            string Falla = "Simbolo no valido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba el caracter E";
            string Solucion = "Asegurese de que escribió correctamente";

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado86()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("OFF", Categoria.OFF, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("OFF", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("OFF", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado87()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("GET_TEMPERATURE", Categoria.GET_TEMPERATURE, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("GET_TEMPERATURE", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("GET_TEMPERATURE", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado90()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            FormarComponente("INCREMENTAR", Categoria.INCREMENTAR, NumeroLineaActual, PosicionInicial, PosicionFinal, Tipo.DUMMY);

            string Falla = "Caracter ingresado no válido: " + Lexema + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y esperaba la cadena: " + DevolverFaltante("INCREMENTAR", Lexema);
            string Solucion = "Asegúrese que luego de ingresar " + Lexema + ",  se ingrese: " + DevolverFaltante("INCREMENTAR", Lexema);

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        private void ProcesarEstado92()
        {
            DevolverPuntero();

            int PosicionInicial = Puntero - Lexema.Length;
            int PosicionFinal = Puntero;

            string Falla = "Simbolo no valido: " + CaracterActual;
            string Causa = "Recibí " + CaracterActual + " y se esperaba el caracter E";
            string Solucion = "Asegurese de que escribió correctamente";

            Error Error = Error.Crear(NumeroLineaActual, PosicionInicial, PosicionFinal, Falla, Causa, Solucion, TipoError.LEXICO);
            GestorErrores.ObtenerInstancia().Agregar(Error);
            ContinuarAnalisis = false;
        }
        private bool EsEspacio()
        {
            return " ".Equals(CaracterActual);
        }

        private bool EsCero()
        {
            return "0".Equals(CaracterActual);
        }

        private bool EsUno()
        {
            return "1".Equals(CaracterActual);
        }

        private bool EsLetraTemperatura()
        {
            return "K".Equals(CaracterActual) || "F".Equals(CaracterActual) || "C".Equals(CaracterActual) || "R".Equals(CaracterActual);
        }

        private bool EsLetraA()
        {
            return "A".Equals(CaracterActual);
        }

        private bool EsLetraC()
        {
            return "C".Equals(CaracterActual);
        }

        private bool EsLetraD()
        {
            return "D".Equals(CaracterActual);
        }

        private bool EsLetraE()
        {
            return "E".Equals(CaracterActual);
        }

        private bool EsLetraF()
        {
            return "F".Equals(CaracterActual);
        }

        private bool EsLetraG()
        {
            return "G".Equals(CaracterActual);
        }

        private bool EsLetraH()
        {
            return "H".Equals(CaracterActual);
        }

        private bool EsLetraI()
        {
            return "I".Equals(CaracterActual);
        }

        private bool EsLetraK()
        {
            return "K".Equals(CaracterActual);
        }

        private bool EsLetraM()
        {
            return "M".Equals(CaracterActual);
        }

        private bool EsLetraN()
        {
            return "N".Equals(CaracterActual);
        }

        private bool EsLetraO()
        {
            return "O".Equals(CaracterActual);
        }

        private bool EsLetraP()
        {
            return "P".Equals(CaracterActual);
        }

        private bool EsLetraR()
        {
            return "R".Equals(CaracterActual);
        }

        private bool EsLetraS()
        {
            return "S".Equals(CaracterActual);
        }

        private bool EsLetraT()
        {
            return "T".Equals(CaracterActual);
        }

        private bool EsLetraU()
        {
            return "U".Equals(CaracterActual);
        }

        private bool EsLetraW()
        {
            return "W".Equals(CaracterActual);
        }

        private bool EsFinLinea()
        {
            return "@FL@".Equals(CaracterActual);
        }

        private bool EsSignoMenos()
        {
            return "-".Equals(CaracterActual);
        }

        private bool EsGuionBajo()
        {
            return "_".Equals(CaracterActual);
        }

        private void FormarLexema()
        {
            Lexema = Lexema + CaracterActual;
        }

        private void DevorarEspacioBlanco()
        {
            String Blanco = " ";

            while (Blanco.Equals(CaracterActual))
            {
                LeerSiguienteCaracter();
            }
        }

     
    }
}
