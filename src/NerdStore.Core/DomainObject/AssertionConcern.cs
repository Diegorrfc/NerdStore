using System;
using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObject
{
    public class AssertionConcern
    {
        public static void ValidarSeigual(object object1, object object2, string msg)
        {
            if (!object1.Equals(object2))
                throw new DomainException(msg);
        }
        public static void ValidarSeDiferente(object object1, object object2, string msg)
        {
            if (object1.Equals(object2))
                throw new DomainException(msg);
        }
        public static void ValidarCaracteres(string valor, int max, string msg)
        {
            if (valor.Trim().Length > max)
                throw new DomainException(msg);
        }
        public static void ValidarCaracteres(string valor, int min, int max, string msg)
        {
            if (valor.Trim().Length > max || valor.Trim().Length < min)
                throw new DomainException(msg);
        }
        public static void ValidarExpressao(string pattern, string valor, string msg)
        {
            var regex = new Regex(pattern);
            if (!regex.IsMatch(valor))
                throw new DomainException(msg);
        }
        public static void ValidarSeNulo(object object1, string msg)
        {
            if (object1 == null)
                throw new DomainException(msg);
        }
        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string msg)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(msg);
        }
        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string msg)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(msg);
        }
        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string msg)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(msg);
        }
        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string msg)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(msg);
        }
        public static void ValidarSeMenorIgualMinimo(decimal valor, decimal minimo, string msg)
        {
            if (valor <= minimo)
                throw new DomainException(msg);
        }
        public static void ValidarSeMenorIgualMinimo(int valor, int minimo, string msg)
        {
            if (valor <= minimo)
                throw new DomainException(msg);
        }
        public static void ValidarSeMenorIgualMinimo(double valor, double minimo, string msg)
        {
            if (valor <= minimo)
                throw new DomainException(msg);
        }
    }
}
