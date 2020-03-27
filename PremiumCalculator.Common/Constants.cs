namespace PremiumCalculator.Common
{
    public class Constants
    {
        public struct States
        {
            public const string NY = "NY";
            public const string AL = "AL";
            public const string AK = "AK";
            public const string Other = "*";
        }

        public struct MonthOfBirth
        {
            public const int August = 8;
            public const int January = 1;
            public const int November = 11;
            public const int December = 12;
            public const int Other = 0;
        }


        public struct Months
        {
            public const string August = "8";
            public const string January = "1";
            public const string November = "11";
            public const string December = "12";
            public const string Other = "0";
        }

        public const string MessageGeneral= "La edad ingresada es incorrecto o no encuentra su equivalencia";
        public const string Message= "No encuentra su equivalencia";
    }
}
