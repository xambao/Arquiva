using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Arquiva.Models
{

    public enum TramiteStatus
    {
        Interno,
        Externo,
    }

    public class Tramite
    {
        #region Fields
        private const string PATTERN = "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};";

        private const string PATTERN_DATE = "yyyyMMdd";
        #endregion

        #region Propriedades
        public int Id { get; set; }

        public string REG { get; set; }

        public string REGMasked { get; set; }

        public DateTime Entrada { get; set; }

        public DateTime Prevista { get; set; }

        public DateTime Saida { get; set; }

        public string Responsavel { get; set; }

        public string Destino { get; set; }

        public TramiteStatus Status { get; set; }

        public string Assunto { get; set; }

        #endregion

        #region + RecuperarRegistro
        public string RecuperarRegistro()
        {
            return String.Format(PATTERN,
                Id,
                Status.ToString(),
                REG,
                REGMasked,
                Entrada.ToString(PATTERN_DATE),
                Prevista.ToString(PATTERN_DATE),
                Saida.ToString(PATTERN_DATE),
                Responsavel,
                Destino,
                Assunto.Trim().Length > 100 ? Assunto.Trim().Substring(0, 96) + " ..." : Assunto.Trim()
                );
        }

        #endregion


        #region + Criar
        public static Tramite Criar(string linha)
        {

            if (String.IsNullOrWhiteSpace(linha))
                return null;

            var campos = linha.Split(';');

            if (campos.Length < 9)
                return null;

            return new Tramite
            {
                Id = TryParseInt(campos[0]),
                Status = TryParseStatus(campos[1]),
                REG = campos[2],
                REGMasked = campos[3],
                Entrada =TryParseDate(campos[4]),
                Prevista = TryParseDate(campos[5]),
                Saida = TryParseDate(campos[6]),
                Responsavel = campos[7],
                Destino = campos[8],
                Assunto = campos[9],
            };
        }

        #endregion

        #region - TryParseInt
        private static int TryParseInt(string str)
        {
            int value;
            if (!Int32.TryParse(str, out value))
                value = 0;
            return value;
        }
        #endregion

        #region - TryParseDate
        private static DateTime TryParseDate(string str)
        {
            DateTime value;
            if (!DateTime.TryParseExact(str, PATTERN_DATE, CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                value = DateTime.Now;
            return value;
        }
        #endregion

        #region - TryParseStatus
        private static TramiteStatus TryParseStatus(string str)
        {
            TramiteStatus value;

            if (!Enum.TryParse<TramiteStatus>(str, out value))
                value = TramiteStatus.Interno;
            return value;
        }
        #endregion

    }
}

